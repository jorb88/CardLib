using System;
namespace CardLib
{
	public interface ICardGame
	{
		/// <summary>
		/// All card games must support the observer pattern. Registration is
		/// done via the GameStateChanged event.
		/// </summary>
		event EventHandler GameStateChanged;

		/// <summary>
		/// Capability profile - what each game can do in any given state.
		/// </summary>
		bool CanDo(int action);

		/// <summary>
		/// Label tags - text for the labels under each player's card images.
		/// </summary>
		string LabelText(int position);

		/// <summary>
		/// Message to be displayed as a summary (status line).
		/// </summary>
		string Message { get; }

		/// <summary>
		/// Total number of hands played - statistics.
		/// </summary>
		int Hands { get; }

		/// <summary>
		/// Total number of times the player has won.
		/// </summary>
		double Wins { get; }

		/// <summary>
		/// The player's hand.
		/// </summary>
		GameHand PlayerHand { get; }

		/// <summary>
		/// The system's hand
		/// </summary>
		GameHand SystemHand { get; }
	}
}
