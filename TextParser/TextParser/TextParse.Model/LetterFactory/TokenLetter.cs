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
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}

			return _signFactory.IsQuestion(token.Value);
		}

		public bool IsLetter(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}

			char letter = token.Value.ToCharArray()[0];
			return _letterFactory.IsLetter(letter);
		}

		public TypeLetter GetSound(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}

			char letter = token.Value.ToCharArray()[0];
			return _letterFactory.GetSound(letter);
		}

		public bool IsEnd(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}
			return _signFactory.IsEnd(token.Value);
		}

		public bool IsSpaces(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}
			return _signFactory.IsSpaces(token.Value);
		}

		public bool IsSeparator(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}
			return _signFactory.IsSeparator(token.Value);
		}

		public bool IsNewLine(IToken token)
		{
			if (token == null || token.Value == null)
			{
				throw new System.ArgumentNullException();
			}
			return _signFactory.IsNewLine(token.Value);
		}
	}
}
