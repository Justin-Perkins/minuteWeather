using Newtonsoft.Json;


namespace MessageHandler
{
    internal class WeatherAPI
    {
        static HttpClient httpClient = new HttpClient();

        /* get properties about a city given the name, state code, and country code */
        public static async Task<City?> getCityData(string cityName, string stateCode, string countryCode)
        {
            //http://api.openweathermap.org/geo/1.0/direct?q=Hooksett,US-NH,3166-2:US&limit=1&appid=454d61aae24208d25e6421d9b83c4fca
            string url = string.Format("http://api.openweathermap.org/geo/1.0/direct?q={0},{1},{2}&limit=1&appid=454d61aae24208d25e6421d9b83c4fca",cityName,stateCode,countryCode);
            string response = await httpClient.GetStringAsync(url);

            dynamic? cityJson  = JsonConvert.DeserializeObject(response);
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
            //https://api.openweathermap.org/data/2.5/weather?lat=43.096972&lon=-71.465378&appid=454d61aae24208d25e6421d9b83c4fca&units=imperial
            //https://api.openweathermap.org/data/2.5/uvi?lat=43.096972&lon=-71.465378&appid=454d61aae24208d25e6421d9b83c4fca

            string url = String.Format("https://api.openweathermap.org/data/2.5/weather?lat={0}&lon={1}&appid=454d61aae24208d25e6421d9b83c4fca&units=imperial",lat,lon);
            string response = await httpClient.GetStringAsync(url);
            if (response == null)
            {
                Console.WriteLine("Failed to get a response from the API, do you have internet?");
                return null;
            }
            dynamic? weatherJson = JsonConvert.DeserializeObject(response);
            if (weatherJson == null)
            {
                return null;
            }
            url = String.Format("https://api.openweathermap.org/data/2.5/uvi?lat={0}&lon={1}&appid=454d61aae24208d25e6421d9b83c4fca", lat, lon);
            response = await httpClient.GetStringAsync(url);
            dynamic? ultraVioletJson = JsonConvert.DeserializeObject(response);
            WeatherData weatherData = new WeatherData(weatherJson, ultraVioletJson);
            return weatherData;
        }
    }
}
