using System;

namespace PersonalAssistant.Services.Sms.Domain
{
    public class SendSmsDto
    {
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
    }
}


