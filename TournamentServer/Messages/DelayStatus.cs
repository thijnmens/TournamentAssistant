using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;
using TaUtilities;
using TournamentServer.Classes;
using TournamentServer.Services;
using JsonConverter = TaUtilities.JsonConverter;

namespace TournamentServer.Messages
{
	public static class DelayStatus
	{
		public static void Incoming(MainService mainService, DelayStatusRequest request)
		{
			var user = Server.Websocket.Connections.First(pair => pair.Value.User.Username == request.Username);
			Outgoing(user.Value, request.Delay);
		}

		public static void Outgoing(MainService mainService, int delay)
		{
			mainService.SendMessage(Message.DELAY_STATUS, JsonConverter.Convert(new DelayStatusResponse(delay)));
		}
	}

	public class DelayStatusRequest
	{
		[JsonProperty("delay")] public int Delay;
		[JsonProperty("user")] public string Username;
	}
	
	public class DelayStatusResponse
	{
		[JsonProperty("delay")] public int Delay;

		public DelayStatusResponse(int delay)
		{
			Delay = delay;
		}
	}
}