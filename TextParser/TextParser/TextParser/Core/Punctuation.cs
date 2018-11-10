using System.Collections.Generic;

namespace TextParser.Core
{
    public class Punctuation
    {
		public Simbol Sign { get; set; }

		public Punctuation (Simbol sign)
		{
			Sign = sign;
		}

		public override string ToString()
		{
			return Sign.ToString();
		}

		public static bool operator == (Punctuation p1, Punctuation p2)
		{
			if(p1 is null)
			{
				return false;
			}

			if(p2 is null)
			{
				return false;
			}

			return p1.Sign.Equals(p2.Sign);
		}

		public static bool operator !=(Punctuation p1, Punctuation p2)
		{
			return !(p1 == p2);
		}

		public override bool Equals(object obj)
		{
			var punctuation = obj as Punctuation;
			return punctuation != null &&
				   EqualityComparer<Simbol>.Default.Equals(Sign, punctuation.Sign);
		}

		public override int GetHashCode()
		{
			return 675013463 + EqualityComparer<Simbol>.Default.GetHashCode(Sign);
		}
	}
}
