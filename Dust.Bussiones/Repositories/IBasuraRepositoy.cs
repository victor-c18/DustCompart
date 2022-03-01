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
        Task<IEnumerable<BasurasDTO>> GetAllBasuras();
        Task<BasurasDTO> GetBasurasDetails(int id);
        Task<bool> insertBasuras(BasurasDTO basuras);
        Task<bool> UpdateBasuras(BasurasDTO basuras);
        Task<bool> deleteBasuras(BasurasDTO basuras);
    }
}
