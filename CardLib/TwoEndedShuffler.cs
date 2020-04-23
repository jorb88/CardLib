using System;
using System.Collections.Generic;
namespace CardLib
{
	public class TwoEndedShuffler : IShuffler
	{
		public void Shuffle(List<PlayingCard> deck)
		{
			for (int i = 0; i < deck.Count; i++)
			{
				int si = RandomNumber.Next(deck.Count);
				int ti = RandomNumber.Next(deck.Count);
				PlayingCard temp = (PlayingCard)deck[ti];
				deck[ti] = deck[si];
				deck[si] = temp;
			}
		}
	}
}