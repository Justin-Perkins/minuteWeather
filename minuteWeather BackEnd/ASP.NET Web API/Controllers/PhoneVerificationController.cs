using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;
using Microsoft.AspNetCore.Mvc;

namespace minuteWeather_BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class PhoneVerificationController : ControllerBase
{
    static string? accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
    static string? authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

    private readonly ILogger<PhoneVerificationController> _logger;

    public PhoneVerificationController(ILogger<PhoneVerificationController> logger)
    {
        _logger = logger;
    }

    /* send a SMS verification code */
    [NonAction]
    public static void sendPhoneNumberVerification(string phoneNumber)
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
        }
        catch (Twilio.Exceptions.ApiException)
        {

        }
    }

    /* Check if the user has validated their phone number */
    [NonAction]
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
            return verificationCheck.Status == "approved";
        }
        catch (Twilio.Exceptions.ApiException)
        {
            return false;
        }
    }

    [HttpGet]
    [Route("VerifyPhoneNumber")]
    public bool VerifyPhoneNumber([FromQuery] string phoneNumber, string verificationCode)
    {
        bool status = phoneNumberVerificationCheck(phoneNumber, verificationCode);
        
        return status;
    } 

    [HttpPost]
    [Route("SendVerification")]
    public void SendVerification([FromQuery] string phoneNumber)
    {
        sendPhoneNumberVerification(phoneNumber);
    }
}