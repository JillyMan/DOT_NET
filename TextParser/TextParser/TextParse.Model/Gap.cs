using System.Collections.Generic;
using TextParser.Core;

namespace TextParser.Model
{
	public class Gap : IGap
	{
		public string Value { get; set; }

		public Gap(string str)
		{
			Value = str;
		}

		public static bool operator ==(Gap p1, Gap p2)
		{
			if(p1 is null || p2 is null)
			{
				return false;
			}
			return p1.Value.Equals(p2.Value);
		}

		public static bool operator !=(Gap p1, Gap p2)
		{
			return !(p1 == p2);
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public override bool Equals(object obj)
		{
			if(obj is Gap)
			{
				return (this == (Gap)obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
		}
	}
}
