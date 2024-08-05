using System.Data.SqlClient;
using Dapper;
class Deportista{
public int IdDeportista {get; set;}
public string Apellido {get; set;}
public string Nombre {get; set;}
public DateTime FechaNacimiento {get; set;}
public string Foto {get; set;}
public int IdPais {get; set;}
public int IdDeporte {get; set;}


private static string _connectionString = @"Server=localhost;
DataBase=TP6;Trusted_Connection = True;";

public void AgregarDeportista(Deportista deportistaIng)
{
    using(SqlConnection db = new SqlConnection(_connectionString))
    {
        string sql = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
    }
}
}