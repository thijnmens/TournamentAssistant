using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class PlayerKickedPacket : IPacket
	{
		[JsonConstructor]
		public PlayerKickedPacket(string username, ApplicationType applicationType)
		{
			MessageType = MessageType.PLAYER_KICKED;
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
