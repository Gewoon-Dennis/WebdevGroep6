﻿using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace DatabaseImplementatie.Repository;

public class uitgaveRepository
{
    public string connectionString =
        "Server=178.84.118.110;Database=webdev-final;Uid=DBAdmin;Pwd=Password12345!;Port=3306";

    private MySqlConnection Connect()
    {
        return new MySqlConnection(connectionString);
    }

    public IEnumerable<UitgavePak> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam,/* afbeelding*/ schrijver_naam, verified
                FROM uitgave
                INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id);");
    }

    public IEnumerable<UitgavePak> GetAZ()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam, afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
INNER JOIN uitgever USING (uitgever_id)
INNER JOIN schrijver USING (schrijver_id)
INNER JOIN tekenaar USING (tekenaar_id)
order by uitgave_titel;");
    }

    public IEnumerable<UitgavePak> GetReeks()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam, afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
INNER JOIN uitgever USING (uitgever_id)
INNER JOIN schrijver USING (schrijver_id)
INNER JOIN tekenaar USING (tekenaar_id)
order by reeks_naam;");
    }

    public bool AddUitgave(uitgave UitGave, reeks Reeks, uitgever Uitgever, tekenaar Tekenaar, schrijver Schrijver)
    {
        using var connection = Connect();
        
        int LinkReeks = connection.Execute(@"INSERT INTO reeks (reeks_id, reeks_naam)
            VALUES (@reeks_id, @reeks_naam)", Reeks);
        
        int LinkUitgever = connection.Execute(@"INSERT INTO uitgever (uitgever_id, uitgever_naam)
            VALUES (@uitgever_id, @uitgever_naam)", Uitgever);
        
        int LinkTekenaar = connection.Execute(
        @"INSERT INTO tekenaar (tekenaar_id, tekenaar_naam, geboortedatum, geslacht, wikipedia_tekenaar)
            VALUES (@tekenaar_id, @tekenaar_naam, @geboortedatum, @geslacht, @wikipedia_tekenaar)", Tekenaar);
        
        int LinkSchrijver = connection.Execute(
        @"INSERT INTO schrijver (schrijver_id, schrijver_naam, geboortedatum, geslacht, wikipedia_schrijver)
            VALUES (@schrijver_id, @schrijver_naam, @geboortedatum, @geslacht, @wikipedia_schrijver)", Schrijver);
        
        int AddUitgave = connection.Execute(@"INSERT INTO uitgave(uitgave_id, uitgave_titel, isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_id, uitgever_id, tekenaar_id, schrijver_id, afbeelding, beschrijving, verified)
                VALUES (@uitgave_id, @uitgave_titel, @isbn, @uitgavejaar, @druk, @taal, @blz, @expliciet, @afmetingen, @reeks_id, @uitgever_id, @tekenaar_id, @schrijver_id, @afbeelding, @beschrijving, @verified)", UitGave);


        if (AddUitgave > 0 && LinkReeks > 0 && LinkUitgever > 0 && LinkTekenaar > 0 && LinkSchrijver > 0)
        {
            return true;
        }
        else
        {
            return false;
            
        }
    
    }

}
