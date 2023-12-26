using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class DownloadStartedPacket : IPacket
	{
		[JsonConstructor]
		public DownloadStartedPacket(string username, ApplicationType applicationType)
		{
			MessageType = MessageType.DOWNLOAD_STARTED;
			Username = username;
			ApplicationType = applicationType;
		}

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
