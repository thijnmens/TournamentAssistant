﻿using TaUtilities;
using TaUtilities.Interfaces;

namespace TournamentServer.Classes
{
	public class Player : IUser
	{
		public Player(string username, IRoute connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public IRoute Connection { get; }
		public bool Downloading { get; set; }

		public bool DownloadMap(int mapCode)
		{
			if (Downloading)
				return false;

			Connection.SendMessage(PacketCreator.DownloadFilePacket(mapCode));
			Downloading = true;
			return true;
		}

		public void LoadMap(int mapCode)
		{
			Connection.SendMessage(PacketCreator.LoadMapPacket(0, mapCode));
		}

		public void StartMap()
		{
			Connection.SendMessage(PacketCreator.StartMapPacket(0));
		}
	}
}
