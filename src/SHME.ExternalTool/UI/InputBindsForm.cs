using SHME.ExternalTool.Extras;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SHME.ExternalTool.UI
{
	public partial class InputBindsForm : Form
	{
		private object _settings = null!;
		private Settings Settings
		{
			get => (Settings)_settings;
			set => _settings = value;
		}

		// WinForms, running under Mono, has problems with padding DataGridView
		// cells, failing to take it into account when auto sizing and making
		// the contents of the cell invisible.
		private Padding _cellPadding = new Padding(10);

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

				DataGridViewCell cell;
				if (DgvFlyInputBinds.SelectedCells.Count > 0)
				{
					cell = DgvFlyInputBinds.SelectedCells[0];
				}
				else
				{
					cell = DgvFpsInputBinds.SelectedCells[0];
				}

				if (value)
				{
					cell.Style.SelectionBackColor = Color.FromArgb(192, 255, 255);
					cell.Style.SelectionForeColor = Color.Black;
				}
				else
				{
					if (!_suppressSave)
					{
						Settings.Local.Save();
					}
					else
					{
						_suppressSave = false;
					}

					cell.Style.SelectionBackColor = cell.DataGridView.DefaultCellStyle.SelectionBackColor;
					cell.Style.SelectionForeColor = cell.DataGridView.DefaultCellStyle.SelectionForeColor;
				}

				UpdateColumnSize(cell.DataGridView, _cellPadding, cell.ColumnIndex);
				UpdateRowSize(cell.DataGridView, _cellPadding, cell.RowIndex);

				cell.DataGridView.Refresh();
			}
		}

		public InputBindsForm(Settings settings)
		{
			InitializeComponent();

			int border = 12;
			AutoScrollMargin = new Size(border, border);
			ClientSize = new Size(
				border + 540 + border,
				border + 540 + border);
			MaximumSize = Size;

			Settings = settings;

			BuildColumns(DgvFlyInputBinds, Settings.Local.FlyBinds);
			BuildColumns(DgvFpsInputBinds, Settings.Local.FpsBinds);
		}

		private static void BuildColumns(DataGridView dgv, Collection<InputBind> binds)
		{
			dgv.AutoGenerateColumns = false;
			dgv.DataSource = binds;

			// Columns don't need to be sortable anyway, but this property turns
			// out to be critical to allow the header text to be fully centered,
			// otherwise the calculations leave room for the sort triangle. The
			// first column doesn't strictly need this, since it's not editable,
			// but no harm setting it explicitly for all.
			var sortMode = DataGridViewColumnSortMode.NotSortable;

			var commandColumn = new DataGridViewTextBoxColumn()
			{
				DataPropertyName = "Command",
				HeaderText = "Command",
				SortMode = sortMode
			};

			var keyColumn = new DataGridViewTextBoxColumn()
			{
				DataPropertyName = "KeyBind",
				HeaderText = "Key",
				SortMode = sortMode
			};

			var mouseColumn = new DataGridViewTextBoxColumn()
			{
				DataPropertyName = "MouseBind",
				HeaderText = "Mouse button",
				SortMode = sortMode
			};

			dgv.Columns.Add(commandColumn);
			dgv.Columns.Add(keyColumn);
			dgv.Columns.Add(mouseColumn);
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

		private void InputBindsForm_Shown(object sender, EventArgs e)
		{
			DgvFlyInputBinds.ClearSelection();
			DgvFpsInputBinds.ClearSelection();

			UpdateSize(DgvFlyInputBinds, _cellPadding);
			UpdateSize(DgvFpsInputBinds, _cellPadding);
		}

		private static void UpdateColumnSize(DataGridView dgv, Padding padding, int columnIndex)
		{
			int width = 0;
			foreach (DataGridViewRow row in dgv.Rows)
			{
				foreach(DataGridViewCell c in row.Cells)
				{
					if (c.ColumnIndex == columnIndex)
					{
						string? text = c.FormattedValue.ToString();
						if (text == null)
							continue;
						Size size = TextRenderer.MeasureText(text, dgv.DefaultCellStyle.Font);
						size.Width += padding.Left + padding.Right;
						if (size.Width > width)
							width = size.Width;
					}
				}
			}
			dgv.Columns[columnIndex].Width = width;
		}

		private static void UpdateRowSize(DataGridView dgv, Padding padding, int rowIndex)
		{
			int height = 0;
			foreach (DataGridViewCell c in dgv.Rows[rowIndex].Cells)
			{
				string? text = c.FormattedValue.ToString();
				if (text == null)
					continue;
				Size size = TextRenderer.MeasureText(text, dgv.DefaultCellStyle.Font);
				size.Height += padding.Top + padding.Bottom;
				if (size.Height > height)
					height = size.Height;
			}
			dgv.Rows[rowIndex].Height = height;
		}

		private static void UpdateSize(DataGridView dgv, Padding padding)
		{
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				UpdateColumnSize(dgv, padding, i);
			}

			for (int i = 0; i < dgv.Rows.Count; i++)
			{
				UpdateRowSize(dgv, padding, i);
			}
		}

		private void BtnInputBindsDefault_Click(object sender, EventArgs e)
		{
			DataGridView dgv;
			Collection<InputBind> defaultBinds;
			if (sender == BtnFlyInputDefault)
			{
				dgv = DgvFlyInputBinds;
				defaultBinds = DefaultLocalSettings.FlyBinds;
			}
			else
			{
				dgv = DgvFpsInputBinds;
				defaultBinds = DefaultLocalSettings.FpsBinds;
			}

			foreach (DataGridViewRow row in dgv.Rows)
			{
				var bind = (InputBind)row.DataBoundItem;

				// Using the InputBind instance directly in the lambda below
				// would create an anonymous method in the assembly that had a
				// field of the InputBind type. Since InputBind is defined in an
				// external assembly, it would be an obstacle to loading the
				// plugin, just like the JsonSettings and ShmeCommand types.
				object o = bind;
				InputBind defaultBind = defaultBinds
					.Where((b) => b.Command == ((InputBind)o).Command)
					.FirstOrDefault();

				row.Cells[1].Value = defaultBind.KeyBind;
				row.Cells[2].Value = defaultBind.MouseBind;
			}

			UpdateSize(dgv, _cellPadding);

			Settings.Local.Save();
		}

		private void DgvInputBinds_KeyDown(object sender, KeyEventArgs e)
		{
			if (!Editing || e.KeyCode == Keys.Escape)
			{
				FinishEditing(true);
				return;
			}

			DataGridViewCell cell;
			Collection<InputBind> inputBinds;
			if (DgvFlyInputBinds.SelectedCells.Count > 0)
			{
				cell = DgvFlyInputBinds.SelectedCells[0];
				inputBinds = Settings.Local.FlyBinds;
			}
			else
			{
				cell = DgvFpsInputBinds.SelectedCells[0];
				inputBinds = Settings.Local.FpsBinds;
			}

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
						}
						else
						{
							bind.KeyBind = Keys.None;
						}
						break;
					}

					object o = bind;
					IEnumerable<InputBind> dupes = inputBinds
						.Where((b) => b.KeyBind == e.KeyCode && !ReferenceEquals(b, o));

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
			var dgv = sender as DataGridView;
			if (ReferenceEquals(sender, DgvFlyInputBinds))
			{
				DgvFpsInputBinds.ClearSelection();
			}
			else if (ReferenceEquals(sender, DgvFpsInputBinds))
			{
				DgvFlyInputBinds.ClearSelection();
			}
			else
			{
				return;
			}

			if (!Editing)
			{
				return;
			}

			Collection<InputBind> inputBinds;
			if (ReferenceEquals(dgv, DgvFlyInputBinds))
			{
				inputBinds = Settings.Local.FlyBinds;
			}
			else
			{
				inputBinds = Settings.Local.FpsBinds;
			}

			DataGridViewCell selected = dgv.SelectedCells[0];
			if (selected.ColumnIndex == 0
				|| e.ColumnIndex != selected.ColumnIndex
				|| e.RowIndex != selected.RowIndex
				|| selected.OwningRow.DataBoundItem is not InputBind bind)
			{
				return;
			}

			object o = bind;
			IEnumerable<InputBind> dupes = inputBinds
				.Where((b) => b.MouseBind == e.Button && !ReferenceEquals(b, o));

			bool suppress = e.Button == bind.MouseBind;
			foreach (InputBind dupe in dupes)
			{
				dupe.MouseBind = MouseButtons.None;
				suppress = false;
			}

			bind.MouseBind = e.Button;

			FinishEditing(suppress);
		}

		private void DgvInputBinds_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (sender == DgvFlyInputBinds)
				DgvFpsInputBinds.ClearSelection();
			else if (sender == DgvFpsInputBinds)
				DgvFlyInputBinds.ClearSelection();
		}
	}
}
