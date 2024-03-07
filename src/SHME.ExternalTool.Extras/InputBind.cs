using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Windows.Forms;

namespace SHME.ExternalTool.Extras
{
	[Flags]
	public enum ShmeCommand
	{
		None,
		Forward,
		Backward,
		Left,
		Right,
		Up,
		Down,
		Action,
		Aim,
		Light,
		Run,
		View
	}

	public class InputBind(ShmeCommand command, Keys keyBind, MouseButtons mouseBind)
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public ShmeCommand Command { get; set; } = command;

		[JsonConverter(typeof(StringEnumConverter))]
		public Keys KeyBind { get; set; } = keyBind;

		[JsonConverter(typeof(StringEnumConverter))]
		public MouseButtons MouseBind { get; set; } = mouseBind;

		public InputBind(InputBind b) : this(b.Command, b.KeyBind, b.MouseBind)
		{
		}
	}
}
