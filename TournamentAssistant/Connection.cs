using System;
using System.Linq;
using Steamworks;
using TaUtilities;
using TournamentAssistant.Messages;
using WebSocketSharp;

namespace TournamentAssistant
{
	public class Connection
	{

		private WebSocket Ws { get; }

		private int LobbyCode { get; }

		public Connection(string url, int lobbyCode)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Attempting to join {url}?type=mod&username={SteamFriends.GetPersonaName()}");
			Ws = new WebSocket($"ws://{url}?type=mod&username={SteamFriends.GetPersonaName()}");
			LobbyCode = lobbyCode;

			Ws.ConnectAsync();

			Ws.OnMessage += OnMessage;
		}


		private void OnMessage(object sender, MessageEventArgs e)
		{
			var splitMessage = e.Data.Split(new[] { ':' }, 2);
			var messageType = splitMessage.First();
			var data = splitMessage.Last();

			if (Enum.TryParse(messageType, out Message message)) throw new ArgumentException();

			switch (message)
			{
				case Message.CONNECTED:
					Connected.Incoming(Ws.Url.ToString(), LobbyCode);
					return;
				case Message.JOINED_LOBBY:
					JoinedLobby.Incoming();
					return;
				case Message.USERNAME_TAKEN:
					UsernameTaken.Incoming(JsonConverter.Convert<UsernameTakenRequest>(data));
					return;
				case Message.UNKNOWN_MESSAGE:
					UnknownMessage.Incoming(JsonConverter.Convert<UnknownMessageRequest>(data));
					return;
				case Message.UNKNOWN_LOBBY:
					UnknownLobby.Incoming(JsonConverter.Convert<UnknownLobbyRequest>(data));
					return;
				case Message.JOIN_LOBBY:
				default:
					UnknownMessage.Outgoing(e.Data);
					return;
			}
		}

		public void SendMessage(Message message)
		{
			Ws.SendAsync(message.ToString(), _ => { });
		}

		public void SendMessage(Message message, Action<bool> callback)
		{
			Ws.SendAsync(message.ToString(), callback);
		}

		public void SendMessage(Message message, string data)
		{
			Ws.SendAsync($"{message.ToString()}:{data}", _ => { });
		}

		public void SendMessage(Message message, string data, Action<bool> callback)
		{
			Ws.SendAsync($"{message.ToString()}:{data}", callback);
		}

		public void OnApplicationQuit()
		{
			Ws.Close();
		}
	}
}