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

			var websocket = new Websocket();
			if (args.Contains("--ip")) websocket = new Websocket(args[args.ToList().IndexOf("--ip") + 1]);
			stopwatch.Stop();
			Console.WriteLine($"Server Started in {Green(stopwatch.ElapsedMilliseconds.ToString())}ms");
			Console.WriteLine(
				$"Server is listening on {Underline(Red($"ws://{websocket.IPAddress}:{websocket.Port}"))}");
			Console.WriteLine($"Press {Underline(Bold("h"))} for help");

			while (true)
			{
				var key = Console.ReadKey(true);
				switch (key.KeyChar)
				{
					case 'h':
						Console.WriteLine($"\n{Bright.Blue("help")}");
						Console.WriteLine($"{Green("#")} {Red("h")} for help");
						Console.WriteLine($"{Green("#")} {Red("q")} to exit");
						Console.WriteLine($"{Green("#")} {Red("l")} to list connections");
						Console.WriteLine();
						break;

					case 'l':
						Console.WriteLine($"\n{Bright.Blue("Connections")}");
						Connections.ForEach(connection => { Console.WriteLine($"{Green("#")} {Red(connection)}"); });
						Console.WriteLine();
						break;

					case 'q':
						goto exit_loop;
				}
			}

			exit_loop: ;
			Console.WriteLine("Closing server...");
		}
	}
}