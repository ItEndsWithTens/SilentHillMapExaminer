using Nucs.JsonSettings;
using SHME.ExternalTool.Extras;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public static class BindingExtensions
	{
		public static void AddBinding(this Control c,
			ref IList<Binding> bindings, JsonSettings s,
			string cProp, string sProp,
			ConvertEventHandler? f = null, ConvertEventHandler? p = null)
		{
			var b = new Binding(cProp, s, sProp, f != null || p != null)
			{
				// Prepare to set the initial control value from the stored
				// setting, and trust later code to reverse the relationship.
				ControlUpdateMode = ControlUpdateMode.OnPropertyChanged,
				DataSourceUpdateMode = DataSourceUpdateMode.Never
			};

			if (f != null)
			{
				b.Format += f;
			}

			if (p != null)
			{
				b.Parse += p;
			}

			c.DataBindings.Clear();
			c.DataBindings.Add(b);

			bindings.Add(b);
		}

		public static string GetFieldName(this CustomMainForm f, object o)
		{
			string name = String.Empty;

			Type thisType = typeof(CustomMainForm);
			FieldInfo[] fields = thisType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo field in fields)
			{
				if (ReferenceEquals(field.GetValue(f), o))
				{
					name = field.Name;
					break;
				}
			}

			return name;
		}

		public static void ResetIfBad(this NumericUpDown nud, CustomMainForm form)
		{
			if (Decimal.TryParse(nud.Text, out decimal _))
			{
				return;
			}

			string name = form.GetFieldName(nud).Substring(3);
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public;

			FieldInfo info =
				typeof(DefaultRoamingSettings).GetField(name, flags) ??
				typeof(DefaultLocalSettings).GetField(name, flags);

			if (info == null)
			{
				return;
			}

			nud.Value = (decimal)info.GetValue(form);
			nud.Text = nud.Value.ToString(CultureInfo.CurrentCulture);
		}
	}

	public partial class CustomMainForm
	{
		private IList<Binding> _settingsBindings = [];

		private void BindSettings(PropertyInfo[] props, JsonSettings settings)
		{
			string[] prefixes = ["Cbx", "Cmb", "Nud", "Rdo", "Trk"];
			Type formType = typeof(CustomMainForm);
			foreach (PropertyInfo prop in props)
			{
				foreach (string prefix in prefixes)
				{
					FieldInfo info = formType.GetField($"{prefix}{prop.Name}", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					if (info == null)
					{
						continue;
					}

					switch (prefix)
					{
						case "Cbx":
							var cbx = (CheckBox)info.GetValue(this);
							cbx.AddBinding(
								ref _settingsBindings,
								settings,
								nameof(cbx.Checked),
								prop.Name);
							cbx.Checked = (bool)prop.GetValue(settings);
							break;
						case "Cmb":
							var cmb = (ComboBox)info.GetValue(this);
							cmb.AddBinding(
								ref _settingsBindings,
								settings,
								nameof(cmb.SelectedIndex),
								prop.Name);
							cmb.SelectedIndex = (int)prop.GetValue(settings);
							break;
						case "Nud":
							var nud = (NumericUpDown)info.GetValue(this);
							nud.AddBinding(
								ref _settingsBindings,
								settings,
								nameof(nud.Value),
								prop.Name);
							nud.Value = (decimal)prop.GetValue(settings);
							break;
						case "Rdo":
							var rdo = (RadioButton)info.GetValue(this);
							rdo.AddBinding(
								ref _settingsBindings,
								settings,
								nameof(rdo.Checked),
								prop.Name);
							rdo.Checked = (bool)prop.GetValue(settings);
							break;
						case "Trk":
							var trk = (TrackBar)info.GetValue(this);
							trk.AddBinding(
								ref _settingsBindings,
								settings,
								nameof(trk.Value),
								prop.Name);
							trk.Value = (int)prop.GetValue(settings);
							break;
						default:
							break;
					}

					break;
				}
			}
		}

		private void InitializeDataBindings()
		{
			BindSettings(typeof(LocalSettings).GetProperties(), Settings.Local);
			BindSettings(typeof(RoamingSettings).GetProperties(), Settings.Roaming);

			// Now that the controls have all been initialized with values read
			// from Settings, reverse the flow so the controls call the shots.
			foreach (Binding binding in _settingsBindings)
			{
				binding.ControlUpdateMode = ControlUpdateMode.Never;
				binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
			}
		}
	}
}
