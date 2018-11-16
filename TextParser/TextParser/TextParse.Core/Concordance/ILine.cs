using System.Collections.Generic;

namespace TextParser.Core.Concordance
{
	public interface ILine
	{
		int Counter { get; }
		int MaxLength { get; }
		IList<IToken> Tokens { get; }
		bool Add(IToken token);
	}
}
