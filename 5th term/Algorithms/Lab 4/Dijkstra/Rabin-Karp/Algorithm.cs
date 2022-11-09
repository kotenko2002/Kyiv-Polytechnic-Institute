using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabin_Karp
{
    public static class Algorithm
    {
		public static int[] SearchString(string str, string substr)
		{
			List<int> resultList = new List<int>();
			ulong strHash = 0;
			ulong substrHash = 0;
			ulong q = 6;
			ulong d = 256;  
			ulong h = 1;

			for (int i = 0; i < substr.Length; ++i)
			{
				strHash = (strHash * d + str[i]) % q;
				substrHash = (substrHash * d + substr[i]) % q;
			}

			if (strHash == substrHash)
				resultList.Add(0);

			for (int i = 1; i <= substr.Length - 1; ++i)
				h = (h * d) % q;

			for (int i = 1; i <= str.Length - substr.Length; ++i)
			{
				strHash = (strHash + q - h * str[i - 1] % q) % q;
				strHash = (strHash * d + str[i + substr.Length - 1]) % q;

				if (strHash == substrHash)
					if (str.Substring(i, substr.Length) == substr)
						resultList.Add(i);
			}

			return resultList.ToArray();
		}
		public static int[] Mine(string str, string substr)
		{
			List<int> resultList = new List<int>();
			int substrHash = substr.GetHashCode();

			for (int i = 0; i < str.Length - substr.Length; i++)
				if (str.Substring(i, substr.Length).GetHashCode() == substrHash)
					resultList.Add(i);

			return resultList.ToArray();
		}
	}
}
