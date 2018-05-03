using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientRestNet
{
    public abstract class ClientRest
    {
        #region Propiedades
        public abstract string GetController();

        public string GetUri()
        {
            return ConfigurationManager.AppSettings["URL_WEBAPI"];
        }

        protected WebApiClient NewWebApiClient()
        {
            WebApiClient WebApiClient = new WebApiClient(GetUri(), GetController());
            //WebApiClient.SetBasicAutorization(GetCustomerName(), GetCustomerIntegrationCode());
            //if (!string.IsNullOrWhiteSpace(GetTocken()))
            //{
            //    WebApiClient.Cliente.DefaultRequestHeaders.Add("Token", GetTocken().Trim());
            //}
            return WebApiClient;
        }
        #endregion
    }
}
