namespace TaUtilities.Packets
{
	public class CreateLobbyData
	{
		public CreateLobbyData(string password)
		{
			Password = password;
		}

		public string Password { get; }
	}
}
