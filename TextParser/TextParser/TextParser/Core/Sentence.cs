using System;
using System.Collections.Generic;
using System.Linq;

namespace TextParser.Core
{
    public class Sentence
    {
		private uint _counter;

		private IDictionary<Word, IList<uint>> _wordCount;
		private IDictionary<Punctuation, IList<uint>> _signCount;

		public IDictionary<Word, IList<uint>> WordsCount
		{
			get
			{
				return _wordCount;
			}
		}

		public IDictionary<Punctuation, IList<uint>> SignCount
		{
			get
			{
				return _signCount;
			}
		}
	
		public Sentence()
		{
			_wordCount = new Dictionary<Word, IList<uint>>();
			_signCount = new Dictionary<Punctuation, IList<uint>>();

		}

		public void AddWord(Word word)
		{
			if (word != null)
			{
				if (_wordCount.ContainsKey(word))
				{
					_wordCount[word].Add(_counter++);
				}
				else
				{
					_wordCount.Add(word, new List<uint>() { _counter++ });
				}
			}
		}

		public void AddPunctuationSign(Punctuation sign)
		{
			if (sign != null)
			{
				if (_signCount.ContainsKey(sign))
				{
					_signCount[sign].Add(_counter++);
				}
				else
				{
					_signCount.Add(sign, new List<uint>() { _counter++ });
				}
			}
		}

		public override string ToString()
		{
			string[] elements = new string[_counter];

			foreach(var word in _wordCount.Keys)
			{
				foreach (var index in _wordCount[word])
				{
					elements[index] = word.ToString();
				}
			}

			foreach (var sign in _signCount.Keys)
			{
				foreach (var index in _signCount[sign])
				{
					elements[index] = sign.ToString();
				}
			}

			return String.Join("",elements);
		}
	}
}
