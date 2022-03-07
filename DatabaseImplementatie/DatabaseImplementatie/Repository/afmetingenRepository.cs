using Dapper;
using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Repository;

public class afmetingenRepository
{
    private MySqlConnection Connect()
    {
        return new MySqlConnection("Server=24.132.196.32;Database=webdevsite;Uid=DBAdmin;Pwd=Password12345!;Port=3306");
    }
    
    public IEnumerable<artiesten> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<artiesten>("SELECT * FROM artiest");
    }
    
    //public void AddData(long isbn, float lengte, float breedte, float dikte, float hoogte)
    public void AddData(string geboortedatum, string aut_naam, string wikipedia_aut, int is_tekenaar, int is_schrijver)
    {

        string sql =
            "INSERT INTO artiest (geboortedatum, aut_naam, wikipedia_aut, is_tekenaar, is_schrijver) VALUES (@geboortedatum, @aut_naam, @wikipedia_aut, @is_tekenaar, @is_schrijver);";
            //"INSERT INTO afmetingen (isbn, lengte, breedte, dikte, hoogte) VALUES (@isbn, @lengte, @breedte, @dikte, @hoogte);";
        
        using var connection = Connect();

        var affectedRows = connection.Execute(sql, new {geboortedatum = geboortedatum, aut_naam = aut_naam, wikipedia_aut = wikipedia_aut, is_tekenaar = is_tekenaar, is_schrijver = is_schrijver});
        
    }
}