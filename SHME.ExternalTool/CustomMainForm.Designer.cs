﻿using System.Windows.Forms;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private Button BtnGetPosition;
		private Button BtnSetPosition;
		private TextBox TbxPositionX;
		private TextBox TbxPositionY;

		private void InitializeComponent()
		{
            this.BtnGetPosition = new System.Windows.Forms.Button();
            this.BtnSetPosition = new System.Windows.Forms.Button();
            this.TbxPositionX = new System.Windows.Forms.TextBox();
            this.TbxPositionY = new System.Windows.Forms.TextBox();
            this.LblHarryPositionX = new System.Windows.Forms.Label();
            this.LblHarryPositionY = new System.Windows.Forms.Label();
            this.BtnSetHarryPitch = new System.Windows.Forms.Button();
            this.BtnSetHarryYaw = new System.Windows.Forms.Button();
            this.BtnSetHarryRoll = new System.Windows.Forms.Button();
            this.TbxHarryPitch = new System.Windows.Forms.TextBox();
            this.TbxHarryYaw = new System.Windows.Forms.TextBox();
            this.TbxHarryRoll = new System.Windows.Forms.TextBox();
            this.BtnGetAngles = new System.Windows.Forms.Button();
            this.GbxHarry = new System.Windows.Forms.GroupBox();
            this.LblHarryPositionZ = new System.Windows.Forms.Label();
            this.TbxPositionZ = new System.Windows.Forms.TextBox();
            this.BtnSetAngles = new System.Windows.Forms.Button();
            this.LblHarryRoll = new System.Windows.Forms.Label();
            this.LblHarryYaw = new System.Windows.Forms.Label();
            this.LblHarryPitch = new System.Windows.Forms.Label();
            this.GbxCamera = new System.Windows.Forms.GroupBox();
            this.LblFov = new System.Windows.Forms.Label();
            this.TrkFov = new System.Windows.Forms.TrackBar();
            this.LblCameraRoll = new System.Windows.Forms.Label();
            this.LblCameraYaw = new System.Windows.Forms.Label();
            this.LblCameraPitch = new System.Windows.Forms.Label();
            this.LblCameraPositionZ = new System.Windows.Forms.Label();
            this.LblCameraPositionY = new System.Windows.Forms.Label();
            this.LblCameraPositionX = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnGrabMapGraphic = new System.Windows.Forms.Button();
            this.PbxMapGraphic = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TbpBasics = new System.Windows.Forms.TabPage();
            this.GbxControls = new System.Windows.Forms.GroupBox();
            this.LblButtonR3 = new System.Windows.Forms.Label();
            this.LblButtonL3 = new System.Windows.Forms.Label();
            this.LblButtonR2 = new System.Windows.Forms.Label();
            this.LblButtonR1 = new System.Windows.Forms.Label();
            this.LblButtonL2 = new System.Windows.Forms.Label();
            this.LblButtonL1 = new System.Windows.Forms.Label();
            this.LblButtonX = new System.Windows.Forms.Label();
            this.LblButtonCircle = new System.Windows.Forms.Label();
            this.LblButtonSquare = new System.Windows.Forms.Label();
            this.LblButtonTriangle = new System.Windows.Forms.Label();
            this.LblButtonDown = new System.Windows.Forms.Label();
            this.LblButtonRight = new System.Windows.Forms.Label();
            this.LblButtonLeft = new System.Windows.Forms.Label();
            this.LblButtonUp = new System.Windows.Forms.Label();
            this.LblButtonStart = new System.Windows.Forms.Label();
            this.LblButtonSelect = new System.Windows.Forms.Label();
            this.GbxOverlay = new System.Windows.Forms.GroupBox();
            this.LblOverlayCamRoll = new System.Windows.Forms.Label();
            this.LblOverlayCamYaw = new System.Windows.Forms.Label();
            this.LblOverlayCamPitch = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionZ = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionY = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionX = new System.Windows.Forms.Label();
            this.TbpMap = new System.Windows.Forms.TabPage();
            this.TbpBox = new System.Windows.Forms.TabPage();
            this.NudBoxZ = new System.Windows.Forms.NumericUpDown();
            this.NudBoxY = new System.Windows.Forms.NumericUpDown();
            this.NudBoxX = new System.Windows.Forms.NumericUpDown();
            this.LblBoxZ = new System.Windows.Forms.Label();
            this.BtnBoxGetPosition = new System.Windows.Forms.Button();
            this.BtnBoxSetPosition = new System.Windows.Forms.Button();
            this.LblBoxX = new System.Windows.Forms.Label();
            this.LblBoxY = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.GbxHarry.SuspendLayout();
            this.GbxCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TbpBasics.SuspendLayout();
            this.GbxControls.SuspendLayout();
            this.GbxOverlay.SuspendLayout();
            this.TbpMap.SuspendLayout();
            this.TbpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxX)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGetPosition
            // 
            this.BtnGetPosition.Location = new System.Drawing.Point(6, 32);
            this.BtnGetPosition.Name = "BtnGetPosition";
            this.BtnGetPosition.Size = new System.Drawing.Size(75, 23);
            this.BtnGetPosition.TabIndex = 0;
            this.BtnGetPosition.Text = "Get position";
            this.BtnGetPosition.UseVisualStyleBackColor = true;
            this.BtnGetPosition.Click += new System.EventHandler(this.BtnGetPosition_Click);
            // 
            // BtnSetPosition
            // 
            this.BtnSetPosition.Location = new System.Drawing.Point(255, 32);
            this.BtnSetPosition.Name = "BtnSetPosition";
            this.BtnSetPosition.Size = new System.Drawing.Size(75, 23);
            this.BtnSetPosition.TabIndex = 1;
            this.BtnSetPosition.Text = "Set position";
            this.BtnSetPosition.UseVisualStyleBackColor = true;
            this.BtnSetPosition.Click += new System.EventHandler(this.BtnSetPosition_Click);
            // 
            // TbxPositionX
            // 
            this.TbxPositionX.Location = new System.Drawing.Point(87, 34);
            this.TbxPositionX.Name = "TbxPositionX";
            this.TbxPositionX.Size = new System.Drawing.Size(50, 20);
            this.TbxPositionX.TabIndex = 2;
            // 
            // TbxPositionY
            // 
            this.TbxPositionY.Location = new System.Drawing.Point(143, 34);
            this.TbxPositionY.Name = "TbxPositionY";
            this.TbxPositionY.Size = new System.Drawing.Size(50, 20);
            this.TbxPositionY.TabIndex = 3;
            // 
            // LblHarryPositionX
            // 
            this.LblHarryPositionX.AutoSize = true;
            this.LblHarryPositionX.Location = new System.Drawing.Point(84, 12);
            this.LblHarryPositionX.Name = "LblHarryPositionX";
            this.LblHarryPositionX.Size = new System.Drawing.Size(50, 13);
            this.LblHarryPositionX.TabIndex = 4;
            this.LblHarryPositionX.Text = "<harry x>";
            // 
            // LblHarryPositionY
            // 
            this.LblHarryPositionY.AutoSize = true;
            this.LblHarryPositionY.Location = new System.Drawing.Point(143, 12);
            this.LblHarryPositionY.Name = "LblHarryPositionY";
            this.LblHarryPositionY.Size = new System.Drawing.Size(50, 13);
            this.LblHarryPositionY.TabIndex = 5;
            this.LblHarryPositionY.Text = "<harry y>";
            // 
            // BtnSetHarryPitch
            // 
            this.BtnSetHarryPitch.Location = new System.Drawing.Point(6, 110);
            this.BtnSetHarryPitch.Name = "BtnSetHarryPitch";
            this.BtnSetHarryPitch.Size = new System.Drawing.Size(75, 23);
            this.BtnSetHarryPitch.TabIndex = 6;
            this.BtnSetHarryPitch.Text = "Set pitch";
            this.BtnSetHarryPitch.UseVisualStyleBackColor = true;
            this.BtnSetHarryPitch.Click += new System.EventHandler(this.BtnSetHarryPitch_Click);
            // 
            // BtnSetHarryYaw
            // 
            this.BtnSetHarryYaw.Location = new System.Drawing.Point(6, 139);
            this.BtnSetHarryYaw.Name = "BtnSetHarryYaw";
            this.BtnSetHarryYaw.Size = new System.Drawing.Size(75, 23);
            this.BtnSetHarryYaw.TabIndex = 7;
            this.BtnSetHarryYaw.Text = "Set yaw";
            this.BtnSetHarryYaw.UseVisualStyleBackColor = true;
            this.BtnSetHarryYaw.Click += new System.EventHandler(this.BtnSetHarryYaw_Click);
            // 
            // BtnSetHarryRoll
            // 
            this.BtnSetHarryRoll.Location = new System.Drawing.Point(6, 168);
            this.BtnSetHarryRoll.Name = "BtnSetHarryRoll";
            this.BtnSetHarryRoll.Size = new System.Drawing.Size(75, 23);
            this.BtnSetHarryRoll.TabIndex = 8;
            this.BtnSetHarryRoll.Text = "Set roll";
            this.BtnSetHarryRoll.UseVisualStyleBackColor = true;
            this.BtnSetHarryRoll.Click += new System.EventHandler(this.BtnSetHarryRoll_Click);
            // 
            // TbxHarryPitch
            // 
            this.TbxHarryPitch.Location = new System.Drawing.Point(87, 110);
            this.TbxHarryPitch.Name = "TbxHarryPitch";
            this.TbxHarryPitch.Size = new System.Drawing.Size(75, 20);
            this.TbxHarryPitch.TabIndex = 9;
            // 
            // TbxHarryYaw
            // 
            this.TbxHarryYaw.Location = new System.Drawing.Point(87, 141);
            this.TbxHarryYaw.Name = "TbxHarryYaw";
            this.TbxHarryYaw.Size = new System.Drawing.Size(75, 20);
            this.TbxHarryYaw.TabIndex = 10;
            // 
            // TbxHarryRoll
            // 
            this.TbxHarryRoll.Location = new System.Drawing.Point(87, 170);
            this.TbxHarryRoll.Name = "TbxHarryRoll";
            this.TbxHarryRoll.Size = new System.Drawing.Size(75, 20);
            this.TbxHarryRoll.TabIndex = 11;
            // 
            // BtnGetAngles
            // 
            this.BtnGetAngles.Location = new System.Drawing.Point(87, 81);
            this.BtnGetAngles.Name = "BtnGetAngles";
            this.BtnGetAngles.Size = new System.Drawing.Size(75, 23);
            this.BtnGetAngles.TabIndex = 12;
            this.BtnGetAngles.Text = "Get angles";
            this.BtnGetAngles.UseVisualStyleBackColor = true;
            this.BtnGetAngles.Click += new System.EventHandler(this.BtnGetAngles_Click);
            // 
            // GbxHarry
            // 
            this.GbxHarry.Controls.Add(this.LblHarryPositionZ);
            this.GbxHarry.Controls.Add(this.TbxPositionZ);
            this.GbxHarry.Controls.Add(this.BtnSetAngles);
            this.GbxHarry.Controls.Add(this.LblHarryRoll);
            this.GbxHarry.Controls.Add(this.LblHarryYaw);
            this.GbxHarry.Controls.Add(this.LblHarryPitch);
            this.GbxHarry.Controls.Add(this.BtnGetAngles);
            this.GbxHarry.Controls.Add(this.BtnGetPosition);
            this.GbxHarry.Controls.Add(this.TbxHarryRoll);
            this.GbxHarry.Controls.Add(this.BtnSetPosition);
            this.GbxHarry.Controls.Add(this.TbxHarryYaw);
            this.GbxHarry.Controls.Add(this.TbxPositionX);
            this.GbxHarry.Controls.Add(this.TbxHarryPitch);
            this.GbxHarry.Controls.Add(this.TbxPositionY);
            this.GbxHarry.Controls.Add(this.BtnSetHarryRoll);
            this.GbxHarry.Controls.Add(this.LblHarryPositionX);
            this.GbxHarry.Controls.Add(this.BtnSetHarryYaw);
            this.GbxHarry.Controls.Add(this.LblHarryPositionY);
            this.GbxHarry.Controls.Add(this.BtnSetHarryPitch);
            this.GbxHarry.Location = new System.Drawing.Point(6, 6);
            this.GbxHarry.Name = "GbxHarry";
            this.GbxHarry.Size = new System.Drawing.Size(338, 266);
            this.GbxHarry.TabIndex = 13;
            this.GbxHarry.TabStop = false;
            this.GbxHarry.Text = "Harry";
            // 
            // LblHarryPositionZ
            // 
            this.LblHarryPositionZ.AutoSize = true;
            this.LblHarryPositionZ.Location = new System.Drawing.Point(199, 12);
            this.LblHarryPositionZ.Name = "LblHarryPositionZ";
            this.LblHarryPositionZ.Size = new System.Drawing.Size(50, 13);
            this.LblHarryPositionZ.TabIndex = 18;
            this.LblHarryPositionZ.Text = "<harry z>";
            // 
            // TbxPositionZ
            // 
            this.TbxPositionZ.Location = new System.Drawing.Point(199, 34);
            this.TbxPositionZ.Name = "TbxPositionZ";
            this.TbxPositionZ.Size = new System.Drawing.Size(50, 20);
            this.TbxPositionZ.TabIndex = 3;
            // 
            // BtnSetAngles
            // 
            this.BtnSetAngles.Location = new System.Drawing.Point(87, 196);
            this.BtnSetAngles.Name = "BtnSetAngles";
            this.BtnSetAngles.Size = new System.Drawing.Size(75, 23);
            this.BtnSetAngles.TabIndex = 16;
            this.BtnSetAngles.Text = "Set angles";
            this.BtnSetAngles.UseVisualStyleBackColor = true;
            this.BtnSetAngles.Click += new System.EventHandler(this.BtnSetAngles_Click);
            // 
            // LblHarryRoll
            // 
            this.LblHarryRoll.AutoSize = true;
            this.LblHarryRoll.Location = new System.Drawing.Point(168, 173);
            this.LblHarryRoll.Name = "LblHarryRoll";
            this.LblHarryRoll.Size = new System.Drawing.Size(58, 13);
            this.LblHarryRoll.TabIndex = 15;
            this.LblHarryRoll.Text = "<harry roll>";
            // 
            // LblHarryYaw
            // 
            this.LblHarryYaw.AutoSize = true;
            this.LblHarryYaw.Location = new System.Drawing.Point(168, 144);
            this.LblHarryYaw.Name = "LblHarryYaw";
            this.LblHarryYaw.Size = new System.Drawing.Size(64, 13);
            this.LblHarryYaw.TabIndex = 14;
            this.LblHarryYaw.Text = "<harry yaw>";
            // 
            // LblHarryPitch
            // 
            this.LblHarryPitch.AutoSize = true;
            this.LblHarryPitch.Location = new System.Drawing.Point(168, 113);
            this.LblHarryPitch.Name = "LblHarryPitch";
            this.LblHarryPitch.Size = new System.Drawing.Size(68, 13);
            this.LblHarryPitch.TabIndex = 13;
            this.LblHarryPitch.Text = "<harry pitch>";
            // 
            // GbxCamera
            // 
            this.GbxCamera.Controls.Add(this.label1);
            this.GbxCamera.Controls.Add(this.LblFov);
            this.GbxCamera.Controls.Add(this.TrkFov);
            this.GbxCamera.Controls.Add(this.LblCameraRoll);
            this.GbxCamera.Controls.Add(this.LblCameraYaw);
            this.GbxCamera.Controls.Add(this.LblCameraPitch);
            this.GbxCamera.Controls.Add(this.LblCameraPositionZ);
            this.GbxCamera.Controls.Add(this.LblCameraPositionY);
            this.GbxCamera.Controls.Add(this.LblCameraPositionX);
            this.GbxCamera.Location = new System.Drawing.Point(350, 6);
            this.GbxCamera.Name = "GbxCamera";
            this.GbxCamera.Size = new System.Drawing.Size(396, 266);
            this.GbxCamera.TabIndex = 14;
            this.GbxCamera.TabStop = false;
            this.GbxCamera.Text = "Camera";
            // 
            // LblFov
            // 
            this.LblFov.AutoSize = true;
            this.LblFov.Location = new System.Drawing.Point(182, 194);
            this.LblFov.Name = "LblFov";
            this.LblFov.Size = new System.Drawing.Size(34, 13);
            this.LblFov.TabIndex = 8;
            this.LblFov.Text = "<fov>";
            // 
            // TrkFov
            // 
            this.TrkFov.Location = new System.Drawing.Point(9, 210);
            this.TrkFov.Maximum = 120;
            this.TrkFov.Minimum = 1;
            this.TrkFov.Name = "TrkFov";
            this.TrkFov.Size = new System.Drawing.Size(381, 45);
            this.TrkFov.TabIndex = 6;
            this.TrkFov.Value = 1;
            this.TrkFov.Scroll += new System.EventHandler(this.TrkFov_Scroll);
            // 
            // LblCameraRoll
            // 
            this.LblCameraRoll.AutoSize = true;
            this.LblCameraRoll.Location = new System.Drawing.Point(6, 141);
            this.LblCameraRoll.Name = "LblCameraRoll";
            this.LblCameraRoll.Size = new System.Drawing.Size(28, 13);
            this.LblCameraRoll.TabIndex = 5;
            this.LblCameraRoll.Text = "Roll:";
            // 
            // LblCameraYaw
            // 
            this.LblCameraYaw.AutoSize = true;
            this.LblCameraYaw.Location = new System.Drawing.Point(6, 124);
            this.LblCameraYaw.Name = "LblCameraYaw";
            this.LblCameraYaw.Size = new System.Drawing.Size(31, 13);
            this.LblCameraYaw.TabIndex = 4;
            this.LblCameraYaw.Text = "Yaw:";
            // 
            // LblCameraPitch
            // 
            this.LblCameraPitch.AutoSize = true;
            this.LblCameraPitch.Location = new System.Drawing.Point(6, 107);
            this.LblCameraPitch.Name = "LblCameraPitch";
            this.LblCameraPitch.Size = new System.Drawing.Size(34, 13);
            this.LblCameraPitch.TabIndex = 3;
            this.LblCameraPitch.Text = "Pitch:";
            // 
            // LblCameraPositionZ
            // 
            this.LblCameraPositionZ.AutoSize = true;
            this.LblCameraPositionZ.Location = new System.Drawing.Point(6, 76);
            this.LblCameraPositionZ.Name = "LblCameraPositionZ";
            this.LblCameraPositionZ.Size = new System.Drawing.Size(57, 13);
            this.LblCameraPositionZ.TabIndex = 2;
            this.LblCameraPositionZ.Text = "Position Z:";
            // 
            // LblCameraPositionY
            // 
            this.LblCameraPositionY.AutoSize = true;
            this.LblCameraPositionY.Location = new System.Drawing.Point(6, 59);
            this.LblCameraPositionY.Name = "LblCameraPositionY";
            this.LblCameraPositionY.Size = new System.Drawing.Size(57, 13);
            this.LblCameraPositionY.TabIndex = 1;
            this.LblCameraPositionY.Text = "Position Y:";
            // 
            // LblCameraPositionX
            // 
            this.LblCameraPositionX.AutoSize = true;
            this.LblCameraPositionX.Location = new System.Drawing.Point(6, 42);
            this.LblCameraPositionX.Name = "LblCameraPositionX";
            this.LblCameraPositionX.Size = new System.Drawing.Size(57, 13);
            this.LblCameraPositionX.TabIndex = 0;
            this.LblCameraPositionX.Text = "Position X:";
            // 
            // BtnGrabMapGraphic
            // 
            this.BtnGrabMapGraphic.Location = new System.Drawing.Point(6, 492);
            this.BtnGrabMapGraphic.Name = "BtnGrabMapGraphic";
            this.BtnGrabMapGraphic.Size = new System.Drawing.Size(114, 23);
            this.BtnGrabMapGraphic.TabIndex = 15;
            this.BtnGrabMapGraphic.Text = "Grab map graphic";
            this.BtnGrabMapGraphic.UseVisualStyleBackColor = true;
            this.BtnGrabMapGraphic.Click += new System.EventHandler(this.BtnGrabMapGraphic_Click);
            // 
            // PbxMapGraphic
            // 
            this.PbxMapGraphic.BackColor = System.Drawing.Color.Black;
            this.PbxMapGraphic.Location = new System.Drawing.Point(6, 6);
            this.PbxMapGraphic.Name = "PbxMapGraphic";
            this.PbxMapGraphic.Size = new System.Drawing.Size(640, 480);
            this.PbxMapGraphic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PbxMapGraphic.TabIndex = 16;
            this.PbxMapGraphic.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TbpBasics);
            this.tabControl1.Controls.Add(this.TbpMap);
            this.tabControl1.Controls.Add(this.TbpBox);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(760, 752);
            this.tabControl1.TabIndex = 17;
            // 
            // TbpBasics
            // 
            this.TbpBasics.Controls.Add(this.GbxControls);
            this.TbpBasics.Controls.Add(this.GbxOverlay);
            this.TbpBasics.Controls.Add(this.GbxHarry);
            this.TbpBasics.Controls.Add(this.GbxCamera);
            this.TbpBasics.Location = new System.Drawing.Point(4, 22);
            this.TbpBasics.Name = "TbpBasics";
            this.TbpBasics.Padding = new System.Windows.Forms.Padding(3);
            this.TbpBasics.Size = new System.Drawing.Size(752, 726);
            this.TbpBasics.TabIndex = 0;
            this.TbpBasics.Text = "Basics";
            this.TbpBasics.UseVisualStyleBackColor = true;
            // 
            // GbxControls
            // 
            this.GbxControls.Controls.Add(this.LblButtonR3);
            this.GbxControls.Controls.Add(this.LblButtonL3);
            this.GbxControls.Controls.Add(this.LblButtonR2);
            this.GbxControls.Controls.Add(this.LblButtonR1);
            this.GbxControls.Controls.Add(this.LblButtonL2);
            this.GbxControls.Controls.Add(this.LblButtonL1);
            this.GbxControls.Controls.Add(this.LblButtonX);
            this.GbxControls.Controls.Add(this.LblButtonCircle);
            this.GbxControls.Controls.Add(this.LblButtonSquare);
            this.GbxControls.Controls.Add(this.LblButtonTriangle);
            this.GbxControls.Controls.Add(this.LblButtonDown);
            this.GbxControls.Controls.Add(this.LblButtonRight);
            this.GbxControls.Controls.Add(this.LblButtonLeft);
            this.GbxControls.Controls.Add(this.LblButtonUp);
            this.GbxControls.Controls.Add(this.LblButtonStart);
            this.GbxControls.Controls.Add(this.LblButtonSelect);
            this.GbxControls.Location = new System.Drawing.Point(6, 278);
            this.GbxControls.Name = "GbxControls";
            this.GbxControls.Size = new System.Drawing.Size(338, 442);
            this.GbxControls.TabIndex = 16;
            this.GbxControls.TabStop = false;
            this.GbxControls.Text = "Controls";
            // 
            // LblButtonR3
            // 
            this.LblButtonR3.AutoSize = true;
            this.LblButtonR3.Location = new System.Drawing.Point(213, 230);
            this.LblButtonR3.Name = "LblButtonR3";
            this.LblButtonR3.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR3.TabIndex = 15;
            this.LblButtonR3.Text = "R3";
            // 
            // LblButtonL3
            // 
            this.LblButtonL3.AutoSize = true;
            this.LblButtonL3.Location = new System.Drawing.Point(83, 230);
            this.LblButtonL3.Name = "LblButtonL3";
            this.LblButtonL3.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL3.TabIndex = 14;
            this.LblButtonL3.Text = "L3";
            // 
            // LblButtonR2
            // 
            this.LblButtonR2.AutoSize = true;
            this.LblButtonR2.Location = new System.Drawing.Point(279, 33);
            this.LblButtonR2.Name = "LblButtonR2";
            this.LblButtonR2.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR2.TabIndex = 13;
            this.LblButtonR2.Text = "R2";
            // 
            // LblButtonR1
            // 
            this.LblButtonR1.AutoSize = true;
            this.LblButtonR1.Location = new System.Drawing.Point(279, 67);
            this.LblButtonR1.Name = "LblButtonR1";
            this.LblButtonR1.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR1.TabIndex = 12;
            this.LblButtonR1.Text = "R1";
            // 
            // LblButtonL2
            // 
            this.LblButtonL2.AutoSize = true;
            this.LblButtonL2.Location = new System.Drawing.Point(22, 33);
            this.LblButtonL2.Name = "LblButtonL2";
            this.LblButtonL2.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL2.TabIndex = 11;
            this.LblButtonL2.Text = "L2";
            // 
            // LblButtonL1
            // 
            this.LblButtonL1.AutoSize = true;
            this.LblButtonL1.Location = new System.Drawing.Point(22, 67);
            this.LblButtonL1.Name = "LblButtonL1";
            this.LblButtonL1.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL1.TabIndex = 10;
            this.LblButtonL1.Text = "L1";
            // 
            // LblButtonX
            // 
            this.LblButtonX.AutoSize = true;
            this.LblButtonX.Location = new System.Drawing.Point(250, 170);
            this.LblButtonX.Name = "LblButtonX";
            this.LblButtonX.Size = new System.Drawing.Size(14, 13);
            this.LblButtonX.TabIndex = 9;
            this.LblButtonX.Text = "X";
            // 
            // LblButtonCircle
            // 
            this.LblButtonCircle.AutoSize = true;
            this.LblButtonCircle.Location = new System.Drawing.Point(279, 138);
            this.LblButtonCircle.Name = "LblButtonCircle";
            this.LblButtonCircle.Size = new System.Drawing.Size(33, 13);
            this.LblButtonCircle.TabIndex = 8;
            this.LblButtonCircle.Text = "Circle";
            // 
            // LblButtonSquare
            // 
            this.LblButtonSquare.AutoSize = true;
            this.LblButtonSquare.Location = new System.Drawing.Point(199, 138);
            this.LblButtonSquare.Name = "LblButtonSquare";
            this.LblButtonSquare.Size = new System.Drawing.Size(41, 13);
            this.LblButtonSquare.TabIndex = 7;
            this.LblButtonSquare.Text = "Square";
            // 
            // LblButtonTriangle
            // 
            this.LblButtonTriangle.AutoSize = true;
            this.LblButtonTriangle.Location = new System.Drawing.Point(235, 106);
            this.LblButtonTriangle.Name = "LblButtonTriangle";
            this.LblButtonTriangle.Size = new System.Drawing.Size(45, 13);
            this.LblButtonTriangle.TabIndex = 6;
            this.LblButtonTriangle.Text = "Triangle";
            // 
            // LblButtonDown
            // 
            this.LblButtonDown.AutoSize = true;
            this.LblButtonDown.Location = new System.Drawing.Point(41, 170);
            this.LblButtonDown.Name = "LblButtonDown";
            this.LblButtonDown.Size = new System.Drawing.Size(35, 13);
            this.LblButtonDown.TabIndex = 5;
            this.LblButtonDown.Text = "Down";
            // 
            // LblButtonRight
            // 
            this.LblButtonRight.AutoSize = true;
            this.LblButtonRight.Location = new System.Drawing.Point(70, 138);
            this.LblButtonRight.Name = "LblButtonRight";
            this.LblButtonRight.Size = new System.Drawing.Size(32, 13);
            this.LblButtonRight.TabIndex = 4;
            this.LblButtonRight.Text = "Right";
            // 
            // LblButtonLeft
            // 
            this.LblButtonLeft.AutoSize = true;
            this.LblButtonLeft.Location = new System.Drawing.Point(18, 138);
            this.LblButtonLeft.Name = "LblButtonLeft";
            this.LblButtonLeft.Size = new System.Drawing.Size(25, 13);
            this.LblButtonLeft.TabIndex = 3;
            this.LblButtonLeft.Text = "Left";
            // 
            // LblButtonUp
            // 
            this.LblButtonUp.AutoSize = true;
            this.LblButtonUp.Location = new System.Drawing.Point(48, 106);
            this.LblButtonUp.Name = "LblButtonUp";
            this.LblButtonUp.Size = new System.Drawing.Size(21, 13);
            this.LblButtonUp.TabIndex = 2;
            this.LblButtonUp.Text = "Up";
            // 
            // LblButtonStart
            // 
            this.LblButtonStart.AutoSize = true;
            this.LblButtonStart.Location = new System.Drawing.Point(168, 201);
            this.LblButtonStart.Name = "LblButtonStart";
            this.LblButtonStart.Size = new System.Drawing.Size(29, 13);
            this.LblButtonStart.TabIndex = 1;
            this.LblButtonStart.Text = "Start";
            // 
            // LblButtonSelect
            // 
            this.LblButtonSelect.AutoSize = true;
            this.LblButtonSelect.Location = new System.Drawing.Point(120, 201);
            this.LblButtonSelect.Name = "LblButtonSelect";
            this.LblButtonSelect.Size = new System.Drawing.Size(37, 13);
            this.LblButtonSelect.TabIndex = 0;
            this.LblButtonSelect.Text = "Select";
            // 
            // GbxOverlay
            // 
            this.GbxOverlay.Controls.Add(this.label2);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamRoll);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamYaw);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPitch);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionZ);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionY);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionX);
            this.GbxOverlay.Location = new System.Drawing.Point(350, 278);
            this.GbxOverlay.Name = "GbxOverlay";
            this.GbxOverlay.Size = new System.Drawing.Size(396, 442);
            this.GbxOverlay.TabIndex = 15;
            this.GbxOverlay.TabStop = false;
            this.GbxOverlay.Text = "Overlay";
            // 
            // LblOverlayCamRoll
            // 
            this.LblOverlayCamRoll.AutoSize = true;
            this.LblOverlayCamRoll.Location = new System.Drawing.Point(6, 142);
            this.LblOverlayCamRoll.Name = "LblOverlayCamRoll";
            this.LblOverlayCamRoll.Size = new System.Drawing.Size(28, 13);
            this.LblOverlayCamRoll.TabIndex = 11;
            this.LblOverlayCamRoll.Text = "Roll:";
            // 
            // LblOverlayCamYaw
            // 
            this.LblOverlayCamYaw.AutoSize = true;
            this.LblOverlayCamYaw.Location = new System.Drawing.Point(6, 125);
            this.LblOverlayCamYaw.Name = "LblOverlayCamYaw";
            this.LblOverlayCamYaw.Size = new System.Drawing.Size(31, 13);
            this.LblOverlayCamYaw.TabIndex = 10;
            this.LblOverlayCamYaw.Text = "Yaw:";
            // 
            // LblOverlayCamPitch
            // 
            this.LblOverlayCamPitch.AutoSize = true;
            this.LblOverlayCamPitch.Location = new System.Drawing.Point(6, 108);
            this.LblOverlayCamPitch.Name = "LblOverlayCamPitch";
            this.LblOverlayCamPitch.Size = new System.Drawing.Size(34, 13);
            this.LblOverlayCamPitch.TabIndex = 9;
            this.LblOverlayCamPitch.Text = "Pitch:";
            // 
            // LblOverlayCamPositionZ
            // 
            this.LblOverlayCamPositionZ.AutoSize = true;
            this.LblOverlayCamPositionZ.Location = new System.Drawing.Point(6, 77);
            this.LblOverlayCamPositionZ.Name = "LblOverlayCamPositionZ";
            this.LblOverlayCamPositionZ.Size = new System.Drawing.Size(57, 13);
            this.LblOverlayCamPositionZ.TabIndex = 8;
            this.LblOverlayCamPositionZ.Text = "Position Z:";
            // 
            // LblOverlayCamPositionY
            // 
            this.LblOverlayCamPositionY.AutoSize = true;
            this.LblOverlayCamPositionY.Location = new System.Drawing.Point(6, 60);
            this.LblOverlayCamPositionY.Name = "LblOverlayCamPositionY";
            this.LblOverlayCamPositionY.Size = new System.Drawing.Size(57, 13);
            this.LblOverlayCamPositionY.TabIndex = 7;
            this.LblOverlayCamPositionY.Text = "Position Y:";
            // 
            // LblOverlayCamPositionX
            // 
            this.LblOverlayCamPositionX.AutoSize = true;
            this.LblOverlayCamPositionX.Location = new System.Drawing.Point(6, 43);
            this.LblOverlayCamPositionX.Name = "LblOverlayCamPositionX";
            this.LblOverlayCamPositionX.Size = new System.Drawing.Size(57, 13);
            this.LblOverlayCamPositionX.TabIndex = 6;
            this.LblOverlayCamPositionX.Text = "Position X:";
            // 
            // TbpMap
            // 
            this.TbpMap.Controls.Add(this.BtnGrabMapGraphic);
            this.TbpMap.Controls.Add(this.PbxMapGraphic);
            this.TbpMap.Location = new System.Drawing.Point(4, 22);
            this.TbpMap.Name = "TbpMap";
            this.TbpMap.Padding = new System.Windows.Forms.Padding(3);
            this.TbpMap.Size = new System.Drawing.Size(752, 726);
            this.TbpMap.TabIndex = 1;
            this.TbpMap.Text = "Map";
            this.TbpMap.UseVisualStyleBackColor = true;
            // 
            // TbpBox
            // 
            this.TbpBox.Controls.Add(this.NudBoxZ);
            this.TbpBox.Controls.Add(this.NudBoxY);
            this.TbpBox.Controls.Add(this.NudBoxX);
            this.TbpBox.Controls.Add(this.LblBoxZ);
            this.TbpBox.Controls.Add(this.BtnBoxGetPosition);
            this.TbpBox.Controls.Add(this.BtnBoxSetPosition);
            this.TbpBox.Controls.Add(this.LblBoxX);
            this.TbpBox.Controls.Add(this.LblBoxY);
            this.TbpBox.Location = new System.Drawing.Point(4, 22);
            this.TbpBox.Name = "TbpBox";
            this.TbpBox.Padding = new System.Windows.Forms.Padding(3);
            this.TbpBox.Size = new System.Drawing.Size(752, 726);
            this.TbpBox.TabIndex = 2;
            this.TbpBox.Text = "Box";
            this.TbpBox.UseVisualStyleBackColor = true;
            // 
            // NudBoxZ
            // 
            this.NudBoxZ.Location = new System.Drawing.Point(199, 33);
            this.NudBoxZ.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudBoxZ.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudBoxZ.Name = "NudBoxZ";
            this.NudBoxZ.Size = new System.Drawing.Size(50, 20);
            this.NudBoxZ.TabIndex = 29;
            this.NudBoxZ.ValueChanged += new System.EventHandler(this.NudBoxZ_ValueChanged);
            // 
            // NudBoxY
            // 
            this.NudBoxY.Location = new System.Drawing.Point(143, 33);
            this.NudBoxY.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudBoxY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudBoxY.Name = "NudBoxY";
            this.NudBoxY.Size = new System.Drawing.Size(50, 20);
            this.NudBoxY.TabIndex = 28;
            this.NudBoxY.ValueChanged += new System.EventHandler(this.NudBoxY_ValueChanged);
            // 
            // NudBoxX
            // 
            this.NudBoxX.Location = new System.Drawing.Point(87, 33);
            this.NudBoxX.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudBoxX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudBoxX.Name = "NudBoxX";
            this.NudBoxX.Size = new System.Drawing.Size(50, 20);
            this.NudBoxX.TabIndex = 27;
            this.NudBoxX.ValueChanged += new System.EventHandler(this.NudBoxX_ValueChanged);
            // 
            // LblBoxZ
            // 
            this.LblBoxZ.AutoSize = true;
            this.LblBoxZ.Location = new System.Drawing.Point(202, 12);
            this.LblBoxZ.Name = "LblBoxZ";
            this.LblBoxZ.Size = new System.Drawing.Size(44, 13);
            this.LblBoxZ.TabIndex = 26;
            this.LblBoxZ.Text = "<box z>";
            // 
            // BtnBoxGetPosition
            // 
            this.BtnBoxGetPosition.Location = new System.Drawing.Point(6, 32);
            this.BtnBoxGetPosition.Name = "BtnBoxGetPosition";
            this.BtnBoxGetPosition.Size = new System.Drawing.Size(75, 23);
            this.BtnBoxGetPosition.TabIndex = 19;
            this.BtnBoxGetPosition.Text = "Get position";
            this.BtnBoxGetPosition.UseVisualStyleBackColor = true;
            this.BtnBoxGetPosition.Click += new System.EventHandler(this.BtnBoxGetPosition_Click);
            // 
            // BtnBoxSetPosition
            // 
            this.BtnBoxSetPosition.Location = new System.Drawing.Point(255, 32);
            this.BtnBoxSetPosition.Name = "BtnBoxSetPosition";
            this.BtnBoxSetPosition.Size = new System.Drawing.Size(75, 23);
            this.BtnBoxSetPosition.TabIndex = 20;
            this.BtnBoxSetPosition.Text = "Set position";
            this.BtnBoxSetPosition.UseVisualStyleBackColor = true;
            this.BtnBoxSetPosition.Click += new System.EventHandler(this.BtnBoxSetPosition_Click);
            // 
            // LblBoxX
            // 
            this.LblBoxX.AutoSize = true;
            this.LblBoxX.Location = new System.Drawing.Point(90, 12);
            this.LblBoxX.Name = "LblBoxX";
            this.LblBoxX.Size = new System.Drawing.Size(44, 13);
            this.LblBoxX.TabIndex = 24;
            this.LblBoxX.Text = "<box x>";
            // 
            // LblBoxY
            // 
            this.LblBoxY.AutoSize = true;
            this.LblBoxY.Location = new System.Drawing.Point(146, 12);
            this.LblBoxY.Name = "LblBoxY";
            this.LblBoxY.Size = new System.Drawing.Size(44, 13);
            this.LblBoxY.TabIndex = 25;
            this.LblBoxY.Text = "<box y>";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Y up, right-handed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Y down, X north, Z east";
            // 
            // CustomMainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 776);
            this.Controls.Add(this.tabControl1);
            this.Name = "CustomMainForm";
            this.GbxHarry.ResumeLayout(false);
            this.GbxHarry.PerformLayout();
            this.GbxCamera.ResumeLayout(false);
            this.GbxCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.TbpBasics.ResumeLayout(false);
            this.GbxControls.ResumeLayout(false);
            this.GbxControls.PerformLayout();
            this.GbxOverlay.ResumeLayout(false);
            this.GbxOverlay.PerformLayout();
            this.TbpMap.ResumeLayout(false);
            this.TbpMap.PerformLayout();
            this.TbpBox.ResumeLayout(false);
            this.TbpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxX)).EndInit();
            this.ResumeLayout(false);

		}

		private Label LblHarryPositionX;
		private Label LblHarryPositionY;
		private Button BtnSetHarryPitch;
		private Button BtnSetHarryYaw;
		private Button BtnSetHarryRoll;
		private TextBox TbxHarryPitch;
		private TextBox TbxHarryYaw;
		private TextBox TbxHarryRoll;
		private Button BtnGetAngles;
		private GroupBox GbxHarry;
		private Label LblHarryRoll;
		private Label LblHarryYaw;
		private Label LblHarryPitch;
		private Button BtnSetAngles;
		private Label LblHarryPositionZ;
		private TextBox TbxPositionZ;
		private GroupBox GbxCamera;
		private Label LblCameraPositionZ;
		private Label LblCameraPositionY;
		private Label LblCameraPositionX;
		private Label LblCameraRoll;
		private Label LblCameraYaw;
		private Label LblCameraPitch;
		private TrackBar TrkFov;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private Label LblFov;
		private Button BtnGrabMapGraphic;
		private PictureBox PbxMapGraphic;
		private TabControl tabControl1;
		private TabPage TbpBasics;
		private TabPage TbpMap;
		private TabPage TbpBox;
		private Label LblBoxZ;
		private Button BtnBoxGetPosition;
		private Button BtnBoxSetPosition;
		private Label LblBoxX;
		private Label LblBoxY;
		private NumericUpDown NudBoxZ;
		private NumericUpDown NudBoxY;
		private NumericUpDown NudBoxX;
		private GroupBox GbxOverlay;
		private Label LblOverlayCamRoll;
		private Label LblOverlayCamYaw;
		private Label LblOverlayCamPitch;
		private Label LblOverlayCamPositionZ;
		private Label LblOverlayCamPositionY;
		private Label LblOverlayCamPositionX;
		private GroupBox GbxControls;
		private Label LblButtonStart;
		private Label LblButtonSelect;
		private Label LblButtonDown;
		private Label LblButtonRight;
		private Label LblButtonLeft;
		private Label LblButtonUp;
		private Label LblButtonX;
		private Label LblButtonCircle;
		private Label LblButtonSquare;
		private Label LblButtonTriangle;
		private Label LblButtonR3;
		private Label LblButtonL3;
		private Label LblButtonR2;
		private Label LblButtonR1;
		private Label LblButtonL2;
		private Label LblButtonL1;
		private Label label2;
		private Label label1;
	}
}
