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
    public IEnumerable<tekenaar> GetTekenaars()
    {
        using var connection = Connect();
        return Connect().Query<tekenaar>("SELECT * FROM tekenaar");
    }
    public IEnumerable<schrijver> GetSchrijvers()
    {
        using var connection = Connect();
        return Connect().Query<schrijver>("SELECT * FROM schrijver");
    }
} 