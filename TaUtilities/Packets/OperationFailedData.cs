namespace TaUtilities.Packets
{
	public class OperationFailedData
	{
		public OperationFailedData(string failedOperationMessage)
		{
			FailedOperationMessage = failedOperationMessage;
		}

		public string FailedOperationMessage { get; }
	}
}
