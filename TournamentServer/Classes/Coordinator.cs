using TaUtilities.Interfaces;
using WebSocketSharp.Server;

namespace TournamentServer.Classes
{
	public class Coordinator : IUser
	{
		public string Username { get; }
		public IRoute Connection { get; }

		public Coordinator(string username, IRoute connection)
		{
			Username = username;
			Connection = connection;
		}
	}
}
