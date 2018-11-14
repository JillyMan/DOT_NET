using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextParser.Core;
using TextParser.Core.Parser;
using TextParser.Model;

namespace TextParser.Parser
{
	public class Parser : IParser
	{
		private TextBuilder _builder;

		public Parser()
		{
			_builder = new TextBuilder();
		}

		public IText Parse(string path)
		{
			if (!File.Exists(path))
			{
				throw new FileNotFoundException(path);
			}

			using (StreamReader reader = new StreamReader(path))
			{
				string line;
				IToken streamToken = new Token();

				while ((line = reader.ReadLine()) != null)
				{
					line = DeleteSequenceSpaces(line);
					line += "\n";
					for (int i = 0; i < line.Length; ++i)
					{
						Token current = new Token
						{
							Value = line[i].ToString()
						};

						if (current.Value.Equals("#")) break;

						if (_builder.IsKeySign(current))
						{
							IToken keySign = new Token("")
							{
								Value = FindKeySign(line, current, ref i)
							};

							_builder.Action(keySign, streamToken);

							streamToken = new Token();

							continue;
						}

						streamToken.Value += current;
					}
				}
			}
			 
			return _builder.GetText();
		}

		private string FindKeySign(string line, IToken current, ref int index)
		{
			string result = current.Value;
			if (index + 1 < line.Length)
			{
				string subStr = line.Remove(0, index + 1);
				foreach (var c in subStr)
				{
					current.Value += c;
					if (_builder.IsKeySign(current))
					{
						result += c;
						++index;
					}
					else
					{
						break;
					}
				}
			}
			return result;
		}

		public static string DeleteSequenceSpaces(string text)
		{
			string[] str = text.Split(" ");

			IList<string> list = new List<string>();

			foreach (var s in str)
			{
				if (!s.Equals(""))
				{
					list.Add(s);
				}
			}

			string result = string.Join(" ", list.ToArray());
			result = result.Replace("\t", " ");
			result = result.Replace("\\t", " ");
			return result;
		}
	}
}