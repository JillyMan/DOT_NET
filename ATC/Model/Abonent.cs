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

		public override bool Equals(object obj)
		{
			if (obj is Abonent a)
			{
				return FirstName.Equals(a.FirstName) &&
					LastName.Equals(a.LastName);
			}
			return false;
		}

		public override string ToString()
		{
			return FirstName + " " + LastName;
		}

		public override int GetHashCode()
		{
			var hashCode = -1531887941;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
			return hashCode;
		}
	}
}
