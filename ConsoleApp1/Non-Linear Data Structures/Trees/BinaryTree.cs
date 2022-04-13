using System;
using System.Collections.Generic;

namespace Data_Structures_and_Algorithms.Trees
{
	public class BinaryTree
	{
		private class Node
		{
			public int value;
			public Node leftChild;
			public Node rightChild;
			public Node(int value)
			{
				this.value = value;
			}

			public override string ToString()
			{
				return "Node = " + value;
			}
		}

		private Node root;


		public void Insert(int value)
		{
			var node = new Node(value);

			if (root == null)
			{
				root = node;
				return;
			}

			var current = root;
			while (true)
			{
				if (value < current.value)
				{
					if (current.leftChild == null)
					{
						current.leftChild = node;
						break;
					}
					current = current.leftChild;
				}

				else
				{
					if (current.rightChild == null)
					{
						current.rightChild = node;
						break;
					}
					current = current.rightChild;
				}
			}
		}

		public bool Find(int value)
		{
			var current = root;
			while (current != null)
			{
				if (value < current.value)
					current = current.leftChild;
				else if (value > current.value)
					current = current.rightChild;
				else
					return true;
			}

			return false;
		}

		#region Traversings
		public void TraversePreOrder()
		{
			TraversePreOrder(root);
		}
		private void TraversePreOrder(Node root)
		{
			if (root == null)
				return;

			Console.WriteLine(root.value);
			TraversePreOrder(root.leftChild);
			TraversePreOrder(root.rightChild);
		}

		public void TraverseInOrder()
		{
			TraverseInOrder(root);
		}
		private void TraverseInOrder(Node root)
		{
			if (root == null)
				return;

			TraverseInOrder(root.leftChild);
			Console.WriteLine(root.value);
			TraverseInOrder(root.rightChild);
		}

		public void TraversePostOrder()
		{
			TraversePostOrder(root);
		}
		private void TraversePostOrder(Node root)
		{
			if (root == null)
				return;

			TraversePostOrder(root.leftChild);
			TraversePostOrder(root.rightChild);
			Console.WriteLine(root.value);
		}
		#endregion

		public int Height()
		{
			return Height(root);
		}
		private int Height(Node root)
		{
			if (root == null)
				return -1;

			if (IsLeaf(root))
				return 0;

			return 1 + Math.Max(Height(root.leftChild), Height(root.rightChild));
		}

		#region find minimum
		//this is for binary trees  -> O(n)
		private int Minimum(Node root)
		{
			if (IsLeaf(root))
				return root.value;

			var left = Minimum(root.leftChild);
			var right = Minimum(root.rightChild);

			return Math.Min(root.value, Math.Min(left, right));
		}

		//this is for a binary search tree    -> O(log n)
		private int MinimumInBinaryTree(Node root)
		{
			if (root == null)
				throw new Exception();

			var current = root;
			var last = current;

			while (current != null)
			{
				last = current;
				current = current.leftChild;
			}

			return last.value;
		}
		#endregion

		#region Equals
		public bool Equals(BinaryTree other)
		{
			if (other == null)
				return false;

			return Equals(root, other.root);
		}

		private bool Equals(Node first, Node second)
		{
			if (first == null && second == null)
				return true;

			if (first != null && second != null)
			{
				return	first.value == second.value
						&& Equals(first.leftChild, second.leftChild)
						&& Equals(first.rightChild, second.rightChild);
			}

			return false;
		}
		#endregion

		#region IsBinarySearchTree
		public bool IsBinarySearchTree()
		{
			return IsBinarySearchTree(root, int.MinValue, int.MaxValue);
		}

		private bool IsBinarySearchTree(Node root, int min, int max)
		{
			if (root == null)
				return true;

			if (root.value < min && root.value > max)
				return false;

			return	IsBinarySearchTree(root.leftChild, min, root.value - 1)
					&& IsBinarySearchTree(root.rightChild, root.value + 1, max);
		}
		#endregion

		#region Nodes at K Distance from the Root
		public List<int> GetNodesAtDistance(int distance)
		{
			var list = new List<int>();
			GetNodesAtDistance(root, distance, list);
			return list;
		}

		private void GetNodesAtDistance(Node root, int distance, List<int> list)
		{
			if (root == null)
				return;

			if (distance == 0)
			{
				list.Add(root.value);
				return;
			}

			GetNodesAtDistance(root.leftChild, distance - 1, list);
			GetNodesAtDistance(root.rightChild, distance - 1, list);
		}
		#endregion

		public void TraverseLevelOrder()
		{
			for (int i = 0; i < Height(); i++)
			{
				var list = GetNodesAtDistance(i);
				foreach (var value in list)
					Console.WriteLine(value);
			}
		}


		private bool IsLeaf(Node node)
		{
			return node.leftChild == null && node.rightChild == null;
		}
	}
}
