using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Rabin_Karp
{
    internal class Program
    {
        static void Main(string[] args)
        {
			int[] value = Algorithm.SearchString(
				"я не люблю ASP.NET MVC застосунки, я віддаю перевагу ASP.NET API",
				"ASP.NET"
			);
			foreach (var item in value)
				Console.WriteLine(item);

            value = Algorithm.Mine(
                "я не люблю ASP.NET MVC застосунки, я віддаю перевагу ASP.NET API",
                "ASP.NET"
            );
            foreach (var item in value)
                Console.WriteLine(item);
        }
		
	}
}
