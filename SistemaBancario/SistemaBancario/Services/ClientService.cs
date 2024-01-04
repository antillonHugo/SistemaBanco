using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public class ClientService
    {
        //clase que posee la conexion a sql
        ConnectionDB objConnection = new ConnectionDB();

        //instanciamos a la clase de objetos de tipo Client
        Client cliente = new Client();
        
        List<Client> listacliente = new List<Client>();


        public List<Client> obtenercliente(int idclient,int idrol)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
                {
                    
                    var query = "select idusuario,nombre,apellido,correo,telefono,nombre_usuario,contrasena from CLIENTE c inner join USUARIO u on c.idcliente = u.idcliente inner join ROLES r on r.idRoles = u.idRoles";
                    
                    //sí es un usuario normal lo restringimos el acceso a solo su información 
                    if (idrol == 2)
                    {
                        query += " where c.idcliente = @idcliente and u.idRoles = @rol";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();

                        //sí es un usuario normal lo restringimos el acceso a solo su información mediante su código
                        if (idrol == 2)
                        {
                            command.Parameters.AddWithValue("@idcliente", idclient);
                            command.Parameters.AddWithValue("@rol", idrol);
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cliente = new Client()
                                {
                                    idcliente = (int)reader["idusuario"],
                                    nombre = (string)reader["nombre"],
                                    apellido = (string)reader["apellido"],
                                    correo = (string)reader["correo"],
                                    telefono = (string)reader["telefono"]
                                };

                                // Agregar el estudiante a la lista
                                listacliente.Add(cliente);
                            }
                        }
                    }

                    //retorna la lista de objeto
                    return listacliente;
                }
            }
             catch (Exception e)
            {
                // Manejar la excepción según tus necesidades.
                Console.WriteLine($"Error: {e.Message}");
            }

            return null;
        } 

        /*
        public List<Client> obtenercliente(int idrol, int idclient)
        {
            using (var connection = new SqlConnection(objConnection.connectionString))
            {
                var query = "select idusuario, nombre, apellido, correo, telefono, nombre_usuario, contrasena, estado, rol " +
                                 "from CLIENTE c inner join USUARIO u on c.idcliente = u.idcliente inner join ROLES r on r.idRoles = u.idRoles " +
                                 "where idusuario = @idclient";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idclient", idclient);

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        var usuarios = new List<Client>();

                        if (reader.Read())
                        {
                            Client client = new Client
                            {
                                idcliente = (int)reader["idusuario"],
                                nombre = (string)reader["nombre"],
                                apellido = (string)reader["apellido"],
                                correo = (string)reader["correo"],
                                telefono = (string)reader["telefono"]
                            };

                            // Agregar el estudiante a la lista
                            usuarios.Add(client);

                            return usuarios;
                        }
                        else
                        {
                            return null; // No se encontró cliente
                        }
                    }
                }
            }
        }
        */


    }
 }