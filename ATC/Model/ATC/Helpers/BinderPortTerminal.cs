using Core.ATC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ATC.Helpers
{
	public class BinderPortTerminal
	{
		public void Bind(ITerminal terminal, IPort port)
		{
			if(terminal == null || port == null)
			{
				throw new ArgumentNullException();
			}

			terminal.CallAction += (number) => port.Call(terminal, number);
			terminal.AnswerAction += () => port.Answer(terminal);
			terminal.RejectAction += () => port.Reject(terminal);
		}

		public void UnBind(ITerminal terminal, IPort port)
		{
			if (terminal == null || port == null)
			{
				throw new ArgumentNullException();
			}

			terminal.CallAction += (number) => port.Call(terminal, number);
			terminal.AnswerAction += () => port.Answer(terminal);
			terminal.RejectAction += () => port.Reject(terminal);
		}
	}
}
