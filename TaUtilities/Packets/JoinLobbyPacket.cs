using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class JoinLobbyPacket : IPacket
	{
		[JsonConstructor]
		public JoinLobbyPacket(string username, ApplicationType applicationType, JoinLobbyData data)
		{
			MessageType = MessageType.JOIN_LOBBY;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public JoinLobbyData Data { get; }
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
