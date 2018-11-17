using System.Collections.Generic;

namespace TextParser.Core.Concordance
{
	public interface IPage
	{
		int Number { get; }
		int Size { get; }
		bool Add(ILine line);
		IList<ILine> Lines { get; }
	}
}
