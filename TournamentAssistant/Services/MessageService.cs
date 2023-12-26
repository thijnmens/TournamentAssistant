using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaUtilities;
using TaUtilities.Packets;

namespace TournamentAssistant.Services
{
	public static class MessageService
	{
		public static void DownloadFile(string data, int lobbyCode)
		{
			var downloadFilePacket = PacketConverter.Convert<DownloadFilePacket>(data);
			TournamentAssistant.ModEntry.Logger.Log($"Starting map download with code `{downloadFilePacket.Data.MapCode}`");

			Task.Factory.StartNew(() =>
			{
				using (var client = new WebClient())
				{
					client.DownloadFile($"https://cdn.adosar.io/map/{downloadFilePacket.Data.MapCode}.zip", $"./CustomSongs/{downloadFilePacket.Data.MapCode}.zip");
				}

				TournamentAssistant.ModEntry.Logger.Log("Finished download, starting unzip");

				ZipFile.ExtractToDirectory($"./CustomSongs/{downloadFilePacket.Data.MapCode}.zip", $"./CustomSongs/{downloadFilePacket.Data.MapCode}/");
				TournamentAssistant.ModEntry.Logger.Log("Finished Extracting");

				TournamentAssistant.Connection.SendMessage(PacketCreator.DownloadFinishedPacket(lobbyCode));
			});
		}

		public static void LoadMap(string data)
		{
			var loadMapPacket = PacketConverter.Convert<LoadMapPacket>(data);
			TournamentAssistant.ModEntry.Logger.Log($"Loading map with code `{loadMapPacket.Data.MapCode}`");

			ADOBase.controller.LoadCustomLevel($"./CustomSongs/{loadMapPacket.Data.MapCode}/main.adofai");
			ADOBase.controller.LockInput(100000000000f);
		}

		public static void StartMap()
		{
			ADOBase.controller.UnlockInput();
			//SendKeys.Send(" ");
		}
	}
}
