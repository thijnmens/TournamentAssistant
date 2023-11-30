using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class CreateLobbyPacket : IPacket
	{
		[JsonConstructor]
		public CreateLobbyPacket(MessageType messageType, string username, ApplicationType applicationType, CreateLobbyData data)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public CreateLobbyPacket(string password)
		{
			MessageType = MessageType.CREATE_LOBBY;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new CreateLobbyData(password);
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
