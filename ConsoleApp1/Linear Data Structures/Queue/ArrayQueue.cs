using System;

namespace Data_Structures_and_Algorithms.Queue
{
	public class ArrayQueue
	{
		private int[] items;
		private int rear;
		private int front;
		private int count;
		public ArrayQueue(int capacity)
		{
			items = new int[capacity];
		}


		public void Enqueue(int item)
		{
			if (count == items.Length)
				throw new Exception();

			items[rear] = item;
			rear = (rear + 1) % items.Length;
			count++;
		}

		public int Dequeue()
		{
			var item = items[front];
			items[front] = 0;
			front = (front + 1) % items.Length;
			count--;
			return item;
		}


		public override string ToString()
		{
			return string.Join(",", items);
		}
	}
}
