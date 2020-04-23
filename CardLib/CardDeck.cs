using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace CardLib
{
	public delegate void ShufflerMethod(List<PlayingCard> deck);
	public class CardDeck : IEnumerable<PlayingCard>
	{
		public PlayingCard this[int ix] { get { return deck[ix]; } }
		private List<PlayingCard> deck = new List<PlayingCard>();
		private static ShufflerMethod CurrentShufflerMethod;
		public int Count { get { return deck.Count; } }
		public CardDeck()
		{
			foreach (CardSuit s in CardSuitChoices.All)
			{
				for (int r = PlayingCard.Ace; r <= PlayingCard.King; r++)
				{
					PlayingCard card = new PlayingCard(r, s);
					card.FaceUp = true;
					deck.Add(card);
				}
			}
			IShuffler shuffler = new KnuthShuffler();
			CurrentShufflerMethod = shuffler.Shuffle;
		}
		public virtual PlayingCard Deal()
		{
			PlayingCard card = deck[deck.Count - 1];
			deck.Remove(card);
			card.FaceUp = false;
			return card;
		}
		public virtual void Add(PlayingCard card)
		{
			if (card == null) throw new ArgumentNullException("card");
			card.FaceUp = true;
			deck.Add(card);
		}
		public override string ToString()
		{
			return ToString(false);
		}
		public virtual string ToString(bool graphical)
		{
			StringBuilder rep = new StringBuilder(string.Empty, deck.Count * 4);
			for (int i = 0; i < deck.Count; i++)
			{
				rep.Append(deck[i].ToString(graphical) + " ");
			}
			return rep.ToString().Trim();
		}
		public void ChangeShuffler(ShufflerMethod method)
		{
			CurrentShufflerMethod = method;
		}
		public void ChangeShuffler(IShuffler shuffler)
		{
			CurrentShufflerMethod = shuffler.Shuffle;
		}
		public CardDeck Shuffle(ShufflerMethod method)
		{
			method(deck);
			return this;
		}
		public CardDeck Shuffle(IShuffler shuffler)
		{
			shuffler.Shuffle(deck);
			return this;
		}
		public CardDeck Shuffle()
		{
			CurrentShufflerMethod(deck);
			return this;
		}
		public virtual void Stack(string cardCode, int pos)
		{
			if (cardCode == null) return;
			if (cardCode.Length == 0) return;

			pos = deck.Count - 1 - pos;
			PlayingCard temp;
			for (int i = 0; i < deck.Count; i++)
			{
				if (deck[i].Code == cardCode)
				{
					temp = deck[pos];
					deck[pos] = deck[i];
					deck[i] = temp;
					return;
				}
			}
			throw new ArgumentOutOfRangeException("cardCode");
		}
		public void Sort()
		{
			deck.Sort();
		}
		public IEnumerator<PlayingCard> GetEnumerator()
		{
			return deck.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return deck.GetEnumerator();
		}
	}
}

