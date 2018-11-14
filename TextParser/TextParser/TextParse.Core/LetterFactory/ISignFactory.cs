using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextParser.Core.LetterFactory
{
	public interface ISignFactory<T>
	{
		bool IsEnd(T sign);
		bool IsSpaces(T sign);
		bool IsSeparative(T sign);
		bool IsQuestion(T sign);
	}
}
