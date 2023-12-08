using System;
using Steamworks;
using TaUtilities;
using TaUtilities.Interfaces;
using TournamentAssistant.Services;
using WebSocketSharp;

namespace TournamentAssistant
{
	public class Connection
	{
		public Connection(string url, int lobbyCode, string password = "")
		{
			PacketCreator.ApplicationType = ApplicationType.MOD;
			PacketCreator.Username = SteamFriends.GetPersonaName();

			TournamentAssistant.ModEntry.Logger.Log($"Attempting to join {url}");
			Ws = new WebSocket($"ws://{url}");
			LobbyCode = lobbyCode;

			Ws.ConnectAsync();

			Ws.OnMessage += OnMessage;
			Ws.OnOpen += (sender, args) =>
			{
				SendMessage(
					PacketCreator.JoinLobbyPacket(lobbyCode, password),
					joining =>
					{
						if (joining)
						{
							TournamentAssistant
								.ModEntry
								.Logger
								.Log($"Attempting to join lobby with code `{LobbyCode}` and username `{PacketCreator.Username}` (usingPassword={string.IsNullOrWhiteSpace(password)})");
						}
						else
						{
							TournamentAssistant
								.ModEntry
								.Logger
								.Error(
									$"Something went wrong when attempting to join lobby with code `{LobbyCode}` and username `{PacketCreator.Username}` (usingPassword={string.IsNullOrWhiteSpace(password)})"
								);
						}
					}
				);
			};
		}

		private WebSocket Ws { get; }

		private int LobbyCode { get; }

		private void OnMessage(object sender, MessageEventArgs e)
		{
			if (e.IsPing)
				return;

			var messageType = PacketConverter.GetMessageType(e.Data);

			switch (messageType)
			{
				case MessageType.UNKNOWN_MESSAGE:
					TournamentAssistant.ModEntry.Logger.Warning($"Send an unknown message to the server:\n`{e.Data}`");
					return;

				case MessageType.OPERATION_FAILED:
					TournamentAssistant.ModEntry.Logger.Error($"An operation on the server failed:\n`{e.Data}`");
					return;

				case MessageType.LOBBY_JOINED:
					TournamentAssistant.ModEntry.Logger.Log($"Successfully joined lobby with code `{LobbyCode}` and username `{PacketCreator.Username}`");
					return;

				case MessageType.LOBBY_LEFT:
					TournamentAssistant.ModEntry.Logger.Log("Left lobby");
					return;

				case MessageType.DOWNLOAD_FILE:
					MessageService.DownloadFile(e.Data, LobbyCode);
					return;

				case MessageType.DOWNLOADS_FINISHED:
				case MessageType.DOWNLOAD_STATUS:
				case MessageType.START_DOWNLOAD:
				case MessageType.CREATE_LOBBY:
				case MessageType.LOBBY_CREATED:
				case MessageType.LOBBY_REMOVED:
				case MessageType.REMOVE_LOBBY:
				case MessageType.JOIN_LOBBY:
				case MessageType.LEAVE_LOBBY:
				case MessageType.PLAYER_KICKED:
				case MessageType.KICK_PLAYER:
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
