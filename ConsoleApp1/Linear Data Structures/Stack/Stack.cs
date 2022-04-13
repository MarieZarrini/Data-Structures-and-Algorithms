using System;
using System.Linq;

namespace Data_Structures_and_Algorithms.Stack
{
	public class Stack
	{
		private int count;
		private int[] items = new int[5];

		public void Push(int item)
		{
			if (count == items.Length)
				throw new StackOverflowException();

			items[count++] = item;
		}

		public int Pop()
		{
			if (count == 0)
				throw new Exception();

			return items[--count];
		}

		public int Peek()
		{
			if (count == 0)
				throw new Exception();

			return items[count - 1];
		}

		public bool IsEmpty()
		{
			return count == 0;
		}


		public override string ToString()
		{
			var content = items.Take(count);
			return string.Join(",", content);
		}
	}
}
