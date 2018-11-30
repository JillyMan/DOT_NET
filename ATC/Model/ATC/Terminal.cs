using System;
using Core.ATC;

namespace Model
{
	public class Terminal : ITerminal
	{
		public int Number { get; }

		public Terminal(int number)
		{
			Number = number;
		}

		public event Action<int> CallAction;
		public event Action RejectAction;
		public event Action AnswerAction;

		public event Action ConnectToPortAction;
		public event Action DisconnectAction;

		public void ConnectToPort()
		{
			if(ConnectToPortAction != null)
			{
				ConnectToPortAction();
			}
		}

		public void Disconnect()
		{
			if(DisconnectAction != null)
			{
				DisconnectAction();
			}
		}

		public void Call(int number)
		{
			if(CallAction != null)
			{
				CallAction(number);
			}
		}

		public void Answer()
		{
			if(AnswerAction != null)
			{
				AnswerAction();
			}
		}

		public void Reject()
		{
			if(RejectAction != null)
			{
				RejectAction();
			}
		}

	}
}