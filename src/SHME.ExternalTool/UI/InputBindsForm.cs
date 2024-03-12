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
		private Padding _cellPadding = new(10);

		private bool _suppressSave;
		private DataGridViewCell? _editingCell;
		private DataGridViewCell? EditingCell
		{
			get => _editingCell;
			set
			{
				if (value == _editingCell)
				{
					return;
				}

				DataGridView dgv;

				if (value != null)
				{
					value.Style.SelectionBackColor = Color.FromArgb(192, 255, 255);
					value.Style.SelectionForeColor = Color.Black;
					dgv = value.DataGridView;
					_editingCell = value;
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

					_editingCell.Style.SelectionBackColor = _editingCell.DataGridView.DefaultCellStyle.SelectionBackColor;
					_editingCell.Style.SelectionForeColor = _editingCell.DataGridView.DefaultCellStyle.SelectionForeColor;
					dgv = _editingCell.DataGridView;

					UpdateColumnSize(dgv, _cellPadding, _editingCell.ColumnIndex);
					UpdateRowSize(dgv, _cellPadding, _editingCell.RowIndex);

					_editingCell = value;
				}

				dgv.Refresh();
			}
		}

		public InputBindsForm(Settings settings)
		{
			InitializeComponent();

			int border = 12;
			AutoScrollMargin = new Size(border, border);
			ClientSize = new Size(
				border + 640 + border,
				border + 512 + border);
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

			dgv.DataBindingComplete += Dgv_DataBindingComplete;
		}

		private static void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			if (sender is DataGridView dgv)
			{
				dgv.ClearSelection();
			}
		}

		private void FinishEditing(bool suppressSave = false)
		{
			if (EditingCell == null)
			{
				return;
			}

			_suppressSave = suppressSave;
			EditingCell = null;
		}

		private void InputBindsForm_Shown(object sender, EventArgs e)
		{
			UpdateSize(DgvFlyInputBinds, _cellPadding);
			UpdateSize(DgvFpsInputBinds, _cellPadding);

			DgvFlyInputBinds.Refresh();
			DgvFpsInputBinds.Refresh();
		}

		private static void UpdateColumnSize(DataGridView dgv, Padding padding, int columnIndex)
		{
			DataGridViewColumn column = dgv.Columns[columnIndex];
			string? text = column.HeaderText;
			Size size = TextRenderer.MeasureText(text, dgv.ColumnHeadersDefaultCellStyle.Font);
			size.Width += padding.Left + padding.Right;

			int width = 0;
			if (size.Width > width)
			{
				width = size.Width;
			}

			foreach (DataGridViewRow row in dgv.Rows)
			{
				foreach (DataGridViewCell c in row.Cells)
				{
					if (c.ColumnIndex == columnIndex)
					{
						text = c.FormattedValue.ToString();
						if (text == null)
						{
							continue;
						}
						size = TextRenderer.MeasureText(text, dgv.DefaultCellStyle.Font);
						size.Width += padding.Left + padding.Right;
						if (size.Width > width)
						{
							width = size.Width;
						}
					}
				}
			}

			column.Width = width;
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
			int height = 0;
			for (int i = 0; i < dgv.Columns.Count; i++)
			{
				string? text = dgv.Columns[i].HeaderText;
				if (text == null)
				{
					continue;
				}

				Size size = TextRenderer.MeasureText(text, dgv.ColumnHeadersDefaultCellStyle.Font);
				size.Height += padding.Top + padding.Bottom;
				if (size.Height > height)
				{
					height = size.Height;
				}
			}
			dgv.ColumnHeadersHeight = height;

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
			if (ReferenceEquals(sender, BtnFlyInputDefault))
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
			if (EditingCell == null
				|| e.KeyCode == Keys.Escape
				|| EditingCell.OwningRow.DataBoundItem is not InputBind bind)
			{
				FinishEditing(true);
				return;
			}

			Collection<InputBind> inputBinds;
			if (ReferenceEquals(EditingCell.DataGridView, DgvFlyInputBinds))
			{
				inputBinds = Settings.Local.FlyBinds;
			}
			else
			{
				inputBinds = Settings.Local.FpsBinds;
			}

			bool suppress = false;

			switch (EditingCell.ColumnIndex)
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

			EditingCell = ((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
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

			if (EditingCell == null)
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

			if (!ReferenceEquals(dgv, EditingCell.DataGridView)
				|| EditingCell.ColumnIndex != 2
				|| e.ColumnIndex != EditingCell.ColumnIndex
				|| e.RowIndex != EditingCell.RowIndex
				|| EditingCell.OwningRow.DataBoundItem is not InputBind bind)
			{
				FinishEditing(true);
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
			if (ReferenceEquals(sender, DgvFlyInputBinds))
			{
				DgvFpsInputBinds.ClearSelection();
			}
			else if (ReferenceEquals(sender, DgvFpsInputBinds))
			{
				DgvFlyInputBinds.ClearSelection();
			}
		}
	}
}
