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
						_settings.Local.Save();
					}
					else
					{
						_suppressSave = false;
					}

					cell.Style.SelectionBackColor = DgvFpsInputBinds.DefaultCellStyle.SelectionBackColor;
					cell.Style.SelectionForeColor = DgvFpsInputBinds.DefaultCellStyle.SelectionForeColor;
				}

				// Toggling AutoSizeMode off and on again is an easy way to auto
				// size the column after a change.
				cell.OwningColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
				cell.OwningColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
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

			_settings = settings;

			BuildColumns(DgvFlyInputBinds, _settings.Local.FlyBinds);
			BuildColumns(DgvFpsInputBinds, _settings.Local.FpsBinds);
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

				InputBind defaultBind = defaultBinds
					.Where((b) => b.Command == bind.Command)
					.FirstOrDefault();

				row.Cells[1].Value = defaultBind.KeyBind;
				row.Cells[2].Value = defaultBind.MouseBind;
			}

			_settings.Local.Save();
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
				inputBinds = _settings.Local.FlyBinds;
			}
			else
			{
				cell = DgvFpsInputBinds.SelectedCells[0];
				inputBinds = _settings.Local.FpsBinds;
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

					IEnumerable<InputBind> dupes = inputBinds
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

			DataGridViewCell cell;
			Collection<InputBind> inputBinds;
			if (DgvFlyInputBinds.SelectedCells.Count > 0)
			{
				cell = DgvFlyInputBinds.SelectedCells[0];
				inputBinds = _settings.Local.FlyBinds;
			}
			else
			{
				cell = DgvFpsInputBinds.SelectedCells[0];
				inputBinds = _settings.Local.FpsBinds;
			}

			if (cell.ColumnIndex != 2)
			{
				return;
			}

			if (cell.OwningRow.DataBoundItem is not InputBind bind)
			{
				return;
			}

			IEnumerable<InputBind> dupes = inputBinds
				.Where((b) => b.MouseBind == e.Button && b != bind);

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
