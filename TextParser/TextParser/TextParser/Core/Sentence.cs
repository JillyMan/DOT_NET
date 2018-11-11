using System;
using System.Collections.Generic;
using System.Linq;

namespace TextParser.Core
{
    public class Sentence
    {
		private int _counter;
	
		private IDictionary<Word, IList<int>> _wordPosition;
		private IDictionary<Punctuation, IList<int>> _signPosition;

		public ICollection<Word> Words
		{
			get
			{
				return _wordPosition.Keys;
			}
		}

		public ICollection<Punctuation> Signs
		{
			get
			{
				return _signPosition.Keys;
			}
		}

		public int CountWord
		{
			get
			{
				int result = 0;
				_wordPosition.Values.ToList().ForEach(x => result += x.Count);
				return result;
			}
		}

		public int CountSign
		{
			get
			{
				int result = 0;
				_signPosition.Values.ToList().ForEach(x => result += x.Count);
				return result;
			}
		}

		public IDictionary<Word, IList<int>> WordsPositions
		{
			get
			{
				return _wordPosition;
			}
		}

		public IDictionary<Punctuation, IList<int>> SignsPositions
		{
			get
			{
				return _signPosition;
			}
		}
	
		public Sentence()
		{
			_wordPosition = new Dictionary<Word, IList<int>>();
			_signPosition = new Dictionary<Punctuation, IList<int>>();
		}

		public void RemoveWord(Word word)
		{
			if(word != null)
			{
				if(_wordPosition.ContainsKey(word))
				{
					int indexInSentence = _wordPosition[word].First();
					int countRepeatInSentence = _wordPosition[word].Count;
					_counter -= countRepeatInSentence;

					_wordPosition.Remove(word);
					Remove(indexInSentence, countRepeatInSentence);
				}
			}
		}

		public void RemoveSign(Punctuation sign)
		{
			if (sign != null)
			{
				if (_signPosition.ContainsKey(sign))
				{
					int indexInSentence = _signPosition[sign].First();
					int countRepeatInSentence = _signPosition[sign].Count;
					_counter -= countRepeatInSentence;

					_signPosition.Remove(sign);
					Remove(indexInSentence, countRepeatInSentence);
				}
			}
		}

		private void Remove(int indexInSentence, int countRepeatInSentence)
		{
			ICollection<IList<int>> collectionPosWords = _wordPosition.Values;
			ICollection<IList<int>> collectionPosSigns = _signPosition.Values;
			var sentence = collectionPosWords.Union(collectionPosSigns).ToList();

			sentence.ForEach((x) =>
			{
				for (int i = 0; i < x.Count; ++i)
				{
					if (x[i] > indexInSentence)
					{
						x[i] -= countRepeatInSentence;
					}
				}
			});
		}

		public void AddWord(Word word)
		{
			if (word != null)
			{
				if (_wordPosition.ContainsKey(word))
				{
					_wordPosition[word].Add(_counter++);
				}
				else
				{
					_wordPosition.Add(word, new List<int>() { _counter++ });
				}
			}
		}

		public void AddPunctuationSign(Punctuation sign)
		{
			if (sign != null)
			{
				if (_signPosition.ContainsKey(sign))
				{
					_signPosition[sign].Add(_counter++);
				}
				else
				{
					_signPosition.Add(sign, new List<int>() { _counter++ });
				}
			}
		}

		public void Clear()
		{
			_signPosition.Clear();
			_wordPosition.Clear();
		}

		public override string ToString()
		{
			string[] elements = new string[_counter];

			foreach(var word in _wordPosition.Keys)
			{
				foreach (var index in _wordPosition[word])
				{
					elements[index] = word.ToString();
				}
			}

			foreach (var sign in _signPosition.Keys)
			{
				foreach (var index in _signPosition[sign])
				{
					elements[index] = sign.ToString();
				}
			}

			return String.Join("",elements);
		}

		public void ChangeWord(Word source, Word other)
		{
			if(source != null && other != null)
			{
				_wordPosition.Add(other, _wordPosition[source]);
				_wordPosition.Remove(source);
			}
		}
	}
}
