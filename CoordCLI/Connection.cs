using System;
using TaUtilities;
using TaUtilities.Interfaces;
using WebSocketSharp;

namespace CoordCLI
{
	public class Connection
	{
		public Connection(string ip, string port)
		{
			Ws = new WebSocket($"ws://{ip}:{port}");

			Ws.ConnectAsync();

			Ws.OnMessage += OnMessage;
			Ws.OnOpen += (sender, args) =>
			{
				Program.WriteInfo("Connected!");
			};
		}

		private WebSocket Ws { get; }

		public int LobbyCode { get; set; }

		private void OnMessage(object sender, MessageEventArgs e)
		{
			if (e.IsPing)
				return;

			var messageType = PacketConverter.GetMessageType(e.Data);

			switch (messageType)
			{
				case MessageType.UNKNOWN_MESSAGE:
					MessageService.UnknownMessage(e.Data);
					return;

				case MessageType.OPERATION_FAILED:
					MessageService.OperationFailed(e.Data);
					return;

				case MessageType.LOBBY_JOINED:
					MessageService.LobbyJoined();
					return;

				case MessageType.LOBBY_LEFT:
					MessageService.LobbyLeft();
					return;

				case MessageType.DOWNLOAD_FILE:
					MessageService.DownloadFile(e.Data, this);
					return;

				case MessageType.LOBBY_CREATED:
					MessageService.LobbyCreated(e.Data);
					return;

				case MessageType.LOBBY_REMOVED:
					MessageService.LobbyRemoved();
					return;

				case MessageType.PLAYER_KICKED:
					MessageService.PlayerKicked();
					return;

				case MessageType.DOWNLOADS_FINISHED:
					MessageService.DownloadsFinished(e.Data);
					return;

				case MessageType.CREATE_LOBBY:
				case MessageType.REMOVE_LOBBY:
				case MessageType.JOIN_LOBBY:
				case MessageType.LEAVE_LOBBY:
				case MessageType.KICK_PLAYER:
				case MessageType.START_DOWNLOAD:
				case MessageType.DOWNLOAD_FINISHED:
				case MessageType.DOWNLOAD_STATUS:
				default:
					SendMessage(PacketCreator.UnknownMessagePacket(e.Data));
					return;
			}
		}

		public void SendMessage(IPacket packet)
		{
			Ws.SendAsync(packet.ToJson(), _ => { });
		}

		public void SendMessage(IPacket packet, Action<bool> callback)
		{
			Ws.SendAsync(packet.ToJson(), callback);
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
