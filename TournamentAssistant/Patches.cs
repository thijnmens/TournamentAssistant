using HarmonyLib;

// ReSharper disable UnusedType.Local
// ReSharper disable UnusedMember.Local

namespace TournamentAssistant
{
	internal class Patches
	{
		[HarmonyPatch(typeof(scrController), "OnApplicationQuit")]
		private static class ScrControllerOnApplicationQuitPatch
		{
			[HarmonyPrefix]
			private static bool Prefix()
			{
				if (TournamentAssistant.Connection != null) TournamentAssistant.Connection.OnApplicationQuit();
				return true;
			}
		}
	}
}