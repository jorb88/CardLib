using System;
using System.Collections.Generic;

namespace CardLib
{
	public abstract class GameHand : IComparer<PlayingCard>
	{
		private string text;
		public string Text { get { return text; } set { text = value; } }

		private List<PlayingCard> hand = new List<PlayingCard>();
		protected List<PlayingCard> Hand { get { return hand; } }

		public abstract long Score { get; }
		public virtual long Worth { get { return Score; } }
		public virtual string Description { get { return ""; } }

		public virtual void ClearHand()
		{
			hand.Clear();
		}
		public void RemoveAt(int index) { hand.RemoveAt(index); }
		public virtual bool Contains(PlayingCard card) { return hand.Contains(card); }

		public virtual void AddCard(PlayingCard card)
		{
			card.FaceUp = true;
			hand.Add(card);
		}

		public override string ToString()
		{
			string rep = "";
			foreach (PlayingCard c in hand)
			{
				rep = rep + c + " ";
			}
			return rep.Trim();
		}

		public int Count { get { return hand.Count; } }

		public virtual PlayingCard this[int ix]
		{
			get
			{
				if (ix < hand.Count) return hand[ix];
				else return null;
			}
			set
			{
				value.FaceUp = true;
				hand[ix] = value;
			}
		}

		public virtual int Compare(PlayingCard x, PlayingCard y)
		{
			if (x == null) throw new ArgumentNullException("x");
			if (y == null) throw new ArgumentNullException("y");
			if (x.Rank < y.Rank) return +1;
			if (x.Rank > y.Rank) return -1;
			return 0;
		}

		public System.Collections.IEnumerator GetEnumerator()
		{
			return hand.GetEnumerator();
		}

		public void SortHand(IComparer<PlayingCard> sorter)
		{
			hand.Sort(sorter);
		}
	}
}
