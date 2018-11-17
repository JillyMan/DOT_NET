using System;
using System.Resources;
using System.Linq;
using System.Collections.Generic;
using TextParser.Model;
using TextParser.Model.Util;
using TextParser.Core;
using TextParser.Parser;
using TextParser.Concordance;
using TextParser.Core.Concordance;
using TextParser.Core.Parser;
using TextParser.Corcondance.Factory;
using TextParser.SandBox.Properties;

namespace TextParser.SandBox
{
	class Program
	{
		public void Run()
		{
			IWord[] words = new Word[5]
			{
				new Word("hello"),
				new Word("world"),
				new Word("how"),
				new Word("are"),
				new Word("you")
			};

			Gap space = new Gap(" ");
			Gap space1 = new Gap(" ");

			IGap tab = new Gap("\t");
			IGap newLine = new Gap("\n");

			IPunctuationSign comma = new PunctuationSign(", ");
			IPunctuationSign dash = new PunctuationSign("-");
			IPunctuationSign dot = new PunctuationSign(".");
			IPunctuationSign mark = new PunctuationSign("! ");
			IPunctuationSign q = new PunctuationSign("?");
			IToken q1 = new PunctuationSign("?");

			ISentence sentence = new Sentence(new List<IToken>());

			var any = sentence.Last();

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

		public static void Main(string[] args)
        {			
			Parser.TextParser p = new Parser.TextParser();

			IText text = p.Parse(Resources.FileWithText);
			Console.WriteLine(text);
			#region Task1		
			/*
				Console.WriteLine("\n\n");

				int i = 0;
				foreach(var s in text.Sentences.SortByWordCount())
				{
					Console.WriteLine(++i + ") " + s.ToString() + " ----" + s.Count);
				}
				Console.WriteLine("\n\n");

				Console.WriteLine("Question sentence ");

				i = 0;
				foreach (var s in text.Sentences.QuestionSentenceByWordLength(4))
				{
					Console.WriteLine(++i + ") " + s.ToString() + " ----" + s.Length);
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

			Console.WriteLine("----------------------------------------------------");
			#region Task2
			Concordance.Concordance concordance = new Concordance.Concordance();
			PageParser parser = new PageParser(new PaginatedTextHelper(25, 3));
			IPaginatedText paginatedText = parser.Parse(text);

			Console.WriteLine(paginatedText);

			concordance.WriteToFile(paginatedText, Resources.Concordance);

			#endregion			
		}
	}
}