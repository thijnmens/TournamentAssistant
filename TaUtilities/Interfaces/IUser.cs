namespace TaUtilities.Interfaces
{
	public interface IUser
	{
		string Username { get; }
		IRoute Connection { get; }
		bool Downloading { get; set; }
		string ToString();
		bool DownloadMap(int mapCode);
		void LoadMap(int mapCode);
		void StartMap();
	}
}
