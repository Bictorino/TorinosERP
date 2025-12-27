using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;

namespace TorinosERP.Application.Services
{
    public class VendaService
    {
        private readonly DbSession _session;
        private readonly IVendaRepository _vendaRepo;
        private readonly IProdutoRepository _produtoRepo;
        
        public VendaService(
            DbSession session,
            IVendaRepository vendaRepo,
            IProdutoRepository produtoRepo)
        {
            _session = session;
            _vendaRepo = vendaRepo;
            _produtoRepo = produtoRepo;
        }

        public async Task<Venda> SalvarRascunhoAsync(Venda venda)
        {

            if (venda.Status != Domain.Enums.VendaStatus.Aberta)
                throw new Exception("Não é possível alterar uma venda que já foi finalizada ou cancelada.");

            _session.Transaction = _session.Connection.BeginTransaction();

            try
            {                
                if (venda.Id == 0)
                {                    
                    await _vendaRepo.AdicionarAsync(venda); 
                }
                else
                {                    
                    await _vendaRepo.AtualizarAsync(venda);
                    
                    await _vendaRepo.RemoverItensDaVendaAsync(venda.Id);
                }
                
                foreach (var item in venda.Itens)
                {                    
                    item.AssociarVenda(venda.Id);
                    await _vendaRepo.AdicionarItemAsync(item);
                }

                _session.Transaction.Commit();
                return venda; 
            }
            catch
            {
                _session.Transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Transaction?.Dispose();
                _session.Transaction = null;
            }
        }

        public async Task EfetivarVendaAsync(Venda venda)
        {            
            if (venda.Id == 0)
                throw new Exception("A venda precisa ser salva antes de ser efetivada.");

            _session.Transaction = _session.Connection.BeginTransaction();

            try
            {                
                if (venda.Status != Domain.Enums.VendaStatus.Aberta)
                    throw new Exception("Venda já está finalizada ou cancelada.");

                foreach (var item in venda.Itens)
                {
                    var produtoNoEstoque = await _produtoRepo.ObterPorIdAsync(item.ProdutoId);

                    if (produtoNoEstoque == null)
                        throw new Exception($"Produto do item (ID {item.ProdutoId}) não existe mais no cadastro.");

                    if (produtoNoEstoque.Estoque < item.Quantidade)
                        throw new Exception($"Estoque insuficiente para '{produtoNoEstoque.Nome}'. Necessário: {item.Quantidade}, Disponível: {produtoNoEstoque.Estoque}");
                    
                    await _produtoRepo.BaixarEstoqueAsync(item.ProdutoId, item.Quantidade);
                }
                
                venda.Efetivar();
                await _vendaRepo.AtualizarAsync(venda);

                _session.Transaction.Commit();
            }
            catch
            {
                _session.Transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Transaction?.Dispose();
                _session.Transaction = null;
            }
        }

        public async Task EstornarVendaAsync(Venda venda)
        {            
            if (venda.Status != Domain.Enums.VendaStatus.Efetivada)
                throw new Exception("Apenas vendas finalizadas podem ser estornadas para correção.");

            _session.Transaction = _session.Connection.BeginTransaction();

            try
            {                
                foreach (var item in venda.Itens)
                {
                    await _produtoRepo.ReporEstoqueAsync(item.ProdutoId, item.Quantidade);
                }
                
                venda.Reabrir();
                
                await _vendaRepo.AtualizarAsync(venda);

                _session.Transaction.Commit();
            }
            catch
            {
                _session.Transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Transaction?.Dispose();
                _session.Transaction = null;
            }
        }

        public async Task CancelarVendaAsync(Venda venda)
        {
            if (venda.Status == Domain.Enums.VendaStatus.Cancelada)
                throw new Exception("Esta venda já está cancelada.");

            _session.Transaction = _session.Connection.BeginTransaction();

            try
            {                
                if (venda.Status == Domain.Enums.VendaStatus.Efetivada)
                {
                    foreach (var item in venda.Itens)
                    {
                        await _produtoRepo.ReporEstoqueAsync(item.ProdutoId, item.Quantidade);
                    }
                }
                
                venda.Cancelar();
                
                await _vendaRepo.AtualizarAsync(venda);

                _session.Transaction.Commit();
            }
            catch
            {
                _session.Transaction.Rollback();
                throw;
            }
            finally
            {
                _session.Transaction?.Dispose();
                _session.Transaction = null;
            }
        }
    }
}
