using System;
using Core;
using Core.ATC;

namespace Model
{
	public class Terminal : ITerminal
	{
		public IPort Port { get; private set; }
		public IClient Abonent { get; }
		public string Number { get; }

		public Terminal(string number, IClient abonent)
		{
			Number = number;
			Abonent = abonent;
		}

		public event Action<string> CallAction;
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

		public void Call(string number)
		{
			if (!string.IsNullOrEmpty(number))
			{
				if(CallAction != null)
				{
					CallAction(number);
				}
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