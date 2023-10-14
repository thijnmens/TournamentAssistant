using Messages;
using TournamentServer.Handlers;

namespace TournamentServer.Classes
{
	public class Player
	{
		public string Username { get; private set; }

		public Player(string username)
		{
			Username = username;
		}

		public void Kick()
		{
			MessageHandler.Instance.SendMessage(Message.KICK);
		}
	}
}