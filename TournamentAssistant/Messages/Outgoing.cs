using System;
using Messages;
using Steamworks;

namespace TournamentAssistant.Messages
{
	public static class Outgoing
	{
		public static void Pong()
		{
		}

		public static void NewConnection()
		{
			MessageHandler.SendAsync(Message.NEW_CONNECTION, SteamFriends.GetPersonaName());
		}

		public static void ConnectionAccepted()
		{
		}

		public static void CloseConnection()
		{
		}

		public static void ConnectionClosed()
		{
		}

		public static void LobbyCreated()
		{
		}

		public static void LobbyDeleted()
		{
		}

		public static void GetPlayerInfo()
		{
		}

		public static void PlayerInfo()
		{
		}

		public static void Version()
		{
		}

		public static void Kick()
		{
		}

		public static void UnknownMessage()
		{
			throw new NotImplementedException();
		}
	}
}