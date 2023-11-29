using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LobbyCreatedPacket : IPacket
	{
		public LobbyCreatedData Data { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }
		public string Username { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		public LobbyCreatedPacket(int lobbyCode)
		{
			MessageType = MessageType.LOBBY_CREATED;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new LobbyCreatedData(lobbyCode);
		}

		[JsonConstructor]
		public LobbyCreatedPacket(MessageType messageType, string username, ApplicationType applicationType, int lobbyCode)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = new LobbyCreatedData(lobbyCode);
		}

		public class LobbyCreatedData
		{
			public int LobbyCode { get; }

			public LobbyCreatedData(int lobbyCode)
			{
				LobbyCode = lobbyCode;
			}
		}

		public override string ToString()
		{
			return PacketConverter.Convert(this);
		}
	}
}