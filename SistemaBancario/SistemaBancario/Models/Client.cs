using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class Client
    {
        public int idcliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono {get;set;}

        // Propiedad de navegación hace referencia al cliente asociado con su usuario personal
        // Clave foránea para representar la relación uno a uno con User
        public virtual User user { get; set; }
    }
}