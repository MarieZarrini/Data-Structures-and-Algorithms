namespace Data_Structures_and_Algorithms.Algorithms.Searching_Algorithms
{
	public class BinarySearch
	{
		public int IterativeSearch(int[] list, int target)
		{
			var start = 0;
			var end = list.Length - 1;
			while (start <= end)
			{
				var middle = (start + end) / 2;

				if (list[middle] < target)
					start = middle + 1;

				else if (list[middle] > target)
					end = middle - 1;

				else
					return middle;
			}

			return -1;
		}



		public int RecursiveSearch(int[] array, int target)
		{
			return RecursiveSearch(array, target, 0, array.Length);
		}

		public int RecursiveSearch(int[] array, int target, int start, int end)
		{
			if (start > end)
				return -1;

			var middle = (start + end) / 2;

			if (array[middle] > target)
				return RecursiveSearch(array, target, start, middle - 1);

			else if (array[middle] < target)
				return RecursiveSearch(array, target, middle + 1, end);

			return middle;

		}
	}
}
