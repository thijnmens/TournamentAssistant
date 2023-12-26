using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Classes;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class DownloadMap
	{
		public static void Incoming(MainService mainService, DownloadMapRequest downloadMapRequest)
		{
			if (mainService.User.GetType() == typeof(Coordinator))
				// TODO: Filter by lobby
				foreach (var connection in Server.Websocket.Connections)
					Outgoing(connection.Value, downloadMapRequest.DownloadUrl);
			else
				UnknownMessage.Outgoing(mainService, $"DOWNLOAD_MAP:{{\"downloadUrl\":\"{downloadMapRequest.DownloadUrl}\"}}");
		}

		public static void Outgoing(MainService mainService, string downloadUrl)
		{
			var downloadMapResponse = new DownloadMapResponse(downloadUrl);
			mainService.SendMessage(Message.DOWNLOAD_MAP, JsonConverter.Convert(downloadMapResponse));
		}

		private class DownloadMapResponse
		{
			[JsonProperty("downloadUrl")]
			public string DownloadUrl;

			public DownloadMapResponse(string downloadUrl)
			{
				DownloadUrl = downloadUrl;
			}
		}
	}

	public class DownloadMapRequest
	{
		[JsonProperty("downloadUrl")]
		public string DownloadUrl;
	}
}
