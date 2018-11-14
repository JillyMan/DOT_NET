using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TextParser.Core;

namespace TextParser.Model
{
	public class Sentence : ISentence
	{
		public IList<IToken> Tokens { get; }

		public int Count
		{
			get
			{
				return Tokens.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return Tokens.IsReadOnly;
			}
		}

		public Sentence(IList<IToken> list)
		{
			Tokens = list;
		}	
	
		public void Add(IToken token)
		{
			if(token != null)
			{
				Tokens.Add(token);
			}
		}

		public bool Remove(IToken token)
		{
			if(token != null)
			{
				bool result = false;
				result = Tokens.Remove(token);
//				while () ;
				return result;
			}
			return false;
		}

		public void Clear()
		{
			Tokens.Clear();
		}

		public bool Contains(IToken item)
		{
			if(item != null)
			{
				return Tokens.Contains(item);
			}
			return false;
		}

		public void CopyTo(IToken[] array, int arrayIndex)
		{
			if(array != null && array.Length > 0)
			{
				Tokens.CopyTo(array, arrayIndex);
			}		
		}

		public IEnumerable<IWord> GetWords()
		{
			foreach(var word in Tokens)
			{
				if(word is IWord)
				{
					yield return (IWord)word;
				}
			}
		}

		public IEnumerable<IGap> GetGaps()
		{
			foreach (var gap in Tokens)
			{
				if (gap is IGap)
				{
					yield return (IGap)gap;
				}
			}
		}

		public IEnumerable<IPunctuationSign> GetPunctuation()
		{
			foreach (var punct in Tokens)
			{
				if (punct is IPunctuationSign)
				{
					yield return (IPunctuationSign)punct;
				}
			}
		}

		public IEnumerator<IToken> GetEnumerator()
		{
			return Tokens.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			string result = "";
			Tokens.ToList().ForEach(token => result += token.ToString());
			return result;
		}
	}
}