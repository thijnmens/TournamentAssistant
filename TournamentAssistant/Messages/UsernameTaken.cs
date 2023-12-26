using Newtonsoft.Json;

namespace TournamentAssistant.Messages
{
	public static class UsernameTaken
	{
		public static void Incoming(UsernameTakenRequest request)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Username '{request.Username}' is already taken, please change it");
		}
	}

	public class UsernameTakenRequest
	{
		[JsonProperty("username")]
		public string Username;

		public UsernameTakenRequest(string username)
		{
			Username = username;
		}
	}
}
