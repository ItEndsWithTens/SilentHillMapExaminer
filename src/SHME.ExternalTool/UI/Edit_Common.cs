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

	private int _topBeforeP;
	private int _topBeforeT;
	private int _topBeforeA;
	private int _topBeforeC;
	private int _selectedBeforeP;
	private int _selectedBeforeT;
	private int _selectedBeforeA;
	private int _selectedBeforeC;
	private void BeginArrayUpdate()
	{
		_topBeforeP = LbxPois.TopIndex;
		_topBeforeT = LbxTriggers.TopIndex;
		_topBeforeA = LbxPoiAssociatedTriggers.TopIndex;
		_topBeforeC = LbxCameraPaths.TopIndex;

		_selectedBeforeP = LbxPois.SelectedIndex;
		_selectedBeforeT = LbxTriggers.SelectedIndex;
		_selectedBeforeA = LbxPoiAssociatedTriggers.SelectedIndex;
		_selectedBeforeC = LbxCameraPaths.SelectedIndex;

		LbxPois.BeginUpdate();
		LbxTriggers.BeginUpdate();
		LbxPoiAssociatedTriggers.BeginUpdate();
		LbxCameraPaths.BeginUpdate();
	}
	private void EndArrayUpdate()
	{
		LbxPois.SelectedIndex = _selectedBeforeP;
		LbxTriggers.SelectedIndex = _selectedBeforeT;
		LbxPoiAssociatedTriggers.SelectedIndex = _selectedBeforeA;
		LbxCameraPaths.SelectedIndex = _selectedBeforeC;

		LbxPois.TopIndex = _topBeforeP;
		LbxTriggers.TopIndex = _topBeforeT;
		LbxPoiAssociatedTriggers.TopIndex = _topBeforeA;
		LbxCameraPaths.TopIndex = _topBeforeC;

		LbxPois.EndUpdate();
		LbxTriggers.EndUpdate();
		LbxPoiAssociatedTriggers.EndUpdate();
		LbxCameraPaths.EndUpdate();
	}

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
