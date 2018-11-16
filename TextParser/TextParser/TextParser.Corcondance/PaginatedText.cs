using System;
using System.Collections.Generic;
using System.Linq;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class PaginatedText : IPaginatedText
	{
		public IList<IPage> Pages { get; }

		public PaginatedText(IList<IPage> pages)
		{
			Pages = pages;
		}
		
		public void Add(IPage page)
		{
			if(page != null)
			{
				Pages.Add(page);
			}
		}
	}
}
