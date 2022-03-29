using Dapper;
using DatabaseImplementatie.Models;
using MySql.Data.MySqlClient;

namespace DatabaseImplementatie.Repository;

public class gebruikerRepository
{
    public string connectionString =
        "Server=178.84.118.110;Database=webdev-final;Uid=DBAdmin;Pwd=Password12345!;Port=3306";
    private MySqlConnection Connect()
    {
        return new MySqlConnection(connectionString);
    }
    
    public bool AddNewUser(Gebruiker gebruiker)
    {
        using var connection = Connect();
        int numRowEffected = connection.Execute(@"INSERT INTO gebruiker(gebruiker_id, gebruikersnaam, gebruikermail, wachtwoord, rol) 
            VALUES (@gebruiker_id, @gebruikersnaam, @gebruikermail, @wachtwoord, @rol)",gebruiker);

        return numRowEffected == 1;
    }
    
    public string GetVerzamelaar(string email, string password)
    {
        using var connection = Connect();
        string UserId= connection.QuerySingleOrDefault<string>(
            @"SELECT gebruiker_id FROM gebruiker WHERE gebruikermail = @Email AND wachtwoord = @Password"
            , new {Email = email, Password = password});
        return UserId;
     
    }
    
    public string AdminCheck(string userID)
    {
        using var connection = Connect();
        string rol= connection.QuerySingleOrDefault<string>(
            @"SELECT rol FROM gebruiker WHERE gebruiker_id = @UserID"
            , new {UserID = userID});
        return rol;
    }
    public string ModeratorCheck(string userID)
    {
        using var connection = Connect();
        string rol= connection.QuerySingleOrDefault<string>(
            @"SELECT rol FROM gebruiker WHERE gebruiker_id = @UserID"
            , new {UserID = userID});
        return rol;
    }

    public IEnumerable<Gebruiker> GetUserRole(string email)
    {
        string Search = "%"+email+"%";
        using var connection = Connect();
        return connection.Query<Gebruiker>(@"SELECT gebruiker_id, gebruikersnaam, gebruikermail, rol FROM gebruiker
                                                WHERE gebruikermail LIKE @GebruikerEmail", new { @GebruikerEmail = Search});
    }
    
    public bool PromoteUser(string GebruikerID)
    {
        using var connection = Connect();
        int Promote = connection.Execute(@"UPDATE gebruiker SET rol = 'Moderator' WHERE gebruiker_id = @UserID", new {UserID = GebruikerID});
        if(Promote > 0){return true;}

        return false;
    }
    public bool DemoteUser(string GebruikerID)
    {
        using var connection = Connect();
        int Demote = connection.Execute(@"UPDATE gebruiker SET rol = 'Verzamelaar' WHERE gebruiker_id = @UserID", new {UserID = GebruikerID});
        if(Demote > 0){return true;}

        return false;
    }
}