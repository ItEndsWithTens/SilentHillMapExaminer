using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BizHawk.Client.EmuHawk
{
	public static class StringExtensions
	{
		public static string PrintAsciiControlCharacters(this string s)
		{
			var sb = new StringBuilder();

			foreach (char c in s)
			{
				// Don't bother escaping ' and ", as they already print well.
				switch (c)
				{
					case '\\':
						sb.Append("\\");
						break;
					case '\0':
						sb.Append("\\0");
						break;
					case '\a':
						sb.Append("\\a");
						break;
					case '\b':
						sb.Append("\\b");
						break;
					case '\f':
						sb.Append("\\f");
						break;
					case '\n':
						sb.Append("\\n");
						break;
					case '\r':
						sb.Append("\\r");
						break;
					case '\t':
						sb.Append("\\t");
						break;
					case '\v':
						sb.Append("\\v");
						break;
					default:
						sb.Append(c);
						break;
				}
			}

			return sb.ToString();
		}
	}

	public partial class CustomMainForm
	{
		private void BtnReadStrings_Click(object sender, EventArgs e)
		{
			int arrayStart = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfPointersToStrings);
			arrayStart -= (int)Rom.Addresses.MainRam.BaseAddress;

			int arrayEnd = Mem!.ReadS32(Rom.Addresses.MainRam.PointerToArrayOfTriggersMaybe);
			arrayEnd -= (int)Rom.Addresses.MainRam.BaseAddress;

			int arrayBytes = arrayEnd - arrayStart;
			int stringCount = arrayBytes / sizeof(int);

			LblStringCount.Text = stringCount.ToString();

			var strings = new List<string>();
			for (int i = 0; i < stringCount; i++)
			{
				int pointer = Mem!.ReadS32(arrayStart + (sizeof(int) * i));
				pointer -= (int)Rom.Addresses.MainRam.BaseAddress;

				var sb = new StringBuilder();
				char current;
				do
				{
					current = (char)Mem!.ReadByte(pointer++);
					sb.Append(current);
				}
				while (current != '\0');

				strings.Add($"{i} (0x{i:X}):    {sb.ToString().PrintAsciiControlCharacters()}");
			}

			RtbStrings.Clear();
			if (strings.Count > 0)
			{
				RtbStrings.Text = strings.Aggregate((a, b) => a + '\n' + b);
			}
		}
	}
}
