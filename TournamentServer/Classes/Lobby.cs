using System.Collections.Generic;
using System.Linq;
using TaUtilities;
using TaUtilities.Interfaces;
using TournamentServer.Services;

namespace TournamentServer.Classes
{
	public class Lobby
	{
		public Lobby(int lobbyCode, string password, string owner)
		{
			LobbyCode = lobbyCode;
			Password = password;
			Owner = owner;
			Users = new List<IUser>();
		}

		public int LobbyCode { get; }
		public string Password { get; }
		public string Owner { get; }
		public List<IUser> Users { get; }

		public void Close()
		{
			var lobbyLeftPacket = PacketCreator.LobbyLeftPacket();
			foreach (var user in Users)
			{
				user.Connection.SendMessage(lobbyLeftPacket);
			}

			LobbyService.Lobbies.Remove(LobbyCode);
		}

		public bool Join(IUser user)
		{
			if (Users.Exists(match => match.Username == user.Username))
				return false;

			Users.Add(user);
			return true;
		}

		public bool Leave(string username)
		{
			return Users.Exists(match => match.Username == username) && Users.Remove(Users.First(a => a.Username == username));
		}

		public bool IsAuthorized(string username = "", string password = "")
		{
			if (!string.IsNullOrWhiteSpace(username))
			{
				if (Owner != username)
					return false;
			}

			if (!string.IsNullOrWhiteSpace(password))
			{
				if (Password != password)
					return false;
			}

			return true;
		}

		public bool DownloadMap(int mapCode)
		{
			var success = true;

			foreach (var user in Users)
			{
				var startedDownload = user.DownloadMap(mapCode);
				if (!startedDownload)
					success = false;
			}

			return success;
		}

		public bool DownloadStatus()
		{
			return !Users.Any(user => user.Downloading);
		}

		public void DownloadFinished(string username)
		{
			Users.First(user => user.Username == username).Downloading = false;
		}

		public void LoadMap(int mapCode)
		{
			foreach (var user in Users)
			{
				if (user.GetType() == typeof(Player))
					user.LoadMap(mapCode);
			}
		}

		public void StartMap()
		{
			foreach (var user in Users)
			{
				if (user.GetType() == typeof(Player))
					user.StartMap();
			}
		}
	}
}
