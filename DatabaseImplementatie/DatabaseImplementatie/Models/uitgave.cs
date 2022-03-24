namespace DatabaseImplementatie.Models;

public class C_uitgave
{
        public Guid C_uitgave_id { get; set; }
        public string C_uitgave_titel { get; set; }
        public long C_isbn { get; set; }
        public int C_uitgavejaar { get; set; }
        public int C_druk { get; set; }
        public string C_taal { get; set; }
        public int C_blz { get; set; }
        public bool C_expliciet { get; set; }
        public string C_afmetingen { get; set; }
        public Guid C_reeks_id { get; set; }
        public Guid C_uitgever_id { get; set; }
        public Guid C_schrijver_id { get; set; }
        public Guid C_tekenaar_id { get; set; }
        public string C_afbeelding { get; set; }
        public string C_beschrijving { get; set; }
        public bool C_verified { get; set; }
}