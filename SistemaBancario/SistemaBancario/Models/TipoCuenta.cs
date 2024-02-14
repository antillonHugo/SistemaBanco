using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class TipoCuenta
    {
        public int idTipocuenta { get; set; }
        public string tipocuenta { get; set; }

        // Propiedad de navegación hace referencia al tipo de cuenta del usuario
        // Clave foránea para representar la relación uno a muchos con CuentaBancaria
        public List<CuentaBancaria> cuentaBancarias { get; set; }
    }
}