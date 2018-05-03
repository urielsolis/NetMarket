using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class SucursalDTO
    {
        public long idSucursal { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public long idEmpresa { get; set; } 
        public string nombreEmpresa { get; set; }
        public string rutaimagen { get; set; }
        public bool abierto { get; set; }
    }
}
