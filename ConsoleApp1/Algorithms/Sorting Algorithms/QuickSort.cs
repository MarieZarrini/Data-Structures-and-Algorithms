namespace Data_Structures_and_Algorithms.Algorithms.Sorting_Algorithms
{
	public class QuickSort
	{
		public void Sort(int[] array)
		{
			Sort(array, 0, array.Length - 1);
		}

		private void Sort(int[] array, int start, int end)
		{
			if (start >= end)
				return;

			var boundry = Partition(array, start, end);

			Sort(array, start, boundry - 1);
			Sort(array, boundry + 1, end);
		}


		private static int Partition(int[] array, int start, int end)
		{
			var pivot = array[end];
			int boundry = start - 1;
			for (int i = start; i <= end; i++)
				if (array[i] <= pivot)
					Swap(array, ++boundry, i);

			return boundry;
		}

		private static void Swap(int[] array, int index1, int index2)
		{
			var temp = array[index1];
			array[index1] = array[index2];
			array[index2] = temp;
		}
	}
}
