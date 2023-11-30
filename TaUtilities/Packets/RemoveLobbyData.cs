namespace TaUtilities.Packets
{
	public class RemoveLobbyData
	{
		public RemoveLobbyData(int lobbyCode, string password)
		{
			LobbyCode = lobbyCode;
			Password = password;
		}

		public int LobbyCode { get; }
		public string Password { get; }
	}
}
