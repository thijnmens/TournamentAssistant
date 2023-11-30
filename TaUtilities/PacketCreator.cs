using TaUtilities.Packets;

namespace TaUtilities
{
	public static class PacketCreator
	{
		public static string Username { get; set; } = "SERVER";
		public static ApplicationType ApplicationType { get; set; } = ApplicationType.SERVER;

		public static CreateLobbyPacket CreateLobbyPacket(string password)
		{
			return new CreateLobbyPacket(Username, ApplicationType, new CreateLobbyData(password));
		}

		public static JoinLobbyPacket JoinLobbyPacket(int lobbyCode, string password)
		{
			return new JoinLobbyPacket(Username, ApplicationType, new JoinLobbyData(lobbyCode, password));
		}

		public static KickPlayerPacket KickPlayerPacket(int lobbyCode, string kickUsername, string password)
		{
			return new KickPlayerPacket(Username, ApplicationType, new KickPlayerData(lobbyCode, kickUsername, password));
		}

		public static LeaveLobbyPacket LeaveLobbyPacket(int lobbyCode)
		{
			return new LeaveLobbyPacket(Username, ApplicationType, new LeaveLobbyData(lobbyCode));
		}

		public static LobbyCreatedPacket LobbyCreatedPacket(int lobbyCode)
		{
			return new LobbyCreatedPacket(Username, ApplicationType, new LobbyCreatedData(lobbyCode));
		}

		public static UnknownMessagePacket UnknownMessagePacket(string receivedMessage)
		{
			return new UnknownMessagePacket(Username, ApplicationType, new UnknownMessageData(receivedMessage));
		}
	}
}
