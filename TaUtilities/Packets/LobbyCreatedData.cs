namespace TaUtilities.Packets
{
	public class LobbyCreatedData
	{
		public LobbyCreatedData(int lobbyCode, bool usingPassword)
		{
			LobbyCode = lobbyCode;
			UsingPassword = usingPassword;
		}

		public int LobbyCode { get; }
		public bool UsingPassword { get; }
	}
}
