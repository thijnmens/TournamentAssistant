namespace TaUtilities.Packets
{
	public class DownloadFinishedData
	{
		public DownloadFinishedData(int lobbyCode)
		{
			LobbyCode = lobbyCode;
		}

		public int LobbyCode { get; }
	}
}
