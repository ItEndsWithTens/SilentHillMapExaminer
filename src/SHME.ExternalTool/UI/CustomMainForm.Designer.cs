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
            this.TbxHarryPitch = new System.Windows.Forms.TextBox();
            this.TbxHarryYaw = new System.Windows.Forms.TextBox();
            this.TbxHarryRoll = new System.Windows.Forms.TextBox();
            this.BtnGetAngles = new System.Windows.Forms.Button();
            this.GbxHarry = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxEnableHarrySection = new System.Windows.Forms.CheckBox();
            this.TbxPositionZ = new System.Windows.Forms.TextBox();
            this.LblHarryPositionZ = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.LblSpawnGeometry = new System.Windows.Forms.Label();
            this.LblHarryRoll = new System.Windows.Forms.Label();
            this.BtnSetAngles = new System.Windows.Forms.Button();
            this.LblHarryYaw = new System.Windows.Forms.Label();
            this.LblSpawnXZ = new System.Windows.Forms.Label();
            this.LblHarryPitch = new System.Windows.Forms.Label();
            this.CbxHarrySetPositionMoveCamera = new System.Windows.Forms.CheckBox();
            this.GbxCamera = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel25 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxCameraDetach = new System.Windows.Forms.CheckBox();
            this.LblCameraPositionZ = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.LblCameraPositionY = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblCameraPositionX = new System.Windows.Forms.Label();
            this.LblCameraDrawDistance = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.LblCameraPitch = new System.Windows.Forms.Label();
            this.LblCameraYaw = new System.Windows.Forms.Label();
            this.LblCameraRoll = new System.Windows.Forms.Label();
            this.TrkFov = new System.Windows.Forms.TrackBar();
            this.CbxCameraLockToHead = new System.Windows.Forms.CheckBox();
            this.CbxCameraFreeze = new System.Windows.Forms.CheckBox();
            this.CbxShowLookAt = new System.Windows.Forms.CheckBox();
            this.LblFov = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnGrabMapGraphic = new System.Windows.Forms.Button();
            this.PbxMapGraphic = new System.Windows.Forms.PictureBox();
            this.TbcMainTabs = new System.Windows.Forms.TabControl();
            this.TbpBasics = new System.Windows.Forms.TabPage();
            this.TlpBasics = new System.Windows.Forms.TableLayoutPanel();
            this.GbxControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.NudCameraFlySensitivity = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.CbxCameraFlyInvert = new System.Windows.Forms.CheckBox();
            this.BtnInputBinds = new System.Windows.Forms.Button();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCameraFps = new System.Windows.Forms.Button();
            this.NudEyeHeight = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.CbxAlwaysRun = new System.Windows.Forms.CheckBox();
            this.CbxShowFeet = new System.Windows.Forms.CheckBox();
            this.CbxHideHarry = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCameraFly = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NudCameraFlySpeed = new System.Windows.Forms.NumericUpDown();
            this.GbxOverlay = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxAntialiasing = new System.Windows.Forms.CheckBox();
            this.CbxFarClipping = new System.Windows.Forms.CheckBox();
            this.CbxBackfaceCulling = new System.Windows.Forms.CheckBox();
            this.LblOverlayCamRoll = new System.Windows.Forms.Label();
            this.LblOverlayCamYaw = new System.Windows.Forms.Label();
            this.LblOverlayCamPitch = new System.Windows.Forms.Label();
            this.CbxOverlayCameraMatchGame = new System.Windows.Forms.CheckBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.NudOverlayCameraZ = new System.Windows.Forms.NumericUpDown();
            this.label84 = new System.Windows.Forms.Label();
            this.NudOverlayCameraY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraX = new System.Windows.Forms.NumericUpDown();
            this.NudFilledOpacity = new System.Windows.Forms.NumericUpDown();
            this.CbxReadLevelDataOnStageLoad = new System.Windows.Forms.CheckBox();
            this.CbxEnableOverlayCameraReporting = new System.Windows.Forms.CheckBox();
            this.NudOverlayCameraPitch = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraYaw = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraRoll = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionX = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionY = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionZ = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.NudCrosshairLength = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.CbxEnableOverlay = new System.Windows.Forms.CheckBox();
            this.CmbRenderMode = new System.Windows.Forms.ComboBox();
            this.TbpPois = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel33 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel35 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnReadTriggers = new System.Windows.Forms.Button();
            this.LblTriggerCount = new System.Windows.Forms.Label();
            this.tableLayoutPanel34 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnReadPois = new System.Windows.Forms.Button();
            this.LblPoiCount = new System.Windows.Forms.Label();
            this.LbxPois = new System.Windows.Forms.ListBox();
            this.LbxTriggers = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel32 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClearPoisTriggers = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.RdoAxisColorsOff = new System.Windows.Forms.RadioButton();
            this.label68 = new System.Windows.Forms.Label();
            this.CmbPoiRenderShape = new System.Windows.Forms.ComboBox();
            this.RdoAxisColorsOverlay = new System.Windows.Forms.RadioButton();
            this.RdoAxisColorsGame = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.GbxSelectedTrigger = new System.Windows.Forms.GroupBox();
            this.CmsSelectedTrigger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmSelectedTriggerResetProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmSelectedTriggerResetAllProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.TlpSelectedTriggerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.CbxSelectedTriggerDisabled = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerAddress = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiGeometry = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing0 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing1 = new System.Windows.Forms.Label();
            this.CbxSelectedTriggerEnableUpdates = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerThing4 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing3 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiIndex = new System.Windows.Forms.Label();
            this.LblSelectedTriggerStyle = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing2 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerFiredDetails = new System.Windows.Forms.Label();
            this.LblSelectedTriggerType = new System.Windows.Forms.Label();
            this.CmbSelectedTriggerType = new System.Windows.Forms.ComboBox();
            this.NudSelectedTriggerTargetIndex = new System.Windows.Forms.NumericUpDown();
            this.LblSelectedTriggerTargetIndex = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing5 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing6 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerStageIndex = new System.Windows.Forms.Label();
            this.CbxSelectedTriggerSomeBool = new System.Windows.Forms.CheckBox();
            this.NudSelectedTriggerStageIndex = new System.Windows.Forms.NumericUpDown();
            this.MtbSelectedTriggerPoiGeometry = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing0 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing1 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing5 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing6 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing2 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing3 = new System.Windows.Forms.MaskedTextBox();
            this.MtbSelectedTriggerThing4 = new System.Windows.Forms.MaskedTextBox();
            this.NudSelectedTriggerPoiIndex = new System.Windows.Forms.NumericUpDown();
            this.CmbSelectedTriggerStyle = new System.Windows.Forms.ComboBox();
            this.CbxSelectedTriggerFired = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerFiredGroup = new System.Windows.Forms.Label();
            this.NudSelectedTriggerFiredGroup = new System.Windows.Forms.NumericUpDown();
            this.GbxSelectedPoi = new System.Windows.Forms.GroupBox();
            this.CmsSelectedPoi = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmSelectedPoiResetProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmSelectedPoiResetAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.LbxPoiAssociatedTriggers = new System.Windows.Forms.ListBox();
            this.label33 = new System.Windows.Forms.Label();
            this.BtnGoToPoi = new System.Windows.Forms.Button();
            this.LblSelectedPoiXZ = new System.Windows.Forms.Label();
            this.LblSelectedPoiAddress = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.LblSelectedPoiGeometry = new System.Windows.Forms.Label();
            this.TbxSelectedPoiX = new System.Windows.Forms.TextBox();
            this.TbxSelectedPoiZ = new System.Windows.Forms.TextBox();
            this.MtbSelectedPoiGeometry = new System.Windows.Forms.MaskedTextBox();
            this.TbpCamera = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel44 = new System.Windows.Forms.TableLayoutPanel();
            this.LbxCameraPaths = new System.Windows.Forms.ListBox();
            this.BtnClearCameraPaths = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CmsSelectedCameraPath = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmSelectedCameraPathResetProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsmSelectedCameraPathResetAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.label107 = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathYaw = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathVolumeMin = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathPitch = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathVolumeMax = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathThing6 = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathThing5 = new System.Windows.Forms.Label();
            this.BtnCameraPathGoToVolumeMin = new System.Windows.Forms.Button();
            this.BtnCameraPathGoToVolumeMax = new System.Windows.Forms.Button();
            this.LblSelectedCameraPathAreaMin = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathThing4 = new System.Windows.Forms.Label();
            this.LblSelectedCameraPathAreaMax = new System.Windows.Forms.Label();
            this.LblCameraPathAddress = new System.Windows.Forms.Label();
            this.CbxSelectedCameraPathDisabled = new System.Windows.Forms.CheckBox();
            this.TbxCameraPathVolumeMinX = new System.Windows.Forms.TextBox();
            this.TbxCameraPathVolumeMinY = new System.Windows.Forms.TextBox();
            this.TbxCameraPathVolumeMinZ = new System.Windows.Forms.TextBox();
            this.TbxCameraPathVolumeMaxX = new System.Windows.Forms.TextBox();
            this.TbxCameraPathVolumeMaxY = new System.Windows.Forms.TextBox();
            this.TbxCameraPathVolumeMaxZ = new System.Windows.Forms.TextBox();
            this.TbxCameraPathAreaMinX = new System.Windows.Forms.TextBox();
            this.TbxCameraPathAreaMinZ = new System.Windows.Forms.TextBox();
            this.TbxCameraPathAreaMaxX = new System.Windows.Forms.TextBox();
            this.TbxCameraPathAreaMaxZ = new System.Windows.Forms.TextBox();
            this.MtbCameraPathThing4 = new System.Windows.Forms.MaskedTextBox();
            this.MtbCameraPathThing5 = new System.Windows.Forms.MaskedTextBox();
            this.MtbCameraPathThing6 = new System.Windows.Forms.MaskedTextBox();
            this.TbxCameraPathPitch = new System.Windows.Forms.TextBox();
            this.TbxCameraPathYaw = new System.Windows.Forms.TextBox();
            this.LblCameraPathCount = new System.Windows.Forms.Label();
            this.BtnCameraPathReadArray = new System.Windows.Forms.Button();
            this.TbpStats = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.LblRunningDistance = new System.Windows.Forms.Label();
            this.LblTotalTime = new System.Windows.Forms.Label();
            this.LblWalkingDistance = new System.Windows.Forms.Label();
            this.LblHarryHealth = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.CbxEnableStatsReporting = new System.Windows.Forms.CheckBox();
            this.TbpMap = new System.Windows.Forms.TabPage();
            this.TbpFog = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxFog = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxCustomWorldTint = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.BtnWorldTintDefault = new System.Windows.Forms.Button();
            this.BtnCustomWorldTintCurrent = new System.Windows.Forms.Button();
            this.NudCustomWorldTintR = new System.Windows.Forms.NumericUpDown();
            this.NudCustomWorldTintG = new System.Windows.Forms.NumericUpDown();
            this.BtnWorldTintColor = new System.Windows.Forms.Button();
            this.NudCustomWorldTintB = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxCustomFog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCustomFogCurrent = new System.Windows.Forms.Button();
            this.BtnFogColorDefault = new System.Windows.Forms.Button();
            this.NudCustomFogR = new System.Windows.Forms.NumericUpDown();
            this.NudCustomFogG = new System.Windows.Forms.NumericUpDown();
            this.NudCustomFogB = new System.Windows.Forms.NumericUpDown();
            this.BtnFogColor = new System.Windows.Forms.Button();
            this.BtnFogWorldTintColorSwap = new System.Windows.Forms.Button();
            this.CbxDiscoMode = new System.Windows.Forms.CheckBox();
            this.TbpStrings = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnReadStrings = new System.Windows.Forms.Button();
            this.RtbStrings = new System.Windows.Forms.RichTextBox();
            this.LblStringCount = new System.Windows.Forms.Label();
            this.TbpSave = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.PnlSaveRamDangerArea = new System.Windows.Forms.Panel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxSaveRamDanger = new System.Windows.Forms.CheckBox();
            this.BtnSaveRamImportBrowse = new System.Windows.Forms.Button();
            this.TbxSaveRamImportPath = new System.Windows.Forms.TextBox();
            this.BtnSaveRamImport = new System.Windows.Forms.Button();
            this.GbxConvertStatesOrSaveRam = new System.Windows.Forms.GroupBox();
            this.TbcConvertStatesOrSaveRam = new System.Windows.Forms.TabControl();
            this.TbpConvertStatesToSaveRam = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.label58 = new System.Windows.Forms.Label();
            this.LbxConvertStatesToSaveRam = new System.Windows.Forms.ListBox();
            this.BtnConvertStatesToSaveRamGo = new System.Windows.Forms.Button();
            this.TbxConvertStatesToSaveRamInputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertStatesToSaveRamInputPathBrowse = new System.Windows.Forms.Button();
            this.BtnConvertStatesToSaveRamOutputPathBrowse = new System.Windows.Forms.Button();
            this.label55 = new System.Windows.Forms.Label();
            this.TbxConvertStatesToSaveRamOutputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertStatesToSaveRamRefresh = new System.Windows.Forms.Button();
            this.TbpConvertSaveRamToStates = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnConvertSaveRamToStatesOutputPathBrowse = new System.Windows.Forms.Button();
            this.label57 = new System.Windows.Forms.Label();
            this.BtnConvertSaveRamToStatesGo = new System.Windows.Forms.Button();
            this.label56 = new System.Windows.Forms.Label();
            this.TbxConvertSaveRamToStatesOutputPath = new System.Windows.Forms.TextBox();
            this.TbxConvertSaveRamToStatesInputPath = new System.Windows.Forms.TextBox();
            this.BtnConvertSaveRamToStatesInputPathBrowse = new System.Windows.Forms.Button();
            this.BtnConvertSaveRamToStatesRefresh = new System.Windows.Forms.Button();
            this.LbxConvertSaveRamToStates = new System.Windows.Forms.ListBox();
            this.PbxHazardStripes = new System.Windows.Forms.PictureBox();
            this.BtnSaveRamExport = new System.Windows.Forms.Button();
            this.TbxSaveRamExportPath = new System.Windows.Forms.TextBox();
            this.BtnSaveRamExportBrowse = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnOpenSaveMenu = new System.Windows.Forms.Button();
            this.CmbSaveButton = new System.Windows.Forms.ComboBox();
            this.TbpTest = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.CmbModelSubmeshName = new System.Windows.Forms.ComboBox();
            this.BtnReadHarryModel = new System.Windows.Forms.Button();
            this.TrkTestModelScale = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.NudTestModelX = new System.Windows.Forms.NumericUpDown();
            this.NudTestModelY = new System.Windows.Forms.NumericUpDown();
            this.NudTestModelZ = new System.Windows.Forms.NumericUpDown();
            this.LblModelX = new System.Windows.Forms.Label();
            this.LblModelY = new System.Windows.Forms.Label();
            this.LblModelZ = new System.Windows.Forms.Label();
            this.BtnTestModelSetPosition = new System.Windows.Forms.Button();
            this.BtnTestModelGetPosition = new System.Windows.Forms.Button();
            this.LblTestModelScale = new System.Windows.Forms.Label();
            this.CbxEnableTestModelSection = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.NudTestBoxSizeX = new System.Windows.Forms.NumericUpDown();
            this.NudTestBoxSizeY = new System.Windows.Forms.NumericUpDown();
            this.NudTestBoxSizeZ = new System.Windows.Forms.NumericUpDown();
            this.CbxEnableTestBox = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.NudTestBoxX = new System.Windows.Forms.NumericUpDown();
            this.NudTestBoxY = new System.Windows.Forms.NumericUpDown();
            this.NudTestBoxZ = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxEnableTestSheet = new System.Windows.Forms.CheckBox();
            this.NudTestSheetX = new System.Windows.Forms.NumericUpDown();
            this.NudTestSheetSizeX = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.NudTestSheetSizeZ = new System.Windows.Forms.NumericUpDown();
            this.NudTestSheetZ = new System.Windows.Forms.NumericUpDown();
            this.NudTestSheetY = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxEnableTestLine = new System.Windows.Forms.CheckBox();
            this.NudTestLineAX = new System.Windows.Forms.NumericUpDown();
            this.NudTestLineAY = new System.Windows.Forms.NumericUpDown();
            this.NudTestLineAZ = new System.Windows.Forms.NumericUpDown();
            this.NudTestLineBX = new System.Windows.Forms.NumericUpDown();
            this.NudTestLineBY = new System.Windows.Forms.NumericUpDown();
            this.NudTestLineBZ = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.TbpFiles = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnReadFiles = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.LbxFilesDirectories = new System.Windows.Forms.ListBox();
            this.CmsFilesDirectories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LbxFilesFiles = new System.Windows.Forms.ListBox();
            this.CmsFilesFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.extractSelectedFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TbpFramebuffer = new System.Windows.Forms.TabPage();
            this.TlpFramebufferTab = new System.Windows.Forms.TableLayoutPanel();
            this.ScrFramebuffer = new System.Windows.Forms.ScrollableControl();
            this.BpbFramebuffer = new SHME.ExternalTool.BetterPictureBox();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnFramebufferSave = new System.Windows.Forms.Button();
            this.BtnFramebufferZoomIn = new System.Windows.Forms.Button();
            this.CmbFramebufferZoom = new System.Windows.Forms.ComboBox();
            this.BtnFramebufferGrab = new System.Windows.Forms.Button();
            this.BtnFramebufferZoomOut = new System.Windows.Forms.Button();
            this.label93 = new System.Windows.Forms.Label();
            this.label89 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.NudFramebufferH = new System.Windows.Forms.NumericUpDown();
            this.NudFramebufferW = new System.Windows.Forms.NumericUpDown();
            this.label91 = new System.Windows.Forms.Label();
            this.NudFramebufferOfsX = new System.Windows.Forms.NumericUpDown();
            this.NudFramebufferOfsY = new System.Windows.Forms.NumericUpDown();
            this.TbpUtility = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TbxUtilityAnglesGameUnits = new System.Windows.Forms.TextBox();
            this.label78 = new System.Windows.Forms.Label();
            this.LblUtilityAnglesError = new System.Windows.Forms.Label();
            this.TbxUtilityAnglesDegrees = new System.Windows.Forms.TextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label71 = new System.Windows.Forms.Label();
            this.LblUtilityFixedPointError = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.TbxUtilityFixedPointQ = new System.Windows.Forms.TextBox();
            this.TbxUtilityFixedPointFloat = new System.Windows.Forms.TextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.CmbUtilityFixedPointFormat = new System.Windows.Forms.ComboBox();
            this.label73 = new System.Windows.Forms.Label();
            this.TbpMisc = new System.Windows.Forms.TabPage();
            this.GbxController = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel28 = new System.Windows.Forms.TableLayoutPanel();
            this.LblButtonR1 = new System.Windows.Forms.Label();
            this.LblButtonL1 = new System.Windows.Forms.Label();
            this.LblButtonR2 = new System.Windows.Forms.Label();
            this.LblButtonL2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel31 = new System.Windows.Forms.TableLayoutPanel();
            this.LblButtonSelect = new System.Windows.Forms.Label();
            this.LblButtonR3 = new System.Windows.Forms.Label();
            this.LblButtonStart = new System.Windows.Forms.Label();
            this.LblButtonL3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel30 = new System.Windows.Forms.TableLayoutPanel();
            this.LblButtonTriangle = new System.Windows.Forms.Label();
            this.LblButtonSquare = new System.Windows.Forms.Label();
            this.LblButtonCircle = new System.Windows.Forms.Label();
            this.LblButtonX = new System.Windows.Forms.Label();
            this.CbxEnableControllerReporting = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.LblButtonUp = new System.Windows.Forms.Label();
            this.LblButtonLeft = new System.Windows.Forms.Label();
            this.LblButtonRight = new System.Windows.Forms.Label();
            this.LblButtonDown = new System.Windows.Forms.Label();
            this.TbpSettings = new System.Windows.Forms.TabPage();
            this.TlpSettings = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSettingsResetAll = new System.Windows.Forms.Button();
            this.GbxSettingsFiles = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel40 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnSettingsSaveCopies = new System.Windows.Forms.Button();
            this.BtnSettingsGoRoaming = new System.Windows.Forms.Button();
            this.BtnSettingsGoLocal = new System.Windows.Forms.Button();
            this.TbxSettingsFilesRoaming = new System.Windows.Forms.TextBox();
            this.LblSettingsLocal = new System.Windows.Forms.Label();
            this.LblSettingsRoaming = new System.Windows.Forms.Label();
            this.TbxSettingsFilesLocal = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel42 = new System.Windows.Forms.TableLayoutPanel();
            this.GbxOverlayDisplaySurface = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel41 = new System.Windows.Forms.TableLayoutPanel();
            this.RdoOverlayDisplaySurfaceFramebuffer = new System.Windows.Forms.RadioButton();
            this.RdoOverlayDisplaySurfaceClient = new System.Windows.Forms.RadioButton();
            this.RdoOverlayDisplaySurfaceEmuCore = new System.Windows.Forms.RadioButton();
            this.GbxOverlayBackend = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel43 = new System.Windows.Forms.TableLayoutPanel();
            this.RdoBackendBitmap = new System.Windows.Forms.RadioButton();
            this.RdoBackendBizHawkGui = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GbxHarry.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            this.GbxCamera.SuspendLayout();
            this.tableLayoutPanel25.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).BeginInit();
            this.TbcMainTabs.SuspendLayout();
            this.TbpBasics.SuspendLayout();
            this.TlpBasics.SuspendLayout();
            this.GbxControls.SuspendLayout();
            this.tableLayoutPanel39.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCameraFlySensitivity)).BeginInit();
            this.tableLayoutPanel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudEyeHeight)).BeginInit();
            this.tableLayoutPanel27.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCameraFlySpeed)).BeginInit();
            this.GbxOverlay.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFilledOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraRoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCrosshairLength)).BeginInit();
            this.TbpPois.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel33.SuspendLayout();
            this.tableLayoutPanel35.SuspendLayout();
            this.tableLayoutPanel34.SuspendLayout();
            this.tableLayoutPanel32.SuspendLayout();
            this.tableLayoutPanel37.SuspendLayout();
            this.GbxSelectedTrigger.SuspendLayout();
            this.CmsSelectedTrigger.SuspendLayout();
            this.TlpSelectedTriggerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerStageIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerPoiIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerFiredGroup)).BeginInit();
            this.GbxSelectedPoi.SuspendLayout();
            this.CmsSelectedPoi.SuspendLayout();
            this.tableLayoutPanel36.SuspendLayout();
            this.TbpCamera.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel44.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.CmsSelectedCameraPath.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.TbpStats.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.TbpMap.SuspendLayout();
            this.TbpFog.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintB)).BeginInit();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogB)).BeginInit();
            this.TbpStrings.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.TbpSave.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.PnlSaveRamDangerArea.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            this.GbxConvertStatesOrSaveRam.SuspendLayout();
            this.TbcConvertStatesOrSaveRam.SuspendLayout();
            this.TbpConvertStatesToSaveRam.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.TbpConvertSaveRamToStates.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHazardStripes)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.TbpTest.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkTestModelScale)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelZ)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxZ)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetY)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBZ)).BeginInit();
            this.TbpFiles.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.CmsFilesDirectories.SuspendLayout();
            this.CmsFilesFiles.SuspendLayout();
            this.TbpFramebuffer.SuspendLayout();
            this.TlpFramebufferTab.SuspendLayout();
            this.ScrFramebuffer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BpbFramebuffer)).BeginInit();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferOfsX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferOfsY)).BeginInit();
            this.TbpUtility.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.TbpMisc.SuspendLayout();
            this.GbxController.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.tableLayoutPanel28.SuspendLayout();
            this.tableLayoutPanel31.SuspendLayout();
            this.tableLayoutPanel30.SuspendLayout();
            this.tableLayoutPanel29.SuspendLayout();
            this.TbpSettings.SuspendLayout();
            this.TlpSettings.SuspendLayout();
            this.GbxSettingsFiles.SuspendLayout();
            this.tableLayoutPanel40.SuspendLayout();
            this.tableLayoutPanel42.SuspendLayout();
            this.GbxOverlayDisplaySurface.SuspendLayout();
            this.tableLayoutPanel41.SuspendLayout();
            this.GbxOverlayBackend.SuspendLayout();
            this.tableLayoutPanel43.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnGetPosition
            // 
            this.BtnGetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGetPosition.AutoSize = true;
            this.BtnGetPosition.Location = new System.Drawing.Point(3, 34);
            this.BtnGetPosition.Name = "BtnGetPosition";
            this.BtnGetPosition.Size = new System.Drawing.Size(75, 25);
            this.BtnGetPosition.TabIndex = 5;
            this.BtnGetPosition.Text = "Get";
            this.BtnGetPosition.UseVisualStyleBackColor = true;
            this.BtnGetPosition.Click += new System.EventHandler(this.BtnGetPosition_Click);
            // 
            // BtnSetPosition
            // 
            this.BtnSetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSetPosition.AutoSize = true;
            this.BtnSetPosition.Location = new System.Drawing.Point(250, 34);
            this.BtnSetPosition.Name = "BtnSetPosition";
            this.BtnSetPosition.Size = new System.Drawing.Size(75, 25);
            this.BtnSetPosition.TabIndex = 40;
            this.BtnSetPosition.Text = "Set";
            this.BtnSetPosition.UseVisualStyleBackColor = true;
            this.BtnSetPosition.Click += new System.EventHandler(this.BtnSetPosition_Click);
            // 
            // TbxPositionX
            // 
            this.TbxPositionX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxPositionX.Location = new System.Drawing.Point(84, 36);
            this.TbxPositionX.Name = "TbxPositionX";
            this.TbxPositionX.Size = new System.Drawing.Size(49, 20);
            this.TbxPositionX.TabIndex = 15;
            this.TbxPositionX.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxPosition_KeyDown);
            // 
            // TbxPositionY
            // 
            this.TbxPositionY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxPositionY.Location = new System.Drawing.Point(139, 36);
            this.TbxPositionY.Name = "TbxPositionY";
            this.TbxPositionY.Size = new System.Drawing.Size(49, 20);
            this.TbxPositionY.TabIndex = 25;
            this.TbxPositionY.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxPosition_KeyDown);
            // 
            // LblHarryPositionX
            // 
            this.LblHarryPositionX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPositionX.Location = new System.Drawing.Point(86, 16);
            this.LblHarryPositionX.Name = "LblHarryPositionX";
            this.LblHarryPositionX.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPositionX.TabIndex = 10;
            this.LblHarryPositionX.Text = "<xxxxx>";
            this.LblHarryPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblHarryPositionY
            // 
            this.LblHarryPositionY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPositionY.Location = new System.Drawing.Point(141, 16);
            this.LblHarryPositionY.Name = "LblHarryPositionY";
            this.LblHarryPositionY.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPositionY.TabIndex = 20;
            this.LblHarryPositionY.Text = "<yyyyy>";
            this.LblHarryPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxHarryPitch
            // 
            this.TbxHarryPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxHarryPitch.Location = new System.Drawing.Point(84, 129);
            this.TbxHarryPitch.Name = "TbxHarryPitch";
            this.TbxHarryPitch.Size = new System.Drawing.Size(49, 20);
            this.TbxHarryPitch.TabIndex = 65;
            this.TbxHarryPitch.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryPitch.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryPitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxAngles_KeyDown);
            // 
            // TbxHarryYaw
            // 
            this.TbxHarryYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxHarryYaw.Location = new System.Drawing.Point(139, 129);
            this.TbxHarryYaw.Name = "TbxHarryYaw";
            this.TbxHarryYaw.Size = new System.Drawing.Size(49, 20);
            this.TbxHarryYaw.TabIndex = 75;
            this.TbxHarryYaw.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryYaw.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryYaw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxAngles_KeyDown);
            // 
            // TbxHarryRoll
            // 
            this.TbxHarryRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxHarryRoll.Location = new System.Drawing.Point(194, 129);
            this.TbxHarryRoll.Name = "TbxHarryRoll";
            this.TbxHarryRoll.Size = new System.Drawing.Size(49, 20);
            this.TbxHarryRoll.TabIndex = 85;
            this.TbxHarryRoll.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryRoll.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxHarryRoll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxAngles_KeyDown);
            // 
            // BtnGetAngles
            // 
            this.BtnGetAngles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGetAngles.AutoSize = true;
            this.BtnGetAngles.Location = new System.Drawing.Point(3, 127);
            this.BtnGetAngles.Name = "BtnGetAngles";
            this.BtnGetAngles.Size = new System.Drawing.Size(75, 25);
            this.BtnGetAngles.TabIndex = 55;
            this.BtnGetAngles.Text = "Get";
            this.BtnGetAngles.UseVisualStyleBackColor = true;
            this.BtnGetAngles.Click += new System.EventHandler(this.BtnGetAngles_Click);
            // 
            // GbxHarry
            // 
            this.GbxHarry.AutoSize = true;
            this.GbxHarry.Controls.Add(this.tableLayoutPanel24);
            this.GbxHarry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxHarry.Location = new System.Drawing.Point(3, 3);
            this.GbxHarry.Name = "GbxHarry";
            this.GbxHarry.Size = new System.Drawing.Size(335, 300);
            this.GbxHarry.TabIndex = 0;
            this.GbxHarry.TabStop = false;
            this.GbxHarry.Text = "Harry";
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 5;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel24.Controls.Add(this.CbxEnableHarrySection, 4, 8);
            this.tableLayoutPanel24.Controls.Add(this.TbxPositionX, 1, 1);
            this.tableLayoutPanel24.Controls.Add(this.TbxPositionZ, 3, 1);
            this.tableLayoutPanel24.Controls.Add(this.TbxPositionY, 2, 1);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryPositionZ, 3, 0);
            this.tableLayoutPanel24.Controls.Add(this.label59, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.label61, 0, 3);
            this.tableLayoutPanel24.Controls.Add(this.label18, 0, 7);
            this.tableLayoutPanel24.Controls.Add(this.label19, 0, 8);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryPositionY, 2, 0);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryPositionX, 1, 0);
            this.tableLayoutPanel24.Controls.Add(this.LblSpawnGeometry, 2, 8);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryRoll, 3, 3);
            this.tableLayoutPanel24.Controls.Add(this.BtnSetAngles, 4, 4);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryYaw, 2, 3);
            this.tableLayoutPanel24.Controls.Add(this.LblSpawnXZ, 2, 7);
            this.tableLayoutPanel24.Controls.Add(this.LblHarryPitch, 1, 3);
            this.tableLayoutPanel24.Controls.Add(this.BtnGetAngles, 0, 4);
            this.tableLayoutPanel24.Controls.Add(this.TbxHarryYaw, 2, 4);
            this.tableLayoutPanel24.Controls.Add(this.TbxHarryPitch, 1, 4);
            this.tableLayoutPanel24.Controls.Add(this.TbxHarryRoll, 3, 4);
            this.tableLayoutPanel24.Controls.Add(this.BtnGetPosition, 0, 1);
            this.tableLayoutPanel24.Controls.Add(this.BtnSetPosition, 4, 1);
            this.tableLayoutPanel24.Controls.Add(this.CbxHarrySetPositionMoveCamera, 3, 2);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 9;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(329, 281);
            this.tableLayoutPanel24.TabIndex = 0;
            // 
            // CbxEnableHarrySection
            // 
            this.CbxEnableHarrySection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableHarrySection.AutoSize = true;
            this.CbxEnableHarrySection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableHarrySection.Checked = true;
            this.CbxEnableHarrySection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEnableHarrySection.Location = new System.Drawing.Point(267, 261);
            this.CbxEnableHarrySection.Name = "CbxEnableHarrySection";
            this.CbxEnableHarrySection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableHarrySection.TabIndex = 0;
            this.CbxEnableHarrySection.Text = "Enable";
            this.CbxEnableHarrySection.UseVisualStyleBackColor = true;
            // 
            // TbxPositionZ
            // 
            this.TbxPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxPositionZ.Location = new System.Drawing.Point(194, 36);
            this.TbxPositionZ.Name = "TbxPositionZ";
            this.TbxPositionZ.Size = new System.Drawing.Size(49, 20);
            this.TbxPositionZ.TabIndex = 35;
            this.TbxPositionZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxPositionZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxPosition_KeyDown);
            // 
            // LblHarryPositionZ
            // 
            this.LblHarryPositionZ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPositionZ.Location = new System.Drawing.Point(196, 16);
            this.LblHarryPositionZ.Name = "LblHarryPositionZ";
            this.LblHarryPositionZ.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPositionZ.TabIndex = 30;
            this.LblHarryPositionZ.Text = "<zzzzz>";
            this.LblHarryPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(18, 9);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(44, 13);
            this.label59.TabIndex = 3;
            this.label59.Text = "Position";
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(21, 102);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(39, 13);
            this.label61.TabIndex = 50;
            this.label61.Text = "Angles";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label18.AutoSize = true;
            this.tableLayoutPanel24.SetColumnSpan(this.label18, 2);
            this.label18.Location = new System.Drawing.Point(52, 226);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(81, 13);
            this.label18.TabIndex = 95;
            this.label18.Text = "Last spawn XZ:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label19.AutoSize = true;
            this.tableLayoutPanel24.SetColumnSpan(this.label19, 2);
            this.label19.Location = new System.Drawing.Point(23, 258);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 13);
            this.label19.TabIndex = 105;
            this.label19.Text = "Last spawn geometry:";
            // 
            // LblSpawnGeometry
            // 
            this.LblSpawnGeometry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSpawnGeometry.AutoSize = true;
            this.tableLayoutPanel24.SetColumnSpan(this.LblSpawnGeometry, 2);
            this.LblSpawnGeometry.Location = new System.Drawing.Point(139, 258);
            this.LblSpawnGeometry.Name = "LblSpawnGeometry";
            this.LblSpawnGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSpawnGeometry.TabIndex = 110;
            this.LblSpawnGeometry.Text = "<geometry>";
            // 
            // LblHarryRoll
            // 
            this.LblHarryRoll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryRoll.Location = new System.Drawing.Point(196, 109);
            this.LblHarryRoll.Name = "LblHarryRoll";
            this.LblHarryRoll.Size = new System.Drawing.Size(45, 15);
            this.LblHarryRoll.TabIndex = 80;
            this.LblHarryRoll.Text = "<roll>";
            this.LblHarryRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSetAngles
            // 
            this.BtnSetAngles.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSetAngles.AutoSize = true;
            this.BtnSetAngles.Location = new System.Drawing.Point(250, 127);
            this.BtnSetAngles.Name = "BtnSetAngles";
            this.BtnSetAngles.Size = new System.Drawing.Size(75, 25);
            this.BtnSetAngles.TabIndex = 90;
            this.BtnSetAngles.Text = "Set";
            this.BtnSetAngles.UseVisualStyleBackColor = true;
            this.BtnSetAngles.Click += new System.EventHandler(this.BtnSetAngles_Click);
            // 
            // LblHarryYaw
            // 
            this.LblHarryYaw.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryYaw.Location = new System.Drawing.Point(141, 109);
            this.LblHarryYaw.Name = "LblHarryYaw";
            this.LblHarryYaw.Size = new System.Drawing.Size(45, 15);
            this.LblHarryYaw.TabIndex = 70;
            this.LblHarryYaw.Text = "<yaw>";
            this.LblHarryYaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSpawnXZ
            // 
            this.LblSpawnXZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSpawnXZ.AutoSize = true;
            this.tableLayoutPanel24.SetColumnSpan(this.LblSpawnXZ, 3);
            this.LblSpawnXZ.Location = new System.Drawing.Point(139, 226);
            this.LblSpawnXZ.Name = "LblSpawnXZ";
            this.LblSpawnXZ.Size = new System.Drawing.Size(117, 13);
            this.LblSpawnXZ.TabIndex = 100;
            this.LblSpawnXZ.Text = "PLACEHOLDER TEXT";
            // 
            // LblHarryPitch
            // 
            this.LblHarryPitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPitch.Location = new System.Drawing.Point(86, 109);
            this.LblHarryPitch.Name = "LblHarryPitch";
            this.LblHarryPitch.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPitch.TabIndex = 60;
            this.LblHarryPitch.Text = "<pitch>";
            this.LblHarryPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CbxHarrySetPositionMoveCamera
            // 
            this.CbxHarrySetPositionMoveCamera.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxHarrySetPositionMoveCamera.AutoSize = true;
            this.CbxHarrySetPositionMoveCamera.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxHarrySetPositionMoveCamera.Checked = true;
            this.CbxHarrySetPositionMoveCamera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel24.SetColumnSpan(this.CbxHarrySetPositionMoveCamera, 2);
            this.CbxHarrySetPositionMoveCamera.Location = new System.Drawing.Point(235, 69);
            this.CbxHarrySetPositionMoveCamera.Name = "CbxHarrySetPositionMoveCamera";
            this.CbxHarrySetPositionMoveCamera.Size = new System.Drawing.Size(91, 17);
            this.CbxHarrySetPositionMoveCamera.TabIndex = 45;
            this.CbxHarrySetPositionMoveCamera.Text = "Move camera";
            this.CbxHarrySetPositionMoveCamera.UseVisualStyleBackColor = true;
            // 
            // GbxCamera
            // 
            this.GbxCamera.AutoSize = true;
            this.GbxCamera.Controls.Add(this.tableLayoutPanel25);
            this.GbxCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxCamera.Location = new System.Drawing.Point(344, 3);
            this.GbxCamera.Name = "GbxCamera";
            this.GbxCamera.Size = new System.Drawing.Size(335, 300);
            this.GbxCamera.TabIndex = 5;
            this.GbxCamera.TabStop = false;
            this.GbxCamera.Text = "Game camera";
            // 
            // tableLayoutPanel25
            // 
            this.tableLayoutPanel25.ColumnCount = 5;
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel25.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel25.Controls.Add(this.CbxCameraDetach, 0, 4);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraPositionZ, 1, 3);
            this.tableLayoutPanel25.Controls.Add(this.label63, 0, 2);
            this.tableLayoutPanel25.Controls.Add(this.label62, 0, 1);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraPositionY, 1, 2);
            this.tableLayoutPanel25.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel25.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraPositionX, 1, 1);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraDrawDistance, 4, 0);
            this.tableLayoutPanel25.Controls.Add(this.label64, 0, 3);
            this.tableLayoutPanel25.Controls.Add(this.label67, 2, 3);
            this.tableLayoutPanel25.Controls.Add(this.label66, 2, 2);
            this.tableLayoutPanel25.Controls.Add(this.label65, 2, 1);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraPitch, 3, 1);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraYaw, 3, 2);
            this.tableLayoutPanel25.Controls.Add(this.LblCameraRoll, 3, 3);
            this.tableLayoutPanel25.Controls.Add(this.TrkFov, 0, 7);
            this.tableLayoutPanel25.Controls.Add(this.CbxCameraLockToHead, 0, 6);
            this.tableLayoutPanel25.Controls.Add(this.CbxCameraFreeze, 0, 5);
            this.tableLayoutPanel25.Controls.Add(this.CbxShowLookAt, 3, 4);
            this.tableLayoutPanel25.Controls.Add(this.LblFov, 2, 6);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 8;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.Size = new System.Drawing.Size(329, 281);
            this.tableLayoutPanel25.TabIndex = 0;
            // 
            // CbxCameraDetach
            // 
            this.CbxCameraDetach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbxCameraDetach.AutoSize = true;
            this.CbxCameraDetach.Location = new System.Drawing.Point(3, 150);
            this.CbxCameraDetach.Name = "CbxCameraDetach";
            this.CbxCameraDetach.Size = new System.Drawing.Size(61, 17);
            this.CbxCameraDetach.TabIndex = 75;
            this.CbxCameraDetach.Text = "Detach";
            this.CbxCameraDetach.UseVisualStyleBackColor = true;
            this.CbxCameraDetach.CheckedChanged += new System.EventHandler(this.CbxCameraDetach_CheckedChanged);
            // 
            // LblCameraPositionZ
            // 
            this.LblCameraPositionZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionZ.Location = new System.Drawing.Point(70, 111);
            this.LblCameraPositionZ.Name = "LblCameraPositionZ";
            this.LblCameraPositionZ.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionZ.TabIndex = 40;
            this.LblCameraPositionZ.Text = "<z>";
            this.LblCameraPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.LblCameraPositionZ, "The game camera\'s position in SH coordinates");
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(47, 78);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(17, 13);
            this.label63.TabIndex = 25;
            this.label63.Text = "Y:";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(47, 44);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(17, 13);
            this.label62.TabIndex = 15;
            this.label62.Text = "X:";
            // 
            // LblCameraPositionY
            // 
            this.LblCameraPositionY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionY.Location = new System.Drawing.Point(70, 77);
            this.LblCameraPositionY.Name = "LblCameraPositionY";
            this.LblCameraPositionY.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionY.TabIndex = 30;
            this.LblCameraPositionY.Text = "<y>";
            this.LblCameraPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.LblCameraPositionY, "The game camera\'s position in SH coordinates");
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.tableLayoutPanel25.SetColumnSpan(this.label13, 2);
            this.label13.Location = new System.Drawing.Point(192, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Draw distance:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel25.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "X east, Y down, Z north";
            this.toolTip1.SetToolTip(this.label1, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblCameraPositionX
            // 
            this.LblCameraPositionX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionX.Location = new System.Drawing.Point(70, 43);
            this.LblCameraPositionX.Name = "LblCameraPositionX";
            this.LblCameraPositionX.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionX.TabIndex = 20;
            this.LblCameraPositionX.Text = "<x>";
            this.LblCameraPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.LblCameraPositionX, "The game camera\'s position in SH coordinates");
            // 
            // LblCameraDrawDistance
            // 
            this.LblCameraDrawDistance.Location = new System.Drawing.Point(276, 0);
            this.LblCameraDrawDistance.Name = "LblCameraDrawDistance";
            this.LblCameraDrawDistance.Size = new System.Drawing.Size(50, 15);
            this.LblCameraDrawDistance.TabIndex = 10;
            this.LblCameraDrawDistance.Text = "<meters>";
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(47, 112);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(17, 13);
            this.label64.TabIndex = 35;
            this.label64.Text = "Z:";
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(145, 112);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(28, 13);
            this.label67.TabIndex = 65;
            this.label67.Text = "Roll:";
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(142, 78);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(31, 13);
            this.label66.TabIndex = 55;
            this.label66.Text = "Yaw:";
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(139, 44);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(34, 13);
            this.label65.TabIndex = 45;
            this.label65.Text = "Pitch:";
            // 
            // LblCameraPitch
            // 
            this.LblCameraPitch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraPitch, 2);
            this.LblCameraPitch.Location = new System.Drawing.Point(179, 43);
            this.LblCameraPitch.Name = "LblCameraPitch";
            this.LblCameraPitch.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPitch.TabIndex = 50;
            this.LblCameraPitch.Text = "<pitch>";
            this.LblCameraPitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCameraYaw
            // 
            this.LblCameraYaw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraYaw, 2);
            this.LblCameraYaw.Location = new System.Drawing.Point(179, 77);
            this.LblCameraYaw.Name = "LblCameraYaw";
            this.LblCameraYaw.Size = new System.Drawing.Size(45, 15);
            this.LblCameraYaw.TabIndex = 60;
            this.LblCameraYaw.Text = "<yaw>";
            this.LblCameraYaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCameraRoll
            // 
            this.LblCameraRoll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraRoll, 2);
            this.LblCameraRoll.Location = new System.Drawing.Point(179, 111);
            this.LblCameraRoll.Name = "LblCameraRoll";
            this.LblCameraRoll.Size = new System.Drawing.Size(45, 15);
            this.LblCameraRoll.TabIndex = 70;
            this.LblCameraRoll.Text = "<roll>";
            this.LblCameraRoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TrkFov
            // 
            this.TrkFov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel25.SetColumnSpan(this.TrkFov, 5);
            this.TrkFov.Location = new System.Drawing.Point(3, 231);
            this.TrkFov.Maximum = 120;
            this.TrkFov.Minimum = 1;
            this.TrkFov.Name = "TrkFov";
            this.TrkFov.Size = new System.Drawing.Size(323, 45);
            this.TrkFov.TabIndex = 100;
            this.toolTip1.SetToolTip(this.TrkFov, "Vertical FOV, in degrees");
            this.TrkFov.Value = 1;
            this.TrkFov.Scroll += new System.EventHandler(this.TrkFov_Scroll);
            // 
            // CbxCameraLockToHead
            // 
            this.CbxCameraLockToHead.AutoSize = true;
            this.tableLayoutPanel25.SetColumnSpan(this.CbxCameraLockToHead, 2);
            this.CbxCameraLockToHead.Location = new System.Drawing.Point(3, 196);
            this.CbxCameraLockToHead.Name = "CbxCameraLockToHead";
            this.CbxCameraLockToHead.Size = new System.Drawing.Size(89, 17);
            this.CbxCameraLockToHead.TabIndex = 85;
            this.CbxCameraLockToHead.Text = "Lock to head";
            this.CbxCameraLockToHead.UseVisualStyleBackColor = true;
            // 
            // CbxCameraFreeze
            // 
            this.CbxCameraFreeze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraFreeze.AutoSize = true;
            this.CbxCameraFreeze.Location = new System.Drawing.Point(3, 173);
            this.CbxCameraFreeze.Name = "CbxCameraFreeze";
            this.CbxCameraFreeze.Size = new System.Drawing.Size(58, 17);
            this.CbxCameraFreeze.TabIndex = 80;
            this.CbxCameraFreeze.Text = "Freeze";
            this.CbxCameraFreeze.UseVisualStyleBackColor = true;
            this.CbxCameraFreeze.CheckedChanged += new System.EventHandler(this.CbxCameraFreeze_CheckedChanged);
            // 
            // CbxShowLookAt
            // 
            this.CbxShowLookAt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxShowLookAt.AutoSize = true;
            this.CbxShowLookAt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel25.SetColumnSpan(this.CbxShowLookAt, 2);
            this.CbxShowLookAt.Location = new System.Drawing.Point(238, 150);
            this.CbxShowLookAt.Name = "CbxShowLookAt";
            this.CbxShowLookAt.Size = new System.Drawing.Size(88, 17);
            this.CbxShowLookAt.TabIndex = 90;
            this.CbxShowLookAt.Text = "Show look at";
            this.toolTip1.SetToolTip(this.CbxShowLookAt, "Whether to draw directly on the game\'s framebuffer instead of BizHawk\'s GUI. Curr" +
        "ently available only in the Octoshock core.");
            this.CbxShowLookAt.UseVisualStyleBackColor = true;
            // 
            // LblFov
            // 
            this.LblFov.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblFov.Location = new System.Drawing.Point(128, 212);
            this.LblFov.Name = "LblFov";
            this.LblFov.Size = new System.Drawing.Size(45, 15);
            this.LblFov.TabIndex = 95;
            this.LblFov.Text = "1";
            this.LblFov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LblFov, "Vertical FOV, in degrees");
            // 
            // BtnGrabMapGraphic
            // 
            this.BtnGrabMapGraphic.AutoSize = true;
            this.BtnGrabMapGraphic.Location = new System.Drawing.Point(6, 492);
            this.BtnGrabMapGraphic.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGrabMapGraphic.Name = "BtnGrabMapGraphic";
            this.BtnGrabMapGraphic.Size = new System.Drawing.Size(125, 25);
            this.BtnGrabMapGraphic.TabIndex = 0;
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
            this.TbcMainTabs.Controls.Add(this.TbpBasics);
            this.TbcMainTabs.Controls.Add(this.TbpPois);
            this.TbcMainTabs.Controls.Add(this.TbpCamera);
            this.TbcMainTabs.Controls.Add(this.TbpStats);
            this.TbcMainTabs.Controls.Add(this.TbpMap);
            this.TbcMainTabs.Controls.Add(this.TbpFog);
            this.TbcMainTabs.Controls.Add(this.TbpStrings);
            this.TbcMainTabs.Controls.Add(this.TbpSave);
            this.TbcMainTabs.Controls.Add(this.TbpTest);
            this.TbcMainTabs.Controls.Add(this.TbpFiles);
            this.TbcMainTabs.Controls.Add(this.TbpFramebuffer);
            this.TbcMainTabs.Controls.Add(this.TbpUtility);
            this.TbcMainTabs.Controls.Add(this.TbpMisc);
            this.TbcMainTabs.Controls.Add(this.TbpSettings);
            this.TbcMainTabs.Location = new System.Drawing.Point(0, 0);
            this.TbcMainTabs.Margin = new System.Windows.Forms.Padding(0);
            this.TbcMainTabs.Name = "TbcMainTabs";
            this.TbcMainTabs.SelectedIndex = 0;
            this.TbcMainTabs.Size = new System.Drawing.Size(696, 644);
            this.TbcMainTabs.TabIndex = 17;
            // 
            // TbpBasics
            // 
            this.TbpBasics.Controls.Add(this.TlpBasics);
            this.TbpBasics.Location = new System.Drawing.Point(4, 22);
            this.TbpBasics.Name = "TbpBasics";
            this.TbpBasics.Padding = new System.Windows.Forms.Padding(3);
            this.TbpBasics.Size = new System.Drawing.Size(688, 618);
            this.TbpBasics.TabIndex = 0;
            this.TbpBasics.Text = "Basics";
            this.TbpBasics.UseVisualStyleBackColor = true;
            // 
            // TlpBasics
            // 
            this.TlpBasics.ColumnCount = 2;
            this.TlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpBasics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpBasics.Controls.Add(this.GbxCamera, 1, 0);
            this.TlpBasics.Controls.Add(this.GbxHarry, 0, 0);
            this.TlpBasics.Controls.Add(this.GbxControls, 0, 1);
            this.TlpBasics.Controls.Add(this.GbxOverlay, 1, 1);
            this.TlpBasics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpBasics.Location = new System.Drawing.Point(3, 3);
            this.TlpBasics.Margin = new System.Windows.Forms.Padding(0);
            this.TlpBasics.Name = "TlpBasics";
            this.TlpBasics.RowCount = 2;
            this.TlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpBasics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TlpBasics.Size = new System.Drawing.Size(682, 612);
            this.TlpBasics.TabIndex = 17;
            // 
            // GbxControls
            // 
            this.GbxControls.AutoSize = true;
            this.GbxControls.Controls.Add(this.tableLayoutPanel39);
            this.GbxControls.Controls.Add(this.tableLayoutPanel38);
            this.GbxControls.Controls.Add(this.tableLayoutPanel27);
            this.GbxControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxControls.Location = new System.Drawing.Point(3, 309);
            this.GbxControls.Name = "GbxControls";
            this.GbxControls.Size = new System.Drawing.Size(335, 300);
            this.GbxControls.TabIndex = 10;
            this.GbxControls.TabStop = false;
            this.GbxControls.Text = "Controls";
            // 
            // tableLayoutPanel39
            // 
            this.tableLayoutPanel39.ColumnCount = 4;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.Controls.Add(this.NudCameraFlySensitivity, 3, 1);
            this.tableLayoutPanel39.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel39.Controls.Add(this.CbxCameraFlyInvert, 1, 1);
            this.tableLayoutPanel39.Controls.Add(this.BtnInputBinds, 0, 1);
            this.tableLayoutPanel39.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel39.Location = new System.Drawing.Point(3, 72);
            this.tableLayoutPanel39.Name = "tableLayoutPanel39";
            this.tableLayoutPanel39.RowCount = 3;
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel39.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel39.Size = new System.Drawing.Size(329, 165);
            this.tableLayoutPanel39.TabIndex = 5;
            // 
            // NudCameraFlySensitivity
            // 
            this.NudCameraFlySensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudCameraFlySensitivity.DecimalPlaces = 2;
            this.NudCameraFlySensitivity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.NudCameraFlySensitivity.Location = new System.Drawing.Point(266, 72);
            this.NudCameraFlySensitivity.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NudCameraFlySensitivity.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NudCameraFlySensitivity.Name = "NudCameraFlySensitivity";
            this.NudCameraFlySensitivity.Size = new System.Drawing.Size(60, 20);
            this.NudCameraFlySensitivity.TabIndex = 11;
            this.NudCameraFlySensitivity.ValueChanged += new System.EventHandler(this.NudCameraFlySensitivity_ValueChanged);
            this.NudCameraFlySensitivity.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCameraFlySensitivity.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCameraFlySensitivity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCameraFlySensitivity.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Sensitivity";
            this.toolTip1.SetToolTip(this.label4, "Mouse sensitivity, as an arbitrary multiplier");
            // 
            // CbxCameraFlyInvert
            // 
            this.CbxCameraFlyInvert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraFlyInvert.AutoSize = true;
            this.CbxCameraFlyInvert.Location = new System.Drawing.Point(84, 73);
            this.CbxCameraFlyInvert.Name = "CbxCameraFlyInvert";
            this.CbxCameraFlyInvert.Size = new System.Drawing.Size(53, 17);
            this.CbxCameraFlyInvert.TabIndex = 0;
            this.CbxCameraFlyInvert.Text = "Invert";
            this.CbxCameraFlyInvert.UseVisualStyleBackColor = true;
            // 
            // BtnInputBinds
            // 
            this.BtnInputBinds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnInputBinds.Location = new System.Drawing.Point(3, 57);
            this.BtnInputBinds.Name = "BtnInputBinds";
            this.BtnInputBinds.Size = new System.Drawing.Size(75, 50);
            this.BtnInputBinds.TabIndex = 12;
            this.BtnInputBinds.Text = "Input binds";
            this.BtnInputBinds.UseVisualStyleBackColor = true;
            this.BtnInputBinds.Click += new System.EventHandler(this.BtnInputBinds_Click);
            // 
            // tableLayoutPanel38
            // 
            this.tableLayoutPanel38.AutoSize = true;
            this.tableLayoutPanel38.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel38.ColumnCount = 5;
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel38.Controls.Add(this.BtnCameraFps, 0, 0);
            this.tableLayoutPanel38.Controls.Add(this.NudEyeHeight, 4, 0);
            this.tableLayoutPanel38.Controls.Add(this.label48, 3, 0);
            this.tableLayoutPanel38.Controls.Add(this.CbxAlwaysRun, 3, 1);
            this.tableLayoutPanel38.Controls.Add(this.CbxShowFeet, 1, 1);
            this.tableLayoutPanel38.Controls.Add(this.CbxHideHarry, 1, 0);
            this.tableLayoutPanel38.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel38.Location = new System.Drawing.Point(3, 237);
            this.tableLayoutPanel38.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel38.Name = "tableLayoutPanel38";
            this.tableLayoutPanel38.RowCount = 2;
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel38.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel38.Size = new System.Drawing.Size(329, 60);
            this.tableLayoutPanel38.TabIndex = 10;
            // 
            // BtnCameraFps
            // 
            this.BtnCameraFps.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraFps.AutoSize = true;
            this.BtnCameraFps.Location = new System.Drawing.Point(3, 5);
            this.BtnCameraFps.Name = "BtnCameraFps";
            this.tableLayoutPanel38.SetRowSpan(this.BtnCameraFps, 2);
            this.BtnCameraFps.Size = new System.Drawing.Size(75, 50);
            this.BtnCameraFps.TabIndex = 0;
            this.BtnCameraFps.Text = "First person";
            this.toolTip1.SetToolTip(this.BtnCameraFps, "Enter first person mode");
            this.BtnCameraFps.UseVisualStyleBackColor = true;
            this.BtnCameraFps.Click += new System.EventHandler(this.BtnCameraFps_ClickFirst);
            this.BtnCameraFps.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFps_KeyDown);
            this.BtnCameraFps.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFps_KeyUp);
            this.BtnCameraFps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnCameraFps_MouseDown);
            this.BtnCameraFps.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnCameraFps_MouseUp);
            // 
            // NudEyeHeight
            // 
            this.NudEyeHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudEyeHeight.DecimalPlaces = 2;
            this.NudEyeHeight.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.NudEyeHeight.Location = new System.Drawing.Point(266, 5);
            this.NudEyeHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NudEyeHeight.Name = "NudEyeHeight";
            this.NudEyeHeight.Size = new System.Drawing.Size(60, 20);
            this.NudEyeHeight.TabIndex = 20;
            this.toolTip1.SetToolTip(this.NudEyeHeight, "Crosshair length as a percentage of viewport height");
            this.NudEyeHeight.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudEyeHeight.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudEyeHeight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudEyeHeight.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label48
            // 
            this.label48.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(203, 8);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 13);
            this.label48.TabIndex = 15;
            this.label48.Text = "Eye height";
            this.toolTip1.SetToolTip(this.label48, "Movement speed, in units per frame");
            // 
            // CbxAlwaysRun
            // 
            this.CbxAlwaysRun.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxAlwaysRun.AutoSize = true;
            this.CbxAlwaysRun.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxAlwaysRun.Checked = true;
            this.CbxAlwaysRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel38.SetColumnSpan(this.CbxAlwaysRun, 2);
            this.CbxAlwaysRun.Location = new System.Drawing.Point(249, 36);
            this.CbxAlwaysRun.Name = "CbxAlwaysRun";
            this.CbxAlwaysRun.Size = new System.Drawing.Size(77, 17);
            this.CbxAlwaysRun.TabIndex = 25;
            this.CbxAlwaysRun.Text = "Always run";
            this.CbxAlwaysRun.UseVisualStyleBackColor = true;
            this.CbxAlwaysRun.CheckedChanged += new System.EventHandler(this.CbxAlwaysRun_CheckedChanged);
            // 
            // CbxShowFeet
            // 
            this.CbxShowFeet.AutoSize = true;
            this.CbxShowFeet.Checked = true;
            this.CbxShowFeet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxShowFeet.Location = new System.Drawing.Point(84, 33);
            this.CbxShowFeet.Name = "CbxShowFeet";
            this.CbxShowFeet.Size = new System.Drawing.Size(74, 17);
            this.CbxShowFeet.TabIndex = 10;
            this.CbxShowFeet.Text = "Show feet";
            this.CbxShowFeet.UseVisualStyleBackColor = true;
            // 
            // CbxHideHarry
            // 
            this.CbxHideHarry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbxHideHarry.AutoSize = true;
            this.CbxHideHarry.Checked = true;
            this.CbxHideHarry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxHideHarry.Location = new System.Drawing.Point(84, 10);
            this.CbxHideHarry.Name = "CbxHideHarry";
            this.CbxHideHarry.Size = new System.Drawing.Size(76, 17);
            this.CbxHideHarry.TabIndex = 5;
            this.CbxHideHarry.Text = "Hide Harry";
            this.CbxHideHarry.UseVisualStyleBackColor = true;
            this.CbxHideHarry.CheckedChanged += new System.EventHandler(this.CbxHideHarry_CheckedChanged);
            // 
            // tableLayoutPanel27
            // 
            this.tableLayoutPanel27.AutoSize = true;
            this.tableLayoutPanel27.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel27.ColumnCount = 3;
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.Controls.Add(this.BtnCameraFly, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel27.Controls.Add(this.NudCameraFlySpeed, 2, 0);
            this.tableLayoutPanel27.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel27.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel27.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel27.Name = "tableLayoutPanel27";
            this.tableLayoutPanel27.RowCount = 1;
            this.tableLayoutPanel27.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel27.Size = new System.Drawing.Size(329, 56);
            this.tableLayoutPanel27.TabIndex = 0;
            // 
            // BtnCameraFly
            // 
            this.BtnCameraFly.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraFly.AutoSize = true;
            this.BtnCameraFly.Location = new System.Drawing.Point(3, 3);
            this.BtnCameraFly.Name = "BtnCameraFly";
            this.BtnCameraFly.Size = new System.Drawing.Size(75, 50);
            this.BtnCameraFly.TabIndex = 0;
            this.BtnCameraFly.Text = "Fly";
            this.toolTip1.SetToolTip(this.BtnCameraFly, "Enter fly mode");
            this.BtnCameraFly.UseVisualStyleBackColor = true;
            this.BtnCameraFly.Click += new System.EventHandler(this.BtnCameraFly_ClickFirst);
            this.BtnCameraFly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFly_KeyDown);
            this.BtnCameraFly.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFly_KeyUp);
            this.BtnCameraFly.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnCameraFly_MouseDown);
            this.BtnCameraFly.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnCameraFly_MouseUp);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Speed";
            this.toolTip1.SetToolTip(this.label3, "Movement speed, in units per frame");
            // 
            // NudCameraFlySpeed
            // 
            this.NudCameraFlySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudCameraFlySpeed.DecimalPlaces = 3;
            this.NudCameraFlySpeed.Increment = new decimal(new int[] {
            25,
            0,
            0,
            196608});
            this.NudCameraFlySpeed.Location = new System.Drawing.Point(266, 18);
            this.NudCameraFlySpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NudCameraFlySpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NudCameraFlySpeed.Name = "NudCameraFlySpeed";
            this.NudCameraFlySpeed.Size = new System.Drawing.Size(60, 20);
            this.NudCameraFlySpeed.TabIndex = 10;
            this.NudCameraFlySpeed.ValueChanged += new System.EventHandler(this.NudCameraFlySpeed_ValueChanged);
            this.NudCameraFlySpeed.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCameraFlySpeed.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCameraFlySpeed.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCameraFlySpeed.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // GbxOverlay
            // 
            this.GbxOverlay.AutoSize = true;
            this.GbxOverlay.Controls.Add(this.tableLayoutPanel26);
            this.GbxOverlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxOverlay.Location = new System.Drawing.Point(344, 309);
            this.GbxOverlay.Name = "GbxOverlay";
            this.GbxOverlay.Size = new System.Drawing.Size(335, 300);
            this.GbxOverlay.TabIndex = 15;
            this.GbxOverlay.TabStop = false;
            this.GbxOverlay.Text = "Overlay camera";
            // 
            // tableLayoutPanel26
            // 
            this.tableLayoutPanel26.ColumnCount = 5;
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel26.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel26.Controls.Add(this.CbxAntialiasing, 3, 4);
            this.tableLayoutPanel26.Controls.Add(this.CbxFarClipping, 3, 6);
            this.tableLayoutPanel26.Controls.Add(this.CbxBackfaceCulling, 3, 5);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamRoll, 0, 6);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamYaw, 0, 5);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPitch, 0, 4);
            this.tableLayoutPanel26.Controls.Add(this.CbxOverlayCameraMatchGame, 3, 0);
            this.tableLayoutPanel26.Controls.Add(this.label22, 3, 1);
            this.tableLayoutPanel26.Controls.Add(this.label23, 3, 2);
            this.tableLayoutPanel26.Controls.Add(this.label24, 3, 3);
            this.tableLayoutPanel26.Controls.Add(this.label27, 1, 1);
            this.tableLayoutPanel26.Controls.Add(this.label26, 1, 2);
            this.tableLayoutPanel26.Controls.Add(this.label25, 1, 3);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraZ, 2, 3);
            this.tableLayoutPanel26.Controls.Add(this.label84, 3, 8);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraY, 2, 2);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraX, 2, 1);
            this.tableLayoutPanel26.Controls.Add(this.NudFilledOpacity, 4, 8);
            this.tableLayoutPanel26.Controls.Add(this.CbxReadLevelDataOnStageLoad, 0, 8);
            this.tableLayoutPanel26.Controls.Add(this.CbxEnableOverlayCameraReporting, 0, 7);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraPitch, 4, 1);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraYaw, 4, 2);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraRoll, 4, 3);
            this.tableLayoutPanel26.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionX, 0, 1);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionY, 0, 2);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionZ, 0, 3);
            this.tableLayoutPanel26.Controls.Add(this.label70, 2, 7);
            this.tableLayoutPanel26.Controls.Add(this.NudCrosshairLength, 4, 7);
            this.tableLayoutPanel26.Controls.Add(this.label69, 0, 9);
            this.tableLayoutPanel26.Controls.Add(this.CbxEnableOverlay, 3, 10);
            this.tableLayoutPanel26.Controls.Add(this.CmbRenderMode, 0, 10);
            this.tableLayoutPanel26.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel26.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel26.Name = "tableLayoutPanel26";
            this.tableLayoutPanel26.RowCount = 11;
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel26.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel26.Size = new System.Drawing.Size(329, 281);
            this.tableLayoutPanel26.TabIndex = 0;
            // 
            // CbxAntialiasing
            // 
            this.CbxAntialiasing.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxAntialiasing.AutoSize = true;
            this.CbxAntialiasing.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxAntialiasing, 2);
            this.CbxAntialiasing.Location = new System.Drawing.Point(247, 104);
            this.CbxAntialiasing.Name = "CbxAntialiasing";
            this.CbxAntialiasing.Size = new System.Drawing.Size(79, 17);
            this.CbxAntialiasing.TabIndex = 100;
            this.CbxAntialiasing.Text = "Antialiasing";
            this.CbxAntialiasing.UseVisualStyleBackColor = true;
            this.CbxAntialiasing.CheckedChanged += new System.EventHandler(this.CbxAntialiasing_CheckedChanged);
            // 
            // CbxFarClipping
            // 
            this.CbxFarClipping.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxFarClipping.AutoSize = true;
            this.CbxFarClipping.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxFarClipping.Checked = true;
            this.CbxFarClipping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxFarClipping, 2);
            this.CbxFarClipping.Location = new System.Drawing.Point(246, 150);
            this.CbxFarClipping.Name = "CbxFarClipping";
            this.CbxFarClipping.Size = new System.Drawing.Size(80, 17);
            this.CbxFarClipping.TabIndex = 110;
            this.CbxFarClipping.Text = "Far clipping";
            this.CbxFarClipping.UseVisualStyleBackColor = true;
            this.CbxFarClipping.CheckedChanged += new System.EventHandler(this.CbxCullBeyondFarClip_CheckedChanged);
            // 
            // CbxBackfaceCulling
            // 
            this.CbxBackfaceCulling.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxBackfaceCulling.AutoSize = true;
            this.CbxBackfaceCulling.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxBackfaceCulling, 2);
            this.CbxBackfaceCulling.Location = new System.Drawing.Point(221, 127);
            this.CbxBackfaceCulling.Name = "CbxBackfaceCulling";
            this.CbxBackfaceCulling.Size = new System.Drawing.Size(105, 17);
            this.CbxBackfaceCulling.TabIndex = 105;
            this.CbxBackfaceCulling.Text = "Backface culling";
            this.CbxBackfaceCulling.UseVisualStyleBackColor = true;
            this.CbxBackfaceCulling.CheckedChanged += new System.EventHandler(this.CbxCullBackfaces_CheckedChanged);
            // 
            // LblOverlayCamRoll
            // 
            this.LblOverlayCamRoll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamRoll.Location = new System.Drawing.Point(8, 151);
            this.LblOverlayCamRoll.Name = "LblOverlayCamRoll";
            this.LblOverlayCamRoll.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamRoll.TabIndex = 35;
            this.LblOverlayCamRoll.Text = "<roll>";
            this.LblOverlayCamRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOverlayCamYaw
            // 
            this.LblOverlayCamYaw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamYaw.Location = new System.Drawing.Point(8, 128);
            this.LblOverlayCamYaw.Name = "LblOverlayCamYaw";
            this.LblOverlayCamYaw.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamYaw.TabIndex = 30;
            this.LblOverlayCamYaw.Text = "<yaw>";
            this.LblOverlayCamYaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOverlayCamPitch
            // 
            this.LblOverlayCamPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPitch.Location = new System.Drawing.Point(8, 105);
            this.LblOverlayCamPitch.Name = "LblOverlayCamPitch";
            this.LblOverlayCamPitch.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPitch.TabIndex = 25;
            this.LblOverlayCamPitch.Text = "<pitch>";
            this.LblOverlayCamPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CbxOverlayCameraMatchGame
            // 
            this.CbxOverlayCameraMatchGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxOverlayCameraMatchGame.AutoSize = true;
            this.CbxOverlayCameraMatchGame.Checked = true;
            this.CbxOverlayCameraMatchGame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxOverlayCameraMatchGame, 2);
            this.CbxOverlayCameraMatchGame.Location = new System.Drawing.Point(203, 3);
            this.CbxOverlayCameraMatchGame.Name = "CbxOverlayCameraMatchGame";
            this.CbxOverlayCameraMatchGame.Size = new System.Drawing.Size(123, 17);
            this.CbxOverlayCameraMatchGame.TabIndex = 5;
            this.CbxOverlayCameraMatchGame.Text = "Match game camera";
            this.CbxOverlayCameraMatchGame.UseVisualStyleBackColor = true;
            this.CbxOverlayCameraMatchGame.CheckedChanged += new System.EventHandler(this.CbxOverlayCameraMatchGame_CheckedChanged);
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(231, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(34, 13);
            this.label22.TabIndex = 70;
            this.label22.Text = "Pitch:";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(234, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 80;
            this.label23.Text = "Yaw:";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(237, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 90;
            this.label24.Text = "Roll:";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(102, 29);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 13);
            this.label27.TabIndex = 40;
            this.label27.Text = "X:";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(102, 55);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 13);
            this.label26.TabIndex = 50;
            this.label26.Text = "Y:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(102, 81);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 13);
            this.label25.TabIndex = 60;
            this.label25.Text = "Z:";
            // 
            // NudOverlayCameraZ
            // 
            this.NudOverlayCameraZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraZ.Location = new System.Drawing.Point(125, 78);
            this.NudOverlayCameraZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayCameraZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraZ.Name = "NudOverlayCameraZ";
            this.NudOverlayCameraZ.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraZ.TabIndex = 65;
            this.toolTip1.SetToolTip(this.NudOverlayCameraZ, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraZ.ValueChanged += new System.EventHandler(this.NudOverlayCameraZ_ValueChanged);
            this.NudOverlayCameraZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label84
            // 
            this.label84.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(186, 202);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(79, 13);
            this.label84.TabIndex = 135;
            this.label84.Text = "Filled opacity %";
            // 
            // NudOverlayCameraY
            // 
            this.NudOverlayCameraY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraY.Location = new System.Drawing.Point(125, 52);
            this.NudOverlayCameraY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayCameraY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraY.Name = "NudOverlayCameraY";
            this.NudOverlayCameraY.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraY.TabIndex = 55;
            this.toolTip1.SetToolTip(this.NudOverlayCameraY, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraY.ValueChanged += new System.EventHandler(this.NudOverlayCameraY_ValueChanged);
            this.NudOverlayCameraY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayCameraX
            // 
            this.NudOverlayCameraX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraX.Location = new System.Drawing.Point(125, 26);
            this.NudOverlayCameraX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayCameraX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayCameraX.Name = "NudOverlayCameraX";
            this.NudOverlayCameraX.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraX.TabIndex = 45;
            this.toolTip1.SetToolTip(this.NudOverlayCameraX, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraX.ValueChanged += new System.EventHandler(this.NudOverlayCameraX_ValueChanged);
            this.NudOverlayCameraX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudFilledOpacity
            // 
            this.NudFilledOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudFilledOpacity.DecimalPlaces = 1;
            this.NudFilledOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudFilledOpacity.Location = new System.Drawing.Point(271, 199);
            this.NudFilledOpacity.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudFilledOpacity.Name = "NudFilledOpacity";
            this.NudFilledOpacity.Size = new System.Drawing.Size(55, 20);
            this.NudFilledOpacity.TabIndex = 140;
            this.NudFilledOpacity.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudFilledOpacity.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFilledOpacity.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFilledOpacity.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudFilledOpacity.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // CbxReadLevelDataOnStageLoad
            // 
            this.CbxReadLevelDataOnStageLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxReadLevelDataOnStageLoad.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxReadLevelDataOnStageLoad, 3);
            this.CbxReadLevelDataOnStageLoad.Location = new System.Drawing.Point(3, 200);
            this.CbxReadLevelDataOnStageLoad.Name = "CbxReadLevelDataOnStageLoad";
            this.CbxReadLevelDataOnStageLoad.Size = new System.Drawing.Size(121, 17);
            this.CbxReadLevelDataOnStageLoad.TabIndex = 120;
            this.CbxReadLevelDataOnStageLoad.Text = "Auto read level data";
            this.CbxReadLevelDataOnStageLoad.UseVisualStyleBackColor = true;
            this.CbxReadLevelDataOnStageLoad.CheckedChanged += new System.EventHandler(this.CbxReadLevelDataOnStageLoad_CheckedChanged);
            // 
            // CbxEnableOverlayCameraReporting
            // 
            this.CbxEnableOverlayCameraReporting.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxEnableOverlayCameraReporting.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxEnableOverlayCameraReporting, 2);
            this.CbxEnableOverlayCameraReporting.Location = new System.Drawing.Point(3, 174);
            this.CbxEnableOverlayCameraReporting.Name = "CbxEnableOverlayCameraReporting";
            this.CbxEnableOverlayCameraReporting.Size = new System.Drawing.Size(100, 17);
            this.CbxEnableOverlayCameraReporting.TabIndex = 115;
            this.CbxEnableOverlayCameraReporting.Text = "Enable updates";
            this.CbxEnableOverlayCameraReporting.UseVisualStyleBackColor = true;
            // 
            // NudOverlayCameraPitch
            // 
            this.NudOverlayCameraPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraPitch.Location = new System.Drawing.Point(271, 26);
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
            this.NudOverlayCameraPitch.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraPitch.TabIndex = 75;
            this.NudOverlayCameraPitch.ValueChanged += new System.EventHandler(this.NudOverlayCameraPitch_ValueChanged);
            this.NudOverlayCameraPitch.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraPitch.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayCameraYaw
            // 
            this.NudOverlayCameraYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraYaw.Location = new System.Drawing.Point(271, 52);
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
            this.NudOverlayCameraYaw.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraYaw.TabIndex = 85;
            this.NudOverlayCameraYaw.ValueChanged += new System.EventHandler(this.NudOverlayCameraYaw_ValueChanged);
            this.NudOverlayCameraYaw.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraYaw.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayCameraRoll
            // 
            this.NudOverlayCameraRoll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraRoll.Location = new System.Drawing.Point(271, 78);
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
            this.NudOverlayCameraRoll.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraRoll.TabIndex = 95;
            this.NudOverlayCameraRoll.ValueChanged += new System.EventHandler(this.NudOverlayCameraRoll_ValueChanged);
            this.NudOverlayCameraRoll.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraRoll.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X east, Y up, Z south";
            this.toolTip1.SetToolTip(this.label2, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblOverlayCamPositionX
            // 
            this.LblOverlayCamPositionX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPositionX.Location = new System.Drawing.Point(8, 28);
            this.LblOverlayCamPositionX.Name = "LblOverlayCamPositionX";
            this.LblOverlayCamPositionX.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPositionX.TabIndex = 10;
            this.LblOverlayCamPositionX.Text = "<x>";
            this.LblOverlayCamPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionX, "The overlay camera\'s position in overlay coordinates");
            // 
            // LblOverlayCamPositionY
            // 
            this.LblOverlayCamPositionY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPositionY.Location = new System.Drawing.Point(8, 54);
            this.LblOverlayCamPositionY.Name = "LblOverlayCamPositionY";
            this.LblOverlayCamPositionY.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPositionY.TabIndex = 15;
            this.LblOverlayCamPositionY.Text = "<y>";
            this.LblOverlayCamPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionY, "The overlay camera\'s position in overlay coordinates");
            // 
            // LblOverlayCamPositionZ
            // 
            this.LblOverlayCamPositionZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPositionZ.Location = new System.Drawing.Point(8, 80);
            this.LblOverlayCamPositionZ.Name = "LblOverlayCamPositionZ";
            this.LblOverlayCamPositionZ.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPositionZ.TabIndex = 20;
            this.LblOverlayCamPositionZ.Text = "<z>";
            this.LblOverlayCamPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LblOverlayCamPositionZ, "The overlay camera\'s position in overlay coordinates");
            // 
            // label70
            // 
            this.label70.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label70.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.label70, 2);
            this.label70.Location = new System.Drawing.Point(183, 176);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(82, 13);
            this.label70.TabIndex = 125;
            this.label70.Text = "Crosshair length";
            this.toolTip1.SetToolTip(this.label70, "Crosshair length as a percentage of viewport height");
            // 
            // NudCrosshairLength
            // 
            this.NudCrosshairLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudCrosshairLength.DecimalPlaces = 1;
            this.NudCrosshairLength.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudCrosshairLength.Location = new System.Drawing.Point(271, 173);
            this.NudCrosshairLength.Name = "NudCrosshairLength";
            this.NudCrosshairLength.Size = new System.Drawing.Size(55, 20);
            this.NudCrosshairLength.TabIndex = 130;
            this.toolTip1.SetToolTip(this.NudCrosshairLength, "Crosshair length as a percentage of viewport height");
            this.NudCrosshairLength.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCrosshairLength.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCrosshairLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCrosshairLength.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label69.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.label69, 2);
            this.label69.Location = new System.Drawing.Point(25, 241);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(71, 13);
            this.label69.TabIndex = 145;
            this.label69.Text = "Render mode";
            // 
            // CbxEnableOverlay
            // 
            this.CbxEnableOverlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableOverlay.AutoSize = true;
            this.CbxEnableOverlay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxEnableOverlay, 2);
            this.CbxEnableOverlay.Location = new System.Drawing.Point(267, 261);
            this.CbxEnableOverlay.Name = "CbxEnableOverlay";
            this.CbxEnableOverlay.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableOverlay.TabIndex = 0;
            this.CbxEnableOverlay.Text = "Enable";
            this.CbxEnableOverlay.UseVisualStyleBackColor = true;
            this.CbxEnableOverlay.CheckedChanged += new System.EventHandler(this.CbxEnableOverlay_CheckedChanged);
            // 
            // CmbRenderMode
            // 
            this.CmbRenderMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel26.SetColumnSpan(this.CmbRenderMode, 2);
            this.CmbRenderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRenderMode.FormattingEnabled = true;
            this.CmbRenderMode.Items.AddRange(new object[] {
            "Wireframe",
            "Filled",
            "Points"});
            this.CmbRenderMode.Location = new System.Drawing.Point(3, 257);
            this.CmbRenderMode.Name = "CmbRenderMode";
            this.CmbRenderMode.Size = new System.Drawing.Size(116, 21);
            this.CmbRenderMode.TabIndex = 150;
            this.CmbRenderMode.SelectedIndexChanged += new System.EventHandler(this.CmbRenderMode_SelectedIndexChanged);
            // 
            // TbpPois
            // 
            this.TbpPois.Controls.Add(this.splitContainer3);
            this.TbpPois.Location = new System.Drawing.Point(4, 22);
            this.TbpPois.Name = "TbpPois";
            this.TbpPois.Padding = new System.Windows.Forms.Padding(3);
            this.TbpPois.Size = new System.Drawing.Size(688, 618);
            this.TbpPois.TabIndex = 8;
            this.TbpPois.Text = "POIs";
            this.toolTip1.SetToolTip(this.TbpPois, "Points of interest");
            this.TbpPois.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(3, 3);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel33);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel37);
            this.splitContainer3.Size = new System.Drawing.Size(682, 612);
            this.splitContainer3.SplitterDistance = 328;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel33
            // 
            this.tableLayoutPanel33.AutoSize = true;
            this.tableLayoutPanel33.ColumnCount = 2;
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel33.Controls.Add(this.tableLayoutPanel35, 1, 0);
            this.tableLayoutPanel33.Controls.Add(this.tableLayoutPanel34, 0, 0);
            this.tableLayoutPanel33.Controls.Add(this.LbxPois, 0, 1);
            this.tableLayoutPanel33.Controls.Add(this.LbxTriggers, 1, 1);
            this.tableLayoutPanel33.Controls.Add(this.tableLayoutPanel32, 0, 2);
            this.tableLayoutPanel33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel33.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel33.Name = "tableLayoutPanel33";
            this.tableLayoutPanel33.RowCount = 3;
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel33.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel33.Size = new System.Drawing.Size(328, 612);
            this.tableLayoutPanel33.TabIndex = 0;
            // 
            // tableLayoutPanel35
            // 
            this.tableLayoutPanel35.AutoSize = true;
            this.tableLayoutPanel35.ColumnCount = 2;
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel35.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel35.Controls.Add(this.BtnReadTriggers, 0, 0);
            this.tableLayoutPanel35.Controls.Add(this.LblTriggerCount, 1, 0);
            this.tableLayoutPanel35.Location = new System.Drawing.Point(164, 0);
            this.tableLayoutPanel35.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel35.Name = "tableLayoutPanel35";
            this.tableLayoutPanel35.RowCount = 1;
            this.tableLayoutPanel35.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel35.Size = new System.Drawing.Size(122, 31);
            this.tableLayoutPanel35.TabIndex = 10;
            // 
            // BtnReadTriggers
            // 
            this.BtnReadTriggers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadTriggers.AutoSize = true;
            this.BtnReadTriggers.Location = new System.Drawing.Point(3, 3);
            this.BtnReadTriggers.Name = "BtnReadTriggers";
            this.BtnReadTriggers.Size = new System.Drawing.Size(100, 25);
            this.BtnReadTriggers.TabIndex = 0;
            this.BtnReadTriggers.Text = "Read triggers";
            this.BtnReadTriggers.UseVisualStyleBackColor = true;
            this.BtnReadTriggers.Click += new System.EventHandler(this.BtnReadTriggers_Click);
            // 
            // LblTriggerCount
            // 
            this.LblTriggerCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTriggerCount.AutoSize = true;
            this.LblTriggerCount.Location = new System.Drawing.Point(109, 9);
            this.LblTriggerCount.Name = "LblTriggerCount";
            this.LblTriggerCount.Size = new System.Drawing.Size(10, 13);
            this.LblTriggerCount.TabIndex = 5;
            this.LblTriggerCount.Text = "-";
            // 
            // tableLayoutPanel34
            // 
            this.tableLayoutPanel34.AutoSize = true;
            this.tableLayoutPanel34.ColumnCount = 2;
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel34.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel34.Controls.Add(this.BtnReadPois, 0, 0);
            this.tableLayoutPanel34.Controls.Add(this.LblPoiCount, 1, 0);
            this.tableLayoutPanel34.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel34.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel34.Name = "tableLayoutPanel34";
            this.tableLayoutPanel34.RowCount = 1;
            this.tableLayoutPanel34.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel34.Size = new System.Drawing.Size(122, 31);
            this.tableLayoutPanel34.TabIndex = 0;
            // 
            // BtnReadPois
            // 
            this.BtnReadPois.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadPois.AutoSize = true;
            this.BtnReadPois.Location = new System.Drawing.Point(3, 3);
            this.BtnReadPois.Name = "BtnReadPois";
            this.BtnReadPois.Size = new System.Drawing.Size(100, 25);
            this.BtnReadPois.TabIndex = 0;
            this.BtnReadPois.Text = "Read POIs";
            this.BtnReadPois.UseVisualStyleBackColor = true;
            this.BtnReadPois.Click += new System.EventHandler(this.BtnReadPois_Click);
            // 
            // LblPoiCount
            // 
            this.LblPoiCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblPoiCount.AutoSize = true;
            this.LblPoiCount.Location = new System.Drawing.Point(109, 9);
            this.LblPoiCount.Name = "LblPoiCount";
            this.LblPoiCount.Size = new System.Drawing.Size(10, 13);
            this.LblPoiCount.TabIndex = 5;
            this.LblPoiCount.Text = "-";
            // 
            // LbxPois
            // 
            this.LbxPois.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxPois.FormattingEnabled = true;
            this.LbxPois.IntegralHeight = false;
            this.LbxPois.Location = new System.Drawing.Point(3, 34);
            this.LbxPois.Name = "LbxPois";
            this.LbxPois.Size = new System.Drawing.Size(158, 461);
            this.LbxPois.TabIndex = 5;
            this.LbxPois.SelectedIndexChanged += new System.EventHandler(this.LbxPois_SelectedIndexChanged);
            this.LbxPois.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxPois_Format);
            // 
            // LbxTriggers
            // 
            this.LbxTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxTriggers.FormattingEnabled = true;
            this.LbxTriggers.IntegralHeight = false;
            this.LbxTriggers.Location = new System.Drawing.Point(167, 34);
            this.LbxTriggers.Name = "LbxTriggers";
            this.LbxTriggers.Size = new System.Drawing.Size(158, 461);
            this.LbxTriggers.TabIndex = 15;
            this.LbxTriggers.SelectedIndexChanged += new System.EventHandler(this.LbxTriggers_SelectedIndexChanged);
            this.LbxTriggers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxTriggers_Format);
            // 
            // tableLayoutPanel32
            // 
            this.tableLayoutPanel32.ColumnCount = 5;
            this.tableLayoutPanel33.SetColumnSpan(this.tableLayoutPanel32, 2);
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel32.Controls.Add(this.BtnClearPoisTriggers, 0, 0);
            this.tableLayoutPanel32.Controls.Add(this.label44, 2, 1);
            this.tableLayoutPanel32.Controls.Add(this.RdoAxisColorsOff, 4, 2);
            this.tableLayoutPanel32.Controls.Add(this.label68, 0, 1);
            this.tableLayoutPanel32.Controls.Add(this.CmbPoiRenderShape, 0, 2);
            this.tableLayoutPanel32.Controls.Add(this.RdoAxisColorsOverlay, 3, 2);
            this.tableLayoutPanel32.Controls.Add(this.RdoAxisColorsGame, 2, 2);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(0, 498);
            this.tableLayoutPanel32.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 3;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel32.Size = new System.Drawing.Size(328, 114);
            this.tableLayoutPanel32.TabIndex = 20;
            // 
            // BtnClearPoisTriggers
            // 
            this.tableLayoutPanel32.SetColumnSpan(this.BtnClearPoisTriggers, 5);
            this.BtnClearPoisTriggers.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClearPoisTriggers.Location = new System.Drawing.Point(0, 0);
            this.BtnClearPoisTriggers.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClearPoisTriggers.Name = "BtnClearPoisTriggers";
            this.BtnClearPoisTriggers.Size = new System.Drawing.Size(328, 25);
            this.BtnClearPoisTriggers.TabIndex = 0;
            this.BtnClearPoisTriggers.Text = "Clear";
            this.BtnClearPoisTriggers.UseVisualStyleBackColor = true;
            this.BtnClearPoisTriggers.Click += new System.EventHandler(this.BtnClearPoisTriggers_Click);
            // 
            // label44
            // 
            this.label44.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label44.AutoSize = true;
            this.tableLayoutPanel32.SetColumnSpan(this.label44, 3);
            this.label44.Location = new System.Drawing.Point(188, 74);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(108, 13);
            this.label44.TabIndex = 15;
            this.label44.Text = "Positive axis coloring:";
            this.toolTip1.SetToolTip(this.label44, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // RdoAxisColorsOff
            // 
            this.RdoAxisColorsOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoAxisColorsOff.AutoSize = true;
            this.RdoAxisColorsOff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoAxisColorsOff.Location = new System.Drawing.Point(286, 92);
            this.RdoAxisColorsOff.Name = "RdoAxisColorsOff";
            this.RdoAxisColorsOff.Size = new System.Drawing.Size(39, 17);
            this.RdoAxisColorsOff.TabIndex = 30;
            this.RdoAxisColorsOff.TabStop = true;
            this.RdoAxisColorsOff.Text = "Off";
            this.RdoAxisColorsOff.UseVisualStyleBackColor = true;
            this.RdoAxisColorsOff.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(21, 74);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(38, 13);
            this.label68.TabIndex = 5;
            this.label68.Text = "Shape";
            // 
            // CmbPoiRenderShape
            // 
            this.CmbPoiRenderShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbPoiRenderShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPoiRenderShape.FormattingEnabled = true;
            this.CmbPoiRenderShape.Items.AddRange(new object[] {
            "Volumes",
            "Cubes",
            "Centers"});
            this.CmbPoiRenderShape.Location = new System.Drawing.Point(3, 90);
            this.CmbPoiRenderShape.Name = "CmbPoiRenderShape";
            this.CmbPoiRenderShape.Size = new System.Drawing.Size(75, 21);
            this.CmbPoiRenderShape.TabIndex = 10;
            this.CmbPoiRenderShape.SelectedIndexChanged += new System.EventHandler(this.CmbRenderShape_SelectedIndexChanged);
            // 
            // RdoAxisColorsOverlay
            // 
            this.RdoAxisColorsOverlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoAxisColorsOverlay.AutoSize = true;
            this.RdoAxisColorsOverlay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoAxisColorsOverlay.Location = new System.Drawing.Point(219, 92);
            this.RdoAxisColorsOverlay.Name = "RdoAxisColorsOverlay";
            this.RdoAxisColorsOverlay.Size = new System.Drawing.Size(61, 17);
            this.RdoAxisColorsOverlay.TabIndex = 25;
            this.RdoAxisColorsOverlay.TabStop = true;
            this.RdoAxisColorsOverlay.Text = "Overlay";
            this.toolTip1.SetToolTip(this.RdoAxisColorsOverlay, "X east, Y up, Z south");
            this.RdoAxisColorsOverlay.UseVisualStyleBackColor = true;
            this.RdoAxisColorsOverlay.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // RdoAxisColorsGame
            // 
            this.RdoAxisColorsGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoAxisColorsGame.AutoSize = true;
            this.RdoAxisColorsGame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoAxisColorsGame.Checked = true;
            this.RdoAxisColorsGame.Location = new System.Drawing.Point(160, 92);
            this.RdoAxisColorsGame.Name = "RdoAxisColorsGame";
            this.RdoAxisColorsGame.Size = new System.Drawing.Size(53, 17);
            this.RdoAxisColorsGame.TabIndex = 20;
            this.RdoAxisColorsGame.TabStop = true;
            this.RdoAxisColorsGame.Text = "Game";
            this.toolTip1.SetToolTip(this.RdoAxisColorsGame, "X east, Y down, Z north");
            this.RdoAxisColorsGame.UseVisualStyleBackColor = true;
            this.RdoAxisColorsGame.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.ColumnCount = 1;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel37.Controls.Add(this.GbxSelectedTrigger, 0, 1);
            this.tableLayoutPanel37.Controls.Add(this.GbxSelectedPoi, 0, 0);
            this.tableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel37.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 2;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel37.Size = new System.Drawing.Size(350, 612);
            this.tableLayoutPanel37.TabIndex = 5;
            // 
            // GbxSelectedTrigger
            // 
            this.GbxSelectedTrigger.ContextMenuStrip = this.CmsSelectedTrigger;
            this.GbxSelectedTrigger.Controls.Add(this.TlpSelectedTriggerLeft);
            this.GbxSelectedTrigger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxSelectedTrigger.Location = new System.Drawing.Point(0, 244);
            this.GbxSelectedTrigger.Margin = new System.Windows.Forms.Padding(0);
            this.GbxSelectedTrigger.Name = "GbxSelectedTrigger";
            this.GbxSelectedTrigger.Size = new System.Drawing.Size(350, 368);
            this.GbxSelectedTrigger.TabIndex = 5;
            this.GbxSelectedTrigger.TabStop = false;
            this.GbxSelectedTrigger.Text = "Selected trigger";
            // 
            // CmsSelectedTrigger
            // 
            this.CmsSelectedTrigger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmSelectedTriggerResetProperty,
            this.toolStripSeparator2,
            this.TsmSelectedTriggerResetAllProperties});
            this.CmsSelectedTrigger.Name = "CmsSelectedTrigger";
            this.CmsSelectedTrigger.Size = new System.Drawing.Size(265, 54);
            this.CmsSelectedTrigger.Opening += new System.ComponentModel.CancelEventHandler(this.CmsSelectedTrigger_Opening);
            // 
            // TsmSelectedTriggerResetProperty
            // 
            this.TsmSelectedTriggerResetProperty.Name = "TsmSelectedTriggerResetProperty";
            this.TsmSelectedTriggerResetProperty.Size = new System.Drawing.Size(264, 22);
            this.TsmSelectedTriggerResetProperty.Text = "Reset property from disc";
            this.TsmSelectedTriggerResetProperty.Click += new System.EventHandler(this.TsmSelectedTriggerResetProperty_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(261, 6);
            // 
            // TsmSelectedTriggerResetAllProperties
            // 
            this.TsmSelectedTriggerResetAllProperties.Name = "TsmSelectedTriggerResetAllProperties";
            this.TsmSelectedTriggerResetAllProperties.Size = new System.Drawing.Size(264, 22);
            this.TsmSelectedTriggerResetAllProperties.Text = "Reset all trigger properties from disc";
            this.TsmSelectedTriggerResetAllProperties.Click += new System.EventHandler(this.TsmSelectedTriggerResetAllProperties_Click);
            // 
            // TlpSelectedTriggerLeft
            // 
            this.TlpSelectedTriggerLeft.AutoSize = true;
            this.TlpSelectedTriggerLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TlpSelectedTriggerLeft.ColumnCount = 4;
            this.TlpSelectedTriggerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpSelectedTriggerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpSelectedTriggerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpSelectedTriggerLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.TlpSelectedTriggerLeft.Controls.Add(this.CbxSelectedTriggerDisabled, 1, 1);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerAddress, 1, 0);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label40, 0, 0);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerPoiGeometry, 0, 2);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing0, 0, 3);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing1, 0, 4);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CbxSelectedTriggerEnableUpdates, 2, 0);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing4, 0, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing3, 0, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerPoiIndex, 0, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerStyle, 0, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing2, 0, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerFiredDetails, 1, 6);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerType, 2, 7);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CmbSelectedTriggerType, 3, 7);
            this.TlpSelectedTriggerLeft.Controls.Add(this.NudSelectedTriggerTargetIndex, 3, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerTargetIndex, 2, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing5, 2, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing6, 2, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerStageIndex, 2, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CbxSelectedTriggerSomeBool, 3, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.NudSelectedTriggerStageIndex, 3, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerPoiGeometry, 1, 2);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing0, 1, 3);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing1, 1, 4);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing5, 3, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing6, 3, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing2, 1, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing3, 1, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.MtbSelectedTriggerThing4, 1, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.NudSelectedTriggerPoiIndex, 1, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CmbSelectedTriggerStyle, 1, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CbxSelectedTriggerFired, 2, 5);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerFiredGroup, 0, 5);
            this.TlpSelectedTriggerLeft.Controls.Add(this.NudSelectedTriggerFiredGroup, 1, 5);
            this.TlpSelectedTriggerLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.TlpSelectedTriggerLeft.Location = new System.Drawing.Point(3, 16);
            this.TlpSelectedTriggerLeft.Margin = new System.Windows.Forms.Padding(0);
            this.TlpSelectedTriggerLeft.Name = "TlpSelectedTriggerLeft";
            this.TlpSelectedTriggerLeft.RowCount = 13;
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307F));
            this.TlpSelectedTriggerLeft.Size = new System.Drawing.Size(344, 351);
            this.TlpSelectedTriggerLeft.TabIndex = 0;
            // 
            // CbxSelectedTriggerDisabled
            // 
            this.CbxSelectedTriggerDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedTriggerDisabled.AutoSize = true;
            this.CbxSelectedTriggerDisabled.ContextMenuStrip = this.CmsSelectedTrigger;
            this.CbxSelectedTriggerDisabled.Location = new System.Drawing.Point(83, 32);
            this.CbxSelectedTriggerDisabled.Name = "CbxSelectedTriggerDisabled";
            this.CbxSelectedTriggerDisabled.Size = new System.Drawing.Size(67, 17);
            this.CbxSelectedTriggerDisabled.TabIndex = 15;
            this.CbxSelectedTriggerDisabled.Tag = "";
            this.CbxSelectedTriggerDisabled.Text = "Disabled";
            this.CbxSelectedTriggerDisabled.UseVisualStyleBackColor = true;
            this.CbxSelectedTriggerDisabled.CheckedChanged += new System.EventHandler(this.CbxSelectedTriggerEnabled_CheckedChanged);
            // 
            // LblSelectedTriggerAddress
            // 
            this.LblSelectedTriggerAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerAddress.AutoSize = true;
            this.LblSelectedTriggerAddress.Location = new System.Drawing.Point(83, 7);
            this.LblSelectedTriggerAddress.Name = "LblSelectedTriggerAddress";
            this.LblSelectedTriggerAddress.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedTriggerAddress.TabIndex = 10;
            this.LblSelectedTriggerAddress.Text = "<address>";
            this.LblSelectedTriggerAddress.Click += new System.EventHandler(this.LblSelectedTriggerAddress_Click);
            // 
            // label40
            // 
            this.label40.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(29, 7);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 13);
            this.label40.TabIndex = 5;
            this.label40.Text = "Address:";
            // 
            // LblSelectedTriggerPoiGeometry
            // 
            this.LblSelectedTriggerPoiGeometry.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerPoiGeometry.AutoSize = true;
            this.LblSelectedTriggerPoiGeometry.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerPoiGeometry.Location = new System.Drawing.Point(3, 61);
            this.LblSelectedTriggerPoiGeometry.Name = "LblSelectedTriggerPoiGeometry";
            this.LblSelectedTriggerPoiGeometry.Size = new System.Drawing.Size(74, 13);
            this.LblSelectedTriggerPoiGeometry.TabIndex = 20;
            this.LblSelectedTriggerPoiGeometry.Tag = "";
            this.LblSelectedTriggerPoiGeometry.Text = "POI geometry:";
            // 
            // LblSelectedTriggerThing0
            // 
            this.LblSelectedTriggerThing0.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing0.AutoSize = true;
            this.LblSelectedTriggerThing0.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing0.Location = new System.Drawing.Point(34, 88);
            this.LblSelectedTriggerThing0.Name = "LblSelectedTriggerThing0";
            this.LblSelectedTriggerThing0.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing0.TabIndex = 30;
            this.LblSelectedTriggerThing0.Tag = "";
            this.LblSelectedTriggerThing0.Text = "Thing0:";
            // 
            // LblSelectedTriggerThing1
            // 
            this.LblSelectedTriggerThing1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing1.AutoSize = true;
            this.LblSelectedTriggerThing1.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing1.Location = new System.Drawing.Point(34, 115);
            this.LblSelectedTriggerThing1.Name = "LblSelectedTriggerThing1";
            this.LblSelectedTriggerThing1.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing1.TabIndex = 40;
            this.LblSelectedTriggerThing1.Tag = "";
            this.LblSelectedTriggerThing1.Text = "Thing1:";
            // 
            // CbxSelectedTriggerEnableUpdates
            // 
            this.CbxSelectedTriggerEnableUpdates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxSelectedTriggerEnableUpdates.AutoSize = true;
            this.CbxSelectedTriggerEnableUpdates.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxSelectedTriggerEnableUpdates.Checked = true;
            this.CbxSelectedTriggerEnableUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TlpSelectedTriggerLeft.SetColumnSpan(this.CbxSelectedTriggerEnableUpdates, 2);
            this.CbxSelectedTriggerEnableUpdates.Location = new System.Drawing.Point(241, 3);
            this.CbxSelectedTriggerEnableUpdates.Name = "CbxSelectedTriggerEnableUpdates";
            this.CbxSelectedTriggerEnableUpdates.Size = new System.Drawing.Size(100, 17);
            this.CbxSelectedTriggerEnableUpdates.TabIndex = 0;
            this.CbxSelectedTriggerEnableUpdates.Text = "Enable updates";
            this.CbxSelectedTriggerEnableUpdates.UseVisualStyleBackColor = true;
            // 
            // LblSelectedTriggerThing4
            // 
            this.LblSelectedTriggerThing4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing4.AutoSize = true;
            this.LblSelectedTriggerThing4.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing4.Location = new System.Drawing.Point(34, 331);
            this.LblSelectedTriggerThing4.Name = "LblSelectedTriggerThing4";
            this.LblSelectedTriggerThing4.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing4.TabIndex = 115;
            this.LblSelectedTriggerThing4.Tag = "";
            this.LblSelectedTriggerThing4.Text = "Thing4:";
            // 
            // LblSelectedTriggerThing3
            // 
            this.LblSelectedTriggerThing3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing3.AutoSize = true;
            this.LblSelectedTriggerThing3.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing3.Location = new System.Drawing.Point(34, 304);
            this.LblSelectedTriggerThing3.Name = "LblSelectedTriggerThing3";
            this.LblSelectedTriggerThing3.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing3.TabIndex = 105;
            this.LblSelectedTriggerThing3.Tag = "";
            this.LblSelectedTriggerThing3.Text = "Thing3:";
            // 
            // LblSelectedTriggerPoiIndex
            // 
            this.LblSelectedTriggerPoiIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerPoiIndex.AutoSize = true;
            this.LblSelectedTriggerPoiIndex.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerPoiIndex.Location = new System.Drawing.Point(26, 277);
            this.LblSelectedTriggerPoiIndex.Name = "LblSelectedTriggerPoiIndex";
            this.LblSelectedTriggerPoiIndex.Size = new System.Drawing.Size(51, 13);
            this.LblSelectedTriggerPoiIndex.TabIndex = 95;
            this.LblSelectedTriggerPoiIndex.Tag = "";
            this.LblSelectedTriggerPoiIndex.Text = "PoiIndex:";
            // 
            // LblSelectedTriggerStyle
            // 
            this.LblSelectedTriggerStyle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerStyle.AutoSize = true;
            this.LblSelectedTriggerStyle.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerStyle.Location = new System.Drawing.Point(44, 250);
            this.LblSelectedTriggerStyle.Name = "LblSelectedTriggerStyle";
            this.LblSelectedTriggerStyle.Size = new System.Drawing.Size(33, 13);
            this.LblSelectedTriggerStyle.TabIndex = 85;
            this.LblSelectedTriggerStyle.Tag = "";
            this.LblSelectedTriggerStyle.Text = "Style:";
            // 
            // LblSelectedTriggerThing2
            // 
            this.LblSelectedTriggerThing2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing2.AutoSize = true;
            this.LblSelectedTriggerThing2.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing2.Location = new System.Drawing.Point(34, 223);
            this.LblSelectedTriggerThing2.Name = "LblSelectedTriggerThing2";
            this.LblSelectedTriggerThing2.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing2.TabIndex = 75;
            this.LblSelectedTriggerThing2.Tag = "";
            this.LblSelectedTriggerThing2.Text = "Thing2:";
            // 
            // LblSelectedTriggerFiredDetails
            // 
            this.LblSelectedTriggerFiredDetails.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerFiredDetails.AutoSize = true;
            this.TlpSelectedTriggerLeft.SetColumnSpan(this.LblSelectedTriggerFiredDetails, 3);
            this.LblSelectedTriggerFiredDetails.Location = new System.Drawing.Point(83, 169);
            this.LblSelectedTriggerFiredDetails.Name = "LblSelectedTriggerFiredDetails";
            this.LblSelectedTriggerFiredDetails.Size = new System.Drawing.Size(84, 13);
            this.LblSelectedTriggerFiredDetails.TabIndex = 60;
            this.LblSelectedTriggerFiredDetails.Text = "Group 0x , bit 0x";
            this.LblSelectedTriggerFiredDetails.Click += new System.EventHandler(this.LblSelectedTriggerFiredDetails_Click);
            // 
            // LblSelectedTriggerType
            // 
            this.LblSelectedTriggerType.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerType.AutoSize = true;
            this.LblSelectedTriggerType.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerType.Location = new System.Drawing.Point(219, 196);
            this.LblSelectedTriggerType.Name = "LblSelectedTriggerType";
            this.LblSelectedTriggerType.Size = new System.Drawing.Size(34, 13);
            this.LblSelectedTriggerType.TabIndex = 125;
            this.LblSelectedTriggerType.Tag = "";
            this.LblSelectedTriggerType.Text = "Type:";
            // 
            // CmbSelectedTriggerType
            // 
            this.CmbSelectedTriggerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSelectedTriggerType.FormattingEnabled = true;
            this.CmbSelectedTriggerType.Location = new System.Drawing.Point(259, 192);
            this.CmbSelectedTriggerType.Name = "CmbSelectedTriggerType";
            this.CmbSelectedTriggerType.Size = new System.Drawing.Size(82, 21);
            this.CmbSelectedTriggerType.TabIndex = 130;
            this.CmbSelectedTriggerType.Tag = "";
            this.CmbSelectedTriggerType.SelectedValueChanged += new System.EventHandler(this.CmbSelectedTrigger_SelectedValueChanged);
            this.CmbSelectedTriggerType.Enter += new System.EventHandler(this.Selectable_Enter);
            this.CmbSelectedTriggerType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.CmbSelectedTriggerType.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // NudSelectedTriggerTargetIndex
            // 
            this.NudSelectedTriggerTargetIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSelectedTriggerTargetIndex.Location = new System.Drawing.Point(259, 219);
            this.NudSelectedTriggerTargetIndex.Name = "NudSelectedTriggerTargetIndex";
            this.NudSelectedTriggerTargetIndex.Size = new System.Drawing.Size(82, 20);
            this.NudSelectedTriggerTargetIndex.TabIndex = 140;
            this.NudSelectedTriggerTargetIndex.Tag = "";
            this.NudSelectedTriggerTargetIndex.ValueChanged += new System.EventHandler(this.NudSelectedTrigger_ValueChanged);
            this.NudSelectedTriggerTargetIndex.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudSelectedTriggerTargetIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.NudSelectedTriggerTargetIndex.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // LblSelectedTriggerTargetIndex
            // 
            this.LblSelectedTriggerTargetIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerTargetIndex.AutoSize = true;
            this.LblSelectedTriggerTargetIndex.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerTargetIndex.Location = new System.Drawing.Point(184, 223);
            this.LblSelectedTriggerTargetIndex.Name = "LblSelectedTriggerTargetIndex";
            this.LblSelectedTriggerTargetIndex.Size = new System.Drawing.Size(69, 13);
            this.LblSelectedTriggerTargetIndex.TabIndex = 135;
            this.LblSelectedTriggerTargetIndex.Tag = "";
            this.LblSelectedTriggerTargetIndex.Text = "Target index:";
            // 
            // LblSelectedTriggerThing5
            // 
            this.LblSelectedTriggerThing5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing5.AutoSize = true;
            this.LblSelectedTriggerThing5.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing5.Location = new System.Drawing.Point(210, 250);
            this.LblSelectedTriggerThing5.Name = "LblSelectedTriggerThing5";
            this.LblSelectedTriggerThing5.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing5.TabIndex = 145;
            this.LblSelectedTriggerThing5.Tag = "";
            this.LblSelectedTriggerThing5.Text = "Thing5:";
            // 
            // LblSelectedTriggerThing6
            // 
            this.LblSelectedTriggerThing6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerThing6.AutoSize = true;
            this.LblSelectedTriggerThing6.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerThing6.Location = new System.Drawing.Point(210, 277);
            this.LblSelectedTriggerThing6.Name = "LblSelectedTriggerThing6";
            this.LblSelectedTriggerThing6.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedTriggerThing6.TabIndex = 155;
            this.LblSelectedTriggerThing6.Tag = "";
            this.LblSelectedTriggerThing6.Text = "Thing6:";
            // 
            // LblSelectedTriggerStageIndex
            // 
            this.LblSelectedTriggerStageIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerStageIndex.AutoSize = true;
            this.LblSelectedTriggerStageIndex.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerStageIndex.Location = new System.Drawing.Point(187, 304);
            this.LblSelectedTriggerStageIndex.Name = "LblSelectedTriggerStageIndex";
            this.LblSelectedTriggerStageIndex.Size = new System.Drawing.Size(66, 13);
            this.LblSelectedTriggerStageIndex.TabIndex = 165;
            this.LblSelectedTriggerStageIndex.Tag = "";
            this.LblSelectedTriggerStageIndex.Text = "Stage index:";
            // 
            // CbxSelectedTriggerSomeBool
            // 
            this.CbxSelectedTriggerSomeBool.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedTriggerSomeBool.AutoSize = true;
            this.CbxSelectedTriggerSomeBool.ContextMenuStrip = this.CmsSelectedTrigger;
            this.CbxSelectedTriggerSomeBool.Location = new System.Drawing.Point(259, 329);
            this.CbxSelectedTriggerSomeBool.Name = "CbxSelectedTriggerSomeBool";
            this.CbxSelectedTriggerSomeBool.Size = new System.Drawing.Size(74, 17);
            this.CbxSelectedTriggerSomeBool.TabIndex = 175;
            this.CbxSelectedTriggerSomeBool.Tag = "";
            this.CbxSelectedTriggerSomeBool.Text = "SomeBool";
            this.CbxSelectedTriggerSomeBool.UseVisualStyleBackColor = true;
            // 
            // NudSelectedTriggerStageIndex
            // 
            this.NudSelectedTriggerStageIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSelectedTriggerStageIndex.Location = new System.Drawing.Point(259, 300);
            this.NudSelectedTriggerStageIndex.Name = "NudSelectedTriggerStageIndex";
            this.NudSelectedTriggerStageIndex.Size = new System.Drawing.Size(82, 20);
            this.NudSelectedTriggerStageIndex.TabIndex = 170;
            this.NudSelectedTriggerStageIndex.Tag = "";
            this.NudSelectedTriggerStageIndex.ValueChanged += new System.EventHandler(this.NudSelectedTrigger_ValueChanged);
            this.NudSelectedTriggerStageIndex.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudSelectedTriggerStageIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.NudSelectedTriggerStageIndex.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // MtbSelectedTriggerPoiGeometry
            // 
            this.MtbSelectedTriggerPoiGeometry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TlpSelectedTriggerLeft.SetColumnSpan(this.MtbSelectedTriggerPoiGeometry, 2);
            this.MtbSelectedTriggerPoiGeometry.Location = new System.Drawing.Point(83, 57);
            this.MtbSelectedTriggerPoiGeometry.Name = "MtbSelectedTriggerPoiGeometry";
            this.MtbSelectedTriggerPoiGeometry.Size = new System.Drawing.Size(170, 20);
            this.MtbSelectedTriggerPoiGeometry.TabIndex = 25;
            this.MtbSelectedTriggerPoiGeometry.Tag = "";
            this.MtbSelectedTriggerPoiGeometry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerPoiGeometry.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // MtbSelectedTriggerThing0
            // 
            this.MtbSelectedTriggerThing0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing0.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing0.Location = new System.Drawing.Point(83, 84);
            this.MtbSelectedTriggerThing0.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing0.Name = "MtbSelectedTriggerThing0";
            this.MtbSelectedTriggerThing0.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing0.TabIndex = 35;
            this.MtbSelectedTriggerThing0.Tag = "";
            this.MtbSelectedTriggerThing0.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing0.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing0.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing0.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing0.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing1
            // 
            this.MtbSelectedTriggerThing1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing1.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing1.Location = new System.Drawing.Point(83, 111);
            this.MtbSelectedTriggerThing1.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing1.Name = "MtbSelectedTriggerThing1";
            this.MtbSelectedTriggerThing1.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing1.TabIndex = 45;
            this.MtbSelectedTriggerThing1.Tag = "";
            this.MtbSelectedTriggerThing1.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing1.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing1.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing5
            // 
            this.MtbSelectedTriggerThing5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing5.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing5.Location = new System.Drawing.Point(259, 246);
            this.MtbSelectedTriggerThing5.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing5.Name = "MtbSelectedTriggerThing5";
            this.MtbSelectedTriggerThing5.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing5.TabIndex = 150;
            this.MtbSelectedTriggerThing5.Tag = "";
            this.MtbSelectedTriggerThing5.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing5.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing5.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing6
            // 
            this.MtbSelectedTriggerThing6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing6.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing6.Location = new System.Drawing.Point(259, 273);
            this.MtbSelectedTriggerThing6.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing6.Name = "MtbSelectedTriggerThing6";
            this.MtbSelectedTriggerThing6.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing6.TabIndex = 160;
            this.MtbSelectedTriggerThing6.Tag = "";
            this.MtbSelectedTriggerThing6.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing6.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing6.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing2
            // 
            this.MtbSelectedTriggerThing2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing2.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing2.Location = new System.Drawing.Point(83, 219);
            this.MtbSelectedTriggerThing2.Mask = "\\0\\xA";
            this.MtbSelectedTriggerThing2.Name = "MtbSelectedTriggerThing2";
            this.MtbSelectedTriggerThing2.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing2.TabIndex = 80;
            this.MtbSelectedTriggerThing2.Tag = "";
            this.MtbSelectedTriggerThing2.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing2.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing2.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing2.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing3
            // 
            this.MtbSelectedTriggerThing3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing3.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing3.Location = new System.Drawing.Point(83, 300);
            this.MtbSelectedTriggerThing3.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing3.Name = "MtbSelectedTriggerThing3";
            this.MtbSelectedTriggerThing3.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing3.TabIndex = 110;
            this.MtbSelectedTriggerThing3.Tag = "";
            this.MtbSelectedTriggerThing3.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing3.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing3.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing3.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbSelectedTriggerThing4
            // 
            this.MtbSelectedTriggerThing4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbSelectedTriggerThing4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedTriggerThing4.Location = new System.Drawing.Point(83, 327);
            this.MtbSelectedTriggerThing4.Mask = "\\0\\xAA";
            this.MtbSelectedTriggerThing4.Name = "MtbSelectedTriggerThing4";
            this.MtbSelectedTriggerThing4.Size = new System.Drawing.Size(82, 20);
            this.MtbSelectedTriggerThing4.TabIndex = 120;
            this.MtbSelectedTriggerThing4.Tag = "";
            this.MtbSelectedTriggerThing4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedTriggerThing4.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedTriggerThing4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.MtbSelectedTriggerThing4.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            this.MtbSelectedTriggerThing4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // NudSelectedTriggerPoiIndex
            // 
            this.NudSelectedTriggerPoiIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSelectedTriggerPoiIndex.Location = new System.Drawing.Point(83, 273);
            this.NudSelectedTriggerPoiIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudSelectedTriggerPoiIndex.Name = "NudSelectedTriggerPoiIndex";
            this.NudSelectedTriggerPoiIndex.Size = new System.Drawing.Size(82, 20);
            this.NudSelectedTriggerPoiIndex.TabIndex = 100;
            this.NudSelectedTriggerPoiIndex.Tag = "";
            this.NudSelectedTriggerPoiIndex.ValueChanged += new System.EventHandler(this.NudSelectedTrigger_ValueChanged);
            this.NudSelectedTriggerPoiIndex.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudSelectedTriggerPoiIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.NudSelectedTriggerPoiIndex.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // CmbSelectedTriggerStyle
            // 
            this.CmbSelectedTriggerStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSelectedTriggerStyle.FormattingEnabled = true;
            this.CmbSelectedTriggerStyle.Location = new System.Drawing.Point(83, 246);
            this.CmbSelectedTriggerStyle.Name = "CmbSelectedTriggerStyle";
            this.CmbSelectedTriggerStyle.Size = new System.Drawing.Size(82, 21);
            this.CmbSelectedTriggerStyle.TabIndex = 90;
            this.CmbSelectedTriggerStyle.Tag = "";
            this.CmbSelectedTriggerStyle.SelectedValueChanged += new System.EventHandler(this.CmbSelectedTrigger_SelectedValueChanged);
            this.CmbSelectedTriggerStyle.Enter += new System.EventHandler(this.Selectable_Enter);
            this.CmbSelectedTriggerStyle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.CmbSelectedTriggerStyle.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // CbxSelectedTriggerFired
            // 
            this.CbxSelectedTriggerFired.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedTriggerFired.AutoSize = true;
            this.CbxSelectedTriggerFired.ContextMenuStrip = this.CmsSelectedTrigger;
            this.CbxSelectedTriggerFired.Location = new System.Drawing.Point(171, 140);
            this.CbxSelectedTriggerFired.Name = "CbxSelectedTriggerFired";
            this.CbxSelectedTriggerFired.Size = new System.Drawing.Size(49, 17);
            this.CbxSelectedTriggerFired.TabIndex = 50;
            this.CbxSelectedTriggerFired.Tag = "";
            this.CbxSelectedTriggerFired.Text = "Fired";
            this.CbxSelectedTriggerFired.UseVisualStyleBackColor = true;
            this.CbxSelectedTriggerFired.CheckedChanged += new System.EventHandler(this.CbxSelectedTriggerFired_CheckedChanged);
            // 
            // LblSelectedTriggerFiredGroup
            // 
            this.LblSelectedTriggerFiredGroup.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedTriggerFiredGroup.AutoSize = true;
            this.LblSelectedTriggerFiredGroup.ContextMenuStrip = this.CmsSelectedTrigger;
            this.LblSelectedTriggerFiredGroup.Location = new System.Drawing.Point(15, 142);
            this.LblSelectedTriggerFiredGroup.Name = "LblSelectedTriggerFiredGroup";
            this.LblSelectedTriggerFiredGroup.Size = new System.Drawing.Size(62, 13);
            this.LblSelectedTriggerFiredGroup.TabIndex = 65;
            this.LblSelectedTriggerFiredGroup.Tag = "";
            this.LblSelectedTriggerFiredGroup.Text = "FiredGroup:";
            // 
            // NudSelectedTriggerFiredGroup
            // 
            this.NudSelectedTriggerFiredGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSelectedTriggerFiredGroup.Location = new System.Drawing.Point(83, 138);
            this.NudSelectedTriggerFiredGroup.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.NudSelectedTriggerFiredGroup.Name = "NudSelectedTriggerFiredGroup";
            this.NudSelectedTriggerFiredGroup.Size = new System.Drawing.Size(82, 20);
            this.NudSelectedTriggerFiredGroup.TabIndex = 70;
            this.NudSelectedTriggerFiredGroup.Tag = "";
            this.NudSelectedTriggerFiredGroup.ValueChanged += new System.EventHandler(this.NudSelectedTrigger_ValueChanged);
            this.NudSelectedTriggerFiredGroup.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudSelectedTriggerFiredGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedTrigger_KeyDown);
            this.NudSelectedTriggerFiredGroup.Leave += new System.EventHandler(this.SelectedTrigger_Leave);
            // 
            // GbxSelectedPoi
            // 
            this.GbxSelectedPoi.ContextMenuStrip = this.CmsSelectedPoi;
            this.GbxSelectedPoi.Controls.Add(this.tableLayoutPanel36);
            this.GbxSelectedPoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxSelectedPoi.Location = new System.Drawing.Point(0, 0);
            this.GbxSelectedPoi.Margin = new System.Windows.Forms.Padding(0);
            this.GbxSelectedPoi.Name = "GbxSelectedPoi";
            this.GbxSelectedPoi.Size = new System.Drawing.Size(350, 244);
            this.GbxSelectedPoi.TabIndex = 0;
            this.GbxSelectedPoi.TabStop = false;
            this.GbxSelectedPoi.Text = "Selected POI";
            // 
            // CmsSelectedPoi
            // 
            this.CmsSelectedPoi.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmSelectedPoiResetProperty,
            this.toolStripSeparator1,
            this.TsmSelectedPoiResetAll});
            this.CmsSelectedPoi.Name = "CmsSelectedPoi";
            this.CmsSelectedPoi.Size = new System.Drawing.Size(249, 54);
            this.CmsSelectedPoi.Opening += new System.ComponentModel.CancelEventHandler(this.CmsSelectedPoi_Opening);
            // 
            // TsmSelectedPoiResetProperty
            // 
            this.TsmSelectedPoiResetProperty.Name = "TsmSelectedPoiResetProperty";
            this.TsmSelectedPoiResetProperty.Size = new System.Drawing.Size(248, 22);
            this.TsmSelectedPoiResetProperty.Text = "Reset property from disc";
            this.TsmSelectedPoiResetProperty.Click += new System.EventHandler(this.TsmSelectedPoiResetProperty_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(245, 6);
            // 
            // TsmSelectedPoiResetAll
            // 
            this.TsmSelectedPoiResetAll.Name = "TsmSelectedPoiResetAll";
            this.TsmSelectedPoiResetAll.Size = new System.Drawing.Size(248, 22);
            this.TsmSelectedPoiResetAll.Text = "Reset all POI properties from disc";
            this.TsmSelectedPoiResetAll.Click += new System.EventHandler(this.TsmSelectedPoiResetAll_Click);
            // 
            // tableLayoutPanel36
            // 
            this.tableLayoutPanel36.ColumnCount = 4;
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel36.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel36.Controls.Add(this.LbxPoiAssociatedTriggers, 0, 4);
            this.tableLayoutPanel36.Controls.Add(this.label33, 0, 3);
            this.tableLayoutPanel36.Controls.Add(this.BtnGoToPoi, 3, 1);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiXZ, 0, 1);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiAddress, 1, 0);
            this.tableLayoutPanel36.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiGeometry, 0, 2);
            this.tableLayoutPanel36.Controls.Add(this.TbxSelectedPoiX, 1, 1);
            this.tableLayoutPanel36.Controls.Add(this.TbxSelectedPoiZ, 2, 1);
            this.tableLayoutPanel36.Controls.Add(this.MtbSelectedPoiGeometry, 1, 2);
            this.tableLayoutPanel36.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel36.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel36.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel36.Name = "tableLayoutPanel36";
            this.tableLayoutPanel36.RowCount = 5;
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel36.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel36.Size = new System.Drawing.Size(344, 225);
            this.tableLayoutPanel36.TabIndex = 0;
            // 
            // LbxPoiAssociatedTriggers
            // 
            this.tableLayoutPanel36.SetColumnSpan(this.LbxPoiAssociatedTriggers, 4);
            this.LbxPoiAssociatedTriggers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxPoiAssociatedTriggers.FormattingEnabled = true;
            this.LbxPoiAssociatedTriggers.IntegralHeight = false;
            this.LbxPoiAssociatedTriggers.Location = new System.Drawing.Point(3, 115);
            this.LbxPoiAssociatedTriggers.Name = "LbxPoiAssociatedTriggers";
            this.LbxPoiAssociatedTriggers.Size = new System.Drawing.Size(338, 107);
            this.LbxPoiAssociatedTriggers.TabIndex = 40;
            this.LbxPoiAssociatedTriggers.SelectedIndexChanged += new System.EventHandler(this.LbxPoiAssociatedTriggers_SelectedIndexChanged);
            this.LbxPoiAssociatedTriggers.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxTriggers_Format);
            // 
            // label33
            // 
            this.label33.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label33.AutoSize = true;
            this.tableLayoutPanel36.SetColumnSpan(this.label33, 4);
            this.label33.Location = new System.Drawing.Point(3, 99);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(99, 13);
            this.label33.TabIndex = 35;
            this.label33.Text = "Associated triggers:";
            // 
            // BtnGoToPoi
            // 
            this.BtnGoToPoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGoToPoi.AutoSize = true;
            this.BtnGoToPoi.Location = new System.Drawing.Point(240, 31);
            this.BtnGoToPoi.Name = "BtnGoToPoi";
            this.BtnGoToPoi.Size = new System.Drawing.Size(100, 22);
            this.BtnGoToPoi.TabIndex = 20;
            this.BtnGoToPoi.Text = "Go";
            this.BtnGoToPoi.UseVisualStyleBackColor = true;
            this.BtnGoToPoi.Click += new System.EventHandler(this.BtnGoToPoi_Click);
            // 
            // LblSelectedPoiXZ
            // 
            this.LblSelectedPoiXZ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedPoiXZ.AutoSize = true;
            this.LblSelectedPoiXZ.ContextMenuStrip = this.CmsSelectedPoi;
            this.LblSelectedPoiXZ.Location = new System.Drawing.Point(52, 35);
            this.LblSelectedPoiXZ.Name = "LblSelectedPoiXZ";
            this.LblSelectedPoiXZ.Size = new System.Drawing.Size(24, 13);
            this.LblSelectedPoiXZ.TabIndex = 10;
            this.LblSelectedPoiXZ.Tag = "";
            this.LblSelectedPoiXZ.Text = "XZ:";
            // 
            // LblSelectedPoiAddress
            // 
            this.LblSelectedPoiAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedPoiAddress.AutoSize = true;
            this.LblSelectedPoiAddress.Location = new System.Drawing.Point(82, 7);
            this.LblSelectedPoiAddress.Name = "LblSelectedPoiAddress";
            this.LblSelectedPoiAddress.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedPoiAddress.TabIndex = 5;
            this.LblSelectedPoiAddress.Text = "<address>";
            this.LblSelectedPoiAddress.Click += new System.EventHandler(this.LblSelectedPoiAddress_Click);
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 0;
            this.label21.Text = "Address:";
            // 
            // LblSelectedPoiGeometry
            // 
            this.LblSelectedPoiGeometry.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedPoiGeometry.AutoSize = true;
            this.LblSelectedPoiGeometry.ContextMenuStrip = this.CmsSelectedPoi;
            this.LblSelectedPoiGeometry.Location = new System.Drawing.Point(21, 63);
            this.LblSelectedPoiGeometry.Name = "LblSelectedPoiGeometry";
            this.LblSelectedPoiGeometry.Size = new System.Drawing.Size(55, 13);
            this.LblSelectedPoiGeometry.TabIndex = 25;
            this.LblSelectedPoiGeometry.Tag = "";
            this.LblSelectedPoiGeometry.Text = "Geometry:";
            // 
            // TbxSelectedPoiX
            // 
            this.TbxSelectedPoiX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSelectedPoiX.Location = new System.Drawing.Point(82, 32);
            this.TbxSelectedPoiX.Name = "TbxSelectedPoiX";
            this.TbxSelectedPoiX.Size = new System.Drawing.Size(73, 20);
            this.TbxSelectedPoiX.TabIndex = 15;
            this.TbxSelectedPoiX.Tag = "";
            this.TbxSelectedPoiX.Text = "<x>";
            this.TbxSelectedPoiX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxSelectedPoiX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedPoi_KeyDown);
            this.TbxSelectedPoiX.Leave += new System.EventHandler(this.SelectedPoi_Leave);
            // 
            // TbxSelectedPoiZ
            // 
            this.TbxSelectedPoiZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSelectedPoiZ.Location = new System.Drawing.Point(161, 32);
            this.TbxSelectedPoiZ.Name = "TbxSelectedPoiZ";
            this.TbxSelectedPoiZ.Size = new System.Drawing.Size(73, 20);
            this.TbxSelectedPoiZ.TabIndex = 16;
            this.TbxSelectedPoiZ.Tag = "";
            this.TbxSelectedPoiZ.Text = "<z>";
            this.TbxSelectedPoiZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxSelectedPoiZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedPoi_KeyDown);
            this.TbxSelectedPoiZ.Leave += new System.EventHandler(this.SelectedPoi_Leave);
            // 
            // MtbSelectedPoiGeometry
            // 
            this.MtbSelectedPoiGeometry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel36.SetColumnSpan(this.MtbSelectedPoiGeometry, 2);
            this.MtbSelectedPoiGeometry.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbSelectedPoiGeometry.Location = new System.Drawing.Point(82, 60);
            this.MtbSelectedPoiGeometry.Mask = "\\0\\xAAAAAAAA";
            this.MtbSelectedPoiGeometry.Name = "MtbSelectedPoiGeometry";
            this.MtbSelectedPoiGeometry.Size = new System.Drawing.Size(152, 20);
            this.MtbSelectedPoiGeometry.TabIndex = 30;
            this.MtbSelectedPoiGeometry.Tag = "";
            this.MtbSelectedPoiGeometry.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbSelectedPoiGeometry.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbSelectedPoiGeometry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedPoi_KeyDown);
            this.MtbSelectedPoiGeometry.Leave += new System.EventHandler(this.SelectedPoi_Leave);
            // 
            // TbpCamera
            // 
            this.TbpCamera.Controls.Add(this.tableLayoutPanel21);
            this.TbpCamera.Location = new System.Drawing.Point(4, 22);
            this.TbpCamera.Name = "TbpCamera";
            this.TbpCamera.Padding = new System.Windows.Forms.Padding(3);
            this.TbpCamera.Size = new System.Drawing.Size(688, 618);
            this.TbpCamera.TabIndex = 13;
            this.TbpCamera.Text = "Camera";
            this.TbpCamera.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.AutoSize = true;
            this.tableLayoutPanel21.ColumnCount = 2;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel21.Controls.Add(this.splitContainer2, 0, 1);
            this.tableLayoutPanel21.Controls.Add(this.LblCameraPathCount, 1, 0);
            this.tableLayoutPanel21.Controls.Add(this.BtnCameraPathReadArray, 0, 0);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 2;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(682, 612);
            this.tableLayoutPanel21.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.tableLayoutPanel21.SetColumnSpan(this.splitContainer2, 2);
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 32);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel44);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox10);
            this.splitContainer2.Size = new System.Drawing.Size(676, 577);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 10;
            // 
            // tableLayoutPanel44
            // 
            this.tableLayoutPanel44.ColumnCount = 1;
            this.tableLayoutPanel44.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel44.Controls.Add(this.LbxCameraPaths, 0, 0);
            this.tableLayoutPanel44.Controls.Add(this.BtnClearCameraPaths, 0, 1);
            this.tableLayoutPanel44.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel44.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel44.Name = "tableLayoutPanel44";
            this.tableLayoutPanel44.RowCount = 2;
            this.tableLayoutPanel44.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel44.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel44.Size = new System.Drawing.Size(225, 577);
            this.tableLayoutPanel44.TabIndex = 1;
            // 
            // LbxCameraPaths
            // 
            this.LbxCameraPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxCameraPaths.FormattingEnabled = true;
            this.LbxCameraPaths.IntegralHeight = false;
            this.LbxCameraPaths.Location = new System.Drawing.Point(3, 3);
            this.LbxCameraPaths.Name = "LbxCameraPaths";
            this.LbxCameraPaths.Size = new System.Drawing.Size(219, 546);
            this.LbxCameraPaths.TabIndex = 0;
            this.LbxCameraPaths.SelectedIndexChanged += new System.EventHandler(this.LbxCameraPaths_SelectedIndexChanged);
            this.LbxCameraPaths.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxCameraPaths_Format);
            // 
            // BtnClearCameraPaths
            // 
            this.BtnClearCameraPaths.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BtnClearCameraPaths.Location = new System.Drawing.Point(0, 552);
            this.BtnClearCameraPaths.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClearCameraPaths.Name = "BtnClearCameraPaths";
            this.BtnClearCameraPaths.Size = new System.Drawing.Size(225, 25);
            this.BtnClearCameraPaths.TabIndex = 1;
            this.BtnClearCameraPaths.Text = "Clear";
            this.BtnClearCameraPaths.UseVisualStyleBackColor = true;
            this.BtnClearCameraPaths.Click += new System.EventHandler(this.BtnClearCameraPaths_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.groupBox10.Controls.Add(this.tableLayoutPanel22);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(447, 577);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Selected path";
            // 
            // CmsSelectedCameraPath
            // 
            this.CmsSelectedCameraPath.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmSelectedCameraPathResetProperty,
            this.toolStripSeparator3,
            this.TsmSelectedCameraPathResetAll});
            this.CmsSelectedCameraPath.Name = "CmdSelectedCameraPath";
            this.CmsSelectedCameraPath.Size = new System.Drawing.Size(296, 54);
            this.CmsSelectedCameraPath.Opening += new System.ComponentModel.CancelEventHandler(this.CmsSelectedCameraPath_Opening);
            // 
            // TsmSelectedCameraPathResetProperty
            // 
            this.TsmSelectedCameraPathResetProperty.Name = "TsmSelectedCameraPathResetProperty";
            this.TsmSelectedCameraPathResetProperty.Size = new System.Drawing.Size(295, 22);
            this.TsmSelectedCameraPathResetProperty.Text = "Reset property from disc";
            this.TsmSelectedCameraPathResetProperty.Click += new System.EventHandler(this.TsmSelectedCameraPathResetProperty_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(292, 6);
            // 
            // TsmSelectedCameraPathResetAll
            // 
            this.TsmSelectedCameraPathResetAll.Name = "TsmSelectedCameraPathResetAll";
            this.TsmSelectedCameraPathResetAll.Size = new System.Drawing.Size(295, 22);
            this.TsmSelectedCameraPathResetAll.Text = "Reset all camera path properties from disc";
            this.TsmSelectedCameraPathResetAll.Click += new System.EventHandler(this.TsmSelectedCameraPathResetAll_Click);
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.AutoSize = true;
            this.tableLayoutPanel22.ColumnCount = 5;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.Controls.Add(this.label107, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathYaw, 0, 14);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathVolumeMin, 0, 3);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathPitch, 0, 13);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathVolumeMax, 0, 4);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathThing6, 0, 11);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathThing5, 0, 10);
            this.tableLayoutPanel22.Controls.Add(this.BtnCameraPathGoToVolumeMin, 4, 3);
            this.tableLayoutPanel22.Controls.Add(this.BtnCameraPathGoToVolumeMax, 4, 4);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathAreaMin, 0, 6);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathThing4, 0, 9);
            this.tableLayoutPanel22.Controls.Add(this.LblSelectedCameraPathAreaMax, 0, 7);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathAddress, 1, 0);
            this.tableLayoutPanel22.Controls.Add(this.CbxSelectedCameraPathDisabled, 1, 1);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMinX, 1, 3);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMinY, 2, 3);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMinZ, 3, 3);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMaxX, 1, 4);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMaxY, 2, 4);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathVolumeMaxZ, 3, 4);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathAreaMinX, 1, 6);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathAreaMinZ, 3, 6);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathAreaMaxX, 1, 7);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathAreaMaxZ, 3, 7);
            this.tableLayoutPanel22.Controls.Add(this.MtbCameraPathThing4, 1, 9);
            this.tableLayoutPanel22.Controls.Add(this.MtbCameraPathThing5, 1, 10);
            this.tableLayoutPanel22.Controls.Add(this.MtbCameraPathThing6, 1, 11);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathPitch, 1, 13);
            this.tableLayoutPanel22.Controls.Add(this.TbxCameraPathYaw, 1, 14);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 15;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666667F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(441, 558);
            this.tableLayoutPanel22.TabIndex = 0;
            // 
            // label107
            // 
            this.label107.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(46, 12);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(48, 13);
            this.label107.TabIndex = 0;
            this.label107.Text = "Address:";
            // 
            // LblSelectedCameraPathYaw
            // 
            this.LblSelectedCameraPathYaw.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathYaw.AutoSize = true;
            this.LblSelectedCameraPathYaw.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathYaw.Location = new System.Drawing.Point(63, 531);
            this.LblSelectedCameraPathYaw.Name = "LblSelectedCameraPathYaw";
            this.LblSelectedCameraPathYaw.Size = new System.Drawing.Size(31, 13);
            this.LblSelectedCameraPathYaw.TabIndex = 105;
            this.LblSelectedCameraPathYaw.Text = "Yaw:";
            // 
            // LblSelectedCameraPathVolumeMin
            // 
            this.LblSelectedCameraPathVolumeMin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathVolumeMin.AutoSize = true;
            this.LblSelectedCameraPathVolumeMin.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathVolumeMin.Location = new System.Drawing.Point(6, 123);
            this.LblSelectedCameraPathVolumeMin.Name = "LblSelectedCameraPathVolumeMin";
            this.LblSelectedCameraPathVolumeMin.Size = new System.Drawing.Size(88, 13);
            this.LblSelectedCameraPathVolumeMin.TabIndex = 15;
            this.LblSelectedCameraPathVolumeMin.Text = "Volume min XYZ:";
            // 
            // LblSelectedCameraPathPitch
            // 
            this.LblSelectedCameraPathPitch.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathPitch.AutoSize = true;
            this.LblSelectedCameraPathPitch.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathPitch.Location = new System.Drawing.Point(60, 493);
            this.LblSelectedCameraPathPitch.Name = "LblSelectedCameraPathPitch";
            this.LblSelectedCameraPathPitch.Size = new System.Drawing.Size(34, 13);
            this.LblSelectedCameraPathPitch.TabIndex = 95;
            this.LblSelectedCameraPathPitch.Text = "Pitch:";
            // 
            // LblSelectedCameraPathVolumeMax
            // 
            this.LblSelectedCameraPathVolumeMax.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathVolumeMax.AutoSize = true;
            this.LblSelectedCameraPathVolumeMax.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathVolumeMax.Location = new System.Drawing.Point(3, 160);
            this.LblSelectedCameraPathVolumeMax.Name = "LblSelectedCameraPathVolumeMax";
            this.LblSelectedCameraPathVolumeMax.Size = new System.Drawing.Size(91, 13);
            this.LblSelectedCameraPathVolumeMax.TabIndex = 30;
            this.LblSelectedCameraPathVolumeMax.Text = "Volume max XYZ:";
            // 
            // LblSelectedCameraPathThing6
            // 
            this.LblSelectedCameraPathThing6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathThing6.AutoSize = true;
            this.LblSelectedCameraPathThing6.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathThing6.Location = new System.Drawing.Point(51, 419);
            this.LblSelectedCameraPathThing6.Name = "LblSelectedCameraPathThing6";
            this.LblSelectedCameraPathThing6.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedCameraPathThing6.TabIndex = 85;
            this.LblSelectedCameraPathThing6.Text = "Thing6:";
            // 
            // LblSelectedCameraPathThing5
            // 
            this.LblSelectedCameraPathThing5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathThing5.AutoSize = true;
            this.LblSelectedCameraPathThing5.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathThing5.Location = new System.Drawing.Point(51, 382);
            this.LblSelectedCameraPathThing5.Name = "LblSelectedCameraPathThing5";
            this.LblSelectedCameraPathThing5.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedCameraPathThing5.TabIndex = 75;
            this.LblSelectedCameraPathThing5.Text = "Thing5:";
            // 
            // BtnCameraPathGoToVolumeMin
            // 
            this.BtnCameraPathGoToVolumeMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathGoToVolumeMin.AutoSize = true;
            this.BtnCameraPathGoToVolumeMin.Location = new System.Drawing.Point(337, 117);
            this.BtnCameraPathGoToVolumeMin.Name = "BtnCameraPathGoToVolumeMin";
            this.BtnCameraPathGoToVolumeMin.Size = new System.Drawing.Size(100, 25);
            this.BtnCameraPathGoToVolumeMin.TabIndex = 25;
            this.BtnCameraPathGoToVolumeMin.Text = "Go to min";
            this.BtnCameraPathGoToVolumeMin.UseVisualStyleBackColor = true;
            this.BtnCameraPathGoToVolumeMin.Click += new System.EventHandler(this.BtnCameraPathGoToVolumeMin_Click);
            // 
            // BtnCameraPathGoToVolumeMax
            // 
            this.BtnCameraPathGoToVolumeMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathGoToVolumeMax.AutoSize = true;
            this.BtnCameraPathGoToVolumeMax.Location = new System.Drawing.Point(337, 154);
            this.BtnCameraPathGoToVolumeMax.Name = "BtnCameraPathGoToVolumeMax";
            this.BtnCameraPathGoToVolumeMax.Size = new System.Drawing.Size(100, 25);
            this.BtnCameraPathGoToVolumeMax.TabIndex = 40;
            this.BtnCameraPathGoToVolumeMax.Text = "Go to max";
            this.BtnCameraPathGoToVolumeMax.UseVisualStyleBackColor = true;
            this.BtnCameraPathGoToVolumeMax.Click += new System.EventHandler(this.BtnCameraPathGoToVolumeMax_Click);
            // 
            // LblSelectedCameraPathAreaMin
            // 
            this.LblSelectedCameraPathAreaMin.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathAreaMin.AutoSize = true;
            this.LblSelectedCameraPathAreaMin.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathAreaMin.Location = new System.Drawing.Point(26, 234);
            this.LblSelectedCameraPathAreaMin.Name = "LblSelectedCameraPathAreaMin";
            this.LblSelectedCameraPathAreaMin.Size = new System.Drawing.Size(68, 13);
            this.LblSelectedCameraPathAreaMin.TabIndex = 45;
            this.LblSelectedCameraPathAreaMin.Text = "Area min XZ:";
            // 
            // LblSelectedCameraPathThing4
            // 
            this.LblSelectedCameraPathThing4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathThing4.AutoSize = true;
            this.LblSelectedCameraPathThing4.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathThing4.Location = new System.Drawing.Point(51, 345);
            this.LblSelectedCameraPathThing4.Name = "LblSelectedCameraPathThing4";
            this.LblSelectedCameraPathThing4.Size = new System.Drawing.Size(43, 13);
            this.LblSelectedCameraPathThing4.TabIndex = 65;
            this.LblSelectedCameraPathThing4.Text = "Thing4:";
            // 
            // LblSelectedCameraPathAreaMax
            // 
            this.LblSelectedCameraPathAreaMax.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSelectedCameraPathAreaMax.AutoSize = true;
            this.LblSelectedCameraPathAreaMax.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.LblSelectedCameraPathAreaMax.Location = new System.Drawing.Point(23, 271);
            this.LblSelectedCameraPathAreaMax.Name = "LblSelectedCameraPathAreaMax";
            this.LblSelectedCameraPathAreaMax.Size = new System.Drawing.Size(71, 13);
            this.LblSelectedCameraPathAreaMax.TabIndex = 55;
            this.LblSelectedCameraPathAreaMax.Text = "Area max XZ:";
            // 
            // LblCameraPathAddress
            // 
            this.LblCameraPathAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathAddress.AutoSize = true;
            this.LblCameraPathAddress.Location = new System.Drawing.Point(100, 12);
            this.LblCameraPathAddress.Name = "LblCameraPathAddress";
            this.LblCameraPathAddress.Size = new System.Drawing.Size(56, 13);
            this.LblCameraPathAddress.TabIndex = 5;
            this.LblCameraPathAddress.Text = "<address>";
            this.LblCameraPathAddress.Click += new System.EventHandler(this.LblCameraPathAddress_Click);
            // 
            // CbxSelectedCameraPathDisabled
            // 
            this.CbxSelectedCameraPathDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedCameraPathDisabled.AutoSize = true;
            this.tableLayoutPanel22.SetColumnSpan(this.CbxSelectedCameraPathDisabled, 2);
            this.CbxSelectedCameraPathDisabled.ContextMenuStrip = this.CmsSelectedCameraPath;
            this.CbxSelectedCameraPathDisabled.Location = new System.Drawing.Point(100, 47);
            this.CbxSelectedCameraPathDisabled.Name = "CbxSelectedCameraPathDisabled";
            this.CbxSelectedCameraPathDisabled.Size = new System.Drawing.Size(67, 17);
            this.CbxSelectedCameraPathDisabled.TabIndex = 10;
            this.CbxSelectedCameraPathDisabled.Text = "Disabled";
            this.CbxSelectedCameraPathDisabled.UseVisualStyleBackColor = true;
            this.CbxSelectedCameraPathDisabled.CheckedChanged += new System.EventHandler(this.CbxSelectedCameraPathEnabled_CheckedChanged);
            // 
            // TbxCameraPathVolumeMinX
            // 
            this.TbxCameraPathVolumeMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMinX.Location = new System.Drawing.Point(100, 119);
            this.TbxCameraPathVolumeMinX.Name = "TbxCameraPathVolumeMinX";
            this.TbxCameraPathVolumeMinX.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMinX.TabIndex = 111;
            this.TbxCameraPathVolumeMinX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMinX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMinX.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathVolumeMinY
            // 
            this.TbxCameraPathVolumeMinY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMinY.Location = new System.Drawing.Point(179, 119);
            this.TbxCameraPathVolumeMinY.Name = "TbxCameraPathVolumeMinY";
            this.TbxCameraPathVolumeMinY.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMinY.TabIndex = 112;
            this.TbxCameraPathVolumeMinY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMinY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMinY.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathVolumeMinZ
            // 
            this.TbxCameraPathVolumeMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMinZ.Location = new System.Drawing.Point(258, 119);
            this.TbxCameraPathVolumeMinZ.Name = "TbxCameraPathVolumeMinZ";
            this.TbxCameraPathVolumeMinZ.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMinZ.TabIndex = 113;
            this.TbxCameraPathVolumeMinZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMinZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMinZ.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathVolumeMaxX
            // 
            this.TbxCameraPathVolumeMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMaxX.Location = new System.Drawing.Point(100, 156);
            this.TbxCameraPathVolumeMaxX.Name = "TbxCameraPathVolumeMaxX";
            this.TbxCameraPathVolumeMaxX.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMaxX.TabIndex = 114;
            this.TbxCameraPathVolumeMaxX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMaxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMaxX.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathVolumeMaxY
            // 
            this.TbxCameraPathVolumeMaxY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMaxY.Location = new System.Drawing.Point(179, 156);
            this.TbxCameraPathVolumeMaxY.Name = "TbxCameraPathVolumeMaxY";
            this.TbxCameraPathVolumeMaxY.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMaxY.TabIndex = 115;
            this.TbxCameraPathVolumeMaxY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMaxY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMaxY.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathVolumeMaxZ
            // 
            this.TbxCameraPathVolumeMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathVolumeMaxZ.Location = new System.Drawing.Point(258, 156);
            this.TbxCameraPathVolumeMaxZ.Name = "TbxCameraPathVolumeMaxZ";
            this.TbxCameraPathVolumeMaxZ.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathVolumeMaxZ.TabIndex = 116;
            this.TbxCameraPathVolumeMaxZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathVolumeMaxZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathVolumeMaxZ.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathAreaMinX
            // 
            this.TbxCameraPathAreaMinX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathAreaMinX.Location = new System.Drawing.Point(100, 230);
            this.TbxCameraPathAreaMinX.Name = "TbxCameraPathAreaMinX";
            this.TbxCameraPathAreaMinX.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathAreaMinX.TabIndex = 117;
            this.TbxCameraPathAreaMinX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathAreaMinX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathAreaMinX.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathAreaMinZ
            // 
            this.TbxCameraPathAreaMinZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathAreaMinZ.Location = new System.Drawing.Point(258, 230);
            this.TbxCameraPathAreaMinZ.Name = "TbxCameraPathAreaMinZ";
            this.TbxCameraPathAreaMinZ.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathAreaMinZ.TabIndex = 118;
            this.TbxCameraPathAreaMinZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathAreaMinZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathAreaMinZ.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathAreaMaxX
            // 
            this.TbxCameraPathAreaMaxX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathAreaMaxX.Location = new System.Drawing.Point(100, 267);
            this.TbxCameraPathAreaMaxX.Name = "TbxCameraPathAreaMaxX";
            this.TbxCameraPathAreaMaxX.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathAreaMaxX.TabIndex = 119;
            this.TbxCameraPathAreaMaxX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathAreaMaxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathAreaMaxX.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathAreaMaxZ
            // 
            this.TbxCameraPathAreaMaxZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathAreaMaxZ.Location = new System.Drawing.Point(258, 267);
            this.TbxCameraPathAreaMaxZ.Name = "TbxCameraPathAreaMaxZ";
            this.TbxCameraPathAreaMaxZ.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathAreaMaxZ.TabIndex = 120;
            this.TbxCameraPathAreaMaxZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathAreaMaxZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathAreaMaxZ.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // MtbCameraPathThing4
            // 
            this.MtbCameraPathThing4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbCameraPathThing4.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbCameraPathThing4.Location = new System.Drawing.Point(100, 341);
            this.MtbCameraPathThing4.Mask = "\\0\\xAA";
            this.MtbCameraPathThing4.Name = "MtbCameraPathThing4";
            this.MtbCameraPathThing4.Size = new System.Drawing.Size(73, 20);
            this.MtbCameraPathThing4.TabIndex = 121;
            this.MtbCameraPathThing4.Tag = "";
            this.MtbCameraPathThing4.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbCameraPathThing4.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbCameraPathThing4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.MtbCameraPathThing4.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            this.MtbCameraPathThing4.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbCameraPathThing5
            // 
            this.MtbCameraPathThing5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbCameraPathThing5.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbCameraPathThing5.Location = new System.Drawing.Point(100, 378);
            this.MtbCameraPathThing5.Mask = "\\0\\xAA";
            this.MtbCameraPathThing5.Name = "MtbCameraPathThing5";
            this.MtbCameraPathThing5.Size = new System.Drawing.Size(73, 20);
            this.MtbCameraPathThing5.TabIndex = 122;
            this.MtbCameraPathThing5.Tag = "";
            this.MtbCameraPathThing5.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbCameraPathThing5.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbCameraPathThing5.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.MtbCameraPathThing5.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            this.MtbCameraPathThing5.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // MtbCameraPathThing6
            // 
            this.MtbCameraPathThing6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MtbCameraPathThing6.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.MtbCameraPathThing6.Location = new System.Drawing.Point(100, 415);
            this.MtbCameraPathThing6.Mask = "\\0\\xAAAA";
            this.MtbCameraPathThing6.Name = "MtbCameraPathThing6";
            this.MtbCameraPathThing6.Size = new System.Drawing.Size(73, 20);
            this.MtbCameraPathThing6.TabIndex = 123;
            this.MtbCameraPathThing6.Tag = "";
            this.MtbCameraPathThing6.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MtbCameraPathThing6.Enter += new System.EventHandler(this.Selectable_Enter);
            this.MtbCameraPathThing6.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.MtbCameraPathThing6.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            this.MtbCameraPathThing6.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.HexMaskedTextBox_PreviewKeyDown);
            // 
            // TbxCameraPathPitch
            // 
            this.TbxCameraPathPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathPitch.Location = new System.Drawing.Point(100, 489);
            this.TbxCameraPathPitch.Name = "TbxCameraPathPitch";
            this.TbxCameraPathPitch.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathPitch.TabIndex = 124;
            this.TbxCameraPathPitch.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathPitch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathPitch.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // TbxCameraPathYaw
            // 
            this.TbxCameraPathYaw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraPathYaw.Location = new System.Drawing.Point(100, 528);
            this.TbxCameraPathYaw.Name = "TbxCameraPathYaw";
            this.TbxCameraPathYaw.Size = new System.Drawing.Size(73, 20);
            this.TbxCameraPathYaw.TabIndex = 125;
            this.TbxCameraPathYaw.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxCameraPathYaw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedCameraPath_KeyDown);
            this.TbxCameraPathYaw.Leave += new System.EventHandler(this.SelectedCameraPath_Leave);
            // 
            // LblCameraPathCount
            // 
            this.LblCameraPathCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathCount.AutoSize = true;
            this.LblCameraPathCount.Location = new System.Drawing.Point(153, 8);
            this.LblCameraPathCount.Name = "LblCameraPathCount";
            this.LblCameraPathCount.Size = new System.Drawing.Size(10, 13);
            this.LblCameraPathCount.TabIndex = 5;
            this.LblCameraPathCount.Text = "-";
            // 
            // BtnCameraPathReadArray
            // 
            this.BtnCameraPathReadArray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathReadArray.AutoSize = true;
            this.BtnCameraPathReadArray.Location = new System.Drawing.Point(3, 3);
            this.BtnCameraPathReadArray.Name = "BtnCameraPathReadArray";
            this.BtnCameraPathReadArray.Size = new System.Drawing.Size(144, 23);
            this.BtnCameraPathReadArray.TabIndex = 0;
            this.BtnCameraPathReadArray.Text = "Read camera paths";
            this.BtnCameraPathReadArray.UseVisualStyleBackColor = true;
            this.BtnCameraPathReadArray.Click += new System.EventHandler(this.BtnCameraPathReadArray_Click);
            // 
            // TbpStats
            // 
            this.TbpStats.Controls.Add(this.tableLayoutPanel3);
            this.TbpStats.Controls.Add(this.CbxEnableStatsReporting);
            this.TbpStats.Location = new System.Drawing.Point(4, 22);
            this.TbpStats.Name = "TbpStats";
            this.TbpStats.Padding = new System.Windows.Forms.Padding(3);
            this.TbpStats.Size = new System.Drawing.Size(688, 618);
            this.TbpStats.TabIndex = 5;
            this.TbpStats.Text = "Stats";
            this.TbpStats.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.label14, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.label52, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.LblRunningDistance, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.LblTotalTime, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.LblWalkingDistance, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.LblHarryHealth, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(200, 130);
            this.tableLayoutPanel3.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Harry health:";
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(40, 67);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 13);
            this.label52.TabIndex = 10;
            this.label52.Text = "Total time:";
            // 
            // LblRunningDistance
            // 
            this.LblRunningDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblRunningDistance.AutoSize = true;
            this.LblRunningDistance.Location = new System.Drawing.Point(102, 111);
            this.LblRunningDistance.Name = "LblRunningDistance";
            this.LblRunningDistance.Size = new System.Drawing.Size(34, 13);
            this.LblRunningDistance.TabIndex = 35;
            this.LblRunningDistance.Text = "<run>";
            // 
            // LblTotalTime
            // 
            this.LblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.Location = new System.Drawing.Point(102, 67);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(62, 13);
            this.LblTotalTime.TabIndex = 15;
            this.LblTotalTime.Text = "<totalTime>";
            // 
            // LblWalkingDistance
            // 
            this.LblWalkingDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblWalkingDistance.AutoSize = true;
            this.LblWalkingDistance.Location = new System.Drawing.Point(102, 88);
            this.LblWalkingDistance.Name = "LblWalkingDistance";
            this.LblWalkingDistance.Size = new System.Drawing.Size(53, 13);
            this.LblWalkingDistance.TabIndex = 25;
            this.LblWalkingDistance.Text = "<walked>";
            // 
            // LblHarryHealth
            // 
            this.LblHarryHealth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblHarryHealth.AutoSize = true;
            this.LblHarryHealth.Location = new System.Drawing.Point(102, 4);
            this.LblHarryHealth.Name = "LblHarryHealth";
            this.LblHarryHealth.Size = new System.Drawing.Size(74, 13);
            this.LblHarryHealth.TabIndex = 5;
            this.LblHarryHealth.Text = "<harry health>";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Running distance:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Walking distance:";
            // 
            // CbxEnableStatsReporting
            // 
            this.CbxEnableStatsReporting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableStatsReporting.AutoSize = true;
            this.CbxEnableStatsReporting.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableStatsReporting.Checked = true;
            this.CbxEnableStatsReporting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxEnableStatsReporting.Location = new System.Drawing.Point(623, 595);
            this.CbxEnableStatsReporting.Name = "CbxEnableStatsReporting";
            this.CbxEnableStatsReporting.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableStatsReporting.TabIndex = 0;
            this.CbxEnableStatsReporting.Text = "Enable";
            this.CbxEnableStatsReporting.UseVisualStyleBackColor = true;
            // 
            // TbpMap
            // 
            this.TbpMap.Controls.Add(this.BtnGrabMapGraphic);
            this.TbpMap.Controls.Add(this.PbxMapGraphic);
            this.TbpMap.Location = new System.Drawing.Point(4, 22);
            this.TbpMap.Name = "TbpMap";
            this.TbpMap.Padding = new System.Windows.Forms.Padding(3);
            this.TbpMap.Size = new System.Drawing.Size(688, 618);
            this.TbpMap.TabIndex = 1;
            this.TbpMap.Text = "Map";
            this.TbpMap.UseVisualStyleBackColor = true;
            // 
            // TbpFog
            // 
            this.TbpFog.Controls.Add(this.tableLayoutPanel14);
            this.TbpFog.Controls.Add(this.CbxDiscoMode);
            this.TbpFog.Location = new System.Drawing.Point(4, 22);
            this.TbpFog.Name = "TbpFog";
            this.TbpFog.Padding = new System.Windows.Forms.Padding(3);
            this.TbpFog.Size = new System.Drawing.Size(688, 618);
            this.TbpFog.TabIndex = 6;
            this.TbpFog.Text = "Fog";
            this.TbpFog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.AutoSize = true;
            this.tableLayoutPanel14.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel14.ColumnCount = 5;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel14.Controls.Add(this.CbxFog, 0, 0);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel13, 4, 0);
            this.tableLayoutPanel14.Controls.Add(this.tableLayoutPanel12, 2, 0);
            this.tableLayoutPanel14.Controls.Add(this.BtnFogWorldTintColorSwap, 2, 1);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel14.Size = new System.Drawing.Size(362, 194);
            this.tableLayoutPanel14.TabIndex = 0;
            // 
            // CbxFog
            // 
            this.CbxFog.AutoSize = true;
            this.CbxFog.Checked = true;
            this.CbxFog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CbxFog.Location = new System.Drawing.Point(3, 3);
            this.CbxFog.Name = "CbxFog";
            this.CbxFog.Size = new System.Drawing.Size(44, 17);
            this.CbxFog.TabIndex = 0;
            this.CbxFog.Text = "Fog";
            this.CbxFog.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.AutoSize = true;
            this.tableLayoutPanel13.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel13.ColumnCount = 3;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel13.Controls.Add(this.CbxCustomWorldTint, 0, 0);
            this.tableLayoutPanel13.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.label11, 0, 2);
            this.tableLayoutPanel13.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel13.Controls.Add(this.BtnWorldTintDefault, 0, 5);
            this.tableLayoutPanel13.Controls.Add(this.BtnCustomWorldTintCurrent, 0, 4);
            this.tableLayoutPanel13.Controls.Add(this.NudCustomWorldTintR, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.NudCustomWorldTintG, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.BtnWorldTintColor, 2, 1);
            this.tableLayoutPanel13.Controls.Add(this.NudCustomWorldTintB, 1, 3);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(231, 0);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 6;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.Size = new System.Drawing.Size(131, 163);
            this.tableLayoutPanel13.TabIndex = 10;
            // 
            // CbxCustomWorldTint
            // 
            this.CbxCustomWorldTint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxCustomWorldTint.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.CbxCustomWorldTint, 3);
            this.CbxCustomWorldTint.Location = new System.Drawing.Point(12, 3);
            this.CbxCustomWorldTint.Name = "CbxCustomWorldTint";
            this.CbxCustomWorldTint.Size = new System.Drawing.Size(106, 17);
            this.CbxCustomWorldTint.TabIndex = 0;
            this.CbxCustomWorldTint.Text = "Custom world tint";
            this.CbxCustomWorldTint.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "R:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "G:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "B:";
            // 
            // BtnWorldTintDefault
            // 
            this.BtnWorldTintDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnWorldTintDefault.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.BtnWorldTintDefault, 3);
            this.BtnWorldTintDefault.Location = new System.Drawing.Point(3, 135);
            this.BtnWorldTintDefault.Name = "BtnWorldTintDefault";
            this.BtnWorldTintDefault.Size = new System.Drawing.Size(125, 25);
            this.BtnWorldTintDefault.TabIndex = 45;
            this.BtnWorldTintDefault.Text = "Default";
            this.BtnWorldTintDefault.UseVisualStyleBackColor = true;
            this.BtnWorldTintDefault.Click += new System.EventHandler(this.BtnWorldTintDefault_Click);
            // 
            // BtnCustomWorldTintCurrent
            // 
            this.BtnCustomWorldTintCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCustomWorldTintCurrent.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.BtnCustomWorldTintCurrent, 3);
            this.BtnCustomWorldTintCurrent.Location = new System.Drawing.Point(3, 104);
            this.BtnCustomWorldTintCurrent.Name = "BtnCustomWorldTintCurrent";
            this.BtnCustomWorldTintCurrent.Size = new System.Drawing.Size(125, 25);
            this.BtnCustomWorldTintCurrent.TabIndex = 40;
            this.BtnCustomWorldTintCurrent.Text = "Current";
            this.BtnCustomWorldTintCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomWorldTintCurrent.Click += new System.EventHandler(this.BtnCustomWorldTintCurrent_Click);
            // 
            // NudCustomWorldTintR
            // 
            this.NudCustomWorldTintR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomWorldTintR.Location = new System.Drawing.Point(27, 26);
            this.NudCustomWorldTintR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomWorldTintR.Name = "NudCustomWorldTintR";
            this.NudCustomWorldTintR.Size = new System.Drawing.Size(52, 20);
            this.NudCustomWorldTintR.TabIndex = 10;
            this.NudCustomWorldTintR.Value = new decimal(new int[] {
            121,
            0,
            0,
            0});
            this.NudCustomWorldTintR.ValueChanged += new System.EventHandler(this.NudWorldTintR_ValueChanged);
            this.NudCustomWorldTintR.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintR.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomWorldTintR.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudCustomWorldTintG
            // 
            this.NudCustomWorldTintG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomWorldTintG.Location = new System.Drawing.Point(27, 52);
            this.NudCustomWorldTintG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomWorldTintG.Name = "NudCustomWorldTintG";
            this.NudCustomWorldTintG.Size = new System.Drawing.Size(52, 20);
            this.NudCustomWorldTintG.TabIndex = 20;
            this.NudCustomWorldTintG.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.NudCustomWorldTintG.ValueChanged += new System.EventHandler(this.NudWorldTintG_ValueChanged);
            this.NudCustomWorldTintG.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintG.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomWorldTintG.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // BtnWorldTintColor
            // 
            this.BtnWorldTintColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(128)))), ((int)(((byte)(138)))));
            this.BtnWorldTintColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnWorldTintColor.Location = new System.Drawing.Point(85, 26);
            this.BtnWorldTintColor.Name = "BtnWorldTintColor";
            this.tableLayoutPanel13.SetRowSpan(this.BtnWorldTintColor, 3);
            this.BtnWorldTintColor.Size = new System.Drawing.Size(43, 72);
            this.BtnWorldTintColor.TabIndex = 35;
            this.BtnWorldTintColor.UseVisualStyleBackColor = false;
            this.BtnWorldTintColor.Click += new System.EventHandler(this.BtnWorldTintColor_Click);
            // 
            // NudCustomWorldTintB
            // 
            this.NudCustomWorldTintB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomWorldTintB.Location = new System.Drawing.Point(27, 78);
            this.NudCustomWorldTintB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomWorldTintB.Name = "NudCustomWorldTintB";
            this.NudCustomWorldTintB.Size = new System.Drawing.Size(52, 20);
            this.NudCustomWorldTintB.TabIndex = 30;
            this.NudCustomWorldTintB.Value = new decimal(new int[] {
            138,
            0,
            0,
            0});
            this.NudCustomWorldTintB.ValueChanged += new System.EventHandler(this.NudWorldTintB_ValueChanged);
            this.NudCustomWorldTintB.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintB.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomWorldTintB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomWorldTintB.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoSize = true;
            this.tableLayoutPanel12.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel12.ColumnCount = 3;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.CbxCustomFog, 0, 0);
            this.tableLayoutPanel12.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel12.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel12.Controls.Add(this.BtnCustomFogCurrent, 0, 4);
            this.tableLayoutPanel12.Controls.Add(this.BtnFogColorDefault, 0, 5);
            this.tableLayoutPanel12.Controls.Add(this.NudCustomFogR, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.NudCustomFogG, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.NudCustomFogB, 1, 3);
            this.tableLayoutPanel12.Controls.Add(this.BtnFogColor, 2, 1);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(75, 0);
            this.tableLayoutPanel12.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 6;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(131, 163);
            this.tableLayoutPanel12.TabIndex = 5;
            // 
            // CbxCustomFog
            // 
            this.CbxCustomFog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxCustomFog.AutoSize = true;
            this.tableLayoutPanel12.SetColumnSpan(this.CbxCustomFog, 3);
            this.CbxCustomFog.Location = new System.Drawing.Point(26, 3);
            this.CbxCustomFog.Name = "CbxCustomFog";
            this.CbxCustomFog.Size = new System.Drawing.Size(79, 17);
            this.CbxCustomFog.TabIndex = 0;
            this.CbxCustomFog.Text = "Custom fog";
            this.CbxCustomFog.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "R:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "G:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "B:";
            // 
            // BtnCustomFogCurrent
            // 
            this.BtnCustomFogCurrent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCustomFogCurrent.AutoSize = true;
            this.tableLayoutPanel12.SetColumnSpan(this.BtnCustomFogCurrent, 3);
            this.BtnCustomFogCurrent.Location = new System.Drawing.Point(3, 104);
            this.BtnCustomFogCurrent.Name = "BtnCustomFogCurrent";
            this.BtnCustomFogCurrent.Size = new System.Drawing.Size(125, 25);
            this.BtnCustomFogCurrent.TabIndex = 40;
            this.BtnCustomFogCurrent.Text = "Current";
            this.BtnCustomFogCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomFogCurrent.Click += new System.EventHandler(this.BtnCustomFogCurrent_Click);
            // 
            // BtnFogColorDefault
            // 
            this.BtnFogColorDefault.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFogColorDefault.AutoSize = true;
            this.tableLayoutPanel12.SetColumnSpan(this.BtnFogColorDefault, 3);
            this.BtnFogColorDefault.Location = new System.Drawing.Point(3, 135);
            this.BtnFogColorDefault.Name = "BtnFogColorDefault";
            this.BtnFogColorDefault.Size = new System.Drawing.Size(125, 25);
            this.BtnFogColorDefault.TabIndex = 45;
            this.BtnFogColorDefault.Text = "Default";
            this.BtnFogColorDefault.UseVisualStyleBackColor = true;
            this.BtnFogColorDefault.Click += new System.EventHandler(this.BtnFogColorDefault_Click);
            // 
            // NudCustomFogR
            // 
            this.NudCustomFogR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomFogR.Location = new System.Drawing.Point(27, 26);
            this.NudCustomFogR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomFogR.Name = "NudCustomFogR";
            this.NudCustomFogR.Size = new System.Drawing.Size(52, 20);
            this.NudCustomFogR.TabIndex = 10;
            this.NudCustomFogR.Value = new decimal(new int[] {
            108,
            0,
            0,
            0});
            this.NudCustomFogR.ValueChanged += new System.EventHandler(this.NudFogR_ValueChanged);
            this.NudCustomFogR.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogR.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomFogR.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudCustomFogG
            // 
            this.NudCustomFogG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomFogG.Location = new System.Drawing.Point(27, 52);
            this.NudCustomFogG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomFogG.Name = "NudCustomFogG";
            this.NudCustomFogG.Size = new System.Drawing.Size(52, 20);
            this.NudCustomFogG.TabIndex = 20;
            this.NudCustomFogG.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NudCustomFogG.ValueChanged += new System.EventHandler(this.NudFogG_ValueChanged);
            this.NudCustomFogG.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogG.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomFogG.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudCustomFogB
            // 
            this.NudCustomFogB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudCustomFogB.Location = new System.Drawing.Point(27, 78);
            this.NudCustomFogB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudCustomFogB.Name = "NudCustomFogB";
            this.NudCustomFogB.Size = new System.Drawing.Size(52, 20);
            this.NudCustomFogB.TabIndex = 30;
            this.NudCustomFogB.Value = new decimal(new int[] {
            116,
            0,
            0,
            0});
            this.NudCustomFogB.ValueChanged += new System.EventHandler(this.NudFogB_ValueChanged);
            this.NudCustomFogB.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogB.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudCustomFogB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudCustomFogB.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // BtnFogColor
            // 
            this.BtnFogColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.BtnFogColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFogColor.Location = new System.Drawing.Point(85, 26);
            this.BtnFogColor.Name = "BtnFogColor";
            this.tableLayoutPanel12.SetRowSpan(this.BtnFogColor, 3);
            this.BtnFogColor.Size = new System.Drawing.Size(43, 72);
            this.BtnFogColor.TabIndex = 35;
            this.BtnFogColor.UseVisualStyleBackColor = false;
            this.BtnFogColor.Click += new System.EventHandler(this.BtnFogColor_Click);
            // 
            // BtnFogWorldTintColorSwap
            // 
            this.BtnFogWorldTintColorSwap.AutoSize = true;
            this.tableLayoutPanel14.SetColumnSpan(this.BtnFogWorldTintColorSwap, 3);
            this.BtnFogWorldTintColorSwap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFogWorldTintColorSwap.Location = new System.Drawing.Point(78, 166);
            this.BtnFogWorldTintColorSwap.Name = "BtnFogWorldTintColorSwap";
            this.BtnFogWorldTintColorSwap.Size = new System.Drawing.Size(281, 25);
            this.BtnFogWorldTintColorSwap.TabIndex = 15;
            this.BtnFogWorldTintColorSwap.Text = "Swap";
            this.BtnFogWorldTintColorSwap.UseVisualStyleBackColor = true;
            this.BtnFogWorldTintColorSwap.Click += new System.EventHandler(this.BtnFogWorldTintColorSwap_Click);
            // 
            // CbxDiscoMode
            // 
            this.CbxDiscoMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CbxDiscoMode.AutoSize = true;
            this.CbxDiscoMode.Location = new System.Drawing.Point(6, 595);
            this.CbxDiscoMode.Name = "CbxDiscoMode";
            this.CbxDiscoMode.Size = new System.Drawing.Size(82, 17);
            this.CbxDiscoMode.TabIndex = 5;
            this.CbxDiscoMode.Text = "Disco mode";
            this.CbxDiscoMode.UseVisualStyleBackColor = true;
            this.CbxDiscoMode.CheckedChanged += new System.EventHandler(this.CbxDiscoMode_CheckedChanged);
            // 
            // TbpStrings
            // 
            this.TbpStrings.Controls.Add(this.tableLayoutPanel10);
            this.TbpStrings.Location = new System.Drawing.Point(4, 22);
            this.TbpStrings.Name = "TbpStrings";
            this.TbpStrings.Padding = new System.Windows.Forms.Padding(3);
            this.TbpStrings.Size = new System.Drawing.Size(688, 618);
            this.TbpStrings.TabIndex = 7;
            this.TbpStrings.Text = "Strings";
            this.TbpStrings.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.AutoSize = true;
            this.tableLayoutPanel10.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel10.Controls.Add(this.BtnReadStrings, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.RtbStrings, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.LblStringCount, 1, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(682, 612);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // BtnReadStrings
            // 
            this.BtnReadStrings.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadStrings.AutoSize = true;
            this.BtnReadStrings.Location = new System.Drawing.Point(3, 3);
            this.BtnReadStrings.Name = "BtnReadStrings";
            this.BtnReadStrings.Size = new System.Drawing.Size(125, 25);
            this.BtnReadStrings.TabIndex = 0;
            this.BtnReadStrings.Text = "Read strings";
            this.BtnReadStrings.UseVisualStyleBackColor = true;
            this.BtnReadStrings.Click += new System.EventHandler(this.BtnReadStrings_Click);
            // 
            // RtbStrings
            // 
            this.tableLayoutPanel10.SetColumnSpan(this.RtbStrings, 2);
            this.RtbStrings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RtbStrings.Location = new System.Drawing.Point(3, 34);
            this.RtbStrings.Name = "RtbStrings";
            this.RtbStrings.Size = new System.Drawing.Size(676, 575);
            this.RtbStrings.TabIndex = 10;
            this.RtbStrings.Text = "";
            // 
            // LblStringCount
            // 
            this.LblStringCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblStringCount.AutoSize = true;
            this.LblStringCount.Location = new System.Drawing.Point(134, 9);
            this.LblStringCount.Name = "LblStringCount";
            this.LblStringCount.Size = new System.Drawing.Size(10, 13);
            this.LblStringCount.TabIndex = 5;
            this.LblStringCount.Text = "-";
            // 
            // TbpSave
            // 
            this.TbpSave.Controls.Add(this.groupBox3);
            this.TbpSave.Controls.Add(this.groupBox4);
            this.TbpSave.Location = new System.Drawing.Point(4, 22);
            this.TbpSave.Name = "TbpSave";
            this.TbpSave.Padding = new System.Windows.Forms.Padding(3);
            this.TbpSave.Size = new System.Drawing.Size(688, 618);
            this.TbpSave.TabIndex = 9;
            this.TbpSave.Text = "Save";
            this.TbpSave.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tableLayoutPanel17);
            this.groupBox3.Location = new System.Drawing.Point(6, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(676, 538);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SaveRAM";
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel17.Controls.Add(this.PnlSaveRamDangerArea, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.BtnSaveRamExport, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.TbxSaveRamExportPath, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.BtnSaveRamExportBrowse, 2, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel17.Size = new System.Drawing.Size(670, 519);
            this.tableLayoutPanel17.TabIndex = 9;
            // 
            // PnlSaveRamDangerArea
            // 
            this.tableLayoutPanel17.SetColumnSpan(this.PnlSaveRamDangerArea, 3);
            this.PnlSaveRamDangerArea.Controls.Add(this.tableLayoutPanel18);
            this.PnlSaveRamDangerArea.Controls.Add(this.PbxHazardStripes);
            this.PnlSaveRamDangerArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlSaveRamDangerArea.Location = new System.Drawing.Point(3, 34);
            this.PnlSaveRamDangerArea.Name = "PnlSaveRamDangerArea";
            this.PnlSaveRamDangerArea.Size = new System.Drawing.Size(664, 482);
            this.PnlSaveRamDangerArea.TabIndex = 15;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel18.ColumnCount = 3;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel18.Controls.Add(this.CbxSaveRamDanger, 0, 0);
            this.tableLayoutPanel18.Controls.Add(this.BtnSaveRamImportBrowse, 2, 1);
            this.tableLayoutPanel18.Controls.Add(this.TbxSaveRamImportPath, 1, 1);
            this.tableLayoutPanel18.Controls.Add(this.BtnSaveRamImport, 0, 1);
            this.tableLayoutPanel18.Controls.Add(this.GbxConvertStatesOrSaveRam, 0, 2);
            this.tableLayoutPanel18.Location = new System.Drawing.Point(18, 16);
            this.tableLayoutPanel18.Margin = new System.Windows.Forms.Padding(15);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 3;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(628, 451);
            this.tableLayoutPanel18.TabIndex = 0;
            // 
            // CbxSaveRamDanger
            // 
            this.CbxSaveRamDanger.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxSaveRamDanger.AutoSize = true;
            this.tableLayoutPanel18.SetColumnSpan(this.CbxSaveRamDanger, 3);
            this.CbxSaveRamDanger.Location = new System.Drawing.Point(112, 3);
            this.CbxSaveRamDanger.Name = "CbxSaveRamDanger";
            this.CbxSaveRamDanger.Padding = new System.Windows.Forms.Padding(3);
            this.CbxSaveRamDanger.Size = new System.Drawing.Size(404, 23);
            this.CbxSaveRamDanger.TabIndex = 0;
            this.CbxSaveRamDanger.Text = "Acknowledge the incredible danger of messing with savestates and SaveRAM!";
            this.CbxSaveRamDanger.UseVisualStyleBackColor = true;
            this.CbxSaveRamDanger.CheckedChanged += new System.EventHandler(this.CbxSaveRamDanger_CheckedChanged);
            // 
            // BtnSaveRamImportBrowse
            // 
            this.BtnSaveRamImportBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamImportBrowse.AutoSize = true;
            this.BtnSaveRamImportBrowse.Enabled = false;
            this.BtnSaveRamImportBrowse.Location = new System.Drawing.Point(550, 32);
            this.BtnSaveRamImportBrowse.Name = "BtnSaveRamImportBrowse";
            this.BtnSaveRamImportBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamImportBrowse.TabIndex = 15;
            this.BtnSaveRamImportBrowse.Text = "...";
            this.BtnSaveRamImportBrowse.UseVisualStyleBackColor = true;
            this.BtnSaveRamImportBrowse.Click += new System.EventHandler(this.BtnSaveRamImportBrowse_Click);
            // 
            // TbxSaveRamImportPath
            // 
            this.TbxSaveRamImportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSaveRamImportPath.Enabled = false;
            this.TbxSaveRamImportPath.Location = new System.Drawing.Point(84, 34);
            this.TbxSaveRamImportPath.Name = "TbxSaveRamImportPath";
            this.TbxSaveRamImportPath.Size = new System.Drawing.Size(460, 20);
            this.TbxSaveRamImportPath.TabIndex = 10;
            // 
            // BtnSaveRamImport
            // 
            this.BtnSaveRamImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamImport.AutoSize = true;
            this.BtnSaveRamImport.Enabled = false;
            this.BtnSaveRamImport.Location = new System.Drawing.Point(3, 32);
            this.BtnSaveRamImport.Name = "BtnSaveRamImport";
            this.BtnSaveRamImport.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamImport.TabIndex = 5;
            this.BtnSaveRamImport.Text = "Import";
            this.BtnSaveRamImport.UseVisualStyleBackColor = true;
            this.BtnSaveRamImport.Click += new System.EventHandler(this.BtnSaveRamImport_Click);
            // 
            // GbxConvertStatesOrSaveRam
            // 
            this.tableLayoutPanel18.SetColumnSpan(this.GbxConvertStatesOrSaveRam, 3);
            this.GbxConvertStatesOrSaveRam.Controls.Add(this.TbcConvertStatesOrSaveRam);
            this.GbxConvertStatesOrSaveRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxConvertStatesOrSaveRam.Enabled = false;
            this.GbxConvertStatesOrSaveRam.Location = new System.Drawing.Point(3, 63);
            this.GbxConvertStatesOrSaveRam.Name = "GbxConvertStatesOrSaveRam";
            this.GbxConvertStatesOrSaveRam.Size = new System.Drawing.Size(622, 385);
            this.GbxConvertStatesOrSaveRam.TabIndex = 20;
            this.GbxConvertStatesOrSaveRam.TabStop = false;
            this.GbxConvertStatesOrSaveRam.Text = "Convert";
            // 
            // TbcConvertStatesOrSaveRam
            // 
            this.TbcConvertStatesOrSaveRam.Controls.Add(this.TbpConvertStatesToSaveRam);
            this.TbcConvertStatesOrSaveRam.Controls.Add(this.TbpConvertSaveRamToStates);
            this.TbcConvertStatesOrSaveRam.Location = new System.Drawing.Point(6, 19);
            this.TbcConvertStatesOrSaveRam.Name = "TbcConvertStatesOrSaveRam";
            this.TbcConvertStatesOrSaveRam.SelectedIndex = 0;
            this.TbcConvertStatesOrSaveRam.Size = new System.Drawing.Size(610, 346);
            this.TbcConvertStatesOrSaveRam.TabIndex = 0;
            // 
            // TbpConvertStatesToSaveRam
            // 
            this.TbpConvertStatesToSaveRam.Controls.Add(this.tableLayoutPanel15);
            this.TbpConvertStatesToSaveRam.Location = new System.Drawing.Point(4, 22);
            this.TbpConvertStatesToSaveRam.Name = "TbpConvertStatesToSaveRam";
            this.TbpConvertStatesToSaveRam.Padding = new System.Windows.Forms.Padding(3);
            this.TbpConvertStatesToSaveRam.Size = new System.Drawing.Size(602, 320);
            this.TbpConvertStatesToSaveRam.TabIndex = 0;
            this.TbpConvertStatesToSaveRam.Text = "States to SaveRAM";
            this.TbpConvertStatesToSaveRam.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 4;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel15.Controls.Add(this.label58, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.LbxConvertStatesToSaveRam, 0, 1);
            this.tableLayoutPanel15.Controls.Add(this.BtnConvertStatesToSaveRamGo, 3, 2);
            this.tableLayoutPanel15.Controls.Add(this.TbxConvertStatesToSaveRamInputPath, 1, 0);
            this.tableLayoutPanel15.Controls.Add(this.BtnConvertStatesToSaveRamInputPathBrowse, 2, 0);
            this.tableLayoutPanel15.Controls.Add(this.BtnConvertStatesToSaveRamOutputPathBrowse, 2, 2);
            this.tableLayoutPanel15.Controls.Add(this.label55, 0, 2);
            this.tableLayoutPanel15.Controls.Add(this.TbxConvertStatesToSaveRamOutputPath, 1, 2);
            this.tableLayoutPanel15.Controls.Add(this.BtnConvertStatesToSaveRamRefresh, 3, 0);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 3;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel15.Size = new System.Drawing.Size(590, 308);
            this.tableLayoutPanel15.TabIndex = 31;
            // 
            // label58
            // 
            this.label58.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(8, 9);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(130, 13);
            this.label58.TabIndex = 0;
            this.label58.Text = "Save state input directory:";
            // 
            // LbxConvertStatesToSaveRam
            // 
            this.tableLayoutPanel15.SetColumnSpan(this.LbxConvertStatesToSaveRam, 4);
            this.LbxConvertStatesToSaveRam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxConvertStatesToSaveRam.FormattingEnabled = true;
            this.LbxConvertStatesToSaveRam.HorizontalScrollbar = true;
            this.LbxConvertStatesToSaveRam.IntegralHeight = false;
            this.LbxConvertStatesToSaveRam.Location = new System.Drawing.Point(3, 34);
            this.LbxConvertStatesToSaveRam.Name = "LbxConvertStatesToSaveRam";
            this.LbxConvertStatesToSaveRam.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxConvertStatesToSaveRam.Size = new System.Drawing.Size(584, 240);
            this.LbxConvertStatesToSaveRam.TabIndex = 20;
            // 
            // BtnConvertStatesToSaveRamGo
            // 
            this.BtnConvertStatesToSaveRamGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamGo.AutoSize = true;
            this.BtnConvertStatesToSaveRamGo.Location = new System.Drawing.Point(512, 280);
            this.BtnConvertStatesToSaveRamGo.Name = "BtnConvertStatesToSaveRamGo";
            this.BtnConvertStatesToSaveRamGo.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamGo.TabIndex = 40;
            this.BtnConvertStatesToSaveRamGo.Text = "Go";
            this.BtnConvertStatesToSaveRamGo.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamGo.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamGo_Click);
            // 
            // TbxConvertStatesToSaveRamInputPath
            // 
            this.TbxConvertStatesToSaveRamInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertStatesToSaveRamInputPath.Location = new System.Drawing.Point(144, 5);
            this.TbxConvertStatesToSaveRamInputPath.Name = "TbxConvertStatesToSaveRamInputPath";
            this.TbxConvertStatesToSaveRamInputPath.Size = new System.Drawing.Size(281, 20);
            this.TbxConvertStatesToSaveRamInputPath.TabIndex = 5;
            this.TbxConvertStatesToSaveRamInputPath.TextChanged += new System.EventHandler(this.TbxConvertStatesToSaveRamInputPath_TextChanged);
            // 
            // BtnConvertStatesToSaveRamInputPathBrowse
            // 
            this.BtnConvertStatesToSaveRamInputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamInputPathBrowse.AutoSize = true;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Location = new System.Drawing.Point(431, 3);
            this.BtnConvertStatesToSaveRamInputPathBrowse.Name = "BtnConvertStatesToSaveRamInputPathBrowse";
            this.BtnConvertStatesToSaveRamInputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamInputPathBrowse.TabIndex = 10;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Text = "...";
            this.BtnConvertStatesToSaveRamInputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamInputPathBrowse_Click);
            // 
            // BtnConvertStatesToSaveRamOutputPathBrowse
            // 
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.AutoSize = true;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Location = new System.Drawing.Point(431, 280);
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Name = "BtnConvertStatesToSaveRamOutputPathBrowse";
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamOutputPathBrowse.TabIndex = 35;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Text = "...";
            this.BtnConvertStatesToSaveRamOutputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamOutputPathBrowse.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamOutputPathBrowse_Click);
            // 
            // label55
            // 
            this.label55.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(3, 286);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(135, 13);
            this.label55.TabIndex = 25;
            this.label55.Text = "SaveRAM output directory:";
            // 
            // TbxConvertStatesToSaveRamOutputPath
            // 
            this.TbxConvertStatesToSaveRamOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertStatesToSaveRamOutputPath.Location = new System.Drawing.Point(144, 282);
            this.TbxConvertStatesToSaveRamOutputPath.Name = "TbxConvertStatesToSaveRamOutputPath";
            this.TbxConvertStatesToSaveRamOutputPath.Size = new System.Drawing.Size(281, 20);
            this.TbxConvertStatesToSaveRamOutputPath.TabIndex = 30;
            // 
            // BtnConvertStatesToSaveRamRefresh
            // 
            this.BtnConvertStatesToSaveRamRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamRefresh.AutoSize = true;
            this.BtnConvertStatesToSaveRamRefresh.Location = new System.Drawing.Point(512, 3);
            this.BtnConvertStatesToSaveRamRefresh.Name = "BtnConvertStatesToSaveRamRefresh";
            this.BtnConvertStatesToSaveRamRefresh.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamRefresh.TabIndex = 15;
            this.BtnConvertStatesToSaveRamRefresh.Text = "Refresh";
            this.BtnConvertStatesToSaveRamRefresh.UseVisualStyleBackColor = true;
            this.BtnConvertStatesToSaveRamRefresh.Click += new System.EventHandler(this.BtnConvertStatesToSaveRamRefresh_Click);
            // 
            // TbpConvertSaveRamToStates
            // 
            this.TbpConvertSaveRamToStates.Controls.Add(this.tableLayoutPanel16);
            this.TbpConvertSaveRamToStates.Location = new System.Drawing.Point(4, 22);
            this.TbpConvertSaveRamToStates.Name = "TbpConvertSaveRamToStates";
            this.TbpConvertSaveRamToStates.Padding = new System.Windows.Forms.Padding(3);
            this.TbpConvertSaveRamToStates.Size = new System.Drawing.Size(602, 320);
            this.TbpConvertSaveRamToStates.TabIndex = 1;
            this.TbpConvertSaveRamToStates.Text = "SaveRAM to states";
            this.TbpConvertSaveRamToStates.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 4;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel16.Controls.Add(this.BtnConvertSaveRamToStatesOutputPathBrowse, 2, 2);
            this.tableLayoutPanel16.Controls.Add(this.label57, 0, 2);
            this.tableLayoutPanel16.Controls.Add(this.BtnConvertSaveRamToStatesGo, 3, 2);
            this.tableLayoutPanel16.Controls.Add(this.label56, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.TbxConvertSaveRamToStatesOutputPath, 1, 2);
            this.tableLayoutPanel16.Controls.Add(this.TbxConvertSaveRamToStatesInputPath, 1, 0);
            this.tableLayoutPanel16.Controls.Add(this.BtnConvertSaveRamToStatesInputPathBrowse, 2, 0);
            this.tableLayoutPanel16.Controls.Add(this.BtnConvertSaveRamToStatesRefresh, 3, 0);
            this.tableLayoutPanel16.Controls.Add(this.LbxConvertSaveRamToStates, 0, 1);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 3;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel16.Size = new System.Drawing.Size(590, 308);
            this.tableLayoutPanel16.TabIndex = 32;
            // 
            // BtnConvertSaveRamToStatesOutputPathBrowse
            // 
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.AutoSize = true;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Location = new System.Drawing.Point(431, 280);
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Name = "BtnConvertSaveRamToStatesOutputPathBrowse";
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesOutputPathBrowse.TabIndex = 35;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Text = "...";
            this.BtnConvertSaveRamToStatesOutputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesOutputPathBrowse.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesOutputPathBrowse_Click);
            // 
            // label57
            // 
            this.label57.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(3, 286);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(137, 13);
            this.label57.TabIndex = 25;
            this.label57.Text = "Save state output directory:";
            // 
            // BtnConvertSaveRamToStatesGo
            // 
            this.BtnConvertSaveRamToStatesGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesGo.AutoSize = true;
            this.BtnConvertSaveRamToStatesGo.Location = new System.Drawing.Point(512, 280);
            this.BtnConvertSaveRamToStatesGo.Name = "BtnConvertSaveRamToStatesGo";
            this.BtnConvertSaveRamToStatesGo.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesGo.TabIndex = 40;
            this.BtnConvertSaveRamToStatesGo.Text = "Go";
            this.BtnConvertSaveRamToStatesGo.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesGo.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesGo_Click);
            // 
            // label56
            // 
            this.label56.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(12, 9);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(128, 13);
            this.label56.TabIndex = 0;
            this.label56.Text = "SaveRAM input directory:";
            // 
            // TbxConvertSaveRamToStatesOutputPath
            // 
            this.TbxConvertSaveRamToStatesOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesOutputPath.Location = new System.Drawing.Point(146, 282);
            this.TbxConvertSaveRamToStatesOutputPath.Name = "TbxConvertSaveRamToStatesOutputPath";
            this.TbxConvertSaveRamToStatesOutputPath.Size = new System.Drawing.Size(279, 20);
            this.TbxConvertSaveRamToStatesOutputPath.TabIndex = 30;
            // 
            // TbxConvertSaveRamToStatesInputPath
            // 
            this.TbxConvertSaveRamToStatesInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesInputPath.Location = new System.Drawing.Point(146, 5);
            this.TbxConvertSaveRamToStatesInputPath.Name = "TbxConvertSaveRamToStatesInputPath";
            this.TbxConvertSaveRamToStatesInputPath.Size = new System.Drawing.Size(279, 20);
            this.TbxConvertSaveRamToStatesInputPath.TabIndex = 5;
            this.TbxConvertSaveRamToStatesInputPath.TextChanged += new System.EventHandler(this.TbxConvertSaveRamToStatesInputPath_TextChanged);
            // 
            // BtnConvertSaveRamToStatesInputPathBrowse
            // 
            this.BtnConvertSaveRamToStatesInputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesInputPathBrowse.AutoSize = true;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Location = new System.Drawing.Point(431, 3);
            this.BtnConvertSaveRamToStatesInputPathBrowse.Name = "BtnConvertSaveRamToStatesInputPathBrowse";
            this.BtnConvertSaveRamToStatesInputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesInputPathBrowse.TabIndex = 10;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Text = "...";
            this.BtnConvertSaveRamToStatesInputPathBrowse.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesInputPathBrowse_Click);
            // 
            // BtnConvertSaveRamToStatesRefresh
            // 
            this.BtnConvertSaveRamToStatesRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesRefresh.AutoSize = true;
            this.BtnConvertSaveRamToStatesRefresh.Location = new System.Drawing.Point(512, 3);
            this.BtnConvertSaveRamToStatesRefresh.Name = "BtnConvertSaveRamToStatesRefresh";
            this.BtnConvertSaveRamToStatesRefresh.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesRefresh.TabIndex = 15;
            this.BtnConvertSaveRamToStatesRefresh.Text = "Refresh";
            this.BtnConvertSaveRamToStatesRefresh.UseVisualStyleBackColor = true;
            this.BtnConvertSaveRamToStatesRefresh.Click += new System.EventHandler(this.BtnConvertSaveRamToStatesRefresh_Click);
            // 
            // LbxConvertSaveRamToStates
            // 
            this.LbxConvertSaveRamToStates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel16.SetColumnSpan(this.LbxConvertSaveRamToStates, 4);
            this.LbxConvertSaveRamToStates.FormattingEnabled = true;
            this.LbxConvertSaveRamToStates.HorizontalScrollbar = true;
            this.LbxConvertSaveRamToStates.IntegralHeight = false;
            this.LbxConvertSaveRamToStates.Location = new System.Drawing.Point(3, 34);
            this.LbxConvertSaveRamToStates.Name = "LbxConvertSaveRamToStates";
            this.LbxConvertSaveRamToStates.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxConvertSaveRamToStates.Size = new System.Drawing.Size(584, 240);
            this.LbxConvertSaveRamToStates.TabIndex = 20;
            // 
            // PbxHazardStripes
            // 
            this.PbxHazardStripes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PbxHazardStripes.Location = new System.Drawing.Point(0, 0);
            this.PbxHazardStripes.Name = "PbxHazardStripes";
            this.PbxHazardStripes.Size = new System.Drawing.Size(664, 482);
            this.PbxHazardStripes.TabIndex = 8;
            this.PbxHazardStripes.TabStop = false;
            this.PbxHazardStripes.SizeChanged += new System.EventHandler(this.PbxHazardStripes_SizeChanged);
            this.PbxHazardStripes.VisibleChanged += new System.EventHandler(this.PbxHazardStripes_VisibleChanged);
            // 
            // BtnSaveRamExport
            // 
            this.BtnSaveRamExport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamExport.AutoSize = true;
            this.BtnSaveRamExport.Location = new System.Drawing.Point(3, 3);
            this.BtnSaveRamExport.Name = "BtnSaveRamExport";
            this.BtnSaveRamExport.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamExport.TabIndex = 0;
            this.BtnSaveRamExport.Text = "Export";
            this.BtnSaveRamExport.UseVisualStyleBackColor = true;
            this.BtnSaveRamExport.Click += new System.EventHandler(this.BtnSaveRamExport_Click);
            // 
            // TbxSaveRamExportPath
            // 
            this.TbxSaveRamExportPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSaveRamExportPath.Location = new System.Drawing.Point(84, 5);
            this.TbxSaveRamExportPath.Name = "TbxSaveRamExportPath";
            this.TbxSaveRamExportPath.Size = new System.Drawing.Size(502, 20);
            this.TbxSaveRamExportPath.TabIndex = 5;
            // 
            // BtnSaveRamExportBrowse
            // 
            this.BtnSaveRamExportBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamExportBrowse.AutoSize = true;
            this.BtnSaveRamExportBrowse.Location = new System.Drawing.Point(592, 3);
            this.BtnSaveRamExportBrowse.Name = "BtnSaveRamExportBrowse";
            this.BtnSaveRamExportBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamExportBrowse.TabIndex = 10;
            this.BtnSaveRamExportBrowse.Text = "...";
            this.BtnSaveRamExportBrowse.UseVisualStyleBackColor = true;
            this.BtnSaveRamExportBrowse.Click += new System.EventHandler(this.BtnSaveRamExportBrowse_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.BtnOpenSaveMenu);
            this.groupBox4.Controls.Add(this.CmbSaveButton);
            this.groupBox4.Location = new System.Drawing.Point(6, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(676, 61);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In-game saves";
            // 
            // BtnOpenSaveMenu
            // 
            this.BtnOpenSaveMenu.AutoSize = true;
            this.BtnOpenSaveMenu.Location = new System.Drawing.Point(6, 19);
            this.BtnOpenSaveMenu.Name = "BtnOpenSaveMenu";
            this.BtnOpenSaveMenu.Size = new System.Drawing.Size(147, 23);
            this.BtnOpenSaveMenu.TabIndex = 0;
            this.BtnOpenSaveMenu.Text = "Open save menu";
            this.BtnOpenSaveMenu.UseVisualStyleBackColor = true;
            this.BtnOpenSaveMenu.Click += new System.EventHandler(this.BtnOpenSaveMenu_Click);
            // 
            // CmbSaveButton
            // 
            this.CmbSaveButton.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSaveButton.FormattingEnabled = true;
            this.CmbSaveButton.Location = new System.Drawing.Point(159, 20);
            this.CmbSaveButton.Name = "CmbSaveButton";
            this.CmbSaveButton.Size = new System.Drawing.Size(99, 21);
            this.CmbSaveButton.TabIndex = 5;
            this.CmbSaveButton.SelectedValueChanged += new System.EventHandler(this.CmbSaveButton_SelectedValueChanged);
            // 
            // TbpTest
            // 
            this.TbpTest.Controls.Add(this.groupBox6);
            this.TbpTest.Controls.Add(this.groupBox5);
            this.TbpTest.Location = new System.Drawing.Point(4, 22);
            this.TbpTest.Name = "TbpTest";
            this.TbpTest.Padding = new System.Windows.Forms.Padding(3);
            this.TbpTest.Size = new System.Drawing.Size(688, 618);
            this.TbpTest.TabIndex = 2;
            this.TbpTest.Text = "Test";
            this.TbpTest.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.AutoSize = true;
            this.groupBox6.Controls.Add(this.tableLayoutPanel20);
            this.groupBox6.Location = new System.Drawing.Point(7, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(675, 196);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Model";
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.TrkTestModelScale, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel20.Controls.Add(this.LblTestModelScale, 1, 1);
            this.tableLayoutPanel20.Controls.Add(this.CbxEnableTestModelSection, 1, 2);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 3;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.Size = new System.Drawing.Size(669, 177);
            this.tableLayoutPanel20.TabIndex = 0;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel9.AutoSize = true;
            this.tableLayoutPanel9.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel9.Controls.Add(this.CmbModelSubmeshName, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.BtnReadHarryModel, 0, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(258, 31);
            this.tableLayoutPanel9.TabIndex = 5;
            // 
            // CmbModelSubmeshName
            // 
            this.CmbModelSubmeshName.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            this.CmbModelSubmeshName.Location = new System.Drawing.Point(134, 5);
            this.CmbModelSubmeshName.Name = "CmbModelSubmeshName";
            this.CmbModelSubmeshName.Size = new System.Drawing.Size(121, 21);
            this.CmbModelSubmeshName.TabIndex = 5;
            this.CmbModelSubmeshName.Text = "HEAD1";
            // 
            // BtnReadHarryModel
            // 
            this.BtnReadHarryModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadHarryModel.AutoSize = true;
            this.BtnReadHarryModel.Location = new System.Drawing.Point(3, 3);
            this.BtnReadHarryModel.Name = "BtnReadHarryModel";
            this.BtnReadHarryModel.Size = new System.Drawing.Size(125, 25);
            this.BtnReadHarryModel.TabIndex = 0;
            this.BtnReadHarryModel.Text = "Read Harry submesh";
            this.BtnReadHarryModel.UseVisualStyleBackColor = true;
            this.BtnReadHarryModel.Click += new System.EventHandler(this.BtnReadHarryModel_Click);
            // 
            // TrkTestModelScale
            // 
            this.TrkTestModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrkTestModelScale.Location = new System.Drawing.Point(3, 59);
            this.TrkTestModelScale.Maximum = 2000;
            this.TrkTestModelScale.Minimum = 1;
            this.TrkTestModelScale.Name = "TrkTestModelScale";
            this.TrkTestModelScale.Size = new System.Drawing.Size(430, 45);
            this.TrkTestModelScale.TabIndex = 10;
            this.toolTip1.SetToolTip(this.TrkTestModelScale, "Arbitrary model scale factor");
            this.TrkTestModelScale.Value = 1;
            this.TrkTestModelScale.Scroll += new System.EventHandler(this.TrkModelScale_Scroll);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel8.AutoSize = true;
            this.tableLayoutPanel8.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel8.ColumnCount = 5;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel8.Controls.Add(this.NudTestModelX, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.NudTestModelY, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.NudTestModelZ, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.LblModelX, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.LblModelY, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.LblModelZ, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.BtnTestModelSetPosition, 4, 1);
            this.tableLayoutPanel8.Controls.Add(this.BtnTestModelGetPosition, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 130);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(430, 44);
            this.tableLayoutPanel8.TabIndex = 20;
            // 
            // NudTestModelX
            // 
            this.NudTestModelX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudTestModelX.Location = new System.Drawing.Point(134, 18);
            this.NudTestModelX.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudTestModelX.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudTestModelX.Name = "NudTestModelX";
            this.NudTestModelX.Size = new System.Drawing.Size(50, 20);
            this.NudTestModelX.TabIndex = 10;
            this.NudTestModelX.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudTestModelX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestModelX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestModelY
            // 
            this.NudTestModelY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudTestModelY.Location = new System.Drawing.Point(190, 18);
            this.NudTestModelY.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudTestModelY.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudTestModelY.Name = "NudTestModelY";
            this.NudTestModelY.Size = new System.Drawing.Size(50, 20);
            this.NudTestModelY.TabIndex = 20;
            this.NudTestModelY.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudTestModelY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestModelY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestModelZ
            // 
            this.NudTestModelZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudTestModelZ.Location = new System.Drawing.Point(246, 18);
            this.NudTestModelZ.Maximum = new decimal(new int[] {
            32768,
            0,
            0,
            0});
            this.NudTestModelZ.Minimum = new decimal(new int[] {
            32768,
            0,
            0,
            -2147483648});
            this.NudTestModelZ.Name = "NudTestModelZ";
            this.NudTestModelZ.Size = new System.Drawing.Size(50, 20);
            this.NudTestModelZ.TabIndex = 30;
            this.NudTestModelZ.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudTestModelZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestModelZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestModelZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // LblModelX
            // 
            this.LblModelX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelX.AutoSize = true;
            this.LblModelX.Location = new System.Drawing.Point(147, 0);
            this.LblModelX.Name = "LblModelX";
            this.LblModelX.Size = new System.Drawing.Size(24, 13);
            this.LblModelX.TabIndex = 5;
            this.LblModelX.Text = "<x>";
            // 
            // LblModelY
            // 
            this.LblModelY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelY.AutoSize = true;
            this.LblModelY.Location = new System.Drawing.Point(203, 0);
            this.LblModelY.Name = "LblModelY";
            this.LblModelY.Size = new System.Drawing.Size(24, 13);
            this.LblModelY.TabIndex = 15;
            this.LblModelY.Text = "<y>";
            // 
            // LblModelZ
            // 
            this.LblModelZ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelZ.AutoSize = true;
            this.LblModelZ.Location = new System.Drawing.Point(259, 0);
            this.LblModelZ.Name = "LblModelZ";
            this.LblModelZ.Size = new System.Drawing.Size(24, 13);
            this.LblModelZ.TabIndex = 25;
            this.LblModelZ.Text = "<z>";
            // 
            // BtnTestModelSetPosition
            // 
            this.BtnTestModelSetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnTestModelSetPosition.AutoSize = true;
            this.BtnTestModelSetPosition.Location = new System.Drawing.Point(302, 16);
            this.BtnTestModelSetPosition.Name = "BtnTestModelSetPosition";
            this.BtnTestModelSetPosition.Size = new System.Drawing.Size(125, 25);
            this.BtnTestModelSetPosition.TabIndex = 35;
            this.BtnTestModelSetPosition.Text = "Set model position";
            this.BtnTestModelSetPosition.UseVisualStyleBackColor = true;
            this.BtnTestModelSetPosition.Click += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            // 
            // BtnTestModelGetPosition
            // 
            this.BtnTestModelGetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnTestModelGetPosition.AutoSize = true;
            this.BtnTestModelGetPosition.Location = new System.Drawing.Point(3, 16);
            this.BtnTestModelGetPosition.Name = "BtnTestModelGetPosition";
            this.BtnTestModelGetPosition.Size = new System.Drawing.Size(125, 25);
            this.BtnTestModelGetPosition.TabIndex = 0;
            this.BtnTestModelGetPosition.Text = "Get Harry position";
            this.BtnTestModelGetPosition.UseVisualStyleBackColor = true;
            this.BtnTestModelGetPosition.Click += new System.EventHandler(this.BtnModelGetHarryPosition_Click);
            // 
            // LblTestModelScale
            // 
            this.LblTestModelScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTestModelScale.Location = new System.Drawing.Point(439, 74);
            this.LblTestModelScale.Name = "LblTestModelScale";
            this.LblTestModelScale.Size = new System.Drawing.Size(45, 15);
            this.LblTestModelScale.TabIndex = 15;
            this.LblTestModelScale.Text = "1";
            this.toolTip1.SetToolTip(this.LblTestModelScale, "Arbitrary model scale factor");
            // 
            // CbxEnableTestModelSection
            // 
            this.CbxEnableTestModelSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableTestModelSection.AutoSize = true;
            this.CbxEnableTestModelSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableTestModelSection.Location = new System.Drawing.Point(607, 157);
            this.CbxEnableTestModelSection.Name = "CbxEnableTestModelSection";
            this.CbxEnableTestModelSection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableTestModelSection.TabIndex = 0;
            this.CbxEnableTestModelSection.Text = "Enable";
            this.CbxEnableTestModelSection.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.AutoSize = true;
            this.groupBox5.Controls.Add(this.tableLayoutPanel7);
            this.groupBox5.Location = new System.Drawing.Point(6, 208);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(676, 404);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Boxes";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel5, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(670, 110);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.ColumnCount = 4;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxSizeX, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxSizeY, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxSizeZ, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.CbxEnableTestBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label53, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.label37, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.label54, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxX, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxY, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.NudTestBoxZ, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.label30, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label29, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label28, 0, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(189, 104);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // NudTestBoxSizeX
            // 
            this.NudTestBoxSizeX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxSizeX.Location = new System.Drawing.Point(132, 29);
            this.NudTestBoxSizeX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxSizeX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxSizeX.Name = "NudTestBoxSizeX";
            this.NudTestBoxSizeX.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxSizeX.TabIndex = 40;
            this.toolTip1.SetToolTip(this.NudTestBoxSizeX, "The test box\'s position in SH coordinates");
            this.NudTestBoxSizeX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestBoxSizeX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeX_ValueChanged);
            this.NudTestBoxSizeX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxSizeX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestBoxSizeY
            // 
            this.NudTestBoxSizeY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxSizeY.Location = new System.Drawing.Point(132, 55);
            this.NudTestBoxSizeY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxSizeY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxSizeY.Name = "NudTestBoxSizeY";
            this.NudTestBoxSizeY.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxSizeY.TabIndex = 50;
            this.toolTip1.SetToolTip(this.NudTestBoxSizeY, "The test box\'s position in SH coordinates");
            this.NudTestBoxSizeY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestBoxSizeY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeY_ValueChanged);
            this.NudTestBoxSizeY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxSizeY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestBoxSizeZ
            // 
            this.NudTestBoxSizeZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxSizeZ.Location = new System.Drawing.Point(132, 81);
            this.NudTestBoxSizeZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxSizeZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxSizeZ.Name = "NudTestBoxSizeZ";
            this.NudTestBoxSizeZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxSizeZ.TabIndex = 60;
            this.toolTip1.SetToolTip(this.NudTestBoxSizeZ, "The test box\'s position in SH coordinates");
            this.NudTestBoxSizeZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestBoxSizeZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxSizeZ_ValueChanged);
            this.NudTestBoxSizeZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxSizeZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxSizeZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // CbxEnableTestBox
            // 
            this.CbxEnableTestBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxEnableTestBox.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.CbxEnableTestBox, 4);
            this.CbxEnableTestBox.Location = new System.Drawing.Point(61, 4);
            this.CbxEnableTestBox.Name = "CbxEnableTestBox";
            this.CbxEnableTestBox.Size = new System.Drawing.Size(67, 17);
            this.CbxEnableTestBox.TabIndex = 0;
            this.CbxEnableTestBox.Text = "Test box";
            this.CbxEnableTestBox.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(86, 58);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 13);
            this.label53.TabIndex = 45;
            this.label53.Text = "Size Y:";
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(86, 84);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 13);
            this.label37.TabIndex = 55;
            this.label37.Text = "Size Z:";
            // 
            // label54
            // 
            this.label54.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(86, 32);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(40, 13);
            this.label54.TabIndex = 35;
            this.label54.Text = "Size X:";
            // 
            // NudTestBoxX
            // 
            this.NudTestBoxX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxX.Location = new System.Drawing.Point(26, 29);
            this.NudTestBoxX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxX.Name = "NudTestBoxX";
            this.NudTestBoxX.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxX.TabIndex = 10;
            this.toolTip1.SetToolTip(this.NudTestBoxX, "The test box\'s position in SH coordinates");
            this.NudTestBoxX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxX_ValueChanged);
            this.NudTestBoxX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestBoxY
            // 
            this.NudTestBoxY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxY.Location = new System.Drawing.Point(26, 55);
            this.NudTestBoxY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxY.Name = "NudTestBoxY";
            this.NudTestBoxY.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxY.TabIndex = 20;
            this.toolTip1.SetToolTip(this.NudTestBoxY, "The test box\'s position in SH coordinates");
            this.NudTestBoxY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxY_ValueChanged);
            this.NudTestBoxY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestBoxZ
            // 
            this.NudTestBoxZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestBoxZ.Location = new System.Drawing.Point(26, 81);
            this.NudTestBoxZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestBoxZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestBoxZ.Name = "NudTestBoxZ";
            this.NudTestBoxZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestBoxZ.TabIndex = 30;
            this.toolTip1.SetToolTip(this.NudTestBoxZ, "The test box\'s position in SH coordinates");
            this.NudTestBoxZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxZ_ValueChanged);
            this.NudTestBoxZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestBoxZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestBoxZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 13);
            this.label30.TabIndex = 5;
            this.label30.Text = "X:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 13);
            this.label29.TabIndex = 15;
            this.label29.Text = "Y:";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 84);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 13);
            this.label28.TabIndex = 25;
            this.label28.Text = "Z:";
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(this.CbxEnableTestSheet, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.NudTestSheetX, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.NudTestSheetSizeX, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.label86, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label85, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.label87, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label79, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.label88, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.NudTestSheetSizeZ, 3, 3);
            this.tableLayoutPanel6.Controls.Add(this.NudTestSheetZ, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.NudTestSheetY, 1, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(478, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(189, 104);
            this.tableLayoutPanel6.TabIndex = 10;
            // 
            // CbxEnableTestSheet
            // 
            this.CbxEnableTestSheet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxEnableTestSheet.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.CbxEnableTestSheet, 4);
            this.CbxEnableTestSheet.Location = new System.Drawing.Point(56, 4);
            this.CbxEnableTestSheet.Name = "CbxEnableTestSheet";
            this.CbxEnableTestSheet.Size = new System.Drawing.Size(76, 17);
            this.CbxEnableTestSheet.TabIndex = 0;
            this.CbxEnableTestSheet.Text = "Test sheet";
            this.CbxEnableTestSheet.UseVisualStyleBackColor = true;
            // 
            // NudTestSheetX
            // 
            this.NudTestSheetX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestSheetX.Location = new System.Drawing.Point(26, 29);
            this.NudTestSheetX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestSheetX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestSheetX.Name = "NudTestSheetX";
            this.NudTestSheetX.Size = new System.Drawing.Size(54, 20);
            this.NudTestSheetX.TabIndex = 10;
            this.toolTip1.SetToolTip(this.NudTestSheetX, "The test box\'s position in SH coordinates");
            this.NudTestSheetX.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetX_ValueChanged);
            this.NudTestSheetX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestSheetX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestSheetSizeX
            // 
            this.NudTestSheetSizeX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestSheetSizeX.Location = new System.Drawing.Point(132, 29);
            this.NudTestSheetSizeX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestSheetSizeX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestSheetSizeX.Name = "NudTestSheetSizeX";
            this.NudTestSheetSizeX.Size = new System.Drawing.Size(54, 20);
            this.NudTestSheetSizeX.TabIndex = 40;
            this.toolTip1.SetToolTip(this.NudTestSheetSizeX, "The test box\'s position in SH coordinates");
            this.NudTestSheetSizeX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestSheetSizeX.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetSizeX_ValueChanged);
            this.NudTestSheetSizeX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetSizeX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetSizeX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestSheetSizeX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label86
            // 
            this.label86.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(3, 84);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(17, 13);
            this.label86.TabIndex = 25;
            this.label86.Text = "Z:";
            // 
            // label85
            // 
            this.label85.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(86, 32);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(40, 13);
            this.label85.TabIndex = 35;
            this.label85.Text = "Size X:";
            // 
            // label87
            // 
            this.label87.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(3, 58);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(17, 13);
            this.label87.TabIndex = 15;
            this.label87.Text = "Y:";
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(86, 84);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(40, 13);
            this.label79.TabIndex = 45;
            this.label79.Text = "Size Z:";
            // 
            // label88
            // 
            this.label88.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(3, 32);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(17, 13);
            this.label88.TabIndex = 5;
            this.label88.Text = "X:";
            // 
            // NudTestSheetSizeZ
            // 
            this.NudTestSheetSizeZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestSheetSizeZ.Location = new System.Drawing.Point(132, 81);
            this.NudTestSheetSizeZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestSheetSizeZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestSheetSizeZ.Name = "NudTestSheetSizeZ";
            this.NudTestSheetSizeZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestSheetSizeZ.TabIndex = 50;
            this.toolTip1.SetToolTip(this.NudTestSheetSizeZ, "The test box\'s position in SH coordinates");
            this.NudTestSheetSizeZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestSheetSizeZ.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetSizeZ_ValueChanged);
            this.NudTestSheetSizeZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetSizeZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetSizeZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestSheetSizeZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestSheetZ
            // 
            this.NudTestSheetZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestSheetZ.Location = new System.Drawing.Point(26, 81);
            this.NudTestSheetZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestSheetZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestSheetZ.Name = "NudTestSheetZ";
            this.NudTestSheetZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestSheetZ.TabIndex = 30;
            this.toolTip1.SetToolTip(this.NudTestSheetZ, "The test box\'s position in SH coordinates");
            this.NudTestSheetZ.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetZ_ValueChanged);
            this.NudTestSheetZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestSheetZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestSheetY
            // 
            this.NudTestSheetY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestSheetY.Location = new System.Drawing.Point(26, 55);
            this.NudTestSheetY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestSheetY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestSheetY.Name = "NudTestSheetY";
            this.NudTestSheetY.Size = new System.Drawing.Size(54, 20);
            this.NudTestSheetY.TabIndex = 20;
            this.toolTip1.SetToolTip(this.NudTestSheetY, "The test box\'s position in SH coordinates");
            this.NudTestSheetY.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetY_ValueChanged);
            this.NudTestSheetY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestSheetY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestSheetY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.CbxEnableTestLine, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineAX, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineAY, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineAZ, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineBX, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineBY, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.NudTestLineBZ, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.label31, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.label34, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.label36, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label20, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label17, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.label16, 0, 3);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(252, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 4;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(166, 104);
            this.tableLayoutPanel5.TabIndex = 5;
            // 
            // CbxEnableTestLine
            // 
            this.CbxEnableTestLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxEnableTestLine.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.CbxEnableTestLine, 4);
            this.CbxEnableTestLine.Location = new System.Drawing.Point(50, 4);
            this.CbxEnableTestLine.Name = "CbxEnableTestLine";
            this.CbxEnableTestLine.Size = new System.Drawing.Size(66, 17);
            this.CbxEnableTestLine.TabIndex = 0;
            this.CbxEnableTestLine.Text = "Test line";
            this.CbxEnableTestLine.UseVisualStyleBackColor = true;
            // 
            // NudTestLineAX
            // 
            this.NudTestLineAX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineAX.Location = new System.Drawing.Point(26, 29);
            this.NudTestLineAX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineAX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineAX.Name = "NudTestLineAX";
            this.NudTestLineAX.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineAX.TabIndex = 10;
            this.toolTip1.SetToolTip(this.NudTestLineAX, "The test box\'s position in SH coordinates");
            this.NudTestLineAX.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAX_ValueChanged);
            this.NudTestLineAX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineAX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestLineAY
            // 
            this.NudTestLineAY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineAY.Location = new System.Drawing.Point(26, 55);
            this.NudTestLineAY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineAY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineAY.Name = "NudTestLineAY";
            this.NudTestLineAY.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineAY.TabIndex = 20;
            this.toolTip1.SetToolTip(this.NudTestLineAY, "The test box\'s position in SH coordinates");
            this.NudTestLineAY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudTestLineAY.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAY_ValueChanged);
            this.NudTestLineAY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineAY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestLineAZ
            // 
            this.NudTestLineAZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineAZ.Location = new System.Drawing.Point(26, 81);
            this.NudTestLineAZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineAZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineAZ.Name = "NudTestLineAZ";
            this.NudTestLineAZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineAZ.TabIndex = 30;
            this.toolTip1.SetToolTip(this.NudTestLineAZ, "The test box\'s position in SH coordinates");
            this.NudTestLineAZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAZ_ValueChanged);
            this.NudTestLineAZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineAZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineAZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestLineBX
            // 
            this.NudTestLineBX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineBX.Location = new System.Drawing.Point(109, 29);
            this.NudTestLineBX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineBX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineBX.Name = "NudTestLineBX";
            this.NudTestLineBX.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineBX.TabIndex = 40;
            this.toolTip1.SetToolTip(this.NudTestLineBX, "The test box\'s position in SH coordinates");
            this.NudTestLineBX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudTestLineBX.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBX_ValueChanged);
            this.NudTestLineBX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineBX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestLineBY
            // 
            this.NudTestLineBY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineBY.Location = new System.Drawing.Point(109, 55);
            this.NudTestLineBY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineBY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineBY.Name = "NudTestLineBY";
            this.NudTestLineBY.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineBY.TabIndex = 50;
            this.toolTip1.SetToolTip(this.NudTestLineBY, "The test box\'s position in SH coordinates");
            this.NudTestLineBY.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudTestLineBY.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBY_ValueChanged);
            this.NudTestLineBY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineBY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudTestLineBZ
            // 
            this.NudTestLineBZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudTestLineBZ.Location = new System.Drawing.Point(109, 81);
            this.NudTestLineBZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudTestLineBZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudTestLineBZ.Name = "NudTestLineBZ";
            this.NudTestLineBZ.Size = new System.Drawing.Size(54, 20);
            this.NudTestLineBZ.TabIndex = 60;
            this.toolTip1.SetToolTip(this.NudTestLineBZ, "The test box\'s position in SH coordinates");
            this.NudTestLineBZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBZ_ValueChanged);
            this.NudTestLineBZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudTestLineBZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Nud_KeyDown);
            this.NudTestLineBZ.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(86, 84);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 13);
            this.label31.TabIndex = 55;
            this.label31.Text = "Z:";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(86, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 13);
            this.label34.TabIndex = 45;
            this.label34.Text = "Y:";
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(86, 32);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 13);
            this.label36.TabIndex = 35;
            this.label36.Text = "X:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 13);
            this.label20.TabIndex = 5;
            this.label20.Text = "X:";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Y:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 13);
            this.label16.TabIndex = 25;
            this.label16.Text = "Z:";
            // 
            // TbpFiles
            // 
            this.TbpFiles.Controls.Add(this.tableLayoutPanel19);
            this.TbpFiles.Location = new System.Drawing.Point(4, 22);
            this.TbpFiles.Name = "TbpFiles";
            this.TbpFiles.Padding = new System.Windows.Forms.Padding(3);
            this.TbpFiles.Size = new System.Drawing.Size(688, 618);
            this.TbpFiles.TabIndex = 10;
            this.TbpFiles.Text = "Files";
            this.TbpFiles.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 1;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Controls.Add(this.BtnReadFiles, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.splitContainer1, 0, 1);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 2;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(682, 612);
            this.tableLayoutPanel19.TabIndex = 0;
            // 
            // BtnReadFiles
            // 
            this.BtnReadFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReadFiles.AutoSize = true;
            this.BtnReadFiles.Location = new System.Drawing.Point(3, 3);
            this.BtnReadFiles.Name = "BtnReadFiles";
            this.BtnReadFiles.Size = new System.Drawing.Size(125, 25);
            this.BtnReadFiles.TabIndex = 0;
            this.BtnReadFiles.Text = "Read file records";
            this.BtnReadFiles.UseVisualStyleBackColor = true;
            this.BtnReadFiles.Click += new System.EventHandler(this.BtnReadFiles_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 34);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.LbxFilesDirectories);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LbxFilesFiles);
            this.splitContainer1.Size = new System.Drawing.Size(676, 575);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 5;
            // 
            // LbxFilesDirectories
            // 
            this.LbxFilesDirectories.ContextMenuStrip = this.CmsFilesDirectories;
            this.LbxFilesDirectories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxFilesDirectories.FormattingEnabled = true;
            this.LbxFilesDirectories.IntegralHeight = false;
            this.LbxFilesDirectories.Location = new System.Drawing.Point(0, 0);
            this.LbxFilesDirectories.Name = "LbxFilesDirectories";
            this.LbxFilesDirectories.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxFilesDirectories.Size = new System.Drawing.Size(150, 575);
            this.LbxFilesDirectories.TabIndex = 0;
            this.LbxFilesDirectories.SelectedIndexChanged += new System.EventHandler(this.LbxFilesDirectories_SelectedIndexChanged);
            // 
            // CmsFilesDirectories
            // 
            this.CmsFilesDirectories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractSelectedToolStripMenuItem});
            this.CmsFilesDirectories.Name = "CmsFilesDirectories";
            this.CmsFilesDirectories.Size = new System.Drawing.Size(215, 26);
            // 
            // extractSelectedToolStripMenuItem
            // 
            this.extractSelectedToolStripMenuItem.Name = "extractSelectedToolStripMenuItem";
            this.extractSelectedToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.extractSelectedToolStripMenuItem.Text = "Extract selected directories";
            this.extractSelectedToolStripMenuItem.Click += new System.EventHandler(this.ExtractSelectedDirectoriesToolStripMenuItem_Click);
            // 
            // LbxFilesFiles
            // 
            this.LbxFilesFiles.ContextMenuStrip = this.CmsFilesFiles;
            this.LbxFilesFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxFilesFiles.FormattingEnabled = true;
            this.LbxFilesFiles.IntegralHeight = false;
            this.LbxFilesFiles.Location = new System.Drawing.Point(0, 0);
            this.LbxFilesFiles.Name = "LbxFilesFiles";
            this.LbxFilesFiles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.LbxFilesFiles.Size = new System.Drawing.Size(522, 575);
            this.LbxFilesFiles.TabIndex = 0;
            // 
            // CmsFilesFiles
            // 
            this.CmsFilesFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.extractSelectedFilesToolStripMenuItem});
            this.CmsFilesFiles.Name = "CmsFilesFiles";
            this.CmsFilesFiles.Size = new System.Drawing.Size(181, 26);
            // 
            // extractSelectedFilesToolStripMenuItem
            // 
            this.extractSelectedFilesToolStripMenuItem.Name = "extractSelectedFilesToolStripMenuItem";
            this.extractSelectedFilesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractSelectedFilesToolStripMenuItem.Text = "Extract selected files";
            this.extractSelectedFilesToolStripMenuItem.Click += new System.EventHandler(this.ExtractSelectedFilesToolStripMenuItem_Click);
            // 
            // TbpFramebuffer
            // 
            this.TbpFramebuffer.Controls.Add(this.TlpFramebufferTab);
            this.TbpFramebuffer.Location = new System.Drawing.Point(4, 22);
            this.TbpFramebuffer.Name = "TbpFramebuffer";
            this.TbpFramebuffer.Padding = new System.Windows.Forms.Padding(3);
            this.TbpFramebuffer.Size = new System.Drawing.Size(688, 618);
            this.TbpFramebuffer.TabIndex = 11;
            this.TbpFramebuffer.Text = "Framebuffer";
            this.TbpFramebuffer.UseVisualStyleBackColor = true;
            // 
            // TlpFramebufferTab
            // 
            this.TlpFramebufferTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TlpFramebufferTab.ColumnCount = 1;
            this.TlpFramebufferTab.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TlpFramebufferTab.Controls.Add(this.ScrFramebuffer, 0, 1);
            this.TlpFramebufferTab.Controls.Add(this.tableLayoutPanel11, 0, 0);
            this.TlpFramebufferTab.Location = new System.Drawing.Point(3, 3);
            this.TlpFramebufferTab.Margin = new System.Windows.Forms.Padding(0);
            this.TlpFramebufferTab.Name = "TlpFramebufferTab";
            this.TlpFramebufferTab.RowCount = 2;
            this.TlpFramebufferTab.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpFramebufferTab.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpFramebufferTab.Size = new System.Drawing.Size(682, 612);
            this.TlpFramebufferTab.TabIndex = 0;
            // 
            // ScrFramebuffer
            // 
            this.ScrFramebuffer.AutoScroll = true;
            this.ScrFramebuffer.Controls.Add(this.BpbFramebuffer);
            this.ScrFramebuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScrFramebuffer.Location = new System.Drawing.Point(3, 59);
            this.ScrFramebuffer.Name = "ScrFramebuffer";
            this.ScrFramebuffer.Size = new System.Drawing.Size(676, 550);
            this.ScrFramebuffer.TabIndex = 8;
            this.ScrFramebuffer.Text = "scrollableControl1";
            // 
            // BpbFramebuffer
            // 
            this.BpbFramebuffer.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            this.BpbFramebuffer.Location = new System.Drawing.Point(3, 3);
            this.BpbFramebuffer.Name = "BpbFramebuffer";
            this.BpbFramebuffer.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            this.BpbFramebuffer.Size = new System.Drawing.Size(670, 544);
            this.BpbFramebuffer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BpbFramebuffer.TabIndex = 7;
            this.BpbFramebuffer.TabStop = false;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.AutoSize = true;
            this.tableLayoutPanel11.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel11.ColumnCount = 11;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.Controls.Add(this.BtnFramebufferSave, 10, 0);
            this.tableLayoutPanel11.Controls.Add(this.BtnFramebufferZoomIn, 8, 0);
            this.tableLayoutPanel11.Controls.Add(this.CmbFramebufferZoom, 6, 0);
            this.tableLayoutPanel11.Controls.Add(this.BtnFramebufferGrab, 0, 0);
            this.tableLayoutPanel11.Controls.Add(this.BtnFramebufferZoomOut, 7, 0);
            this.tableLayoutPanel11.Controls.Add(this.label93, 3, 1);
            this.tableLayoutPanel11.Controls.Add(this.label89, 1, 0);
            this.tableLayoutPanel11.Controls.Add(this.label90, 3, 0);
            this.tableLayoutPanel11.Controls.Add(this.NudFramebufferH, 4, 1);
            this.tableLayoutPanel11.Controls.Add(this.NudFramebufferW, 4, 0);
            this.tableLayoutPanel11.Controls.Add(this.label91, 1, 1);
            this.tableLayoutPanel11.Controls.Add(this.NudFramebufferOfsX, 2, 0);
            this.tableLayoutPanel11.Controls.Add(this.NudFramebufferOfsY, 2, 1);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(682, 56);
            this.tableLayoutPanel11.TabIndex = 0;
            // 
            // BtnFramebufferSave
            // 
            this.BtnFramebufferSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFramebufferSave.AutoSize = true;
            this.BtnFramebufferSave.Location = new System.Drawing.Point(604, 3);
            this.BtnFramebufferSave.Name = "BtnFramebufferSave";
            this.tableLayoutPanel11.SetRowSpan(this.BtnFramebufferSave, 2);
            this.BtnFramebufferSave.Size = new System.Drawing.Size(75, 50);
            this.BtnFramebufferSave.TabIndex = 60;
            this.BtnFramebufferSave.Text = "Save";
            this.BtnFramebufferSave.UseVisualStyleBackColor = true;
            this.BtnFramebufferSave.Click += new System.EventHandler(this.BtnFramebufferSave_Click);
            // 
            // BtnFramebufferZoomIn
            // 
            this.BtnFramebufferZoomIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFramebufferZoomIn.AutoSize = true;
            this.BtnFramebufferZoomIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFramebufferZoomIn.Location = new System.Drawing.Point(473, 3);
            this.BtnFramebufferZoomIn.Name = "BtnFramebufferZoomIn";
            this.tableLayoutPanel11.SetRowSpan(this.BtnFramebufferZoomIn, 2);
            this.BtnFramebufferZoomIn.Size = new System.Drawing.Size(50, 50);
            this.BtnFramebufferZoomIn.TabIndex = 55;
            this.BtnFramebufferZoomIn.Text = "+";
            this.BtnFramebufferZoomIn.UseVisualStyleBackColor = true;
            this.BtnFramebufferZoomIn.Click += new System.EventHandler(this.BtnFramebufferZoomIn_Click);
            // 
            // CmbFramebufferZoom
            // 
            this.CmbFramebufferZoom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CmbFramebufferZoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbFramebufferZoom.FormattingEnabled = true;
            this.CmbFramebufferZoom.Location = new System.Drawing.Point(351, 17);
            this.CmbFramebufferZoom.Name = "CmbFramebufferZoom";
            this.tableLayoutPanel11.SetRowSpan(this.CmbFramebufferZoom, 2);
            this.CmbFramebufferZoom.Size = new System.Drawing.Size(60, 21);
            this.CmbFramebufferZoom.TabIndex = 45;
            this.CmbFramebufferZoom.SelectedIndexChanged += new System.EventHandler(this.CmbFramebufferZoom_SelectedIndexChanged);
            // 
            // BtnFramebufferGrab
            // 
            this.BtnFramebufferGrab.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFramebufferGrab.AutoSize = true;
            this.BtnFramebufferGrab.Location = new System.Drawing.Point(3, 3);
            this.BtnFramebufferGrab.Name = "BtnFramebufferGrab";
            this.tableLayoutPanel11.SetRowSpan(this.BtnFramebufferGrab, 2);
            this.BtnFramebufferGrab.Size = new System.Drawing.Size(75, 50);
            this.BtnFramebufferGrab.TabIndex = 0;
            this.BtnFramebufferGrab.Text = "Grab";
            this.BtnFramebufferGrab.UseVisualStyleBackColor = true;
            this.BtnFramebufferGrab.Click += new System.EventHandler(this.BtnFramebufferGrab_Click);
            // 
            // BtnFramebufferZoomOut
            // 
            this.BtnFramebufferZoomOut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFramebufferZoomOut.AutoSize = true;
            this.BtnFramebufferZoomOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnFramebufferZoomOut.Location = new System.Drawing.Point(417, 3);
            this.BtnFramebufferZoomOut.Name = "BtnFramebufferZoomOut";
            this.tableLayoutPanel11.SetRowSpan(this.BtnFramebufferZoomOut, 2);
            this.BtnFramebufferZoomOut.Size = new System.Drawing.Size(50, 50);
            this.BtnFramebufferZoomOut.TabIndex = 50;
            this.BtnFramebufferZoomOut.Text = "-";
            this.BtnFramebufferZoomOut.UseVisualStyleBackColor = true;
            this.BtnFramebufferZoomOut.Click += new System.EventHandler(this.BtnFramebufferZoomOut_Click);
            // 
            // label93
            // 
            this.label93.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label93.AutoSize = true;
            this.label93.Location = new System.Drawing.Point(168, 34);
            this.label93.Name = "label93";
            this.label93.Size = new System.Drawing.Size(41, 13);
            this.label93.TabIndex = 35;
            this.label93.Text = "Height:";
            // 
            // label89
            // 
            this.label89.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(84, 6);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(17, 13);
            this.label89.TabIndex = 5;
            this.label89.Text = "X:";
            // 
            // label90
            // 
            this.label90.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(171, 6);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(38, 13);
            this.label90.TabIndex = 25;
            this.label90.Text = "Width:";
            // 
            // NudFramebufferH
            // 
            this.NudFramebufferH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFramebufferH.Location = new System.Drawing.Point(215, 31);
            this.NudFramebufferH.Maximum = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.NudFramebufferH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudFramebufferH.Name = "NudFramebufferH";
            this.NudFramebufferH.Size = new System.Drawing.Size(55, 20);
            this.NudFramebufferH.TabIndex = 40;
            this.toolTip1.SetToolTip(this.NudFramebufferH, "Height");
            this.NudFramebufferH.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudFramebufferH.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferH.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
            this.NudFramebufferH.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudFramebufferW
            // 
            this.NudFramebufferW.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFramebufferW.Location = new System.Drawing.Point(215, 3);
            this.NudFramebufferW.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudFramebufferW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudFramebufferW.Name = "NudFramebufferW";
            this.NudFramebufferW.Size = new System.Drawing.Size(55, 20);
            this.NudFramebufferW.TabIndex = 30;
            this.toolTip1.SetToolTip(this.NudFramebufferW, "Width");
            this.NudFramebufferW.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudFramebufferW.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferW.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
            this.NudFramebufferW.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // label91
            // 
            this.label91.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(84, 34);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(17, 13);
            this.label91.TabIndex = 15;
            this.label91.Text = "Y:";
            // 
            // NudFramebufferOfsX
            // 
            this.NudFramebufferOfsX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFramebufferOfsX.Location = new System.Drawing.Point(107, 3);
            this.NudFramebufferOfsX.Maximum = new decimal(new int[] {
            1023,
            0,
            0,
            0});
            this.NudFramebufferOfsX.Name = "NudFramebufferOfsX";
            this.NudFramebufferOfsX.Size = new System.Drawing.Size(55, 20);
            this.NudFramebufferOfsX.TabIndex = 10;
            this.toolTip1.SetToolTip(this.NudFramebufferOfsX, "X offset");
            this.NudFramebufferOfsX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
            this.NudFramebufferOfsX.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // NudFramebufferOfsY
            // 
            this.NudFramebufferOfsY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFramebufferOfsY.Location = new System.Drawing.Point(107, 31);
            this.NudFramebufferOfsY.Maximum = new decimal(new int[] {
            511,
            0,
            0,
            0});
            this.NudFramebufferOfsY.Name = "NudFramebufferOfsY";
            this.NudFramebufferOfsY.Size = new System.Drawing.Size(55, 20);
            this.NudFramebufferOfsY.TabIndex = 20;
            this.toolTip1.SetToolTip(this.NudFramebufferOfsY, "Y offset");
            this.NudFramebufferOfsY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
            this.NudFramebufferOfsY.Leave += new System.EventHandler(this.Nud_Leave);
            // 
            // TbpUtility
            // 
            this.TbpUtility.Controls.Add(this.groupBox8);
            this.TbpUtility.Controls.Add(this.groupBox7);
            this.TbpUtility.Location = new System.Drawing.Point(4, 22);
            this.TbpUtility.Name = "TbpUtility";
            this.TbpUtility.Padding = new System.Windows.Forms.Padding(3);
            this.TbpUtility.Size = new System.Drawing.Size(688, 618);
            this.TbpUtility.TabIndex = 12;
            this.TbpUtility.Text = "Utility";
            this.TbpUtility.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.AutoSize = true;
            this.groupBox8.Controls.Add(this.tableLayoutPanel1);
            this.groupBox8.Location = new System.Drawing.Point(6, 312);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(676, 300);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Angles";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.TbxUtilityAnglesGameUnits, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label78, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblUtilityAnglesError, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TbxUtilityAnglesDegrees, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label76, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label75, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(145, 78);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TbxUtilityAnglesGameUnits
            // 
            this.TbxUtilityAnglesGameUnits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityAnglesGameUnits.Location = new System.Drawing.Point(72, 3);
            this.TbxUtilityAnglesGameUnits.Name = "TbxUtilityAnglesGameUnits";
            this.TbxUtilityAnglesGameUnits.Size = new System.Drawing.Size(70, 20);
            this.TbxUtilityAnglesGameUnits.TabIndex = 5;
            this.toolTip1.SetToolTip(this.TbxUtilityAnglesGameUnits, "Hexadecimal, 0x0 through 0xFFF");
            this.TbxUtilityAnglesGameUnits.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityAnglesGameUnits.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityAnglesGameUnits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityAnglesGameUnits_KeyDown);
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(34, 58);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(32, 13);
            this.label78.TabIndex = 20;
            this.label78.Text = "Error:";
            // 
            // LblUtilityAnglesError
            // 
            this.LblUtilityAnglesError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblUtilityAnglesError.AutoSize = true;
            this.LblUtilityAnglesError.Location = new System.Drawing.Point(72, 58);
            this.LblUtilityAnglesError.Name = "LblUtilityAnglesError";
            this.LblUtilityAnglesError.Size = new System.Drawing.Size(33, 13);
            this.LblUtilityAnglesError.TabIndex = 25;
            this.LblUtilityAnglesError.Text = "None";
            // 
            // TbxUtilityAnglesDegrees
            // 
            this.TbxUtilityAnglesDegrees.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityAnglesDegrees.Location = new System.Drawing.Point(72, 29);
            this.TbxUtilityAnglesDegrees.Name = "TbxUtilityAnglesDegrees";
            this.TbxUtilityAnglesDegrees.Size = new System.Drawing.Size(70, 20);
            this.TbxUtilityAnglesDegrees.TabIndex = 15;
            this.TbxUtilityAnglesDegrees.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityAnglesDegrees.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityAnglesDegrees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityAnglesDegrees_KeyDown);
            // 
            // label76
            // 
            this.label76.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(16, 32);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(50, 13);
            this.label76.TabIndex = 10;
            this.label76.Text = "Degrees:";
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(3, 6);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(63, 13);
            this.label75.TabIndex = 0;
            this.label75.Text = "Game units:";
            this.toolTip1.SetToolTip(this.label75, "Hexadecimal, 0x0 through 0xFFF");
            // 
            // groupBox7
            // 
            this.groupBox7.AutoSize = true;
            this.groupBox7.Controls.Add(this.tableLayoutPanel2);
            this.groupBox7.Location = new System.Drawing.Point(6, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(676, 300);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Fixed point";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label71, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.LblUtilityFixedPointError, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label72, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.TbxUtilityFixedPointQ, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TbxUtilityFixedPointFloat, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label74, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.CmbUtilityFixedPointFormat, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label73, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(154, 108);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(3, 7);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(42, 13);
            this.label71.TabIndex = 0;
            this.label71.Text = "Format:";
            // 
            // LblUtilityFixedPointError
            // 
            this.LblUtilityFixedPointError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblUtilityFixedPointError.AutoSize = true;
            this.LblUtilityFixedPointError.Location = new System.Drawing.Point(51, 88);
            this.LblUtilityFixedPointError.Name = "LblUtilityFixedPointError";
            this.LblUtilityFixedPointError.Size = new System.Drawing.Size(33, 13);
            this.LblUtilityFixedPointError.TabIndex = 35;
            this.LblUtilityFixedPointError.Text = "None";
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(12, 34);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(33, 13);
            this.label72.TabIndex = 10;
            this.label72.Text = "Float:";
            // 
            // TbxUtilityFixedPointQ
            // 
            this.TbxUtilityFixedPointQ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityFixedPointQ.Location = new System.Drawing.Point(51, 57);
            this.TbxUtilityFixedPointQ.Name = "TbxUtilityFixedPointQ";
            this.TbxUtilityFixedPointQ.Size = new System.Drawing.Size(100, 20);
            this.TbxUtilityFixedPointQ.TabIndex = 25;
            this.TbxUtilityFixedPointQ.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityFixedPointQ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityFixedPointQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityFixedPointQ_KeyDown);
            // 
            // TbxUtilityFixedPointFloat
            // 
            this.TbxUtilityFixedPointFloat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityFixedPointFloat.Location = new System.Drawing.Point(51, 30);
            this.TbxUtilityFixedPointFloat.Name = "TbxUtilityFixedPointFloat";
            this.TbxUtilityFixedPointFloat.Size = new System.Drawing.Size(100, 20);
            this.TbxUtilityFixedPointFloat.TabIndex = 15;
            this.TbxUtilityFixedPointFloat.Click += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityFixedPointFloat.Enter += new System.EventHandler(this.Selectable_Enter);
            this.TbxUtilityFixedPointFloat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityFixedPointFloat_KeyDown);
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(13, 88);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(32, 13);
            this.label74.TabIndex = 30;
            this.label74.Text = "Error:";
            // 
            // CmbUtilityFixedPointFormat
            // 
            this.CmbUtilityFixedPointFormat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CmbUtilityFixedPointFormat.FormattingEnabled = true;
            this.CmbUtilityFixedPointFormat.Items.AddRange(new object[] {
            "Q20.12",
            "Q12.4"});
            this.CmbUtilityFixedPointFormat.Location = new System.Drawing.Point(51, 3);
            this.CmbUtilityFixedPointFormat.Name = "CmbUtilityFixedPointFormat";
            this.CmbUtilityFixedPointFormat.Size = new System.Drawing.Size(100, 21);
            this.CmbUtilityFixedPointFormat.TabIndex = 5;
            this.CmbUtilityFixedPointFormat.SelectionChangeCommitted += new System.EventHandler(this.CmbUtilityFixedPointFormat_SelectionChangeCommitted);
            this.CmbUtilityFixedPointFormat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbUtilityFixedPointFormat_KeyDown);
            // 
            // label73
            // 
            this.label73.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(16, 61);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(29, 13);
            this.label73.TabIndex = 20;
            this.label73.Text = "Hex:";
            // 
            // TbpMisc
            // 
            this.TbpMisc.Controls.Add(this.GbxController);
            this.TbpMisc.Location = new System.Drawing.Point(4, 22);
            this.TbpMisc.Name = "TbpMisc";
            this.TbpMisc.Size = new System.Drawing.Size(688, 618);
            this.TbpMisc.TabIndex = 14;
            this.TbpMisc.Text = "Misc";
            this.TbpMisc.UseVisualStyleBackColor = true;
            // 
            // GbxController
            // 
            this.GbxController.Controls.Add(this.tableLayoutPanel23);
            this.GbxController.Location = new System.Drawing.Point(3, 3);
            this.GbxController.Name = "GbxController";
            this.GbxController.Size = new System.Drawing.Size(374, 317);
            this.GbxController.TabIndex = 0;
            this.GbxController.TabStop = false;
            this.GbxController.Text = "Controller";
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.AutoSize = true;
            this.tableLayoutPanel23.ColumnCount = 5;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel23.Controls.Add(this.tableLayoutPanel28, 0, 0);
            this.tableLayoutPanel23.Controls.Add(this.tableLayoutPanel31, 1, 2);
            this.tableLayoutPanel23.Controls.Add(this.tableLayoutPanel30, 3, 1);
            this.tableLayoutPanel23.Controls.Add(this.CbxEnableControllerReporting, 4, 2);
            this.tableLayoutPanel23.Controls.Add(this.tableLayoutPanel29, 0, 1);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel23.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 3;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(368, 298);
            this.tableLayoutPanel23.TabIndex = 0;
            // 
            // tableLayoutPanel28
            // 
            this.tableLayoutPanel28.ColumnCount = 2;
            this.tableLayoutPanel23.SetColumnSpan(this.tableLayoutPanel28, 5);
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.Controls.Add(this.LblButtonR1, 1, 1);
            this.tableLayoutPanel28.Controls.Add(this.LblButtonL1, 0, 1);
            this.tableLayoutPanel28.Controls.Add(this.LblButtonR2, 1, 0);
            this.tableLayoutPanel28.Controls.Add(this.LblButtonL2, 0, 0);
            this.tableLayoutPanel28.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel28.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel28.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel28.Name = "tableLayoutPanel28";
            this.tableLayoutPanel28.RowCount = 2;
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel28.Size = new System.Drawing.Size(368, 53);
            this.tableLayoutPanel28.TabIndex = 0;
            // 
            // LblButtonR1
            // 
            this.LblButtonR1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblButtonR1.AutoSize = true;
            this.LblButtonR1.Location = new System.Drawing.Point(344, 33);
            this.LblButtonR1.Name = "LblButtonR1";
            this.LblButtonR1.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR1.TabIndex = 15;
            this.LblButtonR1.Text = "R1";
            // 
            // LblButtonL1
            // 
            this.LblButtonL1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblButtonL1.AutoSize = true;
            this.LblButtonL1.Location = new System.Drawing.Point(3, 33);
            this.LblButtonL1.Name = "LblButtonL1";
            this.LblButtonL1.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL1.TabIndex = 10;
            this.LblButtonL1.Text = "L1";
            // 
            // LblButtonR2
            // 
            this.LblButtonR2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblButtonR2.AutoSize = true;
            this.LblButtonR2.Location = new System.Drawing.Point(344, 6);
            this.LblButtonR2.Name = "LblButtonR2";
            this.LblButtonR2.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR2.TabIndex = 5;
            this.LblButtonR2.Text = "R2";
            // 
            // LblButtonL2
            // 
            this.LblButtonL2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblButtonL2.AutoSize = true;
            this.LblButtonL2.Location = new System.Drawing.Point(3, 6);
            this.LblButtonL2.Name = "LblButtonL2";
            this.LblButtonL2.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL2.TabIndex = 0;
            this.LblButtonL2.Text = "L2";
            // 
            // tableLayoutPanel31
            // 
            this.tableLayoutPanel31.ColumnCount = 2;
            this.tableLayoutPanel23.SetColumnSpan(this.tableLayoutPanel31, 3);
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.Controls.Add(this.LblButtonSelect, 0, 0);
            this.tableLayoutPanel31.Controls.Add(this.LblButtonR3, 1, 1);
            this.tableLayoutPanel31.Controls.Add(this.LblButtonStart, 1, 0);
            this.tableLayoutPanel31.Controls.Add(this.LblButtonL3, 0, 1);
            this.tableLayoutPanel31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel31.Location = new System.Drawing.Point(91, 175);
            this.tableLayoutPanel31.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel31.Name = "tableLayoutPanel31";
            this.tableLayoutPanel31.RowCount = 2;
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel31.Size = new System.Drawing.Size(183, 123);
            this.tableLayoutPanel31.TabIndex = 15;
            // 
            // LblButtonSelect
            // 
            this.LblButtonSelect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonSelect.AutoSize = true;
            this.LblButtonSelect.Location = new System.Drawing.Point(27, 24);
            this.LblButtonSelect.Name = "LblButtonSelect";
            this.LblButtonSelect.Size = new System.Drawing.Size(37, 13);
            this.LblButtonSelect.TabIndex = 0;
            this.LblButtonSelect.Text = "Select";
            // 
            // LblButtonR3
            // 
            this.LblButtonR3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblButtonR3.AutoSize = true;
            this.LblButtonR3.Location = new System.Drawing.Point(159, 85);
            this.LblButtonR3.Name = "LblButtonR3";
            this.LblButtonR3.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR3.TabIndex = 15;
            this.LblButtonR3.Text = "R3";
            // 
            // LblButtonStart
            // 
            this.LblButtonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonStart.AutoSize = true;
            this.LblButtonStart.Location = new System.Drawing.Point(122, 24);
            this.LblButtonStart.Name = "LblButtonStart";
            this.LblButtonStart.Size = new System.Drawing.Size(29, 13);
            this.LblButtonStart.TabIndex = 5;
            this.LblButtonStart.Text = "Start";
            // 
            // LblButtonL3
            // 
            this.LblButtonL3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblButtonL3.AutoSize = true;
            this.LblButtonL3.Location = new System.Drawing.Point(3, 85);
            this.LblButtonL3.Name = "LblButtonL3";
            this.LblButtonL3.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL3.TabIndex = 10;
            this.LblButtonL3.Text = "L3";
            // 
            // tableLayoutPanel30
            // 
            this.tableLayoutPanel30.ColumnCount = 3;
            this.tableLayoutPanel23.SetColumnSpan(this.tableLayoutPanel30, 2);
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.Controls.Add(this.LblButtonTriangle, 1, 0);
            this.tableLayoutPanel30.Controls.Add(this.LblButtonSquare, 0, 1);
            this.tableLayoutPanel30.Controls.Add(this.LblButtonCircle, 2, 1);
            this.tableLayoutPanel30.Controls.Add(this.LblButtonX, 1, 2);
            this.tableLayoutPanel30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel30.Location = new System.Drawing.Point(183, 53);
            this.tableLayoutPanel30.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel30.Name = "tableLayoutPanel30";
            this.tableLayoutPanel30.RowCount = 3;
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel30.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel30.Size = new System.Drawing.Size(185, 122);
            this.tableLayoutPanel30.TabIndex = 10;
            // 
            // LblButtonTriangle
            // 
            this.LblButtonTriangle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonTriangle.AutoSize = true;
            this.LblButtonTriangle.Location = new System.Drawing.Point(69, 13);
            this.LblButtonTriangle.Name = "LblButtonTriangle";
            this.LblButtonTriangle.Size = new System.Drawing.Size(45, 13);
            this.LblButtonTriangle.TabIndex = 0;
            this.LblButtonTriangle.Text = "Triangle";
            // 
            // LblButtonSquare
            // 
            this.LblButtonSquare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonSquare.AutoSize = true;
            this.LblButtonSquare.Location = new System.Drawing.Point(10, 53);
            this.LblButtonSquare.Name = "LblButtonSquare";
            this.LblButtonSquare.Size = new System.Drawing.Size(41, 13);
            this.LblButtonSquare.TabIndex = 5;
            this.LblButtonSquare.Text = "Square";
            // 
            // LblButtonCircle
            // 
            this.LblButtonCircle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonCircle.AutoSize = true;
            this.LblButtonCircle.Location = new System.Drawing.Point(137, 53);
            this.LblButtonCircle.Name = "LblButtonCircle";
            this.LblButtonCircle.Size = new System.Drawing.Size(33, 13);
            this.LblButtonCircle.TabIndex = 10;
            this.LblButtonCircle.Text = "Circle";
            // 
            // LblButtonX
            // 
            this.LblButtonX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonX.AutoSize = true;
            this.LblButtonX.Location = new System.Drawing.Point(84, 94);
            this.LblButtonX.Name = "LblButtonX";
            this.LblButtonX.Size = new System.Drawing.Size(14, 13);
            this.LblButtonX.TabIndex = 15;
            this.LblButtonX.Text = "X";
            // 
            // CbxEnableControllerReporting
            // 
            this.CbxEnableControllerReporting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableControllerReporting.AutoSize = true;
            this.CbxEnableControllerReporting.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableControllerReporting.Location = new System.Drawing.Point(306, 278);
            this.CbxEnableControllerReporting.Name = "CbxEnableControllerReporting";
            this.CbxEnableControllerReporting.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableControllerReporting.TabIndex = 0;
            this.CbxEnableControllerReporting.Text = "Enable";
            this.CbxEnableControllerReporting.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel29
            // 
            this.tableLayoutPanel29.ColumnCount = 3;
            this.tableLayoutPanel23.SetColumnSpan(this.tableLayoutPanel29, 2);
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel29.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel29.Controls.Add(this.LblButtonUp, 1, 0);
            this.tableLayoutPanel29.Controls.Add(this.LblButtonLeft, 0, 1);
            this.tableLayoutPanel29.Controls.Add(this.LblButtonRight, 2, 1);
            this.tableLayoutPanel29.Controls.Add(this.LblButtonDown, 1, 2);
            this.tableLayoutPanel29.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel29.Location = new System.Drawing.Point(0, 53);
            this.tableLayoutPanel29.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel29.Name = "tableLayoutPanel29";
            this.tableLayoutPanel29.RowCount = 3;
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel29.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel29.Size = new System.Drawing.Size(182, 122);
            this.tableLayoutPanel29.TabIndex = 5;
            // 
            // LblButtonUp
            // 
            this.LblButtonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonUp.AutoSize = true;
            this.LblButtonUp.Location = new System.Drawing.Point(79, 13);
            this.LblButtonUp.Name = "LblButtonUp";
            this.LblButtonUp.Size = new System.Drawing.Size(21, 13);
            this.LblButtonUp.TabIndex = 0;
            this.LblButtonUp.Text = "Up";
            // 
            // LblButtonLeft
            // 
            this.LblButtonLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonLeft.AutoSize = true;
            this.LblButtonLeft.Location = new System.Drawing.Point(17, 53);
            this.LblButtonLeft.Name = "LblButtonLeft";
            this.LblButtonLeft.Size = new System.Drawing.Size(25, 13);
            this.LblButtonLeft.TabIndex = 5;
            this.LblButtonLeft.Text = "Left";
            // 
            // LblButtonRight
            // 
            this.LblButtonRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonRight.AutoSize = true;
            this.LblButtonRight.Location = new System.Drawing.Point(135, 53);
            this.LblButtonRight.Name = "LblButtonRight";
            this.LblButtonRight.Size = new System.Drawing.Size(32, 13);
            this.LblButtonRight.TabIndex = 10;
            this.LblButtonRight.Text = "Right";
            // 
            // LblButtonDown
            // 
            this.LblButtonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonDown.AutoSize = true;
            this.LblButtonDown.Location = new System.Drawing.Point(72, 94);
            this.LblButtonDown.Name = "LblButtonDown";
            this.LblButtonDown.Size = new System.Drawing.Size(35, 13);
            this.LblButtonDown.TabIndex = 15;
            this.LblButtonDown.Text = "Down";
            // 
            // TbpSettings
            // 
            this.TbpSettings.Controls.Add(this.TlpSettings);
            this.TbpSettings.Location = new System.Drawing.Point(4, 22);
            this.TbpSettings.Name = "TbpSettings";
            this.TbpSettings.Size = new System.Drawing.Size(688, 618);
            this.TbpSettings.TabIndex = 15;
            this.TbpSettings.Text = "Settings";
            this.TbpSettings.UseVisualStyleBackColor = true;
            // 
            // TlpSettings
            // 
            this.TlpSettings.ColumnCount = 1;
            this.TlpSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpSettings.Controls.Add(this.BtnSettingsResetAll, 0, 2);
            this.TlpSettings.Controls.Add(this.GbxSettingsFiles, 0, 0);
            this.TlpSettings.Controls.Add(this.tableLayoutPanel42, 0, 1);
            this.TlpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TlpSettings.Location = new System.Drawing.Point(0, 0);
            this.TlpSettings.Name = "TlpSettings";
            this.TlpSettings.RowCount = 3;
            this.TlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TlpSettings.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TlpSettings.Size = new System.Drawing.Size(688, 618);
            this.TlpSettings.TabIndex = 0;
            // 
            // BtnSettingsResetAll
            // 
            this.BtnSettingsResetAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettingsResetAll.Location = new System.Drawing.Point(610, 590);
            this.BtnSettingsResetAll.Name = "BtnSettingsResetAll";
            this.BtnSettingsResetAll.Size = new System.Drawing.Size(75, 25);
            this.BtnSettingsResetAll.TabIndex = 10;
            this.BtnSettingsResetAll.Text = "Reset all";
            this.BtnSettingsResetAll.UseVisualStyleBackColor = true;
            this.BtnSettingsResetAll.Click += new System.EventHandler(this.BtnSettingsResetAll_Click);
            // 
            // GbxSettingsFiles
            // 
            this.GbxSettingsFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.GbxSettingsFiles.Controls.Add(this.tableLayoutPanel40);
            this.GbxSettingsFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxSettingsFiles.Location = new System.Drawing.Point(3, 3);
            this.GbxSettingsFiles.Name = "GbxSettingsFiles";
            this.GbxSettingsFiles.Size = new System.Drawing.Size(682, 112);
            this.GbxSettingsFiles.TabIndex = 0;
            this.GbxSettingsFiles.TabStop = false;
            this.GbxSettingsFiles.Text = "Config files";
            // 
            // tableLayoutPanel40
            // 
            this.tableLayoutPanel40.AutoSize = true;
            this.tableLayoutPanel40.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel40.ColumnCount = 3;
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel40.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel40.Controls.Add(this.BtnSettingsSaveCopies, 1, 2);
            this.tableLayoutPanel40.Controls.Add(this.BtnSettingsGoRoaming, 2, 1);
            this.tableLayoutPanel40.Controls.Add(this.BtnSettingsGoLocal, 2, 0);
            this.tableLayoutPanel40.Controls.Add(this.TbxSettingsFilesRoaming, 1, 1);
            this.tableLayoutPanel40.Controls.Add(this.LblSettingsLocal, 0, 0);
            this.tableLayoutPanel40.Controls.Add(this.LblSettingsRoaming, 0, 1);
            this.tableLayoutPanel40.Controls.Add(this.TbxSettingsFilesLocal, 1, 0);
            this.tableLayoutPanel40.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel40.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel40.Name = "tableLayoutPanel40";
            this.tableLayoutPanel40.RowCount = 3;
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel40.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel40.Size = new System.Drawing.Size(676, 93);
            this.tableLayoutPanel40.TabIndex = 0;
            // 
            // BtnSettingsSaveCopies
            // 
            this.BtnSettingsSaveCopies.Location = new System.Drawing.Point(61, 65);
            this.BtnSettingsSaveCopies.Name = "BtnSettingsSaveCopies";
            this.BtnSettingsSaveCopies.Size = new System.Drawing.Size(100, 25);
            this.BtnSettingsSaveCopies.TabIndex = 30;
            this.BtnSettingsSaveCopies.Text = "Save copies";
            this.BtnSettingsSaveCopies.UseVisualStyleBackColor = true;
            this.BtnSettingsSaveCopies.Click += new System.EventHandler(this.BtnSettingsSaveCopies_Click);
            // 
            // BtnSettingsGoRoaming
            // 
            this.BtnSettingsGoRoaming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettingsGoRoaming.Location = new System.Drawing.Point(598, 34);
            this.BtnSettingsGoRoaming.Name = "BtnSettingsGoRoaming";
            this.BtnSettingsGoRoaming.Size = new System.Drawing.Size(75, 25);
            this.BtnSettingsGoRoaming.TabIndex = 25;
            this.BtnSettingsGoRoaming.Text = "Go";
            this.BtnSettingsGoRoaming.UseVisualStyleBackColor = true;
            this.BtnSettingsGoRoaming.Click += new System.EventHandler(this.BtnSettingsGoRoaming_Click);
            // 
            // BtnSettingsGoLocal
            // 
            this.BtnSettingsGoLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSettingsGoLocal.Location = new System.Drawing.Point(598, 3);
            this.BtnSettingsGoLocal.Name = "BtnSettingsGoLocal";
            this.BtnSettingsGoLocal.Size = new System.Drawing.Size(75, 25);
            this.BtnSettingsGoLocal.TabIndex = 10;
            this.BtnSettingsGoLocal.Text = "Go";
            this.BtnSettingsGoLocal.UseVisualStyleBackColor = true;
            this.BtnSettingsGoLocal.Click += new System.EventHandler(this.BtnSettingsGoLocal_Click);
            // 
            // TbxSettingsFilesRoaming
            // 
            this.TbxSettingsFilesRoaming.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSettingsFilesRoaming.Location = new System.Drawing.Point(61, 36);
            this.TbxSettingsFilesRoaming.Name = "TbxSettingsFilesRoaming";
            this.TbxSettingsFilesRoaming.ReadOnly = true;
            this.TbxSettingsFilesRoaming.Size = new System.Drawing.Size(531, 20);
            this.TbxSettingsFilesRoaming.TabIndex = 20;
            this.toolTip1.SetToolTip(this.TbxSettingsFilesRoaming, "User-specific, machine-independent settings");
            // 
            // LblSettingsLocal
            // 
            this.LblSettingsLocal.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSettingsLocal.AutoSize = true;
            this.LblSettingsLocal.Location = new System.Drawing.Point(19, 9);
            this.LblSettingsLocal.Name = "LblSettingsLocal";
            this.LblSettingsLocal.Size = new System.Drawing.Size(36, 13);
            this.LblSettingsLocal.TabIndex = 0;
            this.LblSettingsLocal.Text = "Local:";
            this.LblSettingsLocal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.LblSettingsLocal, "User-specific, machine-dependent settings");
            // 
            // LblSettingsRoaming
            // 
            this.LblSettingsRoaming.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblSettingsRoaming.AutoSize = true;
            this.LblSettingsRoaming.Location = new System.Drawing.Point(3, 40);
            this.LblSettingsRoaming.Name = "LblSettingsRoaming";
            this.LblSettingsRoaming.Size = new System.Drawing.Size(52, 13);
            this.LblSettingsRoaming.TabIndex = 15;
            this.LblSettingsRoaming.Text = "Roaming:";
            this.LblSettingsRoaming.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.LblSettingsRoaming, "User-specific, machine-independent settings");
            // 
            // TbxSettingsFilesLocal
            // 
            this.TbxSettingsFilesLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxSettingsFilesLocal.Location = new System.Drawing.Point(61, 5);
            this.TbxSettingsFilesLocal.Name = "TbxSettingsFilesLocal";
            this.TbxSettingsFilesLocal.ReadOnly = true;
            this.TbxSettingsFilesLocal.Size = new System.Drawing.Size(531, 20);
            this.TbxSettingsFilesLocal.TabIndex = 5;
            this.toolTip1.SetToolTip(this.TbxSettingsFilesLocal, "User-specific, machine-dependent settings");
            // 
            // tableLayoutPanel42
            // 
            this.tableLayoutPanel42.ColumnCount = 2;
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Controls.Add(this.GbxOverlayDisplaySurface, 0, 0);
            this.tableLayoutPanel42.Controls.Add(this.GbxOverlayBackend, 1, 0);
            this.tableLayoutPanel42.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel42.Location = new System.Drawing.Point(3, 121);
            this.tableLayoutPanel42.Name = "tableLayoutPanel42";
            this.tableLayoutPanel42.RowCount = 2;
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel42.Size = new System.Drawing.Size(682, 463);
            this.tableLayoutPanel42.TabIndex = 5;
            // 
            // GbxOverlayDisplaySurface
            // 
            this.GbxOverlayDisplaySurface.Controls.Add(this.tableLayoutPanel41);
            this.GbxOverlayDisplaySurface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxOverlayDisplaySurface.Location = new System.Drawing.Point(0, 0);
            this.GbxOverlayDisplaySurface.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.GbxOverlayDisplaySurface.Name = "GbxOverlayDisplaySurface";
            this.GbxOverlayDisplaySurface.Size = new System.Drawing.Size(338, 231);
            this.GbxOverlayDisplaySurface.TabIndex = 0;
            this.GbxOverlayDisplaySurface.TabStop = false;
            this.GbxOverlayDisplaySurface.Text = "Overlay display surface";
            // 
            // tableLayoutPanel41
            // 
            this.tableLayoutPanel41.AutoSize = true;
            this.tableLayoutPanel41.ColumnCount = 1;
            this.tableLayoutPanel41.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.Controls.Add(this.RdoOverlayDisplaySurfaceFramebuffer, 0, 2);
            this.tableLayoutPanel41.Controls.Add(this.RdoOverlayDisplaySurfaceClient, 0, 0);
            this.tableLayoutPanel41.Controls.Add(this.RdoOverlayDisplaySurfaceEmuCore, 0, 1);
            this.tableLayoutPanel41.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel41.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel41.Name = "tableLayoutPanel41";
            this.tableLayoutPanel41.RowCount = 4;
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel41.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel41.Size = new System.Drawing.Size(332, 212);
            this.tableLayoutPanel41.TabIndex = 0;
            // 
            // RdoOverlayDisplaySurfaceFramebuffer
            // 
            this.RdoOverlayDisplaySurfaceFramebuffer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RdoOverlayDisplaySurfaceFramebuffer.AutoSize = true;
            this.RdoOverlayDisplaySurfaceFramebuffer.Location = new System.Drawing.Point(3, 49);
            this.RdoOverlayDisplaySurfaceFramebuffer.Name = "RdoOverlayDisplaySurfaceFramebuffer";
            this.RdoOverlayDisplaySurfaceFramebuffer.Size = new System.Drawing.Size(124, 17);
            this.RdoOverlayDisplaySurfaceFramebuffer.TabIndex = 10;
            this.RdoOverlayDisplaySurfaceFramebuffer.Text = "Silent Hill framebuffer";
            this.RdoOverlayDisplaySurfaceFramebuffer.UseVisualStyleBackColor = true;
            this.RdoOverlayDisplaySurfaceFramebuffer.CheckedChanged += new System.EventHandler(this.RdoOverlayDisplaySurface_CheckedChanged);
            // 
            // RdoOverlayDisplaySurfaceClient
            // 
            this.RdoOverlayDisplaySurfaceClient.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RdoOverlayDisplaySurfaceClient.AutoSize = true;
            this.RdoOverlayDisplaySurfaceClient.Checked = true;
            this.RdoOverlayDisplaySurfaceClient.Location = new System.Drawing.Point(3, 3);
            this.RdoOverlayDisplaySurfaceClient.Name = "RdoOverlayDisplaySurfaceClient";
            this.RdoOverlayDisplaySurfaceClient.Size = new System.Drawing.Size(116, 17);
            this.RdoOverlayDisplaySurfaceClient.TabIndex = 0;
            this.RdoOverlayDisplaySurfaceClient.TabStop = true;
            this.RdoOverlayDisplaySurfaceClient.Text = "Window client area";
            this.toolTip1.SetToolTip(this.RdoOverlayDisplaySurfaceClient, "Highest resolution");
            this.RdoOverlayDisplaySurfaceClient.UseVisualStyleBackColor = true;
            this.RdoOverlayDisplaySurfaceClient.CheckedChanged += new System.EventHandler(this.RdoOverlayDisplaySurface_CheckedChanged);
            // 
            // RdoOverlayDisplaySurfaceEmuCore
            // 
            this.RdoOverlayDisplaySurfaceEmuCore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RdoOverlayDisplaySurfaceEmuCore.AutoSize = true;
            this.RdoOverlayDisplaySurfaceEmuCore.Location = new System.Drawing.Point(3, 26);
            this.RdoOverlayDisplaySurfaceEmuCore.Name = "RdoOverlayDisplaySurfaceEmuCore";
            this.RdoOverlayDisplaySurfaceEmuCore.Size = new System.Drawing.Size(90, 17);
            this.RdoOverlayDisplaySurfaceEmuCore.TabIndex = 5;
            this.RdoOverlayDisplaySurfaceEmuCore.Text = "Emulator core";
            this.toolTip1.SetToolTip(this.RdoOverlayDisplaySurfaceEmuCore, "Highest performance");
            this.RdoOverlayDisplaySurfaceEmuCore.UseVisualStyleBackColor = true;
            this.RdoOverlayDisplaySurfaceEmuCore.CheckedChanged += new System.EventHandler(this.RdoOverlayDisplaySurface_CheckedChanged);
            // 
            // GbxOverlayBackend
            // 
            this.GbxOverlayBackend.Controls.Add(this.tableLayoutPanel43);
            this.GbxOverlayBackend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxOverlayBackend.Location = new System.Drawing.Point(344, 0);
            this.GbxOverlayBackend.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.GbxOverlayBackend.Name = "GbxOverlayBackend";
            this.GbxOverlayBackend.Size = new System.Drawing.Size(338, 231);
            this.GbxOverlayBackend.TabIndex = 5;
            this.GbxOverlayBackend.TabStop = false;
            this.GbxOverlayBackend.Text = "Overlay backend";
            // 
            // tableLayoutPanel43
            // 
            this.tableLayoutPanel43.AutoSize = true;
            this.tableLayoutPanel43.ColumnCount = 1;
            this.tableLayoutPanel43.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel43.Controls.Add(this.RdoBackendBitmap, 0, 0);
            this.tableLayoutPanel43.Controls.Add(this.RdoBackendBizHawkGui, 0, 1);
            this.tableLayoutPanel43.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel43.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel43.Name = "tableLayoutPanel43";
            this.tableLayoutPanel43.RowCount = 3;
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel43.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel43.Size = new System.Drawing.Size(332, 212);
            this.tableLayoutPanel43.TabIndex = 0;
            // 
            // RdoBackendBitmap
            // 
            this.RdoBackendBitmap.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RdoBackendBitmap.AutoSize = true;
            this.RdoBackendBitmap.Location = new System.Drawing.Point(3, 3);
            this.RdoBackendBitmap.Name = "RdoBackendBitmap";
            this.RdoBackendBitmap.Size = new System.Drawing.Size(94, 17);
            this.RdoBackendBitmap.TabIndex = 0;
            this.RdoBackendBitmap.Text = "Internal bitmap";
            this.toolTip1.SetToolTip(this.RdoBackendBitmap, "Lower performance, but allows antialiasing and framebuffer rendering");
            this.RdoBackendBitmap.UseVisualStyleBackColor = true;
            this.RdoBackendBitmap.CheckedChanged += new System.EventHandler(this.RdoOverlayBackend_CheckedChanged);
            // 
            // RdoBackendBizHawkGui
            // 
            this.RdoBackendBizHawkGui.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.RdoBackendBizHawkGui.AutoSize = true;
            this.RdoBackendBizHawkGui.Checked = true;
            this.RdoBackendBizHawkGui.Location = new System.Drawing.Point(3, 26);
            this.RdoBackendBizHawkGui.Name = "RdoBackendBizHawkGui";
            this.RdoBackendBizHawkGui.Size = new System.Drawing.Size(109, 17);
            this.RdoBackendBizHawkGui.TabIndex = 5;
            this.RdoBackendBizHawkGui.TabStop = true;
            this.RdoBackendBizHawkGui.Text = "BizHawk GUI API";
            this.toolTip1.SetToolTip(this.RdoBackendBizHawkGui, "Higher performance");
            this.RdoBackendBizHawkGui.UseVisualStyleBackColor = true;
            this.RdoBackendBizHawkGui.CheckedChanged += new System.EventHandler(this.RdoOverlayBackend_CheckedChanged);
            // 
            // CustomMainForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1008, 985);
            this.Controls.Add(this.TbcMainTabs);
            this.Name = "CustomMainForm";
            this.GbxHarry.ResumeLayout(false);
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            this.GbxCamera.ResumeLayout(false);
            this.tableLayoutPanel25.ResumeLayout(false);
            this.tableLayoutPanel25.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMapGraphic)).EndInit();
            this.TbcMainTabs.ResumeLayout(false);
            this.TbpBasics.ResumeLayout(false);
            this.TlpBasics.ResumeLayout(false);
            this.TlpBasics.PerformLayout();
            this.GbxControls.ResumeLayout(false);
            this.GbxControls.PerformLayout();
            this.tableLayoutPanel39.ResumeLayout(false);
            this.tableLayoutPanel39.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCameraFlySensitivity)).EndInit();
            this.tableLayoutPanel38.ResumeLayout(false);
            this.tableLayoutPanel38.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudEyeHeight)).EndInit();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCameraFlySpeed)).EndInit();
            this.GbxOverlay.ResumeLayout(false);
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFilledOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraRoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCrosshairLength)).EndInit();
            this.TbpPois.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel33.ResumeLayout(false);
            this.tableLayoutPanel33.PerformLayout();
            this.tableLayoutPanel35.ResumeLayout(false);
            this.tableLayoutPanel35.PerformLayout();
            this.tableLayoutPanel34.ResumeLayout(false);
            this.tableLayoutPanel34.PerformLayout();
            this.tableLayoutPanel32.ResumeLayout(false);
            this.tableLayoutPanel32.PerformLayout();
            this.tableLayoutPanel37.ResumeLayout(false);
            this.GbxSelectedTrigger.ResumeLayout(false);
            this.GbxSelectedTrigger.PerformLayout();
            this.CmsSelectedTrigger.ResumeLayout(false);
            this.TlpSelectedTriggerLeft.ResumeLayout(false);
            this.TlpSelectedTriggerLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerStageIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerPoiIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerFiredGroup)).EndInit();
            this.GbxSelectedPoi.ResumeLayout(false);
            this.CmsSelectedPoi.ResumeLayout(false);
            this.tableLayoutPanel36.ResumeLayout(false);
            this.tableLayoutPanel36.PerformLayout();
            this.TbpCamera.ResumeLayout(false);
            this.TbpCamera.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel44.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.CmsSelectedCameraPath.ResumeLayout(false);
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.TbpStats.ResumeLayout(false);
            this.TbpStats.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.TbpMap.ResumeLayout(false);
            this.TbpMap.PerformLayout();
            this.TbpFog.ResumeLayout(false);
            this.TbpFog.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomWorldTintB)).EndInit();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCustomFogB)).EndInit();
            this.TbpStrings.ResumeLayout(false);
            this.TbpStrings.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.TbpSave.ResumeLayout(false);
            this.TbpSave.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.PnlSaveRamDangerArea.ResumeLayout(false);
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            this.GbxConvertStatesOrSaveRam.ResumeLayout(false);
            this.TbcConvertStatesOrSaveRam.ResumeLayout(false);
            this.TbpConvertStatesToSaveRam.ResumeLayout(false);
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.TbpConvertSaveRamToStates.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PbxHazardStripes)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.TbpTest.ResumeLayout(false);
            this.TbpTest.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrkTestModelScale)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestModelZ)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestBoxZ)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestSheetY)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudTestLineBZ)).EndInit();
            this.TbpFiles.ResumeLayout(false);
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.CmsFilesDirectories.ResumeLayout(false);
            this.CmsFilesFiles.ResumeLayout(false);
            this.TbpFramebuffer.ResumeLayout(false);
            this.TlpFramebufferTab.ResumeLayout(false);
            this.TlpFramebufferTab.PerformLayout();
            this.ScrFramebuffer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BpbFramebuffer)).EndInit();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferOfsX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFramebufferOfsY)).EndInit();
            this.TbpUtility.ResumeLayout(false);
            this.TbpUtility.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.TbpMisc.ResumeLayout(false);
            this.GbxController.ResumeLayout(false);
            this.GbxController.PerformLayout();
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.tableLayoutPanel28.ResumeLayout(false);
            this.tableLayoutPanel28.PerformLayout();
            this.tableLayoutPanel31.ResumeLayout(false);
            this.tableLayoutPanel31.PerformLayout();
            this.tableLayoutPanel30.ResumeLayout(false);
            this.tableLayoutPanel30.PerformLayout();
            this.tableLayoutPanel29.ResumeLayout(false);
            this.tableLayoutPanel29.PerformLayout();
            this.TbpSettings.ResumeLayout(false);
            this.TlpSettings.ResumeLayout(false);
            this.GbxSettingsFiles.ResumeLayout(false);
            this.GbxSettingsFiles.PerformLayout();
            this.tableLayoutPanel40.ResumeLayout(false);
            this.tableLayoutPanel40.PerformLayout();
            this.tableLayoutPanel42.ResumeLayout(false);
            this.GbxOverlayDisplaySurface.ResumeLayout(false);
            this.GbxOverlayDisplaySurface.PerformLayout();
            this.tableLayoutPanel41.ResumeLayout(false);
            this.tableLayoutPanel41.PerformLayout();
            this.GbxOverlayBackend.ResumeLayout(false);
            this.GbxOverlayBackend.PerformLayout();
            this.tableLayoutPanel43.ResumeLayout(false);
            this.tableLayoutPanel43.PerformLayout();
            this.ResumeLayout(false);

		}

		private Label LblHarryPositionX;
		private Label LblHarryPositionY;
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
		private TabControl TbcMainTabs;
		private TabPage TbpBasics;
		private TabPage TbpMap;
		private TabPage TbpTest;
		private GroupBox GbxOverlay;
		private Label LblOverlayCamRoll;
		private Label LblOverlayCamYaw;
		private Label LblOverlayCamPitch;
		private Label LblOverlayCamPositionZ;
		private Label LblOverlayCamPositionY;
		private Label LblOverlayCamPositionX;
		private Label label2;
		private Label label1;
		private CheckBox CbxEnableOverlayCameraReporting;
		private CheckBox CbxEnableHarrySection;
		private CheckBox CbxCameraFreeze;
		private TabPage TbpStats;
		private Label label8;
		private Label label7;
		private Label LblRunningDistance;
		private Label LblWalkingDistance;
		private CheckBox CbxEnableStatsReporting;
		private TabPage TbpFog;
		private CheckBox CbxFog;
		private Button BtnFogColor;
		private Label label9;
		private Label label6;
		private Label label5;
		private NumericUpDown NudCustomFogB;
		private NumericUpDown NudCustomFogG;
		private NumericUpDown NudCustomFogR;
		private CheckBox CbxCustomFog;
		private CheckBox CbxCustomWorldTint;
		private NumericUpDown NudCustomWorldTintB;
		private NumericUpDown NudCustomWorldTintG;
		private NumericUpDown NudCustomWorldTintR;
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
		private ToolTip toolTip1;
		private System.ComponentModel.IContainer components;
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
		private Label LblFov;
		private TrackBar TrkFov;
		private TabPage TbpStrings;
		private Button BtnReadStrings;
		private Label LblStringCount;
		private RichTextBox RtbStrings;
		private TabPage TbpPois;
		private ListBox LbxPois;
		private Label LblPoiCount;
		private Button BtnReadPois;
		private Label LblSelectedPoiGeometry;
		private Label LblSelectedPoiXZ;
		private Label LblTriggerCount;
		private Button BtnReadTriggers;
		private ListBox LbxTriggers;
		private GroupBox GbxSelectedTrigger;
		private GroupBox GbxSelectedPoi;
		private Label LblSelectedTriggerThing4;
		private Label LblSelectedTriggerThing3;
		private Label LblSelectedTriggerPoiIndex;
		private Label LblSelectedTriggerStyle;
		private Label LblSelectedTriggerThing1;
		private Label LblSelectedTriggerThing0;
		private Label LblSelectedTriggerAddress;
		private Label label40;
		private Label LblSelectedPoiAddress;
		private Label label21;
		private Label label33;
		private ListBox LbxPoiAssociatedTriggers;
		private Button BtnGoToPoi;
		private Label LblSelectedTriggerTargetIndex;
		private NumericUpDown NudSelectedTriggerTargetIndex;
		private ComboBox CmbSelectedTriggerType;
		private Label LblSelectedTriggerType;
		private Label LblSelectedTriggerFiredGroup;
		private Label LblTotalTime;
		private Label label52;
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
		private TextBox TbxSaveRamExportPath;
		private TextBox TbxSaveRamImportPath;
		private Button BtnSaveRamImport;
		private Label LblSelectedTriggerPoiGeometry;
		private ComboBox CmbPoiRenderShape;
		private Button BtnClearPoisTriggers;
		private GroupBox GbxConvertStatesOrSaveRam;
		private PictureBox PbxHazardStripes;
		private CheckBox CbxSaveRamDanger;
		private Label LblSelectedTriggerThing2;
		private Label label59;
		private Label label61;
		private Label label19;
		private Label label18;
		private Label LblSpawnXZ;
		private Label LblSpawnGeometry;
		private Label label67;
		private Label label66;
		private Label label65;
		private Label label64;
		private Label label63;
		private Label label62;
		private GroupBox GbxControls;
		private GroupBox groupBox5;
		private Label label37;
		private Label label53;
		private Label label54;
		private NumericUpDown NudTestBoxSizeZ;
		private NumericUpDown NudTestBoxSizeY;
		private NumericUpDown NudTestBoxSizeX;
		private Label label31;
		private Label label34;
		private Label label36;
		private NumericUpDown NudTestLineBZ;
		private NumericUpDown NudTestLineBY;
		private NumericUpDown NudTestLineBX;
		private Label label16;
		private Label label17;
		private Label label20;
		private NumericUpDown NudTestLineAZ;
		private NumericUpDown NudTestLineAY;
		private NumericUpDown NudTestLineAX;
		private CheckBox CbxEnableTestLine;
		private Label label28;
		private Label label29;
		private Label label30;
		private NumericUpDown NudTestBoxZ;
		private NumericUpDown NudTestBoxY;
		private NumericUpDown NudTestBoxX;
		private CheckBox CbxEnableTestBox;
		private Label label68;
		private RadioButton RdoAxisColorsOff;
		private Label label44;
		private RadioButton RdoAxisColorsOverlay;
		private RadioButton RdoAxisColorsGame;
		private Label label69;
		private GroupBox groupBox6;
		private ComboBox CmbModelSubmeshName;
		private Button BtnReadHarryModel;
		private TabPage TbpFiles;
		private Button BtnReadFiles;
		private ListBox LbxFilesDirectories;
		private ListBox LbxFilesFiles;
		private ContextMenuStrip CmsFilesDirectories;
		private ToolStripMenuItem extractSelectedToolStripMenuItem;
		private ContextMenuStrip CmsFilesFiles;
		private ToolStripMenuItem extractSelectedFilesToolStripMenuItem;
        private CheckBox CbxHarrySetPositionMoveCamera;
        private TabPage TbpFramebuffer;
        private NumericUpDown NudFramebufferH;
        private NumericUpDown NudFramebufferW;
        private NumericUpDown NudFramebufferOfsY;
        private NumericUpDown NudFramebufferOfsX;
        private Button BtnFramebufferGrab;
        private Button BtnFramebufferZoomIn;
        private ScrollableControl ScrFramebuffer;
        private SHME.ExternalTool.BetterPictureBox BpbFramebuffer;
        private Button BtnFramebufferZoomOut;
        private ComboBox CmbFramebufferZoom;
		private Button BtnFramebufferSave;
		private CheckBox CbxDiscoMode;
		private NumericUpDown NudCrosshairLength;
		private Label label70;
		private CheckBox CbxCameraLockToHead;
		private TabPage TbpUtility;
		private GroupBox groupBox7;
		private GroupBox groupBox8;
		private ComboBox CmbUtilityFixedPointFormat;
		private Label label71;
		private TextBox TbxUtilityFixedPointQ;
		private Label label73;
		private TextBox TbxUtilityFixedPointFloat;
		private Label label72;
		private Label label74;
		private Label LblUtilityFixedPointError;
		private TextBox TbxUtilityAnglesDegrees;
		private TextBox TbxUtilityAnglesGameUnits;
		private Label label76;
		private Label label75;
		private Label LblUtilityAnglesError;
		private Label label78;
		private TabPage TbpCamera;
		private Button BtnCameraPathReadArray;
		private ListBox LbxCameraPaths;
		private Label LblCameraPathCount;
		private GroupBox groupBox10;
		private Label LblSelectedCameraPathThing4;
		private Label LblSelectedCameraPathAreaMax;
		private Label LblSelectedCameraPathAreaMin;
		private Button BtnCameraPathGoToVolumeMin;
		private Label LblCameraPathAddress;
		private Label label107;
		private Label LblSelectedCameraPathVolumeMin;
		private Button BtnCameraPathGoToVolumeMax;
		private Label LblSelectedCameraPathVolumeMax;
		private Label LblSelectedCameraPathThing6;
		private Label LblSelectedCameraPathThing5;
		private Label LblSelectedCameraPathYaw;
		private Label LblSelectedCameraPathPitch;
		private CheckBox CbxReadLevelDataOnStageLoad;
		private CheckBox CbxFarClipping;
		private CheckBox CbxBackfaceCulling;
		private CheckBox CbxSelectedCameraPathDisabled;
		private Label label79;
		private Label label85;
		private NumericUpDown NudTestSheetSizeZ;
		private NumericUpDown NudTestSheetSizeX;
		private Label label86;
		private Label label87;
		private Label label88;
		private NumericUpDown NudTestSheetZ;
		private NumericUpDown NudTestSheetY;
		private NumericUpDown NudTestSheetX;
		private CheckBox CbxEnableTestSheet;
		private Label label84;
		private NumericUpDown NudFilledOpacity;
		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private TableLayoutPanel tableLayoutPanel3;
		private TableLayoutPanel tableLayoutPanel4;
		private TableLayoutPanel tableLayoutPanel5;
		private TableLayoutPanel tableLayoutPanel6;
		private TableLayoutPanel tableLayoutPanel7;
		private TableLayoutPanel tableLayoutPanel9;
		private SplitContainer splitContainer1;
		private TableLayoutPanel tableLayoutPanel11;
		private Label label93;
		private Label label91;
		private Label label90;
		private Label label89;
		private TableLayoutPanel tableLayoutPanel10;
		private TableLayoutPanel tableLayoutPanel12;
		private TableLayoutPanel tableLayoutPanel13;
		private TableLayoutPanel tableLayoutPanel14;
		private TabControl TbcConvertStatesOrSaveRam;
		private TabPage TbpConvertStatesToSaveRam;
		private TabPage TbpConvertSaveRamToStates;
		private Label label58;
		private Button BtnConvertStatesToSaveRamInputPathBrowse;
		private TextBox TbxConvertStatesToSaveRamInputPath;
		private Button BtnConvertStatesToSaveRamRefresh;
		private Button BtnConvertStatesToSaveRamGo;
		private ListBox LbxConvertStatesToSaveRam;
		private Label label55;
		private Button BtnConvertStatesToSaveRamOutputPathBrowse;
		private TextBox TbxConvertStatesToSaveRamOutputPath;
		private Label label57;
		private Button BtnConvertSaveRamToStatesOutputPathBrowse;
		private TextBox TbxConvertSaveRamToStatesOutputPath;
		private Button BtnConvertSaveRamToStatesRefresh;
		private Label label56;
		private Button BtnConvertSaveRamToStatesInputPathBrowse;
		private TextBox TbxConvertSaveRamToStatesInputPath;
		private Button BtnConvertSaveRamToStatesGo;
		private ListBox LbxConvertSaveRamToStates;
		private TableLayoutPanel tableLayoutPanel15;
		private TableLayoutPanel tableLayoutPanel16;
		private TableLayoutPanel tableLayoutPanel17;
		private Button BtnSaveRamExportBrowse;
		private Button BtnSaveRamImportBrowse;
		private Panel PnlSaveRamDangerArea;
		private TableLayoutPanel tableLayoutPanel18;
		private TableLayoutPanel TlpFramebufferTab;
		private TableLayoutPanel tableLayoutPanel19;
		private TableLayoutPanel tableLayoutPanel20;
		private TrackBar TrkTestModelScale;
		private TableLayoutPanel tableLayoutPanel8;
		private NumericUpDown NudTestModelX;
		private NumericUpDown NudTestModelY;
		private NumericUpDown NudTestModelZ;
		private Label LblModelX;
		private Label LblModelY;
		private Label LblModelZ;
		private Button BtnTestModelSetPosition;
		private Button BtnTestModelGetPosition;
		private Label LblTestModelScale;
		private CheckBox CbxEnableTestModelSection;
		private SplitContainer splitContainer2;
		private TableLayoutPanel tableLayoutPanel21;
		private TableLayoutPanel tableLayoutPanel22;
		private TableLayoutPanel tableLayoutPanel24;
		private TableLayoutPanel tableLayoutPanel25;
		private TableLayoutPanel tableLayoutPanel26;
		private TableLayoutPanel TlpBasics;
		private ComboBox CmbRenderMode;
		private CheckBox CbxEnableOverlay;
		private TableLayoutPanel tableLayoutPanel32;
		private SplitContainer splitContainer3;
		private TableLayoutPanel tableLayoutPanel33;
		private TableLayoutPanel tableLayoutPanel35;
		private TableLayoutPanel tableLayoutPanel34;
		private TableLayoutPanel TlpSelectedTriggerLeft;
		private TableLayoutPanel tableLayoutPanel36;
		private TableLayoutPanel tableLayoutPanel37;
		private TabPage TbpMisc;
		private Button BtnCameraFps;
		private CheckBox CbxShowFeet;
		private GroupBox GbxController;
		private TableLayoutPanel tableLayoutPanel23;
		private TableLayoutPanel tableLayoutPanel28;
		private Label LblButtonR1;
		private Label LblButtonL1;
		private Label LblButtonR2;
		private Label LblButtonL2;
		private TableLayoutPanel tableLayoutPanel31;
		private Label LblButtonSelect;
		private Label LblButtonR3;
		private Label LblButtonStart;
		private Label LblButtonL3;
		private TableLayoutPanel tableLayoutPanel30;
		private Label LblButtonTriangle;
		private Label LblButtonSquare;
		private Label LblButtonCircle;
		private Label LblButtonX;
		private CheckBox CbxEnableControllerReporting;
		private TableLayoutPanel tableLayoutPanel29;
		private Label LblButtonUp;
		private Label LblButtonLeft;
		private Label LblButtonRight;
		private Label LblButtonDown;
		private TableLayoutPanel tableLayoutPanel27;
		private CheckBox CbxCameraFlyInvert;
		private Label label4;
		private CheckBox CbxCameraDetach;
		private Button BtnCameraFly;
		private Label label3;
		private TableLayoutPanel tableLayoutPanel38;
		private CheckBox CbxAlwaysRun;
		private Label label48;
		private NumericUpDown NudEyeHeight;
		private CheckBox CbxHideHarry;
		private TableLayoutPanel tableLayoutPanel39;
		private CheckBox CbxShowLookAt;
		private PictureBox PbxMapGraphic;
		private NumericUpDown NudCameraFlySpeed;
		private NumericUpDown NudCameraFlySensitivity;
		private Button BtnInputBinds;
		private TabPage TbpSettings;
		private GroupBox GbxSettingsFiles;
		private TableLayoutPanel tableLayoutPanel40;
		private Label LblSettingsLocal;
		private Label LblSettingsRoaming;
		private TextBox TbxSettingsFilesRoaming;
		private TextBox TbxSettingsFilesLocal;
		private Button BtnSettingsGoLocal;
		private Button BtnSettingsGoRoaming;
		private Button BtnSettingsSaveCopies;
		private Button BtnSettingsResetAll;
		private TableLayoutPanel TlpSettings;
		private GroupBox GbxOverlayDisplaySurface;
		private RadioButton RdoOverlayDisplaySurfaceFramebuffer;
		private RadioButton RdoOverlayDisplaySurfaceEmuCore;
		private RadioButton RdoOverlayDisplaySurfaceClient;
		private TableLayoutPanel tableLayoutPanel42;
		private TableLayoutPanel tableLayoutPanel41;
		private CheckBox CbxAntialiasing;
		private GroupBox GbxOverlayBackend;
		private TableLayoutPanel tableLayoutPanel43;
		private RadioButton RdoBackendBitmap;
		private RadioButton RdoBackendBizHawkGui;
		private ContextMenuStrip CmsSelectedPoi;
		private ToolStripMenuItem TsmSelectedPoiResetProperty;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripMenuItem TsmSelectedPoiResetAll;
		private Label LblSelectedTriggerThing5;
		private Label LblSelectedTriggerThing6;
		private Label LblSelectedTriggerStageIndex;
		private CheckBox CbxSelectedTriggerSomeBool;
		private NumericUpDown NudSelectedTriggerStageIndex;
		private TextBox TbxSelectedPoiX;
		private TextBox TbxSelectedPoiZ;
		private MaskedTextBox MtbSelectedPoiGeometry;
		private MaskedTextBox MtbSelectedTriggerPoiGeometry;
		private MaskedTextBox MtbSelectedTriggerThing0;
		private MaskedTextBox MtbSelectedTriggerThing1;
		private MaskedTextBox MtbSelectedTriggerThing5;
		private MaskedTextBox MtbSelectedTriggerThing6;
		private MaskedTextBox MtbSelectedTriggerThing2;
		private MaskedTextBox MtbSelectedTriggerThing3;
		private MaskedTextBox MtbSelectedTriggerThing4;
		private NumericUpDown NudSelectedTriggerFiredGroup;
		private NumericUpDown NudSelectedTriggerPoiIndex;
		private ComboBox CmbSelectedTriggerStyle;
		private CheckBox CbxSelectedTriggerFired;
		private ContextMenuStrip CmsSelectedTrigger;
		private ToolStripMenuItem TsmSelectedTriggerResetProperty;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripMenuItem TsmSelectedTriggerResetAllProperties;
		private TableLayoutPanel tableLayoutPanel44;
		private Button BtnClearCameraPaths;
		private TextBox TbxCameraPathVolumeMinX;
		private TextBox TbxCameraPathVolumeMinY;
		private TextBox TbxCameraPathVolumeMinZ;
		private TextBox TbxCameraPathVolumeMaxX;
		private TextBox TbxCameraPathVolumeMaxY;
		private TextBox TbxCameraPathVolumeMaxZ;
		private TextBox TbxCameraPathAreaMinX;
		private TextBox TbxCameraPathAreaMinZ;
		private TextBox TbxCameraPathAreaMaxX;
		private TextBox TbxCameraPathAreaMaxZ;
		private MaskedTextBox MtbCameraPathThing4;
		private MaskedTextBox MtbCameraPathThing5;
		private MaskedTextBox MtbCameraPathThing6;
		private TextBox TbxCameraPathPitch;
		private TextBox TbxCameraPathYaw;
		private ContextMenuStrip CmsSelectedCameraPath;
		private ToolStripMenuItem TsmSelectedCameraPathResetProperty;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripMenuItem TsmSelectedCameraPathResetAll;
	}
}
