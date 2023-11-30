using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyCreatedPacket : IPacket
	{
		public LobbyCreatedPacket(int lobbyCode)
		{
			MessageType = MessageType.LOBBY_CREATED;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new LobbyCreatedData(lobbyCode);
		}

		[JsonConstructor]
		public LobbyCreatedPacket(MessageType messageType, string username, ApplicationType applicationType, LobbyCreatedData data)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public LobbyCreatedData Data { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }

		public string Username { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		public string ToJson()
		{
			return PacketConverter.Convert(this);
		}
	}
}
