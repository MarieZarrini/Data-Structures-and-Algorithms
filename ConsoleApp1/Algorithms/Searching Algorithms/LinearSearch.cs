namespace Data_Structures_and_Algorithms.Algorithms.Searching_Algorithms
{
	public class LinearSearch
	{
		public int Search(int[] array, int target)
		{
			for (int i = 0; i < array.Length; i++)
				if (array[i] == target)
					return i;

			return -1;
		}
	}
}
