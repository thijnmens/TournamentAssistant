using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyRemovedPacket : IPacket
	{
		[JsonConstructor]
		public LobbyRemovedPacket(string username, ApplicationType applicationType)
		{
			MessageType = MessageType.LOBBY_REMOVED;
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
