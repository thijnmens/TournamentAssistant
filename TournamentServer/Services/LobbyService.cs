using System;
using System.Collections.Generic;
using System.Linq;
using TaUtilities.Packets;
using TournamentServer.Classes;

namespace TournamentServer.Services
{
	public static class LobbyService
	{
		public static Dictionary<int, Lobby> Lobbies { get; } = new Dictionary<int, Lobby>();

		public static int CreateLobby(CreateLobbyPacket packet)
		{
			var lobbyCode = GenerateLobbyCode();
			var lobby = new Lobby(lobbyCode, packet.Data.Password, packet.Username);
			Lobbies.Add(lobbyCode, lobby);
			return lobbyCode;
		}

		public static bool RemoveLobby(RemoveLobbyPacket packet)
		{
			var lobby = GetLobbyByCode(packet.Data.LobbyCode);
			if (lobby.Owner != packet.Username || lobby.Password != packet.Data.Password) return false; // Request is not from lobby owner

			lobby.Close();
			return true;
		}

		private static int GenerateLobbyCode()
		{
			var lobbyCode = new Random().Next(10000, 99999);

			if (Lobbies.ContainsKey(lobbyCode))
				lobbyCode = GenerateLobbyCode();

			return lobbyCode;
		}

		private static Lobby GetLobbyByCode(int lobbyCode)
		{
			return Lobbies.First(kvp => kvp.Key == lobbyCode).Value;
		}
	}
}