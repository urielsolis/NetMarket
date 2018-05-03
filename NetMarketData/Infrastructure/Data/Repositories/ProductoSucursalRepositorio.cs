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
    public class ProductoSucursalRepositorio : EFRepositorio<ProductoSucursal>
    {
        public long guardarProductoSucursal(ProductoSucursalDTO p)
        {
            ProductoSucursal pr = new ProductoSucursal()
            {
                idProductoEmpresa=p.idProductoEmpresa,
                idSucursal=p.idSucursal,
                precio=p.precio,
                Stock=p.stock,
                eliminado = false
            };
            Add(pr);
            SaveChanges();
            return pr.idProductoSucursal;
        }

        public void ModificarProductoSucursal(ProductoSucursalDTO p)
        {
            ProductoSucursal pr = this.Get(p.idProductoSucursal);
            pr.Stock = p.stock;
            pr.precio = p.precio;
            Update(pr);
            SaveChanges();
        }

        public void EliminarProductoSucursal(ProductoSucursalDTO p)
        {
            ProductoSucursal pr = Get(p.idProductoSucursal);
            pr.eliminado = true;
            SaveChanges();
        }

        public ProductoSucursal obtenerProductoSucursal(ProductoSucursalDTO p)
        {
            var e = Get(p.idProductoSucursal);
            if (e.eliminado != true)
            {
                return e;
            }
            else
            {
                return null;
            }
        }

        public List<ProductoSucursal> obtenerProductosSucursal(ProductoSucursalDTO p)
        {
            return BuildQuery().Where(x => x.eliminado == false && x.ProductoEmpresa.Producto.idCategoria == p.idCategoria).ToList();
        }
    }
}
