using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Services
{
    public class SucursalService
    {
        private readonly SucursalRepositorio Sucursalrepositorio;

        public SucursalService()
        {
            this.Sucursalrepositorio = new SucursalRepositorio();
        }

        public long GuardarSucursal(SucursalDTO s)
        {
            if (s.idSucursal == 0)
                s.idSucursal = Sucursalrepositorio.guardarSucursal(s);
            else
                Sucursalrepositorio.ModificarSucursal(s);
            return s.idSucursal;
        }

        public void EliminarSucursal(SucursalDTO s)
        {
            Sucursalrepositorio.EliminarSucursal(s);
        }

        public Sucursal ObtenerSucursal(SucursalDTO s)
        {
            return Sucursalrepositorio.obtenerSucursal(s);
        }

        public List<Sucursal> ObtenerSucursales(SucursalDTO s)
        {
            return Sucursalrepositorio.obtenerSucursales(s);
        }
    }
}
