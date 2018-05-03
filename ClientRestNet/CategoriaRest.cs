using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRestNet.ResponseEntity;

namespace ClientRestNet
{
    public class CategoriaRest : ClientRest
    {
        public override string GetController()
        {
            return "categoriaproducto";
        }


        #region Metodos
        public RespuestaApi<List<CategoriaResponse>> listarcategorias(RequestEntity.CategoriaRequest Params)
        {
            WebApiClient WebApiClient = NewWebApiClient();
            return WebApiClient.PostAsJsonAsync<List<CategoriaResponse>>("vercategorias", Params);
        }
        #endregion
    }
}
