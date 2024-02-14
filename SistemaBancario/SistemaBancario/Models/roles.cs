using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class Roles
    {
        public int idRoles { get; set; }
        public string rol {get;set;}

        // Propiedad de navegación hace referencia a una lista de usuarios asociado a un solo rol(admin/user)
        // Clave foránea para representar la relación uno o muchos usuarios pertenecen a un unico rol
        public virtual List<User> Users { get; set; }
    }
}