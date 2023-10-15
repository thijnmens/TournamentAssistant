﻿using TournamentServer.Services;

namespace TournamentServer.Classes
{
	public class Player : IUser
	{
		public Player(string username, MainService connection)
		{
			Username = username;
			Connection = connection;
		}

		public string Username { get; }
		public MainService Connection { get; }
	}
}