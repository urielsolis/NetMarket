using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClientRestNet
{
    public class WebApiClient
    {
        public HttpClient Cliente
        {
            get;
        }

        public string Url { get; set; }
        public string Controller { get; set; }

        public WebApiClient(string Url = null, string Controller = null, long TimeOut = 30000, bool json = true)
        {
            Cliente = new HttpClient();
            this.Url = Url;
            this.Controller = Controller;
            if (json)
            {
                Cliente.DefaultRequestHeaders.Accept.Clear();
                Cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            Cliente.Timeout = TimeSpan.FromMilliseconds(TimeOut);
        }

        public string PrepararUrl(string Metodo, NameValueCollection query = null)
        {
            if (!string.IsNullOrEmpty(Metodo))
            {
                Metodo = $"/{Metodo}";
            }
            if (query != null)
            {
                return Url + $"api/{Controller}{Metodo}/?{query.ToString()}";
            }
            return Url + $"api/{Controller}{Metodo}";
        }

        public void SetToken(string Token)
        {
            Cliente.DefaultRequestHeaders.Add("Token", Token);
        }

        public void SetBasicAutorization(string UserName, string Password)
        {
            var byteArray = Encoding.ASCII.GetBytes($"{UserName}:{Password}");
            var auth = Convert.ToBase64String(byteArray);
            Cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", auth);
        }

        public RespuestaApi<T> ProcesarRespuesta<T>(HttpResponseMessage Response)
        {
            if (Response.IsSuccessStatusCode)
            {

                RespuestaApi<T> Respuesta = Response.Content.ReadAsAsync<RespuestaApi<T>>().Result;
                if (Respuesta.Codigo > 0)
                {
                    //if (Respuesta.AlertMessages != null)
                    //{
                    //    throw new ValidationException(Respuesta.Message)
                    //    {
                    //        Codigo = Respuesta.Code,
                    //        AlertMessages = Respuesta.AlertMessages,
                    //        ValWarningToken = Respuesta.ValWarningToken
                    //    };
                    //}
                    //else if (Respuesta.Exception != null)
                    //{
                    //    throw new OmniException(Respuesta.Message)
                    //    {
                    //        Codigo = Respuesta.Code
                    //    };
                    //}
                    //else
                    //{
                    //    throw new OmniException(Respuesta.Code, Respuesta.Message);
                    //}

                }
                return Respuesta;
            }
            else
            {
                throw new HttpException((int)Response.StatusCode, "Ha ocurrido un error de comunicación con el servicio, comuniquese con el administrador.");
            }
        }

        public RespuestaApi<T> UploadFile<T>(string Metodo, Stream Stream, string Name, string FileName, Dictionary<string, HttpContent> ExtraParams = null)
        {
            using (Cliente)
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Add(new StreamContent(Stream), Name, FileName);
                    if (ExtraParams != null)
                    {
                        foreach (var item in ExtraParams.Keys)
                        {
                            content.Add(ExtraParams[item], item);
                        }
                    }
                    return PostAsync<T>(Metodo, content);
                }
            }
        }

        public RespuestaApi<T> PostAsJsonAsync<T>(string Metodo, object Params = null)
        {
            using (Cliente)
            {
                HttpResponseMessage Response = Cliente.PostAsJsonAsync(PrepararUrl(Metodo), Params).Result;
                return ProcesarRespuesta<T>(Response);
            }
        }

        public RespuestaApi<T> PostAsync<T>(string Metodo, HttpContent Params)
        {
            using (Cliente)
            {
                HttpResponseMessage Response = Cliente.PostAsync(PrepararUrl(Metodo), Params).Result;
                return ProcesarRespuesta<T>(Response);
            }
        }

        public RespuestaApi<T> GetAsync<T>(string Metodo, object Params = null)
        {
            using (Cliente)
            {
                NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
                if (Params != null)
                {
                    foreach (PropertyInfo propertyInfo in Params.GetType().GetProperties())
                    {
                        query[propertyInfo.Name] = propertyInfo.GetValue(Params).ToString();
                    }
                }
                HttpResponseMessage Response = Cliente.GetAsync(PrepararUrl(Metodo, query)).Result;
                return ProcesarRespuesta<T>(Response);
            }
        }
    }
}
