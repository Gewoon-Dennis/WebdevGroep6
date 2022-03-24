namespace DatabaseImplementatie.Models;

public class UitgavePak
{
        public Guid C_uitgave_id { get; set; }
        public string C_uitgave_titel { get; set; }
        public long C_isbn { get; set; }
        public int C_uitgavejaar { get; set; }
        public int C_druk { get; set; }
        public string C_taal { get; set; }
        public int C_blz { get; set; }
        public int C_expliciet { get; set; }
        public string C_afmetingen { get; set; }
        public string C_reeks_naam { get; set; }
        public string C_uitgever_naam { get; set; }
        public string C_tekennaar_naam { get; set; }
        public string C_schrijver_naam { get; set; }
        public string C_afbeelding { get; set; }
        public int C_verified = 0;
}