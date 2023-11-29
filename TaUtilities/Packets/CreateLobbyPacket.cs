using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class CreateLobbyPacket : IPacket
	{
		public CreateLobbyData Data { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }
		public string Username { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		[JsonConstructor]
		public CreateLobbyPacket(
			MessageType messageType,
			string username,
			ApplicationType applicationType,
			string password
		)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = new CreateLobbyData(password);
		}

		public CreateLobbyPacket(string password)
		{
			MessageType = MessageType.CREATE_LOBBY;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new CreateLobbyData(password);
		}

		public class CreateLobbyData
		{
			public string Password { get; }

			public CreateLobbyData(string password)
			{
				Password = password;
			}
		}
		public override string ToString()
		{
			return PacketConverter.Convert(this);
		}
	}
}