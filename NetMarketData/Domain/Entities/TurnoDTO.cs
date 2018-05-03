using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class TurnoDTO
    {
        public long idTurno { get; set; }
        public long idSucursal { get; set; }
        public string apertura { get; set; }
        public string cierre { get; set; }
    }
}
