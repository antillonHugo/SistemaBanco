using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaBancario.permissions
{
    //está clase me servira para validar que exista una sesion para evitar que ingresen mediante la URL al sistema
    public class ValidateSessionAttribute : ActionFilterAttribute
    {
        //Método válida que exista una variable de sesión llamada Session["idcliente"] de lo contrario nos envía al login
        //OnActionExecuting permite que este método se ejecute antes de que entre al controlador
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["idcliente"] == null)
            {

                filterContext.Result = new RedirectResult("~/Account/Login");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}