using TaUtilities.Interfaces.Messages;

namespace TournamentServer.Messages
{
	public class CreateLobby : ICreateLobby
	{
		public string Password { get; }

		public CreateLobby(string password)
		{
			Password = password;
		}
	}
}
