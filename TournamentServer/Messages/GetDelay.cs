using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TaUtilities;
using TournamentServer.Classes;
using TournamentServer.Services;

namespace TournamentServer.Messages
{
	public static class GetDelay
	{
		public static void Incoming(MainService mainService)
		{
			foreach (var connection in Server.Websocket.Connections.Where(connection => connection.Value.User.GetType() == typeof(Player)))
			{
				Outgoing(connection.Value.User.Connection);
			}
		}

		public static void Outgoing(MainService mainService)
		{
			mainService.SendMessage(Message.GET_DELAY);
		}
	}
}
