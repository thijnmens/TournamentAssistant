using System;
using System.Diagnostics;
using System.Reflection;
using Messages;

namespace TournamentAssistant.Messages
{
	public static class Incoming
	{
		public static bool Connected { get; private set; }
		public static Action OnPong { get; set; } = null;

		/// <summary>
		///     Should not be received, as the client does not accept new connections
		///     <returns>
		///         <see cref="Message">Message.UNKNOWN_MESSAGE</see>
		///     </returns>
		/// </summary>
		public static void NewConnection()
		{
			UnknownMessage(Message.NEW_CONNECTION.ToString());
		}

		/// <summary>
		///     Received when the server requests to close the connection
		///     <returns>
		///         <see cref="Message">Message.CONNECTION_CLOSED</see>
		///     </returns>
		/// </summary>
		public static void CloseConnection()
		{
			MessageHandler.SendAsync(Message.CONNECTION_CLOSED);
		}

		/// <summary>
		///     Received when the server wants to know if the client is still running
		///     <returns>
		///         <see cref="Message">Message.PONG</see>
		///     </returns>
		/// </summary>
		public static void Ping()
		{
			MessageHandler.SendAsync(Message.PONG);
		}

		/// <summary>
		///     Received when the mod sends out a ping to the server to see if it's still running, should not be received otherwise
		/// </summary>
		public static void Pong()
		{
			if (OnPong != null) OnPong();
			else TournamentAssistant.ModEntry.Logger.Warning("Received pong without sending ping");
		}

		/// <summary>
		///     Received when the server requests to get info about the player, the info includes
		///     <list type="bullet">
		///         <item>Steam username</item>
		///         <item>Steam profile picture</item>
		///         <item>Adofai version</item>
		///         <item>Mod version</item>
		///         <item>Mods in use</item>
		///     </list>
		///     <returns>
		///         <see cref="Message">Message.PLAYER_INFO</see>
		///     </returns>
		/// </summary>
		public static void GetPlayerInfo()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Should not be received
		///     <returns>
		///         <see cref="Message">Message.UNKNOWN_MESSAGE</see>
		///     </returns>
		/// </summary>
		public static void PlayerInfo()
		{
			MessageHandler.SendAsync(Message.UNKNOWN_MESSAGE);
		}

		/// <summary>
		///     Received when the server successfully closed the connection on request of the mod
		/// </summary>
		public static void ConnectionClosed()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Received when the server kicks the player
		/// </summary>
		public static void Kick()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		///     Received when the server wants to know what mod version the player is running
		///     <returns>
		///         <see cref="Message">Message.VERSION</see>
		///     </returns>
		/// </summary>
		public static void Version()
		{
			var version = FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(TournamentAssistant)).Location).FileVersion;
			MessageHandler.SendAsync(Message.VERSION, version);
		}

		/// <summary>
		///     Should not be received, as the mod does not create lobbies
		///     <returns>
		///         <see cref="Message">Message.UNKNOWN_MESSAGE</see>
		///     </returns>
		/// </summary>
		public static void CreateLobby()
		{
			MessageHandler.SendAsync(Message.UNKNOWN_MESSAGE);
		}

		/// <summary>
		///     Should not be received, as the mod does not delete lobbies
		///     <returns>
		///         <see cref="Message">Message.UNKNOWN_MESSAGE</see>
		///     </returns>
		/// </summary>
		public static void DeleteLobby()
		{
			MessageHandler.SendAsync(Message.UNKNOWN_MESSAGE);
		}

		/// <summary>
		///     <param name="message">Copy of the faulty message</param>
		///     Received when a message we send was not supported by the server, this can happen due to mismatching versions
		/// </summary>
		public static void UnknownMessage(string message)
		{
			TournamentAssistant.ModEntry.Logger.Error($"Server responded with UNKNOWN_MESSAGE: '{message}'");
		}

		/// <summary>
		///     Received when the server accepts our connection
		/// </summary>
		public static void ConnectionAccepted()
		{
			Connected = false;
		}

		/// <summary>
		///     Received when the joined lobby gets deleted
		/// </summary>
		public static void LobbyDeleted()
		{
			Connected = false;
		}

		/// <summary>
		///     Should not be received as the mod does not create lobbies
		///     <returns>
		///         <see cref="Message">Message.UNKNOWN_MESSAGE</see>
		///     </returns>
		/// </summary>
		public static void LobbyCreated()
		{
			MessageHandler.SendAsync(Message.UNKNOWN_MESSAGE);
		}
	}
}