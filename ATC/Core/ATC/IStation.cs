using System;
using System.Collections.Generic;

namespace Core.ATC
{
	public interface IStation
	{
		event Action<ITerminal, ITerminal> CallCompleted;

		void Call(ITerminal terminal, string number);
		void Answer(ITerminal terminal);
		void Reject(ITerminal terminal);

		void AddTerminal(ITerminal terminal);
		void RemoveTerminal(ITerminal terminal);
	}
}
