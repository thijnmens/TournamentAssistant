using TaUtilities;
using TournamentServer.Services;

namespace TournamentServer.Messages
{
	public static class Connected
	{
		public static void Outgoing(MainService mainService)
		{
			mainService.SendMessage(Message.CONNECTED);
		}
	}
}
