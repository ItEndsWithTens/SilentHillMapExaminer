﻿using System.Windows.Forms;

namespace SHME.ExternalTool.UI
{
	public partial class InputBindsForm
	{
		private GroupBox GbxFirstPersonInputBinds;

		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxFirstPersonInputBinds = new System.Windows.Forms.GroupBox();
            this.TlpConfigFpsInput = new System.Windows.Forms.TableLayoutPanel();
            this.BtnFpsInputDefault = new System.Windows.Forms.Button();
            this.DgvFpsInputBinds = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GbxFlyInputBinds = new System.Windows.Forms.GroupBox();
            this.TlpConfigFlyInput = new System.Windows.Forms.TableLayoutPanel();
            this.DgvFlyInputBinds = new System.Windows.Forms.DataGridView();
            this.BtnFlyInputDefault = new System.Windows.Forms.Button();
            this.GbxFirstPersonInputBinds.SuspendLayout();
            this.TlpConfigFpsInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFpsInputBinds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.GbxFlyInputBinds.SuspendLayout();
            this.TlpConfigFlyInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFlyInputBinds)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxFirstPersonInputBinds
            // 
            this.GbxFirstPersonInputBinds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GbxFirstPersonInputBinds.Controls.Add(this.TlpConfigFpsInput);
            this.GbxFirstPersonInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxFirstPersonInputBinds.Location = new System.Drawing.Point(507, 3);
            this.GbxFirstPersonInputBinds.Name = "GbxFirstPersonInputBinds";
            this.GbxFirstPersonInputBinds.Size = new System.Drawing.Size(498, 979);
            this.GbxFirstPersonInputBinds.TabIndex = 5;
            this.GbxFirstPersonInputBinds.TabStop = false;
            this.GbxFirstPersonInputBinds.Text = "First person";
            // 
            // TlpConfigFpsInput
            // 
            this.TlpConfigFpsInput.ColumnCount = 1;
            this.TlpConfigFpsInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpConfigFpsInput.Controls.Add(this.BtnFpsInputDefault, 0, 1);
            this.TlpConfigFpsInput.Controls.Add(this.DgvFpsInputBinds, 0, 0);
            this.TlpConfigFpsInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpConfigFpsInput.Location = new System.Drawing.Point(3, 16);
            this.TlpConfigFpsInput.Name = "TlpConfigFpsInput";
            this.TlpConfigFpsInput.RowCount = 2;
            this.TlpConfigFpsInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpConfigFpsInput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpConfigFpsInput.Size = new System.Drawing.Size(492, 960);
            this.TlpConfigFpsInput.TabIndex = 2;
            // 
            // BtnFpsInputDefault
            // 
            this.BtnFpsInputDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFpsInputDefault.Location = new System.Drawing.Point(3, 932);
            this.BtnFpsInputDefault.Name = "BtnFpsInputDefault";
            this.BtnFpsInputDefault.Size = new System.Drawing.Size(486, 25);
            this.BtnFpsInputDefault.TabIndex = 5;
            this.BtnFpsInputDefault.Text = "Default";
            this.BtnFpsInputDefault.UseVisualStyleBackColor = true;
            this.BtnFpsInputDefault.Click += new System.EventHandler(this.BtnInputBindsDefault_Click);
            // 
            // DgvFpsInputBinds
            // 
            this.DgvFpsInputBinds.AllowUserToAddRows = false;
            this.DgvFpsInputBinds.AllowUserToDeleteRows = false;
            this.DgvFpsInputBinds.AllowUserToResizeColumns = false;
            this.DgvFpsInputBinds.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DgvFpsInputBinds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvFpsInputBinds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvFpsInputBinds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvFpsInputBinds.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFpsInputBinds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvFpsInputBinds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFpsInputBinds.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvFpsInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFpsInputBinds.Location = new System.Drawing.Point(3, 3);
            this.DgvFpsInputBinds.MultiSelect = false;
            this.DgvFpsInputBinds.Name = "DgvFpsInputBinds";
            this.DgvFpsInputBinds.ReadOnly = true;
            this.DgvFpsInputBinds.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFpsInputBinds.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvFpsInputBinds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvFpsInputBinds.Size = new System.Drawing.Size(486, 923);
            this.DgvFpsInputBinds.StandardTab = true;
            this.DgvFpsInputBinds.TabIndex = 0;
            this.DgvFpsInputBinds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellDoubleClick);
            this.DgvFpsInputBinds.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellEnter);
            this.DgvFpsInputBinds.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellLeave);
            this.DgvFpsInputBinds.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInputBinds_CellMouseDown);
            this.DgvFpsInputBinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvInputBinds_KeyDown);
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
            this.GbxFlyInputBinds.Controls.Add(this.TlpConfigFlyInput);
            this.GbxFlyInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxFlyInputBinds.Location = new System.Drawing.Point(3, 3);
            this.GbxFlyInputBinds.Name = "GbxFlyInputBinds";
            this.GbxFlyInputBinds.Size = new System.Drawing.Size(498, 979);
            this.GbxFlyInputBinds.TabIndex = 0;
            this.GbxFlyInputBinds.TabStop = false;
            this.GbxFlyInputBinds.Text = "Fly";
            // 
            // TlpConfigFlyInput
            // 
            this.TlpConfigFlyInput.ColumnCount = 1;
            this.TlpConfigFlyInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpConfigFlyInput.Controls.Add(this.DgvFlyInputBinds, 0, 0);
            this.TlpConfigFlyInput.Controls.Add(this.BtnFlyInputDefault, 0, 1);
            this.TlpConfigFlyInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpConfigFlyInput.Location = new System.Drawing.Point(3, 16);
            this.TlpConfigFlyInput.Name = "TlpConfigFlyInput";
            this.TlpConfigFlyInput.RowCount = 2;
            this.TlpConfigFlyInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpConfigFlyInput.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpConfigFlyInput.Size = new System.Drawing.Size(492, 960);
            this.TlpConfigFlyInput.TabIndex = 0;
            // 
            // DgvFlyInputBinds
            // 
            this.DgvFlyInputBinds.AllowUserToAddRows = false;
            this.DgvFlyInputBinds.AllowUserToDeleteRows = false;
            this.DgvFlyInputBinds.AllowUserToResizeColumns = false;
            this.DgvFlyInputBinds.AllowUserToResizeRows = false;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.ControlLight;
            this.DgvFlyInputBinds.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
            this.DgvFlyInputBinds.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvFlyInputBinds.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvFlyInputBinds.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvFlyInputBinds.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            this.DgvFlyInputBinds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.Padding = new System.Windows.Forms.Padding(10);
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvFlyInputBinds.DefaultCellStyle = dataGridViewCellStyle15;
            this.DgvFlyInputBinds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvFlyInputBinds.Location = new System.Drawing.Point(3, 3);
            this.DgvFlyInputBinds.MultiSelect = false;
            this.DgvFlyInputBinds.Name = "DgvFlyInputBinds";
            this.DgvFlyInputBinds.ReadOnly = true;
            this.DgvFlyInputBinds.RowHeadersVisible = false;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DgvFlyInputBinds.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.DgvFlyInputBinds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DgvFlyInputBinds.Size = new System.Drawing.Size(486, 923);
            this.DgvFlyInputBinds.StandardTab = true;
            this.DgvFlyInputBinds.TabIndex = 0;
            this.DgvFlyInputBinds.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellDoubleClick);
            this.DgvFlyInputBinds.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellEnter);
            this.DgvFlyInputBinds.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvInputBinds_CellLeave);
            this.DgvFlyInputBinds.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvInputBinds_CellMouseDown);
            this.DgvFlyInputBinds.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvInputBinds_KeyDown);
            // 
            // BtnFlyInputDefault
            // 
            this.BtnFlyInputDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFlyInputDefault.Location = new System.Drawing.Point(3, 932);
            this.BtnFlyInputDefault.Name = "BtnFlyInputDefault";
            this.BtnFlyInputDefault.Size = new System.Drawing.Size(486, 25);
            this.BtnFlyInputDefault.TabIndex = 5;
            this.BtnFlyInputDefault.Text = "Default";
            this.BtnFlyInputDefault.UseVisualStyleBackColor = true;
            this.BtnFlyInputDefault.Click += new System.EventHandler(this.BtnInputBindsDefault_Click);
            // 
            // InputConfigForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 985);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "InputConfigForm";
            this.Shown += new System.EventHandler(this.InputBindsForm_Shown);
            this.GbxFirstPersonInputBinds.ResumeLayout(false);
            this.TlpConfigFpsInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFpsInputBinds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.GbxFlyInputBinds.ResumeLayout(false);
            this.TlpConfigFlyInput.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvFlyInputBinds)).EndInit();
            this.ResumeLayout(false);

		}
		private DataGridView DgvFpsInputBinds;
		private TableLayoutPanel tableLayoutPanel1;
		private GroupBox GbxFlyInputBinds;
		private DataGridView DgvFlyInputBinds;
		private TableLayoutPanel TlpConfigFlyInput;
		private Button BtnFlyInputDefault;
		private TableLayoutPanel TlpConfigFpsInput;
		private Button BtnFpsInputDefault;
	}
}
