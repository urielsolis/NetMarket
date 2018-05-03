using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class ProductoSucursalDTO
    {
        public long idProductoSucursal { get; set; }
        public long idProductoEmpresa { get; set; }
        public long idProducto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public long idSucursal { get; set; }
        public string nombreSucursal { get; set; }
        public long idEmpresa { get; set; }
        public string nombreEmpresa { get; set; }
        public long idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string rutaimagen { get; set; }
    }
}
