namespace DatabaseImplementatie.Models;

public class uitgave
{
        public string uitgave_id { get; set; }
        public string uitgave_titel { get; set; }
        public long isbn { get; set; }
        public string uitgavejaar { get; set; }
        public int druk { get; set; }
        public string taal { get; set; }
        public int blz { get; set; }
        public bool expliciet { get; set; }
        public string afmetingen { get; set; }
        public string reeks_id { get; set; }
        public string uitgever_id { get; set; }
        public string schrijver_id { get; set; }
        public string tekenaar_id { get; set; }
        public string afbeelding { get; set; }
        public string beschrijving { get; set; }
        public bool verified { get; set; }
}