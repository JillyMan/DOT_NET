using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ATC
{
	public interface IPort
	{
		int Number { get; }
		PortStatus Status { get; set; }

		event Action<ITerminal, string> CallAction;
		event Action<ITerminal> RejectAction;
		event Action<ITerminal> AnswerAction;
		event Action<ITerminal> AttachTerminal;
		event Action<ITerminal> UnhookTerminal;

		void Call(ITerminal terminal, string number);
		void Answer(ITerminal terminal);
		void Reject(ITerminal terminal);

		void Attach(ITerminal terminal);
		void Unhook(ITerminal terminal);
	}
}