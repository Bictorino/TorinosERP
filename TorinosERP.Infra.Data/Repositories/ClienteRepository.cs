using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;
using Npgsql;

namespace TorinosERP.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DbSession _session;

        public ClienteRepository(DbSession session)
        {
            _session = session;
        }

        public async Task<int> AdicionarAsync(Cliente cliente)
        {
            try
            {
                string sql = @"INSERT INTO cliente (nome, email, telefone) 
                       VALUES (@Nome, @Email, @Telefone) 
                       RETURNING id";

                return await _session.Connection.ExecuteScalarAsync<int>(sql, cliente, _session.Transaction);
            }
            catch (PostgresException ex)
            {                
                if (ex.SqlState == "23505" && ex.ConstraintName?.Contains("email") == true)
                {
                    throw new Exception("Este e-mail já está cadastrado para outro cliente.");
                }

                throw;
            }
        }

        public async Task<IEnumerable<Cliente>> ObterTodosAsync()
        {
            string sql = "SELECT * FROM cliente ORDER BY nome";
            return await _session.Connection.QueryAsync<Cliente>(sql, null, _session.Transaction);
        }

        public async Task<Cliente?> ObterPorIdAsync(int id)
        {
            string sql = "SELECT * FROM cliente WHERE id = @Id";
            return await _session.Connection.QueryFirstOrDefaultAsync<Cliente>(sql, new { Id = id }, _session.Transaction);
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            try
            {
                string sql = @"UPDATE cliente 
                       SET nome = @Nome, email = @Email, telefone = @Telefone 
                       WHERE id = @Id";
                await _session.Connection.ExecuteAsync(sql, cliente, _session.Transaction);
            }
            catch (PostgresException ex)
            {
                if (ex.SqlState == "23505" && ex.ConstraintName?.Contains("email") == true)
                {
                    throw new Exception("Este e-mail já está em uso por outro cliente.");
                }
                throw;
            }
        }

        public async Task RemoverAsync(int id)
        {
            string sql = "DELETE FROM cliente WHERE id = @Id";
            await _session.Connection.ExecuteAsync(sql, new { Id = id }, _session.Transaction);
        }
    }
}
