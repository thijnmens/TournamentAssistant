namespace TaUtilities.Packets
{
	public class UnknownMessageData
	{
		public UnknownMessageData(string receivedMessage)
		{
			ReceivedMessage = receivedMessage;
		}

		public string ReceivedMessage { get; }
	}
}
