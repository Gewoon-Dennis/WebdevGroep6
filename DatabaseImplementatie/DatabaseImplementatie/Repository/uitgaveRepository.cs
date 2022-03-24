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
    public IEnumerable<UitgavePak> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(@"SELECT uitgave_titel, isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, artiest_naam, rol_schrijver, rol_tekenaar, afbeelding, verified
        FROM uitgave
        INNER JOIN heeft USING(uitgave_id)
        INNER JOIN reeks USING (reeks_id)
        INNER JOIN uitgever USING (uitgever_id)
        INNER JOIN artiest USING (artiest_id);");
    }

    public IEnumerable<UitgavePak> GetAZ()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(@"SELECT uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
INNER JOIN uitgever USING (uitgever_id)
INNER JOIN schrijver USING (schrijver_id)
INNER JOIN tekenaar USING (tekenaar_id)
order by uitgave_titel;");
    }
    public IEnumerable<UitgavePak> GetReeks()
    {
        using var connection = Connect();
        return Connect().Query<UitgavePak>(@"SELECT uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified FROM uitgave INNER JOIN reeks USING (reeks_id)
INNER JOIN uitgever USING (uitgever_id)
INNER JOIN schrijver USING (schrijver_id)
INNER JOIN tekenaar USING (tekenaar_id)
order by reeks_naam;");
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