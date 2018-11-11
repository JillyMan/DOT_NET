using System;
using System.Collections.Generic;
using TextParser.Core;
using TextParser.Parser;
using TextParser.Core.Util;

namespace TextParser
{
    class Program
    {

		public void Run()
		{
			IList<Simbol> hello = new List<Simbol>()
			{
				new Simbol("h"),
				new Simbol("e"),
				new Simbol("l"),
				new Simbol("l"),
				new Simbol("o")
			};

			IList<Simbol> world = new List<Simbol>()
			{
				new Simbol("w"),
				new Simbol("o"),
				new Simbol("r"),
				new Simbol("l"),
				new Simbol("d")
			};

			IList<Simbol> you = new List<Simbol>()
			{
				new Simbol("y"),
				new Simbol("o"),
				new Simbol("u"),
			};

			IList<Simbol> dirty = new List<Simbol>()
			{
				new Simbol("d"),
				new Simbol("i"),
				new Simbol("r"),
				new Simbol("t"),
				new Simbol("y")
			};

			IList<Simbol> dog = new List<Simbol>()
			{
				new Simbol("d"),
				new Simbol("o"),
				new Simbol("g")
			};

			Word[] words = new Word[5]
			{
				new Word(hello),
				new Word(world),
				new Word(you),
				new Word(dirty),
				new Word(dog)
			};

			Punctuation space = new Punctuation(new Simbol(" "));
			Punctuation comma = new Punctuation(new Simbol(", "));
			Punctuation dash = new Punctuation(new Simbol("-"));
			Punctuation dot = new Punctuation(new Simbol(". "));
			Punctuation newLine = new Punctuation(new Simbol("\n"));
			Punctuation mark = new Punctuation(new Simbol("! "));
			Punctuation tab = new Punctuation(new Simbol("\t"));

			Sentence sentence = new Sentence();

			sentence.AddPunctuationSign(tab);
			sentence.AddPunctuationSign(dash);
			sentence.AddWord(words[0]);
			sentence.AddPunctuationSign(space);
			sentence.AddWord(words[4]);
			sentence.AddPunctuationSign(dot);
			sentence.AddPunctuationSign(tab);

			sentence.AddWord(words[2]);
			sentence.AddPunctuationSign(space);
			sentence.AddWord(words[3]);
			sentence.AddPunctuationSign(mark);


			Console.WriteLine(sentence.ToString());
			sentence.RemoveWord(words[3]);
			sentence.RemoveWord(words[4]);
			Console.WriteLine(sentence.ToString());

		}

		static void Main(string[] args)
        {
		//	new Program().Run();
			TextParser.Parser.Parser p = new TextParser.Parser.Parser();
			Text text = p.Parse("file.txt");

			Console.WriteLine(text.ToString());

			Console.WriteLine("\n\n");

			//foreach(var s in text.Sentences.SortByWord())
			//{
			//	Console.WriteLine(s.ToString());
			//}
			//Console.WriteLine("\n\n");


			/*text.RemoveWordFirstConsonantLetter();
			Console.WriteLine(text.ToString());
			*/Console.WriteLine("\n\n");

			text.ChangeWordsInSentence(2, 4, "MOUSE");
			Console.WriteLine(text.ToString());
			Console.WriteLine("\n\n");
		}
	}
}
