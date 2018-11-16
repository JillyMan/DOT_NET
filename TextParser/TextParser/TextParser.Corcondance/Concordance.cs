﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using TextParser.Core;
using TextParser.Core.Concordance;

namespace TextParser.Concordance
{
	public class Concordance
	{
		struct PositionInfo
		{
			public int count;
			public ISet<int> numberPages;
		}

		public void WriteToFile(IPaginatedText paginatedText, string path)
		{
			if(!File.Exists(path))
			{
				throw new FileNotFoundException($"{path} not found!!");
			}

			using(StreamWriter writer = new StreamWriter(path))
			{
				foreach(var record in BreakUpPaginatedText(paginatedText))
				{
					writer.WriteLine(record.Key);
					foreach (var word in record)
					{
						string result = word.Key + "...................." + word.Value.count + " : ";
						word.Value.numberPages.ToList().ForEach(x => result += x.ToString() + " ");
						writer.WriteLine(result);
					}
					writer.WriteLine();
				}
			}
		}

		private IEnumerable<IGrouping<char, KeyValuePair<string, PositionInfo>>> BreakUpPaginatedText(IPaginatedText text)
		{
			var words = (from page in text.Pages
						   from line in page.Lines
								from token in line.Tokens
								   where token is IWord
									   select new
										{
											Word = token.Value,
											NumberPage = page.Number
										}).ToList();

			IDictionary<string, PositionInfo> dictionary = new Dictionary<string, PositionInfo>();
			foreach (var w in words)
			{
				if(!dictionary.ContainsKey(w.Word))
				{
					PositionInfo info;
					info.count = 1;
					info.numberPages = new HashSet<int> { w.NumberPage };
					dictionary.Add(w.Word, info);
				}
				else
				{
					PositionInfo info = dictionary[w.Word];
					info.count++;
					info.numberPages.Add(w.NumberPage);
					dictionary[w.Word] = info;
				}
			}

			var groups = from d in dictionary
						group d by d.Key.First();

			var sorted = from g in groups
						 orderby char.ToLower(g.Key)
						 select g;
					

			foreach(IGrouping<char, KeyValuePair<string, PositionInfo>> group in sorted)
			{
				yield return group;
			}
		}
	}
}
