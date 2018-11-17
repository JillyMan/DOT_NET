using TextParser.Core;
using TextParser.Core.LetterFactory;

namespace TextParser.Model.LetterFactory
{
	public class TokenLetter : ILetterFactory<IToken>, ISignFactory<IToken>
	{
		private LetterFactory _letterFactory = new LetterFactory();
		private SignFactory _signFactory = new SignFactory();

		public bool IsQuestion(IToken token)
		{
			if(token != null || token.Value.Length == 1)
			{
				return _signFactory.IsQuestion(token.Value);
			}
			return false;
		}

		public bool IsLetter(IToken token)
		{
			if (token != null || token.Value.Length == 1)
			{
				char letter = token.Value.ToCharArray()[0];
				return _letterFactory.IsLetter(letter);
			}
			return false;
		}

		public TypeLetter GetSound(IToken token)
		{
			char letter = token.Value.ToCharArray()[0];
			return _letterFactory.GetSound(letter);
		}

		public bool IsEnd(IToken token)
		{
			return _signFactory.IsEnd(token.Value);
		}

		public bool IsSpaces(IToken token)
		{
			return _signFactory.IsSpaces(token.Value);
		}

		public bool IsSeparator(IToken token)
		{
			return _signFactory.IsSeparator(token.Value);
		}
	}
}
