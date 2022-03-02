using Dapper; ///Dapper informacion de las datas
using DustCompact.Data;
using DustCompact.Model;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Data es equivalente al BUSINESS
/// </summary>

namespace DustCompact.Bussiones.Repositories
{
    /// <summary>
    /// IBasuraRepositoy representa la interfaz de implementacion para la integracion de los datos 
    /// </summary>
    public class BasuraRespository : IBasuraRepositoy
    {
        /// <summary>
        /// Variable para la connection string
        /// </summary>
        private PostgreSQLConfiguration _connectionString;

        /// <summary>
        /// Llamado del conection string
        /// </summary>
        /// <param name="connectionString">inyeccion que proviene del startup</param>
        public BasuraRespository(PostgreSQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        /// <summary>
        /// coneccion del sistema 
        /// </summary>
        /// <returns>retorna el conection string de postgress</returns>
        protected NpgsqlConnection dbConnection()
        {
            return new NpgsqlConnection(_connectionString.ConnectionString);
        }

        /// <summary>
        /// eliminacion de objetos por medio de dapper
        /// </summary>
        /// <param name="basuras">objeto basuras</param>
        /// <returns></returns>
        public async Task<bool> deleteBasuras(BasurasDTO basuras)
        {
            var db = dbConnection();
            var sql = @"
                        DELETE 
                        FROM public.""tbl_Desperdicio""
                        WHERE id = @iId";
            var result =  await db.ExecuteAsync(sql, new { Id = basuras.iId });///execute para generar la ejecusion del query
            return result > 0;
        }

        /// <summary>
        /// obtener todas las basuras
        /// </summary>
        /// <returns>Retorna todos los elementos</returns>
        public async Task<IEnumerable<BasurasDTO>> GetAllBasuras()
        {
            var db = dbConnection();///instancia de la dbconection

            ///Generando el query en string el @ se utiliza para determinar una query de varias filas
            var sql = @"
                        SELECT iid,iid_residuo,iid_user,dpeso,ccomentario,dtfechacreacion,dtfechamodificacion,dtfechaeliminacion
                        FROM public.""tbl_Desperdicio"" ";///cuando un nombre tiene mayusculas en postgres se requiere 4 """" comillas

            return await db.QueryAsync<BasurasDTO>(sql, new { });///query para generar una consulta

        }

        public async Task<BasurasDTO> GetBasurasDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT iid,iid_residuo,iid_user,dpeso,ccomentario,dtfechacreacion,dtfechamodificacion,dtfechaeliminacion
                        FROM public.""tbl_Desperdicio"" 
                        WHERE id = @iId ";

            return await db.QueryFirstOrDefaultAsync<BasurasDTO>(sql, new { iId = id });///querypirstordefaul para generar una consulta de un solo elemento
        }

        public async Task<bool> insertBasuras(BasurasDTO basuras)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO public.""tbl_Desperdicio"" (""iid_residuo"", ""iid_user"", ""dpeso"",""ccomentario"", ""dtfechacreacion"", ""dtfechamodificacion"", ""dtfechaeliminacion"")
                        VALUES (@iId_Residuo,@iId_User,@dPeso,@cComentarios,@dtFechaCreacion, @dtFechaModificacion, @dtFechaEliminacion) ";

            var result = await db.ExecuteAsync(sql, new { basuras.iId_Residuo, basuras.iId_User,basuras.dPeso,basuras.cComentarios, basuras.dtFechaCreacion, basuras.dtFechaModificacion, basuras.dtFechaEliminacion});
            return result >0 ;///
        }

        public async Task<bool> UpdateBasuras(BasurasDTO basuras)
        {
            var db = dbConnection();
            ///se realiza una igualacion de los parametros a insertar vs los para metros de las cabeceras de la tabla
            var sql = @"
                        UPDATE public.""tbl_Desperdicio"" 
                        SET iid= @iId,
                            iid_residuo= @iId_Residuo,
                            iid_user= @iId_User,
                            dpeso= @dPeso,
                            ccomentarios= @cComentarios,
                            dtfechacreacion= @dtFechaCreacion,
                            dtfechamodificacion= @dtFechaModificacion,
                            pdtfechaeliminacion= @dtFechaEliminacion,
                        WHERE id = @iId
                        ";

            var result = await db.ExecuteAsync(sql, new { basuras.iId, basuras.iId_Residuo, basuras.iId_User,basuras.dPeso,basuras.cComentarios, basuras.dtFechaCreacion, basuras.dtFechaModificacion, basuras.dtFechaEliminacion });
            return result > 0;
        }
    }
}
