using System;
using System.Collections.Generic;

namespace Core.ATC
{
	public interface IStation<T> where T : ITerminal
	{
		void Call(T terminal, int number);
		void Answer(T terminal);
		void Reject(T terminal);

		void AddTerminal(T terminal);
		void RemoveTerminal(T terminal);
	}
}
