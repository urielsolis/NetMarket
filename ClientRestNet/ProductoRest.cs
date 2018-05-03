using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientRestNet.ResponseEntity;

namespace ClientRestNet
{
    public class ProductoRest : ClientRest
    {
        public override string GetController()
        {
            return "producto";
        }


        #region Metodos
        public RespuestaApi<List<ProductoResponse>> ListarProductosCategoria(RequestEntity.CategoriaRequest Params)
        {
            WebApiClient WebApiClient = NewWebApiClient();
            return WebApiClient.PostAsJsonAsync<List<ProductoResponse>>("verproductos", Params);
        }
        #endregion
    }
}
