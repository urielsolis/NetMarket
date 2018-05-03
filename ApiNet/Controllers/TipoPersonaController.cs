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
    public class TipoPersonaController : ApiController
    {
        private readonly TipoPersonaService tipoServicio = new TipoPersonaService();

        [Route("api/TipoPersona/tipoPersonas")]
        [HttpPost]
        public IHttpActionResult tipoPersonas()
        {
            try
            {
                List<TipoPersonaDTO> tipos = new List<TipoPersonaDTO>();
                var listi = tipoServicio.ObtenerTipos();
                foreach(var t in listi)
                {
                    tipos.Add(new TipoPersonaDTO
                    {
                        idTipo = t.idTipoPersona,
                        nombreTipo = t.nombreTipo
                    });
                } 

                return Ok(RespuestaApi<List<TipoPersonaDTO>>.createRespuestaSuccess(tipos, "success"));
            }
            catch (Exception ex)
            {
                return Ok(RespuestaApi<string>.createRespuestaError(ex.ToString(), "error"));
            }

        }

    }
}
