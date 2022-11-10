using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; 
using System.Text.Json;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UserLoginController : SQLController
{

    private readonly ILogger<UserLoginController> _logger;

    public UserLoginController(ILogger<UserLoginController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    [Route("GetUserId")]
    public string? GetUserId()
    {
        List<UserLogin> loginList = new List<UserLogin>();
        OpenSQLConnection();
        string query = "select * from login;";
        cmd = new MySqlCommand(query, conn);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            UserLogin tempUserLogin = new UserLogin();
            tempUserLogin.user_id = Convert.ToInt32(reader["user_id"]); 
            tempUserLogin.username = Convert.ToString(reader["username"]); 
            tempUserLogin.password = Convert.ToString(reader["password"]);
            loginList.Add(tempUserLogin);
        }

        conn = CloseSQLConnection();

        var json = JsonSerializer.Serialize(loginList);
        
        return json;
    }

    [HttpGet]
    [Route("GetSpecificId")]
    public string? GetSpecificId([FromQuery] int user_Id)
    {
        List<UserLogin> loginList = new List<UserLogin>();
        OpenSQLConnection();
        string query = "select * from login where user_id = @id;";
        cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@id", user_Id);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            UserLogin tempUserLogin = new UserLogin();
            tempUserLogin.user_id = Convert.ToInt32(reader["user_id"]); 
            tempUserLogin.username = Convert.ToString(reader["username"]); 
            tempUserLogin.password = Convert.ToString(reader["password"]);
            loginList.Add(tempUserLogin);
        }

        conn = CloseSQLConnection();

        var json = JsonSerializer.Serialize(loginList);
        
        return json;
    }

    [HttpPost]
    [Route("NewUserLogin")]
    public void NewUserLogin ([FromQuery] string username, string password){
        OpenSQLConnection();
        
        string query = "insert into login (username, password) values(@username, @password);";
        
        cmd = new MySqlCommand(query, conn);
        
        cmd.Parameters.AddWithValue("@username", username);
        cmd.Parameters.AddWithValue("@password", password);
        
        cmd.ExecuteNonQuery();
        conn = CloseSQLConnection();

    }

}