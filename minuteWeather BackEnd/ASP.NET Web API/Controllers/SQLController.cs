using System;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; 

namespace minuteWeather_BackEnd.Controllers;

public class SQLController : ControllerBase
{
    public static MySql.Data.MySqlClient.MySqlConnection? conn;
    public static MySqlCommand? cmd;
    public static MySqlDataReader? reader;
    
    [NonAction]
    public static void OpenSQLConnection()
    {
        String myConnectionString;
        string? MYSQL_PASSWORD = Environment.GetEnvironmentVariable("MySQL");

        //Grabs the MySQL password from enviornment variable
        myConnectionString = "SERVER=localhost;DATABASE=minuteWeather;UID=root;PASSWORD='" + MYSQL_PASSWORD + "';";

        //Tries to open a connection to the database
        try
        {
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
            conn.Open();
        }
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Console.WriteLine(ex.Message);
        }

        //return conn;
    }
    
    [NonAction]
    public static MySql.Data.MySqlClient.MySqlConnection CloseSQLConnection()
    {
        conn.Close();
        return conn;
    }  
}