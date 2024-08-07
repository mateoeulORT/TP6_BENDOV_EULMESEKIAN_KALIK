using System.Data.SqlClient;
using Dapper;

public class DB
{
    private List<Pais> _ListPaises = new List<Pais>();
    private List<Deportista> _ListaDeportistas = new List<Deportista>();
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
    public Deporte? VerInfoDeporte(int idDeporte)
    {
        Deporte? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deporte WHERE IdDeporte = @pIdDeporte";
            r = db.QueryFirstOrDefault<Deporte>(sql, new { pIdDeporte = idDeporte });
        }
        return r;
    }
    public Pais? VerInfoPais(int IdPais)
    {
        Pais? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Pais WHERE IdPais = @pIdPais";
            r = db.QueryFirstOrDefault<Pais>(sql, new { pIdPais = IdPais });
        }
        return r;
    }
    public Deportista? VerInfoDeportista(int idDeportista)
    {
        Deportista? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Deportista WHERE IdDeportista = @pIdDeportista";
            r = db.QueryFirstOrDefault<Deportista>(sql, new { pIdDeportista = idDeportista });
        }
        return r;
    }
    public List<Pais> ListarPaises()
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Pais";
            _ListPaises = db.Query<Pais>(sql).ToList();
        }
        return _ListPaises;
        
    }
    public List<Deportista> ListarDeportistasXPais(int idPais)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportista WHERE idPais = @pIdPais";
            _ListaDeportistas = db.Query<Deportista>(sql).ToList();
        }
        return _ListaDeportistas;
    }
    public List<Deportista> ListarDeportistasXDeporte(int idDeporte)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportistas WHERE idDeporte = @pIdDeporte";
            _ListaDeportistas = db.Query<Deportista>(sql).ToList();
        }  
        return _ListaDeportistas;
    }



}
