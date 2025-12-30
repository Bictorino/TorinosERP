using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.DTOs;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Enums;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;
using static TorinosERP.Domain.DTOs.VendaDTO;

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
            string sql = @"
                            SELECT * FROM venda WHERE id = @Id;
                            SELECT * FROM venda_item WHERE venda_id = @Id"; 

            using (var multi = await _session.Connection.QueryMultipleAsync(sql, new { Id = id }, _session.Transaction))
            {                
                var venda = await multi.ReadFirstOrDefaultAsync<Venda>();

                if (venda == null) return null;
                var itens = await multi.ReadAsync<VendaItem>();
                
                if (itens != null)
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

        public async Task<IEnumerable<VendaDTO.VendaResultado>> PesquisarAsync(VendaDTO.VendaFiltro filtro)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT ");
            sql.AppendLine("    v.id AS Id,");
            sql.AppendLine("    c.nome AS ClienteNome,");
            sql.AppendLine("    v.data_cadastro AS DataCadastro,");
            sql.AppendLine("    v.data_venda AS DataVenda,");
            sql.AppendLine("    v.valor_total AS ValorTotal,");
            sql.AppendLine("    v.status AS Status");
            sql.AppendLine("FROM venda v");
            sql.AppendLine("INNER JOIN cliente c ON v.cliente_id = c.id");
            sql.AppendLine("WHERE 1=1");

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

            return await _session.Connection.QueryAsync<VendaDTO.VendaResultado>(
                sql.ToString(),
                parametros,
                _session.Transaction
            );
        }

        public async Task<IEnumerable<VendaRelatorioGeral>> ObterDadosRelatorioAsync(
        int? clienteId,
        int? statusId,
        DateTime dataInicial,
        DateTime dataFinal,
        bool filtrarPorDataVenda)
        {
            var sql = new StringBuilder();
            var parametros = new DynamicParameters();

            sql.AppendLine("SELECT ");
            sql.AppendLine("    c.nome as ClienteNome,");
            sql.AppendLine("    CASE ");
            sql.AppendLine("        WHEN v.status = 0 THEN 'Aberta'");
            sql.AppendLine("        WHEN v.status = 1 THEN 'Finalizada'");
            sql.AppendLine("        WHEN v.status = 2 THEN 'Cancelada'");
            sql.AppendLine("        ELSE 'Outro' ");
            sql.AppendLine("    END as Status,");
            sql.AppendLine("    v.id as VendaId,");
            sql.AppendLine("    v.data_venda as DataVenda,");
            sql.AppendLine("    v.data_cadastro as DataCadastro,");
            sql.AppendLine("    v.valor_total as TotalVenda,");
            sql.AppendLine("    p.nome as ProdutoNome,");
            sql.AppendLine("    vi.quantidade as Quantidade,");
            sql.AppendLine("    vi.preco_unitario as PrecoUnitario,");
            sql.AppendLine("    vi.subtotal as SubtotalItem ");
            sql.AppendLine("FROM venda v ");
            sql.AppendLine("INNER JOIN cliente c ON v.cliente_id = c.id ");
            sql.AppendLine("INNER JOIN venda_item vi ON vi.venda_id = v.id ");
            sql.AppendLine("INNER JOIN produto p ON vi.produto_id = p.id ");
            sql.AppendLine("WHERE 1=1");

            parametros.Add("@DataInicial", dataInicial.Date);
            parametros.Add("@DataFinal", dataFinal.Date.AddDays(1).AddSeconds(-1));

            if (filtrarPorDataVenda)
            {
                sql.AppendLine("AND v.data_venda >= @DataInicial AND v.data_venda <= @DataFinal");
            }
            else
            {
                sql.AppendLine("AND v.data_cadastro >= @DataInicial AND v.data_cadastro <= @DataFinal");
            }

            if (clienteId.HasValue && clienteId.Value > 0)
            {
                sql.AppendLine("AND v.cliente_id = @ClienteId");
                parametros.Add("@ClienteId", clienteId.Value);
            }

            if (statusId.HasValue && statusId.Value >= 0)
            {
                sql.AppendLine("AND v.status = @StatusId");
                parametros.Add("@StatusId", statusId.Value);
            }

            sql.AppendLine("ORDER BY c.nome, v.status, v.id");

            var conn = _session.Connection;
            return await conn.QueryAsync<VendaRelatorioGeral>(sql.ToString(), parametros);
        }
    }
}
