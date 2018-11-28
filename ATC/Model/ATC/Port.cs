using Core.ATC;
using Model.ATC.Helpers;
using System;

namespace Model.ATC
{
	public class Port : IPort
	{
		private BinderPortTerminal binder;

		public int Number { get; }
		public PortStatus Status { get; set; }

		public event Action<ITerminal, string> CallAction;
		public event Action<ITerminal> RejectAction;
		public event Action<ITerminal> AnswerAction;
		public event Action<ITerminal> AttachTerminal;
		public event Action<ITerminal> UnhookTerminal;

		public Port(int number)
		{
			Number = number;
			Status = PortStatus.Offline;
			binder = new BinderPortTerminal();
		}

		public void Attach(ITerminal terminal)
		{
			if (terminal != null)
			{
				if(AttachTerminal != null)
				{
					binder.Bind(terminal, this);
					AttachTerminal(terminal);		
				}
			}
		}

		public void Unhook(ITerminal terminal)
		{
			if (terminal != null)
			{
				if(UnhookTerminal != null)
				{
					binder.UnBind(terminal, this);
					UnhookTerminal(terminal);
				}
			}
		}

		public void Call(ITerminal terminal, string number)
		{
			if(Status == PortStatus.Online)
			{
				if(CallAction != null)
				{
					CallAction(terminal, number);
				}
			}
		}

		public void Answer(ITerminal terminal)
		{
			Status = PortStatus.Busy;
			if(AnswerAction != null)
			{
				AnswerAction(terminal);
			}
		}	

		public void Reject(ITerminal terminal)
		{
			Status = PortStatus.Online;
			if(RejectAction != null)
			{
				RejectAction(terminal);
			}
		}
	}
}