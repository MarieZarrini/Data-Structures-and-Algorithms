using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_and_Algorithms
{
	public class Graph
	{
		private class Node
		{
			public string label;
			public Node(string label)
			{
				this.label = label;
			}

			public override string ToString()
			{
				return label;
			}
		}

		private readonly Dictionary<string, Node> nodes = new Dictionary<string, Node>();
		private readonly Dictionary<Node, List<Node>> adjacencyList = new Dictionary<Node, List<Node>>();



		public void AddNode(string label)
		{
			var node = new Node(label);
			nodes.TryAdd(label, node);
			adjacencyList.TryAdd(node, new List<Node>());
		}

		public void AddEdge(string from, string to)
		{
			var fromNode = nodes[from];
			if (fromNode == null)
				throw new Exception();

			var toNode = nodes[to];
			if (toNode == null)
				throw new Exception();

			adjacencyList[fromNode].Add(toNode);
		}

		public void RemoveNode(string label)
		{
			var node = nodes[label];
			if (node == null)
				return;

			foreach (var n in adjacencyList.Keys)
				adjacencyList[n].Remove(node);

			adjacencyList.Remove(node);
			nodes.Remove(node.label);
		}

		public void RemoveEdge(string from, string to)
		{
			var fromNode = nodes[from];
			var toNode = nodes[to];

			if (fromNode == null || toNode == null)
				return;

			adjacencyList[fromNode].Remove(toNode);
		}

		public void TraverseDepthFirstRec(string root)
		{
			var node = nodes[root];
			if (node == null)
				return;

			TraverseDepthFirstRec(node, new HashSet<Node>());
		}
		private void TraverseDepthFirstRec(Node root, HashSet<Node> visited)
		{
			Console.WriteLine(root); 
			visited.Add(root);

			foreach (var node in adjacencyList[root])
				if (!visited.Contains(node))
					TraverseDepthFirstRec(node, visited);
		}

		public void TraverseDepthFirst(string root)
		{
			var node = nodes[root];
			if (node == null)
				return;

			HashSet<Node> visited = new HashSet<Node>();

			Stack<Node> stack = new Stack<Node>();
			stack.Push(node);

			while (stack.Count > 0)
			{
				var current = stack.Pop();

				if (visited.Contains(current))
					continue;

				Console.WriteLine(current);
				visited.Add(current);

				foreach (var neighbour in adjacencyList[current])
					if (!visited.Contains(neighbour))
						stack.Push(neighbour);
			}
		}

		public void TraverseBreadthFirst(string root)
		{
			var node = nodes[root];
			if (node == null)
				return;

			HashSet<Node> visited = new HashSet<Node>();

			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(node);

			while (queue.Count > 0)
			{
				var current = queue.Dequeue();

				if (visited.Contains(current))
					continue;

				Console.WriteLine(current);
				visited.Add(current);

				foreach (var neighbour in adjacencyList[current])
					if (!visited.Contains(neighbour))
						queue.Enqueue(neighbour);
			}
		}

		public List<string> TopologicalSort()
		{
			Stack<Node> stack = new Stack<Node>();
			HashSet<Node> visited = new HashSet<Node>();

			foreach (var node in nodes.Values)
				TopologicalSort(node, visited, stack);

			List<string> sorted = new List<string>();
			while (stack.Count > 0)
				sorted.Add(stack.Pop().label);

			return sorted;
		}

		private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
		{
			if (visited.Contains(node))
				return;

			visited.Add(node);

			foreach (var neighbour in adjacencyList[node])
				TopologicalSort(neighbour, visited, stack);

			stack.Push(node);
		}

		public bool HasCycle()
		{
			HashSet<Node> all = new HashSet<Node>();
			foreach(var node in nodes.Values)
				all.Add(node);

			HashSet<Node> visiting = new HashSet<Node>();
			HashSet<Node> visited = new HashSet<Node>();

			var i = 0;
			while (all.Count > 0)
			{
				var current = all.ElementAt(i++);
				if (HasCycle(current, all, visiting, visited))
					return true;
			}

			return false;
		}

		private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visiting, HashSet<Node> visited)
		{
			all.Remove(node);
			visiting.Add(node);

			foreach (var neighbour in adjacencyList[node])
			{
				if (visited.Contains(neighbour))
					continue;

				if (visiting.Contains(neighbour))
					return true;

				if (HasCycle(neighbour, all, visiting, visited))
					return true;
			}

			visiting.Remove(node);
			visited.Add(node);

			return false;
		}



		public void Print()
		{
			foreach (var source in adjacencyList.Keys)
			{
				var targets = adjacencyList[source];
				if (targets.Count > 0)
					Console.WriteLine(source + " is connected to " + targets);
			}
		}
	}
}
