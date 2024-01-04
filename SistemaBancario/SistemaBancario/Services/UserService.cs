using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public class UserService
    {
        //clase que posee la conexion a sql
        ConnectionDB objConnection = new ConnectionDB();

        //variable para los querys sql
        string query;

        public User Validar(string name, string password)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
                {
                    query = "SELECT nombre_usuario,estado,idRoles,idcliente FROM USUARIO WHERE nombre_usuario = @nombre_usuario AND contrasena = @contrasena AND estado=1";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombre_usuario", name);
                        command.Parameters.AddWithValue("@contrasena", password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user = new User
                                {
                                    nombre_usuario = (string)reader["nombre_usuario"],
                                    estado = (bool)reader["estado"],
                                    idRoles = (int)reader["idRoles"],
                                    idcliente = (int)reader["idcliente"]
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades.
                Console.WriteLine($"Error: {ex.Message}");
            }

            return user;
        }

    }
}