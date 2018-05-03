using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class ImagenDTO
    {
        public long idImagen { get; set; }
        public string ruta { get; set; }
        public bool principal { get; set; }
        public long idcategoria { get; set; }
        public long idProducto { get; set; }
        public long idProductoEmpresa { get; set; } 
        public long idProductoSucursal { get; set; }
        public long idEmpresa { get; set; }
        public long idSucursal { get; set; }
        public long idOferta { get; set; }
        public long idpersona { get; set; }
        //public long idDestacado { get; set; }

    }
}
