namespace TaUtilities.Packets
{
	public class LeaveLobbyData
	{
		public LeaveLobbyData(int lobbyCode)
		{
			LobbyCode = lobbyCode;
		}

		public int LobbyCode { get; }
	}
}
