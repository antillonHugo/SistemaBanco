﻿using System;
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
    }
}