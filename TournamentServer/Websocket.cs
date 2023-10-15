using System.Collections.Generic;
using TournamentServer.Classes;
using TournamentServer.Services;
using WebSocketSharp.Server;

namespace TournamentServer
{
	public class Websocket
	{

		private WebSocketServer Server { get; }
		public string IpAddress { get; private set; }
		public string Port { get; private set; }
		public Dictionary<string, MainService> Connections { get; private set; }
		public Dictionary<int, Lobby> Lobbies { get; private set; }

		public Websocket(string ip, string port)
		{
			Server = new WebSocketServer($"ws://{ip}:{port}");

			Server.AddWebSocketService<MainService>("/");

			Server.Start();

			IpAddress = Server.Address.ToString();
			Port = Server.Port.ToString();
			Connections = new Dictionary<string, MainService>();
			Lobbies = new Dictionary<int, Lobby>();
		}
	}
}