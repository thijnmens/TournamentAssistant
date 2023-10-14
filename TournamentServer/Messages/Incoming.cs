using System;
using Messages;
using TournamentServer.Routes;
using static Crayon.Output;

namespace TournamentServer.Messages
{
	public static class Incoming
	{
		public static Action OnPong { get; set; } = null;

		public static void NewConnection(string username)
		{
			Server.Connections.Add(username);
			Server.WriteInfo($"New connection from {Underline(username)}");
			MessageHandler.SendAsync(Message.CONNECTION_ACCEPTED);
		}

		public static void CloseConnection(string username)
		{
			Server.WriteInfo($"Connection closed from {Underline(username)}");
			MessageHandler.SendAsync(Message.CONNECTION_CLOSED);
		}

		public static void Ping()
		{
			MessageHandler.SendAsync(Message.PONG);
		}

		public static void Pong()
		{
			if (OnPong != null) OnPong();
			else Console.WriteLine($"{Red("!")} {Bright.Red("Received pong without sending ping")}");
		}

		public static void GetPlayerInfo(string lobbyCode)
		{
			throw new NotImplementedException();
		}

		public static void PlayerInfo(string playerInfo)
		{
			throw new NotImplementedException();
		}

		public static void ConnectionClosed()
		{
			throw new NotImplementedException();
		}

		public static void Kick(string username, string lobbyCode)
		{
			throw new NotImplementedException();
		}

		public static void Version()
		{
			throw new NotImplementedException();
		}

		public static void CreateLobby(string username)
		{
			throw new NotImplementedException();
		}

		public static void DeleteLobby(string username, string lobbyCode)
		{
			throw new NotImplementedException();
		}

		public static void UnknownMessage()
		{
			throw new NotImplementedException();
		}

		public static void ConnectionAccepted()
		{
			throw new NotImplementedException();
		}
	}
}