using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class LeaveLobbyPacket : IPacket
	{
		[JsonConstructor]
		public LeaveLobbyPacket(string username, ApplicationType applicationType, LeaveLobbyData data)
		{
			MessageType = MessageType.LEAVE_LOBBY;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public LeaveLobbyData Data { get; }
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
