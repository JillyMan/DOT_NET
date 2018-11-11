using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core.Util
{
	public static class WordUtil
	{


		public static IEnumerable<Word> GetWordByLength(this IList<Word> words, uint lenght)
		{
			var result = from w in words
						 where w.Simbols.Count == lenght
						 select w;
			return result;
		}
	}
}
