using TournamentServer.Services;

namespace TournamentServer.Classes
{
	public class Coordinator : IUser
	{
		public Coordinator(string username, MainService connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public MainService Connection { get; }
	}
}