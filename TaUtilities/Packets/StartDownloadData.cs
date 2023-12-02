namespace TaUtilities.Packets
{
	public class StartDownloadData
	{
		public StartDownloadData(int lobbyCode, int mapCode, string password)
		{
			LobbyCode = lobbyCode;
			MapCode = mapCode;
			Password = password;
		}

		public int LobbyCode { get; }
		public int MapCode { get; }
		public string Password { get; }
	}
}
