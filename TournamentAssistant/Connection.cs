using System;
using System.Linq;
using Messages;
using TournamentAssistant.Messages;
using WebSocketSharp;

namespace TournamentAssistant
{
	public class Connection
	{

		private WebSocket Ws { get; }

		public Connection(string url)
		{
			TournamentAssistant.ModEntry.Logger.Log($"Attempting to join {url}");
			Ws = new WebSocket($"ws://{url}");

			MessageHandler.WsSendAsync = Ws.SendAsync;
			MessageHandler.WsSend = Ws.Send;

			Ws.Connect();

			Outgoing.NewConnection();

			Ws.OnMessage += OnMessage;
		}


		private void OnMessage(object sender, MessageEventArgs messageEventArgs)
		{
			var messageType = messageEventArgs.Data.Split(':').First();
			var arg = messageEventArgs.Data.Split(new[] { ':' }, 2).Last();
			if (messageType == arg) arg = "";

			if (Enum.TryParse(messageType, out Message message)) Outgoing.UnknownMessage();

			string[] args;
			switch (message)
			{
				case Message.NEW_CONNECTION:
					Incoming.NewConnection();
					return;
				case Message.CLOSE_CONNECTION:
					Incoming.CloseConnection();
					return;
				case Message.CONNECTION_ACCEPTED:
					Incoming.ConnectionAccepted();
					return;
				case Message.CONNECTION_CLOSED:
					Incoming.ConnectionClosed();
					return;
				case Message.PING:
					Incoming.Ping();
					return;
				case Message.PONG:
					Incoming.Pong();
					return;
				case Message.CREATE_LOBBY:
					Incoming.CreateLobby();
					return;
				case Message.DELETE_LOBBY:
					Incoming.DeleteLobby();
					return;
				case Message.GET_PLAYER_INFO:
					Incoming.GetPlayerInfo();
					return;
				case Message.PLAYER_INFO:
					Incoming.PlayerInfo();
					return;
				case Message.KICK:
					Incoming.Kick();
					return;
				case Message.VERSION:
					Incoming.Version();
					return;
				case Message.UNKNOWN_MESSAGE:
					Incoming.UnknownMessage(messageEventArgs.Data);
					return;
				case Message.LOBBY_CREATED:
					Incoming.LobbyCreated();
					return;
				case Message.LOBBY_DELETED:
					Incoming.LobbyDeleted();
					return;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public void OnApplicationQuit()
		{
			Outgoing.CloseConnection();
			Ws.Close();
		}
	}
}