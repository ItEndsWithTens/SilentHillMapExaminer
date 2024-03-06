using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Windows.Forms;

namespace SHME.ExternalTool.Extras
{
	[Flags]
	public enum GameCommand
	{
		None,
		Forward,
		Backward,
		Action,
		Aim,
		Light,
		Run,
		View,
		StepLeft,
		StepRight
	}

	public class InputBind(GameCommand command, Keys keyBind, MouseButtons mouseBind)
	{
		[JsonConverter(typeof(StringEnumConverter))]
		public GameCommand Command { get; set; } = command;

		[JsonConverter(typeof(StringEnumConverter))]
		public Keys KeyBind { get; set; } = keyBind;

		[JsonConverter(typeof(StringEnumConverter))]
		public MouseButtons MouseBind { get; set; } = mouseBind;
	}
}
