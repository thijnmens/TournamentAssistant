namespace TaUtilities.Packets
{
	public class KickPlayerData
	{
		public KickPlayerData(int lobbyCode, string username, string password)
		{
			LobbyCode = lobbyCode;
			Username = username;
			Password = password;
		}

		public int LobbyCode { get; }
		public string Username { get; }
		public string Password { get; }
	}
}
