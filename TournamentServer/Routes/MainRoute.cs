using System;
using System.Linq;
using Messages;
using TournamentServer.Messages;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TournamentServer.Routes
{
	public class MainRoute : WebSocketBehavior
	{
		public static MainRoute Instance { get; private set; }

		protected override void OnOpen()
		{
			Instance = this;
			base.OnOpen();
		}

		protected override void OnMessage(MessageEventArgs messageEventArgs)
		{
			var messageType = messageEventArgs.Data.Split(':').First();
			var arg = messageEventArgs.Data.Split(new[] { ':' }, 2).Last();
			if (messageType == arg) arg = "";

			if (Enum.TryParse(messageType, out Message message)) Outgoing.UnknownMessage(messageEventArgs.Data);

			string[] args;
			switch (message)
			{
				case Message.NEW_CONNECTION:
					Incoming.NewConnection(arg);
					return;
				case Message.CLOSE_CONNECTION:
					Incoming.CloseConnection(arg);
					return;
				case Message.PING:
					Incoming.Ping();
					return;
				case Message.CREATE_LOBBY:
					Incoming.CreateLobby(arg);
					return;
				case Message.DELETE_LOBBY:
					args = arg.Split('|');
					Incoming.DeleteLobby(args.First(), args.Last());
					return;
				case Message.GET_PLAYER_INFO:
					Incoming.GetPlayerInfo(arg);
					return;
				case Message.PLAYER_INFO:
					Incoming.PlayerInfo(arg);
					return;
				case Message.KICK:
					args = arg.Split('|');
					Incoming.Kick(args.First(), args.Last());
					return;
				case Message.VERSION:
					Incoming.Version();
					return;
				case Message.UNKNOWN_MESSAGE:
					Incoming.UnknownMessage();
					return;
				case Message.CONNECTION_ACCEPTED:
					Incoming.ConnectionAccepted();
					return;
				case Message.CONNECTION_CLOSED:
					Incoming.ConnectionClosed();
					return;
				case Message.PONG:
					Incoming.Pong();
					return;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}