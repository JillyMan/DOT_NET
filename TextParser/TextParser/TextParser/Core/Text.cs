using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TextParser.Core
{
    public class Text
    {
		public IList<Sentence> Sentences { get; }

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
