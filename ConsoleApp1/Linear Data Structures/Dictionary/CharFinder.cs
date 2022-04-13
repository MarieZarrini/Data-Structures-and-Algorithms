using System.Collections.Generic;

namespace Data_Structures_and_Algorithms.Dictionary
{
	public class CharFinder
	{
		//Using Dictionary
		public char FindFirstNonRepeatingChar(string str)
		{
			Dictionary<char, int> dic = new Dictionary<char, int>();

			foreach (var ch in str)
			{
				#region old code
				//if (dic.ContainsKey(ch))
				//{
				//	var count = dic[ch];
				//}
				//else
				//	dic[ch] = 1;
				#endregion

				var count = dic.ContainsKey(ch) ? dic[ch] : 0;
				dic[ch] = count + 1;
			}

			foreach (var ch in str)
				if (dic[ch] == 1)
					return ch;

			return char.MinValue;
		}


		//Using HashSet
		public char FindFirstRepeatedChar(string str)
		{
			HashSet<char> set = new HashSet<char>();

			foreach (var ch in str)
			{
				if (set.Contains(ch))
					return ch;

				set.Add(ch);
			}

			return char.MinValue;
		}
	}
}
