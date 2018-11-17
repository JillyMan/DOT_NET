using System;
using TextParser.Core;
using TextParser.Core.Concordance;
using TextParser.Core.Concordance.Hepler;
using TextParser.Core.Parser;

namespace TextParser.Parser
{
	public class PageParser : IParser<IText, IPaginatedText>
	{
		private IConcordanceHelper _helper;

		private IPage _currentPage;
		private ILine _currentLine;
		private IPaginatedText _paginatedText;

		public PageParser(IConcordanceHelper helper)
		{
			_helper = helper;
			_paginatedText = _helper.GetPaginatedText();
			_currentPage = _helper.GetPage();
			_currentLine = _helper.GetLine();
		}

		public IPaginatedText Parse(IText text)
		{
			foreach (ISentence sentence in text.Sentences)
			{
				foreach (IToken token in sentence)
				{
					if(token.Length > _currentLine.MaxLength)
					{
						throw new System.Exception("Token ->" + token + " very long!!");
					}

					AddInLine(token);
				}
			}
		
			if(_currentLine.Counter > 0)
			{
				AddInPage();
				_paginatedText.Add(_currentPage);
			} 
			else if(_currentPage.Lines.Count > 0)
			{
				_paginatedText.Add(_currentPage);
				_currentPage = _helper.GetPage();
				_currentPage.Add(_currentLine);

				_paginatedText.Add(_currentPage);
			}

			return _paginatedText;
		}

		private void AddInPage()
		{
			if (!_currentPage.Add(_currentLine))
			{
				_paginatedText.Add(_currentPage);
				_currentPage = _helper.GetPage();
				_currentPage.Add(_currentLine);
			}
		}

		private void AddInLine(IToken token)
		{
			if (!_currentLine.Add(token) || token.Value.Equals("\n"))
			{
				AddInPage();
				_currentLine = _helper.GetLine();
				_currentLine.Add(token);
			}
		}
	}
}
