namespace TextParser.Core.LetterFactory
{
	public interface ILetterFactory<T>
	{
		TypeLetter GetSound(T letter);
		bool IsLetter(T letter);
	}
}
