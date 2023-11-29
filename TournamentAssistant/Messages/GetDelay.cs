using System.Threading;
using JetBrains.Annotations;

namespace TournamentAssistant.Messages
{
	public static class GetDelay
	{
		[CanBeNull] private static Thread FormCreatorThread { get; set; }

		public static void Incoming()
		{
			TournamentAssistant.ModEntry.Logger.Log("Starting delay measurement, please don't close the qrcode window");
			new Thread(() =>
			{
				Thread.CurrentThread.IsBackground = true;
				_ = new FormCreator();
			}).Start();
		}

		public static void CloseForm()
		{
			FormCreatorThread?.Abort();
			FormCreatorThread = null;
		}
	}
}