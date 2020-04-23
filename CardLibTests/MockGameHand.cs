using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardLib;

namespace CardLibTests
{
	public class MockGameHand : GameHand
	{
		public override long Score
		{
			get { return 0; }
		}
	}
}
