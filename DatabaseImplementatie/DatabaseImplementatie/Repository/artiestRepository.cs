using Dapper;
using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Repository;

public class artiestRepository
{
    public string connectionString =
        "Server=178.84.118.110;Database=alternatief;Uid=DBAdmin;Pwd=Password12345!;Port=3306";
    private MySqlConnection Connect()
    {
        return new MySqlConnection(connectionString);
    }
    public IEnumerable<artiest> GetAll()
    {
        using var connection = Connect();
        return Connect().Query<artiest>("SELECT * FROM artiest");
    }
} 