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

		public static LobbyCreatedPacket LobbyCreatedPacket(int lobbyCode)
		{
			return new LobbyCreatedPacket(Username, ApplicationType, new LobbyCreatedData(lobbyCode));
		}

		public static UnknownMessagePacket UnknownMessagePacket(string receivedMessage)
		{
			return new UnknownMessagePacket(Username, ApplicationType, new UnknownMessageData(receivedMessage));
		}

		public static StartDownloadPacket DownloadMapPacket(int lobbyCode, int mapCode, string password)
		{
			return new StartDownloadPacket(Username, ApplicationType, new StartDownloadData(lobbyCode, mapCode, password));
		}

		public static DownloadStartedPacket MapDownloadedPacket()
		{
			return new DownloadStartedPacket(Username, ApplicationType);
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
	}
}
