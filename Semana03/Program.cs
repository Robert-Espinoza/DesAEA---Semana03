//Librerias del ADO .NET
using System.Data.SqlClient;
using System.Data;

namespace Semana03;

class Program
{
    // Cadena de conexión a la base de datos
    public static string connectionString = "Data Source=LAB1504-28\\SQLEXPRESS;Initial Catalog=Neptuno2;User ID=usertecsup;Password=123456";


    static void Main()
    {

    }

    //De forma desconectada
    private static DataTable Tecsup2023DB()
    {
        // Crear un DataTable para almacenar los resultados
        DataTable dataTable = new DataTable();
        // Crear una conexión a la base de datos
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT * FROM Trabajador";

            // Crear un adaptador de datos
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);


            // Llenar el DataTable con los datos de la consulta
            adapter.Fill(dataTable);

            // Cerrar la conexión
            connection.Close();

        }
        return dataTable;
    }

    //De forma conectada
    private static List<Trabajadores> ListarTrabajadoresListaObjetos()
    {
        List<Trabajadores> empleados = new List<Trabajadores>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            // Abrir la conexión
            connection.Open();

            // Consulta SQL para seleccionar datos
            string query = "SELECT IdEmpleado,Nombre,Cargo FROM Empleados1";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Verificar si hay filas
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Leer los datos de cada fila

                            empleados.Add(new Trabajadores
                            {
                                Id = (int)reader["IdEmpleado"],
                                Nombre = reader["Nombre"].ToString(),
                                Cargo = reader["Cargo"].ToString()
                            });

                        }
                    }
                }
            }

            // Cerrar la conexión
            connection.Close();


        }
        return Trabajadores;

    }


}
