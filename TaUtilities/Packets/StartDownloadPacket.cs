using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class StartDownloadPacket : IPacket
	{
		[JsonConstructor]
		public StartDownloadPacket(string username, ApplicationType applicationType, StartDownloadData data)
		{
			MessageType = MessageType.START_DOWNLOAD;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public StartDownloadData Data { get; }

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
