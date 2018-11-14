using System.Linq;
using System.Collections.Generic;
using TextParser.Core;

namespace TextParser.Model.Util
{
	public static class WordUtil
	{
		public static IEnumerable<IWord> GetWordByLength(this IList<IWord> words, uint length)
		{
			return words.Where(x => x.Length == length);
		}
	}
}
