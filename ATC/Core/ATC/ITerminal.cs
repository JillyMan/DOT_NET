using System;

namespace Core.ATC
{
	public interface ITerminal
	{
		int Number { get; }

		void Call(int number);
		void Answer();
		void Reject();
	}
}