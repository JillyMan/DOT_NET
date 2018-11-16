using System;
using System.Collections.Generic;
using TextParser.Model;
using TextParser.Model.Util;
using TextParser.Core;
using TextParser.Parser;
using TextParser.Concordance;
using TextParser.Core.Concordance;
using TextParser.Core.Parser;
using TextParser.Corcondance.Factory;


namespace TextParser
{
	class Program
	{
		public void Run()
		{
			IWord[] words = new Word[5]
			{
				new Word("hello"),
				new Word("world"),
				new Word("you"),
				new Word("pretty"),
				new Word("cool")
			};

			Gap space = new Gap(" ");
			Gap space1 = new Gap(" ");

			IGap tab = new Gap("\t");
			IGap newLine = new Gap("\n");

			IPunctuationSign comma = new PunctuationSign(", ");
			IPunctuationSign dash = new PunctuationSign("-");
			IPunctuationSign dot = new PunctuationSign(".");
			IPunctuationSign mark = new PunctuationSign("! ");

			ISentence sentence = new Sentence(new List<IToken>());

			sentence.Add(tab);
			sentence.Add(dash);
			sentence.Add(words[0]);
			sentence.Add(space);
			sentence.Add(words[4]);
			sentence.Add(dot);
			sentence.Add(tab);

			sentence.Add(words[2]);
			sentence.Add(space);
			sentence.Add(words[3]);
			sentence.Add(mark);

			Console.WriteLine(sentence.ToString());
			sentence.Remove(words[3]);
			sentence.Remove(words[4]);
			Console.WriteLine(sentence.ToString());
		}

		/*
		 * Questions:
		 * ITocken -
		 *			Word;
		 *			Pun
		 *			Space
		 * Override gap, punc, token
		 * After sort may be delete \n? 
		 * EMPTY LINE!!
		 */
		public static void Main(string[] args)
        {

	//		new Program().Run();
			TextParser.Parser.TextParser p = new TextParser.Parser.TextParser();

			IText text = p.Parse("F:\\Dot_Net_Project\\TextParser\\TextParser\\TextParser.SandBox\\file.txt");
			#region Task1
			/*
						Console.WriteLine(text.ToString());
						Console.WriteLine("\n\n");

						int i = 0;
						foreach(var s in text.Sentences.SortByWordCount())
						{
							Console.WriteLine(++i + " " + s.ToString() + " ----" + s.Count);
						}
						Console.WriteLine("\n\n");


						text.RemoveWordsFirstConsonantLetter(4);
						Console.WriteLine(text.ToString());
						Console.WriteLine("\n\n");


						text.ReplaceWordsInSentence(2, 4, "EASYPEASY");
						Console.WriteLine(text.ToString());
						Console.WriteLine("\n\n");
			*/
			#endregion

			Concordance.Concordance concordance = new Concordance.Concordance();
			PageParser parser = new PageParser(new Factory(78, 2));
			IPaginatedText paginatedText = parser.Parse(text);

			concordance.WriteToFile(paginatedText, "F:\\Dot_Net_Project\\TextParser\\TextParser\\TextParser.SandBox\\concordance.txt");

			#region Task2
			#endregion
		}
	}
};