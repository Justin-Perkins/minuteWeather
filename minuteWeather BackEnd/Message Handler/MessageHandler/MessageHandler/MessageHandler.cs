using OpenWeatherAPI;
using SendTextMessage;

class MessageHandler
{
    static string? phoneNumber;
    static string? message;
    static string? verificationCode;
    static string? userInput = "-1";

    static async Task Main(string[] args)
    {

        // Look at this later https://www.nuget.org/packages/libphonenumber-csharp/
        // and this https://github.com/twcclegg/libphonenumber-csharp

        while (Convert.ToInt32(userInput) != 0)
        {
            Console.WriteLine("Twilio API for minuteWeather");
            Console.WriteLine("1) Send a SMS message");
            Console.WriteLine("2) Send a SMS verification code");
            Console.WriteLine("3) Validate a SMS verification code");
            Console.WriteLine("4) Get weather data");
            Console.WriteLine("5) Exit");
            userInput = Console.ReadLine();


            switch (Convert.ToInt32(userInput))
            {
                case 1:
                    Console.WriteLine("Input a phone number");
                    phoneNumber = Console.ReadLine();
                    Console.WriteLine("Input a message to send");
                    message = Console.ReadLine();
                    if (phoneNumber == null || message == null)
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                    TwilioAPI.sendSmsMessage(phoneNumber, message);

                    break;
                case 2:
                    Console.WriteLine("Input a phone number");
                    phoneNumber = Console.ReadLine();
                    if (phoneNumber == null)
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                    TwilioAPI.sendPhoneNumberVerification(phoneNumber);

                    break;
                case 3:
                    Console.WriteLine("Input the phone number to be verified");
                    phoneNumber = Console.ReadLine();
                    Console.WriteLine("Input the verification code");
                    verificationCode = Console.ReadLine();
                    if (phoneNumber == null || verificationCode == null)
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
                    TwilioAPI.phoneNumberVerificationCheck(phoneNumber, verificationCode);

                    break;
                case 4:
                    var city = await WeatherAPI.getCityData("Hooksett", "US-NH", "3166-2:US");

                    if (city == null)
                    {
                        Console.WriteLine("City coordinates could not be retrieved");
                        return;
                    }

                    Console.WriteLine("City Country: " + city.getCountry());
                    Console.WriteLine("City State: " + city.getState());
                    Console.WriteLine("City Name: " + city.getName());
                    Console.WriteLine("City latitude: " + city.getLatitude());
                    Console.WriteLine("City longitude: " + city.getLongitude() + "\n");

                    if (city.getLatitude() == null || city.getLongitude() == null)
                    {
                        Console.WriteLine("City coordinates could not be retrieved");
                        return;
                    }

                    var weatherData = await WeatherAPI.getWeatherData(city.getLatitude(), city.getLongitude());

                    if (weatherData == null)
                    {
                        Console.WriteLine("Failed to get the weather data, do you have internet?");
                        return;
                    }

                    Console.WriteLine("City latitude: " + weatherData.getLatitude());
                    Console.WriteLine("City longitude: " + weatherData.getLongitude());
                    Console.WriteLine("Current weather: " + weatherData.getCurrentWeather());
                    Console.WriteLine("Current weather description: " + weatherData.getCurrentWeatherDescription());
                    Console.WriteLine("Current temperature: " + weatherData.getCurrentTemperature());
                    Console.WriteLine("Current feels like temperature: " + weatherData.getFeelsLikeTemperature());
                    Console.WriteLine("Minimum temperature: " + weatherData.getMinimumTemperature());
                    Console.WriteLine("Maximum temperature: " + weatherData.getMaximumTemperature());
                    Console.WriteLine("Current pressure: " + weatherData.getPressure());
                    Console.WriteLine("Current humidity: " + weatherData.getHumidity());
                    Console.WriteLine("Current visibility: " + weatherData.getVisibility());
                    Console.WriteLine("Current wind speed: " + weatherData.getWindSpeed());
                    Console.WriteLine("Current wind degree: " + weatherData.getWindDegree());
                    break;
                case 5:
                    userInput = "0";
                    break;
            

                default:
                    break;
            }
        }
    }
}
