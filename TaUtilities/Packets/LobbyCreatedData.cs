namespace TaUtilities.Packets
{
	public class LobbyCreatedData
	{
		public LobbyCreatedData(int lobbyCode)
		{
			LobbyCode = lobbyCode;
		}

		public int LobbyCode { get; }
	}
}
