using Dapper;
using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Repository;

public class artiestRepository
{
    public string connectionString =
        "Server=178.84.118.110;Database=webdev-final;Uid=DBAdmin;Pwd=Password12345!;Port=3306";
    private MySqlConnection Connect()
    {
        return new MySqlConnection(connectionString);
    }
    public IEnumerable<tekenaarPak> GetTekenaars()
    {
        using var connection = Connect();
        return Connect().Query<tekenaarPak>("SELECT * FROM tekenaar");
    }
    public IEnumerable<schrijverPak> GetSchrijvers()
    {
        using var connection = Connect();
        return Connect().Query<schrijverPak>("SELECT * FROM schrijver");
    }
} 