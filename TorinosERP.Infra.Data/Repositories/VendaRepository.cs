using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Enums;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;

namespace TorinosERP.Infra.Data.Repositories
{
    public class VendaRepository : IVendaRepository
    {
        private readonly DbSession _session;

        public VendaRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> AdicionarAsync(Venda venda)
        {
            string sql = @"INSERT INTO venda (cliente_id, valor_total, status) 
                        VALUES (@ClienteId, @ValorTotal, @Status) 
                        RETURNING id, data_cadastro";

            var resultado = await _session.Connection.QuerySingleAsync<dynamic>(sql, venda, _session.Transaction);

            venda.ConfirmarVenda((int)resultado.id, (DateTime)resultado.data_cadastro, null, venda.Status);

            return venda.Id;
        }

        public async Task AtualizarAsync(Venda venda)
        {            
            string sql = @"UPDATE venda 
                        SET valor_total = @ValorTotal, 
                            status = @Status, 
                            data_venda = @DataVenda 
                        WHERE id = @Id";

            await _session.Connection.ExecuteAsync(sql, venda, _session.Transaction);
        }

        public async Task AdicionarItemAsync(VendaItem item)
        {
            string sql = @"INSERT INTO venda_item (venda_id, produto_id, produto_nome, quantidade, preco_unitario) 
                        VALUES (@VendaId, @ProdutoId, @ProdutoNome, @Quantidade, @PrecoUnitario)";

            await _session.Connection.ExecuteAsync(sql, item, _session.Transaction);
        }

        public async Task RemoverItensDaVendaAsync(int vendaId)
        {
            string sql = "DELETE FROM venda_item WHERE venda_id = @VendaId";
            await _session.Connection.ExecuteAsync(sql, new { VendaId = vendaId }, _session.Transaction);
        }

        public async Task<Venda?> ObterPorIdAsync(int id)
        {            
            var sql = @"
                        SELECT * FROM venda WHERE id = @Id;
                        SELECT * FROM venda_item WHERE venda_id = @Id";

            using (var multi = await _session.Connection.QueryMultipleAsync(sql, new { Id = id }, _session.Transaction))
            {
                var vendaDto = await multi.ReadFirstOrDefaultAsync<dynamic>();

                if (vendaDto == null) return null;

                var statusEnum = (VendaStatus)Convert.ToInt32(vendaDto.status);
                var clienteId = Convert.ToInt32(vendaDto.cliente_id);
                var idVenda = Convert.ToInt32(vendaDto.id);

                DateTime dataCadastro = vendaDto.data_cadastro;
                DateTime? dataVenda = vendaDto.data_venda;

                var venda = new Venda(clienteId);
                venda.ConfirmarVenda(idVenda, dataCadastro, dataVenda, statusEnum);

                var itens = await multi.ReadAsync<VendaItem>();

                foreach (var item in itens)
                {
                    venda.AdicionarItem(item);
                }

                return venda;
            }
        }
    }
}
