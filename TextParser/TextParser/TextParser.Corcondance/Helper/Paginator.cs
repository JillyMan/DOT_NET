using TextParser.Concordance;
using TextParser.Core.Concordance;
using TextParser.Core.Concordance.Hepler;

namespace TextParser.Corcondance.Paginator
{
	public class Paginator : IPaginator
	{
		public int LengthLine { get; }
		public int SizePage { get; }
		private int counterPage = 0;

		public Paginator(int lengthLine, int sizePage)
		{
			LengthLine = lengthLine;
			SizePage = sizePage;
		}

		public ILine GetLine()
		{			
			return new Line(LengthLine);
		}

		public IPage GetPage()
		{
			return new Page(++counterPage, SizePage);
		}

		public IPaginatedText GetPaginatedText()
		{
			return new PaginatedText();
		}
	}
}