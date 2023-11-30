using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LeaveLobbyPacket : IPacket
	{
		[JsonConstructor]
		public LeaveLobbyPacket(MessageType messageType, string username, ApplicationType applicationType, LeaveLobbyData data)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public LeaveLobbyPacket(int lobbyCode)
		{
			MessageType = MessageType.LEAVE_LOBBY;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new LeaveLobbyData(lobbyCode);
		}

		public LeaveLobbyData Data { get; }
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
