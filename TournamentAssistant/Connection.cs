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
			var messageType = splitMessage.First().Trim();
			var data = splitMessage.Last().Trim();

			var message = (Message)Enum.Parse(typeof(Message), messageType);

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
				case Message.DOWNLOAD_MAP:
					DownloadMap.Incoming(JsonConverter.Convert<DownloadMapRequest>(data));
					return;
				case Message.OPERATION_FAILED:
					OperationFailed.Incoming(JsonConverter.Convert<OperationFailedRequest>(data));
					return;
				case Message.GET_DELAY:
					GetDelay.Incoming();
					break;
				case Message.DELAY_STATUS:
					DelayStatus.Incoming(JsonConverter.Convert<DelayStatusRequest>(data));
					break;
				case Message.JOIN_LOBBY:
				case Message.MAP_DOWNLOADED:
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

		public void OnApplicationQuit(Action callback)
		{
			Ws.Close();
			callback();
		}
	}
}