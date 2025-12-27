using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TorinosERP.Infra.Data.Context
{
    public class DbSession : IDisposable
    {
        public IDbConnection Connection { get; }
        public IDbTransaction? Transaction { get; set; }

        public DbSession()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TorinosERP"].ConnectionString;

            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Close();
            Connection?.Dispose();
        }
    }
}
