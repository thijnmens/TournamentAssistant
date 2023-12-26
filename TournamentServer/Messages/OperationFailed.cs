using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class OperationFailed
	{
		public static void Incoming(OperationFailedRequest request)
		{
			Server.WriteError("Mod/Client was unable to process a message from the server");
			Server.WriteError($"Error: '{request.Message}'");
		}

		public static void Outgoing(MainService mainService, string message)
		{
			var operationFailedResponse = new OperationFailedResponse(message);
			mainService.SendMessage(Message.OPERATION_FAILED, JsonConverter.Convert(operationFailedResponse));
		}
	}

	public class OperationFailedResponse
	{
		[JsonProperty("message")]
		public string Message;

		public OperationFailedResponse(string message)
		{
			Message = message;
		}
	}

	public class OperationFailedRequest
	{
		[JsonProperty("message")]
		public string Message;
	}
}
