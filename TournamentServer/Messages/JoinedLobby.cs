using TaUtilities;
using TournamentServer.Services;

namespace TournamentServer.Messages
{
	public static class JoinedLobby
	{
		public static void Outgoing(MainService mainService)
		{
			mainService.SendMessage(Message.JOINED_LOBBY);
		}
	}
}