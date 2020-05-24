using PersonalAssistant.Services.Sms.Domain;
using System;
using System.Threading.Tasks;

namespace PersonalAssistant.Services.Sms
{
	public interface ISmsService
	{
		/// <summary>
		/// Send an SMS
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		Task<Guid> SendSmsAsync(SendSmsDto dto);
	}
}

