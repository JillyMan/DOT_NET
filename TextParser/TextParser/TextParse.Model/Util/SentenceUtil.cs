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
			IPunctuationSign sign = new PunctuationSign("?");
			var questionSentences = sentence.Where(x => x.Last() == sign);

			ISet<IWord> set = new HashSet<IWord>();

			foreach (var s in questionSentences)
			{
				var words = s.GetWords().Where(x => x.Length == length).ToList();
				words.ForEach(x => set.Add(x));
			}
			return set;
		}
				
		public static void Normalize(this IText text)
		{
			foreach (var sentences in text.Sentences)
			{
				var gaps = sentences.GetGaps();

				foreach (IToken gap in gaps)
				{
					if (gap.Equals("\t"))
					{
						gap.Value = " ";
					}

					if (!gap.Equals('\n'))
					{
						gap.Value = " ";
					}
				}
			}
		}
	}
}
