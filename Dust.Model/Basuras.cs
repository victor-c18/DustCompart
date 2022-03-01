using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustCompact.Model
{

    public class Basuras
    {
        public int iId { get; set; }
        public int iId_Residuo { get; set; }
        public int iId_User { get; set; }
        public double dPeso { get; set; }
        public string cComentarios { get; set; }
        public DateTime? dtFechaCreacion { get; set; }
        public DateTime? dtFechaModificacion { get; set; }
        public DateTime? dtFechaEliminacion { get; set; }

    }
}
