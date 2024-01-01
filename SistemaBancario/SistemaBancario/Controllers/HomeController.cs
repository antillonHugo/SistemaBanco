using SistemaBancario.permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace SistemaBancario.Controllers
{
    // [ValidateSessionAttribute] Hace referencia a la clase que evita ingresar al sistema por medio de la URL
    [ValidateSessionAttribute]
    public class HomeController : Controller
    {

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
    }
}