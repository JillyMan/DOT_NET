using System.Collections.Generic;

namespace TextParser.Core
{
	public interface ISentence : ICollection<IToken>
	{
		IList<IToken> Tokens { get; }
		IEnumerable<IWord> GetWords();
	}
}
