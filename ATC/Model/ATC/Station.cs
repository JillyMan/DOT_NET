using Core.ATC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.ATC
{
	public class Station : IStation
	{
		public event Action<ITerminal, ITerminal> CallCompleted;

		private IList<ITerminal> _connectionTerminal;
		private IList<Tuple<ITerminal, ITerminal>> _currentCalls;
		private IList<Tuple<ITerminal, string>> _waitsResponse;

		public Station()
		{
			_connectionTerminal = new List<ITerminal>();
			_currentCalls = new List<Tuple<ITerminal, ITerminal>>();
			_waitsResponse = new List<Tuple<ITerminal, string>>();
		}

		public void Call(ITerminal terminal, string number)
		{
			if(terminal != null || string.IsNullOrEmpty(number))
			{
				_waitsResponse.Add(new Tuple<ITerminal, string>(terminal, number));
			}
		}

		public void Answer(ITerminal terminal)
		{
			if(terminal != null)
			{
				var t = _waitsResponse.FirstOrDefault(x => x.Item2.Equals(terminal.Number));
				if (t != null)
				{
					_currentCalls.Add(new Tuple<ITerminal, ITerminal>(t.Item1, terminal));
					_waitsResponse.Remove(t);
				}
			}
		}

		public void Reject(ITerminal terminal)
		{
			if(terminal != null)
			{
				var t = _currentCalls.FirstOrDefault(x => x.Item1.Equals(terminal) || x.Item2.Equals(terminal));

				if (t != null)
				{
					CallCompleted(t.Item1, t.Item2);
					_currentCalls.Remove(t);
				}
			}
		}

		public void AddTerminal(ITerminal terminal)
		{
			if(terminal != null)
			{
				_connectionTerminal.Add(terminal);
			}
		}

		public void RemoveTerminal(ITerminal terminal)
		{
			if(terminal != null)
			{
				_connectionTerminal.Remove(terminal);
			}
		}
	}
}