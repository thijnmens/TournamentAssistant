using System;
using System.Collections.Generic;
using System.Linq;
using TaUtilities;
using TaUtilities.Interfaces;
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

			if (!lobby.IsAuthorized(packet.Username, packet.Data.Password))
				return false;

			lobby.Close();
			return true;
		}

		public static bool JoinLobby(JoinLobbyPacket packet, IRoute connection)
		{
			var lobby = GetLobbyByCode(packet.Data.LobbyCode);
			IUser user;
			if (packet.ApplicationType == ApplicationType.APP)
			{
				user = new Coordinator(packet.Username, connection);
			}
			else
			{
				user = new Player(packet.Username, connection);
			}

			return lobby.Join(user);
		}

		public static bool LeaveLobby(LeaveLobbyPacket packet)
		{
			var lobby = GetLobbyByCode(packet.Data.LobbyCode);
			return lobby.Leave(packet.Username);
		}

		public static bool KickPlayer(KickPlayerPacket packet)
		{
			var lobby = GetLobbyByCode(packet.Data.LobbyCode);

			return lobby.IsAuthorized(packet.Username, packet.Data.Password) && lobby.Leave(packet.Data.Username);
		}

		private static int GenerateLobbyCode()
		{
			var lobbyCode = new Random().Next(10000, 99999);

			if (Lobbies.ContainsKey(lobbyCode))
				lobbyCode = GenerateLobbyCode();

			return lobbyCode;
		}

		public static Lobby GetLobbyByCode(int lobbyCode)
		{
			return Lobbies.First(kvp => kvp.Key == lobbyCode).Value;
		}
	}
}
