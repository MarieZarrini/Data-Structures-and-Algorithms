using System.Collections.Generic;

namespace Data_Structures_and_Algorithms.Dictionary
{
	public class Dictionary
	{
		private class Entry
		{
			public int key;
			public string value;
			public Entry(int key, string value)
			{
				this.key = key;
				this.value = value;
			}
		}

		private LinkedList<Entry>[] entries = new LinkedList<Entry>[5];

		public void Put(int key, string value)
		{
			var entry = GetEntry(key);
			if (entry != null)
			{
				entry.value = value;
				return;
			}

			var bucket = GetOrCreateBucket(key);
			bucket.AddLast(new Entry(key, value));
		}

		public string Get(int key)
		{
			var entry = GetEntry(key);

			return entry?.value;
		}

		public void Remove(int key)
		{
			var entry = GetEntry(key);
			if (entry == null)
				throw new System.Exception();

			GetBucket(key).Remove(entry);
		}



		private LinkedList<Entry> GetBucket(int key)
		{
			return entries[Hash(key)];
		}

		private LinkedList<Entry> GetOrCreateBucket(int key)
		{
			var index = Hash(key);
			var bucket = entries[index];

			if (bucket == null)
				bucket = new LinkedList<Entry>();

			return bucket;
		}

		private Entry GetEntry(int key)
		{
			var bucket = GetBucket(key);

			if (bucket != null)
				foreach (var entry in bucket)
					if (entry.key == key)
						return entry;

			return null;
		}

		private int Hash(int key)
		{
			return key % entries.Length;
		}
	}
}
