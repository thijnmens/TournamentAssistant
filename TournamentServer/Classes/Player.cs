using System;

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
			throw new NotImplementedException();
		}
	}
}