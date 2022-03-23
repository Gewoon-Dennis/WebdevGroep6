namespace DatabaseImplementatie.Models;

public class Gebruiker
{
    public Guid Gebruiker_id { get; set; }
    public string Gebruiker_Naam { get; set; }
    public string Gebruiker_Mail { get; set; }
    public string Wachtwoord { get; set; }
    public string Rol { get; set; }
}