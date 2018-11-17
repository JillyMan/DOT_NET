using System.Collections.Generic;
using TextParser.Core;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class Line : ILine
	{
		public int Counter { get; private set; }
		public int MaxLength { get; }
		public IList<IToken> Tokens { get; }

		public Line(int maxLength)
		{
			Counter = 0;
			Tokens = new List<IToken>();
			MaxLength = maxLength;
		}

		public bool Add(IToken token)
		{
			bool result = false;
			if (token != null)
			{
				int lengthToken = token.Value.Length;
				if (Counter + lengthToken <= MaxLength)
				{
					Counter += lengthToken;
					Tokens.Add(token);
					result = true;
				}

			}
			return result;
		}

		public override string ToString()
		{
			string result = "";

			foreach (var token in Tokens)
			{
				result += token.ToString();
			}
			result += "\n";
			return result;
		}
	}
}