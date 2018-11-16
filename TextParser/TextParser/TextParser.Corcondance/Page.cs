using System.Collections.Generic;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class Page : IPage
	{		
		public int Number { get; }
		public IList<ILine> Lines { get; }
		public int Size { get; }

		public Page(int number, int size, IList<ILine> lines)
		{
			Number = number;
			Size = size < 0 ? 0 : size;
			Lines = lines;
		}

		public bool Add(ILine line)
		{
			bool result = false;
			if(Lines.Count <= Size)
			{
				if(line != null)
				{
					Lines.Add(line);
					result = true;
				}
			}
			return result;
		}
	}
}
