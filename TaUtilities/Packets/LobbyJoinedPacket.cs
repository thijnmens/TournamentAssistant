using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyJoinedPacket : IPacket
	{
		[JsonConstructor]
		public LobbyJoinedPacket(string username, ApplicationType applicationType)
		{
			MessageType = MessageType.LOBBY_JOINED;
			Username = username;
			ApplicationType = applicationType;
		}

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
