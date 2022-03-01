using Dapper; ///Dapper informacion de las datas
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
    /// <summary>
    /// IBasuraRepositoy representa la interfaz de implementacion para la integracion de los datos 
    /// </summary>
    public class BasuraRespository : IBasuraRepositoy
    {
        private PostgreSQLConfiguration _connectionString;

        public BasuraRespository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> deleteBasuras(Basuras basuras)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM public.""tbl_Desperdicio""
                        WHERE id = @iId";
            var result =  await db.ExecuteAsync(sql, new { Id = basuras.iId });
            return result > 0;
        }

        public async Task<IEnumerable<Basuras>> GetAllBasuras()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT iid,iid_residuo,iid_user,dpeso,ccomentario,dtfechacreacion,dtfechamodificacion,dtfechaeliminacion
                        FROM public.""tbl_Desperdicio"" ";

            return await db.QueryAsync<Basuras>(sql, new { });

        }

        public async Task<Basuras> GetBasurasDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT iid,iid_residuo,iid_user,dpeso,ccomentario,dtfechacreacion,dtfechamodificacion,dtfechaeliminacion
                        FROM public.""tbl_Desperdicio"" 
                        WHERE id = @iId ";

            return await db.QueryFirstOrDefaultAsync<Basuras>(sql, new { iId = id });
        }

        public async Task<bool> insertBasuras(Basuras basuras)
        {
            var db = dbConnection();

            var sql = @"
                        INSER INTO pubic.""tbl_Desperdicio"" (iid_residuo, iid_user, dpeso, ccomentarios, dtfechacreacion, dtfechamodificacion pdteechaeliminacion)
                        VALUES (@iId,@iId_Residuo,@iId_User,@dPeso,@cComentario,@dtFechaCreacion, @dtFechaModificacion, @dtFechaEliminacion) ";

            var result = await db.ExecuteAsync(sql, new { basuras.iId_Residuo, basuras.iId_User, basuras.dtFechaCreacion, basuras.dtFechaModificacion, basuras.dtFechaEliminacion});
            return result >0 ;
        }

        public async Task<bool> UpdateBasuras(Basuras basuras)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE pubic.""tbl_Desperdicio"" 
                        SET iid= @iId,
                            iid_residuo= @iId_Residuo,
                            iid_user= @iId_User,
                            dpeso= @dPeso,
                            ccomentarios= @cComentario,
                            dtfechacreacion= @dtFechaCreacion,
                            dtfechamodificacion= @dtFechaModificacion,
                            pdtfechaeliminacion= @dtFechaEliminacion,
                        WHERE id = @iId
                        ";

            var result = await db.ExecuteAsync(sql, new { basuras.iId, basuras.iId_Residuo, basuras.iId_User, basuras.dtFechaCreacion, basuras.dtFechaModificacion, basuras.dtFechaEliminacion });
            return result > 0;
        }
    }
}
