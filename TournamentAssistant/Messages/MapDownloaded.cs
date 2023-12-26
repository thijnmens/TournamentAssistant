using TaUtilities;

namespace TournamentAssistant.Messages
{
	public static class MapDownloaded
	{
		public static void Outgoing()
		{
			TournamentAssistant.Connection?.SendMessage(MessageType.MAP_DOWNLOADED);
		}
	}
}
