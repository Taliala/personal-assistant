using PersonalAssistant.Services.Sms.Domain;
using System;
using System.Threading.Tasks;

namespace PersonalAssistant.Services.Events.Managers
{
	public interface IEventsManager
	{
		/// <summary>
		/// Save an event
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		Task<Guid> InsertEventAsync(SendSmsDto dto);
	}
}

