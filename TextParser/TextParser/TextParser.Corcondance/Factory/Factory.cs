using System.Collections.Generic;
using TextParser.Concordance;
using TextParser.Core;
using TextParser.Core.Concordance;

namespace TextParser.Corcondance.Factory
{
	public class Factory : Core.Concordance.Factory.IFactory
	{
		public int LengthLine { get; }
		public int SizePage { get; }
		private int counterPage = 0;

		public Factory(int lengthLine, int sizePage)
		{
			LengthLine = lengthLine;
			SizePage = sizePage;
		}

		public ILine GetLine()
		{			
			return new Line(LengthLine, new List<IToken>());
		}

		public IPage GetPage()
		{
			return new Page(++counterPage, SizePage, new List<ILine>());
		}

		public IPaginatedText GetPaginatedText()
		{
			return new PaginatedText(new List<IPage>());
		}
	}
}
