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
    public class SucursalController : ApiController
    {
        private readonly SucursalService sucursalServicio = new SucursalService();
        private readonly EmpresaService empresaServicio = new EmpresaService();
        private readonly ImagenService imagenServicio = new ImagenService();
        private readonly TurnoService turnoServicio = new TurnoService();

        [Route("api/sucursal/versucursales")]
        [HttpPost]
        public IHttpActionResult versucursales([FromBody] SucursalDTO s)
        {
            try
            {
                List<SucursalDTO> Sucursales = new List<SucursalDTO>();
                var listsu = sucursalServicio.ObtenerSucursales(s);
                foreach (var e in listsu)
                {
                    EmpresaDTO emm = new EmpresaDTO
                    {
                        idEmpresa = e.idEmpresa
                    };
                    ImagenDTO i = new ImagenDTO()
                    {
                        idSucursal = e.idSucursal,
                        principal = true
                    };
                    Sucursales.Add(new SucursalDTO
                    {
                        idSucursal = e.idSucursal,
                        nombre = e.nombreSucursal,
                        idEmpresa = e.idEmpresa,
                        direccion = e.direccion,
                        nombreEmpresa = empresaServicio.ObtenerEmpresa(emm).nombreEmpresa,
                        rutaimagen = imagenServicio.Obtenerimagen(i),
                        abierto = turnoServicio.comprobardisponibilidad(e.idSucursal)
                    });
                }

                return Ok(RespuestaApi<List<SucursalDTO>>.createRespuestaSuccess(Sucursales, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/sucursal/guardarsucursal")]
        [HttpPost]
        public IHttpActionResult guardarsucursal([FromBody] SucursalDTO s)
        {
            try
            {
                long pk = sucursalServicio.GuardarSucursal(s);

                return Ok(RespuestaApi<long>.createRespuestaSuccess(pk, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/sucursal/versucursal")]
        [HttpPost]
        public IHttpActionResult versucursal([FromBody] SucursalDTO s)
        {
            try
            {
                Sucursal su = new Sucursal();
                SucursalDTO suc = new SucursalDTO();
                su = sucursalServicio.ObtenerSucursal(s);
                EmpresaDTO emm = new EmpresaDTO
                {
                    idEmpresa = su.idEmpresa
                };
                ImagenDTO i = new ImagenDTO()
                {
                    idSucursal = su.idSucursal,
                    principal = true
                };
                suc.idSucursal = su.idSucursal;
                suc.nombre = su.nombreSucursal;
                suc.direccion = su.direccion;
                suc.idEmpresa = su.idEmpresa;
                suc.nombreEmpresa = empresaServicio.ObtenerEmpresa(emm).nombreEmpresa;
                suc.rutaimagen = imagenServicio.Obtenerimagen(i);
                
                return Ok(RespuestaApi<SucursalDTO>.createRespuestaSuccess(suc, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }

        [Route("api/sucursal/eliminarsucursal")]
        [HttpPost]
        public IHttpActionResult eliminarsucursal([FromBody] SucursalDTO s)
        {
            try
            {
                sucursalServicio.EliminarSucursal(s);

                return Ok(RespuestaApi<string>.createRespuestaSuccess("Sucursal eliminada correctamente", "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }
        }
    }
}
