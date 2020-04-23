using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardLib;

namespace CardLibTests
{
	[TestClass]
	public class PlayingCardTests
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void CreationFailureTest()
		{
			PlayingCard card = new PlayingCard(-1, CardSuit.Hearts);
		}
		[TestMethod]
		public void RankAndSuitTest()
		{
			Array suitChoices = Enum.GetValues(typeof(CardSuit));
			foreach (CardSuit s in suitChoices)
			{
				for (int r = PlayingCard.Ace; r <= PlayingCard.King; r++)
				{
					PlayingCard card = new PlayingCard(r, s);
					Assert.AreEqual(r, card.Rank);
					Assert.AreEqual(s, card.Suit);
				}
			}
		}
		[TestMethod()]
		public void FlipTest()
		{
			PlayingCard card = new PlayingCard(PlayingCard.Deuce, CardSuit.Spades);
			Assert.IsFalse(card.FaceUp);
			card.Flip();
			Assert.IsTrue(card.FaceUp);
		}
		public void CodeTest()
		{
			int rank = 3;
			CardSuit suit = CardSuit.Hearts;
			PlayingCard target = new PlayingCard(rank, suit);
			string expected = "3H";
			string actual = target.Code;
			Assert.AreEqual(expected, actual);
		}
		[TestMethod]
		public void ToStringTest()
		{
			PlayingCard card = new PlayingCard(7, CardSuit.Hearts);
			Assert.AreEqual("XX",card.ToString());
			card.Flip();
			Assert.AreEqual("7H", card.Code);
		}
		[TestMethod]
		public void PlayingCardConstructorTest()
		{
			int rank = 4;
			CardSuit suit = CardSuit.Diamonds;
			PlayingCard target = new PlayingCard(rank, suit);
			Assert.AreEqual(4, target.Rank);
			Assert.AreEqual(CardSuit.Diamonds, target.Suit);
		}
		[TestMethod]
		public void EyeTest()
		{
			// one-eyes
			int rank = PlayingCard.Jack;
			CardSuit suit = CardSuit.Hearts;
			PlayingCard target = new PlayingCard(rank, suit);
			Assert.AreEqual(1, target.Eyes);

			rank = PlayingCard.Jack;
			suit = CardSuit.Spades;
			target = new PlayingCard(rank, suit);
			Assert.AreEqual(1, target.Eyes);

			rank = PlayingCard.King;
			suit = CardSuit.Diamonds;
			target = new PlayingCard(rank, suit);
			Assert.AreEqual(1, target.Eyes);

			// two-eyes
			rank = PlayingCard.King;
			suit = CardSuit.Clubs;
			target = new PlayingCard(rank, suit);
			Assert.AreEqual(2, target.Eyes);

			rank = PlayingCard.Queen;
			suit = CardSuit.Diamonds;
			target = new PlayingCard(rank, suit);
			Assert.AreEqual(2, target.Eyes);

			rank = PlayingCard.Jack;
			suit = CardSuit.Diamonds;
			target = new PlayingCard(rank, suit);
			Assert.AreEqual(2, target.Eyes);
			// no eyes
			target = new PlayingCard(3, CardSuit.Diamonds);
			Assert.AreEqual(0, target.Eyes);
		}
		[TestMethod]
		public void PlayingCardFactoryTest()
		{
			PlayingCard c1 = PlayingCard.Parse("AS");
			Assert.AreEqual(PlayingCard.Ace, c1.Rank);
			Assert.AreEqual(CardSuit.Spades, c1.Suit);
			PlayingCard c2 = PlayingCard.Parse("4D");
			Assert.AreEqual(4, c2.Rank);
			Assert.AreEqual(CardSuit.Diamonds, c2.Suit);
		}
	}
}
