using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;

namespace TorinosERP.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DbSession _session;

        public ProdutoRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> AdicionarAsync(Produto produto)
        {
            string sql = @"INSERT INTO produto (nome, descricao, preco, estoque) 
                        VALUES (@Nome, @Descricao, @Preco, @Estoque) 
                        RETURNING id";

            return await _session.Connection.ExecuteScalarAsync<int>(sql, produto, _session.Transaction);
        }

        public async Task<IEnumerable<Produto>> ObterTodosAsync()
        {
            string sql = "SELECT * FROM produto ORDER BY nome";
            return await _session.Connection.QueryAsync<Produto>(sql, null, _session.Transaction);
        }

        public async Task<Produto?> ObterPorIdAsync(int id)
        {
            string sql = "SELECT * FROM produto WHERE id = @Id";
            return await _session.Connection.QueryFirstOrDefaultAsync<Produto>(sql, new { Id = id }, _session.Transaction);
        }

        public async Task AtualizarAsync(Produto produto)
        {
            string sql = @"UPDATE produto 
                        SET nome = @Nome, descricao = @Descricao, preco = @Preco 
                        WHERE id = @Id";            
            await _session.Connection.ExecuteAsync(sql, produto, _session.Transaction);
        }

        public async Task BaixarEstoqueAsync(int produtoId, int quantidade)
        {            
            string sql = "UPDATE produto SET estoque = estoque - @Quantidade WHERE id = @Id";
            await _session.Connection.ExecuteAsync(sql, new { Quantidade = quantidade, Id = produtoId }, _session.Transaction);
        }

        public async Task RemoverAsync(int id)
        {
            string sql = "DELETE FROM produto WHERE id = @Id";
            await _session.Connection.ExecuteAsync(sql, new { Id = id }, _session.Transaction);
        }

        public async Task ReporEstoqueAsync(int produtoId, int quantidade)
        {
            var sql = "UPDATE produto SET estoque = estoque + @Quantidade WHERE id = @Id";

            await _session.Connection.ExecuteAsync(sql,
                new { Quantidade = quantidade, Id = produtoId },
                _session.Transaction);
        }
    }
}
