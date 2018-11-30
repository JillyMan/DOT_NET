using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.ATC
{
	public interface IPort<T> where T : ITerminal
	{
		int Number { get; }
		PortStatus Status { get; set; }

		void Call(T terminal, int number);
		void Answer(T terminal);
		void Reject(T terminal);
	}
}