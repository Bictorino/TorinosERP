using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TorinosERP.Domain.DTOs;
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
                    venda.CarregarItens(itens);
                }

                return venda;
            }
        }

        public async Task RemoverItemAsync(int idItem)
        {
            string sql = "DELETE FROM venda_item WHERE id = @Id";
            await _session.Connection.ExecuteAsync(sql, new { Id = idItem }, _session.Transaction);
        }

        public async Task<IEnumerable<VendaItem>> ObterItensDaVendaAsync(int vendaId)
        {
            string sql = "SELECT * FROM venda_item WHERE venda_id = @VendaId";
            return await _session.Connection.QueryAsync<VendaItem>(sql, new { VendaId = vendaId }, _session.Transaction);
        }

        public async Task<IEnumerable<VendaDTO.VendaResultadoDto>> PesquisarAsync(VendaDTO.FiltroVendaDto filtro)
        {
            var sql = new StringBuilder(@"
            SELECT 
                v.id AS Id,
                c.nome AS ClienteNome,
                v.data_cadastro AS DataCadastro,
                v.data_venda AS DataVenda,
                v.valor_total AS ValorTotal,
                v.status AS Status
            FROM venda v
            INNER JOIN cliente c ON v.cliente_id = c.id
            WHERE 1=1 ");

            var parametros = new DynamicParameters();
           
            if (filtro.ClienteId.HasValue)
            {
                sql.Append(" AND v.cliente_id = @ClienteId ");
                parametros.Add("ClienteId", filtro.ClienteId.Value);
            }

            if (filtro.Status.HasValue)
            {
                sql.Append(" AND v.status = @Status ");
                parametros.Add("Status", (int)filtro.Status.Value);
            }

            if (filtro.DataCadastroInicio.HasValue)
            {
                sql.Append(" AND v.data_cadastro >= @DataCadIni ");
                parametros.Add("DataCadIni", filtro.DataCadastroInicio.Value.Date);
            }
            if (filtro.DataCadastroFim.HasValue)
            {
                sql.Append(" AND v.data_cadastro <= @DataCadFim ");
                parametros.Add("DataCadFim", filtro.DataCadastroFim.Value.Date.AddDays(1).AddTicks(-1));
            }

            if (filtro.DataEfetivacaoInicio.HasValue)
            {
                sql.Append(" AND v.data_venda >= @DataEfecIni ");
                parametros.Add("DataEfecIni", filtro.DataEfetivacaoInicio.Value.Date);
            }
            if (filtro.DataEfetivacaoFim.HasValue)
            {
                sql.Append(" AND v.data_venda <= @DataEfecFim ");
                parametros.Add("DataEfecFim", filtro.DataEfetivacaoFim.Value.Date.AddDays(1).AddTicks(-1));
            }

            sql.Append(" ORDER BY v.data_cadastro DESC");

            return await _session.Connection.QueryAsync<VendaDTO.VendaResultadoDto>(
                sql.ToString(),
                parametros,
                _session.Transaction
            );
        }

    }
}
