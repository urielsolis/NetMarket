using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
//using System.Web.Http.Cors;
using Microsoft.Ajax.Utilities;
using ClientRestNet;
using ClientRestNet.RequestEntity;
using ClientRestNet.ResponseEntity;

namespace NetMarket.Controllers
{
    public class HomeController : Controller
    {
        protected CategoriaRest CategoriaRest = new CategoriaRest();
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpPost]
        public ActionResult ListarCategorias(CategoriaRequest param)
        {
            try
            {
                var resultado = CategoriaRest.listarcategorias(param);
                return Json(resultado, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(RespuestaApi<string>.createRespuestaError(ex.Message.Replace("'", "")), JsonRequestBehavior.DenyGet);
            }
        }
    }
}