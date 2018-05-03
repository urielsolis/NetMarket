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
    public class ProductoController : Controller
    {
        protected ProductoRest productoRest = new ProductoRest();
        // GET: Producto
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult ProductosCategoria()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ListarProductosCategoria(CategoriaRequest param)
        {
            try
            {
                var resultado = productoRest.ListarProductosCategoria(param);
                //if (resultado.Codigo != 0)
                //{
                //return Json("", JsonRequestBehavior.DenyGet);

                //}
                return Json(resultado, JsonRequestBehavior.DenyGet);
            }
            catch (Exception ex)
            {
                return Json(RespuestaApi<string>.createRespuestaError(ex.Message.Replace("'", "")), JsonRequestBehavior.DenyGet);
            }
        }
    }
}