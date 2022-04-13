using System.Collections.Generic;

namespace Data_Structures_and_Algorithms.Algorithms.Sorting_Algorithms
{
	public class BucketSort
	{
		public void Sort(int[] array)
		{
			Sort(array, 3);
		}

		private void Sort(int[] array, int numberOfBuckets)
		{
			var buckets = CreateBuckets(array, numberOfBuckets);

			var i = 0;
			foreach (var bucket in buckets)
			{
				bucket.Sort();
				foreach (var item in bucket)
					array[i++] = item;
			}
		}


		private static List<List<int>> CreateBuckets(int[] array, int numberOfBuckets)
		{
			var buckets = new List<List<int>>();
			for (int i = 0; i < numberOfBuckets; i++)
				buckets.Add(new List<int>());

			foreach (var item in array)
				buckets[item / numberOfBuckets].Add(item);

			return buckets;
		}
	}
}
