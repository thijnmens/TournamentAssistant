using TournamentServer.Services;

namespace TournamentServer.Classes
{
	public class Lobby
	{
		public int LobbyCode { get; }
		public string Password { get; }
		public string Owner { get; }

		public Lobby(int lobbyCode, string password, string owner)
		{
			LobbyCode = lobbyCode;
			Password = password;
			Owner = owner;
		}

		public void Close()
		{
			LobbyService.Lobbies.Remove(LobbyCode);
		}
	}
}