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
    public class EmpresaService
    {
        private readonly EmpresaRepositorio Empresarepositorio;

        public EmpresaService()
        {
            this.Empresarepositorio = new EmpresaRepositorio();
        }

        public long GuardarEmpresa(EmpresaDTO e)
        {
            if (e.idEmpresa == 0)
                e.idEmpresa = Empresarepositorio.guardarEmpresa(e.nombrempresa,e.nit,e.razon,e.direccion);
            else
                Empresarepositorio.ModificarEmpresa(e.idEmpresa,e.nombrempresa, e.nit, e.razon, e.direccion);
            return e.idEmpresa;
        }

        public void EliminarEmpresa(EmpresaDTO e)
        {
            Empresarepositorio.EliminarEmpresa(e.idEmpresa);
        }

        public Empresa ObtenerEmpresa(EmpresaDTO e)
        {
            return Empresarepositorio.obtenerEmpresa(e.idEmpresa);
        }

        public List<Empresa> ObtenerEmpresas()
        {
            return Empresarepositorio.obtenerEmpresas();
        }

    }
}
