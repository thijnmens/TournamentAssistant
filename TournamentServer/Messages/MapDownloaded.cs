using TournamentServer.Services;

namespace TournamentServer.Messages
{
	public static class MapDownloaded
	{
		public static void Incoming(MainService mainService)
		{
			Server.WriteInfo($"Client {mainService.User.Username} download the map successfully");
		}
	}
}
