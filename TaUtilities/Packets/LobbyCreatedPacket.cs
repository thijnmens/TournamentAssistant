using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyCreatedPacket : IPacket
	{
		[JsonConstructor]
		public LobbyCreatedPacket(string username, ApplicationType applicationType, LobbyCreatedData data)
		{
			MessageType = MessageType.LOBBY_CREATED;
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
