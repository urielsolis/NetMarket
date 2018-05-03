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
    public class ProductoSucursalService
    {
        private readonly ProductoSucursalRepositorio productosucursalrepositorio;

        public ProductoSucursalService()
        {
            this.productosucursalrepositorio = new ProductoSucursalRepositorio();
        }

        public long Guardarproducto(ProductoSucursalDTO p)
        {
            if (p.idProductoSucursal == 0)
                p.idProductoSucursal = productosucursalrepositorio.guardarProductoSucursal(p);
            else
                productosucursalrepositorio.ModificarProductoSucursal(p);
            return p.idProductoSucursal;
        }

        public void Eliminarproducto(ProductoSucursalDTO p)
        {
            productosucursalrepositorio.EliminarProductoSucursal(p);
        }

        public ProductoSucursal Obtenerproducto(ProductoSucursalDTO p)
        {
            return productosucursalrepositorio.obtenerProductoSucursal(p);
        }

        public List<ProductoSucursal> Obtenerproductos(ProductoSucursalDTO p)
        {
            return productosucursalrepositorio.obtenerProductosSucursal(p);
        }
    }
}
