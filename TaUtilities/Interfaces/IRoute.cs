using System;

namespace TaUtilities.Interfaces
{
	public interface IRoute
	{
		void SendMessage(IPacket packet);
		void SendMessage(IPacket packet, Action<bool> callback);
	}
}
