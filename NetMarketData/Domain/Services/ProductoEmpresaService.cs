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
    public class ProductoEmpresaService
    {
        private readonly ProductoEmpresaRepositorio productoempresarepositorio;

        public ProductoEmpresaService()
        {
            this.productoempresarepositorio = new ProductoEmpresaRepositorio();
        }

        public long Guardarproducto(ProductoEmpresaDTO p)
        {
            if (p.idProductoEmpresa == 0)
                p.idProductoEmpresa = productoempresarepositorio.guardarProductoEmpresa(p);
            else
                productoempresarepositorio.ModificarProductoEmpresa(p);
            return p.idProductoEmpresa;
        }

        public void Eliminarproducto(ProductoEmpresaDTO p)
        {
            productoempresarepositorio.EliminarProductoEmpresa(p);
        }

        public ProductoEmpresa Obtenerproducto(ProductoEmpresaDTO p)
        {
            return productoempresarepositorio.obtenerProductoEmpresa(p);
        }

        public List<ProductoEmpresa> Obtenerproductos(ProductoEmpresaDTO p)
        {
            return productoempresarepositorio.obtenerProductosEmpresa(p);
        }
    }
}
