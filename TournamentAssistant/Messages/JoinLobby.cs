using Newtonsoft.Json;
using TaUtilities;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentAssistant.Messages
{
	public static class JoinLobby
	{
		public static void Outgoing(int lobbyCode)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Attempting to join lobby with code '{lobbyCode}'");
			var joinLobbyResponse = new JoinLobbyResponse(lobbyCode);
			TournamentAssistant.Connection?.SendMessage(Message.JOIN_LOBBY, JsonConverter.Convert(joinLobbyResponse));
		}

		private class JoinLobbyResponse
		{
			[JsonProperty("lobbyCode")] public int LobbyCode;

			public JoinLobbyResponse(int lobbyCode)
			{
				LobbyCode = lobbyCode;
			}
		}
	}
}