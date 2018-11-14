using TextParser.Core;

namespace TextParser.Model
{       
	public struct Token : IToken
	{
		public string Value { get; set; }

		public Token(string str)
		{
			Value = str;
		}

		public static bool operator == (Token s1, Token s2)
		{
			if (s1.Value == null || s2.Value == null)
			{
				return false;
			}
			return s1.Value.Equals(s2.Value);
		}

		public static bool operator != (Token s1, Token s2)
		{
			return !(s1 == s2);
		}

		public override string ToString()
		{
			return Value;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if(obj is Token)
			{
				return this == (Token)obj;
			}
			return false;
		}
	}
}
