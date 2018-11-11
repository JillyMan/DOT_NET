using System.Linq;
using System.Collections.Generic;

namespace TextParser.Core.Util
{
    public static class SentenceUtil
    {
		public static IEnumerable<Sentence> SortByWord(this IList<Sentence> sentences)
		{
			var result = from s in sentences
						 orderby s.CountWord
						 select s;
			return result;
		}

		public static IEnumerable<Sentence> InterrogativeSentence(this IList<Sentence> sentence)
		{
			Punctuation sign = new Punctuation(new Simbol("?"));
			var result = from s in sentence
						 where s.SignsPositions.ContainsKey(sign)
						 select s;
			return result;
		}
	}
}
