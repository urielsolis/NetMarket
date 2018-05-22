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
    public class CategoriaProductoService
    {
        private readonly CategoriaProductoRepositorio categoriarepositorio;

        public CategoriaProductoService()
        {
            this.categoriarepositorio = new CategoriaProductoRepositorio();
        }

        public long Guardarcategoria(CategoriaDTO c)
        {
            if (c.idCategoria == 0)
                c.idCategoria = categoriarepositorio.guardarCategoriaProducto(c);
            else
                categoriarepositorio.ModificarCategoriaProducto(c);
            return c.idCategoria;
        }

        public void Eliminarcategoria(CategoriaDTO c)
        {
            categoriarepositorio.EliminarCategoriaProducto(c);
        }

        public CategoriaProducto Obtenercategoria(CategoriaDTO c)
        {
            return categoriarepositorio.obtenerCategoriaProducto(c);
        }

        public List<CategoriaProducto> Obtenercategorias()
        {
            return categoriarepositorio.obtenercategoriasProducto();
        }
    }
}
