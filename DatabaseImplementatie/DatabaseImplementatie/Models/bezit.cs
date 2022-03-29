namespace DatabaseImplementatie.Models;

public class bezit
{
    public string gebruiker_id { get; set; }
    public string uitgave_id { get; set; }
    public bool gelezen { get; set; }
    public string kwaliteit_boek { get; set; }
    public string kwaliteit_verhaal { get; set; }
}