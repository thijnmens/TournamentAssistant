using TaUtilities.Interfaces;

namespace TournamentServer.Classes
{
	public class Coordinator : IUser
	{
		public Coordinator(string username, IRoute connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public IRoute Connection { get; }
	}
}
