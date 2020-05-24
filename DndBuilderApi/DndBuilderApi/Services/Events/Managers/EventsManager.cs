using System;
using System.Threading.Tasks;
using PersonalAssistant.Services.Sms.Domain;
using PersonalAssistant.Services.Sms;

namespace PersonalAssistant.Services.Events.Managers
{
	public class EventsManager : IEventsManager
	{
		private readonly ISmsService _smsService;

		public EventsManager(ISmsService smsService)
		{
			_smsService = smsService;
		}

		/// <inheritdoc />
		public async Task<Guid> InsertEventAsync(SendSmsDto dto)
		{
			return await _smsService.SendSmsAsync(dto);
		}
	}
}

