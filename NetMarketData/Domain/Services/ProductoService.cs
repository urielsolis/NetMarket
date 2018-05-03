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
    public class ProductoService
    {
        private readonly ProductoRepositorio productorepositorio;

        public ProductoService()
        {
            this.productorepositorio = new ProductoRepositorio();
        }

        public long Guardarproducto(ProductoDTO p)
        {
            if (p.idProducto == 0)
                p.idProducto = productorepositorio.guardarProducto(p);
            else
                productorepositorio.ModificarProducto(p);
            return p.idProducto;
        }

        public void Eliminarproducto(ProductoDTO p)
        {
            productorepositorio.EliminarProducto(p);
        }

        public Producto Obtenerproducto(ProductoDTO p)
        {
            return productorepositorio.obtenerProducto(p);
        }

        public List<Producto> Obtenerproductos(ProductoDTO p)
        {
            return productorepositorio.obtenerProductos(p);
        }
    }
}
