using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class KickPlayerPacket : IPacket
	{
		public KickPlayerPacket(int lobbyCode, string username, string password)
		{
			MessageType = MessageType.KICK_PLAYER;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new KickPlayerData(lobbyCode, username, password);
		}

		[JsonConstructor]
		public KickPlayerPacket(MessageType messageType, string username, ApplicationType applicationType, KickPlayerData data)
		{
			MessageType = messageType;
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
