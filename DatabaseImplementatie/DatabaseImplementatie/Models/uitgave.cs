using System.Net.Mime;

namespace DatabaseImplementatie.Models;

public class uitgave
{
        public Guid uitgave_id { get; set; }
        public string uitgave_titel { get; set; }
        public long isbn { get; set; }
        public string uitgavejaar { get; set; }
        public int druk { get; set; }
        public string taal { get; set; }
        public int blz { get; set; }
        public bool expliciet { get; set; }
        public string afmetingen { get; set; }
        public Guid reeks_id { get; set; }
        public Guid uitgever_id { get; set; }
        public Guid schrijver_id { get; set; }
        public Guid tekenaar_id { get; set; }
        public byte[] afbeelding { get; set; }
        public string beschrijving { get; set; }
        public bool verified { get; set; }
}