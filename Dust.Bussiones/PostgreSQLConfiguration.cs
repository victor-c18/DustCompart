using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DustCompact.Data
{
   public class PostgreSQLConfiguration
    {
       
        public PostgreSQLConfiguration(string connectionstring) => ConnectionString = connectionstring;
        public string ConnectionString { get; set; }
    }
}
