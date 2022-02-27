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
            this.components = new System.ComponentModel.Container();
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
            this.LblSpawnThing2 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.LblSpawnThing1 = new System.Windows.Forms.Label();
            this.LblSpawnYaw = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LblSpawnZ = new System.Windows.Forms.Label();
            this.LblSpawnX = new System.Windows.Forms.Label();
            this.LblSpawnThing0 = new System.Windows.Forms.Label();
            this.CbxEnableHarrySection = new System.Windows.Forms.CheckBox();
            this.LblHarryPositionZ = new System.Windows.Forms.Label();
            this.TbxPositionZ = new System.Windows.Forms.TextBox();
            this.BtnSetAngles = new System.Windows.Forms.Button();
            this.LblHarryRoll = new System.Windows.Forms.Label();
            this.LblHarryYaw = new System.Windows.Forms.Label();
            this.LblHarryPitch = new System.Windows.Forms.Label();
            this.GbxCamera = new System.Windows.Forms.GroupBox();
            this.label48 = new System.Windows.Forms.Label();
            this.LblFov = new System.Windows.Forms.Label();
            this.TrkFov = new System.Windows.Forms.TrackBar();
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
            this.RdoOverlayAxisColorsOff = new System.Windows.Forms.RadioButton();
            this.label44 = new System.Windows.Forms.Label();
            this.RdoOverlayAxisColorsOverlay = new System.Windows.Forms.RadioButton();
            this.RdoOverlayAxisColorsGame = new System.Windows.Forms.RadioButton();
            this.LblPoiCount1 = new System.Windows.Forms.Label();
            this.CmbRenderMode = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.NudOverlayTestBoxZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxX = new System.Windows.Forms.NumericUpDown();
            this.CbxOverlayTestBox = new System.Windows.Forms.CheckBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.NudOverlayCameraZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraX = new System.Windows.Forms.NumericUpDown();
            this.CbxOverlayCameraMatchGame = new System.Windows.Forms.CheckBox();
            this.NudOverlayCameraRoll = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraYaw = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraPitch = new System.Windows.Forms.NumericUpDown();
            this.BtnReadPois = new System.Windows.Forms.Button();
            this.CbxEnableOverlay = new System.Windows.Forms.CheckBox();
            this.CbxEnableOverlayCameraReporting = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblOverlayCamRoll = new System.Windows.Forms.Label();
            this.LblOverlayCamYaw = new System.Windows.Forms.Label();
            this.LblOverlayCamPitch = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionZ = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionY = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionX = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.CbxTriggersAutoUpdate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CbxSelectedTriggerDisabled = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerFiredDetails = new System.Windows.Forms.Label();
            this.CbxSelectedTriggerEnableUpdates = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerSomeIndex = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.CmbSelectedTriggerType = new System.Windows.Forms.ComboBox();
            this.NudSelectedTriggerTargetIndex = new System.Windows.Forms.NumericUpDown();
            this.label42 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerAddress = new System.Windows.Forms.Label();
            this.LblSelectedTriggerTypeInfo = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing4 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing3 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiIndex = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerStyle = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerFired = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing1 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing0 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnGoToPoi = new System.Windows.Forms.Button();
            this.label33 = new System.Windows.Forms.Label();
            this.LbxPoiAssociatedTriggers = new System.Windows.Forms.ListBox();
            this.LblSelectedPoiAddress = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.LblSelectedPoiThing0 = new System.Windows.Forms.Label();
            this.LblSelectedPoiX = new System.Windows.Forms.Label();
            this.LblSelectedPoiZ = new System.Windows.Forms.Label();
            this.LblSelectedPoiThing2 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.LblSelectedPoiThing1 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.LblSelectedPoiYaw = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.LblTriggerCount = new System.Windows.Forms.Label();
            this.BtnReadTriggers = new System.Windows.Forms.Button();
            this.LbxTriggers = new System.Windows.Forms.ListBox();
            this.LblPoiCount2 = new System.Windows.Forms.Label();
            this.BtnReadPois2 = new System.Windows.Forms.Button();
            this.LbxPois = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LblTotalTime = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LblHarryHealth = new System.Windows.Forms.Label();
            this.CbxStats = new System.Windows.Forms.CheckBox();
            this.LblRunningDistance = new System.Windows.Forms.Label();
            this.LblWalkingDistance = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TbpMap = new System.Windows.Forms.TabPage();
            this.TbpModel = new System.Windows.Forms.TabPage();
            this.CbxEnableModelDisplay = new System.Windows.Forms.CheckBox();
            this.CmbModelSubmeshName = new System.Windows.Forms.ComboBox();
            this.LblModelScale = new System.Windows.Forms.Label();
            this.TrkModelScale = new System.Windows.Forms.TrackBar();
            this.BtnReadHarryModel = new System.Windows.Forms.Button();
            this.NudModelZ = new System.Windows.Forms.NumericUpDown();
            this.NudModelY = new System.Windows.Forms.NumericUpDown();
            this.NudModelX = new System.Windows.Forms.NumericUpDown();
            this.LblModelZ = new System.Windows.Forms.Label();
            this.BtnModelGetPosition = new System.Windows.Forms.Button();
            this.BtnModelSetPosition = new System.Windows.Forms.Button();
            this.LblModelX = new System.Windows.Forms.Label();
            this.LblModelY = new System.Windows.Forms.Label();
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
            this.BtnFogWorldTintColorSwap = new System.Windows.Forms.Button();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.RtbStrings = new System.Windows.Forms.RichTextBox();
            this.LblStringCount = new System.Windows.Forms.Label();
            this.BtnReadStrings = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.CmbSaveButton = new System.Windows.Forms.ComboBox();
            this.BtnOpenSaveMenu = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GbxHarry.SuspendLayout();
            this.GbxCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.TbpBasics.SuspendLayout();
            this.GbxControls.SuspendLayout();
            this.GbxOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraPitch)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TbpMap.SuspendLayout();
            this.TbpModel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkModelScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelX)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage6.SuspendLayout();
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
            this.GbxHarry.Controls.Add(this.LblSpawnThing2);
            this.GbxHarry.Controls.Add(this.label20);
            this.GbxHarry.Controls.Add(this.LblSpawnThing1);
            this.GbxHarry.Controls.Add(this.LblSpawnYaw);
            this.GbxHarry.Controls.Add(this.label17);
            this.GbxHarry.Controls.Add(this.label16);
            this.GbxHarry.Controls.Add(this.label15);
            this.GbxHarry.Controls.Add(this.label19);
            this.GbxHarry.Controls.Add(this.label18);
            this.GbxHarry.Controls.Add(this.LblSpawnZ);
            this.GbxHarry.Controls.Add(this.LblSpawnX);
            this.GbxHarry.Controls.Add(this.LblSpawnThing0);
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
            // LblSpawnThing2
            // 
            this.LblSpawnThing2.AutoSize = true;
            this.LblSpawnThing2.Location = new System.Drawing.Point(71, 393);
            this.LblSpawnThing2.Name = "LblSpawnThing2";
            this.LblSpawnThing2.Size = new System.Drawing.Size(48, 13);
            this.LblSpawnThing2.TabIndex = 29;
            this.LblSpawnThing2.Text = "<thing2>";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(22, 393);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(43, 13);
            this.label20.TabIndex = 28;
            this.label20.Text = "Thing2:";
            // 
            // LblSpawnThing1
            // 
            this.LblSpawnThing1.AutoSize = true;
            this.LblSpawnThing1.Location = new System.Drawing.Point(70, 345);
            this.LblSpawnThing1.Name = "LblSpawnThing1";
            this.LblSpawnThing1.Size = new System.Drawing.Size(48, 13);
            this.LblSpawnThing1.TabIndex = 27;
            this.LblSpawnThing1.Text = "<thing1>";
            // 
            // LblSpawnYaw
            // 
            this.LblSpawnYaw.AutoSize = true;
            this.LblSpawnYaw.Location = new System.Drawing.Point(71, 369);
            this.LblSpawnYaw.Name = "LblSpawnYaw";
            this.LblSpawnYaw.Size = new System.Drawing.Size(38, 13);
            this.LblSpawnYaw.TabIndex = 26;
            this.LblSpawnYaw.Text = "<yaw>";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 345);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 13);
            this.label17.TabIndex = 25;
            this.label17.Text = "Thing1:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(22, 369);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 13);
            this.label16.TabIndex = 24;
            this.label16.Text = "Yaw:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 321);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(43, 13);
            this.label15.TabIndex = 23;
            this.label15.Text = "Thing0:";
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
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 264);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 19;
            this.label18.Text = "Last spawn XZ:";
            // 
            // LblSpawnZ
            // 
            this.LblSpawnZ.AutoSize = true;
            this.LblSpawnZ.Location = new System.Drawing.Point(139, 264);
            this.LblSpawnZ.Name = "LblSpawnZ";
            this.LblSpawnZ.Size = new System.Drawing.Size(40, 13);
            this.LblSpawnZ.TabIndex = 21;
            this.LblSpawnZ.Text = "???.??";
            // 
            // LblSpawnX
            // 
            this.LblSpawnX.AutoSize = true;
            this.LblSpawnX.Location = new System.Drawing.Point(93, 264);
            this.LblSpawnX.Name = "LblSpawnX";
            this.LblSpawnX.Size = new System.Drawing.Size(40, 13);
            this.LblSpawnX.TabIndex = 19;
            this.LblSpawnX.Text = "???.??";
            // 
            // LblSpawnThing0
            // 
            this.LblSpawnThing0.AutoSize = true;
            this.LblSpawnThing0.Location = new System.Drawing.Point(71, 321);
            this.LblSpawnThing0.Name = "LblSpawnThing0";
            this.LblSpawnThing0.Size = new System.Drawing.Size(48, 13);
            this.LblSpawnThing0.TabIndex = 20;
            this.LblSpawnThing0.Text = "<thing0>";
            // 
            // CbxEnableHarrySection
            // 
            this.CbxEnableHarrySection.AutoSize = true;
            this.CbxEnableHarrySection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.GbxCamera.Controls.Add(this.label48);
            this.GbxCamera.Controls.Add(this.LblFov);
            this.GbxCamera.Controls.Add(this.TrkFov);
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
            this.GbxCamera.Size = new System.Drawing.Size(396, 332);
            this.GbxCamera.TabIndex = 14;
            this.GbxCamera.TabStop = false;
            this.GbxCamera.Text = "Game camera";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(8, 216);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(28, 13);
            this.label48.TabIndex = 21;
            this.label48.Text = "FOV";
            this.toolTip1.SetToolTip(this.label48, "Degrees vertical");
            // 
            // LblFov
            // 
            this.LblFov.AutoSize = true;
            this.LblFov.Location = new System.Drawing.Point(189, 216);
            this.LblFov.Name = "LblFov";
            this.LblFov.Size = new System.Drawing.Size(19, 13);
            this.LblFov.TabIndex = 20;
            this.LblFov.Text = "54";
            this.toolTip1.SetToolTip(this.LblFov, "Degrees vertical");
            // 
            // TrkFov
            // 
            this.TrkFov.Location = new System.Drawing.Point(6, 232);
            this.TrkFov.Maximum = 120;
            this.TrkFov.Minimum = 1;
            this.TrkFov.Name = "TrkFov";
            this.TrkFov.Size = new System.Drawing.Size(384, 45);
            this.TrkFov.TabIndex = 19;
            this.toolTip1.SetToolTip(this.TrkFov, "Degrees vertical");
            this.TrkFov.Value = 54;
            this.TrkFov.Scroll += new System.EventHandler(this.TrkFov_Scroll);
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
            this.CbxCameraFreeze.Location = new System.Drawing.Point(9, 168);
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
            this.CbxEnableCameraSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableCameraSection.Checked = true;
            this.CbxEnableCameraSection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEnableCameraSection.Location = new System.Drawing.Point(331, 309);
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
            this.label1.Text = "X east, Y down, Z north";
            this.toolTip1.SetToolTip(this.label1, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblCameraRoll
            // 
            this.LblCameraRoll.AutoSize = true;
            this.LblCameraRoll.Location = new System.Drawing.Point(6, 141);
            this.LblCameraRoll.Name = "LblCameraRoll";
            this.LblCameraRoll.Size = new System.Drawing.Size(99, 13);
            this.LblCameraRoll.TabIndex = 5;
            this.LblCameraRoll.Text = "<game camera roll>";
            // 
            // LblCameraYaw
            // 
            this.LblCameraYaw.AutoSize = true;
            this.LblCameraYaw.Location = new System.Drawing.Point(6, 124);
            this.LblCameraYaw.Name = "LblCameraYaw";
            this.LblCameraYaw.Size = new System.Drawing.Size(105, 13);
            this.LblCameraYaw.TabIndex = 4;
            this.LblCameraYaw.Text = "<game camera yaw>";
            // 
            // LblCameraPitch
            // 
            this.LblCameraPitch.AutoSize = true;
            this.LblCameraPitch.Location = new System.Drawing.Point(6, 107);
            this.LblCameraPitch.Name = "LblCameraPitch";
            this.LblCameraPitch.Size = new System.Drawing.Size(109, 13);
            this.LblCameraPitch.TabIndex = 3;
            this.LblCameraPitch.Text = "<game camera pitch>";
            // 
            // LblCameraPositionZ
            // 
            this.LblCameraPositionZ.AutoSize = true;
            this.LblCameraPositionZ.Location = new System.Drawing.Point(6, 76);
            this.LblCameraPositionZ.Name = "LblCameraPositionZ";
            this.LblCameraPositionZ.Size = new System.Drawing.Size(91, 13);
            this.LblCameraPositionZ.TabIndex = 2;
            this.LblCameraPositionZ.Text = "<game camera z>";
            this.toolTip1.SetToolTip(this.LblCameraPositionZ, "The game camera\'s position in SH coordinates");
            // 
            // LblCameraPositionY
            // 
            this.LblCameraPositionY.AutoSize = true;
            this.LblCameraPositionY.Location = new System.Drawing.Point(6, 59);
            this.LblCameraPositionY.Name = "LblCameraPositionY";
            this.LblCameraPositionY.Size = new System.Drawing.Size(91, 13);
            this.LblCameraPositionY.TabIndex = 1;
            this.LblCameraPositionY.Text = "<game camera y>";
            this.toolTip1.SetToolTip(this.LblCameraPositionY, "The game camera\'s position in SH coordinates");
            // 
            // LblCameraPositionX
            // 
            this.LblCameraPositionX.AutoSize = true;
            this.LblCameraPositionX.Location = new System.Drawing.Point(6, 42);
            this.LblCameraPositionX.Name = "LblCameraPositionX";
            this.LblCameraPositionX.Size = new System.Drawing.Size(91, 13);
            this.LblCameraPositionX.TabIndex = 0;
            this.LblCameraPositionX.Text = "<game camera x>";
            this.toolTip1.SetToolTip(this.LblCameraPositionX, "The game camera\'s position in SH coordinates");
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
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TbpBasics);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.TbpMap);
            this.tabControl1.Controls.Add(this.TbpModel);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.TbpInfo);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage6);
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
            this.CbxEnableControlsSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsOff);
            this.GbxOverlay.Controls.Add(this.label44);
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsOverlay);
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsGame);
            this.GbxOverlay.Controls.Add(this.LblPoiCount1);
            this.GbxOverlay.Controls.Add(this.CmbRenderMode);
            this.GbxOverlay.Controls.Add(this.label28);
            this.GbxOverlay.Controls.Add(this.label29);
            this.GbxOverlay.Controls.Add(this.label30);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxZ);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxY);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxX);
            this.GbxOverlay.Controls.Add(this.CbxOverlayTestBox);
            this.GbxOverlay.Controls.Add(this.label25);
            this.GbxOverlay.Controls.Add(this.label26);
            this.GbxOverlay.Controls.Add(this.label27);
            this.GbxOverlay.Controls.Add(this.label24);
            this.GbxOverlay.Controls.Add(this.label23);
            this.GbxOverlay.Controls.Add(this.label22);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraZ);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraY);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraX);
            this.GbxOverlay.Controls.Add(this.CbxOverlayCameraMatchGame);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraRoll);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraYaw);
            this.GbxOverlay.Controls.Add(this.NudOverlayCameraPitch);
            this.GbxOverlay.Controls.Add(this.BtnReadPois);
            this.GbxOverlay.Controls.Add(this.CbxEnableOverlay);
            this.GbxOverlay.Controls.Add(this.CbxEnableOverlayCameraReporting);
            this.GbxOverlay.Controls.Add(this.label2);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamRoll);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamYaw);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPitch);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionZ);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionY);
            this.GbxOverlay.Controls.Add(this.LblOverlayCamPositionX);
            this.GbxOverlay.Location = new System.Drawing.Point(350, 344);
            this.GbxOverlay.Name = "GbxOverlay";
            this.GbxOverlay.Size = new System.Drawing.Size(396, 376);
            this.GbxOverlay.TabIndex = 15;
            this.GbxOverlay.TabStop = false;
            this.GbxOverlay.Text = "Overlay camera";
            // 
            // RdoOverlayAxisColorsOff
            // 
            this.RdoOverlayAxisColorsOff.AutoSize = true;
            this.RdoOverlayAxisColorsOff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsOff.Location = new System.Drawing.Point(351, 158);
            this.RdoOverlayAxisColorsOff.Name = "RdoOverlayAxisColorsOff";
            this.RdoOverlayAxisColorsOff.Size = new System.Drawing.Size(39, 17);
            this.RdoOverlayAxisColorsOff.TabIndex = 58;
            this.RdoOverlayAxisColorsOff.TabStop = true;
            this.RdoOverlayAxisColorsOff.Text = "Off";
            this.RdoOverlayAxisColorsOff.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsOff.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(282, 142);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(108, 13);
            this.label44.TabIndex = 57;
            this.label44.Text = "Positive axis coloring:";
            this.toolTip1.SetToolTip(this.label44, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // RdoOverlayAxisColorsOverlay
            // 
            this.RdoOverlayAxisColorsOverlay.AutoSize = true;
            this.RdoOverlayAxisColorsOverlay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsOverlay.Location = new System.Drawing.Point(284, 158);
            this.RdoOverlayAxisColorsOverlay.Name = "RdoOverlayAxisColorsOverlay";
            this.RdoOverlayAxisColorsOverlay.Size = new System.Drawing.Size(61, 17);
            this.RdoOverlayAxisColorsOverlay.TabIndex = 56;
            this.RdoOverlayAxisColorsOverlay.TabStop = true;
            this.RdoOverlayAxisColorsOverlay.Text = "Overlay";
            this.toolTip1.SetToolTip(this.RdoOverlayAxisColorsOverlay, "X east, Y up, Z south");
            this.RdoOverlayAxisColorsOverlay.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsOverlay.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // RdoOverlayAxisColorsGame
            // 
            this.RdoOverlayAxisColorsGame.AutoSize = true;
            this.RdoOverlayAxisColorsGame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsGame.Checked = true;
            this.RdoOverlayAxisColorsGame.Location = new System.Drawing.Point(225, 158);
            this.RdoOverlayAxisColorsGame.Name = "RdoOverlayAxisColorsGame";
            this.RdoOverlayAxisColorsGame.Size = new System.Drawing.Size(53, 17);
            this.RdoOverlayAxisColorsGame.TabIndex = 55;
            this.RdoOverlayAxisColorsGame.TabStop = true;
            this.RdoOverlayAxisColorsGame.Text = "Game";
            this.toolTip1.SetToolTip(this.RdoOverlayAxisColorsGame, "X east, Y down, Z north");
            this.RdoOverlayAxisColorsGame.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsGame.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // LblPoiCount1
            // 
            this.LblPoiCount1.AutoSize = true;
            this.LblPoiCount1.Location = new System.Drawing.Point(90, 294);
            this.LblPoiCount1.Name = "LblPoiCount1";
            this.LblPoiCount1.Size = new System.Drawing.Size(13, 13);
            this.LblPoiCount1.TabIndex = 54;
            this.LblPoiCount1.Text = "0";
            // 
            // CmbRenderMode
            // 
            this.CmbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRenderMode.FormattingEnabled = true;
            this.CmbRenderMode.Items.AddRange(new object[] {
            "Wireframe",
            "Solid",
            "Points"});
            this.CmbRenderMode.Location = new System.Drawing.Point(9, 215);
            this.CmbRenderMode.Name = "CmbRenderMode";
            this.CmbRenderMode.Size = new System.Drawing.Size(121, 21);
            this.CmbRenderMode.TabIndex = 53;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(309, 294);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 13);
            this.label28.TabIndex = 52;
            this.label28.Text = "Z:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(309, 268);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 13);
            this.label29.TabIndex = 51;
            this.label29.Text = "Y:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(309, 242);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 13);
            this.label30.TabIndex = 50;
            this.label30.Text = "X:";
            // 
            // NudOverlayTestBoxZ
            // 
            this.NudOverlayTestBoxZ.Location = new System.Drawing.Point(332, 292);
            this.NudOverlayTestBoxZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayTestBoxZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxZ.Name = "NudOverlayTestBoxZ";
            this.NudOverlayTestBoxZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxZ.TabIndex = 49;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxZ_ValueChanged);
            // 
            // NudOverlayTestBoxY
            // 
            this.NudOverlayTestBoxY.Location = new System.Drawing.Point(332, 266);
            this.NudOverlayTestBoxY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayTestBoxY.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxY.Name = "NudOverlayTestBoxY";
            this.NudOverlayTestBoxY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxY.TabIndex = 48;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxY_ValueChanged);
            // 
            // NudOverlayTestBoxX
            // 
            this.NudOverlayTestBoxX.Location = new System.Drawing.Point(332, 240);
            this.NudOverlayTestBoxX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayTestBoxX.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxX.Name = "NudOverlayTestBoxX";
            this.NudOverlayTestBoxX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxX.TabIndex = 47;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxX_ValueChanged);
            // 
            // CbxOverlayTestBox
            // 
            this.CbxOverlayTestBox.AutoSize = true;
            this.CbxOverlayTestBox.Location = new System.Drawing.Point(319, 217);
            this.CbxOverlayTestBox.Name = "CbxOverlayTestBox";
            this.CbxOverlayTestBox.Size = new System.Drawing.Size(67, 17);
            this.CbxOverlayTestBox.TabIndex = 46;
            this.CbxOverlayTestBox.Text = "Test box";
            this.CbxOverlayTestBox.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(213, 91);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "Z:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(213, 65);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 13);
            this.label26.TabIndex = 44;
            this.label26.Text = "Y:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(213, 39);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 13);
            this.label27.TabIndex = 43;
            this.label27.Text = "X:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(296, 91);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "Roll:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(296, 65);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "Yaw:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(296, 39);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 40;
            this.label22.Text = "Pitch:";
            // 
            // NudOverlayCameraZ
            // 
            this.NudOverlayCameraZ.Location = new System.Drawing.Point(236, 89);
            this.NudOverlayCameraZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraZ.Name = "NudOverlayCameraZ";
            this.NudOverlayCameraZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayCameraZ.TabIndex = 39;
            this.toolTip1.SetToolTip(this.NudOverlayCameraZ, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraZ.ValueChanged += new System.EventHandler(this.NudOverlayCameraZ_ValueChanged);
            // 
            // NudOverlayCameraY
            // 
            this.NudOverlayCameraY.Location = new System.Drawing.Point(236, 63);
            this.NudOverlayCameraY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraY.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraY.Name = "NudOverlayCameraY";
            this.NudOverlayCameraY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayCameraY.TabIndex = 38;
            this.toolTip1.SetToolTip(this.NudOverlayCameraY, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraY.ValueChanged += new System.EventHandler(this.NudOverlayCameraY_ValueChanged);
            // 
            // NudOverlayCameraX
            // 
            this.NudOverlayCameraX.Location = new System.Drawing.Point(236, 37);
            this.NudOverlayCameraX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraX.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraX.Name = "NudOverlayCameraX";
            this.NudOverlayCameraX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayCameraX.TabIndex = 37;
            this.toolTip1.SetToolTip(this.NudOverlayCameraX, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraX.ValueChanged += new System.EventHandler(this.NudOverlayCameraX_ValueChanged);
            // 
            // CbxOverlayCameraMatchGame
            // 
            this.CbxOverlayCameraMatchGame.AutoSize = true;
            this.CbxOverlayCameraMatchGame.Checked = true;
            this.CbxOverlayCameraMatchGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxOverlayCameraMatchGame.Location = new System.Drawing.Point(262, 14);
            this.CbxOverlayCameraMatchGame.Name = "CbxOverlayCameraMatchGame";
            this.CbxOverlayCameraMatchGame.Size = new System.Drawing.Size(123, 17);
            this.CbxOverlayCameraMatchGame.TabIndex = 36;
            this.CbxOverlayCameraMatchGame.Text = "Match game camera";
            this.CbxOverlayCameraMatchGame.UseVisualStyleBackColor = true;
            this.CbxOverlayCameraMatchGame.CheckedChanged += new System.EventHandler(this.CbxOverlayCameraMatchGame_CheckedChanged);
            // 
            // NudOverlayCameraRoll
            // 
            this.NudOverlayCameraRoll.Location = new System.Drawing.Point(333, 89);
            this.NudOverlayCameraRoll.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraRoll.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraRoll.Name = "NudOverlayCameraRoll";
            this.NudOverlayCameraRoll.Size = new System.Drawing.Size(52, 20);
            this.NudOverlayCameraRoll.TabIndex = 35;
            this.NudOverlayCameraRoll.ValueChanged += new System.EventHandler(this.NudOverlayCameraRoll_ValueChanged);
            // 
            // NudOverlayCameraYaw
            // 
            this.NudOverlayCameraYaw.Location = new System.Drawing.Point(333, 63);
            this.NudOverlayCameraYaw.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraYaw.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraYaw.Name = "NudOverlayCameraYaw";
            this.NudOverlayCameraYaw.Size = new System.Drawing.Size(52, 20);
            this.NudOverlayCameraYaw.TabIndex = 34;
            this.NudOverlayCameraYaw.ValueChanged += new System.EventHandler(this.NudOverlayCameraYaw_ValueChanged);
            // 
            // NudOverlayCameraPitch
            // 
            this.NudOverlayCameraPitch.Location = new System.Drawing.Point(333, 37);
            this.NudOverlayCameraPitch.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.NudOverlayCameraPitch.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraPitch.Name = "NudOverlayCameraPitch";
            this.NudOverlayCameraPitch.Size = new System.Drawing.Size(52, 20);
            this.NudOverlayCameraPitch.TabIndex = 33;
            this.NudOverlayCameraPitch.ValueChanged += new System.EventHandler(this.NudOverlayCameraPitch_ValueChanged);
            // 
            // BtnReadPois
            // 
            this.BtnReadPois.Location = new System.Drawing.Point(9, 289);
            this.BtnReadPois.Name = "BtnReadPois";
            this.BtnReadPois.Size = new System.Drawing.Size(75, 23);
            this.BtnReadPois.TabIndex = 16;
            this.BtnReadPois.Text = "Read POIs";
            this.BtnReadPois.UseVisualStyleBackColor = true;
            this.BtnReadPois.Click += new System.EventHandler(this.BtnReadPois_Click);
            // 
            // CbxEnableOverlay
            // 
            this.CbxEnableOverlay.AutoSize = true;
            this.CbxEnableOverlay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableOverlay.Location = new System.Drawing.Point(331, 353);
            this.CbxEnableOverlay.Name = "CbxEnableOverlay";
            this.CbxEnableOverlay.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableOverlay.TabIndex = 15;
            this.CbxEnableOverlay.Text = "Enable";
            this.CbxEnableOverlay.UseVisualStyleBackColor = true;
            this.CbxEnableOverlay.CheckedChanged += new System.EventHandler(this.CbxEnableTriggerDisplay_CheckedChanged);
            // 
            // CbxEnableOverlayCameraReporting
            // 
            this.CbxEnableOverlayCameraReporting.AutoSize = true;
            this.CbxEnableOverlayCameraReporting.Location = new System.Drawing.Point(11, 170);
            this.CbxEnableOverlayCameraReporting.Name = "CbxEnableOverlayCameraReporting";
            this.CbxEnableOverlayCameraReporting.Size = new System.Drawing.Size(100, 17);
            this.CbxEnableOverlayCameraReporting.TabIndex = 14;
            this.CbxEnableOverlayCameraReporting.Text = "Enable updates";
            this.CbxEnableOverlayCameraReporting.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "X east, Y up, Z south";
            this.toolTip1.SetToolTip(this.label2, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblOverlayCamRoll
            // 
            this.LblOverlayCamRoll.AutoSize = true;
            this.LblOverlayCamRoll.Location = new System.Drawing.Point(8, 142);
            this.LblOverlayCamRoll.Name = "LblOverlayCamRoll";
            this.LblOverlayCamRoll.Size = new System.Drawing.Size(107, 13);
            this.LblOverlayCamRoll.TabIndex = 11;
            this.LblOverlayCamRoll.Text = "<overlay camera roll>";
            // 
            // LblOverlayCamYaw
            // 
            this.LblOverlayCamYaw.AutoSize = true;
            this.LblOverlayCamYaw.Location = new System.Drawing.Point(8, 125);
            this.LblOverlayCamYaw.Name = "LblOverlayCamYaw";
            this.LblOverlayCamYaw.Size = new System.Drawing.Size(113, 13);
            this.LblOverlayCamYaw.TabIndex = 10;
            this.LblOverlayCamYaw.Text = "<overlay camera yaw>";
            // 
            // LblOverlayCamPitch
            // 
            this.LblOverlayCamPitch.AutoSize = true;
            this.LblOverlayCamPitch.Location = new System.Drawing.Point(8, 108);
            this.LblOverlayCamPitch.Name = "LblOverlayCamPitch";
            this.LblOverlayCamPitch.Size = new System.Drawing.Size(117, 13);
            this.LblOverlayCamPitch.TabIndex = 9;
            this.LblOverlayCamPitch.Text = "<overlay camera pitch>";
            // 
            // LblOverlayCamPositionZ
            // 
            this.LblOverlayCamPositionZ.AutoSize = true;
            this.LblOverlayCamPositionZ.Location = new System.Drawing.Point(8, 77);
            this.LblOverlayCamPositionZ.Name = "LblOverlayCamPositionZ";
            this.LblOverlayCamPositionZ.Size = new System.Drawing.Size(99, 13);
            this.LblOverlayCamPositionZ.TabIndex = 8;
            this.LblOverlayCamPositionZ.Text = "<overlay camera z>";
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionZ, "The overlay camera\'s position in overlay coordinates");
            // 
            // LblOverlayCamPositionY
            // 
            this.LblOverlayCamPositionY.AutoSize = true;
            this.LblOverlayCamPositionY.Location = new System.Drawing.Point(8, 60);
            this.LblOverlayCamPositionY.Name = "LblOverlayCamPositionY";
            this.LblOverlayCamPositionY.Size = new System.Drawing.Size(99, 13);
            this.LblOverlayCamPositionY.TabIndex = 7;
            this.LblOverlayCamPositionY.Text = "<overlay camera y>";
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionY, "The overlay camera\'s position in overlay coordinates");
            // 
            // LblOverlayCamPositionX
            // 
            this.LblOverlayCamPositionX.AutoSize = true;
            this.LblOverlayCamPositionX.Location = new System.Drawing.Point(8, 43);
            this.LblOverlayCamPositionX.Name = "LblOverlayCamPositionX";
            this.LblOverlayCamPositionX.Size = new System.Drawing.Size(99, 13);
            this.LblOverlayCamPositionX.TabIndex = 6;
            this.LblOverlayCamPositionX.Text = "<overlay camera x>";
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionX, "The overlay camera\'s position in overlay coordinates");
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.CbxTriggersAutoUpdate);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.LblTriggerCount);
            this.tabPage5.Controls.Add(this.BtnReadTriggers);
            this.tabPage5.Controls.Add(this.LbxTriggers);
            this.tabPage5.Controls.Add(this.LblPoiCount2);
            this.tabPage5.Controls.Add(this.BtnReadPois2);
            this.tabPage5.Controls.Add(this.LbxPois);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(752, 726);
            this.tabPage5.TabIndex = 8;
            this.tabPage5.Text = "POIs";
            this.toolTip1.SetToolTip(this.tabPage5, "Points of interest");
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // CbxTriggersAutoUpdate
            // 
            this.CbxTriggersAutoUpdate.AutoSize = true;
            this.CbxTriggersAutoUpdate.Location = new System.Drawing.Point(332, 10);
            this.CbxTriggersAutoUpdate.Name = "CbxTriggersAutoUpdate";
            this.CbxTriggersAutoUpdate.Size = new System.Drawing.Size(48, 17);
            this.CbxTriggersAutoUpdate.TabIndex = 74;
            this.CbxTriggersAutoUpdate.Text = "Auto";
            this.CbxTriggersAutoUpdate.UseVisualStyleBackColor = true;
            this.CbxTriggersAutoUpdate.CheckedChanged += new System.EventHandler(this.CbxTriggersAutoUpdate_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CbxSelectedTriggerDisabled);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerFiredDetails);
            this.groupBox2.Controls.Add(this.CbxSelectedTriggerEnableUpdates);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerSomeIndex);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.label46);
            this.groupBox2.Controls.Add(this.CmbSelectedTriggerType);
            this.groupBox2.Controls.Add(this.NudSelectedTriggerTargetIndex);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerAddress);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerTypeInfo);
            this.groupBox2.Controls.Add(this.label40);
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerThing4);
            this.groupBox2.Controls.Add(this.label49);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerThing3);
            this.groupBox2.Controls.Add(this.label47);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerPoiIndex);
            this.groupBox2.Controls.Add(this.label45);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerStyle);
            this.groupBox2.Controls.Add(this.label43);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerFired);
            this.groupBox2.Controls.Add(this.label41);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerThing1);
            this.groupBox2.Controls.Add(this.label39);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerThing0);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Location = new System.Drawing.Point(386, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 309);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trigger";
            // 
            // CbxSelectedTriggerDisabled
            // 
            this.CbxSelectedTriggerDisabled.AutoSize = true;
            this.CbxSelectedTriggerDisabled.Location = new System.Drawing.Point(9, 32);
            this.CbxSelectedTriggerDisabled.Name = "CbxSelectedTriggerDisabled";
            this.CbxSelectedTriggerDisabled.Size = new System.Drawing.Size(67, 17);
            this.CbxSelectedTriggerDisabled.TabIndex = 91;
            this.CbxSelectedTriggerDisabled.Text = "Disabled";
            this.CbxSelectedTriggerDisabled.UseVisualStyleBackColor = true;
            this.CbxSelectedTriggerDisabled.CheckedChanged += new System.EventHandler(this.CbxSelectedTriggerEnabled_CheckedChanged);
            // 
            // LblSelectedTriggerFiredDetails
            // 
            this.LblSelectedTriggerFiredDetails.AutoSize = true;
            this.LblSelectedTriggerFiredDetails.Location = new System.Drawing.Point(115, 179);
            this.LblSelectedTriggerFiredDetails.Name = "LblSelectedTriggerFiredDetails";
            this.LblSelectedTriggerFiredDetails.Size = new System.Drawing.Size(154, 13);
            this.LblSelectedTriggerFiredDetails.TabIndex = 89;
            this.LblSelectedTriggerFiredDetails.Text = "(Group address 0x?? , bit 0x??)";
            this.LblSelectedTriggerFiredDetails.Click += new System.EventHandler(this.LblSelectedTriggerFiredDetails_Click);
            // 
            // CbxSelectedTriggerEnableUpdates
            // 
            this.CbxSelectedTriggerEnableUpdates.AutoSize = true;
            this.CbxSelectedTriggerEnableUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxSelectedTriggerEnableUpdates.Checked = true;
            this.CbxSelectedTriggerEnableUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxSelectedTriggerEnableUpdates.Location = new System.Drawing.Point(254, 15);
            this.CbxSelectedTriggerEnableUpdates.Name = "CbxSelectedTriggerEnableUpdates";
            this.CbxSelectedTriggerEnableUpdates.Size = new System.Drawing.Size(100, 17);
            this.CbxSelectedTriggerEnableUpdates.TabIndex = 88;
            this.CbxSelectedTriggerEnableUpdates.Text = "Enable updates";
            this.CbxSelectedTriggerEnableUpdates.UseVisualStyleBackColor = true;
            // 
            // LblSelectedTriggerSomeIndex
            // 
            this.LblSelectedTriggerSomeIndex.AutoSize = true;
            this.LblSelectedTriggerSomeIndex.Location = new System.Drawing.Point(70, 199);
            this.LblSelectedTriggerSomeIndex.Name = "LblSelectedTriggerSomeIndex";
            this.LblSelectedTriggerSomeIndex.Size = new System.Drawing.Size(70, 13);
            this.LblSelectedTriggerSomeIndex.TabIndex = 86;
            this.LblSelectedTriggerSomeIndex.Text = "<someIndex>";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(6, 199);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(63, 13);
            this.label50.TabIndex = 87;
            this.label50.Text = "SomeIndex:";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(222, 259);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(34, 13);
            this.label46.TabIndex = 85;
            this.label46.Text = "Type:";
            // 
            // CmbSelectedTriggerType
            // 
            this.CmbSelectedTriggerType.Enabled = false;
            this.CmbSelectedTriggerType.FormattingEnabled = true;
            this.CmbSelectedTriggerType.Location = new System.Drawing.Point(262, 256);
            this.CmbSelectedTriggerType.Name = "CmbSelectedTriggerType";
            this.CmbSelectedTriggerType.Size = new System.Drawing.Size(92, 21);
            this.CmbSelectedTriggerType.TabIndex = 84;
            // 
            // NudSelectedTriggerTargetIndex
            // 
            this.NudSelectedTriggerTargetIndex.Enabled = false;
            this.NudSelectedTriggerTargetIndex.Location = new System.Drawing.Point(297, 283);
            this.NudSelectedTriggerTargetIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudSelectedTriggerTargetIndex.Name = "NudSelectedTriggerTargetIndex";
            this.NudSelectedTriggerTargetIndex.Size = new System.Drawing.Size(57, 20);
            this.NudSelectedTriggerTargetIndex.TabIndex = 83;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(222, 286);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 13);
            this.label42.TabIndex = 82;
            this.label42.Text = "Target index:";
            // 
            // LblSelectedTriggerAddress
            // 
            this.LblSelectedTriggerAddress.AutoSize = true;
            this.LblSelectedTriggerAddress.Location = new System.Drawing.Point(60, 16);
            this.LblSelectedTriggerAddress.Name = "LblSelectedTriggerAddress";
            this.LblSelectedTriggerAddress.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedTriggerAddress.TabIndex = 72;
            this.LblSelectedTriggerAddress.Text = "<address>";
            this.LblSelectedTriggerAddress.Click += new System.EventHandler(this.LblSelectedTriggerAddress_Click);
            // 
            // LblSelectedTriggerTypeInfo
            // 
            this.LblSelectedTriggerTypeInfo.AutoSize = true;
            this.LblSelectedTriggerTypeInfo.Location = new System.Drawing.Point(280, 233);
            this.LblSelectedTriggerTypeInfo.Name = "LblSelectedTriggerTypeInfo";
            this.LblSelectedTriggerTypeInfo.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedTriggerTypeInfo.TabIndex = 77;
            this.LblSelectedTriggerTypeInfo.Text = "<typeinfo>";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 16);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 13);
            this.label40.TabIndex = 71;
            this.label40.Text = "Address:";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(222, 233);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(52, 13);
            this.label51.TabIndex = 78;
            this.label51.Text = "TypeInfo:";
            // 
            // LblSelectedTriggerThing4
            // 
            this.LblSelectedTriggerThing4.AutoSize = true;
            this.LblSelectedTriggerThing4.Location = new System.Drawing.Point(71, 279);
            this.LblSelectedTriggerThing4.Name = "LblSelectedTriggerThing4";
            this.LblSelectedTriggerThing4.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing4.TabIndex = 75;
            this.LblSelectedTriggerThing4.Text = "<thing4>";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 279);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(43, 13);
            this.label49.TabIndex = 76;
            this.label49.Text = "Thing4:";
            // 
            // LblSelectedTriggerThing3
            // 
            this.LblSelectedTriggerThing3.AutoSize = true;
            this.LblSelectedTriggerThing3.Location = new System.Drawing.Point(71, 259);
            this.LblSelectedTriggerThing3.Name = "LblSelectedTriggerThing3";
            this.LblSelectedTriggerThing3.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing3.TabIndex = 73;
            this.LblSelectedTriggerThing3.Text = "<thing3>";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 259);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(43, 13);
            this.label47.TabIndex = 74;
            this.label47.Text = "Thing3:";
            // 
            // LblSelectedTriggerPoiIndex
            // 
            this.LblSelectedTriggerPoiIndex.AutoSize = true;
            this.LblSelectedTriggerPoiIndex.Location = new System.Drawing.Point(71, 239);
            this.LblSelectedTriggerPoiIndex.Name = "LblSelectedTriggerPoiIndex";
            this.LblSelectedTriggerPoiIndex.Size = new System.Drawing.Size(58, 13);
            this.LblSelectedTriggerPoiIndex.TabIndex = 71;
            this.LblSelectedTriggerPoiIndex.Text = "<poiindex>";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 239);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(51, 13);
            this.label45.TabIndex = 72;
            this.label45.Text = "PoiIndex:";
            // 
            // LblSelectedTriggerStyle
            // 
            this.LblSelectedTriggerStyle.AutoSize = true;
            this.LblSelectedTriggerStyle.Location = new System.Drawing.Point(71, 219);
            this.LblSelectedTriggerStyle.Name = "LblSelectedTriggerStyle";
            this.LblSelectedTriggerStyle.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedTriggerStyle.TabIndex = 69;
            this.LblSelectedTriggerStyle.Text = "<style>";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 219);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 13);
            this.label43.TabIndex = 70;
            this.label43.Text = "Style:";
            // 
            // LblSelectedTriggerFired
            // 
            this.LblSelectedTriggerFired.AutoSize = true;
            this.LblSelectedTriggerFired.Location = new System.Drawing.Point(70, 179);
            this.LblSelectedTriggerFired.Name = "LblSelectedTriggerFired";
            this.LblSelectedTriggerFired.Size = new System.Drawing.Size(39, 13);
            this.LblSelectedTriggerFired.TabIndex = 67;
            this.LblSelectedTriggerFired.Text = "<fired>";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(6, 179);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(33, 13);
            this.label41.TabIndex = 68;
            this.label41.Text = "Fired:";
            // 
            // LblSelectedTriggerThing1
            // 
            this.LblSelectedTriggerThing1.AutoSize = true;
            this.LblSelectedTriggerThing1.Location = new System.Drawing.Point(71, 159);
            this.LblSelectedTriggerThing1.Name = "LblSelectedTriggerThing1";
            this.LblSelectedTriggerThing1.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing1.TabIndex = 65;
            this.LblSelectedTriggerThing1.Text = "<thing1>";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 159);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(43, 13);
            this.label39.TabIndex = 66;
            this.label39.Text = "Thing1:";
            // 
            // LblSelectedTriggerThing0
            // 
            this.LblSelectedTriggerThing0.AutoSize = true;
            this.LblSelectedTriggerThing0.Location = new System.Drawing.Point(70, 139);
            this.LblSelectedTriggerThing0.Name = "LblSelectedTriggerThing0";
            this.LblSelectedTriggerThing0.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing0.TabIndex = 63;
            this.LblSelectedTriggerThing0.Text = "<thing0>";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 139);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 64;
            this.label32.Text = "Thing0:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnGoToPoi);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.LbxPoiAssociatedTriggers);
            this.groupBox1.Controls.Add(this.LblSelectedPoiAddress);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.LblSelectedPoiThing0);
            this.groupBox1.Controls.Add(this.LblSelectedPoiX);
            this.groupBox1.Controls.Add(this.LblSelectedPoiZ);
            this.groupBox1.Controls.Add(this.LblSelectedPoiThing2);
            this.groupBox1.Controls.Add(this.label37);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.LblSelectedPoiThing1);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.LblSelectedPoiYaw);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Location = new System.Drawing.Point(386, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 365);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "POI";
            // 
            // BtnGoToPoi
            // 
            this.BtnGoToPoi.Location = new System.Drawing.Point(200, 43);
            this.BtnGoToPoi.Name = "BtnGoToPoi";
            this.BtnGoToPoi.Size = new System.Drawing.Size(75, 23);
            this.BtnGoToPoi.TabIndex = 76;
            this.BtnGoToPoi.Text = "Go";
            this.BtnGoToPoi.UseVisualStyleBackColor = true;
            this.BtnGoToPoi.Click += new System.EventHandler(this.BtnGoToPoi_Click);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(3, 207);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 13);
            this.label33.TabIndex = 75;
            this.label33.Text = "Associated triggers:";
            // 
            // LbxPoiAssociatedTriggers
            // 
            this.LbxPoiAssociatedTriggers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxPoiAssociatedTriggers.FormattingEnabled = true;
            this.LbxPoiAssociatedTriggers.Location = new System.Drawing.Point(6, 223);
            this.LbxPoiAssociatedTriggers.Name = "LbxPoiAssociatedTriggers";
            this.LbxPoiAssociatedTriggers.Size = new System.Drawing.Size(348, 134);
            this.LbxPoiAssociatedTriggers.TabIndex = 74;
            this.LbxPoiAssociatedTriggers.SelectedIndexChanged += new System.EventHandler(this.LbxPoiAssociatedTriggers_SelectedIndexChanged);
            this.LbxPoiAssociatedTriggers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxTriggers_Format);
            // 
            // LblSelectedPoiAddress
            // 
            this.LblSelectedPoiAddress.AutoSize = true;
            this.LblSelectedPoiAddress.Location = new System.Drawing.Point(60, 16);
            this.LblSelectedPoiAddress.Name = "LblSelectedPoiAddress";
            this.LblSelectedPoiAddress.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedPoiAddress.TabIndex = 70;
            this.LblSelectedPoiAddress.Text = "<address>";
            this.LblSelectedPoiAddress.Click += new System.EventHandler(this.LblSelectedPoiAddress_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(6, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Address:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(6, 48);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(95, 13);
            this.label38.TabIndex = 57;
            this.label38.Text = "Selected point XZ:";
            // 
            // LblSelectedPoiThing0
            // 
            this.LblSelectedPoiThing0.AutoSize = true;
            this.LblSelectedPoiThing0.Location = new System.Drawing.Point(71, 93);
            this.LblSelectedPoiThing0.Name = "LblSelectedPoiThing0";
            this.LblSelectedPoiThing0.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedPoiThing0.TabIndex = 59;
            this.LblSelectedPoiThing0.Text = "<thing0>";
            // 
            // LblSelectedPoiX
            // 
            this.LblSelectedPoiX.AutoSize = true;
            this.LblSelectedPoiX.Location = new System.Drawing.Point(107, 48);
            this.LblSelectedPoiX.Name = "LblSelectedPoiX";
            this.LblSelectedPoiX.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedPoiX.TabIndex = 58;
            this.LblSelectedPoiX.Text = "???.??";
            // 
            // LblSelectedPoiZ
            // 
            this.LblSelectedPoiZ.AutoSize = true;
            this.LblSelectedPoiZ.Location = new System.Drawing.Point(153, 48);
            this.LblSelectedPoiZ.Name = "LblSelectedPoiZ";
            this.LblSelectedPoiZ.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedPoiZ.TabIndex = 60;
            this.LblSelectedPoiZ.Text = "???.??";
            // 
            // LblSelectedPoiThing2
            // 
            this.LblSelectedPoiThing2.AutoSize = true;
            this.LblSelectedPoiThing2.Location = new System.Drawing.Point(71, 165);
            this.LblSelectedPoiThing2.Name = "LblSelectedPoiThing2";
            this.LblSelectedPoiThing2.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedPoiThing2.TabIndex = 68;
            this.LblSelectedPoiThing2.Text = "<thing2>";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(6, 70);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(98, 13);
            this.label37.TabIndex = 61;
            this.label37.Text = "Selected point info:";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(22, 165);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(43, 13);
            this.label31.TabIndex = 67;
            this.label31.Text = "Thing2:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(22, 93);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(43, 13);
            this.label36.TabIndex = 62;
            this.label36.Text = "Thing0:";
            // 
            // LblSelectedPoiThing1
            // 
            this.LblSelectedPoiThing1.AutoSize = true;
            this.LblSelectedPoiThing1.Location = new System.Drawing.Point(70, 117);
            this.LblSelectedPoiThing1.Name = "LblSelectedPoiThing1";
            this.LblSelectedPoiThing1.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedPoiThing1.TabIndex = 66;
            this.LblSelectedPoiThing1.Text = "<thing1>";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(22, 141);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(31, 13);
            this.label35.TabIndex = 63;
            this.label35.Text = "Yaw:";
            // 
            // LblSelectedPoiYaw
            // 
            this.LblSelectedPoiYaw.AutoSize = true;
            this.LblSelectedPoiYaw.Location = new System.Drawing.Point(71, 141);
            this.LblSelectedPoiYaw.Name = "LblSelectedPoiYaw";
            this.LblSelectedPoiYaw.Size = new System.Drawing.Size(38, 13);
            this.LblSelectedPoiYaw.TabIndex = 65;
            this.LblSelectedPoiYaw.Text = "<yaw>";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(22, 117);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(43, 13);
            this.label34.TabIndex = 64;
            this.label34.Text = "Thing1:";
            // 
            // LblTriggerCount
            // 
            this.LblTriggerCount.AutoSize = true;
            this.LblTriggerCount.Location = new System.Drawing.Point(292, 11);
            this.LblTriggerCount.Name = "LblTriggerCount";
            this.LblTriggerCount.Size = new System.Drawing.Size(13, 13);
            this.LblTriggerCount.TabIndex = 71;
            this.LblTriggerCount.Text = "0";
            // 
            // BtnReadTriggers
            // 
            this.BtnReadTriggers.Location = new System.Drawing.Point(196, 6);
            this.BtnReadTriggers.Name = "BtnReadTriggers";
            this.BtnReadTriggers.Size = new System.Drawing.Size(90, 23);
            this.BtnReadTriggers.TabIndex = 70;
            this.BtnReadTriggers.Text = "Read triggers";
            this.BtnReadTriggers.UseVisualStyleBackColor = true;
            this.BtnReadTriggers.Click += new System.EventHandler(this.BtnReadTriggers_Click);
            // 
            // LbxTriggers
            // 
            this.LbxTriggers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxTriggers.FormattingEnabled = true;
            this.LbxTriggers.Location = new System.Drawing.Point(196, 32);
            this.LbxTriggers.Name = "LbxTriggers";
            this.LbxTriggers.Size = new System.Drawing.Size(184, 680);
            this.LbxTriggers.TabIndex = 69;
            this.LbxTriggers.SelectedIndexChanged += new System.EventHandler(this.LbxTriggers_SelectedIndexChanged);
            this.LbxTriggers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxTriggers_Format);
            // 
            // LblPoiCount2
            // 
            this.LblPoiCount2.AutoSize = true;
            this.LblPoiCount2.Location = new System.Drawing.Point(87, 11);
            this.LblPoiCount2.Name = "LblPoiCount2";
            this.LblPoiCount2.Size = new System.Drawing.Size(13, 13);
            this.LblPoiCount2.TabIndex = 56;
            this.LblPoiCount2.Text = "0";
            // 
            // BtnReadPois2
            // 
            this.BtnReadPois2.Location = new System.Drawing.Point(6, 6);
            this.BtnReadPois2.Name = "BtnReadPois2";
            this.BtnReadPois2.Size = new System.Drawing.Size(75, 23);
            this.BtnReadPois2.TabIndex = 55;
            this.BtnReadPois2.Text = "Read POIs";
            this.BtnReadPois2.UseVisualStyleBackColor = true;
            this.BtnReadPois2.Click += new System.EventHandler(this.BtnReadPois_Click);
            // 
            // LbxPois
            // 
            this.LbxPois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxPois.FormattingEnabled = true;
            this.LbxPois.Location = new System.Drawing.Point(6, 32);
            this.LbxPois.Name = "LbxPois";
            this.LbxPois.Size = new System.Drawing.Size(184, 680);
            this.LbxPois.TabIndex = 0;
            this.LbxPois.SelectedIndexChanged += new System.EventHandler(this.LbxPois_SelectedIndexChanged);
            this.LbxPois.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxPois_Format);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.LblTotalTime);
            this.tabPage2.Controls.Add(this.label52);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.LblHarryHealth);
            this.tabPage2.Controls.Add(this.CbxStats);
            this.tabPage2.Controls.Add(this.LblRunningDistance);
            this.tabPage2.Controls.Add(this.LblWalkingDistance);
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
            // LblTotalTime
            // 
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.Location = new System.Drawing.Point(98, 53);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(62, 13);
            this.LblTotalTime.TabIndex = 23;
            this.LblTotalTime.Text = "<totalTime>";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(3, 53);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 13);
            this.label52.TabIndex = 22;
            this.label52.Text = "Total time:";
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
            this.CbxStats.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxStats.Checked = true;
            this.CbxStats.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxStats.Location = new System.Drawing.Point(687, 703);
            this.CbxStats.Name = "CbxStats";
            this.CbxStats.Size = new System.Drawing.Size(59, 17);
            this.CbxStats.TabIndex = 4;
            this.CbxStats.Text = "Enable";
            this.CbxStats.UseVisualStyleBackColor = true;
            // 
            // LblRunningDistance
            // 
            this.LblRunningDistance.AutoSize = true;
            this.LblRunningDistance.Location = new System.Drawing.Point(98, 79);
            this.LblRunningDistance.Name = "LblRunningDistance";
            this.LblRunningDistance.Size = new System.Drawing.Size(34, 13);
            this.LblRunningDistance.TabIndex = 3;
            this.LblRunningDistance.Text = "<run>";
            // 
            // LblWalkingDistance
            // 
            this.LblWalkingDistance.AutoSize = true;
            this.LblWalkingDistance.Location = new System.Drawing.Point(98, 66);
            this.LblWalkingDistance.Name = "LblWalkingDistance";
            this.LblWalkingDistance.Size = new System.Drawing.Size(53, 13);
            this.LblWalkingDistance.TabIndex = 2;
            this.LblWalkingDistance.Text = "<walked>";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Running distance:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Walking distance:";
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
            // TbpModel
            // 
            this.TbpModel.Controls.Add(this.CbxEnableModelDisplay);
            this.TbpModel.Controls.Add(this.CmbModelSubmeshName);
            this.TbpModel.Controls.Add(this.LblModelScale);
            this.TbpModel.Controls.Add(this.TrkModelScale);
            this.TbpModel.Controls.Add(this.BtnReadHarryModel);
            this.TbpModel.Controls.Add(this.NudModelZ);
            this.TbpModel.Controls.Add(this.NudModelY);
            this.TbpModel.Controls.Add(this.NudModelX);
            this.TbpModel.Controls.Add(this.LblModelZ);
            this.TbpModel.Controls.Add(this.BtnModelGetPosition);
            this.TbpModel.Controls.Add(this.BtnModelSetPosition);
            this.TbpModel.Controls.Add(this.LblModelX);
            this.TbpModel.Controls.Add(this.LblModelY);
            this.TbpModel.Location = new System.Drawing.Point(4, 22);
            this.TbpModel.Name = "TbpModel";
            this.TbpModel.Padding = new System.Windows.Forms.Padding(3);
            this.TbpModel.Size = new System.Drawing.Size(752, 726);
            this.TbpModel.TabIndex = 2;
            this.TbpModel.Text = "Model";
            this.TbpModel.UseVisualStyleBackColor = true;
            // 
            // CbxEnableModelDisplay
            // 
            this.CbxEnableModelDisplay.AutoSize = true;
            this.CbxEnableModelDisplay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableModelDisplay.Location = new System.Drawing.Point(687, 703);
            this.CbxEnableModelDisplay.Name = "CbxEnableModelDisplay";
            this.CbxEnableModelDisplay.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableModelDisplay.TabIndex = 35;
            this.CbxEnableModelDisplay.Text = "Enable";
            this.CbxEnableModelDisplay.UseVisualStyleBackColor = true;
            this.CbxEnableModelDisplay.CheckedChanged += new System.EventHandler(this.CbxEnableModelDisplay_CheckedChanged);
            // 
            // CmbModelSubmeshName
            // 
            this.CmbModelSubmeshName.FormattingEnabled = true;
            this.CmbModelSubmeshName.Items.AddRange(new object[] {
            "CHEST_",
            "HEAD1",
            "NECK",
            "LSHOUL",
            "LJOU",
            "LZEN",
            "RSHOUL",
            "RJOU",
            "RZEN",
            "HIP_TC",
            "HIP2_T",
            "LMOMO",
            "LSUNE",
            "LFOOT",
            "RMOMO",
            "RSUNE",
            "RFOOT",
            "LHAND",
            "LHAND2",
            "RHAND",
            "RHAND2",
            "RHAND3",
            "RHAND4",
            "*"});
            this.CmbModelSubmeshName.Location = new System.Drawing.Point(130, 8);
            this.CmbModelSubmeshName.Name = "CmbModelSubmeshName";
            this.CmbModelSubmeshName.Size = new System.Drawing.Size(121, 21);
            this.CmbModelSubmeshName.TabIndex = 34;
            this.CmbModelSubmeshName.Text = "HEAD1";
            // 
            // LblModelScale
            // 
            this.LblModelScale.AutoSize = true;
            this.LblModelScale.Location = new System.Drawing.Point(164, 54);
            this.LblModelScale.Name = "LblModelScale";
            this.LblModelScale.Size = new System.Drawing.Size(31, 13);
            this.LblModelScale.TabIndex = 32;
            this.LblModelScale.Text = "1000";
            this.toolTip1.SetToolTip(this.LblModelScale, "Arbitrary model scale factor");
            // 
            // TrkModelScale
            // 
            this.TrkModelScale.Location = new System.Drawing.Point(6, 70);
            this.TrkModelScale.Maximum = 2000;
            this.TrkModelScale.Minimum = 1;
            this.TrkModelScale.Name = "TrkModelScale";
            this.TrkModelScale.Size = new System.Drawing.Size(346, 45);
            this.TrkModelScale.TabIndex = 31;
            this.toolTip1.SetToolTip(this.TrkModelScale, "Arbitrary model scale factor");
            this.TrkModelScale.Value = 1000;
            this.TrkModelScale.Scroll += new System.EventHandler(this.TrkModelScale_Scroll);
            // 
            // BtnReadHarryModel
            // 
            this.BtnReadHarryModel.Location = new System.Drawing.Point(6, 6);
            this.BtnReadHarryModel.Name = "BtnReadHarryModel";
            this.BtnReadHarryModel.Size = new System.Drawing.Size(118, 23);
            this.BtnReadHarryModel.TabIndex = 30;
            this.BtnReadHarryModel.Text = "Read Harry submesh";
            this.BtnReadHarryModel.UseVisualStyleBackColor = true;
            this.BtnReadHarryModel.Click += new System.EventHandler(this.BtnReadHarryModel_Click);
            // 
            // NudModelZ
            // 
            this.NudModelZ.Location = new System.Drawing.Point(237, 160);
            this.NudModelZ.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudModelZ.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudModelZ.Name = "NudModelZ";
            this.NudModelZ.Size = new System.Drawing.Size(50, 20);
            this.NudModelZ.TabIndex = 29;
            this.NudModelZ.ValueChanged += new System.EventHandler(this.NudModelZ_ValueChanged);
            // 
            // NudModelY
            // 
            this.NudModelY.Location = new System.Drawing.Point(181, 160);
            this.NudModelY.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudModelY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudModelY.Name = "NudModelY";
            this.NudModelY.Size = new System.Drawing.Size(50, 20);
            this.NudModelY.TabIndex = 28;
            this.NudModelY.ValueChanged += new System.EventHandler(this.NudModelY_ValueChanged);
            // 
            // NudModelX
            // 
            this.NudModelX.Location = new System.Drawing.Point(125, 160);
            this.NudModelX.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudModelX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudModelX.Name = "NudModelX";
            this.NudModelX.Size = new System.Drawing.Size(50, 20);
            this.NudModelX.TabIndex = 27;
            this.NudModelX.ValueChanged += new System.EventHandler(this.NudModelX_ValueChanged);
            // 
            // LblModelZ
            // 
            this.LblModelZ.AutoSize = true;
            this.LblModelZ.Location = new System.Drawing.Point(250, 139);
            this.LblModelZ.Name = "LblModelZ";
            this.LblModelZ.Size = new System.Drawing.Size(24, 13);
            this.LblModelZ.TabIndex = 26;
            this.LblModelZ.Text = "<z>";
            // 
            // BtnModelGetPosition
            // 
            this.BtnModelGetPosition.Location = new System.Drawing.Point(6, 157);
            this.BtnModelGetPosition.Name = "BtnModelGetPosition";
            this.BtnModelGetPosition.Size = new System.Drawing.Size(113, 23);
            this.BtnModelGetPosition.TabIndex = 19;
            this.BtnModelGetPosition.Text = "Get Harry position";
            this.BtnModelGetPosition.UseVisualStyleBackColor = true;
            this.BtnModelGetPosition.Click += new System.EventHandler(this.BtnModelGetHarryPosition_Click);
            // 
            // BtnModelSetPosition
            // 
            this.BtnModelSetPosition.Location = new System.Drawing.Point(293, 157);
            this.BtnModelSetPosition.Name = "BtnModelSetPosition";
            this.BtnModelSetPosition.Size = new System.Drawing.Size(113, 23);
            this.BtnModelSetPosition.TabIndex = 20;
            this.BtnModelSetPosition.Text = "Set model position";
            this.BtnModelSetPosition.UseVisualStyleBackColor = true;
            this.BtnModelSetPosition.Click += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            // 
            // LblModelX
            // 
            this.LblModelX.AutoSize = true;
            this.LblModelX.Location = new System.Drawing.Point(138, 139);
            this.LblModelX.Name = "LblModelX";
            this.LblModelX.Size = new System.Drawing.Size(24, 13);
            this.LblModelX.TabIndex = 24;
            this.LblModelX.Text = "<x>";
            // 
            // LblModelY
            // 
            this.LblModelY.AutoSize = true;
            this.LblModelY.Location = new System.Drawing.Point(194, 139);
            this.LblModelY.Name = "LblModelY";
            this.LblModelY.Size = new System.Drawing.Size(24, 13);
            this.LblModelY.TabIndex = 25;
            this.LblModelY.Text = "<y>";
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
            this.tabPage3.Controls.Add(this.BtnFogWorldTintColorSwap);
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
            // BtnFogWorldTintColorSwap
            // 
            this.BtnFogWorldTintColorSwap.Location = new System.Drawing.Point(91, 160);
            this.BtnFogWorldTintColorSwap.Name = "BtnFogWorldTintColorSwap";
            this.BtnFogWorldTintColorSwap.Size = new System.Drawing.Size(238, 23);
            this.BtnFogWorldTintColorSwap.TabIndex = 0;
            this.BtnFogWorldTintColorSwap.Text = "Swap";
            this.BtnFogWorldTintColorSwap.UseVisualStyleBackColor = true;
            this.BtnFogWorldTintColorSwap.Click += new System.EventHandler(this.BtnFogWorldTintColorSwap_Click);
            // 
            // BtnCustomWorldTintCurrent
            // 
            this.BtnCustomWorldTintCurrent.Location = new System.Drawing.Point(244, 102);
            this.BtnCustomWorldTintCurrent.Name = "BtnCustomWorldTintCurrent";
            this.BtnCustomWorldTintCurrent.Size = new System.Drawing.Size(87, 23);
            this.BtnCustomWorldTintCurrent.TabIndex = 20;
            this.BtnCustomWorldTintCurrent.Text = "Current";
            this.BtnCustomWorldTintCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomWorldTintCurrent.Click += new System.EventHandler(this.BtnCustomWorldTintCurrent_Click);
            // 
            // BtnCustomFogCurrent
            // 
            this.BtnCustomFogCurrent.Location = new System.Drawing.Point(91, 102);
            this.BtnCustomFogCurrent.Name = "BtnCustomFogCurrent";
            this.BtnCustomFogCurrent.Size = new System.Drawing.Size(87, 23);
            this.BtnCustomFogCurrent.TabIndex = 19;
            this.BtnCustomFogCurrent.Text = "Current";
            this.BtnCustomFogCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomFogCurrent.Click += new System.EventHandler(this.BtnCustomFogCurrent_Click);
            // 
            // BtnWorldTintDefault
            // 
            this.BtnWorldTintDefault.Location = new System.Drawing.Point(244, 131);
            this.BtnWorldTintDefault.Name = "BtnWorldTintDefault";
            this.BtnWorldTintDefault.Size = new System.Drawing.Size(87, 23);
            this.BtnWorldTintDefault.TabIndex = 18;
            this.BtnWorldTintDefault.Text = "Default";
            this.BtnWorldTintDefault.UseVisualStyleBackColor = true;
            this.BtnWorldTintDefault.Click += new System.EventHandler(this.BtnWorldTintDefault_Click);
            // 
            // BtnFogColorDefault
            // 
            this.BtnFogColorDefault.Location = new System.Drawing.Point(91, 131);
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
            this.NudWorldTintB.Location = new System.Drawing.Point(244, 73);
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
            this.NudWorldTintG.Location = new System.Drawing.Point(244, 47);
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
            this.NudWorldTintR.Location = new System.Drawing.Point(244, 21);
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
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "B:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(221, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "G:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(220, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "R:";
            // 
            // BtnWorldTintColor
            // 
            this.BtnWorldTintColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(128)))), ((int)(((byte)(138)))));
            this.BtnWorldTintColor.Location = new System.Drawing.Point(302, 21);
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
            this.NudFogB.Location = new System.Drawing.Point(91, 73);
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
            this.NudFogG.Location = new System.Drawing.Point(91, 47);
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
            this.NudFogR.Location = new System.Drawing.Point(91, 21);
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
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "B:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "G:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "R:";
            // 
            // BtnFogColor
            // 
            this.BtnFogColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.BtnFogColor.Location = new System.Drawing.Point(149, 21);
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
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.RtbStrings);
            this.tabPage4.Controls.Add(this.LblStringCount);
            this.tabPage4.Controls.Add(this.BtnReadStrings);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(752, 726);
            this.tabPage4.TabIndex = 7;
            this.tabPage4.Text = "Strings";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // RtbStrings
            // 
            this.RtbStrings.Location = new System.Drawing.Point(6, 35);
            this.RtbStrings.Name = "RtbStrings";
            this.RtbStrings.Size = new System.Drawing.Size(740, 685);
            this.RtbStrings.TabIndex = 56;
            this.RtbStrings.Text = "";
            // 
            // LblStringCount
            // 
            this.LblStringCount.AutoSize = true;
            this.LblStringCount.Location = new System.Drawing.Point(87, 11);
            this.LblStringCount.Name = "LblStringCount";
            this.LblStringCount.Size = new System.Drawing.Size(13, 13);
            this.LblStringCount.TabIndex = 55;
            this.LblStringCount.Text = "0";
            // 
            // BtnReadStrings
            // 
            this.BtnReadStrings.Location = new System.Drawing.Point(6, 6);
            this.BtnReadStrings.Name = "BtnReadStrings";
            this.BtnReadStrings.Size = new System.Drawing.Size(75, 23);
            this.BtnReadStrings.TabIndex = 0;
            this.BtnReadStrings.Text = "Read strings";
            this.BtnReadStrings.UseVisualStyleBackColor = true;
            this.BtnReadStrings.Click += new System.EventHandler(this.BtnReadStrings_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.CmbSaveButton);
            this.tabPage6.Controls.Add(this.BtnOpenSaveMenu);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(752, 726);
            this.tabPage6.TabIndex = 9;
            this.tabPage6.Text = "Save";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // CmbSaveButton
            // 
            this.CmbSaveButton.FormattingEnabled = true;
            this.CmbSaveButton.Location = new System.Drawing.Point(159, 8);
            this.CmbSaveButton.Name = "CmbSaveButton";
            this.CmbSaveButton.Size = new System.Drawing.Size(99, 21);
            this.CmbSaveButton.TabIndex = 20;
            this.CmbSaveButton.SelectedValueChanged += new System.EventHandler(this.CmbSaveButton_SelectedValueChanged);
            // 
            // BtnOpenSaveMenu
            // 
            this.BtnOpenSaveMenu.Location = new System.Drawing.Point(6, 6);
            this.BtnOpenSaveMenu.Name = "BtnOpenSaveMenu";
            this.BtnOpenSaveMenu.Size = new System.Drawing.Size(147, 23);
            this.BtnOpenSaveMenu.TabIndex = 19;
            this.BtnOpenSaveMenu.Text = "Open save menu";
            this.BtnOpenSaveMenu.UseVisualStyleBackColor = true;
            this.BtnOpenSaveMenu.Click += new System.EventHandler(this.BtnOpenSaveMenu_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraPitch)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TbpMap.ResumeLayout(false);
            this.TbpMap.PerformLayout();
            this.TbpModel.ResumeLayout(false);
            this.TbpModel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkModelScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelX)).EndInit();
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
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage6.ResumeLayout(false);
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
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private Button BtnGrabMapGraphic;
		private PictureBox PbxMapGraphic;
		private TabControl tabControl1;
		private TabPage TbpBasics;
		private TabPage TbpMap;
		private TabPage TbpModel;
		private Label LblModelZ;
		private Button BtnModelGetPosition;
		private Button BtnModelSetPosition;
		private Label LblModelX;
		private Label LblModelY;
		private NumericUpDown NudModelZ;
		private NumericUpDown NudModelY;
		private NumericUpDown NudModelX;
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
		private CheckBox CbxEnableOverlayCameraReporting;
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
		private CheckBox CbxEnableOverlay;
		private TabPage TbpInfo;
		private CheckBox CbxCameraFreeze;
		private TabPage tabPage2;
		private Label label8;
		private Label label7;
		private Label LblRunningDistance;
		private Label LblWalkingDistance;
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
		private Label LblSpawnThing0;
		private Label LblSpawnThing1;
		private Label LblSpawnYaw;
		private Label label17;
		private Label label16;
		private Label label15;
		private Label LblSpawnThing2;
		private Label label20;
		private Button BtnReadPois;
		private ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
		private Button BtnReadHarryModel;
		private Label LblModelScale;
		private TrackBar TrkModelScale;
		private ComboBox CmbModelSubmeshName;
		private CheckBox CbxEnableModelDisplay;
		private NumericUpDown NudOverlayCameraRoll;
		private NumericUpDown NudOverlayCameraYaw;
		private NumericUpDown NudOverlayCameraPitch;
		private CheckBox CbxOverlayCameraMatchGame;
		private NumericUpDown NudOverlayCameraZ;
		private NumericUpDown NudOverlayCameraY;
		private NumericUpDown NudOverlayCameraX;
		private Label label24;
		private Label label23;
		private Label label22;
		private Label label25;
		private Label label26;
		private Label label27;
		private CheckBox CbxOverlayTestBox;
		private Label label28;
		private Label label29;
		private Label label30;
		private NumericUpDown NudOverlayTestBoxZ;
		private NumericUpDown NudOverlayTestBoxY;
		private NumericUpDown NudOverlayTestBoxX;
		private ComboBox CmbRenderMode;
		private Label LblFov;
		private TrackBar TrkFov;
		private Label LblPoiCount1;
		private TabPage tabPage4;
		private Button BtnReadStrings;
		private Label LblStringCount;
		private RichTextBox RtbStrings;
		private TabPage tabPage5;
		private ListBox LbxPois;
		private Label LblPoiCount2;
		private Button BtnReadPois2;
		private Label LblSelectedPoiThing2;
		private Label label31;
		private Label LblSelectedPoiThing1;
		private Label LblSelectedPoiYaw;
		private Label label34;
		private Label label35;
		private Label label36;
		private Label label37;
		private Label label38;
		private Label LblSelectedPoiZ;
		private Label LblSelectedPoiX;
		private Label LblSelectedPoiThing0;
		private Label LblTriggerCount;
		private Button BtnReadTriggers;
		private ListBox LbxTriggers;
		private GroupBox groupBox2;
		private GroupBox groupBox1;
		private Label LblSelectedTriggerTypeInfo;
		private Label label51;
		private Label LblSelectedTriggerThing4;
		private Label label49;
		private Label LblSelectedTriggerThing3;
		private Label label47;
		private Label LblSelectedTriggerPoiIndex;
		private Label label45;
		private Label LblSelectedTriggerStyle;
		private Label label43;
		private Label LblSelectedTriggerFired;
		private Label label41;
		private Label LblSelectedTriggerThing1;
		private Label label39;
		private Label LblSelectedTriggerThing0;
		private Label label32;
		private Label LblSelectedTriggerAddress;
		private Label label40;
		private Label LblSelectedPoiAddress;
		private Label label21;
		private Label label33;
		private ListBox LbxPoiAssociatedTriggers;
		private Button BtnGoToPoi;
		private Label label42;
		private NumericUpDown NudSelectedTriggerTargetIndex;
		private ComboBox CmbSelectedTriggerType;
		private Label label46;
		private CheckBox CbxTriggersAutoUpdate;
		private Label label44;
		private RadioButton RdoOverlayAxisColorsOverlay;
		private RadioButton RdoOverlayAxisColorsGame;
		private RadioButton RdoOverlayAxisColorsOff;
		private Label LblSelectedTriggerSomeIndex;
		private Label label50;
		private Label LblTotalTime;
		private Label label52;
		private Label label48;
		private CheckBox CbxSelectedTriggerEnableUpdates;
		private Label LblSelectedTriggerFiredDetails;
		private Button BtnFogWorldTintColorSwap;
		private CheckBox CbxSelectedTriggerDisabled;
		private TabPage tabPage6;
		private ComboBox CmbSaveButton;
		private Button BtnOpenSaveMenu;
	}
}
