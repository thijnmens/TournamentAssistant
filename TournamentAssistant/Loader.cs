using System;
using System.IO;
using UnityModManagerNet;

namespace TournamentAssistant
{
	internal static class Loader
	{
		internal static bool Load(UnityModManager.ModEntry modEntry)
		{
			try
			{
				LoadAssembly(@"Mods\TA\websocket-sharp.dll");
				LoadAssembly(@"Mods\TA\Messages.dll");

				var _ = new TournamentAssistant(modEntry);
				return true;
			}
			catch (Exception exception)
			{
				modEntry.Logger.Log(exception.ToString());
				return false;
			}
		}

		private static void LoadAssembly(string path)
		{
			using (var stream = new FileStream(path, FileMode.Open))
			{
				var data = new byte[stream.Length];
				// ReSharper disable once MustUseReturnValue
				stream.Read(data, 0, data.Length);
				AppDomain.CurrentDomain.Load(data);
			}
		}
	}
}