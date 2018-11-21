using System;
using TextParser.Core;
using TextParser.Core.LetterFactory;
using TextParser.Core.Concordance;
using TextParser.Core.Concordance.Hepler;
using TextParser.Core.Parser;

namespace TextParser.Parser
{
	public class PageParser : IParser<IText, IPaginatedText>
	{
		private IPaginator _helper;
		private ISignFactory<IToken> _signFactory; 

		private IPage _currentPage;
		private ILine _currentLine;
		private IPaginatedText _paginatedText;

		public PageParser(IPaginator helper, ISignFactory<IToken> signFactory)
		{
			_helper = helper;
			_signFactory = signFactory;
		}

		public IPaginatedText Parse(IText text)
		{
			_paginatedText = _helper.GetPaginatedText();
			_currentPage = _helper.GetPage();
			_currentLine = _helper.GetLine();

			foreach (ISentence sentence in text.Sentences)
			{
				foreach (IToken token in sentence)
				{
					if(token.Length > _currentLine.MaxLength)
					{
						throw new Exception("Token ->" + token + " very long!!");
					}
					AddToken(token);					
				}
			}
		
			AddLine(_currentLine);				
			AddPage(_currentPage);

			return _paginatedText;
		}

		private void AddToken(IToken token)
		{
			if (!_currentLine.Add(token) || _signFactory.IsNewLine(token))
			{
				AddLine(_currentLine);
				_currentLine = _helper.GetLine();
				_currentLine.Add(token);
			}
		}

		private void AddLine(ILine line)
		{
			if(line.Counter > 0)
			{
				if (!_currentPage.Add(line))
				{
					AddPage(_currentPage);
					_currentPage = _helper.GetPage();
					_currentPage.Add(line);
				}
			}
		}

		private void AddPage(IPage page)
		{
			if(page.Lines.Count > 0)
			{
				_paginatedText.Add(page);
			}
		}
	}
}
