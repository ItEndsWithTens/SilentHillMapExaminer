using System.Windows.Forms;

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
            this.CbxEnableHarrySection = new System.Windows.Forms.CheckBox();
            this.LblHarryPositionZ = new System.Windows.Forms.Label();
            this.TbxPositionZ = new System.Windows.Forms.TextBox();
            this.BtnSetAngles = new System.Windows.Forms.Button();
            this.LblHarryRoll = new System.Windows.Forms.Label();
            this.LblHarryYaw = new System.Windows.Forms.Label();
            this.LblHarryPitch = new System.Windows.Forms.Label();
            this.GbxCamera = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.LblCameraDrawDistance = new System.Windows.Forms.Label();
            this.CbxCameraFreeze = new System.Windows.Forms.CheckBox();
            this.CbxEnableCameraSection = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCameraRoll = new System.Windows.Forms.Label();
            this.LblCameraYaw = new System.Windows.Forms.Label();
            this.LblCameraPitch = new System.Windows.Forms.Label();
            this.LblCameraPositionZ = new System.Windows.Forms.Label();
            this.LblCameraPositionY = new System.Windows.Forms.Label();
            this.LblCameraPositionX = new System.Windows.Forms.Label();
            this.LblFov = new System.Windows.Forms.Label();
            this.TrkFov = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnGrabMapGraphic = new System.Windows.Forms.Button();
            this.PbxMapGraphic = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TbpBasics = new System.Windows.Forms.TabPage();
            this.GbxControls = new System.Windows.Forms.GroupBox();
            this.CbxEnableControlsSection = new System.Windows.Forms.CheckBox();
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
            this.CbxEnableTriggerDisplay = new System.Windows.Forms.CheckBox();
            this.CbxEnableOverlaySection = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblOverlayCamRoll = new System.Windows.Forms.Label();
            this.LblOverlayCamYaw = new System.Windows.Forms.Label();
            this.LblOverlayCamPitch = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionZ = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionY = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionX = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.LblHarryHealth = new System.Windows.Forms.Label();
            this.CbxStats = new System.Windows.Forms.CheckBox();
            this.LblDistanceRun = new System.Windows.Forms.Label();
            this.LblDistanceWalked = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LblCalculatedRoll = new System.Windows.Forms.Label();
            this.LblCalculatedYaw = new System.Windows.Forms.Label();
            this.LblCalculatedPitch = new System.Windows.Forms.Label();
            this.LblCalculated = new System.Windows.Forms.Label();
            this.LblMatrix33 = new System.Windows.Forms.Label();
            this.LblMatrix32 = new System.Windows.Forms.Label();
            this.LblMatrix31 = new System.Windows.Forms.Label();
            this.LblMatrix23 = new System.Windows.Forms.Label();
            this.LblMatrix22 = new System.Windows.Forms.Label();
            this.LblMatrix21 = new System.Windows.Forms.Label();
            this.LblMatrix13 = new System.Windows.Forms.Label();
            this.LblMatrix12 = new System.Windows.Forms.Label();
            this.LblMatrix11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LblGteZ = new System.Windows.Forms.Label();
            this.LblGteY = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LblGteX = new System.Windows.Forms.Label();
            this.LblRegisterTest = new System.Windows.Forms.Label();
            this.TbpInfo = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.BtnCustomWorldTintCurrent = new System.Windows.Forms.Button();
            this.BtnCustomFogCurrent = new System.Windows.Forms.Button();
            this.BtnWorldTintDefault = new System.Windows.Forms.Button();
            this.BtnFogColorDefault = new System.Windows.Forms.Button();
            this.CbxCustomWorldTint = new System.Windows.Forms.CheckBox();
            this.NudWorldTintB = new System.Windows.Forms.NumericUpDown();
            this.NudWorldTintG = new System.Windows.Forms.NumericUpDown();
            this.NudWorldTintR = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.BtnWorldTintColor = new System.Windows.Forms.Button();
            this.CbxFogCustom = new System.Windows.Forms.CheckBox();
            this.NudFogB = new System.Windows.Forms.NumericUpDown();
            this.NudFogG = new System.Windows.Forms.NumericUpDown();
            this.NudFogR = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnFogColor = new System.Windows.Forms.Button();
            this.CbxFog = new System.Windows.Forms.CheckBox();
            this.LblSpawnZ = new System.Windows.Forms.Label();
            this.LblSpawnX = new System.Windows.Forms.Label();
            this.LblSpawnInfo = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.GbxHarry.SuspendLayout();
            this.GbxCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TbpBasics.SuspendLayout();
            this.GbxControls.SuspendLayout();
            this.GbxOverlay.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TbpMap.SuspendLayout();
            this.TbpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxX)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).BeginInit();
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
            this.GbxHarry.Controls.Add(this.label19);
            this.GbxHarry.Controls.Add(this.label18);
            this.GbxHarry.Controls.Add(this.LblSpawnZ);
            this.GbxHarry.Controls.Add(this.LblSpawnX);
            this.GbxHarry.Controls.Add(this.LblSpawnInfo);
            this.GbxHarry.Controls.Add(this.CbxEnableHarrySection);
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
            this.GbxHarry.Size = new System.Drawing.Size(338, 433);
            this.GbxHarry.TabIndex = 13;
            this.GbxHarry.TabStop = false;
            this.GbxHarry.Text = "Harry";
            // 
            // CbxEnableHarrySection
            // 
            this.CbxEnableHarrySection.AutoSize = true;
            this.CbxEnableHarrySection.Checked = true;
            this.CbxEnableHarrySection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEnableHarrySection.Location = new System.Drawing.Point(273, 410);
            this.CbxEnableHarrySection.Name = "CbxEnableHarrySection";
            this.CbxEnableHarrySection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableHarrySection.TabIndex = 16;
            this.CbxEnableHarrySection.Text = "Enable";
            this.CbxEnableHarrySection.UseVisualStyleBackColor = true;
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
            this.GbxCamera.Controls.Add(this.label13);
            this.GbxCamera.Controls.Add(this.LblCameraDrawDistance);
            this.GbxCamera.Controls.Add(this.CbxCameraFreeze);
            this.GbxCamera.Controls.Add(this.CbxEnableCameraSection);
            this.GbxCamera.Controls.Add(this.label1);
            this.GbxCamera.Controls.Add(this.LblCameraRoll);
            this.GbxCamera.Controls.Add(this.LblCameraYaw);
            this.GbxCamera.Controls.Add(this.LblCameraPitch);
            this.GbxCamera.Controls.Add(this.LblCameraPositionZ);
            this.GbxCamera.Controls.Add(this.LblCameraPositionY);
            this.GbxCamera.Controls.Add(this.LblCameraPositionX);
            this.GbxCamera.Location = new System.Drawing.Point(350, 6);
            this.GbxCamera.Name = "GbxCamera";
            this.GbxCamera.Size = new System.Drawing.Size(396, 433);
            this.GbxCamera.TabIndex = 14;
            this.GbxCamera.TabStop = false;
            this.GbxCamera.Text = "Game camera";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(221, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Draw distance:";
            // 
            // LblCameraDrawDistance
            // 
            this.LblCameraDrawDistance.AutoSize = true;
            this.LblCameraDrawDistance.Location = new System.Drawing.Point(305, 16);
            this.LblCameraDrawDistance.Name = "LblCameraDrawDistance";
            this.LblCameraDrawDistance.Size = new System.Drawing.Size(85, 13);
            this.LblCameraDrawDistance.TabIndex = 17;
            this.LblCameraDrawDistance.Text = "<draw distance>";
            // 
            // CbxCameraFreeze
            // 
            this.CbxCameraFreeze.AutoSize = true;
            this.CbxCameraFreeze.Location = new System.Drawing.Point(9, 225);
            this.CbxCameraFreeze.Name = "CbxCameraFreeze";
            this.CbxCameraFreeze.Size = new System.Drawing.Size(58, 17);
            this.CbxCameraFreeze.TabIndex = 16;
            this.CbxCameraFreeze.Text = "Freeze";
            this.CbxCameraFreeze.UseVisualStyleBackColor = true;
            this.CbxCameraFreeze.CheckedChanged += new System.EventHandler(this.CbxCameraFreeze_CheckedChanged);
            // 
            // CbxEnableCameraSection
            // 
            this.CbxEnableCameraSection.AutoSize = true;
            this.CbxEnableCameraSection.Checked = true;
            this.CbxEnableCameraSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEnableCameraSection.Location = new System.Drawing.Point(337, 243);
            this.CbxEnableCameraSection.Name = "CbxEnableCameraSection";
            this.CbxEnableCameraSection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableCameraSection.TabIndex = 15;
            this.CbxEnableCameraSection.Text = "Enable";
            this.CbxEnableCameraSection.UseVisualStyleBackColor = true;
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
            // LblFov
            // 
            this.LblFov.AutoSize = true;
            this.LblFov.Location = new System.Drawing.Point(181, 182);
            this.LblFov.Name = "LblFov";
            this.LblFov.Size = new System.Drawing.Size(34, 13);
            this.LblFov.TabIndex = 8;
            this.LblFov.Text = "<fov>";
            // 
            // TrkFov
            // 
            this.TrkFov.Location = new System.Drawing.Point(6, 198);
            this.TrkFov.Maximum = 120;
            this.TrkFov.Minimum = 1;
            this.TrkFov.Name = "TrkFov";
            this.TrkFov.Size = new System.Drawing.Size(384, 45);
            this.TrkFov.TabIndex = 6;
            this.TrkFov.Value = 1;
            this.TrkFov.Scroll += new System.EventHandler(this.TrkFov_Scroll);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.TbpMap);
            this.tabControl1.Controls.Add(this.TbpBox);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TbpInfo);
            this.tabControl1.Controls.Add(this.tabPage3);
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
            this.GbxControls.Controls.Add(this.CbxEnableControlsSection);
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
            this.GbxControls.Location = new System.Drawing.Point(6, 445);
            this.GbxControls.Name = "GbxControls";
            this.GbxControls.Size = new System.Drawing.Size(338, 275);
            this.GbxControls.TabIndex = 16;
            this.GbxControls.TabStop = false;
            this.GbxControls.Text = "Controls";
            // 
            // CbxEnableControlsSection
            // 
            this.CbxEnableControlsSection.AutoSize = true;
            this.CbxEnableControlsSection.Location = new System.Drawing.Point(273, 252);
            this.CbxEnableControlsSection.Name = "CbxEnableControlsSection";
            this.CbxEnableControlsSection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableControlsSection.TabIndex = 15;
            this.CbxEnableControlsSection.Text = "Enable";
            this.CbxEnableControlsSection.UseVisualStyleBackColor = true;
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
            this.GbxOverlay.Controls.Add(this.CbxEnableTriggerDisplay);
            this.GbxOverlay.Controls.Add(this.CbxEnableOverlaySection);
            this.GbxOverlay.Controls.Add(this.label2);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamRoll);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamYaw);
            this.GbxOverlay.Controls.Add(this.LblFov);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPitch);
            this.GbxOverlay.Controls.Add(this.TrkFov);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionZ);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionY);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionX);
            this.GbxOverlay.Location = new System.Drawing.Point(350, 445);
            this.GbxOverlay.Name = "GbxOverlay";
            this.GbxOverlay.Size = new System.Drawing.Size(396, 275);
            this.GbxOverlay.TabIndex = 15;
            this.GbxOverlay.TabStop = false;
            this.GbxOverlay.Text = "Overlay camera";
            // 
            // CbxEnableTriggerDisplay
            // 
            this.CbxEnableTriggerDisplay.AutoSize = true;
            this.CbxEnableTriggerDisplay.Location = new System.Drawing.Point(331, 249);
            this.CbxEnableTriggerDisplay.Name = "CbxEnableTriggerDisplay";
            this.CbxEnableTriggerDisplay.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableTriggerDisplay.TabIndex = 15;
            this.CbxEnableTriggerDisplay.Text = "Enable";
            this.CbxEnableTriggerDisplay.UseVisualStyleBackColor = true;
            this.CbxEnableTriggerDisplay.CheckedChanged += new System.EventHandler(this.CbxEnableTriggerDisplay_CheckedChanged);
            // 
            // CbxEnableOverlaySection
            // 
            this.CbxEnableOverlaySection.AutoSize = true;
            this.CbxEnableOverlaySection.Location = new System.Drawing.Point(9, 170);
            this.CbxEnableOverlaySection.Name = "CbxEnableOverlaySection";
            this.CbxEnableOverlaySection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableOverlaySection.TabIndex = 14;
            this.CbxEnableOverlaySection.Text = "Enable";
            this.CbxEnableOverlaySection.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Y up, X north, Z east";
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.LblHarryHealth);
            this.tabPage2.Controls.Add(this.CbxStats);
            this.tabPage2.Controls.Add(this.LblDistanceRun);
            this.tabPage2.Controls.Add(this.LblDistanceWalked);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 726);
            this.tabPage2.TabIndex = 5;
            this.tabPage2.Text = "Stats";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(3, 3);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Harry health:";
            // 
            // LblHarryHealth
            // 
            this.LblHarryHealth.AutoSize = true;
            this.LblHarryHealth.Location = new System.Drawing.Point(76, 3);
            this.LblHarryHealth.Name = "LblHarryHealth";
            this.LblHarryHealth.Size = new System.Drawing.Size(74, 13);
            this.LblHarryHealth.TabIndex = 20;
            this.LblHarryHealth.Text = "<harry health>";
            // 
            // CbxStats
            // 
            this.CbxStats.AutoSize = true;
            this.CbxStats.Checked = true;
            this.CbxStats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxStats.Location = new System.Drawing.Point(687, 703);
            this.CbxStats.Name = "CbxStats";
            this.CbxStats.Size = new System.Drawing.Size(59, 17);
            this.CbxStats.TabIndex = 4;
            this.CbxStats.Text = "Enable";
            this.CbxStats.UseVisualStyleBackColor = true;
            // 
            // LblDistanceRun
            // 
            this.LblDistanceRun.AutoSize = true;
            this.LblDistanceRun.Location = new System.Drawing.Point(98, 46);
            this.LblDistanceRun.Name = "LblDistanceRun";
            this.LblDistanceRun.Size = new System.Drawing.Size(34, 13);
            this.LblDistanceRun.TabIndex = 3;
            this.LblDistanceRun.Text = "<run>";
            // 
            // LblDistanceWalked
            // 
            this.LblDistanceWalked.AutoSize = true;
            this.LblDistanceWalked.Location = new System.Drawing.Point(98, 33);
            this.LblDistanceWalked.Name = "LblDistanceWalked";
            this.LblDistanceWalked.Size = new System.Drawing.Size(53, 13);
            this.LblDistanceWalked.TabIndex = 2;
            this.LblDistanceWalked.Text = "<walked>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Distance run:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Distance walked:";
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LblCalculatedRoll);
            this.tabPage1.Controls.Add(this.LblCalculatedYaw);
            this.tabPage1.Controls.Add(this.LblCalculatedPitch);
            this.tabPage1.Controls.Add(this.LblCalculated);
            this.tabPage1.Controls.Add(this.LblMatrix33);
            this.tabPage1.Controls.Add(this.LblMatrix32);
            this.tabPage1.Controls.Add(this.LblMatrix31);
            this.tabPage1.Controls.Add(this.LblMatrix23);
            this.tabPage1.Controls.Add(this.LblMatrix22);
            this.tabPage1.Controls.Add(this.LblMatrix21);
            this.tabPage1.Controls.Add(this.LblMatrix13);
            this.tabPage1.Controls.Add(this.LblMatrix12);
            this.tabPage1.Controls.Add(this.LblMatrix11);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.LblGteZ);
            this.tabPage1.Controls.Add(this.LblGteY);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.LblGteX);
            this.tabPage1.Controls.Add(this.LblRegisterTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 726);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "GTE";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LblCalculatedRoll
            // 
            this.LblCalculatedRoll.AutoSize = true;
            this.LblCalculatedRoll.Location = new System.Drawing.Point(23, 527);
            this.LblCalculatedRoll.Name = "LblCalculatedRoll";
            this.LblCalculatedRoll.Size = new System.Drawing.Size(35, 13);
            this.LblCalculatedRoll.TabIndex = 18;
            this.LblCalculatedRoll.Text = "label3";
            // 
            // LblCalculatedYaw
            // 
            this.LblCalculatedYaw.AutoSize = true;
            this.LblCalculatedYaw.Location = new System.Drawing.Point(23, 505);
            this.LblCalculatedYaw.Name = "LblCalculatedYaw";
            this.LblCalculatedYaw.Size = new System.Drawing.Size(35, 13);
            this.LblCalculatedYaw.TabIndex = 17;
            this.LblCalculatedYaw.Text = "label3";
            // 
            // LblCalculatedPitch
            // 
            this.LblCalculatedPitch.AutoSize = true;
            this.LblCalculatedPitch.Location = new System.Drawing.Point(23, 482);
            this.LblCalculatedPitch.Name = "LblCalculatedPitch";
            this.LblCalculatedPitch.Size = new System.Drawing.Size(35, 13);
            this.LblCalculatedPitch.TabIndex = 16;
            this.LblCalculatedPitch.Text = "label3";
            // 
            // LblCalculated
            // 
            this.LblCalculated.AutoSize = true;
            this.LblCalculated.Location = new System.Drawing.Point(23, 448);
            this.LblCalculated.Name = "LblCalculated";
            this.LblCalculated.Size = new System.Drawing.Size(91, 13);
            this.LblCalculated.TabIndex = 15;
            this.LblCalculated.Text = "Calculated values";
            // 
            // LblMatrix33
            // 
            this.LblMatrix33.AutoSize = true;
            this.LblMatrix33.Location = new System.Drawing.Point(196, 355);
            this.LblMatrix33.Name = "LblMatrix33";
            this.LblMatrix33.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix33.TabIndex = 14;
            this.LblMatrix33.Text = "label3";
            // 
            // LblMatrix32
            // 
            this.LblMatrix32.AutoSize = true;
            this.LblMatrix32.Location = new System.Drawing.Point(196, 333);
            this.LblMatrix32.Name = "LblMatrix32";
            this.LblMatrix32.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix32.TabIndex = 13;
            this.LblMatrix32.Text = "label3";
            // 
            // LblMatrix31
            // 
            this.LblMatrix31.AutoSize = true;
            this.LblMatrix31.Location = new System.Drawing.Point(196, 310);
            this.LblMatrix31.Name = "LblMatrix31";
            this.LblMatrix31.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix31.TabIndex = 12;
            this.LblMatrix31.Text = "label3";
            // 
            // LblMatrix23
            // 
            this.LblMatrix23.AutoSize = true;
            this.LblMatrix23.Location = new System.Drawing.Point(106, 355);
            this.LblMatrix23.Name = "LblMatrix23";
            this.LblMatrix23.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix23.TabIndex = 11;
            this.LblMatrix23.Text = "label3";
            // 
            // LblMatrix22
            // 
            this.LblMatrix22.AutoSize = true;
            this.LblMatrix22.Location = new System.Drawing.Point(106, 333);
            this.LblMatrix22.Name = "LblMatrix22";
            this.LblMatrix22.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix22.TabIndex = 10;
            this.LblMatrix22.Text = "label3";
            // 
            // LblMatrix21
            // 
            this.LblMatrix21.AutoSize = true;
            this.LblMatrix21.Location = new System.Drawing.Point(106, 310);
            this.LblMatrix21.Name = "LblMatrix21";
            this.LblMatrix21.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix21.TabIndex = 9;
            this.LblMatrix21.Text = "label3";
            // 
            // LblMatrix13
            // 
            this.LblMatrix13.AutoSize = true;
            this.LblMatrix13.Location = new System.Drawing.Point(23, 355);
            this.LblMatrix13.Name = "LblMatrix13";
            this.LblMatrix13.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix13.TabIndex = 8;
            this.LblMatrix13.Text = "label3";
            // 
            // LblMatrix12
            // 
            this.LblMatrix12.AutoSize = true;
            this.LblMatrix12.Location = new System.Drawing.Point(23, 333);
            this.LblMatrix12.Name = "LblMatrix12";
            this.LblMatrix12.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix12.TabIndex = 7;
            this.LblMatrix12.Text = "label3";
            // 
            // LblMatrix11
            // 
            this.LblMatrix11.AutoSize = true;
            this.LblMatrix11.Location = new System.Drawing.Point(23, 310);
            this.LblMatrix11.Name = "LblMatrix11";
            this.LblMatrix11.Size = new System.Drawing.Size(35, 13);
            this.LblMatrix11.TabIndex = 6;
            this.LblMatrix11.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Some matrix";
            // 
            // LblGteZ
            // 
            this.LblGteZ.AutoSize = true;
            this.LblGteZ.Location = new System.Drawing.Point(23, 207);
            this.LblGteZ.Name = "LblGteZ";
            this.LblGteZ.Size = new System.Drawing.Size(35, 13);
            this.LblGteZ.TabIndex = 4;
            this.LblGteZ.Text = "label3";
            // 
            // LblGteY
            // 
            this.LblGteY.AutoSize = true;
            this.LblGteY.Location = new System.Drawing.Point(23, 185);
            this.LblGteY.Name = "LblGteY";
            this.LblGteY.Size = new System.Drawing.Size(35, 13);
            this.LblGteY.TabIndex = 3;
            this.LblGteY.Text = "label3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "GTE Translation Vector";
            // 
            // LblGteX
            // 
            this.LblGteX.AutoSize = true;
            this.LblGteX.Location = new System.Drawing.Point(23, 162);
            this.LblGteX.Name = "LblGteX";
            this.LblGteX.Size = new System.Drawing.Size(35, 13);
            this.LblGteX.TabIndex = 1;
            this.LblGteX.Text = "label3";
            // 
            // LblRegisterTest
            // 
            this.LblRegisterTest.AutoSize = true;
            this.LblRegisterTest.Location = new System.Drawing.Point(23, 24);
            this.LblRegisterTest.Name = "LblRegisterTest";
            this.LblRegisterTest.Size = new System.Drawing.Size(35, 13);
            this.LblRegisterTest.TabIndex = 0;
            this.LblRegisterTest.Text = "label3";
            // 
            // TbpInfo
            // 
            this.TbpInfo.Location = new System.Drawing.Point(4, 22);
            this.TbpInfo.Name = "TbpInfo";
            this.TbpInfo.Padding = new System.Windows.Forms.Padding(3);
            this.TbpInfo.Size = new System.Drawing.Size(752, 726);
            this.TbpInfo.TabIndex = 4;
            this.TbpInfo.Text = "Info";
            this.TbpInfo.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.BtnCustomWorldTintCurrent);
            this.tabPage3.Controls.Add(this.BtnCustomFogCurrent);
            this.tabPage3.Controls.Add(this.BtnWorldTintDefault);
            this.tabPage3.Controls.Add(this.BtnFogColorDefault);
            this.tabPage3.Controls.Add(this.CbxCustomWorldTint);
            this.tabPage3.Controls.Add(this.NudWorldTintB);
            this.tabPage3.Controls.Add(this.NudWorldTintG);
            this.tabPage3.Controls.Add(this.NudWorldTintR);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.BtnWorldTintColor);
            this.tabPage3.Controls.Add(this.CbxFogCustom);
            this.tabPage3.Controls.Add(this.NudFogB);
            this.tabPage3.Controls.Add(this.NudFogG);
            this.tabPage3.Controls.Add(this.NudFogR);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.BtnFogColor);
            this.tabPage3.Controls.Add(this.CbxFog);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 726);
            this.tabPage3.TabIndex = 6;
            this.tabPage3.Text = "Fog";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // BtnCustomWorldTintCurrent
            // 
            this.BtnCustomWorldTintCurrent.Location = new System.Drawing.Point(265, 102);
            this.BtnCustomWorldTintCurrent.Name = "BtnCustomWorldTintCurrent";
            this.BtnCustomWorldTintCurrent.Size = new System.Drawing.Size(87, 23);
            this.BtnCustomWorldTintCurrent.TabIndex = 20;
            this.BtnCustomWorldTintCurrent.Text = "Current";
            this.BtnCustomWorldTintCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomWorldTintCurrent.Click += new System.EventHandler(this.BtnCustomWorldTintCurrent_Click);
            // 
            // BtnCustomFogCurrent
            // 
            this.BtnCustomFogCurrent.Location = new System.Drawing.Point(112, 102);
            this.BtnCustomFogCurrent.Name = "BtnCustomFogCurrent";
            this.BtnCustomFogCurrent.Size = new System.Drawing.Size(87, 23);
            this.BtnCustomFogCurrent.TabIndex = 19;
            this.BtnCustomFogCurrent.Text = "Current";
            this.BtnCustomFogCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomFogCurrent.Click += new System.EventHandler(this.BtnCustomFogCurrent_Click);
            // 
            // BtnWorldTintDefault
            // 
            this.BtnWorldTintDefault.Location = new System.Drawing.Point(265, 131);
            this.BtnWorldTintDefault.Name = "BtnWorldTintDefault";
            this.BtnWorldTintDefault.Size = new System.Drawing.Size(87, 23);
            this.BtnWorldTintDefault.TabIndex = 18;
            this.BtnWorldTintDefault.Text = "Default";
            this.BtnWorldTintDefault.UseVisualStyleBackColor = true;
            this.BtnWorldTintDefault.Click += new System.EventHandler(this.BtnWorldTintDefault_Click);
            // 
            // BtnFogColorDefault
            // 
            this.BtnFogColorDefault.Location = new System.Drawing.Point(112, 131);
            this.BtnFogColorDefault.Name = "BtnFogColorDefault";
            this.BtnFogColorDefault.Size = new System.Drawing.Size(87, 23);
            this.BtnFogColorDefault.TabIndex = 17;
            this.BtnFogColorDefault.Text = "Default";
            this.BtnFogColorDefault.UseVisualStyleBackColor = true;
            this.BtnFogColorDefault.Click += new System.EventHandler(this.BtnFogColorDefault_Click);
            // 
            // CbxCustomWorldTint
            // 
            this.CbxCustomWorldTint.AutoSize = true;
            this.CbxCustomWorldTint.Location = new System.Drawing.Point(223, 3);
            this.CbxCustomWorldTint.Name = "CbxCustomWorldTint";
            this.CbxCustomWorldTint.Size = new System.Drawing.Size(106, 17);
            this.CbxCustomWorldTint.TabIndex = 16;
            this.CbxCustomWorldTint.Text = "Custom world tint";
            this.CbxCustomWorldTint.UseVisualStyleBackColor = true;
            // 
            // NudWorldTintB
            // 
            this.NudWorldTintB.Location = new System.Drawing.Point(265, 73);
            this.NudWorldTintB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudWorldTintB.Name = "NudWorldTintB";
            this.NudWorldTintB.Size = new System.Drawing.Size(52, 20);
            this.NudWorldTintB.TabIndex = 15;
            this.NudWorldTintB.Value = new decimal(new int[] {
            138,
            0,
            0,
            0});
            this.NudWorldTintB.ValueChanged += new System.EventHandler(this.NudWorldTintB_ValueChanged);
            // 
            // NudWorldTintG
            // 
            this.NudWorldTintG.Location = new System.Drawing.Point(265, 47);
            this.NudWorldTintG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudWorldTintG.Name = "NudWorldTintG";
            this.NudWorldTintG.Size = new System.Drawing.Size(52, 20);
            this.NudWorldTintG.TabIndex = 14;
            this.NudWorldTintG.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NudWorldTintG.ValueChanged += new System.EventHandler(this.NudWorldTintG_ValueChanged);
            // 
            // NudWorldTintR
            // 
            this.NudWorldTintR.Location = new System.Drawing.Point(265, 21);
            this.NudWorldTintR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudWorldTintR.Name = "NudWorldTintR";
            this.NudWorldTintR.Size = new System.Drawing.Size(52, 20);
            this.NudWorldTintR.TabIndex = 13;
            this.NudWorldTintR.Value = new decimal(new int[] {
            121,
            0,
            0,
            0});
            this.NudWorldTintR.ValueChanged += new System.EventHandler(this.NudWorldTintR_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Fog B:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(221, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Fog G:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Fog R:";
            // 
            // BtnWorldTintColor
            // 
            this.BtnWorldTintColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(128)))), ((int)(((byte)(138)))));
            this.BtnWorldTintColor.Location = new System.Drawing.Point(323, 21);
            this.BtnWorldTintColor.Name = "BtnWorldTintColor";
            this.BtnWorldTintColor.Size = new System.Drawing.Size(29, 72);
            this.BtnWorldTintColor.TabIndex = 9;
            this.BtnWorldTintColor.UseVisualStyleBackColor = false;
            this.BtnWorldTintColor.Click += new System.EventHandler(this.BtnWorldTintColor_Click);
            // 
            // CbxFogCustom
            // 
            this.CbxFogCustom.AutoSize = true;
            this.CbxFogCustom.Location = new System.Drawing.Point(70, 3);
            this.CbxFogCustom.Name = "CbxFogCustom";
            this.CbxFogCustom.Size = new System.Drawing.Size(79, 17);
            this.CbxFogCustom.TabIndex = 8;
            this.CbxFogCustom.Text = "Custom fog";
            this.CbxFogCustom.UseVisualStyleBackColor = true;
            // 
            // NudFogB
            // 
            this.NudFogB.Location = new System.Drawing.Point(112, 73);
            this.NudFogB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudFogB.Name = "NudFogB";
            this.NudFogB.Size = new System.Drawing.Size(52, 20);
            this.NudFogB.TabIndex = 7;
            this.NudFogB.Value = new decimal(new int[] {
            116,
            0,
            0,
            0});
            this.NudFogB.ValueChanged += new System.EventHandler(this.NudFogB_ValueChanged);
            // 
            // NudFogG
            // 
            this.NudFogG.Location = new System.Drawing.Point(112, 47);
            this.NudFogG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudFogG.Name = "NudFogG";
            this.NudFogG.Size = new System.Drawing.Size(52, 20);
            this.NudFogG.TabIndex = 6;
            this.NudFogG.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NudFogG.ValueChanged += new System.EventHandler(this.NudFogG_ValueChanged);
            // 
            // NudFogR
            // 
            this.NudFogR.Location = new System.Drawing.Point(112, 21);
            this.NudFogR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudFogR.Name = "NudFogR";
            this.NudFogR.Size = new System.Drawing.Size(52, 20);
            this.NudFogR.TabIndex = 5;
            this.NudFogR.Value = new decimal(new int[] {
            108,
            0,
            0,
            0});
            this.NudFogR.ValueChanged += new System.EventHandler(this.NudFogR_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Fog B:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Fog G:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Fog R:";
            // 
            // BtnFogColor
            // 
            this.BtnFogColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.BtnFogColor.Location = new System.Drawing.Point(170, 21);
            this.BtnFogColor.Name = "BtnFogColor";
            this.BtnFogColor.Size = new System.Drawing.Size(29, 72);
            this.BtnFogColor.TabIndex = 1;
            this.BtnFogColor.UseVisualStyleBackColor = false;
            this.BtnFogColor.Click += new System.EventHandler(this.BtnFogColor_Click);
            // 
            // CbxFog
            // 
            this.CbxFog.AutoSize = true;
            this.CbxFog.Checked = true;
            this.CbxFog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxFog.Location = new System.Drawing.Point(6, 3);
            this.CbxFog.Name = "CbxFog";
            this.CbxFog.Size = new System.Drawing.Size(44, 17);
            this.CbxFog.TabIndex = 0;
            this.CbxFog.Text = "Fog";
            this.CbxFog.UseVisualStyleBackColor = true;
            // 
            // LblSpawnZ
            // 
            this.LblSpawnZ.AutoSize = true;
            this.LblSpawnZ.Location = new System.Drawing.Point(139, 264);
            this.LblSpawnZ.Name = "LblSpawnZ";
            this.LblSpawnZ.Size = new System.Drawing.Size(40, 13);
            this.LblSpawnZ.TabIndex = 21;
            this.LblSpawnZ.Text = "678.90";
            // 
            // LblSpawnX
            // 
            this.LblSpawnX.AutoSize = true;
            this.LblSpawnX.Location = new System.Drawing.Point(93, 264);
            this.LblSpawnX.Name = "LblSpawnX";
            this.LblSpawnX.Size = new System.Drawing.Size(40, 13);
            this.LblSpawnX.TabIndex = 19;
            this.LblSpawnX.Text = "123.45";
            // 
            // LblSpawnInfo
            // 
            this.LblSpawnInfo.AutoSize = true;
            this.LblSpawnInfo.Location = new System.Drawing.Point(93, 298);
            this.LblSpawnInfo.Name = "LblSpawnInfo";
            this.LblSpawnInfo.Size = new System.Drawing.Size(70, 13);
            this.LblSpawnInfo.TabIndex = 20;
            this.LblSpawnInfo.Text = "<spawn info>";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 264);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "Last spawn XZ:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 298);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Last spawn info:";
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TbpMap.ResumeLayout(false);
            this.TbpMap.PerformLayout();
            this.TbpBox.ResumeLayout(false);
            this.TbpBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudBoxX)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).EndInit();
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
		private CheckBox CbxEnableOverlaySection;
		private CheckBox CbxEnableHarrySection;
		private CheckBox CbxEnableCameraSection;
		private CheckBox CbxEnableControlsSection;
		private TabPage tabPage1;
		private Label LblRegisterTest;
		private Label LblGteZ;
		private Label LblGteY;
		private Label label3;
		private Label LblGteX;
		private Label LblMatrix33;
		private Label LblMatrix32;
		private Label LblMatrix31;
		private Label LblMatrix23;
		private Label LblMatrix22;
		private Label LblMatrix21;
		private Label LblMatrix13;
		private Label LblMatrix12;
		private Label LblMatrix11;
		private Label label4;
		private Label LblCalculatedRoll;
		private Label LblCalculatedYaw;
		private Label LblCalculatedPitch;
		private Label LblCalculated;
		private CheckBox CbxEnableTriggerDisplay;
		private TabPage TbpInfo;
		private CheckBox CbxCameraFreeze;
		private TabPage tabPage2;
		private Label label8;
		private Label label7;
		private Label LblDistanceRun;
		private Label LblDistanceWalked;
		private CheckBox CbxStats;
		private TabPage tabPage3;
		private CheckBox CbxFog;
		private Button BtnFogColor;
		private Label label9;
		private Label label6;
		private Label label5;
		private NumericUpDown NudFogB;
		private NumericUpDown NudFogG;
		private NumericUpDown NudFogR;
		private CheckBox CbxFogCustom;
		private CheckBox CbxCustomWorldTint;
		private NumericUpDown NudWorldTintB;
		private NumericUpDown NudWorldTintG;
		private NumericUpDown NudWorldTintR;
		private Label label10;
		private Label label11;
		private Label label12;
		private Button BtnWorldTintColor;
		private Button BtnWorldTintDefault;
		private Button BtnFogColorDefault;
		private Button BtnCustomWorldTintCurrent;
		private Button BtnCustomFogCurrent;
		private Label LblCameraDrawDistance;
		private Label label13;
		private Label label14;
		private Label LblHarryHealth;
		private Label label19;
		private Label label18;
		private Label LblSpawnZ;
		private Label LblSpawnX;
		private Label LblSpawnInfo;
	}
}
