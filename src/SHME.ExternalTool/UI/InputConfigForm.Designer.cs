using System.Windows.Forms;

namespace SHME.ExternalTool.UI
{
	public partial class InputConfigForm
	{
		private GroupBox GbxFirstPersonInputBinds;

		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxFirstPersonInputBinds = new System.Windows.Forms.GroupBox();
            this.DgvInputBinds = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GbxFlyInputBinds = new System.Windows.Forms.GroupBox();
            this.GbxFirstPersonInputBinds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvInputBinds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxFirstPersonInputBinds
            // 
            this.GbxFirstPersonInputBinds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GbxFirstPersonInputBinds.Controls.Add(this.DgvInputBinds);
            this.GbxFirstPersonInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxFirstPersonInputBinds.Location = new System.Drawing.Point(507, 3);
            this.GbxFirstPersonInputBinds.Name = "GbxFirstPersonInputBinds";
            this.GbxFirstPersonInputBinds.Size = new System.Drawing.Size(498, 979);
            this.GbxFirstPersonInputBinds.TabIndex = 0;
            this.GbxFirstPersonInputBinds.TabStop = false;
            this.GbxFirstPersonInputBinds.Text = "First person";
            // 
            // DgvInputBinds
            // 
            this.DgvInputBinds.AllowUserToAddRows = false;
            this.DgvInputBinds.AllowUserToDeleteRows = false;
            this.DgvInputBinds.AllowUserToResizeColumns = false;
            this.DgvInputBinds.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DgvInputBinds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvInputBinds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvInputBinds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvInputBinds.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvInputBinds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvInputBinds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvInputBinds.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvInputBinds.Location = new System.Drawing.Point(3, 16);
            this.DgvInputBinds.MultiSelect = false;
            this.DgvInputBinds.Name = "DgvInputBinds";
            this.DgvInputBinds.ReadOnly = true;
            this.DgvInputBinds.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvInputBinds.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvInputBinds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvInputBinds.Size = new System.Drawing.Size(492, 960);
            this.DgvInputBinds.StandardTab = true;
            this.DgvInputBinds.TabIndex = 1;
            this.DgvInputBinds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellDoubleClick);
            this.DgvInputBinds.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellLeave);
            this.DgvInputBinds.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInputBinds_CellMouseDown);
            this.DgvInputBinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvInputBinds_KeyDown);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.GbxFirstPersonInputBinds, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.GbxFlyInputBinds, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 985);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GbxFlyInputBinds
            // 
            this.GbxFlyInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxFlyInputBinds.Location = new System.Drawing.Point(3, 3);
            this.GbxFlyInputBinds.Name = "GbxFlyInputBinds";
            this.GbxFlyInputBinds.Size = new System.Drawing.Size(498, 979);
            this.GbxFlyInputBinds.TabIndex = 1;
            this.GbxFlyInputBinds.TabStop = false;
            this.GbxFlyInputBinds.Text = "Fly";
            // 
            // InputConfigForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 985);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InputConfigForm";
            this.Shown += new System.EventHandler(this.InputConfigForm_Shown);
            this.GbxFirstPersonInputBinds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvInputBinds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private DataGridView DgvInputBinds;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox GbxFlyInputBinds;
	}
}
