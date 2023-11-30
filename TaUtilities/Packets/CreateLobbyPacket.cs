using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class CreateLobbyPacket : IPacket
	{
		[JsonConstructor]
		public CreateLobbyPacket(string username, ApplicationType applicationType, CreateLobbyData data)
		{
			MessageType = MessageType.CREATE_LOBBY;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public CreateLobbyData Data { get; }
		public string Username { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }

		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		public string ToJson()
		{
			return PacketConverter.Convert(this);
		}
	}
}
