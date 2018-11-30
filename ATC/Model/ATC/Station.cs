using Core.ATC;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Model.ATC
{
	public class Station : IStation<Terminal>
	{
		private Queue<Port> _freePorts;
		public int CountPorts { get; }
		public int BusyPorts { get; private set; }

		public event Func<int, Abonent> GetAbonentByNumber;
		public event Action<Abonent, Abonent, int> CallCompleted;

		private IList<Tuple<Terminal, Terminal>> _currentCalls;
		private IDictionary<Terminal, Port> _portsTerminal;
		private IList<Tuple<Terminal, int>> _waitsResponse;

		public Station(int countPorts)
		{
			_portsTerminal = new Dictionary<Terminal, Port>();
			_currentCalls = new List<Tuple<Terminal, Terminal>>();//create class 
			_waitsResponse = new List<Tuple<Terminal, int>>();

			CountPorts = countPorts;

			Init();
		}

		public void Init()
		{
			_freePorts = new Queue<Port>(CountPorts);
			for(int i = 0; i < CountPorts; ++i)
			{
				Port port = new Port(i);
				BindPort(port);
				_freePorts.Enqueue(port);
			}
		}

		private void BindPort(Port port)
		{
			if (port == null)
			{
				throw new System.ArgumentNullException();
			}

			port.CallAction += Call;
			port.AnswerAction += Answer;
			port.RejectAction += Reject;
			port.AttachTerminalAction += AddTerminal;
			port.UnhookTerminalAction += RemoveTerminal;
		}

		private void BindTerminalWithPort(Terminal terminal)
		{
			if (terminal == null)
			{
				throw new ArgumentNullException();
			}

			if(_portsTerminal.ContainsKey(terminal))
			{
				throw new ArgumentException("Terminal now bind!");
			}

			if(_freePorts.Count <= 0)
			{
				throw new Exception("No free port");
			}

			Port port = _freePorts.Dequeue();
			port.Status = PortStatus.Online;
			terminal.CallAction += (number) => port.Call(terminal, number);
			terminal.AnswerAction += () => port.Answer(terminal);
			terminal.RejectAction += () => port.Reject(terminal);

			terminal.ConnectToPortAction += () => port.AttachTerminal(terminal);
			terminal.DisconnectAction += () => port.UnhookTerminaln(terminal);

			_portsTerminal.Add(terminal, port);

			++BusyPorts;
		}

		private void UnBindTerminalWithPort(Terminal terminal)
		{
			if (terminal == null)
			{
				throw new ArgumentNullException();
			}

			if (_freePorts.Count <= 0)
			{
				throw new Exception("Terminal not belong port!");
			}

			Port port = _portsTerminal[terminal];

			if(port == null)
			{
				throw new Exception("Port is null!?");
			}

			port.Status = PortStatus.Offline;
			terminal.CallAction -= (number) => port.Call(terminal, number);
			terminal.AnswerAction -= () => port.Answer(terminal);
			terminal.RejectAction -= () => port.Reject(terminal);

			terminal.ConnectToPortAction -= () => port.AttachTerminal(terminal);
			terminal.DisconnectAction -= () => port.UnhookTerminaln(terminal);

			_portsTerminal.Remove(terminal);
			_freePorts.Enqueue(port);
			--BusyPorts;
		}

		public void Call(Terminal terminal, int number)
		{
			if(GetAbonentByNumber == null)
			{
				throw new Exception("GetAbonentByNumber is null");
			}

			var abonent = GetAbonentByNumber(number);



			if(abonent == null)
			{
				throw new Exception("Such number not exist!");
			}
			Port p1 = _portsTerminal[terminal];
			p1.Status = PortStatus.Busy;

			_waitsResponse.Add(new Tuple<Terminal, int>(terminal, number));
		}

		public void Answer(Terminal terminal)
		{
			if(terminal != null)
			{
				var call = _waitsResponse.FirstOrDefault(x => x.Item2.Equals(terminal.Number));
				if (call != null)
				{
					Port p1 = _portsTerminal[terminal];
					p1.Status = PortStatus.Busy;

					_currentCalls.Add(new Tuple<Terminal, Terminal>(call.Item1, terminal));
					_waitsResponse.Remove(call);
				}
			}
		}

		public void Reject(Terminal terminal)
		{
			if(terminal != null)
			{
				var t = _currentCalls.FirstOrDefault(x => x.Item1.Equals(terminal) || x.Item2.Equals(terminal));
				if (t != null)
				{
					//mb change this!!?
					Port p1 = _portsTerminal[t.Item1];
					Port p2 = _portsTerminal[t.Item2];
					p1.Status = p2.Status = PortStatus.Online;

					Abonent a1 = GetAbonentByNumber(t.Item1.Number);
					Abonent a2 = GetAbonentByNumber(t.Item2.Number);
					Random random = new Random();
					int duration = random.Next(1000);
					//FAQ: Why random work bad!?
					//Console.WriteLine(duration);
					CallCompleted(a1, a2, duration);
					_currentCalls.Remove(t);
				}
			}
		}

		public void AddTerminal(Terminal terminal)
		{
			if(terminal != null)
			{
				BindTerminalWithPort(terminal);
			}
		}

		public void RemoveTerminal(Terminal terminal)
		{
			if(terminal != null)
			{
				UnBindTerminalWithPort(terminal);
			}
		}
	}
}