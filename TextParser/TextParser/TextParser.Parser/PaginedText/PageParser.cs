using TextParser.Core;
using TextParser.Core.Concordance;
using TextParser.Core.Parser;

namespace TextParser.Parser
{
	public class PageParser : IParser<IText, IPaginatedText>
	{
		Core.Concordance.Factory.IFactory _factory;

		public PageParser(Core.Concordance.Factory.IFactory factory)
		{
			_factory = factory;
		}

		//TODO: What If token very long?;
		public IPaginatedText Parse(IText text)
		{
			IPaginatedText paginatedText = _factory.GetPaginatedText();
			IPage currentPage = _factory.GetPage();
			ILine currentLine = _factory.GetLine();

			foreach (ISentence sentence in text.Sentences)
			{
				foreach (IToken token in sentence)
				{
//					if(|| token.Value.Equals("\n"))
					if (!currentLine.Add(token))
					{
						if (!currentPage.Add(currentLine))
						{
							paginatedText.Add(currentPage);
							currentPage = _factory.GetPage();

						}

						currentPage.Add(currentLine);
						currentLine = _factory.GetLine();
						currentLine.Add(token);
					}
				}
			}

			if (!currentPage.Add(currentLine))
			{
				paginatedText.Add(currentPage);
				currentPage = _factory.GetPage();
				currentPage.Add(currentLine);
			}
			paginatedText.Add(currentPage);

			return paginatedText;
		}

	}
}
