using Dapper;
using DatabaseImplementatie.Models;
using DatabaseImplementatie.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Pages;

public class Ophalen : PageModel
{
    private MySqlConnection Connect()
    {
        return new MySqlConnection("Server=24.132.196.32;Database=alternatief;Uid=DBAdmin;Pwd=Password12345!;Port=3306");
    }
    
    public void OnGet()
    {
        ResultaatUitgave = new uitgaveRepository().GetAll();
        
    }
    
    public void OnPostReeks()
    {
        ResultaatUitgave = new uitgaveRepository().GetReeks();
    }
    public void OnPostAZ()
    {
        ResultaatUitgave = new uitgaveRepository().GetAZ();
    }

    public void OnPostAddToWishList([FromForm] string @item.id)
    {
        using var connection = Connect();
        string sql = "INSERT INTO wishlist_has_stripboek (uitgave_id) VALUES (@id) WHERE wishlist_id= @wishlist_id AND wishlist_gebruiker_naam= @gebruiker_naam AND wishlist_gebruiker_wachtwoord= @gebruiker_wachtwoord";

        int wishlist_id = 1;
        string gebruikernaam = "Dennis";
        string wachtwoord = "Wachtwoord";
        connection.Execute(sql, new {id = @item.id, wishlist_id = wishlist_id, wishlist_gebruiker_naam = gebruikernaam, wishlist_gebruiker_wachtwoord = wachtwoord });
    }

    public IEnumerable<uitgave> ResultaatUitgave { get; set; }
    
}