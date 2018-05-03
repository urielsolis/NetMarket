using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet.RequestEntity
{
    public class CategoriaRequest
    {
        public long idCategoria { get; set; }
        public string nombre { get; set; }
        public string rutaimagen { get; set; }
    }
}
