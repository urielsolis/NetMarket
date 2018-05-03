using Data.Infrastructure.Data.Repositories;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    public class SucursalRepositorio : EFRepositorio<Sucursal>
    {
        public long guardarSucursal(SucursalDTO s)
        {
            Sucursal e = new Sucursal()
            {
                nombreSucursal = s.nombre,
                direccion = s.direccion,
                idEmpresa = s.idEmpresa,
                eliminado = false
            };
            Add(e);
            SaveChanges();
            return e.idEmpresa;
        }

        public void ModificarSucursal(SucursalDTO s)
        {
            Sucursal e = this.Get(s.idSucursal);
            e.nombreSucursal = s.nombre;
            e.direccion = s.direccion;
            Update(e);
            SaveChanges();
        }

        public void EliminarSucursal(SucursalDTO s)
        {
            Sucursal e = Get(s.idSucursal);
            e.eliminado = true;
            SaveChanges();
        }

        public Sucursal obtenerSucursal(SucursalDTO s)
        {
            var e = Get(s.idSucursal);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }

        }

        public List<Sucursal> obtenerSucursales(SucursalDTO s)
        {
            return GetAll().Where(x => x.eliminado == false && x.idEmpresa==s.idEmpresa).ToList();
        }
    }
}
