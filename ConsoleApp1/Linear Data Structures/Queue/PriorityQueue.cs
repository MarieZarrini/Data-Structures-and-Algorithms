using System;

namespace Data_Structures_and_Algorithms.Queue
{
	public class PriorityQueue
	{
		private int[] items = new int[5];
		private int count;

		public void Add(int item)
		{
			if (IsFull())
				throw new Exception();

			var i = ShiftItemsToInsert(item);
			items[i] = item;
			count++;
		}

		public int Remove()
		{
			if(IsEmpty())
				throw new Exception();

			return items[--count];
		}



		private int ShiftItemsToInsert(int item)
		{
			int i;
			for (i = count - 1; i >= 0; i--)
			{
				if (items[i] > item)
					items[i + 1] = items[i];
				else
					break;
			}

			return i + 1;
		}

		public bool IsFull()
		{
			return count == items.Length;
		}

		public bool IsEmpty()
		{
			return count == 0;
		}

		public override string ToString()
		{
			return string.Join(',', items);
		}
	}
}
