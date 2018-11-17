using System;
using System.Collections.Generic;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class Page : IPage
	{		
		public int Number { get; }
		public IList<ILine> Lines { get; }
		public int Size { get; }

		public Page(int number, int size)
		{
			if(size < 0)
			{
				throw new ArgumentException("Size page < 0");
			}
			if(number < 0)
			{
				throw new ArgumentException("Number page < 0");
			}

			Number = number;
			Size = size;
			Lines = new List<ILine>();
		}

		public bool Add(ILine line)
		{
			bool result = false;
			if(Lines.Count < Size)
			{
				if(line != null)
				{
					Lines.Add(line);
					result = true;
				}
			}
			return result;
		}

		public override string ToString()
		{
			string result = "";

			result += $"\n{Number}\n";
			foreach (var line in Lines)
			{
				result += line.ToString();
			}
			return result;
		}
	}
}
