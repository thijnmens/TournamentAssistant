using System.Collections.Generic;
using System.Linq;

namespace TournamentServer.Classes
{
	public class Lobby
	{
		private List<Player> Players { get; }
		public int Code { get; }

		public Lobby(int code)
		{
			Code = code;
			Players = new List<Player>();
		}

		public void KickPlayer(string username)
		{
			var player = Players.First(p => p.Username == username);
			player.Kick();
		}

		public void JoinLobby(Player player)
		{
			Players.Add(player);
		}
	}
}