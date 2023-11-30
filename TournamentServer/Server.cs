using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using TournamentServer.Classes;
using TournamentServer.Services;
using static Crayon.Output;

namespace TournamentServer
{
	internal class Server
	{
		public static Websocket Websocket { get; private set; }

		public static void Main(string[] args)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			Console.Clear();

			WriteBanner();

			var ip = "127.0.0.1";
			var port = "8080";
			if (args.Contains("--ip"))
				ip = args[args.ToList().IndexOf("--ip") + 1];
			if (args.Contains("--port"))
				port = args[args.ToList().IndexOf("--port") + 1];

			Websocket = new Websocket(ip, port);
			stopwatch.Stop();

			WriteServerInfo(stopwatch.ElapsedMilliseconds.ToString(), Websocket.IpAddress, Websocket.Port);

			while (true)
			{
				var key = Console.ReadKey(true);
				switch (key.KeyChar)
				{
					case 'h':
						WriteHelp();
						break;

					case 'l':
						WriteLobbies(LobbyService.Lobbies);
						break;

					// case 'c':
					// 	WriteConnections(Websocket.IpAddress);
					// 	break;

					case 'q':
						goto exit_loop;
				}

				Console.WriteLine();
			}

			exit_loop:
			Console.WriteLine("Closing server...");
		}

		public static void WriteInfo(string message)
		{
			Console.WriteLine($"{Green("~")} {message}");
		}

		public static void WriteWarning(string message)
		{
			Console.WriteLine($"{Yellow("!")} {Bright.Yellow(message)}");
		}

		public static void WriteError(string message)
		{
			Console.WriteLine($"{Red("!!!")} {Bright.Red(message)}");
		}

		public static void WriteNewConnection(string username)
		{
			Console.WriteLine($"{Green("✔")} New connection from {username}");
		}

		private static void WriteBanner()
		{
			// ########################################################################################################################
			// #                                             Tournament Assistant Server                                              #
			// #                                                                                                                      #
			// #                                                                                                                      #
			// #  Version 1.0.0.0                                                                                                     #
			// ########################################################################################################################
			Console.WriteLine(Bright.Black(new string('#', Console.WindowWidth)));
			Console.WriteLine($"{Bright.Black("#")}{new string(' ', Console.WindowWidth / 2 - 14)}Tournament Assistant Server");
			Console.SetCursorPosition(Console.WindowWidth - 1, 1);
			Console.Write(Bright.Black("#"));
			Console.WriteLine($"{Bright.Black("#")}{new string(' ', Console.WindowWidth - 2)}{Bright.Black("#")}");
			Console.WriteLine($"{Bright.Black("#")}{new string(' ', Console.WindowWidth - 2)}{Bright.Black("#")}");
			Console.WriteLine(
				$"{Bright.Black("#")}  Version {Green(FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(Server)).Location).FileVersion)}{new string(' ', Console.WindowWidth - 19)}{Bright.Black("#")}"
			);
			Console.WriteLine(Bright.Black(new string('#', Console.WindowWidth)));
			Console.WriteLine();
		}

		private static void WriteServerInfo(string startupTime, string ipAddress, string port)
		{
			WriteInfo("This is an info message");
			WriteWarning("This is a warning message");
			WriteError("This is an error message");
			Console.WriteLine("");
			Console.WriteLine($"Server Started in {Green(startupTime)}ms");
			Console.WriteLine($"Server is listening on {Underline(Red($"ws://{ipAddress}:{port}"))}");
			Console.WriteLine($"Press {Underline(Bold("h"))} for help");
		}

		private static void WriteHelp()
		{
			Console.WriteLine($"\n{Bright.Blue("help")}");
			Console.WriteLine($"{Green("#")} {Red("h")} for help");
			Console.WriteLine($"{Green("#")} {Red("q")} to exit");
			Console.WriteLine($"{Green("#")} {Red("l")} to list all lobbies");
		}

		// private static void WriteConnections(Dictionary<string, MainService> connections)
		// {
		// 	Console.WriteLine($"\n{Bright.Blue("Connections")}");
		// 	connections.ToList().ForEach(connection => { Console.WriteLine($"{Green("#")} {Red(connection.Value.User.Username)}"); });
		// 	Console.WriteLine();
		// }

		private static void WriteLobbies(Dictionary<int, Lobby> lobbies)
		{
			Console.WriteLine($"\n{Bright.Blue("Lobbies")}");
			lobbies
				.ToList()
				.ForEach(connection =>
				{
					Console.WriteLine(
						$"{Green("#")} {Red(connection.Value.LobbyCode.ToString())} {White("-")} {Yellow(connection.Value.Owner)} {White("-")} {Cyan(LobbyService.GetLobbyByCode(connection.Value.LobbyCode).Users.Count().ToString())}"
					);
				});
			Console.WriteLine();
		}
	}
}
