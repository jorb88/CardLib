using System;
using System.Collections.Generic;

namespace CardLib
{
	public abstract class GameHand : IEnumerable<PlayingCard>, IComparable<GameHand>
	{
		private string text;
		public string Text { get { return text; } set { text = value; } }
		protected List<PlayingCard> Cards { get; private set; } = new List<PlayingCard>();
		public abstract long Score { get; }
		public virtual string Description { get { return ""; } }
		public virtual void ClearHand()
		{
			Cards.Clear();
		}
		public void RemoveAt(int index) { Cards.RemoveAt(index); }
		public virtual bool Contains(PlayingCard card) { return Cards.Contains(card); }
		public virtual void AddCard(PlayingCard card)
		{
			card.FaceUp = true;
			Cards.Add(card);
		}
		public override string ToString()
		{
			string rep = "";
			foreach (PlayingCard c in Cards)
			{
				rep = rep + c + " ";
			}
			return rep.Trim();
		}
		public int Count { get { return Cards.Count; } }
		public virtual PlayingCard this[int ix]
		{
			get
			{
				if (ix < Cards.Count) return Cards[ix];
				else return null;
			}
			set
			{
				value.FaceUp = true;
				Cards[ix] = value;
			}
		}
		public System.Collections.IEnumerator GetEnumerator()
		{
			return Cards.GetEnumerator();
		}
		IEnumerator<PlayingCard> IEnumerable<PlayingCard>.GetEnumerator()
		{
			return Cards.GetEnumerator();
		}
		public virtual void Sort(IComparer<PlayingCard> sorter)
		{
			Cards.Sort(sorter);
		}
		public virtual void Sort()
		{
			Cards.Sort();
		}
		public virtual int CompareTo(GameHand other)
		{
			if (other == null) throw new ArgumentException("other");
			if (this.Score < other.Score) return -1;
			if (this.Score > other.Score) return +1;
			return 0;
		}
		//public static bool operator<(GameHand left, GameHand right)
		//{
		//	return left < right;
		//}
		//public static bool operator >(GameHand left, GameHand right)
		//{
		//	return left > right;
		//}
	}
}
