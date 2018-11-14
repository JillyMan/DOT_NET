using System.Collections.Generic;

namespace TextParser.Core
{
    public interface IWord : IToken
	{
		char this[int index] { get; }
		int Length { get; }
	}
}
