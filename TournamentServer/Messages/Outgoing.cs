using Messages;

namespace TournamentServer.Messages
{
	public static class Outgoing
	{
		public static void Pong()
		{
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

		public static void UnknownMessage(string message)
		{
			MessageHandler.SendAsync(Message.UNKNOWN_MESSAGE);
		}
	}
}