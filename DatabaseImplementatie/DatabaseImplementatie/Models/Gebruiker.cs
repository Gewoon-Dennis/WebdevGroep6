namespace DatabaseImplementatie.Models;

public class Gebruiker
{
    public string gebruiker_id { get; set; }
    public string gebruikersnaam { get; set; }
    public string gebruikermail { get; set; }
    public string wachtwoord { get; set; }
    public string rol { get; set; }
}