using Experimentacion.Objects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Data;

namespace Experimentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            string json = File.ReadAllText("C:\\Users\\ALP54\\source\\repos\\Experimentacion\\MOCK_DATA.json");
            List<UsuarioDto> usuarios = JsonConvert.DeserializeObject<List<UsuarioDto>>(json);
            string connectionString = "Data Source=ALEJANDROPC\\SQLEXPRESS02;Initial Catalog=Experimentacion;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                foreach (UsuarioDto usuario in usuarios)
                {
                    using (SqlCommand command = new SqlCommand("InsertarUsuario", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        command.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                        command.Parameters.AddWithValue("@NumeroDocumentoIdentidad", usuario.NumeroDocumentoIdentidad);
                        command.Parameters.AddWithValue("@TipoDeDocumento", usuario.TipoDeDocumento);
                        command.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        command.Parameters.AddWithValue("@FechaNacimiento", DateTime.Parse(usuario.FechaNacimiento));

                        command.ExecuteNonQuery();
                    }
                }
            }

            watch.Stop();
            decimal elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("La transaccion utlizando csharp tardo "+ elapsedMs/1000 + " segundos");
            Console.ReadKey();
        }
    }
}
