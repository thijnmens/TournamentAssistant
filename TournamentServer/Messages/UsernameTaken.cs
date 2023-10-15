using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class UsernameTaken
	{
		public static void Outgoing(MainService mainService, string username)
		{
			var usernameTakenResponse = new UsernameTakenResponse(username);
			mainService.SendMessage(Message.USERNAME_TAKEN, JsonConverter.Convert(usernameTakenResponse));
		}

		private class UsernameTakenResponse
		{
			[JsonProperty("username")] public string Username;

			public UsernameTakenResponse(string username)
			{
				Username = username;
			}
		}
	}
}