using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using ApiNet.Models;
using NetMarketData.Domain.Services;

namespace ApiNet.Controllers
{
    public class ProductoController : ApiController
    {
        private readonly ProductoService productoServicio = new ProductoService();
        private readonly CategoriaProductoService categoriaServicio = new CategoriaProductoService();
        private readonly ImagenService imagenServicio = new ImagenService();

        [Route("api/producto/verproductos")]
        [HttpPost]
        public IHttpActionResult verproductos([FromBody] ProductoDTO p)
        {
            try
            {
                List<ProductoDTO> productos = new List<ProductoDTO>();
                var listpro = productoServicio.Obtenerproductos(p);
                foreach (var pr in listpro)
                {
                    CategoriaDTO c = new CategoriaDTO()
                    {
                        idCategoria = pr.idCategoria
                    };
                    ImagenDTO i = new ImagenDTO()
                    {
                        idProducto = pr.idProducto,
                        principal = true
                    };
                    productos.Add(new ProductoDTO
                    {
                        idProducto = pr.idProducto,
                        nombre = pr.nombreProducto,
                        descripcion = pr.descripcionProducto,
                        idCategoria = pr.idCategoria,
                        nombrecategoria = categoriaServicio.Obtenercategoria(c).nombreCategoria,
                        rutaimagen = imagenServicio.Obtenerimagen(i)
                });
                }

                return Ok(RespuestaApi<List<ProductoDTO>>.createRespuestaSuccess(productos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/guardarproducto")]
        [HttpPost]
        public IHttpActionResult guardarproducto([FromBody] ProductoDTO p)
        {
            try
            {
                long pk = productoServicio.Guardarproducto(p);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/verproducto")]
        [HttpPost]
        public IHttpActionResult verproducto([FromBody] ProductoDTO p)
        {
            try
            {
                Producto pro = new Producto();
                ProductoDTO producto = new ProductoDTO();
                pro = productoServicio.Obtenerproducto(p);
                CategoriaDTO c = new CategoriaDTO()
                {
                    idCategoria = pro.idCategoria
                };
                ImagenDTO i = new ImagenDTO()
                {
                    idProducto = pro.idProducto,
                    principal = true
                };
                producto.nombre = pro.nombreProducto;
                producto.descripcion = pro.descripcionProducto;
                producto.idCategoria = pro.idCategoria;
                producto.nombrecategoria = categoriaServicio.Obtenercategoria(c).nombreCategoria;
                producto.rutaimagen = imagenServicio.Obtenerimagen(i);

                return Ok(RespuestaApi<ProductoDTO>.createRespuestaSuccess(producto, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/producto/eliminarproducto")]
        [HttpPost]
        public IHttpActionResult eliminarproducto([FromBody] ProductoDTO p)
        {
            try
            {
                productoServicio.Eliminarproducto(p);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Producto eliminado correctamente", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
