using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Structures_and_Algorithms.Stack
{
	public class Expression
	{
		private List<char> leftBrackets = new List<char>() { '(', '<', '[', '{' };
		private List<char> rightBrackets = new List<char>() { ')', ']', '>', '}' };

		public string input;
		public Expression(string input)
		{
			this.input = input;
		}


		public bool IsBalanced()
		{
			var stack = new Stack<char>();

			foreach (var ch in input)
			{
				if (IsLeftBracket(ch))
					stack.Push(ch);

				if (IsRightBracket(ch))
				{
					if (stack.Count == 0)
						return false;

					var top = stack.Pop();
					if (!BracketsMatch(top, ch))
						return false;
				}
			}

			return stack.Count == 0;
		}


		private bool IsLeftBracket(char ch)
		{
			return leftBrackets.Contains(ch);
		}

		private bool IsRightBracket(char ch)
		{
			return rightBrackets.Contains(ch);
		}

		private bool BracketsMatch(char left, char right)
		{
			return leftBrackets.IndexOf(left) == rightBrackets.IndexOf(right);
		}
	}
}
