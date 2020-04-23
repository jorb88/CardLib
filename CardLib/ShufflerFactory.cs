using System;
namespace CardLib
{
	public static class ShufflerFactory
	{
		public static string[] Choices { get; private set; } =
		{
			"Simple Knuth Shuffler",
			"Modified Knuth Shuffler",
			"Two Ended Shuffler"
		};
		public static IShuffler Create(string shufflerText)
		{
			if (shufflerText == Choices[0]) return new KnuthShuffler();
			if (shufflerText == Choices[1]) return new ModifiedKnuthShuffler();
			if (shufflerText == Choices[2]) return new TwoEndedShuffler();
			return null;
		}
	}
}
