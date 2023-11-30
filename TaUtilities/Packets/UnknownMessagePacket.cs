using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class UnknownMessagePacket : IPacket
	{
		[JsonConstructor]
		public UnknownMessagePacket(string username, ApplicationType applicationType, UnknownMessageData data)
		{
			MessageType = MessageType.UNKNOWN_MESSAGE;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public UnknownMessageData Data { get; }

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
