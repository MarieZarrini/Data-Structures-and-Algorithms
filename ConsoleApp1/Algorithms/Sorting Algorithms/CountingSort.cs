using System.Linq;

namespace Data_Structures_and_Algorithms.Algorithms.Sorting_Algorithms
{
	public class CountingSort
	{
		public void Sort(int[] array)
		{
			var counts = new int[array.Max() + 1];
			foreach (var item in array)
				counts[item]++;

			var j = 0;
			for (int i = 0; i < counts.Length; i++)
				while (counts[i] > 0)
				{
					array[j++] = i;
					counts[i]--;
				}
		}
	}
}
