using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class DownloadsFinishedPacket : IPacket
	{
		[JsonConstructor]
		public DownloadsFinishedPacket(string username, ApplicationType applicationType, DownloadsFinishedData data)
		{
			MessageType = MessageType.DOWNLOADS_FINISHED;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public DownloadsFinishedData Data { get; }

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
