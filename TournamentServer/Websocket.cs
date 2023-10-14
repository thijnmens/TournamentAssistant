using System.Net;
using TournamentServer.Routes;
using WebSocketSharp.Server;

namespace TournamentServer
{
	public class Websocket
	{

		public IPAddress IPAddress { get; }
		public int Port { get; }

		public Websocket(string ip)
		{
			var ws = new WebSocketServer($"ws://{ip}");

			ws.AddWebSocketService<MainRoute>("/");

			ws.Start();
			IPAddress = ws.Address;
			Port = ws.Port;
		}
	}
}