using System;
using System.Linq;
using Messages;
using TournamentServer.Classes;
using WebSocketSharp;
using WebSocketSharp.Server;
using static Crayon.Output;


namespace TournamentServer.Handlers
{
	public class MessageHandler : WebSocketBehavior
	{

		public static MessageHandler Instance { get; private set; }

		protected override void OnOpen()
		{
			Instance = this;
			base.OnOpen();
		}

		protected override void OnMessage(MessageEventArgs messageEventArgs)
		{
			var messageType = messageEventArgs.Data.Split(':')[0];
			var arg = messageEventArgs.Data.Split(new[] { ':' }, 2)[1];

			if (Enum.TryParse(messageType, out Message message)) SendMessage(Message.UNKNOWN_MESSAGE);

			SendMessage(message, arg);
		}

		public void SendMessage(Message message, string arg = "")
		{
			switch (message)
			{
				case Message.PING:
					SendAsync("PING", _ => { });
					return;

				case Message.NEW_CONNECTION:
					SendAsync($"CONNECTION_ACCEPTED:{arg}", _ => Server.Connections.Add(arg));
					Console.WriteLine($"{Green("~")} New connection from {Underline(arg)}");
					return;

				case Message.NEW_LOBBY:
					LobbyManager.CreateNewLobby();
					return;

				case Message.PLAYER_INFO:
					var args = arg.Split('|');
					int.TryParse(args[0], out var lobbyCode);
					var player = args[1];
					if (player == "ALL")
					{
						var playerInfo = LobbyManager.Lobbies[lobbyCode].Players.Select(p => p.Username);
						SendAsync($"PLAYER_INFO:{string.Join("|", playerInfo)}", _ => { });
					}
					else
					{
						var playerInfo = LobbyManager.Lobbies[lobbyCode].Players.First(p => p.Username == player).Username;
						SendAsync($"PLAYER_INFO:{playerInfo}", _ => { });
					}

					return;

				case Message.CLOSE_CONNECTION:
					SendAsync($"CONNECTION_CLOSED:{arg}",
						_ => Server.Connections.Remove(arg));
					Console.WriteLine($"{Red("~")} Connection closed for {Underline(arg)}");
					return;

				case Message.UNKNOWN_MESSAGE:
					SendAsync($"UNKNOWN_MESSAGE:{arg}", _ => { });
					return;

				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}