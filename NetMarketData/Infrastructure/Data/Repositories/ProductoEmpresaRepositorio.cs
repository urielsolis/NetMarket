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
    public class ProductoEmpresaRepositorio : EFRepositorio<ProductoEmpresa>
    {
        public long guardarProductoEmpresa(ProductoEmpresaDTO p)
        {
            ProductoEmpresa pr = new ProductoEmpresa()
            {
                idProducto = p.idProducto,
                Precio = p.precio,
                idEmpresa = p.idEmpresa,
                eliminado = false
            };
            Add(pr);
            SaveChanges();
            return pr.idProducto;
        }

        public void ModificarProductoEmpresa(ProductoEmpresaDTO p)
        {
            ProductoEmpresa pr = this.Get(p.idProductoEmpresa);
            pr.Precio = p.precio;
            Update(pr);
            SaveChanges();
        }

        public void EliminarProductoEmpresa(ProductoEmpresaDTO p)
        {
            ProductoEmpresa pr = Get(p.idProductoEmpresa);
            pr.eliminado = true;
            SaveChanges();
        }

        public ProductoEmpresa obtenerProductoEmpresa(ProductoEmpresaDTO p)
        {
            var e = Get(p.idProductoEmpresa);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }

        }

        public List<ProductoEmpresa> obtenerProductosEmpresa(ProductoEmpresaDTO p)
        {
            return BuildQuery().Where(x => x.eliminado == false && x.Producto.idCategoria == p.idCategoria).ToList();
        }

    }
}
