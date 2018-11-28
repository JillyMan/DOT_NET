using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public class Abonent : IClient
	{
		public string FirstName { get; }
		public string LastName { get; }

		public Abonent(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}

	}
}
