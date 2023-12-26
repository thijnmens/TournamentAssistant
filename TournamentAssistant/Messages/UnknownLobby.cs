using Newtonsoft.Json;

namespace TournamentAssistant.Messages
{
	public static class UnknownLobby
	{
		public static void Incoming(UnknownLobbyRequest request)
		{
			TournamentAssistant.ModEntry.Logger.Error($"Failed to join lobby with code '{request.LobbyCode}', did you make a typo?");
		}
	}

	public class UnknownLobbyRequest
	{
		[JsonProperty("lobbyCode")]
		public int LobbyCode;
	}
}
