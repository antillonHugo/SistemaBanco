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

        //lista para almacenar los clientes
        List<Client> listacliente = new List<Client>();

        public List<Client> obtenercliente(int idclient,int idrol)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
                {
                    
                    var query = "select idusuario,nombre,apellido,correo,telefono,nombre_usuario,contrasena,estado,rol from CLIENTE c inner join USUARIO u on c.idcliente = u.idcliente inner join ROLES r on r.idRoles = u.idRoles";
                    
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
                            command.Parameters.AddWithValue("@idcliente",idclient);
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

                                // Crear un nuevo objeto User
                                var user = new User()
                                {
                                    nombre_usuario = (string)reader["nombre_usuario"],
                                    contrasena = (string)reader["contrasena"],
                                    estado = (bool)reader["estado"],
                                };

                                var rol = new Roles()
                                {
                                    rol = (string)reader["rol"]
                                };

                                

                                // Asignar el usuario al cliente
                                cliente.user = user;
                                cliente.user.rol = rol;

                                // Agregar el cliente a la lista
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




        public List<Client> obtenerdatoscliente(int idclient)
        {
            List<Client> usuarios = new List<Client>();

            using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
            {
                connection.Open();

                // Consulta para obtener usuarios y sus cuentas bancarias
                string query = "SELECT c.idcliente, nombre, idCuentaBancaria,saldo,fecha_apertura,idTipocuenta,idTransaccion,idTipoTransaccion,monto,fecha_transaccion FROM CLIENTE c LEFT JOIN CuentaBancaria cb ON c.idcliente = cb.idcliente inner join TRANSACCION t on c.idcliente = t.idcliente where c.idcliente= @idcliente";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idcliente", idclient);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int idUsuario = (int)reader["idcliente"];
                            string nombreUsuario = (string)reader["nombre"];
                            int idcuenta = (int)reader["idCuentaBancaria"];
                            //double saldo = (double)reader["saldo"];
                            // Crear una variable para rastrear si se encontró el usuario
                            bool usuarioEncontrado = false;

                            // Recorrer la lista de usuarios
                            foreach (var u in usuarios)
                            {
                                if (u.idcliente == idUsuario)
                                {
                                    usuarioEncontrado = true;
                                    break;
                                }
                            }

                            // Verificar si ya existe el usuario en la lista
                            if (!usuarioEncontrado)
                            {
                                // Crear el nuevo usuario y agregarlo a la lista
                                Client usuario = new Client { idcliente = idUsuario, nombre = nombreUsuario };
                                usuarios.Add(usuario);
                            }
                        }

                    }
                }
          
            }

            return usuarios;

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