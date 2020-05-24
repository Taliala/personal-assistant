using System;
using System.Threading.Tasks;
using PersonalAssistant.Services.Sms.Domain;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio;
using Microsoft.Extensions.Configuration;

namespace PersonalAssistant.Services.Sms
{
	public class SmsService : ISmsService
	{
		private readonly IConfiguration _configuration;
		public SmsService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		/// <inheritdoc />
		public async Task<Guid> SendSmsAsync(SendSmsDto dto)
		{
			var accountSid = _configuration["Twilio:AccountSid"];
			var authToken = _configuration["Twilio:AuthToken"];
			TwilioClient.Init(accountSid, authToken);

			var phoneNumber = new PhoneNumber(dto.PhoneNumber);
			if (!await TwilioHelper.VerifyPhoneNumberAsync(phoneNumber))
			{
				// TODO Use ReturnResult class
				return new Guid();
			}

			var messageOptions = new CreateMessageOptions(phoneNumber);
			messageOptions.From = new PhoneNumber("+12073863924"); // TODO Store in config after setting up twilio account
			messageOptions.Body = dto.Message;

			MessageResource.Create(messageOptions);

			return Guid.NewGuid();
		}		
	}
}

