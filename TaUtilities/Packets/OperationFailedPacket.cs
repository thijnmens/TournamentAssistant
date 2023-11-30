using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class OperationFailedPacket : IPacket
	{
		public OperationFailedPacket(string failedOperationMessage)
		{
			MessageType = MessageType.OPERATION_FAILED;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new OperationFailedData(failedOperationMessage);
		}

		[JsonConstructor]
		public OperationFailedPacket(MessageType messageType, string username, ApplicationType applicationType, OperationFailedData data)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = data;
		}

		public OperationFailedData Data { get; }

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
