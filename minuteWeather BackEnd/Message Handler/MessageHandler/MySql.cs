using MySql.Data.MySqlClient;

namespace MessageHandler
{
    /* Class to interact with the database */
    internal class MySql
    {
        static string query = ""; // query string
        static MySqlCommand? cmd;// sql command
        static MySqlDataReader? dataReader; // read data from a sql query
        public static List<TimeSpan> timeList = new List<TimeSpan>(); // List of times to send alerts
        public static List<Alert> alertList = new List<Alert>(); // List of alerts and their porperties


        /* Return a list of all alert times in the database. Exclude duplicate times */
        public static List<TimeSpan> updateAlertList(MySqlConnection conn)
        {
            timeList.Clear();
            conn.Open();
            query = "select distinct alert_time from daily_alert;"; // query string
            cmd = new MySqlCommand(query, conn); // sql command
            dataReader = cmd.ExecuteReader(); // read data from a sql query
            while (dataReader.Read())
            {
                timeList.Add((TimeSpan)dataReader["alert_time"]);
            }
            conn.Close();
            return timeList;
        }


        /* Return a list of all alerts in the database at a specific time */
        public static List<Alert> getAlertsFromDatabase(MySqlConnection conn, string alert_time)
        {
            alertList.Clear();
            conn.Open();
            query = "select daily_alert.*,phone,city_name,state_code,country_code from daily_alert,users where daily_alert.user_id = users.user_id and alert_time = @time;";
            cmd = new MySqlCommand(query, conn); // sql command
            cmd.Parameters.AddWithValue("time", alert_time);
            dataReader = cmd.ExecuteReader(); // read data from a sql query
            while (dataReader.Read())
            {
                Alert tempAlert = new Alert();
                tempAlert.user_id = Convert.ToInt32(dataReader["user_id"]);
                tempAlert.alert_time = Convert.ToString(dataReader["alert_time"]);
                tempAlert.temp = Convert.ToInt32(dataReader["temp"]);
                tempAlert.humidity = Convert.ToInt32(dataReader["humidity"]);
                tempAlert.precipitation = Convert.ToInt32(dataReader["precipitation"]);
                tempAlert.wind = Convert.ToInt32(dataReader["wind"]);
                tempAlert.uv = Convert.ToInt32(dataReader["uv"]);
                tempAlert.phone = Convert.ToString(dataReader["phone"]);
                tempAlert.city = Convert.ToString(dataReader["city_name"]);
                tempAlert.stateCode = Convert.ToString(dataReader["state_code"]);
                tempAlert.countryCode = Convert.ToString(dataReader["country_code"]);
                alertList.Add(tempAlert);
            }
            conn.Close();
            return alertList;
        }
    }
}
