using System.Collections.Generic;
using TaUtilities.Interfaces;

namespace TournamentServer.Classes
{
	public class Lobby
	{
		public int LobbyCode { get; }
		public List<IUser> Users { get; }

		public Lobby(int lobbyCode, List<IUser> users)
		{
			LobbyCode = lobbyCode;
			Users = users;
		}
	}
}