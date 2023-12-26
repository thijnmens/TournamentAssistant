using Newtonsoft.Json;
using TaUtilities;

namespace TournamentAssistant.Messages
{
	public static class UnknownMessage
	{
		public static void Incoming(UnknownMessageRequest request)
		{
			TournamentAssistant.ModEntry.Logger.Error("Mod sent an unknown message to the server");
			TournamentAssistant.ModEntry.Logger.Error($"Message copy: '{request.Message}'");
		}

		public static void Outgoing(string message)
		{
			var unknownMessageResponse = new UnknownMessageResponse(message);
			TournamentAssistant.Connection?.SendMessage(MessageType.UNKNOWN_MESSAGE, PacketConverter.Convert(unknownMessageResponse));
		}
	}

	public class UnknownMessageResponse
	{
		[JsonProperty("message")]
		public string Message;

		public UnknownMessageResponse(string message)
		{
			Message = message;
		}
	}

	public class UnknownMessageRequest
	{
		[JsonProperty("message")]
		public string Message;
	}
}
