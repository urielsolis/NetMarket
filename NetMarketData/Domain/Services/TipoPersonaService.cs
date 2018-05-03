using NetMarketData.Infrastructure.Data.DataModels;
using NetMarketData.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetMarketData.Domain.Services
{
    public class TipoPersonaService
    {
        private readonly TipoPersonaRepositorio TipoPersonaRepositorio;

        public TipoPersonaService()
        {
            this.TipoPersonaRepositorio = new TipoPersonaRepositorio();
        }

        public long GuardarTipo( string nombre, long pk = 0)
        {
            if (pk == 0)
                pk = TipoPersonaRepositorio.guardarTipoPersona(nombre);
            else
                TipoPersonaRepositorio.ModificarTipoPersona(pk, nombre);
            return pk;
        }

        public void EliminarTipo(long pk)
        {
            TipoPersonaRepositorio.EliminarTipoPersona(pk);
        }

        public TipoPersona ObtenerTipo(long pk)
        {
            return TipoPersonaRepositorio.obtenerTipoPersona(pk);
        }

        public List<TipoPersona> ObtenerTipos()
        {
            return TipoPersonaRepositorio.obtenerTiposPersona();
        }

    }
}
