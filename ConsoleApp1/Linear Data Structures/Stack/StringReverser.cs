using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_and_Algorithms
{
	public class StringReverser
	{
		public string Reverse(string input)
		{
			if (input == null)
				throw new ArgumentNullException("input");

			var stack = new Stack<char>();

			foreach (var ch in input)
				stack.Push(ch);

			var reversed = new StringBuilder();
			while (stack.Count != 0)
				reversed.Append(stack.Pop());

			return reversed.ToString();
		}
	}
}
