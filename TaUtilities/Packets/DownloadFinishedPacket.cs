using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class DownloadFinishedPacket : IPacket
	{
		[JsonConstructor]
		public DownloadFinishedPacket(string username, ApplicationType applicationType, DownloadFinishedData data)
		{
			MessageType = MessageType.DOWNLOAD_FINISHED;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public DownloadFinishedData Data { get; }

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
