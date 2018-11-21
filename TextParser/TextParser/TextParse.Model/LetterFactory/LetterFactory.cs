using System.Collections.Generic;
using TextParser.Core.LetterFactory;

namespace TextParser.Model.LetterFactory
{
	public class LetterFactory : ILetterFactory<char>
	{
		private static IDictionary<char, TypeLetter> _letters;

		static LetterFactory()
		{
			_letters = new Dictionary<char, TypeLetter>();
			Init();
		}

		private static void Init()
		{
			_letters.Add('a', TypeLetter.Vowel);
			_letters.Add('e', TypeLetter.Vowel);
			_letters.Add('i', TypeLetter.Vowel);
			_letters.Add('o', TypeLetter.Vowel);
			_letters.Add('u', TypeLetter.Vowel);

			_letters.Add('b', TypeLetter.Consonant);
			_letters.Add('c', TypeLetter.Consonant);
			_letters.Add('d', TypeLetter.Consonant);
			_letters.Add('f', TypeLetter.Consonant);
			_letters.Add('g', TypeLetter.Consonant);
			_letters.Add('h', TypeLetter.Consonant);
			_letters.Add('j', TypeLetter.Consonant);
			_letters.Add('k', TypeLetter.Consonant);
			_letters.Add('l', TypeLetter.Consonant);
			_letters.Add('m', TypeLetter.Consonant);
			_letters.Add('n', TypeLetter.Consonant);
			_letters.Add('p', TypeLetter.Consonant);
			_letters.Add('q', TypeLetter.Consonant);
			_letters.Add('r', TypeLetter.Consonant);
			_letters.Add('s', TypeLetter.Consonant);
			_letters.Add('t', TypeLetter.Consonant);
			_letters.Add('v', TypeLetter.Consonant);
			_letters.Add('w', TypeLetter.Consonant);
			_letters.Add('x', TypeLetter.Consonant);
			_letters.Add('y', TypeLetter.Consonant);
			_letters.Add('z', TypeLetter.Consonant);
		}

		public TypeLetter GetSound(char letter)
		{
			return _letters[char.ToLower(letter)];
		}
		
		public bool IsLetter(char letter)
		{
			return _letters.ContainsKey(char.ToLower(letter));
		}
	}
}
