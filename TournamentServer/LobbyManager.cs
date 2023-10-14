using System;
using System.Collections.Generic;
using System.Linq;
using TournamentServer.Classes;

namespace TournamentServer
{
	public static class LobbyManager
	{
		public static Dictionary<int, Lobby> Lobbies { get; } = new Dictionary<int, Lobby>();

		public static Lobby CreateNewLobby()
		{
			var code = new Random().Next(10000, 99999);
			var lobby = Lobbies.Keys.Contains(code) ? CreateNewLobby() : new Lobby(code);
			Lobbies.Add(code, lobby);
			return lobby;
		}
	}
}