﻿namespace DatabaseImplementatie.Models;

public class uitgave
{
        public Guid uitgave_id { get; set; }
        public string titel { get; set; }
        public long isbn { get; set; }
        
        public int uitgavejaar { get; set; }
        public int druk { get; set; }
        public string taal { get; set; }
        public int blz { get; set; }
        public int expliciet { get; set; }
        public string afmetingen { get; set; }
        public string reeks_id { get; set; }
        public string uitgever_id { get; set; }
        public string afbeelding { get; set; }
        public int verified = 0;
}