using System.Linq;
using TextParser.Core;
using TextParser.Core.LetterFactory;
using TextParser.Model.LetterFactory;

namespace TextParser.Model.Util
{
	public static class TextUtil
	{
		public static void RemoveWordsFirstConsonantLetter(this IText text, int length)
		{
			TokenLetter alphabet = new TokenLetter();

			for (int i = 0; i < text.Sentences.Count; ++i)
			{
				ISentence sentence = text.Sentences[i];
				var wordsForDelete = sentence
					.GetWords()
					.Where(x =>
						 x.Length == length &&
						 alphabet.IsLetter(x) &&
						 alphabet.GetSound(x) == TypeLetter.Consonant
					).ToList();

				wordsForDelete.ForEach(x => sentence.Remove(x));
			}
		}

		public static void ReplaceWordsInSentence(this IText text, int index, int length, string subString)
		{
			if (text.Count >= index)
			{
				ISentence sentence = text[index];
				var words = sentence.GetWords().Where(x => x.Length == length).ToList();
				words.ForEach(x => x.Value = subString);				
			}
		}
	}
}
