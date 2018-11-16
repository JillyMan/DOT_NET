using System.Collections.Generic;

namespace TextParser.Core.Concordance
{
	public interface IPaginatedText
	{
		void Add(IPage page);
		IList<IPage> Pages { get; }
	}
}
