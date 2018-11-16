using System.Collections.Generic;
using TextParser.Core;
using TextParser.Model;
using TextParser.Model.LetterFactory;

namespace TextParser.Parser
{
	public class TextBuilder
	{
		private TokenLetter _tokenLetter;
		private Sentence _sentence;
		private Text _text;

		public TextBuilder()
		{
			_tokenLetter = new TokenLetter();
			_text = new Text(new List<ISentence>());
			_sentence = new Sentence(new List<IToken>());
		}

		public Text GetText()
		{
			return _text;
		}

		private void CreateSentences(IToken sign, IToken word)
		{
			AddWord(word);
			AddPuncSign(sign);
			_text.Add(_sentence);
			_sentence = new Sentence(new List<IToken>());
		}

		private void CreateGap(IToken gap)
		{
			if (gap != null)
			{ 
				if (gap.Value != null)
				{
					_sentence.Add(new Gap(gap.Value));
				}
			}
		}

		private void AddWord(IToken buffer)
		{
			if(buffer != null)
			{
				if (buffer.Value != null)
				{
					_sentence.Add(new Word(buffer.Value));
				}
			}
		}

		private void AddPuncSign(IToken sign)
		{
			if(sign != null)
			{
				if (sign.Value != null)
				{
					_sentence.Add(new PunctuationSign(sign.Value));
				}
			}
		}
			
		public bool IsKeySign(IToken token)
		{
			return _tokenLetter.IsEnd(token) || 
					_tokenLetter.IsSeparative(token) || 
					_tokenLetter.IsSpaces(token);
		}

		public void Action(IToken sign, IToken buffer)
		{
			if (_tokenLetter.IsEnd(sign))
			{
				CreateSentences(sign, buffer);
			}
			else if (_tokenLetter.IsSeparative(sign))
			{
				AddWord(buffer);
				AddPuncSign(sign);
			}
			else if(_tokenLetter.IsSpaces(sign))
			{
				AddWord(buffer);
				CreateGap(sign); 
			}
		}
	}
}