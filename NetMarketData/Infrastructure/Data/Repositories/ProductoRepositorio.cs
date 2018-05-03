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
    public class ProductoRepositorio : EFRepositorio<Producto>
    {
        public long guardarProducto(ProductoDTO p)
        {
            Producto pr = new Producto()
            {
                nombreProducto=p.nombre,
                descripcionProducto=p.descripcion,
                idCategoria=p.idCategoria,
                eliminado = false
            };
            Add(pr);
            SaveChanges();
            return pr.idProducto;
        }

        public void ModificarProducto(ProductoDTO p)
        {
            Producto pr = this.Get(p.idProducto);
            pr.nombreProducto = p.nombre;
            pr.descripcionProducto = p.descripcion;
            Update(pr);
            SaveChanges();
        }

        public void EliminarProducto(ProductoDTO p)
        {
            Producto pr = Get(p.idProducto);
            pr.eliminado = true;
            SaveChanges();
        }

        public Producto obtenerProducto(ProductoDTO p)
        {
            var e = Get(p.idProducto);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }

        }

        public List<Producto> obtenerProductos(ProductoDTO p)
        {
            return GetAll().Where(x => x.eliminado == false && x.idCategoria==p.idCategoria).ToList();
        }
    }
}
