﻿using TaUtilities.Interfaces;
using TaUtilities.Packets;

namespace TaUtilities
{
	public static class PacketCreator
	{
		public static string Username { get; set; } = "SERVER";
		public static ApplicationType ApplicationType { get; set; } = ApplicationType.SERVER;

		public static JoinLobbyPacket JoinLobbyPacket(int lobbyCode, string password)
		{
			return new JoinLobbyPacket(Username, ApplicationType, new JoinLobbyData(lobbyCode, password));
		}

		public static LobbyCreatedPacket LobbyCreatedPacket(int lobbyCode, bool usingPassword)
		{
			return new LobbyCreatedPacket(Username, ApplicationType, new LobbyCreatedData(lobbyCode, usingPassword));
		}

		public static UnknownMessagePacket UnknownMessagePacket(string receivedMessage)
		{
			return new UnknownMessagePacket(Username, ApplicationType, new UnknownMessageData(receivedMessage));
		}

		public static StartDownloadPacket DownloadMapPacket(int lobbyCode, int mapCode, string password)
		{
			return new StartDownloadPacket(Username, ApplicationType, new StartDownloadData(lobbyCode, mapCode, password));
		}

		public static DownloadFilePacket DownloadFilePacket(int mapCode)
		{
			return new DownloadFilePacket(Username, ApplicationType, new DownloadFileData(mapCode));
		}

		public static LobbyLeftPacket LobbyLeftPacket()
		{
			return new LobbyLeftPacket(Username, ApplicationType);
		}

		public static OperationFailedPacket OperationFailedPacket(string failedOperationMessage)
		{
			return new OperationFailedPacket(Username, ApplicationType, new OperationFailedData(failedOperationMessage));
		}

		public static LobbyRemovedPacket LobbyRemovedPacket()
		{
			return new LobbyRemovedPacket(Username, ApplicationType);
		}

		public static LobbyJoinedPacket LobbyJoinedPacket()
		{
			return new LobbyJoinedPacket(Username, ApplicationType);
		}

		public static PlayerKickedPacket PlayerKickedPacket()
		{
			return new PlayerKickedPacket(Username, ApplicationType);
		}

		public static DownloadStatusPacket DownloadStatusPacket(int lobbyCode)
		{
			return new DownloadStatusPacket(Username, ApplicationType, new DownloadStatusData(lobbyCode));
		}

		public static DownloadsFinishedPacket DownloadsFinishedPacket(bool downloadStatus)
		{
			return new DownloadsFinishedPacket(Username, ApplicationType, new DownloadsFinishedData(downloadStatus));
		}

		public static DownloadFinishedPacket DownloadFinishedPacket(int lobbyCode)
		{
			return new DownloadFinishedPacket(Username, ApplicationType, new DownloadFinishedData(lobbyCode));
		}

		public static CreateLobbyPacket CreateLobbyPacket(string password = "")
		{
			return new CreateLobbyPacket(Username, ApplicationType, new CreateLobbyData(password));
		}

		public static StartDownloadPacket StartDownloadPacket(int lobbyCode, int mapCode, string password = "")
		{
			return new StartDownloadPacket(Username, ApplicationType, new StartDownloadData(lobbyCode, mapCode, password));
		}

		public static LeaveLobbyPacket LeaveLobbyPacket(int lobbyCode)
		{
			return new LeaveLobbyPacket(Username, ApplicationType, new LeaveLobbyData(lobbyCode));
		}

		public static LoadMapPacket LoadMapPacket(int lobbyCode, int mapCode, string password = "")
		{
			return new LoadMapPacket(Username, ApplicationType, new LoadMapData(lobbyCode, mapCode, password));
		}

		public static StartMapPacket StartMapPacket(int lobbyCode, string password = "")
		{
			return new StartMapPacket(Username, ApplicationType, new StartMapData(lobbyCode, password));
		}
	}
}
