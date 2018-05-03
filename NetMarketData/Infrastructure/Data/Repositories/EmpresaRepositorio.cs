using Data.Infrastructure.Data.Repositories;
using NetMarketData.Infrastructure.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    public class EmpresaRepositorio : EFRepositorio<Empresa>
    {
        public long guardarEmpresa(string nombre, string nit, string razon, string dir)
        {
            Empresa e = new Empresa()
            {
                nombreEmpresa = nombre,
                nit = nit,
                razonSocial = razon,
                direccionCentral = dir,
                eliminado = false
            };
            Add(e);
            SaveChanges();
            return e.idEmpresa;
        }

        public void ModificarEmpresa(long id, string nombre, string nit, string razon, string dir)
        {
            Empresa e = this.Get(id);
            e.nombreEmpresa = nombre;
            e.nit = nit;
            e.razonSocial = razon;
            e.direccionCentral = dir;
            Update(e);
            SaveChanges();
        }

        public void EliminarEmpresa(long id)
        {
            Empresa e = Get(id);
            e.eliminado = true;
            SaveChanges();
        }

        public Empresa obtenerEmpresa(long id)
        {
            var e = Get(id);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }
            
        }

        public List<Empresa> obtenerEmpresas()
        {
            return GetAll().Where(x => x.eliminado==false).ToList();
        }
    }
}
