using WebSocketSharp.Server;

namespace TaUtilities.Interfaces
{
	public interface IUser
	{
		string Username { get; }
		IRoute Connection { get; }

		string ToString();
	}
}
