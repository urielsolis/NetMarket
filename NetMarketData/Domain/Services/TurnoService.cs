using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Services
{
    public class TurnoService
    {
        private readonly TurnoRepositorio turnorepositorio;
        private readonly DetalleHorarioRepositorio detallerepositorio;

        public TurnoService()
        {
            this.turnorepositorio = new TurnoRepositorio();
        }

        public long GuardarTurno(TurnoDTO t)
        {
            if (t.idTurno == 0)
                t.idTurno = turnorepositorio.guardarTurno(t);
            else
                turnorepositorio.ModificarTurno(t);
            return t.idTurno;
        }

        public void EliminarTurno(TurnoDTO t)
        {
            turnorepositorio.EliminarTurno(t);
        }

        public Turno ObtenerTurno(TurnoDTO t)
        {
            return turnorepositorio.obtenerTurno(t);
        }

        public List<Turno> Obtenerproductos(TurnoDTO t)
        {
            return turnorepositorio.obtenerTurnos(t);
        }
        public bool comprobardisponibilidad(long idsucursal)
        {
            try
            {
                bool abi = false;
                string hoy = DateTime.Now.ToString("dd/MM/yyyy");
                string now = DateTime.Now.ToString("HH:mm");
                int hoyf = (int)Convert.ToDateTime(hoy, new CultureInfo("es-ES")).DayOfWeek;
                DetalleHorarioDTO dh = new DetalleHorarioDTO();
                dh.idDia = hoyf;
                dh.idTurno = idsucursal;
                List<DetalleHorario> ldh = detallerepositorio.obtenerDetallesHorarioPorDiaYSucursal(dh);
                if (ldh == null)
                {

                }
                else
                {
                    List<DiaDTO> semana = new List<DiaDTO>();
                    DiaDTO daily = new DiaDTO();
                    foreach (var day in ldh)
                    {
                        if (Convert.ToDateTime(now) > Convert.ToDateTime(day.Turno.apertura) && Convert.ToDateTime(now) < Convert.ToDateTime(day.Turno.cierre))
                        {
                            abi = true;
                            break;
                        }
                        else
                        {
                            abi = false;
                        }
                    }
                }
                return abi;
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

    }
}
