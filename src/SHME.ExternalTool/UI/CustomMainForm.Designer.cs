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
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LblSpawnZ = new System.Windows.Forms.Label();
            this.LblSpawnX = new System.Windows.Forms.Label();
            this.LblSpawnGeometry = new System.Windows.Forms.Label();
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
            this.TbcMainTabs = new System.Windows.Forms.TabControl();
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
            this.label37 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.NudOverlayTestBoxSizeZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxSizeY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxSizeX = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.NudOverlayTestLineBZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineBY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineBX = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.NudOverlayTestLineAZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineAY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineAX = new System.Windows.Forms.NumericUpDown();
            this.CbxOverlayTestLine = new System.Windows.Forms.CheckBox();
            this.RdoOverlayAxisColorsOff = new System.Windows.Forms.RadioButton();
            this.label44 = new System.Windows.Forms.Label();
            this.RdoOverlayAxisColorsOverlay = new System.Windows.Forms.RadioButton();
            this.RdoOverlayAxisColorsGame = new System.Windows.Forms.RadioButton();
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
            this.BtnClearPoisTriggers = new System.Windows.Forms.Button();
            this.CmbRenderShape = new System.Windows.Forms.ComboBox();
            this.CbxTriggersAutoUpdate = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblSelectedTriggerThing2 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiGeometry = new System.Windows.Forms.Label();
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
            this.LblSelectedPoiX = new System.Windows.Forms.Label();
            this.LblSelectedPoiZ = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.LblSelectedPoiGeometry = new System.Windows.Forms.Label();
            this.LblTriggerCount = new System.Windows.Forms.Label();
            this.BtnReadTriggers = new System.Windows.Forms.Button();
            this.LbxTriggers = new System.Windows.Forms.ListBox();
            this.LblPoiCount = new System.Windows.Forms.Label();
            this.BtnReadPois = new System.Windows.Forms.Button();
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
            this.TbpSave = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnOpenSaveMenu = new System.Windows.Forms.Button();
            this.CmbSaveButton = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CbxSaveRamDanger = new System.Windows.Forms.CheckBox();
            this.PbxHazardStripes = new System.Windows.Forms.PictureBox();
            this.GbxConvertSaveRamToStates = new System.Windows.Forms.GroupBox();
            this.label57 = new System.Windows.Forms.Label();
            this.BtnConvertSaveRamToStatesOutputPathBrowse = new System.Windows.Forms.Button();
            this.TbxConvertSaveRamToStatesOutputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertSaveRamToStatesRefresh = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.BtnConvertSaveRamToStatesInputPathBrowse = new System.Windows.Forms.Button();
            this.TbxConvertSaveRamToStatesInputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertSaveRamToStatesGo = new System.Windows.Forms.Button();
            this.LbxConvertSaveRamToStates = new System.Windows.Forms.ListBox();
            this.GbxConvertStatesToSaveRam = new System.Windows.Forms.GroupBox();
            this.label58 = new System.Windows.Forms.Label();
            this.BtnConvertStatesToSaveRamInputPathBrowse = new System.Windows.Forms.Button();
            this.TbxConvertStatesToSaveRamInputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertStatesToSaveRamRefresh = new System.Windows.Forms.Button();
            this.BtnConvertStatesToSaveRamGo = new System.Windows.Forms.Button();
            this.LbxConvertStatesToSaveRam = new System.Windows.Forms.ListBox();
            this.label55 = new System.Windows.Forms.Label();
            this.BtnConvertStatesToSaveRamOutputPathBrowse = new System.Windows.Forms.Button();
            this.TbxConvertStatesToSaveRamOutputPath = new System.Windows.Forms.TextBox();
            this.BtnSaveRamImportBrowse = new System.Windows.Forms.Button();
            this.TbxSaveRamImportPath = new System.Windows.Forms.TextBox();
            this.BtnSaveRamImport = new System.Windows.Forms.Button();
            this.BtnSaveRamExportBrowse = new System.Windows.Forms.Button();
            this.TbxSaveRamExportPath = new System.Windows.Forms.TextBox();
            this.BtnSaveRamExport = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GbxHarry.SuspendLayout();
            this.GbxCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).BeginInit();
            this.TbcMainTabs.SuspendLayout();
            this.TbpBasics.SuspendLayout();
            this.GbxControls.SuspendLayout();
            this.GbxOverlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAX)).BeginInit();
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
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.TbpSave.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHazardStripes)).BeginInit();
            this.GbxConvertSaveRamToStates.SuspendLayout();
            this.GbxConvertStatesToSaveRam.SuspendLayout();
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
            this.GbxHarry.Controls.Add(this.LblSpawnGeometry);
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
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 298);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 13);
            this.label19.TabIndex = 22;
            this.label19.Text = "Last spawn geometry:";
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
            // LblSpawnGeometry
            // 
            this.LblSpawnGeometry.AutoSize = true;
            this.LblSpawnGeometry.Location = new System.Drawing.Point(122, 298);
            this.LblSpawnGeometry.Name = "LblSpawnGeometry";
            this.LblSpawnGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSpawnGeometry.TabIndex = 20;
            this.LblSpawnGeometry.Text = "<geometry>";
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
            // TbcMainTabs
            // 
            this.TbcMainTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbcMainTabs.Controls.Add(this.TbpBasics);
            this.TbcMainTabs.Controls.Add(this.tabPage5);
            this.TbcMainTabs.Controls.Add(this.tabPage2);
            this.TbcMainTabs.Controls.Add(this.TbpMap);
            this.TbcMainTabs.Controls.Add(this.TbpModel);
            this.TbcMainTabs.Controls.Add(this.tabPage3);
            this.TbcMainTabs.Controls.Add(this.tabPage4);
            this.TbcMainTabs.Controls.Add(this.TbpSave);
            this.TbcMainTabs.Location = new System.Drawing.Point(12, 12);
            this.TbcMainTabs.Name = "TbcMainTabs";
            this.TbcMainTabs.SelectedIndex = 0;
            this.TbcMainTabs.Size = new System.Drawing.Size(760, 752);
            this.TbcMainTabs.TabIndex = 17;
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
            this.GbxOverlay.Controls.Add(this.label37);
            this.GbxOverlay.Controls.Add(this.label53);
            this.GbxOverlay.Controls.Add(this.label54);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxSizeZ);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxSizeY);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestBoxSizeX);
            this.GbxOverlay.Controls.Add(this.label31);
            this.GbxOverlay.Controls.Add(this.label34);
            this.GbxOverlay.Controls.Add(this.label36);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineBZ);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineBY);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineBX);
            this.GbxOverlay.Controls.Add(this.label16);
            this.GbxOverlay.Controls.Add(this.label17);
            this.GbxOverlay.Controls.Add(this.label20);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineAZ);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineAY);
            this.GbxOverlay.Controls.Add(this.NudOverlayTestLineAX);
            this.GbxOverlay.Controls.Add(this.CbxOverlayTestLine);
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsOff);
            this.GbxOverlay.Controls.Add(this.label44);
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsOverlay);
            this.GbxOverlay.Controls.Add(this.RdoOverlayAxisColorsGame);
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
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(91, 299);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 13);
            this.label37.TabIndex = 78;
            this.label37.Text = "Size Z:";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(91, 273);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 13);
            this.label53.TabIndex = 77;
            this.label53.Text = "Size Y:";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(91, 247);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(40, 13);
            this.label54.TabIndex = 76;
            this.label54.Text = "Size X:";
            // 
            // NudOverlayTestBoxSizeZ
            // 
            this.NudOverlayTestBoxSizeZ.Location = new System.Drawing.Point(137, 297);
            this.NudOverlayTestBoxSizeZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxSizeZ.Name = "NudOverlayTestBoxSizeZ";
            this.NudOverlayTestBoxSizeZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxSizeZ.TabIndex = 75;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxSizeZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxSizeZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeZ_ValueChanged);
            this.NudOverlayTestBoxSizeZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxSizeZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxSizeY
            // 
            this.NudOverlayTestBoxSizeY.Location = new System.Drawing.Point(137, 271);
            this.NudOverlayTestBoxSizeY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxSizeY.Name = "NudOverlayTestBoxSizeY";
            this.NudOverlayTestBoxSizeY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxSizeY.TabIndex = 74;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxSizeY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxSizeY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeY_ValueChanged);
            this.NudOverlayTestBoxSizeY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxSizeY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxSizeX
            // 
            this.NudOverlayTestBoxSizeX.Location = new System.Drawing.Point(137, 245);
            this.NudOverlayTestBoxSizeX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxSizeX.Name = "NudOverlayTestBoxSizeX";
            this.NudOverlayTestBoxSizeX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxSizeX.TabIndex = 73;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxSizeX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxSizeX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestBoxSizeX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeX_ValueChanged);
            this.NudOverlayTestBoxSizeX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxSizeX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(313, 299);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 13);
            this.label31.TabIndex = 72;
            this.label31.Text = "Z:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(313, 273);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 13);
            this.label34.TabIndex = 71;
            this.label34.Text = "Y:";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(313, 247);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 13);
            this.label36.TabIndex = 70;
            this.label36.Text = "X:";
            // 
            // NudOverlayTestLineBZ
            // 
            this.NudOverlayTestLineBZ.Location = new System.Drawing.Point(336, 297);
            this.NudOverlayTestLineBZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineBZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineBZ.Name = "NudOverlayTestLineBZ";
            this.NudOverlayTestLineBZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineBZ.TabIndex = 69;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineBZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineBZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBZ_ValueChanged);
            this.NudOverlayTestLineBZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineBZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineBY
            // 
            this.NudOverlayTestLineBY.Location = new System.Drawing.Point(336, 271);
            this.NudOverlayTestLineBY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineBY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineBY.Name = "NudOverlayTestLineBY";
            this.NudOverlayTestLineBY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineBY.TabIndex = 68;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineBY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineBY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineBY.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBY_ValueChanged);
            this.NudOverlayTestLineBY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineBY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineBX
            // 
            this.NudOverlayTestLineBX.Location = new System.Drawing.Point(336, 245);
            this.NudOverlayTestLineBX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineBX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineBX.Name = "NudOverlayTestLineBX";
            this.NudOverlayTestLineBX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineBX.TabIndex = 67;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineBX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineBX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestLineBX.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBX_ValueChanged);
            this.NudOverlayTestLineBX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineBX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(230, 299);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 13);
            this.label16.TabIndex = 65;
            this.label16.Text = "Z:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(230, 273);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 64;
            this.label17.Text = "Y:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(230, 247);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 13);
            this.label20.TabIndex = 63;
            this.label20.Text = "X:";
            // 
            // NudOverlayTestLineAZ
            // 
            this.NudOverlayTestLineAZ.Location = new System.Drawing.Point(253, 297);
            this.NudOverlayTestLineAZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineAZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineAZ.Name = "NudOverlayTestLineAZ";
            this.NudOverlayTestLineAZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineAZ.TabIndex = 62;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineAZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineAZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAZ_ValueChanged);
            this.NudOverlayTestLineAZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineAZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineAY
            // 
            this.NudOverlayTestLineAY.Location = new System.Drawing.Point(253, 271);
            this.NudOverlayTestLineAY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineAY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineAY.Name = "NudOverlayTestLineAY";
            this.NudOverlayTestLineAY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineAY.TabIndex = 61;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineAY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineAY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineAY.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAY_ValueChanged);
            this.NudOverlayTestLineAY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineAY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineAX
            // 
            this.NudOverlayTestLineAX.Location = new System.Drawing.Point(253, 245);
            this.NudOverlayTestLineAX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestLineAX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestLineAX.Name = "NudOverlayTestLineAX";
            this.NudOverlayTestLineAX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestLineAX.TabIndex = 60;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineAX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineAX.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAX_ValueChanged);
            this.NudOverlayTestLineAX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineAX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // CbxOverlayTestLine
            // 
            this.CbxOverlayTestLine.AutoSize = true;
            this.CbxOverlayTestLine.Location = new System.Drawing.Point(279, 222);
            this.CbxOverlayTestLine.Name = "CbxOverlayTestLine";
            this.CbxOverlayTestLine.Size = new System.Drawing.Size(66, 17);
            this.CbxOverlayTestLine.TabIndex = 59;
            this.CbxOverlayTestLine.Text = "Test line";
            this.CbxOverlayTestLine.UseVisualStyleBackColor = true;
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
            // CmbRenderMode
            // 
            this.CmbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRenderMode.FormattingEnabled = true;
            this.CmbRenderMode.Items.AddRange(new object[] {
            "Wireframe",
            "Solid",
            "Points"});
            this.CmbRenderMode.Location = new System.Drawing.Point(6, 349);
            this.CmbRenderMode.Name = "CmbRenderMode";
            this.CmbRenderMode.Size = new System.Drawing.Size(121, 21);
            this.CmbRenderMode.TabIndex = 53;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 299);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 13);
            this.label28.TabIndex = 52;
            this.label28.Text = "Z:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(8, 273);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 13);
            this.label29.TabIndex = 51;
            this.label29.Text = "Y:";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 247);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 13);
            this.label30.TabIndex = 50;
            this.label30.Text = "X:";
            // 
            // NudOverlayTestBoxZ
            // 
            this.NudOverlayTestBoxZ.Location = new System.Drawing.Point(31, 297);
            this.NudOverlayTestBoxZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxZ.Name = "NudOverlayTestBoxZ";
            this.NudOverlayTestBoxZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxZ.TabIndex = 49;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxZ_ValueChanged);
            this.NudOverlayTestBoxZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxY
            // 
            this.NudOverlayTestBoxY.Location = new System.Drawing.Point(31, 271);
            this.NudOverlayTestBoxY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxY.Name = "NudOverlayTestBoxY";
            this.NudOverlayTestBoxY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxY.TabIndex = 48;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxY_ValueChanged);
            this.NudOverlayTestBoxY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxX
            // 
            this.NudOverlayTestBoxX.Location = new System.Drawing.Point(31, 245);
            this.NudOverlayTestBoxX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestBoxX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestBoxX.Name = "NudOverlayTestBoxX";
            this.NudOverlayTestBoxX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestBoxX.TabIndex = 47;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxX_ValueChanged);
            this.NudOverlayTestBoxX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // CbxOverlayTestBox
            // 
            this.CbxOverlayTestBox.AutoSize = true;
            this.CbxOverlayTestBox.Location = new System.Drawing.Point(11, 222);
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
            this.NudOverlayCameraZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraZ.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.NudOverlayCameraY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraY.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.NudOverlayCameraX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraX.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.NudOverlayCameraRoll.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraRoll.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.NudOverlayCameraYaw.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraYaw.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.NudOverlayCameraPitch.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraPitch.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.tabPage5.Controls.Add(this.BtnClearPoisTriggers);
            this.tabPage5.Controls.Add(this.CmbRenderShape);
            this.tabPage5.Controls.Add(this.CbxTriggersAutoUpdate);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.LblTriggerCount);
            this.tabPage5.Controls.Add(this.BtnReadTriggers);
            this.tabPage5.Controls.Add(this.LbxTriggers);
            this.tabPage5.Controls.Add(this.LblPoiCount);
            this.tabPage5.Controls.Add(this.BtnReadPois);
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
            // BtnClearPoisTriggers
            // 
            this.BtnClearPoisTriggers.Location = new System.Drawing.Point(6, 666);
            this.BtnClearPoisTriggers.Name = "BtnClearPoisTriggers";
            this.BtnClearPoisTriggers.Size = new System.Drawing.Size(374, 23);
            this.BtnClearPoisTriggers.TabIndex = 81;
            this.BtnClearPoisTriggers.Text = "Clear";
            this.BtnClearPoisTriggers.UseVisualStyleBackColor = true;
            this.BtnClearPoisTriggers.Click += new System.EventHandler(this.BtnClearPoisTriggers_Click);
            // 
            // CmbRenderShape
            // 
            this.CmbRenderShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRenderShape.FormattingEnabled = true;
            this.CmbRenderShape.Items.AddRange(new object[] {
            "Volumes",
            "Cubes",
            "Centers"});
            this.CmbRenderShape.Location = new System.Drawing.Point(133, 695);
            this.CmbRenderShape.Name = "CmbRenderShape";
            this.CmbRenderShape.Size = new System.Drawing.Size(121, 21);
            this.CmbRenderShape.TabIndex = 80;
            this.CmbRenderShape.SelectedIndexChanged += new System.EventHandler(this.CmbRenderShape_SelectedIndexChanged);
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
            this.groupBox2.Controls.Add(this.LblSelectedTriggerThing2);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.LblSelectedTriggerPoiGeometry);
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
            this.groupBox2.Location = new System.Drawing.Point(386, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 336);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected trigger";
            // 
            // LblSelectedTriggerThing2
            // 
            this.LblSelectedTriggerThing2.AutoSize = true;
            this.LblSelectedTriggerThing2.Location = new System.Drawing.Point(75, 219);
            this.LblSelectedTriggerThing2.Name = "LblSelectedTriggerThing2";
            this.LblSelectedTriggerThing2.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing2.TabIndex = 94;
            this.LblSelectedTriggerThing2.Text = "<thing2>";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(6, 219);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(43, 13);
            this.label60.TabIndex = 95;
            this.label60.Text = "Thing2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 92;
            this.label15.Text = "POI geometry:";
            // 
            // LblSelectedTriggerPoiGeometry
            // 
            this.LblSelectedTriggerPoiGeometry.AutoSize = true;
            this.LblSelectedTriggerPoiGeometry.Location = new System.Drawing.Point(86, 81);
            this.LblSelectedTriggerPoiGeometry.Name = "LblSelectedTriggerPoiGeometry";
            this.LblSelectedTriggerPoiGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSelectedTriggerPoiGeometry.TabIndex = 93;
            this.LblSelectedTriggerPoiGeometry.Text = "<geometry>";
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
            this.LblSelectedTriggerFiredDetails.Location = new System.Drawing.Point(120, 179);
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
            this.LblSelectedTriggerSomeIndex.Location = new System.Drawing.Point(75, 199);
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
            this.LblSelectedTriggerThing4.Location = new System.Drawing.Point(75, 299);
            this.LblSelectedTriggerThing4.Name = "LblSelectedTriggerThing4";
            this.LblSelectedTriggerThing4.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing4.TabIndex = 75;
            this.LblSelectedTriggerThing4.Text = "<thing4>";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(6, 299);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(43, 13);
            this.label49.TabIndex = 76;
            this.label49.Text = "Thing4:";
            // 
            // LblSelectedTriggerThing3
            // 
            this.LblSelectedTriggerThing3.AutoSize = true;
            this.LblSelectedTriggerThing3.Location = new System.Drawing.Point(75, 279);
            this.LblSelectedTriggerThing3.Name = "LblSelectedTriggerThing3";
            this.LblSelectedTriggerThing3.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing3.TabIndex = 73;
            this.LblSelectedTriggerThing3.Text = "<thing3>";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(6, 279);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(43, 13);
            this.label47.TabIndex = 74;
            this.label47.Text = "Thing3:";
            // 
            // LblSelectedTriggerPoiIndex
            // 
            this.LblSelectedTriggerPoiIndex.AutoSize = true;
            this.LblSelectedTriggerPoiIndex.Location = new System.Drawing.Point(75, 259);
            this.LblSelectedTriggerPoiIndex.Name = "LblSelectedTriggerPoiIndex";
            this.LblSelectedTriggerPoiIndex.Size = new System.Drawing.Size(58, 13);
            this.LblSelectedTriggerPoiIndex.TabIndex = 71;
            this.LblSelectedTriggerPoiIndex.Text = "<poiindex>";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(6, 259);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(51, 13);
            this.label45.TabIndex = 72;
            this.label45.Text = "PoiIndex:";
            // 
            // LblSelectedTriggerStyle
            // 
            this.LblSelectedTriggerStyle.AutoSize = true;
            this.LblSelectedTriggerStyle.Location = new System.Drawing.Point(75, 239);
            this.LblSelectedTriggerStyle.Name = "LblSelectedTriggerStyle";
            this.LblSelectedTriggerStyle.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedTriggerStyle.TabIndex = 69;
            this.LblSelectedTriggerStyle.Text = "<style>";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 239);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 13);
            this.label43.TabIndex = 70;
            this.label43.Text = "Style:";
            // 
            // LblSelectedTriggerFired
            // 
            this.LblSelectedTriggerFired.AutoSize = true;
            this.LblSelectedTriggerFired.Location = new System.Drawing.Point(75, 179);
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
            this.LblSelectedTriggerThing1.Location = new System.Drawing.Point(75, 159);
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
            this.LblSelectedTriggerThing0.Location = new System.Drawing.Point(75, 139);
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
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.BtnGoToPoi);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.LbxPoiAssociatedTriggers);
            this.groupBox1.Controls.Add(this.LblSelectedPoiAddress);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.LblSelectedPoiX);
            this.groupBox1.Controls.Add(this.LblSelectedPoiZ);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.LblSelectedPoiGeometry);
            this.groupBox1.Location = new System.Drawing.Point(386, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 338);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected POI";
            // 
            // BtnGoToPoi
            // 
            this.BtnGoToPoi.Location = new System.Drawing.Point(129, 43);
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
            this.label33.Location = new System.Drawing.Point(3, 143);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 13);
            this.label33.TabIndex = 75;
            this.label33.Text = "Associated triggers:";
            // 
            // LbxPoiAssociatedTriggers
            // 
            this.LbxPoiAssociatedTriggers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbxPoiAssociatedTriggers.FormattingEnabled = true;
            this.LbxPoiAssociatedTriggers.Location = new System.Drawing.Point(6, 159);
            this.LbxPoiAssociatedTriggers.Name = "LbxPoiAssociatedTriggers";
            this.LbxPoiAssociatedTriggers.Size = new System.Drawing.Size(348, 173);
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
            this.label38.Size = new System.Drawing.Size(24, 13);
            this.label38.TabIndex = 57;
            this.label38.Text = "XZ:";
            // 
            // LblSelectedPoiX
            // 
            this.LblSelectedPoiX.AutoSize = true;
            this.LblSelectedPoiX.Location = new System.Drawing.Point(36, 48);
            this.LblSelectedPoiX.Name = "LblSelectedPoiX";
            this.LblSelectedPoiX.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedPoiX.TabIndex = 58;
            this.LblSelectedPoiX.Text = "???.??";
            // 
            // LblSelectedPoiZ
            // 
            this.LblSelectedPoiZ.AutoSize = true;
            this.LblSelectedPoiZ.Location = new System.Drawing.Point(82, 48);
            this.LblSelectedPoiZ.Name = "LblSelectedPoiZ";
            this.LblSelectedPoiZ.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedPoiZ.TabIndex = 60;
            this.LblSelectedPoiZ.Text = "???.??";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(6, 83);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(55, 13);
            this.label35.TabIndex = 63;
            this.label35.Text = "Geometry:";
            // 
            // LblSelectedPoiGeometry
            // 
            this.LblSelectedPoiGeometry.AutoSize = true;
            this.LblSelectedPoiGeometry.Location = new System.Drawing.Point(67, 83);
            this.LblSelectedPoiGeometry.Name = "LblSelectedPoiGeometry";
            this.LblSelectedPoiGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSelectedPoiGeometry.TabIndex = 65;
            this.LblSelectedPoiGeometry.Text = "<geometry>";
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
            this.LbxTriggers.Size = new System.Drawing.Size(184, 628);
            this.LbxTriggers.TabIndex = 69;
            this.LbxTriggers.SelectedIndexChanged += new System.EventHandler(this.LbxTriggers_SelectedIndexChanged);
            this.LbxTriggers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxTriggers_Format);
            // 
            // LblPoiCount
            // 
            this.LblPoiCount.AutoSize = true;
            this.LblPoiCount.Location = new System.Drawing.Point(87, 11);
            this.LblPoiCount.Name = "LblPoiCount";
            this.LblPoiCount.Size = new System.Drawing.Size(13, 13);
            this.LblPoiCount.TabIndex = 56;
            this.LblPoiCount.Text = "0";
            // 
            // BtnReadPois
            // 
            this.BtnReadPois.Location = new System.Drawing.Point(6, 6);
            this.BtnReadPois.Name = "BtnReadPois";
            this.BtnReadPois.Size = new System.Drawing.Size(75, 23);
            this.BtnReadPois.TabIndex = 55;
            this.BtnReadPois.Text = "Read POIs";
            this.BtnReadPois.UseVisualStyleBackColor = true;
            this.BtnReadPois.Click += new System.EventHandler(this.BtnReadPois_Click);
            // 
            // LbxPois
            // 
            this.LbxPois.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LbxPois.FormattingEnabled = true;
            this.LbxPois.Location = new System.Drawing.Point(6, 32);
            this.LbxPois.Name = "LbxPois";
            this.LbxPois.Size = new System.Drawing.Size(184, 628);
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
            this.BtnFogWorldTintColorSwap.Size = new System.Drawing.Size(240, 23);
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
            // TbpSave
            // 
            this.TbpSave.Controls.Add(this.groupBox4);
            this.TbpSave.Controls.Add(this.groupBox3);
            this.TbpSave.Location = new System.Drawing.Point(4, 22);
            this.TbpSave.Name = "TbpSave";
            this.TbpSave.Padding = new System.Windows.Forms.Padding(3);
            this.TbpSave.Size = new System.Drawing.Size(752, 726);
            this.TbpSave.TabIndex = 9;
            this.TbpSave.Text = "Save";
            this.TbpSave.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.BtnOpenSaveMenu);
            this.groupBox4.Controls.Add(this.CmbSaveButton);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(740, 56);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In-game saves";
            // 
            // BtnOpenSaveMenu
            // 
            this.BtnOpenSaveMenu.Location = new System.Drawing.Point(6, 19);
            this.BtnOpenSaveMenu.Name = "BtnOpenSaveMenu";
            this.BtnOpenSaveMenu.Size = new System.Drawing.Size(147, 23);
            this.BtnOpenSaveMenu.TabIndex = 19;
            this.BtnOpenSaveMenu.Text = "Open save menu";
            this.BtnOpenSaveMenu.UseVisualStyleBackColor = true;
            this.BtnOpenSaveMenu.Click += new System.EventHandler(this.BtnOpenSaveMenu_Click);
            // 
            // CmbSaveButton
            // 
            this.CmbSaveButton.FormattingEnabled = true;
            this.CmbSaveButton.Location = new System.Drawing.Point(159, 20);
            this.CmbSaveButton.Name = "CmbSaveButton";
            this.CmbSaveButton.Size = new System.Drawing.Size(99, 21);
            this.CmbSaveButton.TabIndex = 20;
            this.CmbSaveButton.SelectedValueChanged += new System.EventHandler(this.CmbSaveButton_SelectedValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.CbxSaveRamDanger);
            this.groupBox3.Controls.Add(this.PbxHazardStripes);
            this.groupBox3.Controls.Add(this.GbxConvertSaveRamToStates);
            this.groupBox3.Controls.Add(this.GbxConvertStatesToSaveRam);
            this.groupBox3.Controls.Add(this.BtnSaveRamImportBrowse);
            this.groupBox3.Controls.Add(this.TbxSaveRamImportPath);
            this.groupBox3.Controls.Add(this.BtnSaveRamImport);
            this.groupBox3.Controls.Add(this.BtnSaveRamExportBrowse);
            this.groupBox3.Controls.Add(this.TbxSaveRamExportPath);
            this.groupBox3.Controls.Add(this.BtnSaveRamExport);
            this.groupBox3.Location = new System.Drawing.Point(6, 69);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(740, 651);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SaveRAM";
            // 
            // CbxSaveRamDanger
            // 
            this.CbxSaveRamDanger.AutoSize = true;
            this.CbxSaveRamDanger.Location = new System.Drawing.Point(182, 55);
            this.CbxSaveRamDanger.Name = "CbxSaveRamDanger";
            this.CbxSaveRamDanger.Size = new System.Drawing.Size(377, 17);
            this.CbxSaveRamDanger.TabIndex = 0;
            this.CbxSaveRamDanger.Text = "Acknowledge incredible danger of messing with savestates and SaveRAM";
            this.CbxSaveRamDanger.UseVisualStyleBackColor = true;
            this.CbxSaveRamDanger.CheckedChanged += new System.EventHandler(this.CbxSaveRamDanger_CheckedChanged);
            // 
            // PbxHazardStripes
            // 
            this.PbxHazardStripes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PbxHazardStripes.Location = new System.Drawing.Point(6, 47);
            this.PbxHazardStripes.Name = "PbxHazardStripes";
            this.PbxHazardStripes.Size = new System.Drawing.Size(728, 32);
            this.PbxHazardStripes.TabIndex = 8;
            this.PbxHazardStripes.TabStop = false;
            this.PbxHazardStripes.SizeChanged += new System.EventHandler(this.PbxHazardStripes_SizeChanged);
            this.PbxHazardStripes.VisibleChanged += new System.EventHandler(this.PbxHazardStripes_VisibleChanged);
            // 
            // GbxConvertSaveRamToStates
            // 
            this.GbxConvertSaveRamToStates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbxConvertSaveRamToStates.Controls.Add(this.label57);
            this.GbxConvertSaveRamToStates.Controls.Add(this.BtnConvertSaveRamToStatesOutputPathBrowse);
            this.GbxConvertSaveRamToStates.Controls.Add(this.TbxConvertSaveRamToStatesOutputPath);
            this.GbxConvertSaveRamToStates.Controls.Add(this.BtnConvertSaveRamToStatesRefresh);
            this.GbxConvertSaveRamToStates.Controls.Add(this.label56);
            this.GbxConvertSaveRamToStates.Controls.Add(this.BtnConvertSaveRamToStatesInputPathBrowse);
            this.GbxConvertSaveRamToStates.Controls.Add(this.TbxConvertSaveRamToStatesInputPath);
            this.GbxConvertSaveRamToStates.Controls.Add(this.BtnConvertSaveRamToStatesGo);
            this.GbxConvertSaveRamToStates.Controls.Add(this.LbxConvertSaveRamToStates);
            this.GbxConvertSaveRamToStates.Enabled = false;
            this.GbxConvertSaveRamToStates.Location = new System.Drawing.Point(6, 365);
            this.GbxConvertSaveRamToStates.Name = "GbxConvertSaveRamToStates";
            this.GbxConvertSaveRamToStates.Size = new System.Drawing.Size(728, 280);
            this.GbxConvertSaveRamToStates.TabIndex = 7;
            this.GbxConvertSaveRamToStates.TabStop = false;
            this.GbxConvertSaveRamToStates.Text = "Convert SaveRAM to states";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(4, 256);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(137, 13);
            this.label57.TabIndex = 22;
            this.label57.Text = "Save state output directory:";
            // 
            // BtnConvertSaveRamToStatesOutputPathBrowse
            // 
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Location = new System.Drawing.Point(566, 251);
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Name = "BtnConvertSaveRamToStatesOutputPathBrowse";
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertSaveRamToStatesOutputPathBrowse.TabIndex = 21;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Text = "...";
            this.BtnConvertSaveRamToStatesOutputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesOutputPathBrowse_Click);
            // 
            // TbxConvertSaveRamToStatesOutputPath
            // 
            this.TbxConvertSaveRamToStatesOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesOutputPath.Location = new System.Drawing.Point(147, 253);
            this.TbxConvertSaveRamToStatesOutputPath.Name = "TbxConvertSaveRamToStatesOutputPath";
            this.TbxConvertSaveRamToStatesOutputPath.Size = new System.Drawing.Size(413, 20);
            this.TbxConvertSaveRamToStatesOutputPath.TabIndex = 20;
            // 
            // BtnConvertSaveRamToStatesRefresh
            // 
            this.BtnConvertSaveRamToStatesRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertSaveRamToStatesRefresh.Location = new System.Drawing.Point(647, 19);
            this.BtnConvertSaveRamToStatesRefresh.Name = "BtnConvertSaveRamToStatesRefresh";
            this.BtnConvertSaveRamToStatesRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertSaveRamToStatesRefresh.TabIndex = 19;
            this.BtnConvertSaveRamToStatesRefresh.Text = "Refresh";
            this.BtnConvertSaveRamToStatesRefresh.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesRefresh.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesRefresh_Click);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(13, 24);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(128, 13);
            this.label56.TabIndex = 18;
            this.label56.Text = "SaveRAM input directory:";
            // 
            // BtnConvertSaveRamToStatesInputPathBrowse
            // 
            this.BtnConvertSaveRamToStatesInputPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertSaveRamToStatesInputPathBrowse.Location = new System.Drawing.Point(566, 19);
            this.BtnConvertSaveRamToStatesInputPathBrowse.Name = "BtnConvertSaveRamToStatesInputPathBrowse";
            this.BtnConvertSaveRamToStatesInputPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertSaveRamToStatesInputPathBrowse.TabIndex = 17;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Text = "...";
            this.BtnConvertSaveRamToStatesInputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesInputPathBrowse_Click);
            // 
            // TbxConvertSaveRamToStatesInputPath
            // 
            this.TbxConvertSaveRamToStatesInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesInputPath.Location = new System.Drawing.Point(147, 21);
            this.TbxConvertSaveRamToStatesInputPath.Name = "TbxConvertSaveRamToStatesInputPath";
            this.TbxConvertSaveRamToStatesInputPath.Size = new System.Drawing.Size(413, 20);
            this.TbxConvertSaveRamToStatesInputPath.TabIndex = 16;
            this.TbxConvertSaveRamToStatesInputPath.TextChanged += new System.EventHandler(this.TbxConvertSaveRamToStatesInputPath_TextChanged);
            // 
            // BtnConvertSaveRamToStatesGo
            // 
            this.BtnConvertSaveRamToStatesGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertSaveRamToStatesGo.Location = new System.Drawing.Point(647, 251);
            this.BtnConvertSaveRamToStatesGo.Name = "BtnConvertSaveRamToStatesGo";
            this.BtnConvertSaveRamToStatesGo.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertSaveRamToStatesGo.TabIndex = 15;
            this.BtnConvertSaveRamToStatesGo.Text = "Go";
            this.BtnConvertSaveRamToStatesGo.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesGo.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesGo_Click);
            // 
            // LbxConvertSaveRamToStates
            // 
            this.LbxConvertSaveRamToStates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbxConvertSaveRamToStates.FormattingEnabled = true;
            this.LbxConvertSaveRamToStates.HorizontalScrollbar = true;
            this.LbxConvertSaveRamToStates.IntegralHeight = false;
            this.LbxConvertSaveRamToStates.Location = new System.Drawing.Point(6, 48);
            this.LbxConvertSaveRamToStates.Name = "LbxConvertSaveRamToStates";
            this.LbxConvertSaveRamToStates.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxConvertSaveRamToStates.Size = new System.Drawing.Size(716, 197);
            this.LbxConvertSaveRamToStates.TabIndex = 14;
            // 
            // GbxConvertStatesToSaveRam
            // 
            this.GbxConvertStatesToSaveRam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GbxConvertStatesToSaveRam.Controls.Add(this.label58);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.BtnConvertStatesToSaveRamInputPathBrowse);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.TbxConvertStatesToSaveRamInputPath);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.BtnConvertStatesToSaveRamRefresh);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.BtnConvertStatesToSaveRamGo);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.LbxConvertStatesToSaveRam);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.label55);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.BtnConvertStatesToSaveRamOutputPathBrowse);
            this.GbxConvertStatesToSaveRam.Controls.Add(this.TbxConvertStatesToSaveRamOutputPath);
            this.GbxConvertStatesToSaveRam.Enabled = false;
            this.GbxConvertStatesToSaveRam.Location = new System.Drawing.Point(6, 115);
            this.GbxConvertStatesToSaveRam.Name = "GbxConvertStatesToSaveRam";
            this.GbxConvertStatesToSaveRam.Size = new System.Drawing.Size(728, 244);
            this.GbxConvertStatesToSaveRam.TabIndex = 6;
            this.GbxConvertStatesToSaveRam.TabStop = false;
            this.GbxConvertStatesToSaveRam.Text = "Convert states to SaveRAM";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(11, 24);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(130, 13);
            this.label58.TabIndex = 21;
            this.label58.Text = "Save state input directory:";
            // 
            // BtnConvertStatesToSaveRamInputPathBrowse
            // 
            this.BtnConvertStatesToSaveRamInputPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertStatesToSaveRamInputPathBrowse.Location = new System.Drawing.Point(566, 19);
            this.BtnConvertStatesToSaveRamInputPathBrowse.Name = "BtnConvertStatesToSaveRamInputPathBrowse";
            this.BtnConvertStatesToSaveRamInputPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertStatesToSaveRamInputPathBrowse.TabIndex = 20;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Text = "...";
            this.BtnConvertStatesToSaveRamInputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamInputPathBrowse_Click);
            // 
            // TbxConvertStatesToSaveRamInputPath
            // 
            this.TbxConvertStatesToSaveRamInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertStatesToSaveRamInputPath.Location = new System.Drawing.Point(147, 21);
            this.TbxConvertStatesToSaveRamInputPath.Name = "TbxConvertStatesToSaveRamInputPath";
            this.TbxConvertStatesToSaveRamInputPath.Size = new System.Drawing.Size(413, 20);
            this.TbxConvertStatesToSaveRamInputPath.TabIndex = 19;
            this.TbxConvertStatesToSaveRamInputPath.TextChanged += new System.EventHandler(this.TbxConvertStatesToSaveRamInputPath_TextChanged);
            // 
            // BtnConvertStatesToSaveRamRefresh
            // 
            this.BtnConvertStatesToSaveRamRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertStatesToSaveRamRefresh.Location = new System.Drawing.Point(647, 19);
            this.BtnConvertStatesToSaveRamRefresh.Name = "BtnConvertStatesToSaveRamRefresh";
            this.BtnConvertStatesToSaveRamRefresh.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertStatesToSaveRamRefresh.TabIndex = 15;
            this.BtnConvertStatesToSaveRamRefresh.Text = "Refresh";
            this.BtnConvertStatesToSaveRamRefresh.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamRefresh.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamRefresh_Click);
            // 
            // BtnConvertStatesToSaveRamGo
            // 
            this.BtnConvertStatesToSaveRamGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertStatesToSaveRamGo.Location = new System.Drawing.Point(647, 215);
            this.BtnConvertStatesToSaveRamGo.Name = "BtnConvertStatesToSaveRamGo";
            this.BtnConvertStatesToSaveRamGo.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertStatesToSaveRamGo.TabIndex = 14;
            this.BtnConvertStatesToSaveRamGo.Text = "Go";
            this.BtnConvertStatesToSaveRamGo.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamGo.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamGo_Click);
            // 
            // LbxConvertStatesToSaveRam
            // 
            this.LbxConvertStatesToSaveRam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LbxConvertStatesToSaveRam.FormattingEnabled = true;
            this.LbxConvertStatesToSaveRam.HorizontalScrollbar = true;
            this.LbxConvertStatesToSaveRam.IntegralHeight = false;
            this.LbxConvertStatesToSaveRam.Location = new System.Drawing.Point(6, 48);
            this.LbxConvertStatesToSaveRam.Name = "LbxConvertStatesToSaveRam";
            this.LbxConvertStatesToSaveRam.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxConvertStatesToSaveRam.Size = new System.Drawing.Size(716, 161);
            this.LbxConvertStatesToSaveRam.TabIndex = 13;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(6, 220);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(135, 13);
            this.label55.TabIndex = 11;
            this.label55.Text = "SaveRAM output directory:";
            // 
            // BtnConvertStatesToSaveRamOutputPathBrowse
            // 
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Location = new System.Drawing.Point(566, 215);
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Name = "BtnConvertStatesToSaveRamOutputPathBrowse";
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnConvertStatesToSaveRamOutputPathBrowse.TabIndex = 10;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Text = "...";
            this.BtnConvertStatesToSaveRamOutputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamOutputPathBrowse_Click);
            // 
            // TbxConvertStatesToSaveRamOutputPath
            // 
            this.TbxConvertStatesToSaveRamOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertStatesToSaveRamOutputPath.Location = new System.Drawing.Point(147, 217);
            this.TbxConvertStatesToSaveRamOutputPath.Name = "TbxConvertStatesToSaveRamOutputPath";
            this.TbxConvertStatesToSaveRamOutputPath.Size = new System.Drawing.Size(413, 20);
            this.TbxConvertStatesToSaveRamOutputPath.TabIndex = 9;
            // 
            // BtnSaveRamImportBrowse
            // 
            this.BtnSaveRamImportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveRamImportBrowse.Enabled = false;
            this.BtnSaveRamImportBrowse.Location = new System.Drawing.Point(659, 85);
            this.BtnSaveRamImportBrowse.Name = "BtnSaveRamImportBrowse";
            this.BtnSaveRamImportBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveRamImportBrowse.TabIndex = 5;
            this.BtnSaveRamImportBrowse.Text = "...";
            this.BtnSaveRamImportBrowse.UseVisualStyleBackColor = true;
            this.BtnSaveRamImportBrowse.Click += new System.EventHandler(this.BtnSaveRamImportBrowse_Click);
            // 
            // TbxSaveRamImportPath
            // 
            this.TbxSaveRamImportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSaveRamImportPath.Enabled = false;
            this.TbxSaveRamImportPath.Location = new System.Drawing.Point(87, 87);
            this.TbxSaveRamImportPath.Name = "TbxSaveRamImportPath";
            this.TbxSaveRamImportPath.Size = new System.Drawing.Size(566, 20);
            this.TbxSaveRamImportPath.TabIndex = 4;
            // 
            // BtnSaveRamImport
            // 
            this.BtnSaveRamImport.Enabled = false;
            this.BtnSaveRamImport.Location = new System.Drawing.Point(6, 85);
            this.BtnSaveRamImport.Name = "BtnSaveRamImport";
            this.BtnSaveRamImport.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveRamImport.TabIndex = 3;
            this.BtnSaveRamImport.Text = "Import";
            this.BtnSaveRamImport.UseVisualStyleBackColor = true;
            this.BtnSaveRamImport.Click += new System.EventHandler(this.BtnSaveRamImport_Click);
            // 
            // BtnSaveRamExportBrowse
            // 
            this.BtnSaveRamExportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSaveRamExportBrowse.Location = new System.Drawing.Point(659, 19);
            this.BtnSaveRamExportBrowse.Name = "BtnSaveRamExportBrowse";
            this.BtnSaveRamExportBrowse.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveRamExportBrowse.TabIndex = 2;
            this.BtnSaveRamExportBrowse.Text = "...";
            this.BtnSaveRamExportBrowse.UseVisualStyleBackColor = true;
            this.BtnSaveRamExportBrowse.Click += new System.EventHandler(this.BtnSaveRamExportBrowse_Click);
            // 
            // TbxSaveRamExportPath
            // 
            this.TbxSaveRamExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSaveRamExportPath.Location = new System.Drawing.Point(87, 21);
            this.TbxSaveRamExportPath.Name = "TbxSaveRamExportPath";
            this.TbxSaveRamExportPath.Size = new System.Drawing.Size(566, 20);
            this.TbxSaveRamExportPath.TabIndex = 1;
            // 
            // BtnSaveRamExport
            // 
            this.BtnSaveRamExport.Location = new System.Drawing.Point(6, 19);
            this.BtnSaveRamExport.Name = "BtnSaveRamExport";
            this.BtnSaveRamExport.Size = new System.Drawing.Size(75, 23);
            this.BtnSaveRamExport.TabIndex = 0;
            this.BtnSaveRamExport.Text = "Export";
            this.BtnSaveRamExport.UseVisualStyleBackColor = true;
            this.BtnSaveRamExport.Click += new System.EventHandler(this.BtnSaveRamExport_Click);
            // 
            // CustomMainForm
            // 
            this.ClientSize = new System.Drawing.Size(784, 776);
            this.Controls.Add(this.TbcMainTabs);
            this.Name = "CustomMainForm";
            this.GbxHarry.ResumeLayout(false);
            this.GbxHarry.PerformLayout();
            this.GbxCamera.ResumeLayout(false);
            this.GbxCamera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).EndInit();
            this.TbcMainTabs.ResumeLayout(false);
            this.TbpBasics.ResumeLayout(false);
            this.GbxControls.ResumeLayout(false);
            this.GbxControls.PerformLayout();
            this.GbxOverlay.ResumeLayout(false);
            this.GbxOverlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAX)).EndInit();
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
            this.TbpSave.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHazardStripes)).EndInit();
            this.GbxConvertSaveRamToStates.ResumeLayout(false);
            this.GbxConvertSaveRamToStates.PerformLayout();
            this.GbxConvertStatesToSaveRam.ResumeLayout(false);
            this.GbxConvertStatesToSaveRam.PerformLayout();
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
		private TabControl TbcMainTabs;
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
		private CheckBox CbxEnableOverlay;
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
		private Label LblSpawnGeometry;
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
		private TabPage tabPage4;
		private Button BtnReadStrings;
		private Label LblStringCount;
		private RichTextBox RtbStrings;
		private TabPage tabPage5;
		private ListBox LbxPois;
		private Label LblPoiCount;
		private Button BtnReadPois;
		private Label LblSelectedPoiGeometry;
		private Label label35;
		private Label label38;
		private Label LblSelectedPoiZ;
		private Label LblSelectedPoiX;
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
		private TabPage TbpSave;
		private ComboBox CmbSaveButton;
		private Button BtnOpenSaveMenu;
		private GroupBox groupBox3;
		private Button BtnSaveRamExport;
		private GroupBox groupBox4;
		private Button BtnSaveRamExportBrowse;
		private TextBox TbxSaveRamExportPath;
		private Button BtnSaveRamImportBrowse;
		private TextBox TbxSaveRamImportPath;
		private Button BtnSaveRamImport;
		private Label label15;
		private Label LblSelectedTriggerPoiGeometry;
		private Label label31;
		private Label label34;
		private Label label36;
		private NumericUpDown NudOverlayTestLineBZ;
		private NumericUpDown NudOverlayTestLineBY;
		private NumericUpDown NudOverlayTestLineBX;
		private Label label16;
		private Label label17;
		private Label label20;
		private NumericUpDown NudOverlayTestLineAZ;
		private NumericUpDown NudOverlayTestLineAY;
		private NumericUpDown NudOverlayTestLineAX;
		private CheckBox CbxOverlayTestLine;
		private Label label37;
		private Label label53;
		private Label label54;
		private NumericUpDown NudOverlayTestBoxSizeZ;
		private NumericUpDown NudOverlayTestBoxSizeY;
		private NumericUpDown NudOverlayTestBoxSizeX;
		private ComboBox CmbRenderShape;
		private Button BtnClearPoisTriggers;
		private GroupBox GbxConvertSaveRamToStates;
		private GroupBox GbxConvertStatesToSaveRam;
		private PictureBox PbxHazardStripes;
		private CheckBox CbxSaveRamDanger;
		private Label label55;
		private Button BtnConvertStatesToSaveRamOutputPathBrowse;
		private TextBox TbxConvertStatesToSaveRamOutputPath;
		private Button BtnConvertStatesToSaveRamGo;
		private ListBox LbxConvertStatesToSaveRam;
		private Label label56;
		private Button BtnConvertSaveRamToStatesInputPathBrowse;
		private TextBox TbxConvertSaveRamToStatesInputPath;
		private Button BtnConvertSaveRamToStatesGo;
		private ListBox LbxConvertSaveRamToStates;
		private Button BtnConvertStatesToSaveRamRefresh;
		private Button BtnConvertSaveRamToStatesRefresh;
		private Label label57;
		private Button BtnConvertSaveRamToStatesOutputPathBrowse;
		private TextBox TbxConvertSaveRamToStatesOutputPath;
		private Label label58;
		private Button BtnConvertStatesToSaveRamInputPathBrowse;
		private TextBox TbxConvertStatesToSaveRamInputPath;
		private Label LblSelectedTriggerThing2;
		private Label label60;
	}
}
