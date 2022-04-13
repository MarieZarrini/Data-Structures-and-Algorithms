using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Data_Structures_and_Algorithms.Algorithms.string_Manipulation
{
	public class StringUtils
	{
		public static int CountVowels(string input)
		{
			if (input == null)
				return 0;

			int count = 0;
			var vowels = "aeoui";

			foreach (var character in input.ToLower())
				if (vowels.Contains(character))
					count++;

			return count;
		}

		public static string Reverse(string input)
		{
			if (input == null)
				return "";

			var reversed = new StringBuilder();

			for (int i = input.Length - 1; i >= 0; i--)
				reversed.Append(input[i]);

			return reversed.ToString();
		}

		public static string ReverseWords(string sentence)
		{
			if (sentence == null)
				return "";

			var words = sentence.Split(' ');
			var reversed = new StringBuilder();

			for (int i = words.Length - 1; i >= 0; i--)
				reversed.Append(words[i] + ' ');

			return reversed.ToString().Trim();
		}

		public static bool AreRotations(string input1, string input2)
		{
			if (input1 == null || input2 == null)
				return false;

			return (input1.Length == input2.Length) &&
					(input1 + input1).Contains(input2);
		}

		public static string RemoveDuplicates(string input)
		{
			if (input == null)
				return "";

			var result = new HashSet<char>();
			foreach (var ch in input)
				result.Add(ch);

			return string.Join("", result);
		}

		public static char MostRepeatedCharacter(string input)
		{
			if (input == null)
				throw new Exception();

			var result = new Dictionary<char, int>();

			foreach (var ch in input)
			{
				if (!result.ContainsKey(ch))
					result.Add(ch, 0);

				result[ch]++;
			}

			return result.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
		}

		public static string Capitalize(string sentence)
		{
			//return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(sentence.ToLower());

			if (sentence == null)
				return "";

			sentence = Regex.Replace(sentence, @"\s+", " ").Trim();
			var words = sentence.Split(' ');

			for (var i = 0; i < words.Length; i++)
				words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1).ToLower();


			return String.Join(" ", words);
		}

		public static bool AreAnagrams(string input1, string input2)
		{
			if (input1.Length != input2.Length || input1 == null || input2 == null)
				return false;

			foreach (var ch in input1)
				if (!input2.Contains(ch))
					return false;

			return true;
		}

		public static bool IsPalindrome(string input)
		{
			if (input == null)
				return false;

			var reversed = "";
			for (var i = input.Length - 1; i >= 0; i--)
				reversed += input[i];

			if (input.Equals(reversed))
				return true;

			return false;
		}
	}
}
