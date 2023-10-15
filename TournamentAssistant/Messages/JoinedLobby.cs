namespace TournamentAssistant.Messages
{
	public static class JoinedLobby
	{
		public static void Incoming()
		{
			TournamentAssistant.ModEntry.Logger.Log("Successfully joined lobby");
		}
	}
}