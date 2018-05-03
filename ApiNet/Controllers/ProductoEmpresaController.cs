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
    public class ProductoEmpresaController : ApiController
    {
        private readonly ProductoEmpresaService productoempresaservico = new ProductoEmpresaService();
        private readonly ProductoService productoServicio = new ProductoService();
        private readonly CategoriaProductoService categoriaServicio = new CategoriaProductoService();
        private readonly EmpresaService empresaSevicio = new EmpresaService();
        private readonly ImagenService imagenService = new ImagenService();

        [Route("api/productoempresa/verproductos")]
        [HttpPost]
        public IHttpActionResult verproductos([FromBody] ProductoEmpresaDTO p)
        {
            try
            {
                List<ProductoEmpresaDTO> productos = new List<ProductoEmpresaDTO>();
                var listpro = productoempresaservico.Obtenerproductos(p);
                foreach (var pr in listpro)
                {
                    ProductoDTO pp = new ProductoDTO()
                    {
                        idProducto = pr.idProducto
                    };
                    long idc= productoServicio.Obtenerproducto(pp).idCategoria;
                    CategoriaDTO c = new CategoriaDTO()
                    {
                        idCategoria = idc
                    };
                    EmpresaDTO e = new EmpresaDTO()
                    {
                        idEmpresa = Convert.ToInt64(pr.idEmpresa)
                    };
                    ImagenDTO i = new ImagenDTO()
                    {
                        idProductoEmpresa = pr.idProductoEmpresa,
                        principal = true
                    };
                    productos.Add(new ProductoEmpresaDTO
                    {
                        idProductoEmpresa = pr.idProductoEmpresa,
                        idProducto = pr.idProducto,
                        precio = Convert.ToDecimal(pr.Precio),
                        nombre = productoServicio.Obtenerproducto(pp).nombreProducto,
                        idEmpresa= Convert.ToInt64(pr.idEmpresa),
                        nombreEmpresa=empresaSevicio.ObtenerEmpresa(e).nombreEmpresa,
                        idCategoria=categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria= productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).idCategoria,
                        nombreCategoria= categoriaServicio.Obtenercategoria(
                            new CategoriaDTO()
                            {
                                idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                            }
                            ).nombreCategoria,
                        rutaimagen= imagenService.Obtenerimagen(i)
                });
                }

                return Ok(RespuestaApi<List<ProductoEmpresaDTO>>.createRespuestaSuccess(productos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productoempresa/guardarproducto")]
        [HttpPost]
        public IHttpActionResult guardarproducto([FromBody] ProductoEmpresaDTO p)
        {
            try
            {
                long pk = productoempresaservico.Guardarproducto(p);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productoempresa/verproducto")]
        [HttpPost]
        public IHttpActionResult verproducto([FromBody] ProductoEmpresaDTO p)
        {
            try
            {
                ProductoEmpresa pro = new ProductoEmpresa();
                ProductoEmpresaDTO producto = new ProductoEmpresaDTO();
                pro = productoempresaservico.Obtenerproducto(p);
                ProductoDTO pp = new ProductoDTO()
                {
                    idProducto = pro.idProducto
                };
                long idc = productoServicio.Obtenerproducto(pp).idCategoria;
                CategoriaDTO c = new CategoriaDTO()
                {
                    idCategoria = idc
                };
                EmpresaDTO e = new EmpresaDTO()
                {
                    idEmpresa = Convert.ToInt64(pro.idEmpresa)
                };
                ImagenDTO i = new ImagenDTO()
                {
                    idProductoEmpresa = pro.idProductoEmpresa,
                    principal = true
                };
                producto.idProductoEmpresa = pro.idProductoEmpresa;
                producto.idProducto = pro.idProducto;
                producto.precio = Convert.ToDecimal(pro.Precio);
                producto.nombre = productoServicio.Obtenerproducto(pp).nombreProducto;
                producto.idEmpresa = Convert.ToInt64(pro.idEmpresa);
                producto.nombreEmpresa = empresaSevicio.ObtenerEmpresa(e).nombreEmpresa;
                producto.idCategoria = categoriaServicio.Obtenercategoria(
                    new CategoriaDTO()
                    {
                        idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                    }
                    ).idCategoria;
                producto.nombreCategoria = categoriaServicio.Obtenercategoria(
                    new CategoriaDTO()
                    {
                        idCategoria = productoServicio.Obtenerproducto(pp).idCategoria
                    }
                    ).nombreCategoria;
                producto.rutaimagen = imagenService.Obtenerimagen(i);

                return Ok(RespuestaApi<ProductoEmpresaDTO>.createRespuestaSuccess(producto, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/productoempresa/eliminarproducto")]
        [HttpPost]
        public IHttpActionResult eliminarproducto([FromBody] ProductoEmpresaDTO p)
        {
            try
            {
                productoempresaservico.Eliminarproducto(p);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Producto eliminado correctamente de la Empresa", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
