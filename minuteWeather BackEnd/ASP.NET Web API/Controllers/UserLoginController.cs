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

    [HttpGet(Name = "GetUserLogin")]
    public string? Get()
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

    [HttpPost]
    public void Post([FromQuery] UserLogin t_userLogin){
        OpenSQLConnection();
        
        string query = "insert into login (user_id, username, password) values(@user_id, @username, @password);";
        
        cmd = new MySqlCommand(query, conn);
        
        cmd.Parameters.AddWithValue("@user_id", t_userLogin.user_id);
        cmd.Parameters.AddWithValue("@username", t_userLogin.username);
        cmd.Parameters.AddWithValue("@password", t_userLogin.password);
        
        cmd.ExecuteNonQuery();
        conn = CloseSQLConnection();
    }

}