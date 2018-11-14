using System.Collections.Generic;
using TextParser.Core.LetterFactory;

namespace TextParser.Model.LetterFactory
{
	public class SignFactory : ISignFactory<string>
	{
		private static ISet<string> _endSentence;
		private static ISet<string> _spacesSymbol;
		private static ISet<string> _separativeSymbol;

		private static SignFactory _instance = null;
		private static object _syncObject = new object();

		public static SignFactory Instance
		{
			get
			{
				if(_instance == null)
				{
					lock(_syncObject)
					{
						if(_instance == null)
						{
							_instance = new SignFactory();
						}
					}
				}
				return _instance;
			}
		}

		private SignFactory()
		{
		}

		static SignFactory()
		{
			_endSentence = new HashSet<string>();
			_spacesSymbol = new HashSet<string>();
			_separativeSymbol = new HashSet<string>();

			Init();
		}

		private static void Init()
		{
			_endSentence.Add(".");
			_endSentence.Add("..");
			_endSentence.Add("...");
			_endSentence.Add("?");
			_endSentence.Add("!");
			_endSentence.Add("!?");
			_endSentence.Add("?!");
			_endSentence.Add(";");

			_spacesSymbol.Add(" ");
			_spacesSymbol.Add("\n");
			_spacesSymbol.Add("\t");


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

		public bool IsQuestion(string sign)
		{
			return sign.Equals("?");
		}

		public bool IsSeparative(string sign)
		{
			return _separativeSymbol.Contains(sign);
		}

		public bool IsSpaces(string sign)
		{
			return _spacesSymbol.Contains(sign);
		}
	}
}
