using TournamentServer.Services;

namespace TournamentServer.Classes
{
	public interface IUser
	{
		string Username { get; }
		MainService Connection { get; }
	}
}