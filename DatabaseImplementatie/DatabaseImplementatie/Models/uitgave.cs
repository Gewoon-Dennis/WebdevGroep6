namespace DatabaseImplementatie.Models;

public class uitgave
{
        public string id { get; set; }
        public string titel { get; set; }
        public long isbn { get; set; }
        public int druk { get; set; }
        public string taal { get; set; }
        public int jaar { get; set; }
        public int blz { get; set; }
        public long barcode { get; set; }
        public int expliciet { get; set; }
        public string afmetingen { get; set; }
        public string reeks { get; set; }
        public string uitgever { get; set; }
        public string beschrijving { get; set; }
}