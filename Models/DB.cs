using System.Data.SqlClient;
using Dapper;

class DB
{
    private static string _connectionString = @"Server=localhost;
    DataBase=TP6;Trusted_Connection = True;";
    public void AgregarDeportista(Deportista deportistaIng)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Deportista (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
            db.Execute(sql, new { pApellido = deportistaIng.Apellido, pNombre = deportistaIng.Nombre, pFechaNacimiento = deportistaIng.FechaNacimiento, pFoto = deportistaIng.Foto, pIdPais = deportistaIng.IdPais, pIdDeporte = deportistaIng.IdDeporte});
        }

    }
    public void EliminarDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Deportista WHERE IdDeportista = @pIdDeporitsa";
            db.Execute(sql, new { pIdDeportista = idDeportista });
        }
    }
    public Deporte VerInfoDeporte(int idDeporte)
    {
        Deporte r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Deporte WHERE IdDeporte = @pIdDeporte";
            r = db.QueryFirstOrDefault<Deporte>(sql, new { pIdDeporte = idDeporte });
        }
        return r;
    }

}
