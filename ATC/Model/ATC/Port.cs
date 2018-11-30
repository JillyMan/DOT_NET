using Core.ATC;
using System;

namespace Model.ATC
{
	public class Port : IPort<Terminal>
	{
		public int Number { get; }
		public PortStatus Status { get; set; }

		public event Action<Terminal, int> CallAction;
		public event Action<Terminal> RejectAction;
		public event Action<Terminal> AnswerAction;

		public event Action<Terminal> AttachTerminalAction;
		public event Action<Terminal> UnhookTerminalAction;

		public void AttachTerminal(Terminal terminal)
		{
			if(AttachTerminalAction != null)
			{
				AttachTerminalAction(terminal);
			}
		}

		public void UnhookTerminaln(Terminal terminal)
		{
			if(UnhookTerminalAction != null)
			{
				UnhookTerminalAction(terminal);
			}
		}

		public Port(int number)
		{
			Number = number;
			Status = PortStatus.Offline;
		}

		//add check int null;
		public void Call(Terminal terminal, int number)
		{
			if(terminal == null)
			{
				throw new ArgumentNullException("Terminal is null");
			}

			if(Status == PortStatus.Online && 
				CallAction != null)
			{
				CallAction(terminal, number);
			}
		}

		public void Answer(Terminal terminal)
		{
			if (Status == PortStatus.Online && 
				AnswerAction != null)
			{
				AnswerAction(terminal);
			}
		}	

		public void Reject(Terminal terminal)
		{
			if(Status == PortStatus.Busy && 
				RejectAction != null)
			{
				RejectAction(terminal);
			}
		}
	}
}