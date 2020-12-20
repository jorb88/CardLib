using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardLib
{
	public enum CardSuit { Clubs, Diamonds, Hearts, Spades };
	public enum CardRank { Ace = 1, Deuce, Jack = 11, Queen, King};
	public class CardSuitChoices
	{
		public static IEnumerable<CardSuit> All
		{
			get
			{
				Array csChoices = Enum.GetValues(typeof(CardSuit));
				return (IEnumerable<CardSuit>)csChoices;
			}
		}
	}
}
