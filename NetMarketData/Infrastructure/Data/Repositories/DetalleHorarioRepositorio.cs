using Data.Infrastructure.Data.Repositories;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    public class DetalleHorarioRepositorio : EFRepositorio<DetalleHorario>
    {
        public long guardarDetalleHorario(DetalleHorarioDTO dh)
        {
            DetalleHorario det = new DetalleHorario()
            {
                idTurno = dh.idTurno,
                idDia = dh.idDia,
                estado = true
            };
            Add(det);
            SaveChanges();
            return det.idTurno;
        }

        public void EliminarDetallesHorario(TurnoDTO t)
        {
            List<DetalleHorario> ldt = new List<DetalleHorario>();
            TurnoDTO tu = new TurnoDTO();
            tu.idSucursal = t.idSucursal;
            ldt = obtenerDetallesHorarioPorSucursal(tu);
            if (ldt != null && ldt.Count > 0)
            {
                foreach (var de in ldt)
                {
                    Remove(de);
                    SaveChanges();
                }
            }
            
        }

        public List<DetalleHorario> obtenerDetallesHorarioPorDiaYSucursal(DetalleHorarioDTO dh)
        {
            try
            {
                var e = BuildQuery().Where(x => x.idDia == dh.idDia && x.Turno.idSucursal == dh.idTurno).ToList();
                return e;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public List<DetalleHorario> obtenerDetallesHorarioPorSucursal(TurnoDTO t)
        {
            return BuildQuery().Where(x => x.Turno.idSucursal == t.idSucursal).ToList();
        }
    }
}
