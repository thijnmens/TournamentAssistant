using System;
using System.Linq;
using TaUtilities;
using static Crayon.Output;

namespace CoordCLI
{
	internal class Program
	{
		public static Connection Connection { get; private set; }

		public static void Main(string[] args)
		{
			Console.Clear();

			var ip = args.Contains("--ip") ? args[args.ToList().IndexOf("--ip") + 1] : WriteQuestion("ip: ");
			var port = args.Contains("--port") ? args[args.ToList().IndexOf("--port") + 1] : WriteQuestion("port: ");
			var username = args.Contains("--username") ? args[args.ToList().IndexOf("--username") + 1] : WriteQuestion("username: ");

			PacketCreator.ApplicationType = ApplicationType.APP;
			PacketCreator.Username = username;

			Connection = new Connection(ip, port);

			while (true)
			{
				var line = Console.ReadLine() ?? "";

				switch (line.Trim().ToLower())
				{
					case "exit":
						Connection.OnApplicationQuit();
						WriteInfo("Bye bye!");
						return;

					case "createlobby":
						Connection.SendMessage(MessageService.CreateLobby());
						break;

					case "joinlobby":
						Connection.SendMessage(MessageService.JoinLobby());
						break;

					case "leavelobby":
						Connection.SendMessage(MessageService.LeaveLobby(Connection.LobbyCode));
						break;

					case "downloadstatus":
						Connection.SendMessage(MessageService.DownloadStatus(Connection.LobbyCode));
						break;

					case "downloadfile":
						Connection.SendMessage(MessageService.StartDownload(Connection.LobbyCode));
						break;

					case "loadmap":
						Connection.SendMessage(MessageService.LoadMap(Connection.LobbyCode));
						break;

					case "startmap":
						Connection.SendMessage(MessageService.StartMap(Connection.LobbyCode));
						break;

					case "help":
						WriteInfo("Help: ");
						WriteInfo("createlobby: Create a new lobby");
						WriteInfo("joinlobby: Join a lobby");
						WriteInfo("leavelobby: Leave the currently joined lobby");
						WriteInfo("downloadstatus: Gets the download status from all clients");
						WriteInfo("downloadfile: Instructs all clients to download a file");
						WriteInfo("loadmap: Loads a map on all clients");
						WriteInfo("startmap: Starts the map on all clients UNSYNCED");
						break;

					default:
						WriteError($"Unknown command {line}");
						break;
				}
			}
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

		public static string WriteQuestion(string message)
		{
			Console.Write($"{Bright.Red(">")} {Cyan(message)}");
			return Console.ReadLine();
		}
	}
}
