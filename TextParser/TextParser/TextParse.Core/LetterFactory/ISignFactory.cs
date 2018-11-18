namespace TextParser.Core.LetterFactory
{
	public interface ISignFactory<T>
	{
		bool IsEnd(T sign);
		bool IsSpaces(T sign);
		bool IsSeparator(T sign);
		bool IsQuestion(T sign);
		bool IsNewLine(T sign);
	}
}
