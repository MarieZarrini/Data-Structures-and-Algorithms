namespace Data_Structures_and_Algorithms.Algorithms.Searching_Algorithms
{
	public class TernarySearch
	{
		public int Search(int[] array, int target)
		{
			return Search(array, target, 0, array.Length - 1);
		}

		private int Search(int[] array, int target, int left, int right)
		{
			if (left > right)
				return -1;

			int partitionSize = (right - left) / 3;
			int mid1 = left + partitionSize;
			int mid2 = right - partitionSize;

			if (array[mid1] == target)
				return mid1;

			if (array[mid2] == target)
				return mid2;

			if (target < array[mid1])
				return Search(array, target, left, mid1 - 1);

			if (target > array[mid2])
				return Search(array, target, mid2 + 1, right);

			return Search(array, target, mid1 + 1, mid2 - 1);
		}
	}
}
