using System.Linq;
using System.Collections.Generic;
using TextParser.Core;

namespace TextParser.Model
{
    public class Word : IWord 
    {
		public string Value { get; set; }

		public int Length
		{
			get
			{
				return Value.Length;
			}
		}

		public char this[int i]
		{
			get
			{
				return Value[i];
			}
		}
		
		public Word(string word)
		{
			Value = word;
		}

		public IToken GetFirstToken()
		{
			return new Token(Value.First().ToString());
		}

		public static bool operator == (Word w1, Word w2)
		{
			if (w1 is null || w2 is null)
			{
				return false;
			}
			return w1.Value.Equals(w2.Value);
		}

		public static bool operator != (Word w1, Word w2)
		{
			return !(w1 == w2);
		}

		public override bool Equals(object obj)
		{
			if (obj is Word)
			{
				return this == (Word)obj;
			}
			return false;
		}

		public override string ToString()
		{
			return Value;
		}

		public override int GetHashCode()
		{
			var hashCode = 1491549487;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Value);
			hashCode = hashCode * -1521134295 + Length.GetHashCode();
			return hashCode;
		}
	}
}
