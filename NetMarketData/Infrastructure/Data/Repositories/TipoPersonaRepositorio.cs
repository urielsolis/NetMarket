using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetMarketData.Infrastructure.Data.DataModels;
using Data.Infrastructure.Data.Repositories;

namespace NetMarketData.Infrastructure.Data.Repositories
{
    class TipoPersonaRepositorio : EFRepositorio<TipoPersona>
    {
        public long guardarTipoPersona(string nombre)
        {
            TipoPersona t = new TipoPersona()
            {
                nombreTipo = nombre
            };
            Add(t);
            SaveChanges();
            return t.idTipoPersona;
        }

        public void ModificarTipoPersona(long id, string nombre)
        {
            TipoPersona t = this.Get(id);
            t.nombreTipo = nombre;
            Update(t);
            SaveChanges();
        }
        
        public void EliminarTipoPersona(long id)
        {
            TipoPersona t = Get(id);
            Remove(t);
            SaveChanges();
        } 

        public TipoPersona obtenerTipoPersona(long id)
        {
            return Get(id);
        }

        public List<TipoPersona> obtenerTiposPersona()
        {
            return GetAll().ToList();
        }
    }
}
