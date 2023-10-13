using System;
using System.Linq;
using WebSocketSharp;
using WebSocketSharp.Server;
using static Crayon.Output;


namespace TournamentServer
{
	public class MessageHandler : WebSocketBehavior
	{
		protected override void OnMessage(MessageEventArgs messageEventArgs)
		{
			switch (messageEventArgs.Data.Split(':')[0])
			{
				case "PING":
					SendAsync("PONG", _ => { });
					break;
				case "NEW_CONNECTION":
					var ip = messageEventArgs.Data.Split(' ').Last();
					SendAsync($"CONNECTION_ACCEPTED: connection from {ip}",
						_ => { });
					Console.WriteLine($"{Green("~")} New connection from {Underline(ip)}");
					break;
				default:
					Console.WriteLine($"{Red("Unknown message")}: {messageEventArgs.Data}");
					break;
			}
		}
	}
}