using System.Linq;
using System.Collections.Generic;
using TextParser.Core;

namespace TextParser.Model.Util
{
    public static class SentenceUtil
    {
		public static IEnumerable<ISentence> SortByWordCount(this IList<ISentence> sentences)
		{
			var result = from s in sentences
						 orderby s.GetWords().Count()
						 select s;
			return result;
		}

		public static IEnumerable<IWord> QuestionSentenceByWordLength(this IList<ISentence> sentence, int length)
		{
			var sign = new PunctuationSign("?");
			var questionSentences = sentence.Where(x => sign.Equals(x.Last()));

			ISet<IWord> set = new HashSet<IWord>();

			foreach (var s in questionSentences)
			{
				var words = s.GetWords().Where(x => x.Length == length).ToList();
				words.ForEach(x => set.Add(x));
			}
			return set;
		}
	}
}
