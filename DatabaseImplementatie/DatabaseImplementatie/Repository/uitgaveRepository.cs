﻿using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace DatabaseImplementatie.Repository;

public class uitgaveRepository
{
    private MySqlConnection Connect()
    {
        return new MySqlConnection("Server=24.132.196.32;Database=alternatief;Uid=DBAdmin;Pwd=Password12345!;Port=3306");
    }
    public IEnumerable<uitgave> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<uitgave>("SELECT * FROM uitgave");
    }

    public void AddData(string titel, long isbn, int druk, string taal, int jaar, int blz, long barcode, int expliciet,
        string afmetingen, string reeks, string uitgever)
    {
        string sql =
            "INSERT INTO uitgave (titel, isbn, druk, taal, jaar, blz, barcode, expliciet, afmetingen, reeks, uitgever) VALUES (@titel, @isbn, @druk, @taal, @jaar, @blz, @barcode, @expliciet, @afmetingen, @reeks, @uitgever);";
        using var connection = Connect();

        var affectedRows = connection.Execute(sql,
            new
            {
                titel = titel, isbn = isbn, druk = druk, taal = taal, jaar = jaar, blz = blz, barcode = barcode,
                expliciet = expliciet, afmetingen = afmetingen, reeks = reeks, uitgever = uitgever
            });
    }
    
}