using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class RemoveLobbyPacket : IPacket
	{
		[JsonConstructor]
		public RemoveLobbyPacket(string username, ApplicationType applicationType, RemoveLobbyData data)
		{
			MessageType = MessageType.REMOVE_LOBBY;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public RemoveLobbyData Data { get; }

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
