namespace TaUtilities.Packets
{
	public class StartMapData
	{
		public StartMapData(int lobbyCode, string password = "")
		{
			LobbyCode = lobbyCode;
			Password = password;
		}

		public int LobbyCode { get; }
		public string Password { get; }
	}
}
