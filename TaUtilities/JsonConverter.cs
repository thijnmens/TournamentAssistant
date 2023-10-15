using Newtonsoft.Json;

namespace TaUtilities
{
	public static class JsonConverter
	{
		public static T Convert<T>(string data)
		{
			return JsonConvert.DeserializeObject<T>(data);
		}

		public static string Convert(object data)
		{
			return JsonConvert.SerializeObject(data);
		}
	}
}