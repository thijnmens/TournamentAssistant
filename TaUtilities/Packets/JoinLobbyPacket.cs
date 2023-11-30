using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class JoinLobbyPacket : IPacket
	{
		[JsonConstructor]
		public JoinLobbyPacket(MessageType messageType, string username, ApplicationType applicationType, JoinLobbyData data)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public JoinLobbyPacket(int lobbyCode, string password)
		{
			MessageType = MessageType.JOIN_LOBBY;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new JoinLobbyData(lobbyCode, password);
		}

		public JoinLobbyData Data { get; }
		public string Username { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		public string ToJson()
		{
			return PacketConverter.Convert(this);
		}
	}
}
