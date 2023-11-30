using TaUtilities.Interfaces;
using WebSocketSharp.Server;

namespace TournamentServer.Classes
{
	public class Player : IUser
	{
		public string Username { get; }
		public IRoute Connection { get; }

		public Player(string username, IRoute connection)
		{
			Username = username;
			Connection = connection;
		}
	}
}
