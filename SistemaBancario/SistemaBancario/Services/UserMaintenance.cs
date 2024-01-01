using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using SistemaBancario.Models;

namespace SistemaBancario.Services
{
    public class UserMaintenance
    {
        //clase que posee la conexion a sql
        ConnectionDB objConnection = new ConnectionDB();

        //variable para los querys sql
        string query;

        /*
        //método para verificar las cerdenciales del usuario y retorna una lista con algunos datos del usuario
        public List<string> ValidarCredenciales(string nameUser, string password)
        {
            try
            {
                // Crear una lista de strings
                List<string> userInfo = new List<string>();

                objConnection.Conectar();

                query = "select nombre_usuario,contrasena from USUARIO";

                using (SqlCommand comando = new SqlCommand(query, objConnection.conexion))
                {
                    comando.Parameters.AddWithValue("@nameUser", nameUser);
                    comando.Parameters.AddWithValue("@password", password);

                    objConnection.conexion.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            //Creamos una nueva instancia del objeto Usuario
                            Users user = new Users
                            {
                                //Asigna los valores a las instancias
                                IdUsuario = (int)reader["IdUsuario"],
                                IdTipoUsuario = (int)reader["IdTipoUsuario"]
                            };

                            reader.Close();

                            // Ahora que tenemos el IdUsuario y el IdTipoUsuario, podemos obtener el nombre del estudiante
                            string nombreUsuario = ObtenerNombreUsuario(usuario);

                            string idusuario = usuario.IdUsuario.ToString();
                            string idtipo = usuario.IdTipoUsuario.ToString();

                            //agregamos los datos a la lista
                            usuarioInfo.Add(idusuario);
                            usuarioInfo.Add(idtipo);
                            usuarioInfo.Add(nombreUsuario);

                            //retorna la lista  con la informacíón del usuario
                            return usuarioInfo;

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new ApplicationException("Error al validar credenciales. Por favor, inténtalo de nuevo más tarde." + ex);
            }
            finally
            {
                if (objConexion.conexion.State != ConnectionState.Closed)
                {
                    // Cerrar la conexión en el bloque finally para asegurar su cierre incluso en caso de excepciones.
                    objConexion.conexion.Close();
                }
            }

            return null;

        }*/

        public User Validar(string name, string password)
        {
            User user = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
                {
                    string query = "SELECT nombre_usuario,estado,idRoles,idcliente FROM USUARIO WHERE nombre_usuario = @nombre_usuario AND contrasena = @contrasena AND estado=1";

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


        /*
        public void validar(string name, string password)
        {
            // Open a connection to SQL Server and fill the DataTable
            // with data from the Sales.SalesOrderDetail table
            // in the AdventureWorks sample database.
            // Open a connection to the AdventureWorks database.
            using (SqlConnection connection = new SqlConnection(objConnection.connectionString))
            {

                query = "select nombre_usuario from USUARIO where nombre_usuario=@nombre_usuario and contrasena = @contrasena";

                // creamos el SqlCommand.
                using (SqlCommand comando = new SqlCommand(query, connection))
                {
                    //agregamos los parametros a nuestro query
                    comando.Parameters.AddWithValue("@nombre_usuario", name);
                    comando.Parameters.AddWithValue("@contrasena", password);

                    // abrimos la coneccion a la base de datos.
                    connection.Open();

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Users user = new Users
                            {
                                nombre_usuario = (string)reader["nombre_usuario"]
                            };
                        }
                    }
                }
            }
            
        }*/


        /*
            // Create the SqlCommand.
            SqlCommand command = new SqlCommand(query, connection);

        // Create the SqlParameter and assign a value.
        SqlParameter parameter = new SqlParameter("@nombre_usuario", SqlDbType.Int);
        parameter.Value = 1.5;
        command.Parameters.Add(parameter);

        // Open the connection and load the data.
        connection.Open();

        SqlDataReader reader1 =
            command.ExecuteReader(CommandBehavior.CloseConnection);
        table.Load(reader1);

        // Close the SqlDataReader.
        reader1.Close();*/


    }
}