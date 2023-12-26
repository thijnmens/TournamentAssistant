using TaUtilities;
using TaUtilities.Interfaces;
using TaUtilities.Packets;

namespace TournamentServer.Services
{
	public static class MessageService
	{
		public static void UnknownMessage(string data)
		{
			var unknownMessagePacket = PacketConverter.Convert<UnknownMessagePacket>(data);
			Server.WriteWarning($"Server send an unknown message to {unknownMessagePacket.Username}|{unknownMessagePacket.ApplicationType}: `{unknownMessagePacket.Data.ReceivedMessage}`");
		}

		public static LobbyCreatedPacket CreateLobby(string data)
		{
			var createLobbyPacket = PacketConverter.Convert<CreateLobbyPacket>(data);

			var lobbyCode = LobbyService.CreateLobby(createLobbyPacket);
			return PacketCreator.LobbyCreatedPacket(lobbyCode, createLobbyPacket.Data.Password.Length != 0);
		}

		public static IPacket RemoveLobby(string data)
		{
			var removeLobbyPacket = PacketConverter.Convert<RemoveLobbyPacket>(data);
			var lobbyRemoved = LobbyService.RemoveLobby(removeLobbyPacket);

			if (!lobbyRemoved)
				return PacketCreator.OperationFailedPacket(data);

			return PacketCreator.LobbyRemovedPacket();
		}

		public static void OperationFailed(string data)
		{
			var operationFailedPacket = PacketConverter.Convert<OperationFailedPacket>(data);
			Server.WriteError($"An operation failed for {operationFailedPacket.Username}|{operationFailedPacket.ApplicationType}: `{operationFailedPacket.Data.FailedOperationMessage}`");
		}

		public static IPacket JoinLobby(string data, IRoute connection)
		{
			var joinLobbyPacket = PacketConverter.Convert<JoinLobbyPacket>(data);
			var joinedLobby = LobbyService.JoinLobby(joinLobbyPacket, connection);

			if (!joinedLobby)
				return PacketCreator.OperationFailedPacket(data);

			return PacketCreator.LobbyJoinedPacket();
		}

		public static IPacket LeaveLobby(string data)
		{
			var leaveLobbyPacket = PacketConverter.Convert<LeaveLobbyPacket>(data);
			var leftLobby = LobbyService.LeaveLobby(leaveLobbyPacket);

			if (!leftLobby)
				return PacketCreator.OperationFailedPacket(data);

			return PacketCreator.LobbyLeftPacket();
		}

		public static IPacket KickPlayer(string data)
		{
			var kickPlayerPacket = PacketConverter.Convert<KickPlayerPacket>(data);
			var kickedPlayer = LobbyService.KickPlayer(kickPlayerPacket);

			if (!kickedPlayer)
				return PacketCreator.OperationFailedPacket(data);

			return PacketCreator.PlayerKickedPacket();
		}

		public static IPacket DownloadMap(string data)
		{
			var downloadMapPacket = PacketConverter.Convert<StartDownloadPacket>(data);
			var downloadedMap = LobbyService.DownloadMap(downloadMapPacket);

			if (!downloadedMap)
				return PacketCreator.OperationFailedPacket(data);

			return null;
		}

		public static void DownloadFinished(string data)
		{
			var fileDownloadedPacket = PacketConverter.Convert<DownloadFinishedPacket>(data);
			LobbyService.DownloadFinished(fileDownloadedPacket);
		}

		public static DownloadsFinishedPacket DownloadStatus(string data)
		{
			var downloadStatusPacket = PacketConverter.Convert<DownloadStatusPacket>(data);
			var downloadStatus = LobbyService.DownloadStatus(downloadStatusPacket);

			return PacketCreator.DownloadsFinishedPacket(downloadStatus);
		}

		public static void LoadMap(string data)
		{
			var loadMapPacket = PacketConverter.Convert<LoadMapPacket>(data);
			LobbyService.LoadMap(loadMapPacket);
		}

		public static void StartMap(string data)
		{
			var startMapPacket = PacketConverter.Convert<StartMapPacket>(data);
			LobbyService.StartMap(startMapPacket);
		}
	}
}
