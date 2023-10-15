using System;
using System.Linq;
using TaUtilities;
using TournamentServer.Classes;
using TournamentServer.Messages;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace TournamentServer.Services
{
	public class MainService : WebSocketBehavior
	{

		public IUser User { get; private set; }

		protected override void OnOpen()
		{
			var type = Context.QueryString["type"];
			var username = Context.QueryString["username"];

			if (Server.Websocket.Connections.ContainsKey(username))
			{
				UsernameTaken.Outgoing(this, username);
				return;
			}

			if (type == "mod")
			{
				User = new Player(username, this);
				Server.WriteInfo($"New player connected: '{username}'");
			}
			else
			{
				User = new Coordinator(username, this);
				Server.WriteInfo($"New coordinator connected: '{username}'");
			}

			Server.Websocket.Connections.Add(User.Username, this);
			Connected.Outgoing(this);
			base.OnOpen();
		}

		protected override void OnClose(CloseEventArgs e)
		{
			Server.Websocket.Connections.Remove(User.Username);
			Server.WriteInfo($"User '{User.Username}' disconnected");
			base.OnClose(e);
		}

		protected override void OnMessage(MessageEventArgs e)
		{
			var splitMessage = e.Data.Split(new[] { ':' }, 2);
			var messageType = splitMessage.First();
			var data = splitMessage.Last();

			if (!Enum.TryParse(messageType, out Message message)) throw new NotImplementedException(); // TODO: Send UNKNOWN_MESSAGE

			switch (message)
			{
				case Message.UNKNOWN_MESSAGE:
					UnknownMessage.Incoming(JsonConverter.Convert<UnknownMessageRequest>(data));
					return;
				case Message.JOIN_LOBBY:
					JoinLobby.Incoming(this, JsonConverter.Convert<JoinLobbyRequest>(data));
					return;
				case Message.CONNECTED:
				case Message.JOINED_LOBBY:
				case Message.USERNAME_TAKEN:
				case Message.UNKNOWN_LOBBY:
				default:
					UnknownMessage.Outgoing(this, e.Data);
					return;
			}
		}

		public void SendMessage(Message message)
		{
			SendAsync(message.ToString(), _ => { });
		}

		public void SendMessage(Message message, Action<bool> callback)
		{
			SendAsync(message.ToString(), callback);
		}

		public void SendMessage(Message message, string data)
		{
			SendAsync($"{message.ToString()}:{data}", _ => { });
		}

		public void SendMessage(Message message, string data, Action<bool> callback)
		{
			SendAsync($"{message.ToString()}:{data}", callback);
		}
	}
}