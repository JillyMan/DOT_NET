using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextParser.Core;

namespace TextParser.Core.Parser
{
	public interface IParser
	{
		IText Parse(string path);
	}
}
