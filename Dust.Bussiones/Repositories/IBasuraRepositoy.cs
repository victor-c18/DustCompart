using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DustCompact.Model;

namespace DustCompact.Bussiones.Repositories
{
    public interface IBasuraRepositoy
    {
        Task<IEnumerable<Basuras>> GetAllBasuras();
        Task<Basuras> GetBasurasDetails(int id);
        Task<bool> insertBasuras(Basuras basuras);
        Task<bool> UpdateBasuras(Basuras basuras);
        Task<bool> deleteBasuras(Basuras basuras);
    }
}
