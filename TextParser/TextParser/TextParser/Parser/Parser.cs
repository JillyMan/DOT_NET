using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextParser.Core;

namespace TextParser.Parser
{
	public class Parser
	{
		private TextBuilder _factory;

		public Parser()
		{
			_factory = new TextBuilder();
		}

		public Text Parse(string path)
		{
			if(!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}

			Text result = new Text();
			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				IList<Simbol> bufferSimbols = new List<Simbol>();
				Simbol keySign = new Simbol("");
				while ((line = reader.ReadLine()) != null)
				{
					line = DeleteSequenceSpaces(line);
					line += "\n";
					for (int i = 0; i < line.Length; ++i)
					{
						Simbol current;
						current.simbol = line[i].ToString();

						if (_factory.IsKeySign(current.simbol))
						{
							keySign.simbol += current.simbol;
							_factory.Action(keySign, bufferSimbols);
							bufferSimbols = new List<Simbol>();
							keySign.simbol = "";
							continue;
						}

						bufferSimbols.Add(current);
					}
				}
			}

			return _factory.GetText();
		}

		public static string DeleteSequenceSpaces(string text)
		{
			string[] str = text.Split(" ");

			IList<string> list = new List<string>();
			int count = 0;
			foreach (var s in str)
			{
				if (s.Equals(""))
				{
					if(count == 0)
					{
						list.Add(s);
					}
					++count;
				}
				else
				{
					count = 0;
					list.Add(s);
				}
			}
			string result = string.Join(" ", list.ToArray());
			result = result.Replace("\t", " ");
			return result;
		}
	}
}