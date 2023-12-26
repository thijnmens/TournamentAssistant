using Steamworks;

namespace TournamentAssistant.Messages
{
	public static class Connected
	{
		public static void Incoming(string url, int lobbyCode)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Successfully joined {url} with username '{SteamFriends.GetPersonaName()}'");
			JoinLobby.Outgoing(lobbyCode);
		}
	}
}
