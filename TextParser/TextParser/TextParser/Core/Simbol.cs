using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core
{
   public struct Simbol
	{
		public string simbol;

		public Simbol(string str)
		{
			simbol = str;
		}

		public static bool operator == (Simbol s1, Simbol s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(Simbol s1, Simbol s2)
		{
			return !(s1 == s2);
		}

		public override string ToString()
		{
			return simbol;
		}

		public override bool Equals(object obj)
		{
			if(!(obj is Simbol))
			{
				return false;
			}
			Simbol s = (Simbol)obj;
			return simbol.Equals(s.simbol);
		}

		public override int GetHashCode()
		{
			var hashCode = -327816607;
			hashCode = hashCode * -1521134295 + base.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(simbol);
			return hashCode;
		}
	}
}
