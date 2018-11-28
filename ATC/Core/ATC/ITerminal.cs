using System;

namespace Core.ATC
{
	public interface ITerminal
	{
		string Number { get; }
		IClient Abonent { get; }

		event Action<String> CallAction;
		event Action RejectAction;
		event Action AnswerAction;

		event Action ConnectToPortAction;
		event Action DisconnectAction;

		void ConnectToPort();
		void Disconnect();

		void Call(string number);
		void Answer();
		void Reject();
	}
}