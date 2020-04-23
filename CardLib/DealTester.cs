using System;

namespace CardLib
{
	public class DealTester
	{
		private CardDeck deck = new CardDeck();
		private int count = 0;
		private int repeat;
		public int LoopsCompleted { get; private set; }
		public DateTime Started { get; private set; }
		public DateTime Ended { get; private set; }
		public TimeSpan RunTime { get { return Ended - Started; } }

		public DealTester(int repeat)
		{
			this.repeat = repeat;
		}

		public void Deal()
		{
			Started = DateTime.Now;
			for (LoopsCompleted = 0; LoopsCompleted < repeat; LoopsCompleted++)
			{
				deck.Shuffle();
				PlayingCard card = deck.Deal();
				if (card.Suit == CardSuit.Hearts) count++;
				deck.Add(card);
			}
			Ended = DateTime.Now;
		}

		public int Average
		{
			get
			{
				double average = ((double) count / (double) repeat) * 100.0 + .5;
				return (int)average;
			}
		}
	}
}
