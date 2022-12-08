

namespace MessageHandler
{
    /* Store data about a users location */
    internal class City
    {
        string name;
        string latitude;
        string longitute;
        string country;
        string state;

        public City(dynamic cityJson)
        {
            name = cityJson[0]["name"];
            latitude = cityJson[0]["lat"];
            longitute = cityJson[0]["lon"];
            country = cityJson[0]["country"];
            state = cityJson[0]["state"];
        }

        public string getName()
        {
            return name;
        }

        public string getLatitude()
        {
            return latitude;
        }

        public string getLongitude()
        {
            return longitute;
        }

        public string getCountry()
        {
            return country;
        }

        public string getState()
        {
            return state;
        }
    }
}
