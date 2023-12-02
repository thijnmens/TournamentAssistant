namespace TaUtilities.Packets
{
	public class DownloadStatusData
	{
		public DownloadStatusData(int lobbyCode)
		{
			LobbyCode = lobbyCode;
		}

		public int LobbyCode { get; }
	}
}
