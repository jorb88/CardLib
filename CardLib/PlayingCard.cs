using System;

namespace CardLib
{
	/// <summary>
	/// Fundamental playing card abstraction
	/// </summary>
	public class PlayingCard : IComparable<PlayingCard>
	{
		public const int Ace = 1;
		public const int Deuce = 2;
		public const int Jack = 11;
		public const int Queen = 12;
		public const int King = 13;

		public const string SuitCharactersMicrosoftGraphical = "\u2663\u2666\u2665\u2660";
		public const string SuitCharactersAscii7Bit = "CDHS";
		public const string RankCharacters = " A23456789TJQK";

		private readonly int rank;
		private readonly CardSuit suit;
		private readonly int eyes;
		private PlayingCard wildcard;

		public virtual int Rank { get { if (Wild && (wildcard != null)) return wildcard.Rank; return rank; } }
		public virtual CardSuit Suit { get { if (Wild && (wildcard != null)) return wildcard.Suit; return suit; } }
		public virtual int Eyes { get { if (Wild && (wildcard != null)) return wildcard.Eyes; return eyes; } }
		public virtual string Code { get { return "" + RankCharacters[rank] + SuitCharactersAscii7Bit[(int)suit]; } }

		public bool Wild { get; set; }
		public bool FaceUp { get; set; }
		public PlayingCard Wildcard { get { return wildcard; } set { wildcard = value; } }

		public PlayingCard(int rank, CardSuit suit)
		{
			if ((rank < 0) || (rank > King))
				throw new ArgumentException("Invalid value for rank.");

			this.rank = rank;
			this.suit = suit;
			if (rank >= Jack) this.eyes = 2;
			if ((rank == King) && (suit == CardSuit.Diamonds)) this.eyes = 1;
			if ((rank == Jack) && (suit == CardSuit.Spades)) this.eyes = 1;
			if ((rank == Jack) && (suit == CardSuit.Hearts)) this.eyes = 1;
		}

		public PlayingCard Flip() { FaceUp = !FaceUp; return this; }

		/// <summary>
		/// Produces a unique integer index from the playing card's viewable
		/// status. If face down, the index is 0. If face up, the index will
		/// be in the range 1 to 52 and unique for each card.
		/// </summary>
		public virtual int ImageIndex
		{
			get
			{
				if (!FaceUp) return 0;
				return ((int)suit * 13) + rank;
			}
		}
		public override string ToString()
		{
			return ToString(false);
		}
		public static PlayingCard Parse(string cardCode)
		{
			if (cardCode == null) throw new ArgumentNullException("cardCode");
			cardCode = cardCode.Trim().ToUpper();
			PlayingCard card = null;

			if ((cardCode[0] == 'W') && (cardCode[1] == 'J')) card = new Joker();
			else if ((cardCode[0] == 'W') && (cardCode[1] == '\u263A')) card = new Joker();
			else
			{
				int rank = PlayingCard.RankCharacters.IndexOf(cardCode[0]);
				int suit = PlayingCard.SuitCharactersMicrosoftGraphical.IndexOf(cardCode[1]);
				if (suit < 0) suit = PlayingCard.SuitCharactersAscii7Bit.IndexOf(cardCode[1]);
				card = new PlayingCard(rank, (CardSuit)suit);
			}

			if (cardCode.Length < 3) return card;
			if (cardCode[2] == 'U') card.FaceUp = true;
			else card.FaceUp = false;

			return card;
		}
		public virtual string ToString(bool graphical)
		{
			if (!FaceUp) return "XX";
			if (graphical) return "" + RankCharacters[rank] + SuitCharactersMicrosoftGraphical[(int)suit];
			return Code;
		}

		public int CompareTo(PlayingCard other) // Natural deck order
		{
			if (other == null) throw new ArgumentNullException("other");
			if (this.suit > other.suit) return +1;
			if (this.suit < other.suit) return -1;
			return this.rank - other.rank;
		}
	}
}
