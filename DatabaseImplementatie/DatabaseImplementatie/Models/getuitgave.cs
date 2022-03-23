namespace DatabaseImplementatie.Models;

public class UitgavePak
{
        public Guid uitgave_id { get; set; }
        public string uitgave_titel { get; set; }
        public long isbn { get; set; }
        public int uitgavejaar { get; set; }
        public int druk { get; set; }
        public string taal { get; set; }
        public int blz { get; set; }
        public int expliciet { get; set; }
        public string afmetingen { get; set; }
        public string reeks_naam { get; set; }
        public string uitgever_naam { get; set; }
        public string schrijvernaam { get; set; }
        public string tekennaarnaam { get; set; }
        public int isSchrijver { get; set; }
        public int isTekenaar { get; set; }
        public string afbeelding { get; set; }
        public int verified = 0;
}