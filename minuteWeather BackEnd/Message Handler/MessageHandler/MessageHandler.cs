using SendTextMessage;
using System.Timers;
using MySql.Data.MySqlClient;


namespace MessageHandler
{
    /* Driver class */
    internal class MessageHandler
    {
        static string server = "localhost"; // server ip
        static string database = "minuteWeather"; // database name
        static string username = "root"; // MySQL username
        static string? password = Environment.GetEnvironmentVariable("SNHU_PASS"); // MySQL password
        static string connstring = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + username + ";" + "PASSWORD=" + password + ";"; // connection string for connection object
        static MySqlConnection conn = new MySqlConnection(connstring); // MySQL connection object
        static DateTime lastMinute; // Previous check time
        static System.Timers.Timer? timer; // Timer to check for alerts to send


        // Start the program
        static void Main(string[] args)
        {
            timer = new System.Timers.Timer(1000);
            lastMinute = DateTime.Now;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Start();
            while (true)
            { // Keep the program running forever
            }
        }


        // Check for alerts to send. Execute at the top of the minute every minute
        private static void OnTimedEvent(object? source, ElapsedEventArgs e) // execute findAlertsToSend function at the start of every minute
        {

            if (lastMinute.Minute < DateTime.Now.Minute || (lastMinute.Minute == 59 && DateTime.Now.Minute == 0))
            {
                lastMinute = DateTime.Now;
                Console.WriteLine("Checking for alerts to send");
                findAlertsToSend();
            }
        }


        // Look at the alerts in the database. If alerts are found that need to be sent now, get the data and send the data
        private static async void findAlertsToSend()
        {
            List<TimeSpan> timeList = MySql.updateAlertList(conn);
            foreach (TimeSpan time in timeList)
            {
                if (time.Hours == DateTime.Now.Hour && time.Minutes == DateTime.Now.Minute)
                {
                    List<Alert> alertList = MySql.getAlertsFromDatabase(conn, time.ToString());
                    foreach (Alert alert in alertList)
                    {
                        try
                        {
                            Console.WriteLine("Sending alert to " + alert.phone);
                            City? city = await WeatherAPI.getCityData(alert.city, alert.stateCode, alert.countryCode);
                            WeatherData? weatherData = await WeatherAPI.getWeatherData(city.getLatitude(), city.getLongitude());
                            TwilioAPI.sendSmsMessage(alert.phone, alert.createTextString(weatherData));
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Failed to get weather data. Are you connected to the internet?");
                        }
                    }
                }
            }
        }
    }
}
