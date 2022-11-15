using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageHandler
{
    internal class Alert
    {
        public int? user_id { get; set; }
        public string? alert_time { get; set; }
        public int temp { get; set; }
        public int humidity { get; set; }
        public int precipitation { get; set; }
        public int wind { get; set; }
        public int uv { get; set; }
        public string? phone { get; set; }
        public string? city { get; set; }
        public string? stateCode { get; set; }
        public string? countryCode { get; set; }


        public string createTextString(WeatherData weather)
        {
            string message = "Weather Data for " + DateTime.Now.ToString() +
                "\nLocation: " + weather.getCityName() + ", " + weather.getCountryName() +
                "\nDescription: " + weather.getCurrentWeatherDescription() +
                "\nTemperature: " + weather.getCurrentTemperature();
            if (humidity == 1)
            {
                message = message + "\nHumidity: " + weather.getHumidity();
            }
            if (precipitation == 1)
            {
                message = message + "\nTotal rainfall in the next hour: " + weather.getRainfall();
            }
            if (wind == 1)
            {
                message = message + "\nWind: " + weather.getWindSpeed();
            }
            if (uv == 1)
            {
                message = message + "\nMax ultra violet: " + weather.getUltraViolet();
            }
            return message;
        }
    }
}
