using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class RemoveLobbyPacket : IPacket
	{
		public RemoveLobbyData Data { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }
		public string Username { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		[JsonConstructor]
		public RemoveLobbyPacket(
			MessageType messageType,
			string username,
			ApplicationType applicationType,
			int lobbyCode,
			string password
		)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = new RemoveLobbyData(lobbyCode, password);
		}

		public RemoveLobbyPacket(
			int lobbyCode,
			string password
		)
		{
			MessageType = MessageType.REMOVE_LOBBY;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new RemoveLobbyData(lobbyCode, password);
		}

		public override string ToString()
		{
			return PacketConverter.Convert(this);
		}

		public class RemoveLobbyData
		{
			public int LobbyCode { get; }
			public string Password { get; }

			public RemoveLobbyData(int lobbyCode, string password)
			{
				LobbyCode = lobbyCode;
				Password = password;
			}
		}
	}
}