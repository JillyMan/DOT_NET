using System.Collections.Generic;

namespace TextParser.Core.Concordance
{
	public interface ILine
	{
		int Counter { get; }
		int MaxLength { get; }
		bool Add(IToken token);
		IList<IToken> Tokens { get; }
	}
}
