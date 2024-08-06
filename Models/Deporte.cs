using System.Data.SqlClient;
using Dapper;

class Deporte
{
    public string Nombre {get; set;}
    public string Foto {get; set;}
    public int idDeporte{get; set;}
    public List<Deporte> listaDeportes = new List<Deporte>();
}