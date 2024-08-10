using System.Data.SqlClient;
using Dapper;

public class Pais
{
    public int IdPais{get; set;}
    public string? Bandera{get; set;}
    public string? Nombre{get; set;}
    public DateTime FechaFuncacion{get; set;}

}