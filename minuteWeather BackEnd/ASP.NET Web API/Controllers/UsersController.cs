using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; 
using System.Text.Json;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : SQLController
{

    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    public string? Get()
    {
        List<User> userList = new List<User>();
        OpenSQLConnection();
        string query = "select * from users;";
        cmd = new MySqlCommand(query, conn);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            User tempUser = new User();
            tempUser.user_id = Convert.ToInt32(reader["user_id"]); 
            tempUser.first_name = Convert.ToString(reader["first_name"]); 
            tempUser.last_name = Convert.ToString(reader["last_name"]);
            tempUser.phone = Convert.ToInt32(reader["phone"]);
            tempUser.city_name = Convert.ToString(reader["city_name"]);
            tempUser.state_code = Convert.ToString(reader["state_code"]);
            tempUser.country_code = Convert.ToString(reader["country_code"]);
            userList.Add(tempUser);
        }

        conn = CloseSQLConnection();

        var json = JsonSerializer.Serialize(userList);
        
        return json;
    }

    [HttpPost]
    public void Post([FromQuery] User t_user){
        OpenSQLConnection();
        
        string query = "insert into users (first_name, last_name, phone, city_name, state_code, country_code) values (@first_name, @last_name, @phone, @city_name, @state_code, @country_code);";
        
        cmd = new MySqlCommand(query, conn);
        
        cmd.Parameters.AddWithValue("@first_name", t_user.first_name);
        cmd.Parameters.AddWithValue("@last_name", t_user.last_name);
        cmd.Parameters.AddWithValue("@phone", t_user.phone);
        cmd.Parameters.AddWithValue("@city_name", t_user.city_name);
        cmd.Parameters.AddWithValue("@state_code", t_user.state_code);
        cmd.Parameters.AddWithValue("@country_code", t_user.country_code);
        
        cmd.ExecuteNonQuery();
        conn = CloseSQLConnection();
    }

}