using SHME.ExternalTool.Extras;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SHME.ExternalTool.UI
{
	public partial class InputConfigForm : Form
	{
		private readonly Settings _settings;

		private bool _suppressSave;
		private bool _editing;
		private bool Editing
		{
			get => _editing;
			set
			{
				if (value == _editing)
				{
					return;
				}

				_editing = value;

				DataGridViewCell cell = DgvInputBinds.SelectedCells[0];
				if (value)
				{
					cell.Style.SelectionBackColor = Color.FromArgb(192, 255, 255);
					cell.Style.SelectionForeColor = Color.Black;
				}
				else
				{
					if (!_suppressSave)
					{
						_settings.Local.Save();
					}

					cell.Style.SelectionBackColor = DgvInputBinds.DefaultCellStyle.SelectionBackColor;
					cell.Style.SelectionForeColor = DgvInputBinds.DefaultCellStyle.SelectionForeColor;

					_suppressSave = false;
				}
			}
		}

		public InputConfigForm(Settings settings)
		{
			InitializeComponent();

			int border = 12;
			AutoScrollMargin = new Size(border, border);
			ClientSize = new Size(
				border + 540 + border,
				border + 540 + border);
			MaximumSize = Size;

			_settings = settings;

			DgvInputBinds.DataSource = _settings.Local.FirstPersonBinds;

			foreach (DataGridViewColumn col in DgvInputBinds.Columns)
			{
				// Columns don't need to be sortable anyway, but this property
				// turns out to be critical to allow the header text to be fully
				// centered. Otherwise the calculations leave room for the sort
				// triangle. The first column doesn't strictly need this, since
				// it's not editable, but no harm setting it explicitly for all.
				col.SortMode = DataGridViewColumnSortMode.NotSortable;
			}
		}

		private void FinishEditing(bool suppressSave = false)
		{
			if (!Editing)
			{
				return;
			}

			_suppressSave = suppressSave;
			Editing = false;
		}

		private void InputConfigForm_Shown(object sender, EventArgs e)
		{
			DgvInputBinds.ClearSelection();
		}

		private void DgvInputBinds_KeyDown(object sender, KeyEventArgs e)
		{
			if (!Editing || e.KeyCode == Keys.Escape)
			{
				FinishEditing(true);
				return;
			}

			DataGridViewCell cell = DgvInputBinds.SelectedCells[0];
			if (cell.OwningRow.DataBoundItem is not InputBind bind)
			{
				FinishEditing(true);
				return;
			}

			bool suppress = false;

			switch (cell.ColumnIndex)
			{
				case 2:
					if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
					{
						if (bind.MouseBind == MouseButtons.None)
						{
							suppress = true;
						}
						else
						{
							bind.MouseBind = MouseButtons.None;
						}
						break;
					}
					else
					{
						return;
					}

				case 1:
					if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
					{
						if (bind.KeyBind == Keys.None)
						{
							suppress = true;
							break;
						}
						else
						{
							bind.KeyBind = Keys.None;
						}
					}

					IEnumerable<InputBind> dupes = _settings.Local.FirstPersonBinds
						.Where((b) => b.KeyBind == e.KeyCode && b != bind);

					suppress = e.KeyCode == bind.KeyBind;
					foreach (InputBind dupe in dupes)
					{
						dupe.KeyBind = Keys.None;
						suppress = false;
					}

					bind.KeyBind = e.KeyCode;
					break;

				default:
					suppress = true;
					break;
			}

			FinishEditing(suppress);
		}

		private void DgvInputBinds_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				return;
			}

			Editing = true;
		}

		private void DgvInputBinds_CellLeave(object sender, DataGridViewCellEventArgs e)
		{
			FinishEditing(true);
		}

		private void DgvInputBinds_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (!Editing)
			{
				return;
			}

			DataGridViewCell cell = DgvInputBinds.SelectedCells[0];

			if (cell.ColumnIndex != 2)
			{
				return;
			}

			if (cell.OwningRow.DataBoundItem is not InputBind bind)
			{
				return;
			}

			IEnumerable<InputBind> dupes = _settings.Local.FirstPersonBinds
				.Where((b) => b.MouseBind == e.Button && !ReferenceEquals(b, bind));

			bool suppress = e.Button == bind.MouseBind;
			foreach (InputBind dupe in dupes)
			{
				dupe.MouseBind = MouseButtons.None;
				suppress = false;
			}

			bind.MouseBind = e.Button;

			FinishEditing(suppress);
		}
	}
}
