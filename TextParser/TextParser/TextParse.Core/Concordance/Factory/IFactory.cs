namespace TextParser.Core.Concordance.Factory
{
	public interface IFactory
	{
		ILine GetLine();
		IPage GetPage();
		IPaginatedText GetPaginatedText();
	}
}
