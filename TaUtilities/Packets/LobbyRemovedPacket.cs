using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyRemovedPacket : IPacket
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }
		public string Username { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		[JsonConstructor]
		public LobbyRemovedPacket(
			MessageType messageType,
			string username,
			ApplicationType applicationType
		)
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

		public override string ToString()
		{
			return PacketConverter.Convert(this);
		}
	}
}