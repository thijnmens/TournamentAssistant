using TaUtilities;
using TaUtilities.Interfaces;

namespace TournamentAssistant.Packets
{
	public class CreateLobby: IPacket
	{
		public string MessageType { get; }
		public string Username { get; }
		public ApplicationType ApplicationType { get; }
		public IData Data { get; }
		public int? LobbyCode { get; }

		public CreateLobby(string messageType, string username, ApplicationType applicationType, IData data, int? lobbyCode)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
			LobbyCode = lobbyCode;
		}
	}
}