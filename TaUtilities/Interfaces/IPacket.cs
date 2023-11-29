namespace TaUtilities.Interfaces
{
	public interface IPacket
	{
		string MessageType { get; }
		string Username { get; }
		ApplicationType ApplicationType { get; }
		IData Data { get; }
		int? LobbyCode { get; }
	}
}