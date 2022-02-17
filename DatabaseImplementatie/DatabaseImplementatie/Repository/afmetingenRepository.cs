using Dapper;
using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Repository;

public class afmetingenRepository
{
    private MySqlConnection Connect()
    {
        return new MySqlConnection("Server=127.0.0.1;Database=stripboek;Uid=root;Pwd=1234;Port=3306");
    }
    
    public IEnumerable<afmetingen> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<afmetingen>("SELECT * FROM afmetingen");
    }
    
    public void AddData(long isbn, float lengte, float breedte, float dikte, float hoogte)
    {

        string sql =
            "INSERT INTO afmetingen (isbn, lengte, breedte, dikte, hoogte) VALUES (@isbn, @lengte, @breedte, @dikte, @hoogte);";
        
        using var connection = Connect();

        var affectedRows = connection.Execute(sql, new {isbn = isbn, lengte = lengte, breedte = breedte, dikte = dikte, hoogte = hoogte});
        
    }
}