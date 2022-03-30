namespace DatabaseImplementatie.Models;

public class collectie
{
    public string uitgave_id { get; set; }
    public string uitgave_titel { get; set; }
    public string uitgavejaar { get; set; }
    public int druk { get; set; }
    public string taal { get; set; }
    public string afmetingen { get; set; }
    public string reeks_naam { get; set; }
    public string uitgever_naam { get; set; }
    public string tekenaar_naam { get; set; }
    public string schrijver_naam { get; set; }
    public string gelezen { get; set; }
    public string kwaliteit_boek { get; set; }
    public string kwaliteit_verhaal { get; set; }
    public string afbeelding { get; set; }
}