namespace minuteWeather_BackEnd;

public class Alert
{
    public int? user_id {get; set;}
    public string? alert_time {get; set;}
    public int temp {get; set;}
    public int humidity {get; set;}
    public int precipitation {get; set;}
    public int wind {get; set;}
    public int uv {get; set;}

}
