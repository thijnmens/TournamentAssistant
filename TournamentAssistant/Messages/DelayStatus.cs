using Newtonsoft.Json;

namespace TournamentAssistant.Messages
{
	public static class DelayStatus
	{
		public static void Incoming(DelayStatusRequest request)
		{
			if (request.Delay < 0)
				TournamentAssistant.ModEntry.Logger.Warning("Coordinator was unable to find the popup, are you sharing your screen?");
			else
				TournamentAssistant.ModEntry.Logger.Log($"Delay measurement successful, delay: {request.Delay}ms");
			GetDelay.CloseForm();
		}
	}

	public class DelayStatusRequest
	{
		[JsonProperty("delay")]
		public int Delay;
	}
}
