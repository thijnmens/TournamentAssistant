using System;
using System.Diagnostics;
using System.Reflection;
using Messages;
using Steamworks;
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

			Ws.Connect();
			SendMessage(Message.NEW_CONNECTION);

			Ws.OnMessage += OnMessage;
		}

		private void OnMessage(object sender, MessageEventArgs messageEventArgs)
		{
			var messageType = messageEventArgs.Data.Split(':')[0];
			var arg = messageEventArgs.Data.Split(new[] { ':' }, 2)[1];

			if (Enum.TryParse(messageType, out Message message)) SendMessage(Message.UNKNOWN_MESSAGE);
			
			switch (message)
			{
				// Messages with response
				case Message.PING:
				case Message.VERSION:
				case Message.CLOSE_CONNECTION:
				case Message.PLAYER_INFO:
				case Message.KICK:
					SendMessage(message);
					return;
				
				// Messages without response
				case Message.CONNECTION_ACCEPTED:
					TournamentAssistant.ModEntry.Logger.Log($"Successfully connected to {Ws.Url}");
					return;
				
				// Unused messages
				case Message.NEW_LOBBY:
				case Message.NEW_CONNECTION:
					SendMessage(Message.UNUSED_MESSAGE);
					return;

				// Error messages
				case Message.UNUSED_MESSAGE:
				case Message.UNKNOWN_MESSAGE:
				default:
					TournamentAssistant.ModEntry.Logger.Error($"Unknown message:'{messageEventArgs.Data}'");
					return;
			}
		}

		public void OnApplicationQuit()
		{
			SendMessage(Message.CLOSE_CONNECTION);
			Ws.Close();
		}

		private void SendMessage(Message message, string arg = "")
		{
			switch (message)
			{
				case Message.NEW_CONNECTION:
					Send($"NEW_CONNECTION:{SteamFriends.GetPersonaName()}");
					return;

				case Message.CLOSE_CONNECTION:
					Send($"CLOSE_CONNECTION:{SteamFriends.GetPersonaName()}");
					return;

				case Message.KICK:
					SendMessage(Message.CLOSE_CONNECTION);
					Ws.Close();
					return;
				
				case Message.PLAYER_INFO:
					
					return;

				case Message.PING:
					return;
				
					return;
				
				case Message.VERSION:
					Send(FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(TournamentAssistant)).Location).FileVersion);
					return;
				
				case Message.NEW_LOBBY:
				case Message.CONNECTION_ACCEPTED:
				case Message.UNUSED_MESSAGE:
					return;
				
				case Message.UNKNOWN_MESSAGE:
				default:
					Send($"UNKNOWN_MESSAGE:{arg}");
					return;
			}
		}

		private void Send(string message)
		{
			Ws.SendAsync(message, _ => { });
		}
	}
}