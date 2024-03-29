﻿using Newtonsoft.Json;
using Twilio.TwiML.Voice;


namespace MessageHandler
{
    /* Make calls to the OpenWeather API */
    internal class WeatherAPI
    {
        static HttpClient httpClient = new HttpClient(); // Used for API calls
        static string? weatherToken = Environment.GetEnvironmentVariable("WeatherToken"); // Token for API calls


        /* get properties about a city given the name, state code, and country code */
        public static async Task<City?> getCityData(string cityName, string stateCode, string countryCode)
        {

            string url = string.Format("http://api.openweathermap.org/geo/1.0/direct?q={0},{1},{2}&limit=1&appid={3}",cityName,stateCode,countryCode,weatherToken);
            string response = await httpClient.GetStringAsync(url);
            dynamic? cityJson = JsonConvert.DeserializeObject(response);

            if (cityJson == null)
            {
                return null;
            }

            

            City city = new City(cityJson);
            return city;

        }

        /* get properties about the weather given the latitude and longitude */
        public static async Task<WeatherData?> getWeatherData(string lat, string lon)
        {
            
            /* Get most of the weather data */
            string url = String.Format("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid={2}&units=imperial",lat,lon,weatherToken);
            string response = await httpClient.GetStringAsync(url);

            if (response == null)
            {
                Console.WriteLine("Failed to get a response from the API, do you have internet?");
                return null;
            }

            dynamic? weatherJson = JsonConvert.DeserializeObject(response); // Deserialize to Json object

            if (weatherJson == null)
            {
                return null;
            }

            // Make a separate call to the weather api to get ultra violet data
            url = String.Format("https://api.openweathermap.org/data/2.5/uvi?lat={0}&lon={1}&appid={2}", lat, lon, weatherToken); // 
            response = await httpClient.GetStringAsync(url);
            dynamic? ultraVioletJson = JsonConvert.DeserializeObject(response);
            WeatherData weatherData = new WeatherData(weatherJson, ultraVioletJson); // Store weather data in a weatherData object
            return weatherData;

        }
    }
}
