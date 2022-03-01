using DustCompact.Data;
using DustCompact.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustCompact.Bussiones.Repositories
{
    public class BasuraRespository : IBasuraRepositoy
    {
        private PostgreSQLConfiguration _connectionString;
        
        public BasuraRespository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        
        protected NpgsqlConnection bdConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public Task<bool> deleteBasuras(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Basuras>> GetAllBasuras()
        {
            var db = bdConnection();

            return null;
        }

        public Task<Basuras> GetBasurasDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> insertBasuras(Basuras basuras)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBasuras(Basuras basuras)
        {
            throw new NotImplementedException();
        }
    }
}
