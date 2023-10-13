using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using WebSocketSharp;

namespace TournamentAssistant
{
	public class Connection
	{

		private WebSocket Ws { get; }

		public Connection(string url)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Attempting to join {url}");
			Ws = new WebSocket($"ws://{url}");

			string localIP;
			using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
			{
				socket.Connect("8.8.8.8", 65530);
				var endPoint = socket.LocalEndPoint as IPEndPoint;
				localIP = endPoint?.Address.ToString();
			}

			Ws.Connect();
			Ws.SendAsync($"NEW_CONNECTION: new connection from {localIP}", _ => { });

			Ws.OnMessage += OnMessage;
		}

		~Connection()
		{
			Ws.Close();
		}

		private void OnMessage(object sender, MessageEventArgs messageEventArgs)
		{
			switch (messageEventArgs.Data.Split(':')[0])
			{
				case "PING":
					Ws.SendAsync("pong!", b => { });
					break;

				case "VERSION":
					Ws.SendAsync(
						FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(TournamentAssistant)).Location)
							.FileVersion,
						b => { });
					break;
				
				case "CONNECTION_ACCEPTED":
					TournamentAssistant.ModEntry.Logger.Log($"Successfully connected to {Ws.Url}");
					break;

				default:
					TournamentAssistant.ModEntry.Logger.Error($"Unknown message: {messageEventArgs.Data}");
					throw new ArgumentException($"Unknown message: {messageEventArgs.Data}");
			}
		}
	}
}