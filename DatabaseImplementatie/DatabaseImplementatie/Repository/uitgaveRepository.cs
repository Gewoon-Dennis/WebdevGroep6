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
        return Connect().Query<UitgavePak>(@"SELECT uitgave_titel,  isbn, uitgavejaar, druk, taal, blz, expliciet, afmetingen, reeks_naam, uitgever_naam, tekenaar_naam, schrijver_naam,afbeelding, verified
                FROM uitgave
                INNER JOIN reeks USING (reeks_id)
                INNER JOIN uitgever USING (uitgever_id)
                INNER JOIN schrijver USING (schrijver_id)
                INNER JOIN tekenaar USING (tekenaar_id);");
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

    public void AddData(uitgave Uitgave, reeks Reeks, uitgever Uitgever,tekenaar Tekenaar, schrijver Schrijver)
    {
        using var connection = Connect();
    }
    
}