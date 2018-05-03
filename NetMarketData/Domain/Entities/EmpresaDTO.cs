using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class EmpresaDTO
    {
        public long idEmpresa { get; set; }
        public string nombrempresa { get; set; }
        public string nit { get; set; }
        public string razon { get; set; }
        public string direccion { get; set; }
        public string rutaimagen { get; set; }
    }
}
