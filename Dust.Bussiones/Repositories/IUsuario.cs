using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustCompact.Data.Repositories
{
    public interface IUsuario
    {
        Task<IEnumerable <Usuario>> GetAllUsuarios();
        Task<bool> insertUsuario(Usuario usuario);
    }
}
