using System;
using System.Collections.Generic;
using System.Text;

namespace CardLib
{
	/// <summary>
	/// Special random number class. Currently uses .NET random number but implemented as
	/// a singleton so that it can be replaced with a more professional randome number
	/// generator as needed for professional gaming. Limited to the Next() function only.
	/// Also, this avoids having numerous different instances of Random being instantiated
	/// throughout the application.
	/// </summary>
	public sealed class RandomNumber
	{
		private RandomNumber() { }
		private static Random Instance = new Random();
		public static int Next() { return Instance.Next(); }
		public static int Next(int maxValue) { return Instance.Next(maxValue); }
		public static int Next(int minValue, int maxValue) { return Instance.Next(minValue, maxValue); }
		public static bool FiftyFifty { get { return (RandomNumber.Next(0, 2) == 0); } }
	}
}
