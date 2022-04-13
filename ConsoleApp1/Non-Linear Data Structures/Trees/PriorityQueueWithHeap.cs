namespace Data_Structures_and_Algorithms.Trees
{
	public class PriorityQueueWithHeap
	{
		private Heap heap = new Heap();

		public void Enqueue(int item)
		{
			heap.Insert(item);
		}

		public void Dequeue()
		{
			heap.Remove();
		}
	}
}
