using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class ProductoEmpresaDTO
    {
        public long idProductoEmpresa { get; set; }
        public long idProducto { get; set; }
        public decimal precio { get; set; }
        public string nombre { get; set; }
        public long idEmpresa {get;set;}
        public string nombreEmpresa { get; set; }
        public long idCategoria { get; set; }
        public string nombreCategoria { get; set; }
        public string rutaimagen { get; set; }
    }
}
