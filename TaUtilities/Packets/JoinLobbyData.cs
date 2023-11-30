namespace TaUtilities.Packets
{
	public class JoinLobbyData
	{
		public JoinLobbyData(int lobbyCode, string password)
		{
			LobbyCode = lobbyCode;
			Password = password;
		}

		public int LobbyCode { get; }
		public string Password { get; }
	}
}
