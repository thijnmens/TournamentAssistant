using TaUtilities.Interfaces;

namespace TournamentServer.Classes
{
	public class Player : IUser
	{
		public Player(string username, IRoute connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public IRoute Connection { get; }
	}
}
