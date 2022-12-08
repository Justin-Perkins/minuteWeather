
namespace MessageHandler
{
    /* Store data about the weather */
    internal class WeatherData
    {
        float latitude = 0;
        float longitude = 0;
        string currentWeather = "";
        string currentWeatherDescription = "";
        float currentTemperature = 0;
        float feelsLikeTemperature = 0;
        float? minimumTemperature = 0;
        float? maximumTemperature = 0;
        float pressure = 0;
        float humidity = 0;
        float visibility = 0;
        float windSpeed = 0;
        float windDegree = 0;
        float rain = 0;
        string country = "";
        string name = "";
        float uv = 0;

        public WeatherData(dynamic weatherData, dynamic ultraVioletJson)

        {
            latitude = weatherData.coord["lat"];
            longitude = weatherData.coord["lon"];
            currentWeather = weatherData.weather[0]["main"];
            currentWeatherDescription = weatherData.weather[0]["description"];
            currentTemperature = weatherData.main["temp"];
            feelsLikeTemperature = weatherData.main["feels_like"];
            minimumTemperature = weatherData.main["min_temp"];
            maximumTemperature = weatherData.main["max_temp"];
            pressure = weatherData.main["pressure"];
            humidity = weatherData.main["humidity"];
            visibility = weatherData.visibility;
            windSpeed = weatherData.wind["speed"];
            windDegree = weatherData.wind["deg"];

            country = weatherData.sys["country"];
            name = weatherData.name;
            uv = ultraVioletJson.value;
            try
            {
                rain = weatherData.rain["1h"];
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public float getLongitude()
        {
            return latitude;
        }

        public float getLatitude()
        {
            return longitude;
        }

        public string getCurrentWeather()
        {
            return currentWeather;
        }

        public string getCurrentWeatherDescription()
        {
            return currentWeatherDescription;
        }

        public float getCurrentTemperature()
        {
            return currentTemperature;
        }

        public float getFeelsLikeTemperature()
        {
            return feelsLikeTemperature;
        }

        public float? getMinimumTemperature()
        {
            return minimumTemperature;
        }

        public float? getMaximumTemperature()
        {
            return maximumTemperature;
        }

        public float getPressure()
        {
            return pressure;
        }

        public float getHumidity()
        {
            return humidity;
        }

        public float? getVisibility()
        {
            return visibility;
        }

        public float getWindSpeed()
        {
            return windSpeed;
        }

        public float getWindDegree()
        {
            return windDegree;
        }

        public float getRainfall()
        {
            return rain;
        }

        public string getCountryName()
        {
            return country;
        }

        public string getCityName()
        {
            return name;
        }

        public float getUltraViolet()
        {
            return uv;
        }
    }
}
