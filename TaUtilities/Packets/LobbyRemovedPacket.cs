using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyRemovedPacket : IPacket
	{
		[JsonConstructor]
		public LobbyRemovedPacket(MessageType messageType, string username, ApplicationType applicationType)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
		}

		public LobbyRemovedPacket()
		{
			MessageType = MessageType.LOBBY_REMOVED;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
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
