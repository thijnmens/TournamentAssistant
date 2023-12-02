using System;
using TaUtilities;
using TaUtilities.Interfaces;
using TournamentServer.Services;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TournamentServer.Routes
{
	public class MainRoute : WebSocketBehavior, IRoute
	{
		public void SendMessage(IPacket packet)
		{
			SendAsync(packet.ToJson(), _ => { });
		}

		public void SendMessage(IPacket packet, Action<bool> callback)
		{
			SendAsync(packet.ToJson(), callback);
		}

		protected override void OnMessage(MessageEventArgs e)
		{
			base.OnMessage(e);

			if (e.IsPing)
				return;

			switch (PacketConverter.GetMessageType(e.Data))
			{
				case MessageType.UNKNOWN_MESSAGE:
					MessageService.UnknownMessage(e.Data);
					return;

				case MessageType.OPERATION_FAILED:
					MessageService.OperationFailed(e.Data);
					return;

				case MessageType.CREATE_LOBBY:
					SendMessage(MessageService.CreateLobby(e.Data));
					return;

				case MessageType.REMOVE_LOBBY:
					SendMessage(MessageService.RemoveLobby(e.Data));
					return;

				case MessageType.JOIN_LOBBY:
					SendMessage(MessageService.JoinLobby(e.Data, this));
					return;

				case MessageType.LEAVE_LOBBY:
					SendMessage(MessageService.LeaveLobby(e.Data));
					return;

				case MessageType.KICK_PLAYER:
					SendMessage(MessageService.KickPlayer(e.Data));
					return;

				case MessageType.START_DOWNLOAD:
					SendMessage(MessageService.DownloadMap(e.Data));
					return;

				case MessageType.DOWNLOAD_FINISHED:
					MessageService.DownloadFinished(e.Data);
					return;

				case MessageType.DOWNLOAD_STATUS:
					SendMessage(MessageService.DownloadStatus(e.Data));
					return;

				case MessageType.DOWNLOADS_FINISHED:
				case MessageType.DOWNLOAD_FILE:
				case MessageType.DOWNLOAD_STARTED:
				case MessageType.LOBBY_CREATED:
				case MessageType.LOBBY_REMOVED:
				case MessageType.LOBBY_JOINED:
				case MessageType.LOBBY_LEFT:
				case MessageType.PLAYER_KICKED:
				default:
					SendMessage(PacketCreator.UnknownMessagePacket(e.Data));
					return;
			}
		}
	}
}
