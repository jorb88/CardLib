using System;

namespace CardLib
{
	public class Joker : PlayingCard
	{
		private const string JokerCode = "WJ";
		public Joker() : base(0,0) { Wild = true; } // Pretend we are the ace of clubs

		public override string Code { get { return JokerCode; } }

		public override string ToString() { return ToString(true); }

		public override string ToString(bool graphical)
		{
			if (!FaceUp) return base.ToString(graphical);
			if (graphical) return "W\u263A";
			return JokerCode;
		}

		public override int ImageIndex
		{
			get
			{
				if (FaceUp) return 53;
				return base.ImageIndex;
			}
		}
	}
}
