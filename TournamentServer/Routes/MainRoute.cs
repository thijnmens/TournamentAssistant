using System;
using TaUtilities;
using TaUtilities.Interfaces;
using TaUtilities.Packets;
using TournamentServer.Services;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TournamentServer.Routes
{
	public class MainRoute : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs e)
		{
			if (e.IsPing)
				return;

			var messageType = PacketConverter.GetMessageType(e.Data);

			switch (messageType)
			{
				case MessageType.UNKNOWN_MESSAGE:
					var unknownMessagePacket = PacketConverter.Convert<UnknownMessagePacket>(e.Data);
					Server.WriteWarning($"Server send an unknown message to {unknownMessagePacket.Username}|{unknownMessagePacket.ApplicationType}: `{unknownMessagePacket.Data.ReceivedMessage}`");
					break;

				case MessageType.CREATE_LOBBY:
					var createLobbyPacket = PacketConverter.Convert<CreateLobbyPacket>(e.Data);
					var lobbyCode = LobbyService.CreateLobby(createLobbyPacket);
					var lobbyCreatedPacket = new LobbyCreatedPacket(lobbyCode);
					SendMessage(lobbyCreatedPacket);
					break;

				case MessageType.REMOVE_LOBBY:
					var removeLobbyPacket = PacketConverter.Convert<RemoveLobbyPacket>(e.Data);
					var lobbyRemoved = LobbyService.RemoveLobby(removeLobbyPacket);
					if (lobbyRemoved)
					{
						var lobbyRemovedPacket = new LobbyRemovedPacket();
						SendMessage(lobbyRemovedPacket);
					}
					else
					{
						var removeLobbyOperationFailedPacket = new OperationFailedPacket(e.Data);
						SendMessage(removeLobbyOperationFailedPacket);
					}
					break;

				case MessageType.OPERATION_FAILED:
					var operationFailedPacket = PacketConverter.Convert<OperationFailedPacket>(e.Data);
					Server.WriteError($"An operation failed for {operationFailedPacket.Username}|{operationFailedPacket.ApplicationType}: `{operationFailedPacket.Data.FailedOperationMessage}`");
					break;

				case MessageType.LOBBY_CREATED:
				case MessageType.LOBBY_REMOVED:
				default:
					var response = new UnknownMessagePacket(
						MessageType.UNKNOWN_MESSAGE,
						"SERVER",
						ApplicationType.SERVER,
						e.Data
					);
					SendMessage(response);
					break;
			}

			base.OnMessage(e);
		}

		public void SendMessage(IPacket packet)
		{
			SendAsync(packet.ToString(), _ => { });
		}

		public void SendMessage(IPacket packet, Action<bool> callback)
		{
			SendAsync(packet.ToString(), callback);
		}
	}
}