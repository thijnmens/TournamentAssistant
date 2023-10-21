using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;
using Steamworks;

namespace TournamentAssistant.Messages
{
	public static class DownloadMap
	{
		public static void Incoming(DownloadMapRequest request)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Downloading map from '{request.DownloadUrl}'");

			var downloadPath = Path.GetFullPath(Path.Combine(TournamentAssistant.ModEntry.Path, @"../../CustomSongs", Path.GetFileName(request.DownloadUrl)));
			try
			{
				Directory.CreateDirectory(Path.GetDirectoryName(downloadPath) ?? throw new InvalidOperationException());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				TournamentAssistant.ModEntry.Logger.Error($"Failed to create directory for download '{downloadPath}'");
				OperationFailed.Outgoing($"Client '{SteamFriends.GetPersonaName()}' failed to download the map");
				return;
			}

			try
			{
				using (var client = new WebClient())
				{
					// TODO: Change to async (async breaks rn cuz it tries to unzip before the download is finished
					client.DownloadFile(new Uri(request.DownloadUrl ?? throw new InvalidOperationException()), downloadPath);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				TournamentAssistant.ModEntry.Logger.Error($"Failed to download song from '{request.DownloadUrl}'");
				OperationFailed.Outgoing($"Client '{SteamFriends.GetPersonaName()}' failed to download the map");
				return;
			}

			var unzipDir = Path.Combine(Path.GetDirectoryName(downloadPath) ?? string.Empty, Path.GetFileNameWithoutExtension(downloadPath));
			try
			{
				Directory.CreateDirectory(unzipDir);
				ZipFile.ExtractToDirectory(downloadPath, unzipDir);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				TournamentAssistant.ModEntry.Logger.Error($"Failed to unzip map from '{downloadPath}' to '{unzipDir}'");
				OperationFailed.Outgoing($"Client '{SteamFriends.GetPersonaName()}' failed to download the map");
				return;
			}

			TournamentAssistant.ModEntry.Logger.Log($"Successfully download map '{Path.GetFileNameWithoutExtension(downloadPath)}'");
			MapDownloaded.Outgoing();
		}
	}

	public class DownloadMapRequest
	{
		[JsonProperty("downloadUrl")] public string DownloadUrl;
	}
}