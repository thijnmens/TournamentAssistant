using WebSocketSharp.Server;

namespace TaUtilities.Interfaces
{
	public interface IUser
	{
		string Username { get; }
		IWebSocketSession Connection { get; }
		string ToString();
	}
}