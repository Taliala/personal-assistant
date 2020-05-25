using System;
using Twilio.Types;
using Twilio.Rest.Lookups.V1;
using System.Threading.Tasks;

namespace PersonalAssistant.Services.Sms
{
	public static class TwilioHelper
	{
		public async static Task<bool> VerifyPhoneNumberAsync(PhoneNumber phoneNumber)
		{
			try
			{
				// Verify phone number
				await PhoneNumberResource.FetchAsync(
					countryCode: "US",
					pathPhoneNumber: phoneNumber
					);

				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}

