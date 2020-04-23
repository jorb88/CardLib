using System;
using System.Collections;
using System.Collections.Generic;

namespace CardLib
{
	/// <summary>
	/// Emulation of a blackjack shoe. Uses delegation to CardDeck class
	/// </summary>

	public class CardShoe : CardDeck
	{
		// Events
		public event EventHandler WasReset;

		// Fields
		private int endOfShoe;	// Random end of shoe location
		private int decks;		// Number of decks in this shoe
		private List<PlayingCard> drop = new List<PlayingCard>();

		// Properties
		public int EndOfShoe { get { return endOfShoe; } }
		public int CardsAvailableToDeal { get { return Count - endOfShoe; } }
		public int TotalCardsInShoe { get { return Count; } }

		// Constructors
		public CardShoe(int decks)
		{
			if ((decks > 8) || (decks < 1)) throw new ArgumentException("The shoe must have between 1 and 8 decks");
			this.decks = decks;
			for (int i = 0; i < decks-1; i++)	// Add extra decks
			{
				CardDeck d = new CardDeck();	// Another deck
				foreach (PlayingCard card in d) base.Add(card);
			}
			this.Shuffle();
			endOfShoe = RandomNumber.Next(3 * decks, 10 * decks);	// Never deal whole shoe.
		}

		// Methods
		public override PlayingCard Deal()
		{
			if (CardsAvailableToDeal > 0) return base.Deal();
			foreach (PlayingCard card in drop) base.Add(card);
			drop.Clear();
			Shuffle().Shuffle();
			endOfShoe = RandomNumber.Next(3 * decks, 10 * decks);	// Never deal whole shoe.
			if (WasReset != null) WasReset(this, EventArgs.Empty);
			return base.Deal();
		}

		public override void Add(PlayingCard card) { drop.Add(card); }
	}
}
