using System;

namespace Data_Structures_and_Algorithms.Algorithms.Searching_Algorithms
{
	public class ExponentialSearch
	{
		public int Search(int[] array, int target)
		{
			var bound = 1;

			while (bound < array.Length && array[bound] < target)
				bound *= 2;
			
			var left = bound / 2;
			var right = Math.Min(bound, array.Length - 1);

			var binarySearch = new BinarySearch();
			return binarySearch.RecursiveSearch(array, target, left, right);
		}
	}
}
