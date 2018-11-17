using System.Collections.Generic;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class PaginatedText : IPaginatedText
	{
		public IList<IPage> Pages { get; }

		public PaginatedText()
		{
			Pages = new List<IPage>();
		}
		
		public void Add(IPage page)
		{
			if(page != null)
			{
				Pages.Add(page);
			}
		}
		public override string ToString()
		{
			string result = "";

			foreach(var page in Pages)
			{
				result += page.ToString();
			}
	
			return result;
		}

	}
}
