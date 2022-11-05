namespace minuteWeather_BackEnd;

public class User
{
	public int user_id {get; set;} 
	public string? first_name {get; set;}
	public  string? last_name {get; set;}
	public int phone {get; set;}
	public string? city_name {get; set;}
	public string? state_code {get; set;}
	public string? country_code {get; set;}
}