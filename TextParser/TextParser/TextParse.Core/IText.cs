using System.Collections.Generic;

namespace TextParser.Core
{
	public interface IText : ICollection<ISentence>
	{
		ISentence this[int index] { get; }
		IList<ISentence> Sentences { get; }
	}
}
