namespace TaUtilities.Packets
{
	public class DownloadFileData
	{
		public DownloadFileData(int mapCode)
		{
			MapCode = mapCode;
		}

		public int MapCode { get; }
	}
}
