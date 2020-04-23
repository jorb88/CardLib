using CardLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CardLibTests
{
	[TestClass]
	public class CardGamePublisherTests
	{
		[TestMethod]
		public void CardGamePublisherConstructorTest()
		{
			MockCardGame target = new MockCardGame();
			target.StateChanged += EventMethod;
			target.ChangeState();
			Assert.IsTrue(eventHappened);
		}
		private bool eventHappened = false;
		public void EventMethod(object sender,EventArgs e)
		{
			eventHappened = true;
		}
	}
	public class MockCardGame : Util.Publisher
	{
		public void ChangeState() { Notify(); }
	}
}
