﻿namespace DatabaseImplementatie.Models;

public class tekenaar
{
    public Guid tekenaar_id { get; set; }
    public string tekenaar_naam { get; set; }
    public string geboortedatum { get; set; }
    public string geslacht { get; set; }
    public string wikipedia_tekenaar { get; set; }
}