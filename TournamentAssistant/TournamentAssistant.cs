﻿using HarmonyLib;
using JetBrains.Annotations;
using UnityEngine;
using UnityModManagerNet;

namespace TournamentAssistant
{
	public class TournamentAssistant
	{

		public static UnityModManager.ModEntry ModEntry { get; private set; }
		[CanBeNull] private Connection Connection { get; set; }
		private string LobbyUrl { get; set; } = "";

		public TournamentAssistant(UnityModManager.ModEntry modEntry)
		{
			ModEntry = modEntry;

			var harmony = new Harmony("com.thijnmens.tournamentassistant");
			harmony.PatchAll();

			modEntry.OnGUI += OnGui;
		}

		private void OnGui(UnityModManager.ModEntry modEntry)
		{
			GUILayout.BeginVertical();
			GUILayout.Label("Lobby url");
			LobbyUrl = GUILayout.TextArea(LobbyUrl);
			GUILayout.EndVertical();
			GUILayout.BeginHorizontal();
			if (GUILayout.Button("Join")) Connection = new Connection(LobbyUrl);
			GUILayout.EndHorizontal();
		}
	}
}