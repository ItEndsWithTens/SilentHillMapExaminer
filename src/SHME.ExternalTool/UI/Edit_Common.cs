using SHME.ExternalTool;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

	private readonly Dictionary<Type, IList<(string, IList<Control>)>> _fontChangeMap = [];
	private void InitializeEditBindings()
	{
		List<(string, IList<Control>)> cameraPathFontChangeMap = [
			(nameof(CameraPath.Disabled), [CbxSelectedCameraPathDisabled]),
			($"{nameof(CameraPath.VolumeMin)}.X", [TbxCameraPathVolumeMinX]),
			($"{nameof(CameraPath.VolumeMin)}.Y", [TbxCameraPathVolumeMinY]),
			($"{nameof(CameraPath.VolumeMin)}.Z", [TbxCameraPathVolumeMinZ]),
			($"{nameof(CameraPath.VolumeMax)}.X", [TbxCameraPathVolumeMaxX]),
			($"{nameof(CameraPath.VolumeMax)}.Y", [TbxCameraPathVolumeMaxY]),
			($"{nameof(CameraPath.VolumeMax)}.Z", [TbxCameraPathVolumeMaxZ]),
			(nameof(CameraPath.AreaMinX), [TbxCameraPathAreaMinX]),
			(nameof(CameraPath.AreaMinZ), [TbxCameraPathAreaMinZ]),
			(nameof(CameraPath.AreaMaxX), [TbxCameraPathAreaMaxX]),
			(nameof(CameraPath.AreaMaxZ), [TbxCameraPathAreaMaxZ]),
			(nameof(CameraPath.Thing4), [MtbCameraPathThing4]),
			(nameof(CameraPath.Thing5), [MtbCameraPathThing5]),
			(nameof(CameraPath.Thing6), [MtbCameraPathThing6]),
			(nameof(CameraPath.Pitch), [TbxCameraPathPitch]),
			(nameof(CameraPath.Yaw), [TbxCameraPathYaw])];

		List<(string, IList<Control>)> poiFontChangeMap = [
			(nameof(PointOfInterest.X), [TbxSelectedPoiX]),
			(nameof(PointOfInterest.Z), [TbxSelectedPoiZ]),
			(nameof(PointOfInterest.Geometry), [
				MtbSelectedPoiGeometry,
				MtbSelectedTriggerPoiGeometry])];

		List<(string, IList<Control>)> triggerFontChangeMap = [
			(nameof(Trigger.Disabled), [CbxSelectedTriggerDisabled]),
			(nameof(Trigger.Thing0), [MtbSelectedTriggerThing0]),
			(nameof(Trigger.Thing1), [MtbSelectedTriggerThing1]),
			(nameof(Trigger.FiredGroup), [
				NudSelectedTriggerFiredGroup,
				LblSelectedTriggerFiredDetails]),
			(nameof(Trigger.Fired), [CbxSelectedTriggerFired]),
			(nameof(Trigger.Thing2), [MtbSelectedTriggerThing2]),
			(nameof(Trigger.Style), [CmbSelectedTriggerStyle]),
			(nameof(Trigger.PoiIndex), [NudSelectedTriggerPoiIndex]),
			(nameof(Trigger.Thing3), [MtbSelectedTriggerThing3]),
			(nameof(Trigger.Thing4), [MtbSelectedTriggerThing4]),
			(nameof(Trigger.TriggerType), [CmbSelectedTriggerType]),
			(nameof(Trigger.TargetIndex), [NudSelectedTriggerTargetIndex]),
			(nameof(Trigger.Thing5), [MtbSelectedTriggerThing5]),
			(nameof(Trigger.Thing6), [MtbSelectedTriggerThing6]),
			(nameof(Trigger.StageIndex), [NudSelectedTriggerStageIndex]),
			(nameof(Trigger.SomeBool), [CbxSelectedTriggerSomeBool])];

		_fontChangeMap.Clear();
		_fontChangeMap.Add(typeof(CameraPath), cameraPathFontChangeMap);
		_fontChangeMap.Add(typeof(PointOfInterest), poiFontChangeMap);
		_fontChangeMap.Add(typeof(Trigger), triggerFontChangeMap);
	}

	private static object? GetMemberFromObject(object o, string name)
	{
		return GetMemberFromObject(o, name.Split('.'));
	}
	private static object? GetMemberFromObject(object o, Span<string> chain)
	{
		BindingFlags flags =
			BindingFlags.Static |
			BindingFlags.Instance |
			BindingFlags.Public |
			BindingFlags.NonPublic;

		MemberInfo info = o
			.GetType()
			.GetMember(chain[0], flags)
			.FirstOrDefault();

		object? member = info.MemberType switch
		{
			MemberTypes.Field => ((FieldInfo)info).GetValue(o),
			MemberTypes.Property => ((PropertyInfo)info).GetValue(o),
			_ => throw new ArgumentException("Couldn't find member!", nameof(chain))
		};

		if (chain.Length > 1)
		{
			return GetMemberFromObject(member, chain.Slice(1));
		}
		else
		{
			return member;
		}
	}

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

	private Font _fontDefaultValue = DefaultFont;
	private Font _fontChangedValue = new(DefaultFont, FontStyle.Bold);
	private void MakeBoldIfChanged(Control ctrl, SilentHillType changed, string name)
	{
		if (Guts.Stage is null)
		{
			return;
		}

		MainRamAddresses ram = Rom.Addresses.MainRam;
		int ofs = (int)(changed.Address - ram.StageHeader);

		ReadOnlySpan<byte> slice = Guts.Stage
			.ToBytes()
			.Slice(ofs, changed.SizeInBytes);

		SilentHillType reset = changed switch
		{
			CameraPath => new CameraPath(changed.Address, slice),
			PointOfInterest => new PointOfInterest(changed.Address, slice),
			Trigger => new Trigger(changed.Address, slice),
			_ => throw new ArgumentException("Unknown SilentHillType subclass!", nameof(changed))
		};

		object? memberC = GetMemberFromObject(changed, name);
		object? memberR = GetMemberFromObject(reset, name);

		if (memberC != null && memberR != null && memberC.Equals(memberR))
		{
			ctrl.Font = _fontDefaultValue;
		}
		else
		{
			ctrl.Font = _fontChangedValue;
		}
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
