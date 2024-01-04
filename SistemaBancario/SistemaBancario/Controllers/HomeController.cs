using SistemaBancario.permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using SistemaBancario.Services;

namespace SistemaBancario.Controllers
{
    // [ValidateSessionAttribute] Hace referencia a la clase que evita ingresar al sistema por medio de la URL
    [ValidateSessionAttribute]
    public class HomeController : Controller
    {
        //instancia del archivo que realiza las operaciones CRUD
        ClientService objclient = new ClientService();

       
        public static int rol;

        public static int codclient;

        public ActionResult Index()
        {
            // Comprobamos el tipo de valor que se almacena en la variable rol y que no este vacía
            if (Session["Rol"] != null && rol is int)
            {
                //convertimos el contenido de la variable de sesión al tipo de dato esperado (entero)
                int.TryParse(Session["Rol"].ToString(), out rol);

                //convertimos el contenido de la variable de sesión al tipo de dato esperado (entero)
                int.TryParse(Session["idcliente"].ToString(), out codclient);

                var data = objclient.obtenercliente(codclient, rol);
                
                return View(data);
            }
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About ."+ rol;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact ." + rol;

            return View();
        }
    }
}