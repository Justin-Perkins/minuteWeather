

namespace OpenWeatherAPI
{
    internal class WeatherData
    {
        float latitude;
        float longitude;
        string currentWeather;
        string currentWeatherDescription;
        float currentTemperature;
        float feelsLikeTemperature;
        float? minimumTemperature;
        float? maximumTemperature;
        float pressure;
        float humidity;
        float visibility;
        float windSpeed;
        float windDegree;

        public WeatherData(dynamic weatherData)
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
    }
}
