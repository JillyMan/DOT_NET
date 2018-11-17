namespace TextParser.Core.Concordance.Hepler
{
	public interface IConcordanceHelper
	{
		ILine GetLine();
		IPage GetPage();
		IPaginatedText GetPaginatedText();
	}
}
