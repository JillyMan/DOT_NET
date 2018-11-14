using System.Linq;
using System.Collections.Generic;
using System.Collections;
using TextParser.Core;

namespace TextParser.Model
{
	public class Text : IText
	{
		public IList<ISentence> Sentences { get; }

		public ISentence this[int index]
		{
			get
			{
				return Sentences[index];
			}
		}

		public int Count
		{
			get
			{
				return Sentences.Count;
			}
		}

		public bool IsReadOnly
		{
			get
			{
				return Sentences.IsReadOnly;
			}
		}

		public Text(IList<ISentence> list)
		{
			Sentences = list;
		}

		public void Add(ISentence sentence)
		{
			if(sentence != null)
			{
				Sentences.Add(sentence);
			}
		}

		public void Clear()
		{
			Sentences.Clear();
		}

		public bool Contains(ISentence item)
		{
			if(item != null)
			{
				return Sentences.Contains(item);
			}
			return false;
		}

		//TODO: Check bound of List
		public void CopyTo(ISentence[] array, int arrayIndex)
		{
			if(array != null && array.Length > 0)
			{
				Sentences.CopyTo(array, arrayIndex);
			}
		}

		public bool Remove(ISentence item)
		{
			if(item != null)
			{
				return Sentences.Remove(item);
			}
			return false;
		}

		public IEnumerator<ISentence> GetEnumerator()
		{
			return Sentences.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override string ToString()
		{
			string result = "";
			Sentences.ToList().ForEach((x) => result += x.ToString());
			return result;
		}
	}
}
