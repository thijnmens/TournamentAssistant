namespace TaUtilities.Packets
{
	public class DownloadsFinishedData
	{
		public DownloadsFinishedData(bool downloadStatus)
		{
			DownloadStatus = downloadStatus;
		}

		public bool DownloadStatus { get; }
	}
}
