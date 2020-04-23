using System.Collections.Generic;

namespace CardLib
{
	public interface IShuffler
	{
		void Shuffle(List<PlayingCard> deck);
	}
}