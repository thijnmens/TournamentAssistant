using System;
using Messages;

namespace TournamentAssistant.Messages
{
	public static class MessageHandler
	{
		public static Action<string> WsSend { private get; set; }
		public static Action<string, Action<bool>> WsSendAsync { private get; set; }


		public static void Send(Message type)
		{
			WsSend(type.ToString());
		}

		public static void Send(Message type, string data)
		{
			WsSend($"{type.ToString()}:{data}");
		}

		public static void SendAsync(Message type)
		{
			WsSendAsync(type.ToString(), _ => { });
		}

		public static void SendAsync(Message type, string data)
		{
			WsSendAsync($"{type.ToString()}:{data}", _ => { });
		}

		public static void SendAsync(Message type, string data, Action<bool> callback)
		{
			WsSendAsync($"{type.ToString()}:{data}", callback);
		}
	}
}