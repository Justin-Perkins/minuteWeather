using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace SendTextMessage
{
    public static class TwilioAPI
    {
        static string? accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        static string? authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");


        /* Send a SMS message using the Twilio API */
        public static bool sendSmsMessage(string sendToPhoneNumber, string sendMessage)
        {
            TwilioClient.Init(accountSid, authToken);
            try
            {
                var message = MessageResource.Create(
                    body: sendMessage,
                    from: new PhoneNumber(Environment.GetEnvironmentVariable("TWILIO_PHONE_NUMBER")),
                    to: new PhoneNumber(sendToPhoneNumber)
                );
                Console.WriteLine(message.Sid);
                return true;
            }
            catch (Twilio.Exceptions.ApiException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(sendToPhoneNumber + " is not a valid phone number");
                return false;
            }
        }


        /* send a SMS verification code */
        public static bool sendPhoneNumberVerification(string phoneNumber)
        {

            if (!phoneNumber.StartsWith("+1"))
            {
                phoneNumber = "+1" + phoneNumber;
            }

            TwilioClient.Init(accountSid, authToken);
            try
            {
                var verification = VerificationResource.Create(
                    to: phoneNumber,
                    channel: "sms",
                    pathServiceSid: Environment.GetEnvironmentVariable("TWILIO_SERVICE_SID")
                );
                Console.WriteLine(verification.Status);
                return true;
            }
            catch (Twilio.Exceptions.ApiException)
            {
                Console.WriteLine("Invalid input, make sure to add the country code at the start (+1)");
                return false;
            }
        }


        /* Check if the user has validated their phone number */
        public static bool phoneNumberVerificationCheck(string phoneNumber, string verificationCode)
        {
            if (!phoneNumber.StartsWith("+1"))
            {
                phoneNumber = "+1" + phoneNumber;
            }

            TwilioClient.Init(accountSid, authToken);
            try
            {
                var verificationCheck = VerificationCheckResource.Create(
                    to: phoneNumber,
                    code: verificationCode,
                    pathServiceSid: Environment.GetEnvironmentVariable("TWILIO_SERVICE_SID")
                );
                Console.WriteLine(verificationCheck.Status);
                return true;
            }
            catch (Twilio.Exceptions.ApiException)
            {
                Console.WriteLine("Invalid input, make sure to add the country code at the start (+1)");
                return false;
            }
        }
    }
}
