using DustCompact.Bussiones.Repositories;
using DustCompact.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustCompact.Data.Repositories
{
    public class pruebas : IUsuario
    {
        private PostgreSQLConfiguration _connectionString;

        public pruebas(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection bdConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Usuario>> GetAllUsuarios()
        {
            var db = bdConnection();

            return null;
        }

        public Task<bool> insertUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
