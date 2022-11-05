using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient; 
using System.Text.Json;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class WeeklyAlertController : SQLController
{

    private readonly ILogger<WeeklyAlertController> _logger;

    public WeeklyAlertController(ILogger<WeeklyAlertController> logger)
    {
        _logger = logger;
    }
    /*
    [HttpGet(Name = "GetWeeklyAlerts")]
    public string? Get()
    {
        List<Alert> weeklyAlertList = new List<Alert>();
        OpenSQLConnection();
        string query = "select * from daily_alert;";
        cmd = new MySqlCommand(query, conn);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Alert tempAlert = new Alert();
            tempAlert.user_id = Convert.ToInt32(reader["user_id"]); 
            tempAlert.alert_time = Convert.ToDateTime(reader["alert_time"]); 
            tempAlert.temp = Convert.ToInt32(reader["temp"]);
            tempAlert.humidity = Convert.ToInt32(reader["humidity"]);
            tempAlert.precipitation = Convert.ToInt32(reader["precipitation"]);
            tempAlert.wind = Convert.ToInt32(reader["wind"]);
            tempAlert.uv = Convert.ToInt32(reader["uv"]);
            weeklyAlertList.Add(tempAlert);
        }

        conn = CloseSQLConnection();

        var json = JsonSerializer.Serialize(weeklyAlertList);
        
        return json;
    }*/
    
    [HttpGet(Name = "GetAlertsAtTime")]
    //[Route("api/WeeklyAlert/{time}")]
    public string? Get([FromQuery] DateTime time)
    {
        List<Alert> weeklyAlertList = new List<Alert>();
        OpenSQLConnection();
        string query = "select * from weekly_alert where alert_time = @time;";
        cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("time", time);
        reader = cmd.ExecuteReader();
        
        while (reader.Read())
        {
            Alert tempAlert = new Alert();
            tempAlert.user_id = Convert.ToInt32(reader["user_id"]); 
            tempAlert.alert_time = Convert.ToDateTime(reader["alert_time"]); 
            tempAlert.temp = Convert.ToInt32(reader["temp"]);
            tempAlert.humidity = Convert.ToInt32(reader["humidity"]);
            tempAlert.precipitation = Convert.ToInt32(reader["precipitation"]);
            tempAlert.wind = Convert.ToInt32(reader["wind"]);
            tempAlert.uv = Convert.ToInt32(reader["uv"]);
            weeklyAlertList.Add(tempAlert);
        }

        conn = CloseSQLConnection();

        var json = JsonSerializer.Serialize(weeklyAlertList);
        
        return json;
    }

    [HttpPost]
    public void Post([FromQuery] Alert t_alert){
        OpenSQLConnection();
        
        string query = "insert into weekly_alert(user_id, alert_time, temp, humidity, precipitation, wind, uv) values(@user_id, @alert_time, @temp, @humidity, @precipitation, @wind, @uv)";
        
        cmd = new MySqlCommand(query, conn);
        
        cmd.Parameters.AddWithValue("@user_id", t_alert.user_id);
        cmd.Parameters.AddWithValue("@alert_time", t_alert.alert_time);
        cmd.Parameters.AddWithValue("@temp", t_alert.temp);
        cmd.Parameters.AddWithValue("@humidity", t_alert.humidity);
        cmd.Parameters.AddWithValue("@precipitation", t_alert.precipitation);
        cmd.Parameters.AddWithValue("@wind", t_alert.wind);
        cmd.Parameters.AddWithValue("@uv", t_alert.uv);
        
        cmd.ExecuteNonQuery();
        conn = CloseSQLConnection();
    }

    [HttpPut]
    public void Put([FromQuery] Alert t_alert){
        OpenSQLConnection();
        
        string query = "UPDATE weekly_alert SET alert_time = @alert_time, temp = @temp, humidity = @humidity, precipitation = @precipitation, wind = @wind, uv = @uv WHERE user_id = @user_id";
        
        cmd = new MySqlCommand(query, conn);
        
        cmd.Parameters.AddWithValue("@user_id", t_alert.user_id);
        cmd.Parameters.AddWithValue("@alert_time", t_alert.alert_time);
        cmd.Parameters.AddWithValue("@temp", t_alert.temp);
        cmd.Parameters.AddWithValue("@humidity", t_alert.humidity);
        cmd.Parameters.AddWithValue("@precipitation", t_alert.precipitation);
        cmd.Parameters.AddWithValue("@wind", t_alert.wind);
        cmd.Parameters.AddWithValue("@uv", t_alert.uv);
        
        cmd.ExecuteNonQuery();
        conn = CloseSQLConnection();
    }
}