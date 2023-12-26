using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class UnknownLobby
	{
		public static void Outgoing(MainService mainService, int lobbyCode)
		{
			var unknownLobbyResponse = new UnknownLobbyResponse(lobbyCode);
			mainService.SendMessage(Message.UNKNOWN_LOBBY, JsonConverter.Convert(unknownLobbyResponse));
		}
	}

	public class UnknownLobbyResponse
	{
		[JsonProperty("lobbyCode")]
		public int LobbyCode;

		public UnknownLobbyResponse(int lobbyCode)
		{
			LobbyCode = lobbyCode;
		}
	}
}
