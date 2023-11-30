using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class KickPlayerPacket : IPacket
	{
		[JsonConstructor]
		public KickPlayerPacket(string username, ApplicationType applicationType, KickPlayerData data)
		{
			MessageType = MessageType.KICK_PLAYER;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public KickPlayerData Data { get; }

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
