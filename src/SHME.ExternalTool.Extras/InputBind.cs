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
		View,
		Map,
		Option
	}

	public class InputBind(ShmeCommand command, Keys keyBind, MouseButtons mouseBind, string buttonName)
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public ShmeCommand Command { get; set; } = command;

		[JsonConverter(typeof(StringEnumConverter))]
		public Keys KeyBind { get; set; } = keyBind;

		[JsonConverter(typeof(StringEnumConverter))]
		public MouseButtons MouseBind { get; set; } = mouseBind;

		[JsonIgnore]
		public string ButtonName { get; set; } = buttonName;

		public InputBind(ShmeCommand command, Keys keyBind, MouseButtons mouseBind) : this(command, keyBind, mouseBind, String.Empty)
		{
		}
		public InputBind(InputBind b) : this(b.Command, b.KeyBind, b.MouseBind, b.ButtonName)
		{
		}
	}
}
