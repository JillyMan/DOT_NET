using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextParser.Core
{
    public class Word
    {
		public IList<Simbol> Simbols { get; }

		public Word(IList<Simbol> simbols)
		{
			Simbols = simbols;
		}

		public static bool operator ==(Word w1, Word w2)
		{
			if (w1 is null)
			{
				return false;
			}

			if (w2 is null)
			{
				return false;
			}

			if (w1.Simbols.Count != w2.Simbols.Count)
			{
				return false;
			}

			return EqualityComparer<IList<Simbol>>.Default.Equals(w1.Simbols, w2.Simbols);
		}

		public static bool operator != (Word w1, Word w2)
		{
			return !(w1 == w2);
		}

		public override bool Equals(object obj)
		{
			var word = obj as Word;
			return word != null &&
				   EqualityComparer<IList<Simbol>>.Default.Equals(Simbols, word.Simbols);
		}

		public override int GetHashCode()
		{
			return 1528510566 + EqualityComparer<IList<Simbol>>.Default.GetHashCode(Simbols);
		}

		public override string ToString()
		{
			string result = "";

			foreach(var s in Simbols)
			{
				result += s.simbol;
			}

			return result;
		}

	}
}
