using Newtonsoft.Json;
using TaUtilities;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentAssistant.Messages
{
	public static class OperationFailed
	{
		public static void Incoming(OperationFailedRequest request)
		{
			TournamentAssistant.ModEntry.Logger.Error("The server was unable to process one of our messages");
			TournamentAssistant.ModEntry.Logger.Error($"Error message: '{request.Message}'");
		}

		public static void Outgoing(string message)
		{
			var operationFailedResponse = new OperationFailedResponse(message);
			TournamentAssistant.Connection?.SendMessage(Message.OPERATION_FAILED, JsonConverter.Convert(operationFailedResponse));
		}
	}

	public class OperationFailedResponse
	{
		[JsonProperty("message")] public string Message;

		public OperationFailedResponse(string message)
		{
			Message = message;
		}
	}

	public class OperationFailedRequest
	{
		[JsonProperty("message")] public string Message;
	}
}