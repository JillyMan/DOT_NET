using System;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core.Util
{
    public abstract class LetterDictionary<T>
	{
		protected readonly ISet<char> _consonantLetter;
		protected readonly ISet<char> _vowels;

		public LetterDictionary()
		{
			_consonantLetter = new HashSet<char>();
			_vowels = new HashSet<char>();
			Init();
		}

		private void Init()
		{
			_vowels.Add('a');
			_vowels.Add('e');
			_vowels.Add('i'); 
			_vowels.Add('o');
			_vowels.Add('u');

			_consonantLetter.Add('b'); 
			_consonantLetter.Add('c'); 
			_consonantLetter.Add('d'); 
			_consonantLetter.Add('f'); 
			_consonantLetter.Add('g'); 
			_consonantLetter.Add('h'); 
			_consonantLetter.Add('j'); 
			_consonantLetter.Add('k'); 
			_consonantLetter.Add('l'); 
			_consonantLetter.Add('m'); 
			_consonantLetter.Add('n'); 
			_consonantLetter.Add('p'); 
			_consonantLetter.Add('q'); 
			_consonantLetter.Add('r'); 
			_consonantLetter.Add('s'); 
			_consonantLetter.Add('t'); 
			_consonantLetter.Add('v'); 
			_consonantLetter.Add('w'); 
			_consonantLetter.Add('x'); 
			_consonantLetter.Add('y'); 
			_consonantLetter.Add('z');
		}

		public abstract bool IsConsonantLetter(T letter);

		public abstract bool IsVowels(T letter);
	}
}
