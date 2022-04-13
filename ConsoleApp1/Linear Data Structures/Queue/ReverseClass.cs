using System.Collections.Generic;

namespace Data_Structures_and_Algorithms.Queue
{
	public class ReverseClass
	{
		public void Reverse(Queue<int> queue)
		{
			var stack = new Stack<int>();

			while (queue.Count > 0)
				stack.Push(queue.Dequeue());

			while (stack.Count > 0)
				queue.Enqueue(stack.Pop());
		}
	}
}
