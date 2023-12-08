using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using TaUtilities;
using TaUtilities.Packets;

namespace CoordCLI
{
	public static class MessageService
	{
		private static int StatusTryCount { get; set; }

		public static void UnknownMessage(string data)
		{
			var unknownMessagePacket = PacketConverter.Convert<UnknownMessagePacket>(data);
			Program.WriteWarning($"Send an unknown message to the server:\n`{unknownMessagePacket.Data.ReceivedMessage}`");
		}

		public static void OperationFailed(string data)
		{
			var operationFailedPacket = PacketConverter.Convert<OperationFailedPacket>(data);
			Program.WriteError($"An operation on the server failed:\n`{operationFailedPacket.Data.FailedOperationMessage}`");
		}

		public static void LobbyJoined()
		{
			Program.WriteInfo("Successfully joined lobby");
		}

		public static void LobbyLeft()
		{
			Program.WriteInfo("Left the lobby, if this happened unexpectedly you might have been kicked");
		}

		public static void DownloadFile(string data, Connection connection)
		{
			var downloadFilePacket = PacketConverter.Convert<DownloadFilePacket>(data);
			Program.WriteInfo($"Starting map download with code `{downloadFilePacket.Data.MapCode}`");

			Task.Factory.StartNew(() =>
			{
				using (var client = new WebClient())
				{
					client.DownloadFile($"https://cdn.adosar.io/map/{downloadFilePacket.Data.MapCode}.zip", $"{downloadFilePacket.Data.MapCode}.zip");
				}

				ZipFile.ExtractToDirectory($"{downloadFilePacket.Data.MapCode}.zip", "1");

				connection.SendMessage(PacketCreator.DownloadFinishedPacket(connection.LobbyCode));
			});
		}

		public static CreateLobbyPacket CreateLobby()
		{
			var password = Program.WriteQuestion("Password [Leave empty for no password]: ");
			return PacketCreator.CreateLobbyPacket(password);
		}

		public static void LobbyCreated(string data)
		{
			var lobbyCreatedPacket = PacketConverter.Convert<LobbyCreatedPacket>(data);
			Program.WriteInfo($"Created lobby with code `{lobbyCreatedPacket.Data.LobbyCode}` (USING PASSWORD = {lobbyCreatedPacket.Data.UsingPassword})");
		}

		public static JoinLobbyPacket JoinLobby()
		{
			var lobbyCode = int.Parse(Program.WriteQuestion("Lobby code: "));
			var password = Program.WriteQuestion("Password [Leave empty for no password]: ");
			Program.Connection.LobbyCode = lobbyCode;
			return PacketCreator.JoinLobbyPacket(lobbyCode, password);
		}

		public static void LobbyRemoved()
		{
			Program.WriteInfo("Removed lobby");
		}

		public static void PlayerKicked()
		{
			Program.WriteInfo("Player kicked");
		}

		public static void DownloadsFinished(string data)
		{
			var downloadsFinishedPacket = PacketConverter.Convert<DownloadsFinishedPacket>(data);
			if (downloadsFinishedPacket.Data.DownloadStatus)
			{
				StatusTryCount = 0;
				Program.WriteInfo("All downloads finished");
			}
			else
			{
				if (StatusTryCount >= 10)
				{
					Program.WriteWarning("Downloads are taking a long time, try again later");
					StatusTryCount = 0;
					return;
				}

				Task.Factory.StartNew(() =>
				{
					Thread.Sleep(10000);
					Program.Connection.SendMessage(DownloadStatus(Program.Connection.LobbyCode));
					StatusTryCount++;
				});
			}
		}

		public static DownloadStatusPacket DownloadStatus(int lobbyCode)
		{
			return PacketCreator.DownloadStatusPacket(lobbyCode);
		}

		public static StartDownloadPacket StartDownload(int lobbyCode)
		{
			var isInt = int.TryParse(Program.WriteQuestion("Map code: "), out var mapCode);
			if (!isInt)
			{
				Program.WriteWarning($"{mapCode} could not be inverted to an integer, is it a number?");
				return StartDownload(lobbyCode);
			}

			var password = Program.WriteQuestion("Password [Leave empty for no password]: ");
			return PacketCreator.StartDownloadPacket(lobbyCode, mapCode, password);
		}
	}
}
