using TournamentServer.Routes;
using WebSocketSharp.Server;

namespace TournamentServer
{
	public class Websocket
	{
		public Websocket(string ip, string port)
		{
			Server = new WebSocketServer($"ws://{ip}:{port}");

			Server.AddWebSocketService<MainRoute>("/");

			Server.Start();

			IpAddress = Server.Address.ToString();
			Port = Server.Port.ToString();
		}

		private WebSocketServer Server { get; }

		public string IpAddress { get; }
		public string Port { get; }
	}
}
