using System.Collections.Generic;

namespace Data_Structures_and_Algorithms
{
	public class Path
	{
		private readonly List<string> nodes = new List<string>();

		public void Add(string node)
		{
			nodes.Add(node);
		}

		public override string ToString()
		{
			return nodes.ToString();
		}
	}
}
