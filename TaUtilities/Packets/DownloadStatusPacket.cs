using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class DownloadStatusPacket : IPacket
	{
		[JsonConstructor]
		public DownloadStatusPacket(string username, ApplicationType applicationType, DownloadStatusData data)
		{
			MessageType = MessageType.DOWNLOAD_STATUS;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public DownloadStatusData Data { get; }

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
