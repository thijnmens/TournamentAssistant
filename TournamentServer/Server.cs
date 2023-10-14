using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using static Crayon.Output;


namespace TournamentServer
{
	internal class Server
	{
		public static List<string> Connections { get; } = new List<string>();

		public static void Main(string[] args)
		{
			var stopwatch = new Stopwatch();
			stopwatch.Start();

			Console.Clear();

			WriteBanner();

			var ip = "127.0.0.1";
			var port = "8080";
			if (args.Contains("--ip")) ip = args[args.ToList().IndexOf("--ip") + 1];
			if (args.Contains("--port")) port = args[args.ToList().IndexOf("--port") + 1];

			var websocket = new Websocket($"{ip}:{port}");
			stopwatch.Stop();

			WriteServerInfo(stopwatch.ElapsedMilliseconds.ToString(), websocket.IPAddress.ToString(), websocket.Port.ToString());

			while (true)
			{
				var key = Console.ReadKey(true);
				switch (key.KeyChar)
				{
					case 'h':
						WriteHelp();
						break;

					case 'l':
						WriteConnections();
						break;

					case 'q':
						goto exit_loop;
				}

				Console.WriteLine();
			}

			exit_loop:
			Console.WriteLine("Closing server...");
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
			Console.WriteLine(
				$"{Bright.Black("#")}{new string(' ', Console.WindowWidth / 2 - 14)}Tournament Assistant Server");
			Console.SetCursorPosition(Console.WindowWidth - 1, 1);
			Console.Write(Bright.Black("#"));
			Console.WriteLine($"{Bright.Black("#")}{new string(' ', Console.WindowWidth - 2)}{Bright.Black("#")}");
			Console.WriteLine($"{Bright.Black("#")}{new string(' ', Console.WindowWidth - 2)}{Bright.Black("#")}");
			Console.WriteLine(
				$"{Bright.Black("#")}  Version {Green(FileVersionInfo.GetVersionInfo(Assembly.GetAssembly(typeof(Server)).Location).FileVersion)}{new string(' ', Console.WindowWidth - 19)}{Bright.Black("#")}");
			Console.WriteLine(Bright.Black(new string('#', Console.WindowWidth)));
			Console.WriteLine();
		}

		private static void WriteServerInfo(string startupTime, string ipAdress, string port)
		{
			WriteInfo("This is an info message");
			WriteWarning("This is a warning message");
			WriteError("This is an error message");
			Console.WriteLine("");
			Console.WriteLine($"Server Started in {Green(startupTime)}ms");
			Console.WriteLine(
				$"Server is listening on {Underline(Red($"ws://{ipAdress}:{port}"))}");
			Console.WriteLine($"Press {Underline(Bold("h"))} for help");
		}

		private static void WriteHelp()
		{
			Console.WriteLine($"\n{Bright.Blue("help")}");
			Console.WriteLine($"{Green("#")} {Red("h")} for help");
			Console.WriteLine($"{Green("#")} {Red("q")} to exit");
			Console.WriteLine($"{Green("#")} {Red("l")} to list connections");
		}

		private static void WriteConnections()
		{
			Console.WriteLine($"\n{Bright.Blue("Connections")}");
			Connections.ForEach(connection => { Console.WriteLine($"{Green("#")} {Red(connection)}"); });
			Console.WriteLine();
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
	}
}