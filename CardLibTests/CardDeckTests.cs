using CardLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CardLibTests
{
	[TestClass]
	public class CardDeckTests
	{
		[TestMethod]
		public void StackTest()
		{
			CardDeck target = new CardDeck();
			target.Shuffle();
			string CardCode = "QC";
			int pos = 0;
			target.Stack(CardCode, pos);
			PlayingCard card = target.Deal();
			Assert.AreEqual(CardCode, card.Code);
			target = new CardDeck();
			target.Shuffle();
			CardCode = "AS";
			pos = 5;
			target.Stack(CardCode, pos);
			for (int i = 0; i <= pos; i++)
				card = target.Deal();
			Assert.AreEqual(CardCode, card.Code);
		}
		[TestMethod]
		public void ShuffleTest()
		{
			// It is possible, but highly unlikely that the 1st five cards of a
			// shuffled deck would be the same as the first 5 cards in an unshuffled deck.
			CardDeck deck = new CardDeck();
			string c1 = deck.Deal().Code;
			string c2 = deck.Deal().Code;
			string c3 = deck.Deal().Code;
			string c4 = deck.Deal().Code;
			string c5 = deck.Deal().Code;
			deck = new CardDeck();
			deck.Shuffle();
			string a1 = deck.Deal().Code;
			string a2 = deck.Deal().Code;
			string a3 = deck.Deal().Code;
			string a4 = deck.Deal().Code;
			string a5 = deck.Deal().Code;
			Assert.IsFalse((c1 == a1) && (c2 == a2) && (c3 == a3) && (c4 == a4) && (c5 == a5));
		}
		[TestMethod]
		public void ShuffleStrategyTest()
		{
			// It is possible, but highly unlikely that the 1st five cards of a
			// shuffled deck would be the same as the first 5 cards in an unshuffled deck.
			CardDeck deck = new CardDeck();
			string c1 = deck.Deal().Code;
			string c2 = deck.Deal().Code;
			string c3 = deck.Deal().Code;
			string c4 = deck.Deal().Code;
			string c5 = deck.Deal().Code;
			deck = new CardDeck();
			deck.Shuffle(new KnuthShuffler());
			string a1 = deck.Deal().Code;
			string a2 = deck.Deal().Code;
			string a3 = deck.Deal().Code;
			string a4 = deck.Deal().Code;
			string a5 = deck.Deal().Code;
			Assert.IsFalse((c1 == a1) && (c2 == a2) && (c3 == a3) && (c4 == a4) && (c5 == a5));
		}
		[TestMethod]
		public void ShuffleDelegateStrategyTest()
		{
			// It is possible, but highly unlikely that the 1st five cards of a
			// shuffled deck would be the same as the first 5 cards in an unshuffled deck.
			CardDeck deck = new CardDeck();
			string c1 = deck.Deal().Code;
			string c2 = deck.Deal().Code;
			string c3 = deck.Deal().Code;
			string c4 = deck.Deal().Code;
			string c5 = deck.Deal().Code;
			deck = new CardDeck();
			IShuffler shuffler = new KnuthShuffler();
			deck.Shuffle(shuffler.Shuffle);
			string a1 = deck.Deal().Code;
			string a2 = deck.Deal().Code;
			string a3 = deck.Deal().Code;
			string a4 = deck.Deal().Code;
			string a5 = deck.Deal().Code;
			Assert.IsFalse((c1 == a1) && (c2 == a2) && (c3 == a3) && (c4 == a4) && (c5 == a5));
		}
		[TestMethod]
		public void ModifiedShuffleStrategyTest()
		{
			// It is possible, but highly unlikely that the 1st five cards of a
			// shuffled deck would be the same as the first 5 cards in an unshuffled deck.
			CardDeck deck = new CardDeck();
			string c1 = deck.Deal().Code;
			string c2 = deck.Deal().Code;
			string c3 = deck.Deal().Code;
			string c4 = deck.Deal().Code;
			string c5 = deck.Deal().Code;
			deck = new CardDeck();
			deck.Shuffle(new ModifiedKnuthShuffler());
			string a1 = deck.Deal().Code;
			string a2 = deck.Deal().Code;
			string a3 = deck.Deal().Code;
			string a4 = deck.Deal().Code;
			string a5 = deck.Deal().Code;
			Assert.IsFalse((c1 == a1) && (c2 == a2) && (c3 == a3) && (c4 == a4) && (c5 == a5));
		}
		[TestMethod]
		public void ReturnCardTest()
		{
			CardDeck target = new CardDeck();
			PlayingCard card = target.Deal();
			target.Add(card);
			card = target.Deal();
			Assert.AreEqual("KS", card.Code);
		}
		[TestMethod]
		public void DealTest()
		{
			CardDeck target = new CardDeck();
			PlayingCard card = target.Deal();
			Assert.AreEqual("KS", card.Code);
		}
	}
}
