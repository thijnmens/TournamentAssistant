using System.Net;
using WebSocketSharp.Server;

namespace TournamentServer
{
	public class Websocket
	{

		public IPAddress IPAddress { get; }
		public int Port { get; }

		public Websocket(string ip = "127.0.0.1:8080")
		{
			var ws = new WebSocketServer($"ws://{ip}");

			ws.AddWebSocketService<MessageHandler>("/");

			ws.Start();
			IPAddress = ws.Address;
			Port = ws.Port;
		}
	}
}