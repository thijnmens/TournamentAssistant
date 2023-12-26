using TaUtilities.Packets;

namespace TaUtilities.Interfaces
{
	public interface IMessageService
	{
		LobbyCreatedPacket CreateLobby(string data);
		LobbyJoinedPacket JoinLobby(string data);
		PlayerKickedPacket KickPlayer(string data);
		LobbyLeftPacket LeaveLobby(string data);
	}
}
