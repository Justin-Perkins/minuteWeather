using SendTextMessage;

class MessageHandler
{
    static string? phoneNumber;
    static string? message;
    static string? verificationCode;
    static string? userInput = "-1";

    static void Main(string[] args)
    {

        // Look at this later https://www.nuget.org/packages/libphonenumber-csharp/
        // and this https://github.com/twcclegg/libphonenumber-csharp

        while (Convert.ToInt32(userInput) != 0)
        {
            Console.WriteLine("Twilio API for minuteWeather");
            Console.WriteLine("1) Send a SMS message");
            Console.WriteLine("2) Send a SMS verification code");
            Console.WriteLine("3) Validate a SMS verification code");
            Console.WriteLine("4) Exit");
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
                    userInput = "0";
                    break;

                default:
                    break;
            }
        }
    }
}
