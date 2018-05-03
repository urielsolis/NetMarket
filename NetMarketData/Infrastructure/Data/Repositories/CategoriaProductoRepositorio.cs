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
    public class CategoriaProductoRepositorio : EFRepositorio<CategoriaProducto>
    {
        public long guardarCategoriaProducto(CategoriaDTO c)
        {
            CategoriaProducto e = new CategoriaProducto()
            {
                nombreCategoria = c.nombre,
                eliminado = false
            };
            Add(e);
            SaveChanges();
            return e.idCategoria;
        }

        public void ModificarCategoriaProducto(CategoriaDTO c)
        {
            CategoriaProducto e = this.Get(c.idCategoria);
            e.nombreCategoria = c.nombre;
            Update(e);
            SaveChanges();
        }

        public void EliminarCategoriaProducto(CategoriaDTO c)
        {
            CategoriaProducto e = Get(c.idCategoria);
            e.eliminado = true;
            SaveChanges();
        }

        public CategoriaProducto obtenerCategoriaProducto(CategoriaDTO c)
        {
            var e = Get(c.idCategoria);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }

        }

        public List<CategoriaProducto> obtenercategoriasProducto()
        {
            return GetAll().Where(x => x.eliminado == false).ToList();
        }
    }
}
