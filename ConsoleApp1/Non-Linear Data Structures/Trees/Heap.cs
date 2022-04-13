using System;

namespace Data_Structures_and_Algorithms.Trees
{
	public class Heap
	{
		private int[] items = new int[10];
		private int size;

		public void Insert(int value)
		{
			if (IsFull())
				throw new Exception();

			items[size++] = value;

			BubbleUp();
		}

		public void Remove()
		{
			if (size == 0)
				throw new Exception();

			items[0] = items[--size];

			BubbleDown();
		}


		private void BubbleUp()
		{
			var index = size - 1;
			while (index > 0 && items[index] > items[Parent(index)])
			{
				Swap(index, Parent(index));
				index = Parent(index);
			}
		}

		private void BubbleDown()
		{
			var index = 0;
			while (index <= size && !IsValidParent(index))
			{
				var largerChildIndex = LargerChildIndex(index);
				Swap(index, largerChildIndex);
				index = largerChildIndex;
			}
		}

		private int LargerChildIndex(int index)
		{
			if (!HasLeftChild(index))
				return index;

			if (!HasRightChild(index))
				return LeftChildIndex(index);

			return (LeftChild(index) > RightChild(index)) ? LeftChildIndex(index) : RightChildIndex(index);
		}

		private bool HasLeftChild(int index)
		{
			return LeftChildIndex(index) <= size;
		}

		private bool HasRightChild(int index)
		{
			return RightChildIndex(index) <= size;
		}

		private bool IsValidParent(int index)
		{
			if (!HasLeftChild(index))
				return true;

			var isValid = items[index] >= LeftChild(index);

			if (HasRightChild(index))
				isValid = isValid & items[index] >= RightChild(index);

			return isValid;
		}

		private int LeftChildIndex(int index)
		{
			return index * 2 + 1;
		}

		private int RightChildIndex(int index)
		{
			return index * 2 + 2;
		}

		private void Swap(int first, int second)
		{
			var temp = items[first];
			items[first] = items[second];
			items[second] = temp;
		}

		private int Parent(int index)
		{
			return (index - 1) / 2;
		}

		private int LeftChild(int index)
		{
			return items[LeftChildIndex(index)];
		}

		private int RightChild(int index)
		{
			return items[RightChildIndex(index)];
		}

		private bool IsFull()
		{
			return size == items.Length;
		}

		public int Max()
		{
			if (size == 0)
				throw new Exception();

			return items[0];
		}
	}
}
