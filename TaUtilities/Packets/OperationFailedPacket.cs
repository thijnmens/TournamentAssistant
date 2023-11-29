using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities.Packets
{
	public class OperationFailedPacket : IPacket
	{
		public OperationFailedData Data { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public MessageType MessageType { get; }
		public string Username { get; }
		[JsonConverter(typeof(StringEnumConverter))]
		public ApplicationType ApplicationType { get; }

		public OperationFailedPacket(string failedOperationMessage)
		{
			MessageType = MessageType.UNKNOWN_MESSAGE;
			Username = "SERVER";
			ApplicationType = ApplicationType.SERVER;
			Data = new OperationFailedData(failedOperationMessage);
		}

		[JsonConstructor]
		public OperationFailedPacket(
			MessageType messageType,
			string username,
			ApplicationType applicationType,
			string failedOperationMessage
		)
		{
			MessageType = messageType;
			Username = username;
			ApplicationType = applicationType;
			Data = new OperationFailedData(failedOperationMessage);
		}

		public override string ToString()
		{
			return PacketConverter.Convert(this);
		}

		public class OperationFailedData
		{
			public string FailedOperationMessage { get; }

			public OperationFailedData(string failedOperationMessage)
			{
				FailedOperationMessage = failedOperationMessage;
			}
		}
	}
}