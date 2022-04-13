using System;
namespace Data_Structures_and_Algorithms.LinkedList
{
	public class LinkedList
	{
		private Node first;
		private Node last;
		private int size;

		private class Node
		{
			public int value;
			public Node next;

			public Node(int value)
			{
				this.value = value;
			}
		}


		public void AddLast(int item)
		{
			var node = new Node(item);

			if (isEmpty())
				first = last = node;
			else
			{
				last.next = node;
				last = node;
			}

			size++;
		}

		public void AddFirst(int item)
		{
			var node = new Node(item);

			if (isEmpty())
				first = last = node;
			else
			{
				node.next = first;
				first = node;
			}

			size++;
		}

		public int IndexOf(int item)
		{
			int index = 0;
			var current = first;

			while (current != null)
			{
				if (current.value == item)
					return index;

				current = current.next;
				index++;
			}

			return -1;
		}

		public bool Contains(int item)
		{ 
			return IndexOf(item) != -1;
		}

		public void RemoveFirst()
		{
			if (isEmpty())
				throw new ArgumentException();

			if (first == last)
				first = last = null;

			else
			{
				var second = first.next;
				first.next = null;
				first = second;
			}
			
			size--;
		}

		public void RemoveLast()
		{
			if (isEmpty())
				throw new Exception();

			if (first == last)
				first = last = null;

			else
			{
				var previous = getPrevious(last);
				last = previous;
				last.next = null;
			}

			size--;
		}

		public int Size()
		{
			return size;
		}

		public int[] ToArray()
		{
			var array = new int[size];
			var current = first;
			int index = 0;

			while (current != null)
			{
				array[index++] = current.value;
				current = current.next;
			}

			return array;
		}

		public void Reverse()
		{
			// 10  <-  20  <-  30 
			//  p	   c       n
			//         p       c      n
			//                 p      c
			 
			if (isEmpty())
				return;

			var previous = first;
			var current = first.next;

			while (current != null)
			{
				var next = current.next;
				current.next = previous;
				previous = current;
				current = next;
			}

			last = first;
			last.next = null;
			first = previous;
		}

		public int GetKthFromTheEnd(int k)
		{
			if (isEmpty())
				throw new Exception();

			var a = first;
			var b = first;
			for (int i = 0; i < k - 1; i++)
			{
				b = b.next;
				if (b == null)
					throw new Exception();
			}

			while (b != last)
			{
				a = a.next;
				b = b.next;
			}

			return a.value;
		}



		private Node getPrevious(Node node)
		{
			var current = first;
			while (current != null)
			{
				if (current.next == node)
					return current;
				current = current.next;
			}
			return null;
		}

		private bool isEmpty()
		{
			return first == null;
		}
	}
}
