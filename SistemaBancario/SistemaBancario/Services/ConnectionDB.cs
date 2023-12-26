using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SistemaBancario.Services
{
    public class ConnectionDB
    {
        public SqlConnection conexion;

        // Obtén la cadena de conexión del web.config por su nombre
        public string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    }
}