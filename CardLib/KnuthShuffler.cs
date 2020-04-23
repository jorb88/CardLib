using System;
using System.Collections.Generic;

namespace CardLib
{
	public abstract class KnuthShuffleLogic : IShuffler
	{
		public void Shuffle(List<PlayingCard> deck)
		{
			for (int i = 0; i < deck.Count; i++)
			{
				int swapIndex = RandomNumber.Next(Swix(i), deck.Count);
				PlayingCard temp = deck[swapIndex];
				deck[swapIndex] = deck[i];
				deck[i] = temp;
			}
		}
		protected abstract int Swix(int i);
	}
	public class KnuthShuffler : KnuthShuffleLogic
	{
		protected override int Swix(int i)
		{
			return 0;
		}
	}
	public class ModifiedKnuthShuffler : KnuthShuffleLogic
	{
		protected override int Swix(int i)
		{
			return i;
		}
	}
}
