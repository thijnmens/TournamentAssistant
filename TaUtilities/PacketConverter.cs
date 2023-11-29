using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TaUtilities.Interfaces;

namespace TaUtilities
{
	public static class PacketConverter
	{
		public static T Convert<T>(string data)
		{
			return JsonConvert.DeserializeObject<T>(data);
		}

		public static string Convert(IPacket data)
		{
			return JsonConvert.SerializeObject(data);
		}

		public static MessageType GetMessageType(string message)
		{
			return JsonConvert.DeserializeObject<JsonMessageType>(message).MessageType;
		}

		private class JsonMessageType
		{
			[JsonConverter(typeof(StringEnumConverter))]
			public MessageType MessageType { get; }

			public JsonMessageType(MessageType messageType)
			{
				MessageType = messageType;
			}
		}
	}
}