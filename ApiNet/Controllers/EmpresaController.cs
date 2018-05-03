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
    public class EmpresaController : ApiController
    {
        private readonly EmpresaService empresaServicio = new EmpresaService();
        private readonly ImagenService imagenServicio = new ImagenService();

        [Route("api/empresa/verempresas")]
        [HttpPost]
        public IHttpActionResult verempresas()
        {
            try
            {
                List<EmpresaDTO> Empresas = new List<EmpresaDTO>();
                var listem = empresaServicio.ObtenerEmpresas();
                foreach (var e in listem)
                {
                    ImagenDTO i = new ImagenDTO()
                    {
                        idEmpresa = e.idEmpresa,
                        principal = true
                    };
                    Empresas.Add(new EmpresaDTO
                    {
                        idEmpresa = e.idEmpresa,
                        nombrempresa = e.nombreEmpresa,
                        nit = e.nit,
                        razon = e.razonSocial,
                        direccion = e.direccionCentral,
                        rutaimagen = imagenServicio.Obtenerimagen(i)
                    });
                }

                return Ok(RespuestaApi<List<EmpresaDTO>>.createRespuestaSuccess(Empresas,"success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/empresa/guardarempresa")]
        [HttpPost]
        public IHttpActionResult guardarempresa([FromBody] EmpresaDTO e)
        {
            try
            {
                long pk = empresaServicio.GuardarEmpresa(e);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk,"success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/empresa/verempresa")]
        [HttpPost]
        public IHttpActionResult verempresa([FromBody] EmpresaDTO e)
        {
            try
            {
                Empresa em = new Empresa();
                EmpresaDTO emp = new EmpresaDTO();
                em = empresaServicio.ObtenerEmpresa(e);
                ImagenDTO i = new ImagenDTO()
                {
                    idEmpresa = em.idEmpresa,
                    principal = true
                };
                emp.idEmpresa = em.idEmpresa;
                emp.nombrempresa = em.nombreEmpresa;
                emp.nit = em.nit;
                emp.razon = em.razonSocial;
                emp.direccion = em.direccionCentral;
                emp.rutaimagen = imagenServicio.Obtenerimagen(i);

                return Ok(RespuestaApi<EmpresaDTO>.createRespuestaSuccess(emp,"success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/empresa/eliminarempresa")]
        [HttpPost]
        public IHttpActionResult eliminarempresa([FromBody] EmpresaDTO e)
        {
            try
            {
                empresaServicio.EliminarEmpresa(e);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Empresa eliminada correctamente","success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
