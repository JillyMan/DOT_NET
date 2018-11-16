using System.Collections.Generic;

namespace TextParser.Core.Concordance
{
	public interface IPage
	{
		int Number { get; }
		int Size { get; }
		IList<ILine> Lines { get; }
		bool Add(ILine line);
	}
}
