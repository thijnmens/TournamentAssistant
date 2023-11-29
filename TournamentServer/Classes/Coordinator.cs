using TournamentServer.Services;
using TaUtilities.Interfaces;
using WebSocketSharp.Server;

namespace TournamentServer.Classes
{
	public class Coordinator : IUser
	{
		public Coordinator(string username, WebSocketBehavior connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public WebSocketBehavior Connection { get; }

		public override string ToString()
		{
			return Username;
		}
	}
}