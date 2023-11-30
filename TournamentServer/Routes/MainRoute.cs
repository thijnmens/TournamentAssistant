using System;
using TaUtilities;
using TaUtilities.Interfaces;
using TaUtilities.Packets;
using TournamentServer.Services;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TournamentServer.Routes
{
	public class MainRoute : WebSocketBehavior, IRoute
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

				case MessageType.JOIN_LOBBY:
					var joinLobbyPacket = PacketConverter.Convert<JoinLobbyPacket>(e.Data);
					var joinedLobby = LobbyService.JoinLobby(joinLobbyPacket, this);
					if (joinedLobby)
					{
						var lobbyJoinedPacket = new LobbyJoinedPacket();
						SendMessage(lobbyJoinedPacket);
					}
					else
					{
						var joinLobbyOperationFailedPacket = new OperationFailedPacket(e.Data);
						SendMessage(joinLobbyOperationFailedPacket);
					}
					break;

				case MessageType.LEAVE_LOBBY:
					var leaveLobbyPacket = PacketConverter.Convert<LeaveLobbyPacket>(e.Data);
					var leftLobby = LobbyService.LeaveLobby(leaveLobbyPacket);
					if (leftLobby)
					{
						var lobbyLeftPacket = new LobbyLeftPacket();
						SendMessage(lobbyLeftPacket);
					}
					else
					{
						var leaveLobbyOperationFailedPacket = new OperationFailedPacket(e.Data);
						SendMessage(leaveLobbyOperationFailedPacket);
					}
					break;

				case MessageType.KICK_PLAYER:
					var kickPlayerPacket = PacketConverter.Convert<KickPlayerPacket>(e.Data);
					var kickedPlayer = LobbyService.KickPlayer(kickPlayerPacket);
					if (kickedPlayer)
					{
						var playerKickedPacket = new PlayerKickedPacket();
						SendMessage(playerKickedPacket);
					}
					else
					{
						var kickPlayerOperationFailedPacket = new OperationFailedPacket(e.Data);
						SendMessage(kickPlayerOperationFailedPacket);
					}
					break;

				case MessageType.LOBBY_CREATED:
				case MessageType.LOBBY_REMOVED:
				case MessageType.LOBBY_JOINED:
				case MessageType.LOBBY_LEFT:
				case MessageType.PLAYER_KICKED:
				default:
					var response = new UnknownMessagePacket(MessageType.UNKNOWN_MESSAGE, "SERVER", ApplicationType.SERVER, new UnknownMessageData(e.Data));
					SendMessage(response);
					break;
			}

			base.OnMessage(e);
		}

		public void SendMessage(IPacket packet)
		{
			SendAsync(packet.ToJson(), _ => { });
		}

		public void SendMessage(IPacket packet, Action<bool> callback)
		{
			SendAsync(packet.ToJson(), callback);
		}
	}
}
