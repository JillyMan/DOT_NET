using System.Linq;
using System.Collections.Generic;

namespace TextParser.Core.Util
{
	public static class TextUtil
	{
		public static void RemoveWordFirstConsonantLetter(this Text text)
		{
			CustomLetterFactory alphabet = new CustomLetterFactory();

			for (int i = 0; i < text.Sentences.Count; ++i)
			{
				Sentence sentence = text.Sentences[i];
				List<Word> wordsForDelete = new List<Word>();

				for (int j = 0; j < sentence.CountWord; ++j)
				{
					var s = sentence.Words.ToArray()[j];

					if (alphabet.IsConsonantLetter(s[0]))
					{
						wordsForDelete.Add(s);
					}
				}
				wordsForDelete.ForEach(x => sentence.RemoveWord(x));
			}
		}

		public static void ChangeWordsInSentence(this Text text, int numberSentence, int length, string subString)
		{
			if (text.CountSentences >= numberSentence)
			{
				Sentence sentence = text[numberSentence];

				var list = sentence.Words
									.Where(x => x.Length == length)
									.ToList();

				foreach (var s in list)
				{
					sentence.ChangeWord(s, Word.Parse(subString));
				}
			}
		}
	}
}
