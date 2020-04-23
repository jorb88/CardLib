using System;
using System.Collections.Generic;
using System.Text;

namespace CardLib
{
	public interface IStackable
	{
		void Stack(string cardCode, int position);
		CardDeck DeckToStack { get; }
		bool IsStacked { get; }
	}
}
