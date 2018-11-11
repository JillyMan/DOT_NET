using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core.Util
{
	public class CustomLetterFactory : LetterDictionary<Simbol>
	{
		public override bool IsConsonantLetter(Simbol simbol)
		{
			string str = simbol.simbol;
			if (str.Length == 1)
			{
				char[] letter=  str.ToCharArray();
				return _consonantLetter.Contains(char.ToLower(letter[0]));
			}
			return false;
		}

		public override bool IsVowels(Simbol simbol)
		{
			string str = simbol.simbol;
			if (str.Length == 1)
			{
				char[] letter = str.ToCharArray();
				return _vowels.Contains(char.ToLower(letter[0]));
			}
			return false;
		}
	}
}
