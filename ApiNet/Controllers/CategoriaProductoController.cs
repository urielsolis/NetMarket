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
using System.Net.Http;
using NetMarketData.Domain.Entities;
using NetMarketData.Infrastructure.Data.DataModels;
using ApiNet.Models;
using NetMarketData.Domain.Services;
using System.Web.Http.Cors;

namespace ApiNet.Controllers
{
    //[EnableCors(origins: "*", headers: " *", methods: "*")]
    public class CategoriaProductoController : ApiController
    {
        private readonly CategoriaProductoService categoriaServicio = new CategoriaProductoService();
        private readonly ImagenService imagenServicio = new ImagenService();

        [Route("api/categoriaproducto/vercategorias")]
        [HttpPost]
        
        public IHttpActionResult vercategorias()
        {
            try
            {
                List<CategoriaDTO> categorias = new List<CategoriaDTO>();
                var listca = categoriaServicio.Obtenercategorias();
                foreach (var e in listca)
                {
                    ImagenDTO i = new ImagenDTO()
                    {
                        idcategoria = e.idCategoria,
                        principal = true
                    };
                    categorias.Add(new CategoriaDTO
                    {
                        idCategoria=e.idCategoria,
                        nombre = e.nombreCategoria,
                        rutaimagen= imagenServicio.Obtenerimagen(i)
                    });
                }

                return Ok(RespuestaApi<List<CategoriaDTO>>.createRespuestaSuccess(categorias, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/categoriaproducto/guardarcategoria")]
        [HttpPost]
        public IHttpActionResult guardarcategoria([FromBody] CategoriaDTO c)
        {
            try
            {
                long pk = categoriaServicio.Guardarcategoria(c);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/categoriaproducto/vercategoria")]
        [HttpPost]
        public IHttpActionResult vercategoria([FromBody] CategoriaDTO c)
        {
            try
            {
                CategoriaProducto ca = new CategoriaProducto();
                CategoriaDTO cat = new CategoriaDTO();
                ca = categoriaServicio.Obtenercategoria(c);
                ImagenDTO i = new ImagenDTO()
                {
                    idcategoria = ca.idCategoria,
                    principal = true
                };
                cat.idCategoria = ca.idCategoria;
                cat.nombre = ca.nombreCategoria;
                cat.rutaimagen = imagenServicio.Obtenerimagen(i);

                return Ok(RespuestaApi<CategoriaDTO>.createRespuestaSuccess(cat, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/categoriaproducto/eliminarcategoria")]
        [HttpPost]
        public IHttpActionResult eliminarcategoria([FromBody] CategoriaDTO c)
        {
            try
            {
                categoriaServicio.Eliminarcategoria(c);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Categoria de Productos eliminada correctamente", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
