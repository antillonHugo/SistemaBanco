using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class User
    {
        public int idusuario { get; set; }
        public int idcliente { get; set; }
        public string nombre_usuario { get; set; }
        public string contrasena { get; set; }
        public bool estado { get; set; }
        public int idRoles { get; set; }

        // Propiedad de navegación hace referencia al usuario asociado con su información personal
        // Clave foránea para representar la relación uno a uno con Client
        public virtual Client client { get; set; }

        // Propiedad de navegación hace referencia al usuario asociado con su rol(admin/user)
        // Clave foránea para representar la relación un usuario pertenece a un unico rol
        public virtual Roles rol { get; set; }
    }
}