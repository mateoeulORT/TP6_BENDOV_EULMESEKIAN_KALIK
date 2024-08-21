using System.Data.SqlClient;
using Dapper;

public class DB
{
    private List<Pais> _ListPaises = new List<Pais>();
    private List<Deportista> _ListaDeportistas = new List<Deportista>();
    //\SQLEXPRESS
    private static string _connectionString = @"Server=BANHODEMATEO\SQLEXPRESS;
    DataBase=JJOO;Trusted_Connection=True;";
    public static void AgregarDeportista(Deportista deportistaIng)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "INSERT INTO Deportistas (Apellido, Nombre, FechaNacimiento, Foto, IdPais, IdDeporte) VALUES (@pApellido, @pNombre, @pFechaNacimiento, @pFoto, @pIdPais, @pIdDeporte)";
            db.Execute(sql, new { pApellido = deportistaIng.Apellido, pNombre = deportistaIng.Nombre, pFechaNacimiento = deportistaIng.FechaNacimiento, pFoto = deportistaIng.Foto, pIdPais = deportistaIng.IdPais, pIdDeporte = deportistaIng.IdDeporte});
        }

    }
    public static void EliminarDeportista(int idDeportista)
    {
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "DELETE FROM Deportista WHERE IdDeportista = @pIdDeportista";
            db.Execute(sql, new { pIdDeportista = idDeportista });
        }
    }
    public static Deportes? VerInfoDeporte(int idDeporte)
    {
        Deportes? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportes WHERE IdDeporte = @pIdDeporte";
            r = db.QueryFirstOrDefault<Deportes>(sql, new { pIdDeporte = idDeporte });
        }
        return r;
    }
    public static Pais? VerInfoPais(int IdPais)
    {
        Pais? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Paises WHERE IdPais = @pIdPais";
            r = db.QueryFirstOrDefault<Pais>(sql, new { pIdPais = IdPais });
        }
        return r;
    }
    public static Deportista? VerInfoDeportista(int idDeportista)
    {
        Deportista? r = null;
        using (SqlConnection db = new SqlConnection(_connectionString))
        {

            string sql = "SELECT * FROM Deportistas WHERE IdDeportista = @pIdDeportista";
            r = db.QueryFirstOrDefault<Deportista>(sql, new { pIdDeportista = idDeportista });
        }
        return r;
    }
    public static List<Pais> ListarPaises()
    {
        List<Pais> _ListaPaises = new List<Pais>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Paises ORDER BY Nombre";
            _ListaPaises = db.Query<Pais>(sql).ToList();
        }
        return _ListaPaises;
    }
    public static List<Deportes> ListarDeportes()
    {
        List<Deportes> _listaDeportes = new List<Deportes>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportes ORDER BY Nombre";
            _listaDeportes = db.Query<Deportes>(sql).ToList();
        }
        return _listaDeportes;
    }
    public static List<Deportista> ListarDeportistas()
    {
        List<Deportista> _ListaDeportistas = new List<Deportista>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportistas";
            _ListaDeportistas = db.Query<Deportista>(sql).ToList();
        }
        return _ListaDeportistas;
    }
    public static List<Deportista> ListarDeportistasXPais(int idPais)
    {
        List<Deportista> _ListaDeportistas = new List<Deportista>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportistas WHERE IdPais = @pIdPais";
            _ListaDeportistas = db.Query<Deportista>(sql, new { pIdPais = idPais }).ToList();
        }
        return _ListaDeportistas;
    }
    public static List<Deportista> ListarDeportistasXDeporte(int idDeporte)
    {
         List<Deportista> _ListaDeportistas = new List<Deportista>();
        using (SqlConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM Deportistas WHERE IdDeporte = @pIdDeporte";
            _ListaDeportistas = db.Query<Deportista>(sql, new { pIdDeporte = idDeporte }).ToList();
            
        }  
        return _ListaDeportistas;
    }



}
