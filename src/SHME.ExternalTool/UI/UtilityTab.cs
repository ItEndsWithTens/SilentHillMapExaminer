﻿using SHME.ExternalTool;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private Timer FixedPointErrorClearTimer { get; } = new Timer()
		{
			Interval = 3000
		};

		private Timer AnglesErrorClearTimer { get; } = new Timer()
		{
			Interval = 3000
		};

		private void InitializeUtilityTab()
		{
			CmbUtilityFixedPointFormat.SelectedIndex = 0;

			FixedPointErrorClearTimer.Tick += FixedPointErrorClearTimer_Tick;
			AnglesErrorClearTimer.Tick += AnglesErrorClearTimer_Tick;
		}

		private static bool ParseQFormatString(string format, out int integral, out int fractional)
		{
			integral = 0;
			fractional = 0;

			if (String.IsNullOrEmpty(format))
			{
				return false;
			}

			string t = format.Trim().Trim('q', 'Q');

			int dot = t.IndexOf('.');
			if (dot == -1)
			{
				return false;
			}

			if (!Int32.TryParse(t.Substring(0, dot), out integral))
			{
				return false;
			}

			if (!Int32.TryParse(t.Substring(dot + 1), out fractional))
			{
				return false;
			}

			return true;
		}

		private void CmbUtilityFixedPointFormat_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				e.SuppressKeyPress = true;

				TbxUtilityFixedPointFloat.Text = String.Empty;
				TbxUtilityFixedPointQ.Text = String.Empty;

				// Upon a KeyDown event, the Text property has been updated, so
				// in contrast to the SelectionChangeCommitted event, the box's
				// content has been successfully changed and is ready for use.
				if (!ParseQFormatString(CmbUtilityFixedPointFormat.Text, out int _, out int _))
				{
					LblUtilityFixedPointError.Text = "Invalid Q format string!";
				}
				else
				{
					LblUtilityFixedPointError.Text = "None";
				}

				FixedPointErrorClearTimer.Stop();
				FixedPointErrorClearTimer.Start();
			}
		}

		private void CmbUtilityFixedPointFormat_SelectionChangeCommitted(object sender, EventArgs e)
		{
			TbxUtilityFixedPointFloat.Text = String.Empty;
			TbxUtilityFixedPointQ.Text = String.Empty;

			// Using the SelectedItem property of the ComboBox provides the text
			// being committed, whereas the Text property gives the old content.
			if (!ParseQFormatString(CmbUtilityFixedPointFormat.SelectedItem as string, out int _, out int _))
			{
				LblUtilityFixedPointError.Text = "Invalid Q format string!";
			}
			else
			{
				LblUtilityFixedPointError.Text = "None";
			}

			FixedPointErrorClearTimer.Stop();
			FixedPointErrorClearTimer.Start();
		}

		private void TbxUtilityFixedPointFloat_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				return;
			}

			e.SuppressKeyPress = true;

			if (!Single.TryParse(TbxUtilityFixedPointFloat.Text, out float num))
			{
				return;
			}

			if (!ParseQFormatString(CmbUtilityFixedPointFormat.Text, out int i, out int f))
			{
				return;
			}

			int q = Core.FloatToQ(num, f);

			TbxUtilityFixedPointQ.Text = (i + f) switch
			{
				8 => $"0x{(byte)q:X}",
				16 => $"0x{(short)q:X}",
				_ => $"0x{q:X}"
			};
		}

		private void TbxUtilityFixedPointQ_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				return;
			}

			e.SuppressKeyPress = true;

			if (!ParseQFormatString(CmbUtilityFixedPointFormat.Text, out int i, out int f))
			{
				return;
			}

			string text = TbxUtilityFixedPointQ.Text
				.Trim()
				.Replace("0x", "")
				.Replace("0X", "");

			NumberStyles style = NumberStyles.HexNumber;
			IFormatProvider p = CultureInfo.CurrentCulture;

			int q;
			try
			{
				q = (i + f) switch
				{
					8 => Byte.Parse(text, style, p),
					16 => Int16.Parse(text, style, p),
					_ => Int32.Parse(text, style, p)
				};
			}
			catch (Exception err) when (
				err is ArgumentException ||
				err is ArgumentNullException ||
				err is FormatException ||
				err is OverflowException)
			{
				TbxUtilityFixedPointFloat.Clear();
				LblUtilityFixedPointError.Text = err.Message;
				FixedPointErrorClearTimer.Stop();
				FixedPointErrorClearTimer.Start();
				return;
			}

			LblUtilityFixedPointError.Text = "None";
			FixedPointErrorClearTimer.Stop();
			FixedPointErrorClearTimer.Start();

			float num = Core.QToFloat(q, f);

			TbxUtilityFixedPointFloat.Text = num.ToString();
		}

		private void TbxUtilityAnglesGameUnits_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				return;
			}

			e.SuppressKeyPress = true;

			string text = TbxUtilityAnglesGameUnits.Text
				.Trim()
				.Replace("0x", "")
				.Replace("0X", "");

			if (String.IsNullOrEmpty(text))
			{
				return;
			}

			NumberStyles style = NumberStyles.HexNumber;
			IFormatProvider p = CultureInfo.CurrentCulture;

			ushort hex;
			try
			{
				hex = UInt16.Parse(text, style, p);
			}
			catch (Exception err) when (
				err is ArgumentException ||
				err is ArgumentNullException ||
				err is FormatException ||
				err is OverflowException)
			{
				LblUtilityAnglesError.Text = err.Message;
				AnglesErrorClearTimer.Stop();
				AnglesErrorClearTimer.Start();
				return;
			}

			TbxUtilityAnglesDegrees.Text = Core.GameUnitsToDegrees(hex).ToString();
			LblUtilityAnglesError.Text = "None";
			AnglesErrorClearTimer.Stop();
			AnglesErrorClearTimer.Start();
		}

		private void TbxUtilityAnglesDegrees_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter)
			{
				return;
			}

			e.SuppressKeyPress = true;

			string text = TbxUtilityAnglesDegrees.Text.Trim();

			if (String.IsNullOrEmpty(text))
			{
				return;
			}

			NumberStyles style = NumberStyles.Number;
			IFormatProvider p = CultureInfo.CurrentCulture;

			float num;
			try
			{
				num = Single.Parse(text, style, p);
			}
			catch (Exception err) when (
				err is ArgumentException ||
				err is ArgumentNullException ||
				err is FormatException ||
				err is OverflowException)
			{
				LblUtilityAnglesError.Text = err.Message;
				AnglesErrorClearTimer.Stop();
				AnglesErrorClearTimer.Start();
				return;
			}

			uint u = Core.DegreesToGameUnits(num);
			TbxUtilityAnglesGameUnits.Text = $"0x{u:X}";
			LblUtilityAnglesError.Text = "None";
			AnglesErrorClearTimer.Stop();
			AnglesErrorClearTimer.Start();
		}

		private void FixedPointErrorClearTimer_Tick(object sender, EventArgs e)
		{
			LblUtilityFixedPointError.Text = String.Empty;

			FixedPointErrorClearTimer.Stop();
		}

		private void AnglesErrorClearTimer_Tick(object sender, EventArgs e)
		{
			LblUtilityAnglesError.Text = String.Empty;

			AnglesErrorClearTimer.Stop();
		}
	}
}
