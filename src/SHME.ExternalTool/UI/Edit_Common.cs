using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk;

partial class CustomMainForm
{
	/// <summary>
	/// Whether a change to the game's memory was initiated by the user
	/// or is the result of the game itself updating something. Used for
	/// avoiding infinite loops when syncing form controls to the game.
	/// </summary>
	private bool _userChange;

	private void HexMaskedTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
	{
		bool alphanumeric =
			(e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.Z) ||
			(e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9);

		if (!alphanumeric || sender is not MaskedTextBox mtb)
		{
			return;
		}

		// If either of the two literals in the hex prefix "0x" are
		// selected when starting to type in a MaskedTextBox, the first
		// character typed will be swallowed. To instead overwrite the
		// first editable character, reset the selection before KeyDown.
		if (mtb.SelectionStart < 2)
		{
			mtb.SelectionLength = 0;
			mtb.SelectionStart = 2;
		}
	}
}
