using BizHawk.Client.EmuHawk;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SHME.ExternalTool
{
	public struct ControllerConfig : IEquatable<ControllerConfig>
	{
		public static int Size => 28;

		public PsxButtons Enter { get; set; }
		public PsxButtons Cancel { get; set; }
		public PsxButtons Skip { get; set; }
		public PsxButtons Action { get; set; }
		public PsxButtons Aim { get; set; }
		public PsxButtons Light { get; set; }
		public PsxButtons Run { get; set; }
		public PsxButtons View { get; set; }
		public PsxButtons StepL { get; set; }
		public PsxButtons StepR { get; set; }
		public PsxButtons Pause { get; set; }
		public PsxButtons Item { get; set; }
		public PsxButtons Map { get; set; }
		public PsxButtons Option { get; set; }

		public readonly IReadOnlyList<PsxButtons> Commands => [
			Enter,
			Cancel,
			Skip,
			Action,
			Aim,
			Light,
			Run,
			View,
			StepL,
			StepR,
			Pause,
			Item,
			Map,
			Option];

		public ControllerConfig(IReadOnlyList<byte> list) : this(list.ToArray())
		{
		}
		public ControllerConfig(byte[] bytes)
		{
			if (bytes == null)
			{
				throw new ArgumentNullException(nameof(bytes));
			}
			else if (bytes.Length < 28)
			{
				throw new ArgumentException($"Not enough bytes for a {nameof(ControllerConfig)}!");
			}

			Enter = (PsxButtons)BitConverter.ToUInt16(bytes, 0);
			Cancel = (PsxButtons)BitConverter.ToUInt16(bytes, 2);
			Skip = (PsxButtons)BitConverter.ToUInt16(bytes, 4);
			Action = (PsxButtons)BitConverter.ToUInt16(bytes, 6);
			Aim = (PsxButtons)BitConverter.ToUInt16(bytes, 8);
			Light = (PsxButtons)BitConverter.ToUInt16(bytes, 10);
			Run = (PsxButtons)BitConverter.ToUInt16(bytes, 12);
			View = (PsxButtons)BitConverter.ToUInt16(bytes, 14);
			StepL = (PsxButtons)BitConverter.ToUInt16(bytes, 16);
			StepR = (PsxButtons)BitConverter.ToUInt16(bytes, 18);
			Pause = (PsxButtons)BitConverter.ToUInt16(bytes, 20);
			Item = (PsxButtons)BitConverter.ToUInt16(bytes, 22);
			Map = (PsxButtons)BitConverter.ToUInt16(bytes, 24);
			Option = (PsxButtons)BitConverter.ToUInt16(bytes, 26);
		}

		public override readonly bool Equals(object? obj)
		{
			return obj is ControllerConfig layout && Equals(layout);
		}

		public readonly bool Equals(ControllerConfig other)
		{
			return
				Enter == other.Enter &&
				Cancel == other.Cancel &&
				Skip == other.Skip &&
				Action == other.Action &&
				Aim == other.Aim &&
				Light == other.Light &&
				Run == other.Run &&
				View == other.View &&
				StepL == other.StepL &&
				StepR == other.StepR &&
				Pause == other.Pause &&
				Item == other.Item &&
				Map == other.Map &&
				Option == other.Option;
		}

		public override readonly int GetHashCode()
		{
			int hashCode = 633199160;
			hashCode = hashCode * -1521134295 + Enter.GetHashCode();
			hashCode = hashCode * -1521134295 + Cancel.GetHashCode();
			hashCode = hashCode * -1521134295 + Skip.GetHashCode();
			hashCode = hashCode * -1521134295 + Action.GetHashCode();
			hashCode = hashCode * -1521134295 + Aim.GetHashCode();
			hashCode = hashCode * -1521134295 + Light.GetHashCode();
			hashCode = hashCode * -1521134295 + Run.GetHashCode();
			hashCode = hashCode * -1521134295 + View.GetHashCode();
			hashCode = hashCode * -1521134295 + StepL.GetHashCode();
			hashCode = hashCode * -1521134295 + StepR.GetHashCode();
			hashCode = hashCode * -1521134295 + Pause.GetHashCode();
			hashCode = hashCode * -1521134295 + Item.GetHashCode();
			hashCode = hashCode * -1521134295 + Map.GetHashCode();
			hashCode = hashCode * -1521134295 + Option.GetHashCode();
			return hashCode;
		}

		public static bool operator ==(ControllerConfig left, ControllerConfig right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ControllerConfig left, ControllerConfig right)
		{
			return !(left == right);
		}
	}
}
