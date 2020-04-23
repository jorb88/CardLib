using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardLib;

namespace CardLibTests
{
	[TestClass]
	public class GameHandTests
	{
		[TestMethod]
		public void CountTest()
		{
			GameHand hand = new MockGameHand();
			Assert.AreEqual(0, hand.Count);
			hand.AddCard(new PlayingCard(4, CardSuit.Diamonds));
			Assert.AreEqual(1, hand.Count);
			hand.AddCard(new PlayingCard(PlayingCard.King, CardSuit.Diamonds));
			Assert.AreEqual(2, hand.Count);
			hand.AddCard(new PlayingCard(10, CardSuit.Diamonds));
			Assert.AreEqual(3, hand.Count);
			hand.AddCard(new PlayingCard(PlayingCard.Queen, CardSuit.Diamonds));
			Assert.AreEqual(4, hand.Count);
			hand.AddCard(new PlayingCard(PlayingCard.Ace, CardSuit.Diamonds));
			Assert.AreEqual(5, hand.Count);
		}
		[TestMethod]
		public void AddCardTest()
		{
			GameHand hand = new MockGameHand();
			Assert.AreEqual(0, hand.Count);
			PlayingCard card = new PlayingCard(2, CardSuit.Hearts);
			hand.AddCard(card);
			Assert.AreEqual(1, hand.Count);
		}
		[TestMethod]
		public void ItemTest()
		{
			GameHand hand = new MockGameHand();
			PlayingCard card0 = new PlayingCard(4, CardSuit.Diamonds);
			hand.AddCard(card0);
			hand.AddCard(new PlayingCard(PlayingCard.King, CardSuit.Diamonds));
			hand.AddCard(new PlayingCard(10, CardSuit.Diamonds));
			PlayingCard card3 = new PlayingCard(PlayingCard.Queen, CardSuit.Diamonds);
			hand.AddCard(card3);
			PlayingCard card4 = new PlayingCard(PlayingCard.Ace, CardSuit.Diamonds);
			hand.AddCard(card4);
			Assert.AreSame(card0, hand[0]);
			Assert.AreSame(card3, hand[3]);
			Assert.AreSame(card4, hand[4]);
		}
	}
}
