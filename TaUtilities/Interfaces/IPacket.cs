namespace TaUtilities.Interfaces
{
	public interface IPacket
	{
		MessageType MessageType { get; }
		string Username { get; }
		ApplicationType ApplicationType { get; }
		string ToJson();
	}
}
