﻿using Dapper;
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
            VALUES (@Gebruiker_id, @Gebruiker_Naam, @Gebruiker_Mail, @Wachtwoord, @Rol)",gebruiker);

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
}