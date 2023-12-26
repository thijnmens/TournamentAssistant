using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class StartMapPacket : IPacket
	{
		[JsonConstructor]
		public StartMapPacket(string username, ApplicationType applicationType, StartMapData data)
		{
			MessageType = MessageType.LOAD_MAP;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public StartMapData Data { get; }

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
