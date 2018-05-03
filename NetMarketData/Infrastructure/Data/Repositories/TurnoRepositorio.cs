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
    public class TurnoRepositorio : EFRepositorio<Turno>
    {
        public long guardarTurno(TurnoDTO h)
        {
            Turno ho = new Turno()
            {
                idSucursal = h.idSucursal,
                apertura = h.apertura,
                cierre = h.cierre
            };
            Add(ho);
            SaveChanges();
            return ho.idTurno;
        }

        public void ModificarTurno(TurnoDTO t)
        {
            Turno tu = this.Get(t.idTurno);
            tu.apertura = t.apertura;
            tu.cierre = t.cierre;
            Update(tu);
            SaveChanges();
        }

        public void EliminarTurno(TurnoDTO t)
        {
            var tu = Get(t.idTurno);
            Remove(tu);
            SaveChanges();
        }

        public Turno obtenerTurno(TurnoDTO t)
        {
            var e = Get(t.idTurno);
            return e;
        }

        public List<Turno> obtenerTurnos(TurnoDTO t)
        {
            return BuildQuery().Where(x => x.idSucursal == t.idSucursal).ToList();
        }   
    }
}
