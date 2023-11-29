using System;
using System.Linq;
using Steamworks;
using TaUtilities;
using TaUtilities.Interfaces;
using WebSocketSharp;

namespace TournamentAssistant
{
	public class Connection
	{
		private WebSocket Ws { get; }

		private int LobbyCode { get; }

		public Connection(string url, int lobbyCode)
		{
			TournamentAssistant
				.ModEntry
				.Logger
				.Log($"Attempting to join {url}?type=mod&username={SteamFriends.GetPersonaName()}");
			Ws = new WebSocket($"ws://{url}?type=mod&username={SteamFriends.GetPersonaName()}");
			LobbyCode = lobbyCode;

			Ws.ConnectAsync();

			Ws.OnMessage += OnMessage;
		}

		private void OnMessage(object sender, MessageEventArgs e)
		{
			var splitMessage = e.Data.Split(new[] { ':' }, 2);
			var messageType = splitMessage.First().Trim();
			var data = splitMessage.Last().Trim();

			var message = (MessageType)Enum.Parse(typeof(MessageType), messageType);
		}

		public void SendMessage(IPacket packet)
		{
			Ws.SendAsync(packet.ToString(), _ => { });
		}

		public void SendMessage(IPacket packet, Action<bool> callback)
		{
			Ws.SendAsync(packet.ToString(), callback);
		}

		public void OnApplicationQuit()
		{
			Ws.Close();
		}

		public void OnApplicationQuit(Action callback)
		{
			Ws.Close();
			callback();
		}
	}
}