using System.Collections.Generic;
using TextParser.Core.LetterFactory;

namespace TextParser.Model.LetterFactory
{
	public class SignFactory : ISignFactory<string>
	{
		private static ISet<string> _endSentence;
		private static ISet<string> _spacesSymbol;
		private static ISet<string> _separativeSymbol;
		private static ISet<string> _newLineSymbol;

		static SignFactory()
		{
			_endSentence = new HashSet<string>();
			_spacesSymbol = new HashSet<string>();
			_separativeSymbol = new HashSet<string>();
			_newLineSymbol = new HashSet<string>();

			Init();
		}

		private static void Init()
		{
			_endSentence.Add(".");
			_endSentence.Add(". ");
			_endSentence.Add("..");
			_endSentence.Add(".. ");
			_endSentence.Add("...");
			_endSentence.Add("... ");
			_endSentence.Add("?");
			_endSentence.Add("!");
			_endSentence.Add("!?");
			_endSentence.Add("?!");
			_endSentence.Add(";");

			_spacesSymbol.Add(" ");

			_newLineSymbol.Add("\n");

			_separativeSymbol.Add("//");
			_separativeSymbol.Add("/*");
			_separativeSymbol.Add("*/");
			_separativeSymbol.Add(",");
			_separativeSymbol.Add(", ");
			_separativeSymbol.Add(":");
			_separativeSymbol.Add("{");
			_separativeSymbol.Add("}");
			_separativeSymbol.Add("]");
			_separativeSymbol.Add("[");
			_separativeSymbol.Add("-");
		}

		public bool IsEnd(string sign)
		{
			return _endSentence.Contains(sign);
		}

		public bool IsNewLine(string sign)
		{
			return _newLineSymbol.Contains(sign);
		}

		public bool IsQuestion(string sign)
		{
			return sign.Equals("?");
		}

		public bool IsSeparator(string sign)
		{
			return _separativeSymbol.Contains(sign);
		}


		public bool IsSpaces(string sign)
		{
			return _spacesSymbol.Contains(sign);
		}
	}
}
