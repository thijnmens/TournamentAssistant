using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class DownloadFilePacket : IPacket
	{
		[JsonConstructor]
		public DownloadFilePacket(string username, ApplicationType applicationType, DownloadFileData data)
		{
			MessageType = MessageType.DOWNLOAD_FILE;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public DownloadFileData Data { get; }

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
