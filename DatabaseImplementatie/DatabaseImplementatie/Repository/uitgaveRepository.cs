using DatabaseImplementatie.Models;
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

    //get fucntions
    public IEnumerable<UitgavePak> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding
                FROM uitgave
                INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1;");
    }
    
    public IEnumerable<UitgavePak> GetUnverified()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam
                FROM uitgave
                INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 0;");
    }

    //get functios for filters
    public IEnumerable<UitgavePak> GetAZ()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by uitgave_titel ASC");
    }
    
    public IEnumerable<UitgavePak> GetZA()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by uitgave_titel DESC");
    }
    
    public IEnumerable<UitgavePak> GetReeks()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by reeks_naam ASC");
    }

    public IEnumerable<UitgavePak> GetUitgever()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by uitgever_naam ASC");
    }
    
    public IEnumerable<UitgavePak> GetTekenaar()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by tekenaar_naam ASC");
    }
    
    public IEnumerable<UitgavePak> GetSchrijver()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE verified = 1
                order by schrijver_naam ASC");
    }
   
    //collection search
    public IEnumerable<UitgavePak> ZoekUitgave(string searchTerm)
    {
        string Zoekterm = "%" + searchTerm + "%";
        using var connection = Connect();
        return Connect().Query<UitgavePak>(
            @"SELECT DISTINCT uitgave_id, uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id)
                WHERE uitgave_titel LIKE @search AND verified = 1", new{@search = Zoekterm});
    }

    //collection functions
    public bool AddToCollection(bezit Bezit)
    {
        using var connection = Connect();
        int AddToCollection = connection.Execute(
            @"INSERT INTO bezit (gebruiker_id, uitgave_id, gelezen, kwaliteit_boek, kwaliteit_verhaal) 
            VALUES (@gebruiker_id, @uitgave_id, @gelezen, @kwaliteit_boek, @kwaliteit_verhaal)", Bezit);
        if (AddToCollection > 0)
        {
           return true; 
        }

        return false;
    }

    public IEnumerable<collectie> GetCollectie(string Gebruiker_Id)
    {
        using var connection = Connect();
        return Connect().Query<collectie>(@"SELECT uitgave_id, uitgave_titel, uitgavejaar, druk, taal, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam, gelezen, kwaliteit_boek, kwaliteit_verhaal
                        FROM bezit
                        INNER JOIN uitgave USING (uitgave_id)
                        INNER JOIN reeks USING (reeks_id)
                        INNER JOIN uitgever USING (uitgever_id)
                        INNER JOIN schrijver USING (schrijver_id)
                        INNER JOIN tekenaar USING (tekenaar_id)
                        WHERE gebruiker_id = @gebruiker_id", new {@gebruiker_id = Gebruiker_Id});
    }
    
    public bool RemoveFromCollection(string Uitgave_Id, string Gebruiker_Id)
    {
        using var connection = Connect();
        int DeleteFromCollection = connection.Execute(
            @"DELETE bezit FROM bezit WHERE uitgave_id = @uitgave_id AND gebruiker_id = @gebruiker_id", new { @uitgave_id = Uitgave_Id, @gebruiker_id = Gebruiker_Id});
        if (DeleteFromCollection > 0)
        {
            return true; 
        }

        return false;
    }
    
    
    //add stripboek function 
    public bool AddUitgave(uitgave UitGave, reeks Reeks, uitgever Uitgever, tekenaar Tekenaar, schrijver Schrijver)
    {
        int LinkSchrijver = 0;
        using var connection = Connect();
        
        int LinkReeks = connection.Execute(@"INSERT INTO reeks (reeks_id, reeks_naam)
            VALUES (@reeks_id, @reeks_naam)", Reeks);
        
        int LinkUitgever = connection.Execute(@"INSERT INTO uitgever (uitgever_id, uitgever_naam)
            VALUES (@uitgever_id, @uitgever_naam)", Uitgever);
        
        int LinkTekenaar = connection.Execute(
        @"INSERT INTO tekenaar (tekenaar_id, tekenaar_naam, geboortedatum, geslacht, wikipedia_tekenaar)
            VALUES (@tekenaar_id, @tekenaar_naam, @geboortedatum, @geslacht, @wikipedia_tekenaar)", Tekenaar);

        if (Schrijver.schrijver_id != null)
        {
            LinkSchrijver = connection.Execute(
                @"INSERT INTO schrijver (schrijver_id, schrijver_naam, geboortedatum, geslacht, wikipedia_schrijver)
            VALUES (@schrijver_id, @schrijver_naam, @geboortedatum, @geslacht, @wikipedia_schrijver)", Schrijver);
        }
        else
        {
            LinkSchrijver = 1;
        }

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
    //verify comic function
    public bool VerifyComic(string UitgaveId)
    {
        using var connection = Connect();
        int Verify = connection.Execute(@"UPDATE uitgave SET verified = '1' WHERE uitgave_id = @Uitgave_Id", new {Uitgave_Id = UitgaveId});
        if(Verify > 0){return true;}

        return false;
    }
    public bool UnVerifyComic(string UitgaveId)
    {
        using var connection = Connect();
        int Verify = connection.Execute(@"UPDATE uitgave SET verified = '0' WHERE uitgave_id = @Uitgave_Id", new {Uitgave_Id = UitgaveId});
        if(Verify > 0){return true;}

        return false;
    }
    
    //delete unverified comic
    public bool DeleteComic(string UitgaveId)
    {
        using var connection = Connect();
        int Verify = connection.Execute(@"DELETE uitgave FROM uitgave
                    INNER JOIN reeks USING (reeks_id)
                    INNER JOIN uitgever USING (uitgever_id)
                    INNER JOIN schrijver USING (schrijver_id)
                    INNER JOIN tekenaar USING (tekenaar_id) WHERE uitgave_id = @Uitgave_Id", new {Uitgave_Id = UitgaveId});
        if(Verify > 0){return true;}

        return false;
    }

}
