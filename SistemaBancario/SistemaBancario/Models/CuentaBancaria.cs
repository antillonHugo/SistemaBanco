using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaBancario.Models
{
    public class CuentaBancaria
    {
            public int idCuentaBancaria { get; set; }
            public int idcliente {get; set; }
            public int idTipocuenta {get; set; }
            public decimal saldo {get;set; }
            public DateTime fecha_apertura {get; set; }

            // Propiedad de navegación hace referencia al tipo de cuenta del usuario
            // Clave foránea para representar la relación uno a muchos con TipoCuenta
            public virtual TipoCuenta TipoCuenta { get; set; }
    }
}