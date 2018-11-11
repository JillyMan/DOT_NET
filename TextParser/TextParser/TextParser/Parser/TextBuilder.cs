using System;
using System.Collections.Generic;
using System.Text;
using TextParser.Core;

namespace TextParser.Parser
{
    public class TextBuilder
    {
		private IDictionary<string, Action<Simbol, IList<Simbol>>> _dictionary;
		private Sentence _sentence;
		private Text _text;

		public TextBuilder()
		{
			_text = new Text();
			_sentence = new Sentence();
			_dictionary = new Dictionary<string, Action<Simbol, IList<Simbol>>>();

			Init();
		}

		private void Init()
		{
			_dictionary.Add(".", (sign, list) =>
			{
				CreateWordAndSign(sign, list);

				_text.AddSentence(_sentence);
				_sentence = new Sentence();
			});

			_dictionary.Add("!", (sign, list) =>
			{
				CreateWordAndSign(sign, list);

				_text.AddSentence(_sentence);
				_sentence = new Sentence();
			});

			_dictionary.Add("?", (sign, list) =>
			{
				CreateWordAndSign(sign, list);

				_text.AddSentence(_sentence);
				_sentence = new Sentence();
			});

//-------------

			_dictionary.Add(" ", (sign, list) =>
			{
				CreateWordAndSign(sign, list);
			});

			_dictionary.Add(",", (sign, list) =>
			{
				CreateWordAndSign(sign, list);
			});

			_dictionary.Add(";", (sign, list) =>
			{
				CreateWordAndSign(sign, list);
			});

			_dictionary.Add("-", (sign, list) =>
			{
				CreateWordAndSign(sign, list);
			});

			_dictionary.Add("\n", (sign, list) =>
			{
				CreateWordAndSign(sign, list);
			});
		}

		public Text GetText()
		{
			return _text;
		}

		private void CreateWordAndSign(Simbol sign, IList<Simbol> list)
		{
			if(list.Count > 0)
			{
				_sentence.AddWord(CreateWord(list));
			}
			_sentence.AddPunctuationSign(CreatePuncSign(sign));

		}

		private Word CreateWord(IList<Simbol> simbols)
		{
			return new Word(simbols);
		}

		private Punctuation CreatePuncSign(Simbol sign)
		{
			return new Punctuation(sign);
		}

		public bool IsKeySign(string sign)
		{
			return _dictionary.ContainsKey(sign);
		}

		//TODO: Change name Action!!
		public void Action(Simbol s, IList<Simbol> simbols)
		{
			if (_dictionary.ContainsKey(s.simbol))
			{
				_dictionary[s.simbol].Invoke(s, simbols);
			}
		}
	}
}
