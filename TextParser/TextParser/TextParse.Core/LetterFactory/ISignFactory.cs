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
