using System;
using System.Collections.Generic;
using System.Linq;

namespace Data_Structures_and_Algorithms
{
	public class WeightedGraph
	{
		private class Node
		{
			public string label;
			public List<Edge> edges = new List<Edge>();
			public Node(string label)
			{
				this.label = label;
			}

			public override string ToString()
			{
				return label;
			}

			public void AddEdge(Node to, int weight)
			{
				edges.Add(new Edge(this, to, weight));
			}

			public List<Edge> GetEdges()
			{
				return edges;
			}
		}

		private class Edge
		{
			public Node from;
			public Node to;
			public int weight;
			public Edge(Node from, Node to, int weight)
			{
				this.from = from;
				this.to = to;
				this.weight = weight;
			}

			public Edge() { }

			public override string ToString()
			{
				return from + "->" + to; // A->B
			}

			public int ReturnWeight()
			{
				return weight;
			}
		}

		private readonly Dictionary<string, Node> nodes = new Dictionary<string, Node>();


		public void AddNode(string label)
		{
			nodes.TryAdd(label, new Node(label));
		}

		public void AddEdge(string from, string to, int weight)
		{
			var fromNode = nodes[from];
			if (fromNode == null)
				throw new Exception();

			var toNode = nodes[to];
			if (toNode == null)
				throw new Exception();

			fromNode.AddEdge(toNode, weight);
			toNode.AddEdge(fromNode, weight);
		}

		public void Print()
		{
			foreach (var node in nodes.Values)
			{
				var edges = node.GetEdges();
				if (edges.Count > 0)
					Console.WriteLine(node + " is connected to " + edges);
			}
		}

		private class NodeEntry
		{
			public Node node;

			public NodeEntry(Node node)
			{
				this.node = node;
			}
		}

		public Path GetShortestPath(string from, string to)
		{
			var fromNode = nodes[from];
			if (fromNode == null)
				throw new Exception();

			var toNode = nodes[to];
			if (toNode == null)
				throw new Exception();

			Dictionary<Node, int> distances = new();
			foreach (var node in nodes.Values)
				distances.Add(node, int.MaxValue);
			distances[fromNode] = 0;

			var previousNodes = new Dictionary<Node, Node>();

			var visited = new HashSet<Node>();
			var queue = new PriorityQueue<NodeEntry, int>();
			queue.Enqueue(new NodeEntry(fromNode), 0);

			while (queue.Count > 0)
			{
				var current = queue.Dequeue().node;
				visited.Add(current);

				foreach (var edge in current.GetEdges())
				{
					if (visited.Contains(edge.to))
						continue;

					var newDistance = distances[current] + edge.weight;
					if (newDistance < distances[edge.to])
					{
						distances[edge.to] = newDistance;
						previousNodes.Add(edge.to, current);
						queue.Enqueue(new NodeEntry(edge.to), newDistance);
					}
				}
			}

			return BuildPath(previousNodes, toNode);
		}

		private Path BuildPath(Dictionary<Node, Node> previousNodes, Node toNode)
		{

			Stack<Node> stack = new Stack<Node>();
			stack.Push(toNode);
			var previous = previousNodes[toNode];
			while (previous != null)
			{
				stack.Push(previous);
				previous = previousNodes[previous];
			}

			var path = new Path();
			while (stack.Count > 0)
				path.Add(stack.Pop().label);

			return path;
		}


		public bool HasCycle()
		{
			HashSet<Node> visited = new HashSet<Node>();

			foreach (var node in nodes.Values)
			{
				if (!visited.Contains(node) &&
					HasCycle(node, null, visited))
					return true;
			}

			return false;
		}

		private bool HasCycle(Node node, Node parent, HashSet<Node> visited)
		{
			visited.Add(node);

			foreach (var edge in node.GetEdges())
			{
				if (edge.to == parent)
					continue;

				if (visited.Contains(edge.to) ||
					HasCycle(edge.to, node, visited))
					return true;
			}

			return false;
		}


		public WeightedGraph GetMinimumSpanningTree()
		{
			var tree = new WeightedGraph();

			if (nodes.Count == 0)
				return tree;

			var edges = new PriorityQueue<Edge, int>();

			var startNode = nodes.First();
			var startNodeEdges = startNode.Value.GetEdges();
			foreach (var edge in startNodeEdges)
				edges.Enqueue(edge, edge.weight);

			tree.AddNode(startNode.Value.label);

			if (edges.Count == 0)
				return tree;

			while (tree.nodes.Count < nodes.Count)
			{
				var minEdge = edges.Dequeue();
				var nextNode = minEdge.to;

				if (tree.ContainsNode(nextNode.label))
					continue;

				tree.AddNode(nextNode.label);
				tree.AddEdge(minEdge.from.label, nextNode.label, minEdge.weight);

				foreach (var edge in nextNode.GetEdges())
					if (!tree.ContainsNode(edge.to.label))
						edges.Enqueue(edge, edge.weight);
			}

			return tree;
		}

		public bool ContainsNode(string label)
		{
			return nodes.ContainsKey(label);
		}

	}
}
