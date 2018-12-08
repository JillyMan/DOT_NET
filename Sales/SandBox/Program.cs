using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
	class Program
	{
		static void Main(string[] args)
		{
//			new Test.TestEntityLib().Run();
			new Test.TestRepository().Run();
		}
	}
}
