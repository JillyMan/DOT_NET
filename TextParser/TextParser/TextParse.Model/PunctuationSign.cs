using System.Collections.Generic;
using TextParser.Core;

namespace TextParser.Model
{
    public class PunctuationSign : IPunctuationSign
    {
		public string Value { get ; set; }

		public int Length
		{
			get
			{
				return Value.Length;
			}
		}

		public PunctuationSign (string sign)
		{
			Value = sign;
		}
		
		public static bool operator == (PunctuationSign p1, PunctuationSign p2)
		{
			if (p1 is null || p2 is null)
			{
				return false;
			}
			return p1.Value.Equals(p2.Value);
		}

		public static bool operator !=(PunctuationSign p1, PunctuationSign p2)
		{
			return !(p1 == p2);
		}

		public override bool Equals(object obj)
		{
			if(obj is PunctuationSign)
			{
				return (this == (PunctuationSign)obj);
			}
			return false;
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public override int GetHashCode()
		{
			return -1937169414 + EqualityComparer<string>.Default.GetHashCode(Value);
		}
	}
}
