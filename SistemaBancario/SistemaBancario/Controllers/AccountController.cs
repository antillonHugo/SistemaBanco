using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SistemaBancario.Models;
using SistemaBancario.Services;

namespace SistemaBancario.Controllers
{
   
    public class AccountController : Controller
    {
        //instancia del archivo que realiza las operaciones CRUD
        UserService objuser = new UserService();
        
        // GET: Users
        public ActionResult Login()
        {
            return View();
        }

        // POST Users
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (!string.IsNullOrWhiteSpace(user.nombre_usuario) && !string.IsNullOrWhiteSpace(user.contrasena))
            {
                var userdata = objuser.Validar(user.nombre_usuario, user.contrasena);

                if (userdata == null)
                {
                    ViewBag.Message = "Usuario u contraseña invalidas";
                }
                else
                {
                    if (userdata.estado == false)
                    {
                        ViewBag.Message = "Su Cuenta esta deshabilitada comuniquese con su proveedor ";
                    }
                    else
                    {
                        // Almacenar el nombre de usuario en la sesión después de iniciar sesión
                        Session["Rol"] = userdata.idRoles;
                        Session["idcliente"] = userdata.idcliente;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ViewBag.Message = "Campos requeridos";
            }
            return View();
        }

        //método para cerrar sesión
        public ActionResult Logout()
        {
            Session["Rol"] = null;
            Session["idcliente"] = null;

            return RedirectToAction("Login", "Account");
        }

    }
}