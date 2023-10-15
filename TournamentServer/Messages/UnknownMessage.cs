using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class UnknownMessage
	{
		public static void Incoming(UnknownMessageRequest request)
		{
			Server.WriteError("Server sent an unknown message to a user");
			Server.WriteError($"Message copy: '{request.Message}'");
		}

		public static void Outgoing(MainService mainService, string message)
		{
			var unknownMessageResponse = new UnknownMessageResponse(message);
			mainService.SendMessage(Message.UNKNOWN_MESSAGE, JsonConverter.Convert(unknownMessageResponse));
		}
	}

	public class UnknownMessageResponse
	{
		[JsonProperty("message")] public string Message;

		public UnknownMessageResponse(string message)
		{
			Message = message;
		}
	}

	public class UnknownMessageRequest
	{
		[JsonProperty("message")] public string Message;
	}
}