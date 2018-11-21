namespace TextParser.Core.Concordance.Hepler
{
	public interface IPaginator
	{
		ILine GetLine();
		IPage GetPage();
		IPaginatedText GetPaginatedText();
	}
}
