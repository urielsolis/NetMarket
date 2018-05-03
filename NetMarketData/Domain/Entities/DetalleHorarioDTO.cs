using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Entities
{
    public class DetalleHorarioDTO
    {
        public long idTurno { get; set; }
        public long idDia { get; set; }
        public bool estado { get; set; }
    }
}
