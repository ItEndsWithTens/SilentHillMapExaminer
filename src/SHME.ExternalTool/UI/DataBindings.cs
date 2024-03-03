using Nucs.JsonSettings;
using SHME.ExternalTool.Extras;
using System;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public static class BindingExtensions
	{
		public static void AddBinding(this Control c, JsonSettings s,
			string cProp, string sProp, DataSourceUpdateMode m,
			ConvertEventHandler? f = null, ConvertEventHandler? p = null)
		{
			var b = new Binding(cProp, s, sProp, f != null || p != null, m)
			{
				ControlUpdateMode = ControlUpdateMode.Never
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
			string name = form.GetFieldName(nud).Substring(3);
			BindingFlags flags = BindingFlags.Static | BindingFlags.Public;

			FieldInfo info =
				typeof(DefaultRoamingSettings).GetField(name, flags) ??
				typeof(DefaultLocalSettings).GetField(name, flags);

			if (info == null)
			{
				return;
			}

			if (!Decimal.TryParse(nud.Text, out decimal _))
			{
				nud.Value = (decimal)info.GetValue(form);
				nud.Text = nud.Value.ToString(CultureInfo.CurrentCulture);
			}
		}
	}

	public partial class CustomMainForm
	{
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
								settings,
								nameof(cbx.Checked),
								prop.Name,
								DataSourceUpdateMode.OnPropertyChanged);
							cbx.Checked = (bool)prop.GetValue(settings);
							break;
						case "Cmb":
							var cmb = (ComboBox)info.GetValue(this);
							cmb.AddBinding(
								settings,
								nameof(cmb.SelectedIndex),
								prop.Name,
								DataSourceUpdateMode.OnPropertyChanged);
							cmb.SelectedIndex = (int)prop.GetValue(settings);
							break;
						case "Nud":
							var nud = (NumericUpDown)info.GetValue(this);
							nud.AddBinding(
								settings,
								nameof(nud.Value),
								prop.Name,
								DataSourceUpdateMode.OnPropertyChanged);
							nud.Value = (decimal)prop.GetValue(settings);
							break;
						case "Rdo":
							var rdo = (RadioButton)info.GetValue(this);
							rdo.AddBinding(
								settings,
								nameof(rdo.Checked),
								prop.Name,
								DataSourceUpdateMode.OnPropertyChanged);
							rdo.Checked = (bool)prop.GetValue(settings);
							break;
						case "Trk":
							var trk = (TrackBar)info.GetValue(this);
							trk.AddBinding(
								settings,
								nameof(trk.Value),
								prop.Name,
								DataSourceUpdateMode.OnPropertyChanged);
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
		}
	}
}
