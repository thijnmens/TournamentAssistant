using System.Linq;
using Newtonsoft.Json;
using TournamentServer.Services;

namespace TournamentServer.Messages
{
	public static class JoinLobby
	{
		public static void Incoming(MainService mainService, JoinLobbyRequest request)
		{
			if (!Server.Websocket.Lobbies.ContainsKey(request.LobbyCode))
			{
				UnknownLobby.Outgoing(mainService, request.LobbyCode);
				return;
			}

			Server.Websocket.Lobbies.First(lobby => lobby.Key == request.LobbyCode).Value.Users.Add(mainService.User);
			JoinedLobby.Outgoing(mainService);
		}
	}

	public class JoinLobbyRequest
	{
		[JsonProperty("lobbyCode")]
		public int LobbyCode;
	}
}
