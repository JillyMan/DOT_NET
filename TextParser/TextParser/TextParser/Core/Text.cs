using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core
{
	public class Text
	{
		public IList<Sentence> Sentences { get; }

		public Sentence this[int index]
		{
			get
			{
				return Sentences[index];
			}
		}

		public int CountSentences
		{
			get
			{
				return Sentences.Count;
			}
		}

		public Text()
		{
			Sentences = new List<Sentence>();
		}

		public void AddSentence(Sentence sentence)
		{
			if(sentence != null)
			{
				Sentences.Add(sentence);
			}
		}

		public override string ToString()
		{
			string result = "";
			Sentences.ToList().ForEach((x) => result += x.ToString());			
			return result;
		}
	}
}
