using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.ATC
{
	public class Operator
	{
		private class AbonentInfo
		{
			public Abonent Abonent { get; }
			public int Number { get; }

			public AbonentInfo(Abonent abonent, int number)
			{
				Abonent = abonent;
				Number = number;
			}
		}

		private int _currentNumber;
		private IList<AbonentInfo> _abonents;

		public event Action<Abonent, int> RegisterInBilling;
		public event Action<Terminal> AddTerminal;
		
		public Operator()
		{
			_currentNumber = 0;
			_abonents = new List<AbonentInfo>();
		}

		public Abonent GetAbonentByNumber(int number)
		{
			var abonent = _abonents.FirstOrDefault(x => x.Number.Equals(number));
			if(abonent != null)
			{
				return abonent.Abonent;
			}
			return null;
		}

		public Terminal RegisterAbonent(Abonent abonent, int startBalance)
		{		
			if(AddTerminal == null)
			{
				throw new Exception("Need subcribe on event RegisterTerminal!");
			}

			Terminal terminal = new Terminal(++_currentNumber);	
			AddTerminal(terminal);
			_abonents.Add(new AbonentInfo(abonent, _currentNumber));
			RegisterInBilling(abonent, startBalance);

			return terminal;
		}
	}
}
