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
            this.LblFov = new System.Windows.Forms.Label();
            this.TrkFov = new System.Windows.Forms.TrackBar();
            this.CbxCameraLockToHead = new System.Windows.Forms.CheckBox();
            this.CbxCameraFreeze = new System.Windows.Forms.CheckBox();
            this.CbxShowLookAt = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnGrabMapGraphic = new System.Windows.Forms.Button();
            this.PbxMapGraphic = new System.Windows.Forms.PictureBox();
            this.TbcMainTabs = new System.Windows.Forms.TabControl();
            this.TbpBasics = new System.Windows.Forms.TabPage();
            this.TlpBasics = new System.Windows.Forms.TableLayoutPanel();
            this.GbxControls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel39 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.TbxCameraFlySensitivity = new System.Windows.Forms.TextBox();
            this.CbxCameraFlyInvert = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel38 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnFirstPerson = new System.Windows.Forms.Button();
            this.NudEyeHeight = new System.Windows.Forms.NumericUpDown();
            this.label48 = new System.Windows.Forms.Label();
            this.CbxAlwaysRun = new System.Windows.Forms.CheckBox();
            this.CbxShowFeet = new System.Windows.Forms.CheckBox();
            this.CbxHideHarry = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel27 = new System.Windows.Forms.TableLayoutPanel();
            this.BtnCameraFly = new System.Windows.Forms.Button();
            this.TbxCameraFlySpeed = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.GbxOverlay = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel26 = new System.Windows.Forms.TableLayoutPanel();
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
            this.NudOverlayRenderableOpacity = new System.Windows.Forms.NumericUpDown();
            this.CbxReadLevelDataOnStageLoad = new System.Windows.Forms.CheckBox();
            this.CbxEnableOverlayCameraReporting = new System.Windows.Forms.CheckBox();
            this.NudOverlayCameraPitch = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraYaw = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayCameraRoll = new System.Windows.Forms.NumericUpDown();
            this.CbxCullBeyondFarClip = new System.Windows.Forms.CheckBox();
            this.CbxCullBackfaces = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblOverlayCamPitch = new System.Windows.Forms.Label();
            this.LblOverlayCamYaw = new System.Windows.Forms.Label();
            this.LblOverlayCamRoll = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionX = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionY = new System.Windows.Forms.Label();
            this.LblOverlayCamPositionZ = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.NudCrosshairLength = new System.Windows.Forms.NumericUpDown();
            this.label69 = new System.Windows.Forms.Label();
            this.CbxEnableOverlay = new System.Windows.Forms.CheckBox();
            this.CmbRenderMode = new System.Windows.Forms.ComboBox();
            this.CbxOverlayRenderToFramebuffer = new System.Windows.Forms.CheckBox();
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
            this.RdoOverlayAxisColorsOff = new System.Windows.Forms.RadioButton();
            this.label68 = new System.Windows.Forms.Label();
            this.CmbRenderShape = new System.Windows.Forms.ComboBox();
            this.RdoOverlayAxisColorsOverlay = new System.Windows.Forms.RadioButton();
            this.RdoOverlayAxisColorsGame = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel37 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TlpSelectedTriggerLeft = new System.Windows.Forms.TableLayoutPanel();
            this.CbxSelectedTriggerDisabled = new System.Windows.Forms.CheckBox();
            this.LblSelectedTriggerAddress = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiGeometry = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing0 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing1 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerFired = new System.Windows.Forms.Label();
            this.CbxSelectedTriggerEnableUpdates = new System.Windows.Forms.CheckBox();
            this.label49 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing4 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.NudSelectedTriggerTargetIndex = new System.Windows.Forms.NumericUpDown();
            this.CmbSelectedTriggerType = new System.Windows.Forms.ComboBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerTypeInfo = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing3 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerPoiIndex = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerStyle = new System.Windows.Forms.Label();
            this.LblSelectedTriggerThing2 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerSomeIndex = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.LblSelectedTriggerFiredDetails = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel36 = new System.Windows.Forms.TableLayoutPanel();
            this.LbxPoiAssociatedTriggers = new System.Windows.Forms.ListBox();
            this.label33 = new System.Windows.Forms.Label();
            this.BtnGoToPoi = new System.Windows.Forms.Button();
            this.label38 = new System.Windows.Forms.Label();
            this.LblSelectedPoiAddress = new System.Windows.Forms.Label();
            this.LblSelectedPoiXZ = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.LblSelectedPoiGeometry = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.TbpCamera = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LbxCameraPaths = new System.Windows.Forms.ListBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.label107 = new System.Windows.Forms.Label();
            this.LblCameraPathPitch = new System.Windows.Forms.Label();
            this.LblCameraPathYaw = new System.Windows.Forms.Label();
            this.LblCameraPathAddress = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label83 = new System.Windows.Forms.Label();
            this.LblCameraPathThing6 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.LblCameraPathVolumeMin = new System.Windows.Forms.Label();
            this.BtnCameraPathGoToVolumeMin = new System.Windows.Forms.Button();
            this.LblCameraPathThing5 = new System.Windows.Forms.Label();
            this.BtnCameraPathGoToVolumeMax = new System.Windows.Forms.Button();
            this.LblCameraPathVolumeMax = new System.Windows.Forms.Label();
            this.LblCameraPathThing4 = new System.Windows.Forms.Label();
            this.label104 = new System.Windows.Forms.Label();
            this.label92 = new System.Windows.Forms.Label();
            this.LblCameraPathAreaMin = new System.Windows.Forms.Label();
            this.LblCameraPathAreaMax = new System.Windows.Forms.Label();
            this.label102 = new System.Windows.Forms.Label();
            this.CbxSelectedCameraPathDisabled = new System.Windows.Forms.CheckBox();
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
            this.CbxStats = new System.Windows.Forms.CheckBox();
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
            this.NudWorldTintR = new System.Windows.Forms.NumericUpDown();
            this.NudWorldTintG = new System.Windows.Forms.NumericUpDown();
            this.BtnWorldTintColor = new System.Windows.Forms.Button();
            this.NudWorldTintB = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxCustomFog = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnCustomFogCurrent = new System.Windows.Forms.Button();
            this.BtnFogColorDefault = new System.Windows.Forms.Button();
            this.NudFogR = new System.Windows.Forms.NumericUpDown();
            this.NudFogG = new System.Windows.Forms.NumericUpDown();
            this.NudFogB = new System.Windows.Forms.NumericUpDown();
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
            this.TrkModelScale = new System.Windows.Forms.TrackBar();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.NudModelX = new System.Windows.Forms.NumericUpDown();
            this.NudModelY = new System.Windows.Forms.NumericUpDown();
            this.NudModelZ = new System.Windows.Forms.NumericUpDown();
            this.LblModelX = new System.Windows.Forms.Label();
            this.LblModelY = new System.Windows.Forms.Label();
            this.LblModelZ = new System.Windows.Forms.Label();
            this.BtnModelSetPosition = new System.Windows.Forms.Button();
            this.BtnModelGetPosition = new System.Windows.Forms.Button();
            this.LblModelScale = new System.Windows.Forms.Label();
            this.CbxEnableModelDisplay = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.NudOverlayTestBoxSizeX = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxSizeY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxSizeZ = new System.Windows.Forms.NumericUpDown();
            this.CbxOverlayTestBox = new System.Windows.Forms.CheckBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.NudOverlayTestBoxX = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestBoxZ = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxOverlayTestSheet = new System.Windows.Forms.CheckBox();
            this.NudOverlayTestSheetX = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestSheetSizeX = new System.Windows.Forms.NumericUpDown();
            this.label86 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.label87 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label88 = new System.Windows.Forms.Label();
            this.NudOverlayTestSheetSizeZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestSheetZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestSheetY = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.CbxOverlayTestLine = new System.Windows.Forms.CheckBox();
            this.NudOverlayTestLineAX = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineAY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineAZ = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineBX = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineBY = new System.Windows.Forms.NumericUpDown();
            this.NudOverlayTestLineBZ = new System.Windows.Forms.NumericUpDown();
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
            this.CbxEnableControlsSection = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel29 = new System.Windows.Forms.TableLayoutPanel();
            this.LblButtonUp = new System.Windows.Forms.Label();
            this.LblButtonLeft = new System.Windows.Forms.Label();
            this.LblButtonRight = new System.Windows.Forms.Label();
            this.LblButtonDown = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BpbFramebuffer = new SHME.ExternalTool.BetterPictureBox();
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
            this.tableLayoutPanel38.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudEyeHeight)).BeginInit();
            this.tableLayoutPanel27.SuspendLayout();
            this.GbxOverlay.SuspendLayout();
            this.tableLayoutPanel26.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayRenderableOpacity)).BeginInit();
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
            this.groupBox2.SuspendLayout();
            this.TlpSelectedTriggerLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel36.SuspendLayout();
            this.TbpCamera.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.TbpStats.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.TbpMap.SuspendLayout();
            this.TbpFog.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).BeginInit();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TrkModelScale)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelZ)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxZ)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetSizeZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetY)).BeginInit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBZ)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.BpbFramebuffer)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnGetPosition
            // 
            this.BtnGetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGetPosition.AutoSize = true;
            this.BtnGetPosition.Location = new System.Drawing.Point(3, 34);
            this.BtnGetPosition.Name = "BtnGetPosition";
            this.BtnGetPosition.Size = new System.Drawing.Size(75, 25);
            this.BtnGetPosition.TabIndex = 0;
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
            this.BtnSetPosition.TabIndex = 4;
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
            this.TbxPositionX.TabIndex = 1;
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
            this.TbxPositionY.TabIndex = 2;
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
            this.LblHarryPositionX.TabIndex = 4;
            this.LblHarryPositionX.Text = "<xxxxx>";
            this.LblHarryPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblHarryPositionY
            // 
            this.LblHarryPositionY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPositionY.Location = new System.Drawing.Point(141, 16);
            this.LblHarryPositionY.Name = "LblHarryPositionY";
            this.LblHarryPositionY.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPositionY.TabIndex = 5;
            this.LblHarryPositionY.Text = "<yyyyy>";
            this.LblHarryPositionY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TbxHarryPitch
            // 
            this.TbxHarryPitch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxHarryPitch.Location = new System.Drawing.Point(84, 129);
            this.TbxHarryPitch.Name = "TbxHarryPitch";
            this.TbxHarryPitch.Size = new System.Drawing.Size(49, 20);
            this.TbxHarryPitch.TabIndex = 6;
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
            this.TbxHarryYaw.TabIndex = 8;
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
            this.TbxHarryRoll.TabIndex = 10;
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
            this.BtnGetAngles.TabIndex = 5;
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
            this.tableLayoutPanel24.TabIndex = 31;
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
            this.CbxEnableHarrySection.TabIndex = 16;
            this.CbxEnableHarrySection.Text = "Enable";
            this.CbxEnableHarrySection.UseVisualStyleBackColor = true;
            // 
            // TbxPositionZ
            // 
            this.TbxPositionZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxPositionZ.Location = new System.Drawing.Point(194, 36);
            this.TbxPositionZ.Name = "TbxPositionZ";
            this.TbxPositionZ.Size = new System.Drawing.Size(49, 20);
            this.TbxPositionZ.TabIndex = 3;
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
            this.LblHarryPositionZ.TabIndex = 18;
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
            this.label59.TabIndex = 23;
            this.label59.Text = "Position";
            // 
            // label61
            // 
            this.label61.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(21, 102);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(39, 13);
            this.label61.TabIndex = 24;
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
            this.label18.TabIndex = 25;
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
            this.label19.TabIndex = 29;
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
            this.LblSpawnGeometry.TabIndex = 27;
            this.LblSpawnGeometry.Text = "<geometry>";
            // 
            // LblHarryRoll
            // 
            this.LblHarryRoll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryRoll.Location = new System.Drawing.Point(196, 109);
            this.LblHarryRoll.Name = "LblHarryRoll";
            this.LblHarryRoll.Size = new System.Drawing.Size(45, 15);
            this.LblHarryRoll.TabIndex = 15;
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
            this.BtnSetAngles.TabIndex = 12;
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
            this.LblHarryYaw.TabIndex = 14;
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
            this.LblSpawnXZ.TabIndex = 26;
            this.LblSpawnXZ.Text = "PLACEHOLDER TEXT";
            // 
            // LblHarryPitch
            // 
            this.LblHarryPitch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblHarryPitch.Location = new System.Drawing.Point(86, 109);
            this.LblHarryPitch.Name = "LblHarryPitch";
            this.LblHarryPitch.Size = new System.Drawing.Size(45, 15);
            this.LblHarryPitch.TabIndex = 13;
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
            this.CbxHarrySetPositionMoveCamera.TabIndex = 30;
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
            this.tableLayoutPanel25.Controls.Add(this.LblFov, 2, 5);
            this.tableLayoutPanel25.Controls.Add(this.TrkFov, 0, 7);
            this.tableLayoutPanel25.Controls.Add(this.CbxCameraLockToHead, 0, 6);
            this.tableLayoutPanel25.Controls.Add(this.CbxCameraFreeze, 0, 5);
            this.tableLayoutPanel25.Controls.Add(this.CbxShowLookAt, 3, 4);
            this.tableLayoutPanel25.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel25.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel25.Name = "tableLayoutPanel25";
            this.tableLayoutPanel25.RowCount = 8;
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel25.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel25.Size = new System.Drawing.Size(329, 281);
            this.tableLayoutPanel25.TabIndex = 36;
            // 
            // CbxCameraDetach
            // 
            this.CbxCameraDetach.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraDetach.AutoSize = true;
            this.CbxCameraDetach.Location = new System.Drawing.Point(3, 135);
            this.CbxCameraDetach.Name = "CbxCameraDetach";
            this.CbxCameraDetach.Size = new System.Drawing.Size(61, 17);
            this.CbxCameraDetach.TabIndex = 23;
            this.CbxCameraDetach.Text = "Detach";
            this.CbxCameraDetach.UseVisualStyleBackColor = true;
            this.CbxCameraDetach.CheckedChanged += new System.EventHandler(this.CbxCameraDetach_CheckedChanged);
            // 
            // LblCameraPositionZ
            // 
            this.LblCameraPositionZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionZ.Location = new System.Drawing.Point(70, 104);
            this.LblCameraPositionZ.Name = "LblCameraPositionZ";
            this.LblCameraPositionZ.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionZ.TabIndex = 2;
            this.LblCameraPositionZ.Text = "<z>";
            this.LblCameraPositionZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.LblCameraPositionZ, "The game camera\'s position in SH coordinates");
            // 
            // label63
            // 
            this.label63.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(47, 73);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(17, 13);
            this.label63.TabIndex = 30;
            this.label63.Text = "Y:";
            // 
            // label62
            // 
            this.label62.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(47, 41);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(17, 13);
            this.label62.TabIndex = 29;
            this.label62.Text = "X:";
            // 
            // LblCameraPositionY
            // 
            this.LblCameraPositionY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionY.Location = new System.Drawing.Point(70, 72);
            this.LblCameraPositionY.Name = "LblCameraPositionY";
            this.LblCameraPositionY.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionY.TabIndex = 1;
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
            this.label13.TabIndex = 18;
            this.label13.Text = "Draw distance:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel25.SetColumnSpan(this.label1, 2);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "X east, Y down, Z north";
            this.toolTip1.SetToolTip(this.label1, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblCameraPositionX
            // 
            this.LblCameraPositionX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPositionX.Location = new System.Drawing.Point(70, 40);
            this.LblCameraPositionX.Name = "LblCameraPositionX";
            this.LblCameraPositionX.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPositionX.TabIndex = 0;
            this.LblCameraPositionX.Text = "<x>";
            this.LblCameraPositionX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.LblCameraPositionX, "The game camera\'s position in SH coordinates");
            // 
            // LblCameraDrawDistance
            // 
            this.LblCameraDrawDistance.Location = new System.Drawing.Point(276, 0);
            this.LblCameraDrawDistance.Name = "LblCameraDrawDistance";
            this.LblCameraDrawDistance.Size = new System.Drawing.Size(50, 15);
            this.LblCameraDrawDistance.TabIndex = 17;
            this.LblCameraDrawDistance.Text = "<meters>";
            // 
            // label64
            // 
            this.label64.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(47, 105);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(17, 13);
            this.label64.TabIndex = 31;
            this.label64.Text = "Z:";
            // 
            // label67
            // 
            this.label67.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(145, 105);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(28, 13);
            this.label67.TabIndex = 34;
            this.label67.Text = "Roll:";
            // 
            // label66
            // 
            this.label66.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(142, 73);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(31, 13);
            this.label66.TabIndex = 33;
            this.label66.Text = "Yaw:";
            // 
            // label65
            // 
            this.label65.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(139, 41);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(34, 13);
            this.label65.TabIndex = 32;
            this.label65.Text = "Pitch:";
            // 
            // LblCameraPitch
            // 
            this.LblCameraPitch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraPitch, 2);
            this.LblCameraPitch.Location = new System.Drawing.Point(179, 40);
            this.LblCameraPitch.Name = "LblCameraPitch";
            this.LblCameraPitch.Size = new System.Drawing.Size(45, 15);
            this.LblCameraPitch.TabIndex = 3;
            this.LblCameraPitch.Text = "<pitch>";
            this.LblCameraPitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCameraYaw
            // 
            this.LblCameraYaw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraYaw, 2);
            this.LblCameraYaw.Location = new System.Drawing.Point(179, 72);
            this.LblCameraYaw.Name = "LblCameraYaw";
            this.LblCameraYaw.Size = new System.Drawing.Size(45, 15);
            this.LblCameraYaw.TabIndex = 4;
            this.LblCameraYaw.Text = "<yaw>";
            this.LblCameraYaw.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCameraRoll
            // 
            this.LblCameraRoll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel25.SetColumnSpan(this.LblCameraRoll, 2);
            this.LblCameraRoll.Location = new System.Drawing.Point(179, 104);
            this.LblCameraRoll.Name = "LblCameraRoll";
            this.LblCameraRoll.Size = new System.Drawing.Size(45, 15);
            this.LblCameraRoll.TabIndex = 5;
            this.LblCameraRoll.Text = "<roll>";
            this.LblCameraRoll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblFov
            // 
            this.LblFov.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblFov.Location = new System.Drawing.Point(128, 177);
            this.LblFov.Name = "LblFov";
            this.LblFov.Size = new System.Drawing.Size(45, 15);
            this.LblFov.TabIndex = 20;
            this.LblFov.Text = "54";
            this.LblFov.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.LblFov, "Vertical FOV, in degrees");
            // 
            // TrkFov
            // 
            this.TrkFov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel25.SetColumnSpan(this.TrkFov, 5);
            this.TrkFov.Location = new System.Drawing.Point(3, 230);
            this.TrkFov.Maximum = 120;
            this.TrkFov.Minimum = 1;
            this.TrkFov.Name = "TrkFov";
            this.TrkFov.Size = new System.Drawing.Size(323, 45);
            this.TrkFov.TabIndex = 19;
            this.toolTip1.SetToolTip(this.TrkFov, "Vertical FOV, in degrees");
            this.TrkFov.Value = 54;
            this.TrkFov.Scroll += new System.EventHandler(this.TrkFov_Scroll);
            // 
            // CbxCameraLockToHead
            // 
            this.CbxCameraLockToHead.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraLockToHead.AutoSize = true;
            this.tableLayoutPanel25.SetColumnSpan(this.CbxCameraLockToHead, 2);
            this.CbxCameraLockToHead.Location = new System.Drawing.Point(3, 199);
            this.CbxCameraLockToHead.Name = "CbxCameraLockToHead";
            this.CbxCameraLockToHead.Size = new System.Drawing.Size(89, 17);
            this.CbxCameraLockToHead.TabIndex = 35;
            this.CbxCameraLockToHead.Text = "Lock to head";
            this.CbxCameraLockToHead.UseVisualStyleBackColor = true;
            // 
            // CbxCameraFreeze
            // 
            this.CbxCameraFreeze.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraFreeze.AutoSize = true;
            this.CbxCameraFreeze.Location = new System.Drawing.Point(3, 167);
            this.CbxCameraFreeze.Name = "CbxCameraFreeze";
            this.CbxCameraFreeze.Size = new System.Drawing.Size(58, 17);
            this.CbxCameraFreeze.TabIndex = 16;
            this.CbxCameraFreeze.Text = "Freeze";
            this.CbxCameraFreeze.UseVisualStyleBackColor = true;
            this.CbxCameraFreeze.CheckedChanged += new System.EventHandler(this.CbxCameraFreeze_CheckedChanged);
            // 
            // CbxShowLookAt
            // 
            this.CbxShowLookAt.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxShowLookAt.AutoSize = true;
            this.CbxShowLookAt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel25.SetColumnSpan(this.CbxShowLookAt, 2);
            this.CbxShowLookAt.Location = new System.Drawing.Point(238, 135);
            this.CbxShowLookAt.Name = "CbxShowLookAt";
            this.CbxShowLookAt.Size = new System.Drawing.Size(88, 17);
            this.CbxShowLookAt.TabIndex = 93;
            this.CbxShowLookAt.Text = "Show look at";
            this.toolTip1.SetToolTip(this.CbxShowLookAt, "Whether to draw directly on the game\'s framebuffer instead of BizHawk\'s GUI. Curr" +
        "ently available only in the Octoshock core.");
            this.CbxShowLookAt.UseVisualStyleBackColor = true;
            // 
            // BtnGrabMapGraphic
            // 
            this.BtnGrabMapGraphic.AutoSize = true;
            this.BtnGrabMapGraphic.Location = new System.Drawing.Point(6, 492);
            this.BtnGrabMapGraphic.Margin = new System.Windows.Forms.Padding(0);
            this.BtnGrabMapGraphic.Name = "BtnGrabMapGraphic";
            this.BtnGrabMapGraphic.Size = new System.Drawing.Size(125, 25);
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
            this.tableLayoutPanel39.ColumnCount = 3;
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel39.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel39.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel39.Controls.Add(this.TbxCameraFlySensitivity, 2, 1);
            this.tableLayoutPanel39.Controls.Add(this.CbxCameraFlyInvert, 0, 1);
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
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Sensitivity";
            this.toolTip1.SetToolTip(this.label4, "Mouse sensitivity, as an arbitrary multiplier");
            // 
            // TbxCameraFlySensitivity
            // 
            this.TbxCameraFlySensitivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraFlySensitivity.Location = new System.Drawing.Point(276, 72);
            this.TbxCameraFlySensitivity.Name = "TbxCameraFlySensitivity";
            this.TbxCameraFlySensitivity.Size = new System.Drawing.Size(50, 20);
            this.TbxCameraFlySensitivity.TabIndex = 25;
            this.TbxCameraFlySensitivity.Text = "0.25";
            this.toolTip1.SetToolTip(this.TbxCameraFlySensitivity, "Mouse sensitivity, as an arbitrary multiplier");
            this.TbxCameraFlySensitivity.TextChanged += new System.EventHandler(this.TbxCameraFlySensitivity_TextChanged);
            // 
            // CbxCameraFlyInvert
            // 
            this.CbxCameraFlyInvert.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxCameraFlyInvert.AutoSize = true;
            this.CbxCameraFlyInvert.Location = new System.Drawing.Point(3, 73);
            this.CbxCameraFlyInvert.Name = "CbxCameraFlyInvert";
            this.CbxCameraFlyInvert.Size = new System.Drawing.Size(53, 17);
            this.CbxCameraFlyInvert.TabIndex = 15;
            this.CbxCameraFlyInvert.Text = "Invert";
            this.CbxCameraFlyInvert.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel38.Controls.Add(this.BtnFirstPerson, 0, 0);
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
            // BtnFirstPerson
            // 
            this.BtnFirstPerson.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFirstPerson.AutoSize = true;
            this.BtnFirstPerson.Location = new System.Drawing.Point(3, 5);
            this.BtnFirstPerson.Name = "BtnFirstPerson";
            this.tableLayoutPanel38.SetRowSpan(this.BtnFirstPerson, 2);
            this.BtnFirstPerson.Size = new System.Drawing.Size(75, 50);
            this.BtnFirstPerson.TabIndex = 30;
            this.BtnFirstPerson.Text = "First person";
            this.toolTip1.SetToolTip(this.BtnFirstPerson, "Enter WASD first person mode");
            this.BtnFirstPerson.UseVisualStyleBackColor = true;
            this.BtnFirstPerson.Click += new System.EventHandler(this.BtnFirstPerson_ClickFirst);
            this.BtnFirstPerson.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnFirstPerson_KeyDown);
            this.BtnFirstPerson.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnFirstPerson_KeyUp);
            this.BtnFirstPerson.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnFirstPerson_MouseDown);
            this.BtnFirstPerson.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnFirstPerson_MouseUp);
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
            this.NudEyeHeight.Location = new System.Drawing.Point(271, 5);
            this.NudEyeHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.NudEyeHeight.Name = "NudEyeHeight";
            this.NudEyeHeight.Size = new System.Drawing.Size(55, 20);
            this.NudEyeHeight.TabIndex = 50;
            this.toolTip1.SetToolTip(this.NudEyeHeight, "Crosshair length as a percentage of viewport height");
            this.NudEyeHeight.Value = new decimal(new int[] {
            16,
            0,
            0,
            -2147418112});
            // 
            // label48
            // 
            this.label48.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(208, 8);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(57, 13);
            this.label48.TabIndex = 45;
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
            this.CbxAlwaysRun.TabIndex = 55;
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
            this.CbxShowFeet.TabIndex = 40;
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
            this.CbxHideHarry.TabIndex = 35;
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
            this.tableLayoutPanel27.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel27.Controls.Add(this.BtnCameraFly, 0, 0);
            this.tableLayoutPanel27.Controls.Add(this.TbxCameraFlySpeed, 2, 0);
            this.tableLayoutPanel27.Controls.Add(this.label3, 1, 0);
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
            this.toolTip1.SetToolTip(this.BtnCameraFly, "Enter WASDEQ fly mode");
            this.BtnCameraFly.UseVisualStyleBackColor = true;
            this.BtnCameraFly.Click += new System.EventHandler(this.BtnCameraFly_ClickFirst);
            this.BtnCameraFly.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFly_KeyDown);
            this.BtnCameraFly.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnCameraFly_KeyUp);
            // 
            // TbxCameraFlySpeed
            // 
            this.TbxCameraFlySpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxCameraFlySpeed.Location = new System.Drawing.Point(276, 18);
            this.TbxCameraFlySpeed.Name = "TbxCameraFlySpeed";
            this.TbxCameraFlySpeed.Size = new System.Drawing.Size(50, 20);
            this.TbxCameraFlySpeed.TabIndex = 10;
            this.TbxCameraFlySpeed.Text = "0.125";
            this.toolTip1.SetToolTip(this.TbxCameraFlySpeed, "Movement speed, in units per frame");
            this.TbxCameraFlySpeed.TextChanged += new System.EventHandler(this.TbxCameraFlySpeed_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(232, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Speed";
            this.toolTip1.SetToolTip(this.label3, "Movement speed, in units per frame");
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
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayRenderableOpacity, 4, 8);
            this.tableLayoutPanel26.Controls.Add(this.CbxReadLevelDataOnStageLoad, 0, 8);
            this.tableLayoutPanel26.Controls.Add(this.CbxEnableOverlayCameraReporting, 0, 7);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraPitch, 4, 1);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraYaw, 4, 2);
            this.tableLayoutPanel26.Controls.Add(this.NudOverlayCameraRoll, 4, 3);
            this.tableLayoutPanel26.Controls.Add(this.CbxCullBeyondFarClip, 3, 6);
            this.tableLayoutPanel26.Controls.Add(this.CbxCullBackfaces, 3, 5);
            this.tableLayoutPanel26.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPitch, 0, 4);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamYaw, 0, 5);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamRoll, 0, 6);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionX, 0, 1);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionY, 0, 2);
            this.tableLayoutPanel26.Controls.Add(this.LblOverlayCamPositionZ, 0, 3);
            this.tableLayoutPanel26.Controls.Add(this.label70, 2, 7);
            this.tableLayoutPanel26.Controls.Add(this.NudCrosshairLength, 4, 7);
            this.tableLayoutPanel26.Controls.Add(this.label69, 0, 9);
            this.tableLayoutPanel26.Controls.Add(this.CbxEnableOverlay, 3, 10);
            this.tableLayoutPanel26.Controls.Add(this.CmbRenderMode, 0, 10);
            this.tableLayoutPanel26.Controls.Add(this.CbxOverlayRenderToFramebuffer, 2, 4);
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
            this.tableLayoutPanel26.Size = new System.Drawing.Size(329, 281);
            this.tableLayoutPanel26.TabIndex = 102;
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
            this.CbxOverlayCameraMatchGame.TabIndex = 36;
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
            this.label22.TabIndex = 40;
            this.label22.Text = "Pitch:";
            // 
            // label23
            // 
            this.label23.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(234, 55);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 41;
            this.label23.Text = "Yaw:";
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(237, 81);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 13);
            this.label24.TabIndex = 42;
            this.label24.Text = "Roll:";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(102, 29);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 13);
            this.label27.TabIndex = 43;
            this.label27.Text = "X:";
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(102, 55);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(17, 13);
            this.label26.TabIndex = 44;
            this.label26.Text = "Y:";
            // 
            // label25
            // 
            this.label25.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(102, 81);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(17, 13);
            this.label25.TabIndex = 45;
            this.label25.Text = "Z:";
            // 
            // NudOverlayCameraZ
            // 
            this.NudOverlayCameraZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraZ.Location = new System.Drawing.Point(125, 78);
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
            this.NudOverlayCameraZ.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraZ.TabIndex = 39;
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
            this.label84.TabIndex = 101;
            this.label84.Text = "Filled opacity %";
            // 
            // NudOverlayCameraY
            // 
            this.NudOverlayCameraY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayCameraY.Location = new System.Drawing.Point(125, 52);
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
            this.NudOverlayCameraY.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraY.TabIndex = 38;
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
            this.NudOverlayCameraX.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayCameraX.TabIndex = 37;
            this.toolTip1.SetToolTip(this.NudOverlayCameraX, "The overlay camera\'s position in overlay coordinates");
            this.NudOverlayCameraX.ValueChanged += new System.EventHandler(this.NudOverlayCameraX_ValueChanged);
            this.NudOverlayCameraX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayRenderableOpacity
            // 
            this.NudOverlayRenderableOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudOverlayRenderableOpacity.DecimalPlaces = 1;
            this.NudOverlayRenderableOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudOverlayRenderableOpacity.Location = new System.Drawing.Point(271, 199);
            this.NudOverlayRenderableOpacity.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NudOverlayRenderableOpacity.Name = "NudOverlayRenderableOpacity";
            this.NudOverlayRenderableOpacity.Size = new System.Drawing.Size(55, 20);
            this.NudOverlayRenderableOpacity.TabIndex = 100;
            this.NudOverlayRenderableOpacity.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // CbxReadLevelDataOnStageLoad
            // 
            this.CbxReadLevelDataOnStageLoad.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxReadLevelDataOnStageLoad.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxReadLevelDataOnStageLoad, 3);
            this.CbxReadLevelDataOnStageLoad.Location = new System.Drawing.Point(3, 200);
            this.CbxReadLevelDataOnStageLoad.Name = "CbxReadLevelDataOnStageLoad";
            this.CbxReadLevelDataOnStageLoad.Size = new System.Drawing.Size(121, 17);
            this.CbxReadLevelDataOnStageLoad.TabIndex = 96;
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
            this.CbxEnableOverlayCameraReporting.TabIndex = 14;
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
            this.NudOverlayCameraPitch.TabIndex = 33;
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
            this.NudOverlayCameraYaw.TabIndex = 34;
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
            this.NudOverlayCameraRoll.TabIndex = 35;
            this.NudOverlayCameraRoll.ValueChanged += new System.EventHandler(this.NudOverlayCameraRoll_ValueChanged);
            this.NudOverlayCameraRoll.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayCameraRoll.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // CbxCullBeyondFarClip
            // 
            this.CbxCullBeyondFarClip.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxCullBeyondFarClip.AutoSize = true;
            this.CbxCullBeyondFarClip.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxCullBeyondFarClip.Checked = true;
            this.CbxCullBeyondFarClip.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxCullBeyondFarClip, 2);
            this.CbxCullBeyondFarClip.Location = new System.Drawing.Point(246, 150);
            this.CbxCullBeyondFarClip.Name = "CbxCullBeyondFarClip";
            this.CbxCullBeyondFarClip.Size = new System.Drawing.Size(80, 17);
            this.CbxCullBeyondFarClip.TabIndex = 99;
            this.CbxCullBeyondFarClip.Text = "Far clipping";
            this.CbxCullBeyondFarClip.UseVisualStyleBackColor = true;
            this.CbxCullBeyondFarClip.CheckedChanged += new System.EventHandler(this.CbxCullBeyondFarClip_CheckedChanged);
            // 
            // CbxCullBackfaces
            // 
            this.CbxCullBackfaces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CbxCullBackfaces.AutoSize = true;
            this.CbxCullBackfaces.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxCullBackfaces, 2);
            this.CbxCullBackfaces.Location = new System.Drawing.Point(221, 127);
            this.CbxCullBackfaces.Name = "CbxCullBackfaces";
            this.CbxCullBackfaces.Size = new System.Drawing.Size(105, 17);
            this.CbxCullBackfaces.TabIndex = 97;
            this.CbxCullBackfaces.Text = "Backface culling";
            this.CbxCullBackfaces.UseVisualStyleBackColor = true;
            this.CbxCullBackfaces.CheckedChanged += new System.EventHandler(this.CbxCullBackfaces_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.label2, 3);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "X east, Y up, Z south";
            this.toolTip1.SetToolTip(this.label2, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // LblOverlayCamPitch
            // 
            this.LblOverlayCamPitch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPitch.Location = new System.Drawing.Point(8, 105);
            this.LblOverlayCamPitch.Name = "LblOverlayCamPitch";
            this.LblOverlayCamPitch.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPitch.TabIndex = 9;
            this.LblOverlayCamPitch.Text = "<pitch>";
            this.LblOverlayCamPitch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOverlayCamYaw
            // 
            this.LblOverlayCamYaw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamYaw.Location = new System.Drawing.Point(8, 128);
            this.LblOverlayCamYaw.Name = "LblOverlayCamYaw";
            this.LblOverlayCamYaw.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamYaw.TabIndex = 10;
            this.LblOverlayCamYaw.Text = "<yaw>";
            this.LblOverlayCamYaw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOverlayCamRoll
            // 
            this.LblOverlayCamRoll.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamRoll.Location = new System.Drawing.Point(8, 151);
            this.LblOverlayCamRoll.Name = "LblOverlayCamRoll";
            this.LblOverlayCamRoll.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamRoll.TabIndex = 11;
            this.LblOverlayCamRoll.Text = "<roll>";
            this.LblOverlayCamRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOverlayCamPositionX
            // 
            this.LblOverlayCamPositionX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblOverlayCamPositionX.Location = new System.Drawing.Point(8, 28);
            this.LblOverlayCamPositionX.Name = "LblOverlayCamPositionX";
            this.LblOverlayCamPositionX.Size = new System.Drawing.Size(45, 15);
            this.LblOverlayCamPositionX.TabIndex = 6;
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
            this.LblOverlayCamPositionY.TabIndex = 7;
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
            this.LblOverlayCamPositionZ.TabIndex = 8;
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
            this.label70.TabIndex = 94;
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
            this.NudCrosshairLength.TabIndex = 95;
            this.toolTip1.SetToolTip(this.NudCrosshairLength, "Crosshair length as a percentage of viewport height");
            this.NudCrosshairLength.Value = new decimal(new int[] {
            25,
            0,
            0,
            65536});
            this.NudCrosshairLength.ValueChanged += new System.EventHandler(this.NudCrosshairLength_ValueChanged);
            // 
            // label69
            // 
            this.label69.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label69.AutoSize = true;
            this.tableLayoutPanel26.SetColumnSpan(this.label69, 2);
            this.label69.Location = new System.Drawing.Point(25, 241);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(71, 13);
            this.label69.TabIndex = 90;
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
            this.CbxEnableOverlay.TabIndex = 15;
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
            this.CmbRenderMode.TabIndex = 89;
            this.CmbRenderMode.SelectedIndexChanged += new System.EventHandler(this.CmbRenderMode_SelectedIndexChanged);
            // 
            // CbxOverlayRenderToFramebuffer
            // 
            this.CbxOverlayRenderToFramebuffer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxOverlayRenderToFramebuffer.AutoSize = true;
            this.CbxOverlayRenderToFramebuffer.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tableLayoutPanel26.SetColumnSpan(this.CbxOverlayRenderToFramebuffer, 3);
            this.CbxOverlayRenderToFramebuffer.Location = new System.Drawing.Point(197, 104);
            this.CbxOverlayRenderToFramebuffer.Name = "CbxOverlayRenderToFramebuffer";
            this.CbxOverlayRenderToFramebuffer.Size = new System.Drawing.Size(129, 17);
            this.CbxOverlayRenderToFramebuffer.TabIndex = 92;
            this.CbxOverlayRenderToFramebuffer.Text = "Render to framebuffer";
            this.toolTip1.SetToolTip(this.CbxOverlayRenderToFramebuffer, "Whether to draw directly on the game\'s framebuffer instead of BizHawk\'s GUI. Curr" +
        "ently available only in the Octoshock core.");
            this.CbxOverlayRenderToFramebuffer.UseVisualStyleBackColor = true;
            this.CbxOverlayRenderToFramebuffer.CheckedChanged += new System.EventHandler(this.CbxOverlayRenderToFramebuffer_CheckedChanged);
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
            this.splitContainer3.TabIndex = 19;
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
            this.tableLayoutPanel33.TabIndex = 20;
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
            this.tableLayoutPanel35.TabIndex = 74;
            // 
            // BtnReadTriggers
            // 
            this.BtnReadTriggers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadTriggers.AutoSize = true;
            this.BtnReadTriggers.Location = new System.Drawing.Point(3, 3);
            this.BtnReadTriggers.Name = "BtnReadTriggers";
            this.BtnReadTriggers.Size = new System.Drawing.Size(100, 25);
            this.BtnReadTriggers.TabIndex = 70;
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
            this.LblTriggerCount.TabIndex = 71;
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
            this.tableLayoutPanel34.TabIndex = 74;
            // 
            // BtnReadPois
            // 
            this.BtnReadPois.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadPois.AutoSize = true;
            this.BtnReadPois.Location = new System.Drawing.Point(3, 3);
            this.BtnReadPois.Name = "BtnReadPois";
            this.BtnReadPois.Size = new System.Drawing.Size(100, 25);
            this.BtnReadPois.TabIndex = 55;
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
            this.LblPoiCount.TabIndex = 56;
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
            this.LbxPois.TabIndex = 0;
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
            this.LbxTriggers.TabIndex = 69;
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
            this.tableLayoutPanel32.Controls.Add(this.RdoOverlayAxisColorsOff, 4, 2);
            this.tableLayoutPanel32.Controls.Add(this.label68, 0, 1);
            this.tableLayoutPanel32.Controls.Add(this.CmbRenderShape, 0, 2);
            this.tableLayoutPanel32.Controls.Add(this.RdoOverlayAxisColorsOverlay, 3, 2);
            this.tableLayoutPanel32.Controls.Add(this.RdoOverlayAxisColorsGame, 2, 2);
            this.tableLayoutPanel32.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel32.Location = new System.Drawing.Point(0, 498);
            this.tableLayoutPanel32.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel32.Name = "tableLayoutPanel32";
            this.tableLayoutPanel32.RowCount = 3;
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel32.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel32.Size = new System.Drawing.Size(328, 114);
            this.tableLayoutPanel32.TabIndex = 18;
            // 
            // BtnClearPoisTriggers
            // 
            this.tableLayoutPanel32.SetColumnSpan(this.BtnClearPoisTriggers, 5);
            this.BtnClearPoisTriggers.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnClearPoisTriggers.Location = new System.Drawing.Point(0, 0);
            this.BtnClearPoisTriggers.Margin = new System.Windows.Forms.Padding(0);
            this.BtnClearPoisTriggers.Name = "BtnClearPoisTriggers";
            this.BtnClearPoisTriggers.Size = new System.Drawing.Size(328, 25);
            this.BtnClearPoisTriggers.TabIndex = 81;
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
            this.label44.TabIndex = 85;
            this.label44.Text = "Positive axis coloring:";
            this.toolTip1.SetToolTip(this.label44, "Cardinal directions relative to the top-down map view of Old Silent\r\nHill. The ar" +
        "ea maps of indoor levels may not match this.");
            // 
            // RdoOverlayAxisColorsOff
            // 
            this.RdoOverlayAxisColorsOff.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoOverlayAxisColorsOff.AutoSize = true;
            this.RdoOverlayAxisColorsOff.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsOff.Location = new System.Drawing.Point(286, 92);
            this.RdoOverlayAxisColorsOff.Name = "RdoOverlayAxisColorsOff";
            this.RdoOverlayAxisColorsOff.Size = new System.Drawing.Size(39, 17);
            this.RdoOverlayAxisColorsOff.TabIndex = 86;
            this.RdoOverlayAxisColorsOff.TabStop = true;
            this.RdoOverlayAxisColorsOff.Text = "Off";
            this.RdoOverlayAxisColorsOff.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsOff.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // label68
            // 
            this.label68.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(21, 74);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(38, 13);
            this.label68.TabIndex = 87;
            this.label68.Text = "Shape";
            // 
            // CmbRenderShape
            // 
            this.CmbRenderShape.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbRenderShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbRenderShape.FormattingEnabled = true;
            this.CmbRenderShape.Items.AddRange(new object[] {
            "Volumes",
            "Cubes",
            "Centers"});
            this.CmbRenderShape.Location = new System.Drawing.Point(3, 90);
            this.CmbRenderShape.Name = "CmbRenderShape";
            this.CmbRenderShape.Size = new System.Drawing.Size(75, 21);
            this.CmbRenderShape.TabIndex = 80;
            this.CmbRenderShape.SelectedIndexChanged += new System.EventHandler(this.CmbRenderShape_SelectedIndexChanged);
            // 
            // RdoOverlayAxisColorsOverlay
            // 
            this.RdoOverlayAxisColorsOverlay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoOverlayAxisColorsOverlay.AutoSize = true;
            this.RdoOverlayAxisColorsOverlay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsOverlay.Location = new System.Drawing.Point(219, 92);
            this.RdoOverlayAxisColorsOverlay.Name = "RdoOverlayAxisColorsOverlay";
            this.RdoOverlayAxisColorsOverlay.Size = new System.Drawing.Size(61, 17);
            this.RdoOverlayAxisColorsOverlay.TabIndex = 84;
            this.RdoOverlayAxisColorsOverlay.TabStop = true;
            this.RdoOverlayAxisColorsOverlay.Text = "Overlay";
            this.toolTip1.SetToolTip(this.RdoOverlayAxisColorsOverlay, "X east, Y up, Z south");
            this.RdoOverlayAxisColorsOverlay.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsOverlay.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // RdoOverlayAxisColorsGame
            // 
            this.RdoOverlayAxisColorsGame.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RdoOverlayAxisColorsGame.AutoSize = true;
            this.RdoOverlayAxisColorsGame.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.RdoOverlayAxisColorsGame.Checked = true;
            this.RdoOverlayAxisColorsGame.Location = new System.Drawing.Point(160, 92);
            this.RdoOverlayAxisColorsGame.Name = "RdoOverlayAxisColorsGame";
            this.RdoOverlayAxisColorsGame.Size = new System.Drawing.Size(53, 17);
            this.RdoOverlayAxisColorsGame.TabIndex = 83;
            this.RdoOverlayAxisColorsGame.TabStop = true;
            this.RdoOverlayAxisColorsGame.Text = "Game";
            this.toolTip1.SetToolTip(this.RdoOverlayAxisColorsGame, "X east, Y down, Z north");
            this.RdoOverlayAxisColorsGame.UseVisualStyleBackColor = true;
            this.RdoOverlayAxisColorsGame.CheckedChanged += new System.EventHandler(this.RdoOverlayAxisColors_CheckedChanged);
            // 
            // tableLayoutPanel37
            // 
            this.tableLayoutPanel37.ColumnCount = 1;
            this.tableLayoutPanel37.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel37.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel37.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel37.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel37.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel37.Name = "tableLayoutPanel37";
            this.tableLayoutPanel37.RowCount = 2;
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel37.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel37.Size = new System.Drawing.Size(350, 612);
            this.tableLayoutPanel37.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TlpSelectedTriggerLeft);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 244);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(350, 368);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selected trigger";
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
            this.TlpSelectedTriggerLeft.Controls.Add(this.label15, 0, 2);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerPoiGeometry, 1, 2);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label32, 0, 3);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing0, 1, 3);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing1, 1, 4);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label39, 0, 4);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label41, 0, 5);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerFired, 1, 5);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CbxSelectedTriggerEnableUpdates, 2, 0);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label49, 0, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing4, 1, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label42, 2, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.NudSelectedTriggerTargetIndex, 3, 12);
            this.TlpSelectedTriggerLeft.Controls.Add(this.CmbSelectedTriggerType, 3, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label46, 2, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label51, 2, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerTypeInfo, 3, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing3, 1, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerPoiIndex, 1, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label47, 0, 11);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label45, 0, 10);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label43, 0, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerStyle, 1, 9);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerThing2, 1, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerSomeIndex, 1, 7);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label60, 0, 8);
            this.TlpSelectedTriggerLeft.Controls.Add(this.label50, 0, 7);
            this.TlpSelectedTriggerLeft.Controls.Add(this.LblSelectedTriggerFiredDetails, 1, 6);
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
            this.TlpSelectedTriggerLeft.TabIndex = 75;
            // 
            // CbxSelectedTriggerDisabled
            // 
            this.CbxSelectedTriggerDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedTriggerDisabled.AutoSize = true;
            this.CbxSelectedTriggerDisabled.Location = new System.Drawing.Point(83, 32);
            this.CbxSelectedTriggerDisabled.Name = "CbxSelectedTriggerDisabled";
            this.CbxSelectedTriggerDisabled.Size = new System.Drawing.Size(67, 17);
            this.CbxSelectedTriggerDisabled.TabIndex = 91;
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
            this.LblSelectedTriggerAddress.TabIndex = 72;
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
            this.label40.TabIndex = 71;
            this.label40.Text = "Address:";
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 13);
            this.label15.TabIndex = 92;
            this.label15.Text = "POI geometry:";
            // 
            // LblSelectedTriggerPoiGeometry
            // 
            this.LblSelectedTriggerPoiGeometry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerPoiGeometry.AutoSize = true;
            this.TlpSelectedTriggerLeft.SetColumnSpan(this.LblSelectedTriggerPoiGeometry, 3);
            this.LblSelectedTriggerPoiGeometry.Location = new System.Drawing.Point(83, 61);
            this.LblSelectedTriggerPoiGeometry.Name = "LblSelectedTriggerPoiGeometry";
            this.LblSelectedTriggerPoiGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSelectedTriggerPoiGeometry.TabIndex = 93;
            this.LblSelectedTriggerPoiGeometry.Text = "<geometry>";
            // 
            // label32
            // 
            this.label32.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(34, 88);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(43, 13);
            this.label32.TabIndex = 64;
            this.label32.Text = "Thing0:";
            // 
            // LblSelectedTriggerThing0
            // 
            this.LblSelectedTriggerThing0.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerThing0.AutoSize = true;
            this.LblSelectedTriggerThing0.Location = new System.Drawing.Point(83, 88);
            this.LblSelectedTriggerThing0.Name = "LblSelectedTriggerThing0";
            this.LblSelectedTriggerThing0.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing0.TabIndex = 63;
            this.LblSelectedTriggerThing0.Text = "<thing0>";
            // 
            // LblSelectedTriggerThing1
            // 
            this.LblSelectedTriggerThing1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerThing1.AutoSize = true;
            this.LblSelectedTriggerThing1.Location = new System.Drawing.Point(83, 115);
            this.LblSelectedTriggerThing1.Name = "LblSelectedTriggerThing1";
            this.LblSelectedTriggerThing1.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing1.TabIndex = 65;
            this.LblSelectedTriggerThing1.Text = "<thing1>";
            // 
            // label39
            // 
            this.label39.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(34, 115);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(43, 13);
            this.label39.TabIndex = 66;
            this.label39.Text = "Thing1:";
            // 
            // label41
            // 
            this.label41.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(44, 142);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(33, 13);
            this.label41.TabIndex = 68;
            this.label41.Text = "Fired:";
            // 
            // LblSelectedTriggerFired
            // 
            this.LblSelectedTriggerFired.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerFired.AutoSize = true;
            this.LblSelectedTriggerFired.Location = new System.Drawing.Point(83, 142);
            this.LblSelectedTriggerFired.Name = "LblSelectedTriggerFired";
            this.LblSelectedTriggerFired.Size = new System.Drawing.Size(39, 13);
            this.LblSelectedTriggerFired.TabIndex = 67;
            this.LblSelectedTriggerFired.Text = "<fired>";
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
            this.CbxSelectedTriggerEnableUpdates.TabIndex = 88;
            this.CbxSelectedTriggerEnableUpdates.Text = "Enable updates";
            this.CbxSelectedTriggerEnableUpdates.UseVisualStyleBackColor = true;
            // 
            // label49
            // 
            this.label49.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(34, 331);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(43, 13);
            this.label49.TabIndex = 76;
            this.label49.Text = "Thing4:";
            // 
            // LblSelectedTriggerThing4
            // 
            this.LblSelectedTriggerThing4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerThing4.AutoSize = true;
            this.LblSelectedTriggerThing4.Location = new System.Drawing.Point(83, 331);
            this.LblSelectedTriggerThing4.Name = "LblSelectedTriggerThing4";
            this.LblSelectedTriggerThing4.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing4.TabIndex = 75;
            this.LblSelectedTriggerThing4.Text = "<thing4>";
            // 
            // label42
            // 
            this.label42.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(184, 331);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 13);
            this.label42.TabIndex = 82;
            this.label42.Text = "Target index:";
            // 
            // NudSelectedTriggerTargetIndex
            // 
            this.NudSelectedTriggerTargetIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NudSelectedTriggerTargetIndex.Enabled = false;
            this.NudSelectedTriggerTargetIndex.Location = new System.Drawing.Point(259, 327);
            this.NudSelectedTriggerTargetIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.NudSelectedTriggerTargetIndex.Name = "NudSelectedTriggerTargetIndex";
            this.NudSelectedTriggerTargetIndex.Size = new System.Drawing.Size(82, 20);
            this.NudSelectedTriggerTargetIndex.TabIndex = 83;
            // 
            // CmbSelectedTriggerType
            // 
            this.CmbSelectedTriggerType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CmbSelectedTriggerType.Enabled = false;
            this.CmbSelectedTriggerType.FormattingEnabled = true;
            this.CmbSelectedTriggerType.Location = new System.Drawing.Point(259, 300);
            this.CmbSelectedTriggerType.Name = "CmbSelectedTriggerType";
            this.CmbSelectedTriggerType.Size = new System.Drawing.Size(82, 21);
            this.CmbSelectedTriggerType.TabIndex = 84;
            // 
            // label46
            // 
            this.label46.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(219, 304);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(34, 13);
            this.label46.TabIndex = 85;
            this.label46.Text = "Type:";
            // 
            // label51
            // 
            this.label51.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(201, 277);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(52, 13);
            this.label51.TabIndex = 78;
            this.label51.Text = "TypeInfo:";
            // 
            // LblSelectedTriggerTypeInfo
            // 
            this.LblSelectedTriggerTypeInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerTypeInfo.AutoSize = true;
            this.LblSelectedTriggerTypeInfo.Location = new System.Drawing.Point(259, 277);
            this.LblSelectedTriggerTypeInfo.Name = "LblSelectedTriggerTypeInfo";
            this.LblSelectedTriggerTypeInfo.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedTriggerTypeInfo.TabIndex = 77;
            this.LblSelectedTriggerTypeInfo.Text = "<typeinfo>";
            // 
            // LblSelectedTriggerThing3
            // 
            this.LblSelectedTriggerThing3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerThing3.AutoSize = true;
            this.LblSelectedTriggerThing3.Location = new System.Drawing.Point(83, 304);
            this.LblSelectedTriggerThing3.Name = "LblSelectedTriggerThing3";
            this.LblSelectedTriggerThing3.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing3.TabIndex = 73;
            this.LblSelectedTriggerThing3.Text = "<thing3>";
            // 
            // LblSelectedTriggerPoiIndex
            // 
            this.LblSelectedTriggerPoiIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerPoiIndex.AutoSize = true;
            this.LblSelectedTriggerPoiIndex.Location = new System.Drawing.Point(83, 277);
            this.LblSelectedTriggerPoiIndex.Name = "LblSelectedTriggerPoiIndex";
            this.LblSelectedTriggerPoiIndex.Size = new System.Drawing.Size(58, 13);
            this.LblSelectedTriggerPoiIndex.TabIndex = 71;
            this.LblSelectedTriggerPoiIndex.Text = "<poiindex>";
            // 
            // label47
            // 
            this.label47.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(34, 304);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(43, 13);
            this.label47.TabIndex = 74;
            this.label47.Text = "Thing3:";
            // 
            // label45
            // 
            this.label45.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(26, 277);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(51, 13);
            this.label45.TabIndex = 72;
            this.label45.Text = "PoiIndex:";
            // 
            // label43
            // 
            this.label43.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(44, 250);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(33, 13);
            this.label43.TabIndex = 70;
            this.label43.Text = "Style:";
            // 
            // LblSelectedTriggerStyle
            // 
            this.LblSelectedTriggerStyle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerStyle.AutoSize = true;
            this.LblSelectedTriggerStyle.Location = new System.Drawing.Point(83, 250);
            this.LblSelectedTriggerStyle.Name = "LblSelectedTriggerStyle";
            this.LblSelectedTriggerStyle.Size = new System.Drawing.Size(40, 13);
            this.LblSelectedTriggerStyle.TabIndex = 69;
            this.LblSelectedTriggerStyle.Text = "<style>";
            // 
            // LblSelectedTriggerThing2
            // 
            this.LblSelectedTriggerThing2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerThing2.AutoSize = true;
            this.LblSelectedTriggerThing2.Location = new System.Drawing.Point(83, 223);
            this.LblSelectedTriggerThing2.Name = "LblSelectedTriggerThing2";
            this.LblSelectedTriggerThing2.Size = new System.Drawing.Size(48, 13);
            this.LblSelectedTriggerThing2.TabIndex = 94;
            this.LblSelectedTriggerThing2.Text = "<thing2>";
            // 
            // LblSelectedTriggerSomeIndex
            // 
            this.LblSelectedTriggerSomeIndex.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerSomeIndex.AutoSize = true;
            this.LblSelectedTriggerSomeIndex.Location = new System.Drawing.Point(83, 196);
            this.LblSelectedTriggerSomeIndex.Name = "LblSelectedTriggerSomeIndex";
            this.LblSelectedTriggerSomeIndex.Size = new System.Drawing.Size(70, 13);
            this.LblSelectedTriggerSomeIndex.TabIndex = 86;
            this.LblSelectedTriggerSomeIndex.Text = "<someIndex>";
            // 
            // label60
            // 
            this.label60.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(34, 223);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(43, 13);
            this.label60.TabIndex = 95;
            this.label60.Text = "Thing2:";
            // 
            // label50
            // 
            this.label50.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(14, 196);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(63, 13);
            this.label50.TabIndex = 87;
            this.label50.Text = "SomeIndex:";
            // 
            // LblSelectedTriggerFiredDetails
            // 
            this.LblSelectedTriggerFiredDetails.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedTriggerFiredDetails.AutoSize = true;
            this.TlpSelectedTriggerLeft.SetColumnSpan(this.LblSelectedTriggerFiredDetails, 3);
            this.LblSelectedTriggerFiredDetails.Location = new System.Drawing.Point(83, 169);
            this.LblSelectedTriggerFiredDetails.Name = "LblSelectedTriggerFiredDetails";
            this.LblSelectedTriggerFiredDetails.Size = new System.Drawing.Size(84, 13);
            this.LblSelectedTriggerFiredDetails.TabIndex = 89;
            this.LblSelectedTriggerFiredDetails.Text = "Group 0x , bit 0x";
            this.LblSelectedTriggerFiredDetails.Click += new System.EventHandler(this.LblSelectedTriggerFiredDetails_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel36);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 244);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selected POI";
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
            this.tableLayoutPanel36.Controls.Add(this.label38, 0, 1);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiAddress, 1, 0);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiXZ, 1, 1);
            this.tableLayoutPanel36.Controls.Add(this.label21, 0, 0);
            this.tableLayoutPanel36.Controls.Add(this.LblSelectedPoiGeometry, 1, 2);
            this.tableLayoutPanel36.Controls.Add(this.label35, 0, 2);
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
            this.tableLayoutPanel36.TabIndex = 73;
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
            this.LbxPoiAssociatedTriggers.TabIndex = 74;
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
            this.label33.TabIndex = 75;
            this.label33.Text = "Associated triggers:";
            // 
            // BtnGoToPoi
            // 
            this.BtnGoToPoi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnGoToPoi.AutoSize = true;
            this.BtnGoToPoi.Location = new System.Drawing.Point(240, 31);
            this.BtnGoToPoi.Name = "BtnGoToPoi";
            this.BtnGoToPoi.Size = new System.Drawing.Size(100, 22);
            this.BtnGoToPoi.TabIndex = 76;
            this.BtnGoToPoi.Text = "Go";
            this.BtnGoToPoi.UseVisualStyleBackColor = true;
            this.BtnGoToPoi.Click += new System.EventHandler(this.BtnGoToPoi_Click);
            // 
            // label38
            // 
            this.label38.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(52, 35);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 13);
            this.label38.TabIndex = 57;
            this.label38.Text = "XZ:";
            // 
            // LblSelectedPoiAddress
            // 
            this.LblSelectedPoiAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedPoiAddress.AutoSize = true;
            this.LblSelectedPoiAddress.Location = new System.Drawing.Point(82, 7);
            this.LblSelectedPoiAddress.Name = "LblSelectedPoiAddress";
            this.LblSelectedPoiAddress.Size = new System.Drawing.Size(56, 13);
            this.LblSelectedPoiAddress.TabIndex = 70;
            this.LblSelectedPoiAddress.Text = "<address>";
            this.LblSelectedPoiAddress.Click += new System.EventHandler(this.LblSelectedPoiAddress_Click);
            // 
            // LblSelectedPoiXZ
            // 
            this.LblSelectedPoiXZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedPoiXZ.AutoSize = true;
            this.tableLayoutPanel36.SetColumnSpan(this.LblSelectedPoiXZ, 2);
            this.LblSelectedPoiXZ.Location = new System.Drawing.Point(82, 35);
            this.LblSelectedPoiXZ.Name = "LblSelectedPoiXZ";
            this.LblSelectedPoiXZ.Size = new System.Drawing.Size(117, 13);
            this.LblSelectedPoiXZ.TabIndex = 58;
            this.LblSelectedPoiXZ.Text = "PLACEHOLDER TEXT";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 7);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(48, 13);
            this.label21.TabIndex = 69;
            this.label21.Text = "Address:";
            // 
            // LblSelectedPoiGeometry
            // 
            this.LblSelectedPoiGeometry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblSelectedPoiGeometry.AutoSize = true;
            this.LblSelectedPoiGeometry.Location = new System.Drawing.Point(82, 63);
            this.LblSelectedPoiGeometry.Name = "LblSelectedPoiGeometry";
            this.LblSelectedPoiGeometry.Size = new System.Drawing.Size(62, 13);
            this.LblSelectedPoiGeometry.TabIndex = 65;
            this.LblSelectedPoiGeometry.Text = "<geometry>";
            // 
            // label35
            // 
            this.label35.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(21, 63);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(55, 13);
            this.label35.TabIndex = 63;
            this.label35.Text = "Geometry:";
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
            this.tableLayoutPanel21.TabIndex = 75;
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
            this.splitContainer2.Panel1.Controls.Add(this.LbxCameraPaths);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox10);
            this.splitContainer2.Size = new System.Drawing.Size(676, 577);
            this.splitContainer2.SplitterDistance = 225;
            this.splitContainer2.TabIndex = 76;
            // 
            // LbxCameraPaths
            // 
            this.LbxCameraPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LbxCameraPaths.FormattingEnabled = true;
            this.LbxCameraPaths.IntegralHeight = false;
            this.LbxCameraPaths.Location = new System.Drawing.Point(0, 0);
            this.LbxCameraPaths.Name = "LbxCameraPaths";
            this.LbxCameraPaths.Size = new System.Drawing.Size(225, 577);
            this.LbxCameraPaths.TabIndex = 56;
            this.LbxCameraPaths.SelectedIndexChanged += new System.EventHandler(this.LbxCameraPaths_SelectedIndexChanged);
            this.LbxCameraPaths.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.LbxCameraPaths_Format);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tableLayoutPanel22);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(447, 577);
            this.groupBox10.TabIndex = 74;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Selected path";
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.AutoSize = true;
            this.tableLayoutPanel22.ColumnCount = 3;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel22.Controls.Add(this.label107, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathPitch, 1, 13);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathYaw, 1, 14);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathAddress, 1, 0);
            this.tableLayoutPanel22.Controls.Add(this.label82, 0, 14);
            this.tableLayoutPanel22.Controls.Add(this.label108, 0, 3);
            this.tableLayoutPanel22.Controls.Add(this.label77, 0, 13);
            this.tableLayoutPanel22.Controls.Add(this.label80, 0, 4);
            this.tableLayoutPanel22.Controls.Add(this.label83, 0, 11);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathThing6, 1, 11);
            this.tableLayoutPanel22.Controls.Add(this.label81, 0, 10);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathVolumeMin, 1, 3);
            this.tableLayoutPanel22.Controls.Add(this.BtnCameraPathGoToVolumeMin, 2, 3);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathThing5, 1, 10);
            this.tableLayoutPanel22.Controls.Add(this.BtnCameraPathGoToVolumeMax, 2, 4);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathVolumeMax, 1, 4);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathThing4, 1, 9);
            this.tableLayoutPanel22.Controls.Add(this.label104, 0, 6);
            this.tableLayoutPanel22.Controls.Add(this.label92, 0, 9);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathAreaMin, 1, 6);
            this.tableLayoutPanel22.Controls.Add(this.LblCameraPathAreaMax, 1, 7);
            this.tableLayoutPanel22.Controls.Add(this.label102, 0, 7);
            this.tableLayoutPanel22.Controls.Add(this.CbxSelectedCameraPathDisabled, 1, 1);
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
            this.tableLayoutPanel22.TabIndex = 120;
            // 
            // label107
            // 
            this.label107.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label107.AutoSize = true;
            this.label107.Location = new System.Drawing.Point(46, 12);
            this.label107.Name = "label107";
            this.label107.Size = new System.Drawing.Size(48, 13);
            this.label107.TabIndex = 69;
            this.label107.Text = "Address:";
            // 
            // LblCameraPathPitch
            // 
            this.LblCameraPathPitch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathPitch.AutoSize = true;
            this.LblCameraPathPitch.Location = new System.Drawing.Point(100, 493);
            this.LblCameraPathPitch.Name = "LblCameraPathPitch";
            this.LblCameraPathPitch.Size = new System.Drawing.Size(42, 13);
            this.LblCameraPathPitch.TabIndex = 117;
            this.LblCameraPathPitch.Text = "<pitch>";
            // 
            // LblCameraPathYaw
            // 
            this.LblCameraPathYaw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathYaw.AutoSize = true;
            this.LblCameraPathYaw.Location = new System.Drawing.Point(100, 531);
            this.LblCameraPathYaw.Name = "LblCameraPathYaw";
            this.LblCameraPathYaw.Size = new System.Drawing.Size(38, 13);
            this.LblCameraPathYaw.TabIndex = 118;
            this.LblCameraPathYaw.Text = "<yaw>";
            // 
            // LblCameraPathAddress
            // 
            this.LblCameraPathAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathAddress.AutoSize = true;
            this.LblCameraPathAddress.Location = new System.Drawing.Point(100, 12);
            this.LblCameraPathAddress.Name = "LblCameraPathAddress";
            this.LblCameraPathAddress.Size = new System.Drawing.Size(56, 13);
            this.LblCameraPathAddress.TabIndex = 70;
            this.LblCameraPathAddress.Text = "<address>";
            this.LblCameraPathAddress.Click += new System.EventHandler(this.LblCameraPathAddress_Click);
            // 
            // label82
            // 
            this.label82.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(63, 531);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(31, 13);
            this.label82.TabIndex = 116;
            this.label82.Text = "Yaw:";
            // 
            // label108
            // 
            this.label108.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(6, 123);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(88, 13);
            this.label108.TabIndex = 57;
            this.label108.Text = "Volume min XYZ:";
            // 
            // label77
            // 
            this.label77.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(60, 493);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(34, 13);
            this.label77.TabIndex = 115;
            this.label77.Text = "Pitch:";
            // 
            // label80
            // 
            this.label80.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label80.AutoSize = true;
            this.label80.Location = new System.Drawing.Point(3, 160);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(91, 13);
            this.label80.TabIndex = 108;
            this.label80.Text = "Volume max XYZ:";
            // 
            // label83
            // 
            this.label83.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(51, 419);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(43, 13);
            this.label83.TabIndex = 114;
            this.label83.Text = "Thing6:";
            // 
            // LblCameraPathThing6
            // 
            this.LblCameraPathThing6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathThing6.AutoSize = true;
            this.LblCameraPathThing6.Location = new System.Drawing.Point(100, 419);
            this.LblCameraPathThing6.Name = "LblCameraPathThing6";
            this.LblCameraPathThing6.Size = new System.Drawing.Size(48, 13);
            this.LblCameraPathThing6.TabIndex = 113;
            this.LblCameraPathThing6.Text = "<thing6>";
            // 
            // label81
            // 
            this.label81.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(51, 382);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(43, 13);
            this.label81.TabIndex = 112;
            this.label81.Text = "Thing5:";
            // 
            // LblCameraPathVolumeMin
            // 
            this.LblCameraPathVolumeMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathVolumeMin.AutoSize = true;
            this.LblCameraPathVolumeMin.Location = new System.Drawing.Point(100, 123);
            this.LblCameraPathVolumeMin.Name = "LblCameraPathVolumeMin";
            this.LblCameraPathVolumeMin.Size = new System.Drawing.Size(117, 13);
            this.LblCameraPathVolumeMin.TabIndex = 58;
            this.LblCameraPathVolumeMin.Text = "PLACEHOLDER TEXT";
            // 
            // BtnCameraPathGoToVolumeMin
            // 
            this.BtnCameraPathGoToVolumeMin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathGoToVolumeMin.AutoSize = true;
            this.BtnCameraPathGoToVolumeMin.Location = new System.Drawing.Point(338, 117);
            this.BtnCameraPathGoToVolumeMin.Name = "BtnCameraPathGoToVolumeMin";
            this.BtnCameraPathGoToVolumeMin.Size = new System.Drawing.Size(100, 25);
            this.BtnCameraPathGoToVolumeMin.TabIndex = 76;
            this.BtnCameraPathGoToVolumeMin.Text = "Go to min";
            this.BtnCameraPathGoToVolumeMin.UseVisualStyleBackColor = true;
            this.BtnCameraPathGoToVolumeMin.Click += new System.EventHandler(this.BtnCameraPathGoToVolumeMin_Click);
            // 
            // LblCameraPathThing5
            // 
            this.LblCameraPathThing5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathThing5.AutoSize = true;
            this.LblCameraPathThing5.Location = new System.Drawing.Point(100, 382);
            this.LblCameraPathThing5.Name = "LblCameraPathThing5";
            this.LblCameraPathThing5.Size = new System.Drawing.Size(48, 13);
            this.LblCameraPathThing5.TabIndex = 111;
            this.LblCameraPathThing5.Text = "<thing5>";
            // 
            // BtnCameraPathGoToVolumeMax
            // 
            this.BtnCameraPathGoToVolumeMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathGoToVolumeMax.AutoSize = true;
            this.BtnCameraPathGoToVolumeMax.Location = new System.Drawing.Point(338, 154);
            this.BtnCameraPathGoToVolumeMax.Name = "BtnCameraPathGoToVolumeMax";
            this.BtnCameraPathGoToVolumeMax.Size = new System.Drawing.Size(100, 25);
            this.BtnCameraPathGoToVolumeMax.TabIndex = 110;
            this.BtnCameraPathGoToVolumeMax.Text = "Go to max";
            this.BtnCameraPathGoToVolumeMax.UseVisualStyleBackColor = true;
            this.BtnCameraPathGoToVolumeMax.Click += new System.EventHandler(this.BtnCameraPathGoToVolumeMax_Click);
            // 
            // LblCameraPathVolumeMax
            // 
            this.LblCameraPathVolumeMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathVolumeMax.AutoSize = true;
            this.LblCameraPathVolumeMax.Location = new System.Drawing.Point(100, 160);
            this.LblCameraPathVolumeMax.Name = "LblCameraPathVolumeMax";
            this.LblCameraPathVolumeMax.Size = new System.Drawing.Size(117, 13);
            this.LblCameraPathVolumeMax.TabIndex = 109;
            this.LblCameraPathVolumeMax.Text = "PLACEHOLDER TEXT";
            // 
            // LblCameraPathThing4
            // 
            this.LblCameraPathThing4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathThing4.AutoSize = true;
            this.LblCameraPathThing4.Location = new System.Drawing.Point(100, 345);
            this.LblCameraPathThing4.Name = "LblCameraPathThing4";
            this.LblCameraPathThing4.Size = new System.Drawing.Size(48, 13);
            this.LblCameraPathThing4.TabIndex = 104;
            this.LblCameraPathThing4.Text = "<thing4>";
            // 
            // label104
            // 
            this.label104.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label104.AutoSize = true;
            this.label104.Location = new System.Drawing.Point(26, 234);
            this.label104.Name = "label104";
            this.label104.Size = new System.Drawing.Size(68, 13);
            this.label104.TabIndex = 97;
            this.label104.Text = "Area min XZ:";
            // 
            // label92
            // 
            this.label92.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(51, 345);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(43, 13);
            this.label92.TabIndex = 105;
            this.label92.Text = "Thing4:";
            // 
            // LblCameraPathAreaMin
            // 
            this.LblCameraPathAreaMin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathAreaMin.AutoSize = true;
            this.LblCameraPathAreaMin.Location = new System.Drawing.Point(100, 234);
            this.LblCameraPathAreaMin.Name = "LblCameraPathAreaMin";
            this.LblCameraPathAreaMin.Size = new System.Drawing.Size(117, 13);
            this.LblCameraPathAreaMin.TabIndex = 96;
            this.LblCameraPathAreaMin.Text = "PLACEHOLDER TEXT";
            // 
            // LblCameraPathAreaMax
            // 
            this.LblCameraPathAreaMax.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathAreaMax.AutoSize = true;
            this.LblCameraPathAreaMax.Location = new System.Drawing.Point(100, 271);
            this.LblCameraPathAreaMax.Name = "LblCameraPathAreaMax";
            this.LblCameraPathAreaMax.Size = new System.Drawing.Size(117, 13);
            this.LblCameraPathAreaMax.TabIndex = 98;
            this.LblCameraPathAreaMax.Text = "PLACEHOLDER TEXT";
            // 
            // label102
            // 
            this.label102.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label102.AutoSize = true;
            this.label102.Location = new System.Drawing.Point(23, 271);
            this.label102.Name = "label102";
            this.label102.Size = new System.Drawing.Size(71, 13);
            this.label102.TabIndex = 99;
            this.label102.Text = "Area max XZ:";
            // 
            // CbxSelectedCameraPathDisabled
            // 
            this.CbxSelectedCameraPathDisabled.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.CbxSelectedCameraPathDisabled.AutoSize = true;
            this.CbxSelectedCameraPathDisabled.Location = new System.Drawing.Point(100, 47);
            this.CbxSelectedCameraPathDisabled.Name = "CbxSelectedCameraPathDisabled";
            this.CbxSelectedCameraPathDisabled.Size = new System.Drawing.Size(67, 17);
            this.CbxSelectedCameraPathDisabled.TabIndex = 119;
            this.CbxSelectedCameraPathDisabled.Text = "Disabled";
            this.CbxSelectedCameraPathDisabled.UseVisualStyleBackColor = true;
            this.CbxSelectedCameraPathDisabled.CheckedChanged += new System.EventHandler(this.CbxSelectedCameraPathEnabled_CheckedChanged);
            // 
            // LblCameraPathCount
            // 
            this.LblCameraPathCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblCameraPathCount.AutoSize = true;
            this.LblCameraPathCount.Location = new System.Drawing.Point(153, 8);
            this.LblCameraPathCount.Name = "LblCameraPathCount";
            this.LblCameraPathCount.Size = new System.Drawing.Size(10, 13);
            this.LblCameraPathCount.TabIndex = 58;
            this.LblCameraPathCount.Text = "-";
            // 
            // BtnCameraPathReadArray
            // 
            this.BtnCameraPathReadArray.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnCameraPathReadArray.AutoSize = true;
            this.BtnCameraPathReadArray.Location = new System.Drawing.Point(3, 3);
            this.BtnCameraPathReadArray.Name = "BtnCameraPathReadArray";
            this.BtnCameraPathReadArray.Size = new System.Drawing.Size(144, 23);
            this.BtnCameraPathReadArray.TabIndex = 57;
            this.BtnCameraPathReadArray.Text = "Read camera paths";
            this.BtnCameraPathReadArray.UseVisualStyleBackColor = true;
            this.BtnCameraPathReadArray.Click += new System.EventHandler(this.BtnCameraPathReadArray_Click);
            // 
            // TbpStats
            // 
            this.TbpStats.Controls.Add(this.tableLayoutPanel3);
            this.TbpStats.Controls.Add(this.CbxStats);
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
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Harry health:";
            // 
            // label52
            // 
            this.label52.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(40, 67);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(56, 13);
            this.label52.TabIndex = 22;
            this.label52.Text = "Total time:";
            // 
            // LblRunningDistance
            // 
            this.LblRunningDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblRunningDistance.AutoSize = true;
            this.LblRunningDistance.Location = new System.Drawing.Point(102, 111);
            this.LblRunningDistance.Name = "LblRunningDistance";
            this.LblRunningDistance.Size = new System.Drawing.Size(34, 13);
            this.LblRunningDistance.TabIndex = 3;
            this.LblRunningDistance.Text = "<run>";
            // 
            // LblTotalTime
            // 
            this.LblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTotalTime.AutoSize = true;
            this.LblTotalTime.Location = new System.Drawing.Point(102, 67);
            this.LblTotalTime.Name = "LblTotalTime";
            this.LblTotalTime.Size = new System.Drawing.Size(62, 13);
            this.LblTotalTime.TabIndex = 23;
            this.LblTotalTime.Text = "<totalTime>";
            // 
            // LblWalkingDistance
            // 
            this.LblWalkingDistance.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblWalkingDistance.AutoSize = true;
            this.LblWalkingDistance.Location = new System.Drawing.Point(102, 88);
            this.LblWalkingDistance.Name = "LblWalkingDistance";
            this.LblWalkingDistance.Size = new System.Drawing.Size(53, 13);
            this.LblWalkingDistance.TabIndex = 2;
            this.LblWalkingDistance.Text = "<walked>";
            // 
            // LblHarryHealth
            // 
            this.LblHarryHealth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblHarryHealth.AutoSize = true;
            this.LblHarryHealth.Location = new System.Drawing.Point(102, 4);
            this.LblHarryHealth.Name = "LblHarryHealth";
            this.LblHarryHealth.Size = new System.Drawing.Size(74, 13);
            this.LblHarryHealth.TabIndex = 20;
            this.LblHarryHealth.Text = "<harry health>";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 111);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Running distance:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Walking distance:";
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
            this.tableLayoutPanel14.TabIndex = 24;
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
            this.tableLayoutPanel13.Controls.Add(this.NudWorldTintR, 1, 1);
            this.tableLayoutPanel13.Controls.Add(this.NudWorldTintG, 1, 2);
            this.tableLayoutPanel13.Controls.Add(this.BtnWorldTintColor, 2, 1);
            this.tableLayoutPanel13.Controls.Add(this.NudWorldTintB, 1, 3);
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
            this.tableLayoutPanel13.TabIndex = 23;
            // 
            // CbxCustomWorldTint
            // 
            this.CbxCustomWorldTint.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxCustomWorldTint.AutoSize = true;
            this.tableLayoutPanel13.SetColumnSpan(this.CbxCustomWorldTint, 3);
            this.CbxCustomWorldTint.Location = new System.Drawing.Point(12, 3);
            this.CbxCustomWorldTint.Name = "CbxCustomWorldTint";
            this.CbxCustomWorldTint.Size = new System.Drawing.Size(106, 17);
            this.CbxCustomWorldTint.TabIndex = 16;
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
            this.label12.TabIndex = 10;
            this.label12.Text = "R:";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "G:";
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 81);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 13);
            this.label10.TabIndex = 12;
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
            this.BtnWorldTintDefault.TabIndex = 18;
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
            this.BtnCustomWorldTintCurrent.TabIndex = 20;
            this.BtnCustomWorldTintCurrent.Text = "Current";
            this.BtnCustomWorldTintCurrent.UseVisualStyleBackColor = true;
            this.BtnCustomWorldTintCurrent.Click += new System.EventHandler(this.BtnCustomWorldTintCurrent_Click);
            // 
            // NudWorldTintR
            // 
            this.NudWorldTintR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudWorldTintR.Location = new System.Drawing.Point(27, 26);
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
            // NudWorldTintG
            // 
            this.NudWorldTintG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudWorldTintG.Location = new System.Drawing.Point(27, 52);
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
            // BtnWorldTintColor
            // 
            this.BtnWorldTintColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(128)))), ((int)(((byte)(138)))));
            this.BtnWorldTintColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnWorldTintColor.Location = new System.Drawing.Point(85, 26);
            this.BtnWorldTintColor.Name = "BtnWorldTintColor";
            this.tableLayoutPanel13.SetRowSpan(this.BtnWorldTintColor, 3);
            this.BtnWorldTintColor.Size = new System.Drawing.Size(43, 72);
            this.BtnWorldTintColor.TabIndex = 9;
            this.BtnWorldTintColor.UseVisualStyleBackColor = false;
            this.BtnWorldTintColor.Click += new System.EventHandler(this.BtnWorldTintColor_Click);
            // 
            // NudWorldTintB
            // 
            this.NudWorldTintB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudWorldTintB.Location = new System.Drawing.Point(27, 78);
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
            this.tableLayoutPanel12.Controls.Add(this.NudFogR, 1, 1);
            this.tableLayoutPanel12.Controls.Add(this.NudFogG, 1, 2);
            this.tableLayoutPanel12.Controls.Add(this.NudFogB, 1, 3);
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
            this.tableLayoutPanel12.TabIndex = 22;
            // 
            // CbxCustomFog
            // 
            this.CbxCustomFog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxCustomFog.AutoSize = true;
            this.tableLayoutPanel12.SetColumnSpan(this.CbxCustomFog, 3);
            this.CbxCustomFog.Location = new System.Drawing.Point(26, 3);
            this.CbxCustomFog.Name = "CbxCustomFog";
            this.CbxCustomFog.Size = new System.Drawing.Size(79, 17);
            this.CbxCustomFog.TabIndex = 8;
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
            this.label5.TabIndex = 2;
            this.label5.Text = "R:";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "G:";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 13);
            this.label9.TabIndex = 4;
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
            this.BtnCustomFogCurrent.TabIndex = 19;
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
            this.BtnFogColorDefault.TabIndex = 17;
            this.BtnFogColorDefault.Text = "Default";
            this.BtnFogColorDefault.UseVisualStyleBackColor = true;
            this.BtnFogColorDefault.Click += new System.EventHandler(this.BtnFogColorDefault_Click);
            // 
            // NudFogR
            // 
            this.NudFogR.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFogR.Location = new System.Drawing.Point(27, 26);
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
            // NudFogG
            // 
            this.NudFogG.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFogG.Location = new System.Drawing.Point(27, 52);
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
            // NudFogB
            // 
            this.NudFogB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudFogB.Location = new System.Drawing.Point(27, 78);
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
            // BtnFogColor
            // 
            this.BtnFogColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(100)))), ((int)(((byte)(116)))));
            this.BtnFogColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnFogColor.Location = new System.Drawing.Point(85, 26);
            this.BtnFogColor.Name = "BtnFogColor";
            this.tableLayoutPanel12.SetRowSpan(this.BtnFogColor, 3);
            this.BtnFogColor.Size = new System.Drawing.Size(43, 72);
            this.BtnFogColor.TabIndex = 1;
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
            this.BtnFogWorldTintColorSwap.TabIndex = 0;
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
            this.CbxDiscoMode.TabIndex = 21;
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
            this.tableLayoutPanel10.TabIndex = 57;
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
            this.RtbStrings.TabIndex = 56;
            this.RtbStrings.Text = "";
            // 
            // LblStringCount
            // 
            this.LblStringCount.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblStringCount.AutoSize = true;
            this.LblStringCount.Location = new System.Drawing.Point(134, 9);
            this.LblStringCount.Name = "LblStringCount";
            this.LblStringCount.Size = new System.Drawing.Size(10, 13);
            this.LblStringCount.TabIndex = 55;
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
            this.groupBox3.TabIndex = 21;
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
            this.PnlSaveRamDangerArea.TabIndex = 10;
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
            this.tableLayoutPanel18.TabIndex = 9;
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
            this.BtnSaveRamImportBrowse.TabIndex = 5;
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
            this.TbxSaveRamImportPath.TabIndex = 4;
            // 
            // BtnSaveRamImport
            // 
            this.BtnSaveRamImport.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamImport.AutoSize = true;
            this.BtnSaveRamImport.Enabled = false;
            this.BtnSaveRamImport.Location = new System.Drawing.Point(3, 32);
            this.BtnSaveRamImport.Name = "BtnSaveRamImport";
            this.BtnSaveRamImport.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamImport.TabIndex = 3;
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
            this.GbxConvertStatesOrSaveRam.TabIndex = 6;
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
            this.label58.TabIndex = 30;
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
            this.LbxConvertStatesToSaveRam.TabIndex = 25;
            // 
            // BtnConvertStatesToSaveRamGo
            // 
            this.BtnConvertStatesToSaveRamGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamGo.AutoSize = true;
            this.BtnConvertStatesToSaveRamGo.Location = new System.Drawing.Point(512, 280);
            this.BtnConvertStatesToSaveRamGo.Name = "BtnConvertStatesToSaveRamGo";
            this.BtnConvertStatesToSaveRamGo.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamGo.TabIndex = 26;
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
            this.TbxConvertStatesToSaveRamInputPath.TabIndex = 28;
            this.TbxConvertStatesToSaveRamInputPath.TextChanged += new System.EventHandler(this.TbxConvertStatesToSaveRamInputPath_TextChanged);
            // 
            // BtnConvertStatesToSaveRamInputPathBrowse
            // 
            this.BtnConvertStatesToSaveRamInputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamInputPathBrowse.AutoSize = true;
            this.BtnConvertStatesToSaveRamInputPathBrowse.Location = new System.Drawing.Point(431, 3);
            this.BtnConvertStatesToSaveRamInputPathBrowse.Name = "BtnConvertStatesToSaveRamInputPathBrowse";
            this.BtnConvertStatesToSaveRamInputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamInputPathBrowse.TabIndex = 29;
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
            this.BtnConvertStatesToSaveRamOutputPathBrowse.TabIndex = 23;
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
            this.label55.TabIndex = 24;
            this.label55.Text = "SaveRAM output directory:";
            // 
            // TbxConvertStatesToSaveRamOutputPath
            // 
            this.TbxConvertStatesToSaveRamOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertStatesToSaveRamOutputPath.Location = new System.Drawing.Point(144, 282);
            this.TbxConvertStatesToSaveRamOutputPath.Name = "TbxConvertStatesToSaveRamOutputPath";
            this.TbxConvertStatesToSaveRamOutputPath.Size = new System.Drawing.Size(281, 20);
            this.TbxConvertStatesToSaveRamOutputPath.TabIndex = 22;
            // 
            // BtnConvertStatesToSaveRamRefresh
            // 
            this.BtnConvertStatesToSaveRamRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertStatesToSaveRamRefresh.AutoSize = true;
            this.BtnConvertStatesToSaveRamRefresh.Location = new System.Drawing.Point(512, 3);
            this.BtnConvertStatesToSaveRamRefresh.Name = "BtnConvertStatesToSaveRamRefresh";
            this.BtnConvertStatesToSaveRamRefresh.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertStatesToSaveRamRefresh.TabIndex = 27;
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
            this.BtnConvertSaveRamToStatesOutputPathBrowse.TabIndex = 30;
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
            this.label57.TabIndex = 31;
            this.label57.Text = "Save state output directory:";
            // 
            // BtnConvertSaveRamToStatesGo
            // 
            this.BtnConvertSaveRamToStatesGo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesGo.AutoSize = true;
            this.BtnConvertSaveRamToStatesGo.Location = new System.Drawing.Point(512, 280);
            this.BtnConvertSaveRamToStatesGo.Name = "BtnConvertSaveRamToStatesGo";
            this.BtnConvertSaveRamToStatesGo.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesGo.TabIndex = 24;
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
            this.label56.TabIndex = 27;
            this.label56.Text = "SaveRAM input directory:";
            // 
            // TbxConvertSaveRamToStatesOutputPath
            // 
            this.TbxConvertSaveRamToStatesOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesOutputPath.Location = new System.Drawing.Point(146, 282);
            this.TbxConvertSaveRamToStatesOutputPath.Name = "TbxConvertSaveRamToStatesOutputPath";
            this.TbxConvertSaveRamToStatesOutputPath.Size = new System.Drawing.Size(279, 20);
            this.TbxConvertSaveRamToStatesOutputPath.TabIndex = 29;
            // 
            // TbxConvertSaveRamToStatesInputPath
            // 
            this.TbxConvertSaveRamToStatesInputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TbxConvertSaveRamToStatesInputPath.Location = new System.Drawing.Point(146, 5);
            this.TbxConvertSaveRamToStatesInputPath.Name = "TbxConvertSaveRamToStatesInputPath";
            this.TbxConvertSaveRamToStatesInputPath.Size = new System.Drawing.Size(279, 20);
            this.TbxConvertSaveRamToStatesInputPath.TabIndex = 25;
            this.TbxConvertSaveRamToStatesInputPath.TextChanged += new System.EventHandler(this.TbxConvertSaveRamToStatesInputPath_TextChanged);
            // 
            // BtnConvertSaveRamToStatesInputPathBrowse
            // 
            this.BtnConvertSaveRamToStatesInputPathBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnConvertSaveRamToStatesInputPathBrowse.AutoSize = true;
            this.BtnConvertSaveRamToStatesInputPathBrowse.Location = new System.Drawing.Point(431, 3);
            this.BtnConvertSaveRamToStatesInputPathBrowse.Name = "BtnConvertSaveRamToStatesInputPathBrowse";
            this.BtnConvertSaveRamToStatesInputPathBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnConvertSaveRamToStatesInputPathBrowse.TabIndex = 26;
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
            this.BtnConvertSaveRamToStatesRefresh.TabIndex = 28;
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
            this.LbxConvertSaveRamToStates.TabIndex = 23;
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
            this.TbxSaveRamExportPath.TabIndex = 1;
            // 
            // BtnSaveRamExportBrowse
            // 
            this.BtnSaveRamExportBrowse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnSaveRamExportBrowse.AutoSize = true;
            this.BtnSaveRamExportBrowse.Location = new System.Drawing.Point(592, 3);
            this.BtnSaveRamExportBrowse.Name = "BtnSaveRamExportBrowse";
            this.BtnSaveRamExportBrowse.Size = new System.Drawing.Size(75, 25);
            this.BtnSaveRamExportBrowse.TabIndex = 2;
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
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "In-game saves";
            // 
            // BtnOpenSaveMenu
            // 
            this.BtnOpenSaveMenu.AutoSize = true;
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
            this.groupBox6.TabIndex = 37;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Model";
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel9, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.TrkModelScale, 0, 1);
            this.tableLayoutPanel20.Controls.Add(this.tableLayoutPanel8, 0, 2);
            this.tableLayoutPanel20.Controls.Add(this.LblModelScale, 1, 1);
            this.tableLayoutPanel20.Controls.Add(this.CbxEnableModelDisplay, 1, 2);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 3;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel20.Size = new System.Drawing.Size(669, 177);
            this.tableLayoutPanel20.TabIndex = 50;
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
            this.tableLayoutPanel9.TabIndex = 49;
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
            this.CmbModelSubmeshName.TabIndex = 46;
            this.CmbModelSubmeshName.Text = "HEAD1";
            // 
            // BtnReadHarryModel
            // 
            this.BtnReadHarryModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnReadHarryModel.AutoSize = true;
            this.BtnReadHarryModel.Location = new System.Drawing.Point(3, 3);
            this.BtnReadHarryModel.Name = "BtnReadHarryModel";
            this.BtnReadHarryModel.Size = new System.Drawing.Size(125, 25);
            this.BtnReadHarryModel.TabIndex = 43;
            this.BtnReadHarryModel.Text = "Read Harry submesh";
            this.BtnReadHarryModel.UseVisualStyleBackColor = true;
            this.BtnReadHarryModel.Click += new System.EventHandler(this.BtnReadHarryModel_Click);
            // 
            // TrkModelScale
            // 
            this.TrkModelScale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TrkModelScale.Location = new System.Drawing.Point(3, 59);
            this.TrkModelScale.Maximum = 2000;
            this.TrkModelScale.Minimum = 1;
            this.TrkModelScale.Name = "TrkModelScale";
            this.TrkModelScale.Size = new System.Drawing.Size(430, 45);
            this.TrkModelScale.TabIndex = 44;
            this.toolTip1.SetToolTip(this.TrkModelScale, "Arbitrary model scale factor");
            this.TrkModelScale.Value = 1000;
            this.TrkModelScale.Scroll += new System.EventHandler(this.TrkModelScale_Scroll);
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
            this.tableLayoutPanel8.Controls.Add(this.NudModelX, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.NudModelY, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.NudModelZ, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.LblModelX, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.LblModelY, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.LblModelZ, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.BtnModelSetPosition, 4, 1);
            this.tableLayoutPanel8.Controls.Add(this.BtnModelGetPosition, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 130);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(430, 44);
            this.tableLayoutPanel8.TabIndex = 48;
            // 
            // NudModelX
            // 
            this.NudModelX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudModelX.Location = new System.Drawing.Point(134, 18);
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
            this.NudModelX.TabIndex = 40;
            this.NudModelX.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudModelX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudModelX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudModelX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudModel_KeyDown);
            // 
            // NudModelY
            // 
            this.NudModelY.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudModelY.Location = new System.Drawing.Point(190, 18);
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
            this.NudModelY.TabIndex = 41;
            this.NudModelY.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudModelY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudModelY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudModelY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudModel_KeyDown);
            // 
            // NudModelZ
            // 
            this.NudModelZ.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.NudModelZ.Location = new System.Drawing.Point(246, 18);
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
            this.NudModelZ.TabIndex = 42;
            this.NudModelZ.ValueChanged += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            this.NudModelZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudModelZ.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudModelZ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudModel_KeyDown);
            // 
            // LblModelX
            // 
            this.LblModelX.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelX.AutoSize = true;
            this.LblModelX.Location = new System.Drawing.Point(147, 0);
            this.LblModelX.Name = "LblModelX";
            this.LblModelX.Size = new System.Drawing.Size(24, 13);
            this.LblModelX.TabIndex = 37;
            this.LblModelX.Text = "<x>";
            // 
            // LblModelY
            // 
            this.LblModelY.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelY.AutoSize = true;
            this.LblModelY.Location = new System.Drawing.Point(203, 0);
            this.LblModelY.Name = "LblModelY";
            this.LblModelY.Size = new System.Drawing.Size(24, 13);
            this.LblModelY.TabIndex = 38;
            this.LblModelY.Text = "<y>";
            // 
            // LblModelZ
            // 
            this.LblModelZ.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.LblModelZ.AutoSize = true;
            this.LblModelZ.Location = new System.Drawing.Point(259, 0);
            this.LblModelZ.Name = "LblModelZ";
            this.LblModelZ.Size = new System.Drawing.Size(24, 13);
            this.LblModelZ.TabIndex = 39;
            this.LblModelZ.Text = "<z>";
            // 
            // BtnModelSetPosition
            // 
            this.BtnModelSetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnModelSetPosition.AutoSize = true;
            this.BtnModelSetPosition.Location = new System.Drawing.Point(302, 16);
            this.BtnModelSetPosition.Name = "BtnModelSetPosition";
            this.BtnModelSetPosition.Size = new System.Drawing.Size(125, 25);
            this.BtnModelSetPosition.TabIndex = 36;
            this.BtnModelSetPosition.Text = "Set model position";
            this.BtnModelSetPosition.UseVisualStyleBackColor = true;
            this.BtnModelSetPosition.Click += new System.EventHandler(this.BtnModelSetModelPosition_Click);
            // 
            // BtnModelGetPosition
            // 
            this.BtnModelGetPosition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnModelGetPosition.AutoSize = true;
            this.BtnModelGetPosition.Location = new System.Drawing.Point(3, 16);
            this.BtnModelGetPosition.Name = "BtnModelGetPosition";
            this.BtnModelGetPosition.Size = new System.Drawing.Size(125, 25);
            this.BtnModelGetPosition.TabIndex = 35;
            this.BtnModelGetPosition.Text = "Get Harry position";
            this.BtnModelGetPosition.UseVisualStyleBackColor = true;
            this.BtnModelGetPosition.Click += new System.EventHandler(this.BtnModelGetHarryPosition_Click);
            // 
            // LblModelScale
            // 
            this.LblModelScale.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblModelScale.Location = new System.Drawing.Point(439, 74);
            this.LblModelScale.Name = "LblModelScale";
            this.LblModelScale.Size = new System.Drawing.Size(45, 15);
            this.LblModelScale.TabIndex = 45;
            this.LblModelScale.Text = "1000";
            this.toolTip1.SetToolTip(this.LblModelScale, "Arbitrary model scale factor");
            // 
            // CbxEnableModelDisplay
            // 
            this.CbxEnableModelDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableModelDisplay.AutoSize = true;
            this.CbxEnableModelDisplay.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableModelDisplay.Location = new System.Drawing.Point(607, 157);
            this.CbxEnableModelDisplay.Name = "CbxEnableModelDisplay";
            this.CbxEnableModelDisplay.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableModelDisplay.TabIndex = 50;
            this.CbxEnableModelDisplay.Text = "Enable";
            this.CbxEnableModelDisplay.UseVisualStyleBackColor = true;
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
            this.groupBox5.TabIndex = 36;
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
            this.tableLayoutPanel7.TabIndex = 121;
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
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxSizeX, 3, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxSizeY, 3, 2);
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxSizeZ, 3, 3);
            this.tableLayoutPanel4.Controls.Add(this.CbxOverlayTestBox, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label53, 2, 2);
            this.tableLayoutPanel4.Controls.Add(this.label37, 2, 3);
            this.tableLayoutPanel4.Controls.Add(this.label54, 2, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxX, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxY, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.NudOverlayTestBoxZ, 1, 3);
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
            this.tableLayoutPanel4.TabIndex = 118;
            // 
            // NudOverlayTestBoxSizeX
            // 
            this.NudOverlayTestBoxSizeX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxSizeX.Location = new System.Drawing.Point(132, 29);
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
            this.NudOverlayTestBoxSizeX.TabIndex = 99;
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
            // NudOverlayTestBoxSizeY
            // 
            this.NudOverlayTestBoxSizeY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxSizeY.Location = new System.Drawing.Point(132, 55);
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
            this.NudOverlayTestBoxSizeY.TabIndex = 100;
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
            // NudOverlayTestBoxSizeZ
            // 
            this.NudOverlayTestBoxSizeZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxSizeZ.Location = new System.Drawing.Point(132, 81);
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
            this.NudOverlayTestBoxSizeZ.TabIndex = 101;
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
            // CbxOverlayTestBox
            // 
            this.CbxOverlayTestBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxOverlayTestBox.AutoSize = true;
            this.tableLayoutPanel4.SetColumnSpan(this.CbxOverlayTestBox, 4);
            this.CbxOverlayTestBox.Location = new System.Drawing.Point(61, 4);
            this.CbxOverlayTestBox.Name = "CbxOverlayTestBox";
            this.CbxOverlayTestBox.Size = new System.Drawing.Size(67, 17);
            this.CbxOverlayTestBox.TabIndex = 79;
            this.CbxOverlayTestBox.Text = "Test box";
            this.CbxOverlayTestBox.UseVisualStyleBackColor = true;
            // 
            // label53
            // 
            this.label53.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(86, 58);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(40, 13);
            this.label53.TabIndex = 103;
            this.label53.Text = "Size Y:";
            // 
            // label37
            // 
            this.label37.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(86, 84);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 13);
            this.label37.TabIndex = 104;
            this.label37.Text = "Size Z:";
            // 
            // label54
            // 
            this.label54.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(86, 32);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(40, 13);
            this.label54.TabIndex = 102;
            this.label54.Text = "Size X:";
            // 
            // NudOverlayTestBoxX
            // 
            this.NudOverlayTestBoxX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxX.Location = new System.Drawing.Point(26, 29);
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
            this.NudOverlayTestBoxX.TabIndex = 80;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxX.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxX_ValueChanged);
            this.NudOverlayTestBoxX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxY
            // 
            this.NudOverlayTestBoxY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxY.Location = new System.Drawing.Point(26, 55);
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
            this.NudOverlayTestBoxY.TabIndex = 81;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxY.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxY_ValueChanged);
            this.NudOverlayTestBoxY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxY.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestBoxZ
            // 
            this.NudOverlayTestBoxZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestBoxZ.Location = new System.Drawing.Point(26, 81);
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
            this.NudOverlayTestBoxZ.TabIndex = 82;
            this.toolTip1.SetToolTip(this.NudOverlayTestBoxZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestBoxZ.ValueChanged += new System.EventHandler(this.NudOverlayTestBoxZ_ValueChanged);
            this.NudOverlayTestBoxZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestBoxZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label30
            // 
            this.label30.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(3, 32);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 13);
            this.label30.TabIndex = 83;
            this.label30.Text = "X:";
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(3, 58);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 13);
            this.label29.TabIndex = 84;
            this.label29.Text = "Y:";
            // 
            // label28
            // 
            this.label28.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(3, 84);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 13);
            this.label28.TabIndex = 85;
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
            this.tableLayoutPanel6.Controls.Add(this.CbxOverlayTestSheet, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.NudOverlayTestSheetX, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.NudOverlayTestSheetSizeX, 3, 1);
            this.tableLayoutPanel6.Controls.Add(this.label86, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.label85, 2, 1);
            this.tableLayoutPanel6.Controls.Add(this.label87, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.label79, 2, 3);
            this.tableLayoutPanel6.Controls.Add(this.label88, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.NudOverlayTestSheetSizeZ, 3, 3);
            this.tableLayoutPanel6.Controls.Add(this.NudOverlayTestSheetZ, 1, 3);
            this.tableLayoutPanel6.Controls.Add(this.NudOverlayTestSheetY, 1, 2);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(478, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 4;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(189, 104);
            this.tableLayoutPanel6.TabIndex = 120;
            // 
            // CbxOverlayTestSheet
            // 
            this.CbxOverlayTestSheet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxOverlayTestSheet.AutoSize = true;
            this.tableLayoutPanel6.SetColumnSpan(this.CbxOverlayTestSheet, 4);
            this.CbxOverlayTestSheet.Location = new System.Drawing.Point(56, 4);
            this.CbxOverlayTestSheet.Name = "CbxOverlayTestSheet";
            this.CbxOverlayTestSheet.Size = new System.Drawing.Size(76, 17);
            this.CbxOverlayTestSheet.TabIndex = 105;
            this.CbxOverlayTestSheet.Text = "Test sheet";
            this.CbxOverlayTestSheet.UseVisualStyleBackColor = true;
            // 
            // NudOverlayTestSheetX
            // 
            this.NudOverlayTestSheetX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestSheetX.Location = new System.Drawing.Point(26, 29);
            this.NudOverlayTestSheetX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestSheetX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestSheetX.Name = "NudOverlayTestSheetX";
            this.NudOverlayTestSheetX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestSheetX.TabIndex = 106;
            this.toolTip1.SetToolTip(this.NudOverlayTestSheetX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestSheetX.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetX_ValueChanged);
            this.NudOverlayTestSheetX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestSheetX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestSheetSizeX
            // 
            this.NudOverlayTestSheetSizeX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestSheetSizeX.Location = new System.Drawing.Point(132, 29);
            this.NudOverlayTestSheetSizeX.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestSheetSizeX.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestSheetSizeX.Name = "NudOverlayTestSheetSizeX";
            this.NudOverlayTestSheetSizeX.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestSheetSizeX.TabIndex = 112;
            this.toolTip1.SetToolTip(this.NudOverlayTestSheetSizeX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestSheetSizeX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestSheetSizeX.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetSizeX_ValueChanged);
            this.NudOverlayTestSheetSizeX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestSheetSizeX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label86
            // 
            this.label86.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(3, 84);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(17, 13);
            this.label86.TabIndex = 111;
            this.label86.Text = "Z:";
            // 
            // label85
            // 
            this.label85.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(86, 32);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(40, 13);
            this.label85.TabIndex = 115;
            this.label85.Text = "Size X:";
            // 
            // label87
            // 
            this.label87.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(3, 58);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(17, 13);
            this.label87.TabIndex = 110;
            this.label87.Text = "Y:";
            // 
            // label79
            // 
            this.label79.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(86, 84);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(40, 13);
            this.label79.TabIndex = 117;
            this.label79.Text = "Size Z:";
            // 
            // label88
            // 
            this.label88.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label88.AutoSize = true;
            this.label88.Location = new System.Drawing.Point(3, 32);
            this.label88.Name = "label88";
            this.label88.Size = new System.Drawing.Size(17, 13);
            this.label88.TabIndex = 109;
            this.label88.Text = "X:";
            // 
            // NudOverlayTestSheetSizeZ
            // 
            this.NudOverlayTestSheetSizeZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestSheetSizeZ.Location = new System.Drawing.Point(132, 81);
            this.NudOverlayTestSheetSizeZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestSheetSizeZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestSheetSizeZ.Name = "NudOverlayTestSheetSizeZ";
            this.NudOverlayTestSheetSizeZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestSheetSizeZ.TabIndex = 114;
            this.toolTip1.SetToolTip(this.NudOverlayTestSheetSizeZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestSheetSizeZ.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudOverlayTestSheetSizeZ.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetSizeZ_ValueChanged);
            this.NudOverlayTestSheetSizeZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestSheetSizeZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestSheetZ
            // 
            this.NudOverlayTestSheetZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestSheetZ.Location = new System.Drawing.Point(26, 81);
            this.NudOverlayTestSheetZ.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestSheetZ.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestSheetZ.Name = "NudOverlayTestSheetZ";
            this.NudOverlayTestSheetZ.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestSheetZ.TabIndex = 108;
            this.toolTip1.SetToolTip(this.NudOverlayTestSheetZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestSheetZ.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetZ_ValueChanged);
            this.NudOverlayTestSheetZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestSheetZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestSheetY
            // 
            this.NudOverlayTestSheetY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestSheetY.Location = new System.Drawing.Point(26, 55);
            this.NudOverlayTestSheetY.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.NudOverlayTestSheetY.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            -2147483648});
            this.NudOverlayTestSheetY.Name = "NudOverlayTestSheetY";
            this.NudOverlayTestSheetY.Size = new System.Drawing.Size(54, 20);
            this.NudOverlayTestSheetY.TabIndex = 107;
            this.toolTip1.SetToolTip(this.NudOverlayTestSheetY, "The test box\'s position in SH coordinates");
            this.NudOverlayTestSheetY.ValueChanged += new System.EventHandler(this.NudOverlayTestSheetY_ValueChanged);
            this.NudOverlayTestSheetY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestSheetY.Enter += new System.EventHandler(this.Selectable_Enter);
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
            this.tableLayoutPanel5.Controls.Add(this.CbxOverlayTestLine, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineAX, 1, 1);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineAY, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineAZ, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineBX, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineBY, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.NudOverlayTestLineBZ, 3, 3);
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
            this.tableLayoutPanel5.TabIndex = 119;
            // 
            // CbxOverlayTestLine
            // 
            this.CbxOverlayTestLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CbxOverlayTestLine.AutoSize = true;
            this.tableLayoutPanel5.SetColumnSpan(this.CbxOverlayTestLine, 4);
            this.CbxOverlayTestLine.Location = new System.Drawing.Point(50, 4);
            this.CbxOverlayTestLine.Name = "CbxOverlayTestLine";
            this.CbxOverlayTestLine.Size = new System.Drawing.Size(66, 17);
            this.CbxOverlayTestLine.TabIndex = 86;
            this.CbxOverlayTestLine.Text = "Test line";
            this.CbxOverlayTestLine.UseVisualStyleBackColor = true;
            // 
            // NudOverlayTestLineAX
            // 
            this.NudOverlayTestLineAX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineAX.Location = new System.Drawing.Point(26, 29);
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
            this.NudOverlayTestLineAX.TabIndex = 87;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineAX, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineAX.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAX_ValueChanged);
            this.NudOverlayTestLineAX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineAX.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineAY
            // 
            this.NudOverlayTestLineAY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineAY.Location = new System.Drawing.Point(26, 55);
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
            this.NudOverlayTestLineAY.TabIndex = 88;
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
            // NudOverlayTestLineAZ
            // 
            this.NudOverlayTestLineAZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineAZ.Location = new System.Drawing.Point(26, 81);
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
            this.NudOverlayTestLineAZ.TabIndex = 89;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineAZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineAZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineAZ_ValueChanged);
            this.NudOverlayTestLineAZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineAZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // NudOverlayTestLineBX
            // 
            this.NudOverlayTestLineBX.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineBX.Location = new System.Drawing.Point(109, 29);
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
            this.NudOverlayTestLineBX.TabIndex = 93;
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
            // NudOverlayTestLineBY
            // 
            this.NudOverlayTestLineBY.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineBY.Location = new System.Drawing.Point(109, 55);
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
            this.NudOverlayTestLineBY.TabIndex = 94;
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
            // NudOverlayTestLineBZ
            // 
            this.NudOverlayTestLineBZ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.NudOverlayTestLineBZ.Location = new System.Drawing.Point(109, 81);
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
            this.NudOverlayTestLineBZ.TabIndex = 95;
            this.toolTip1.SetToolTip(this.NudOverlayTestLineBZ, "The test box\'s position in SH coordinates");
            this.NudOverlayTestLineBZ.ValueChanged += new System.EventHandler(this.NudOverlayTestLineBZ_ValueChanged);
            this.NudOverlayTestLineBZ.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudOverlayTestLineBZ.Enter += new System.EventHandler(this.Selectable_Enter);
            // 
            // label31
            // 
            this.label31.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(86, 84);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 13);
            this.label31.TabIndex = 98;
            this.label31.Text = "Z:";
            // 
            // label34
            // 
            this.label34.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(86, 58);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 13);
            this.label34.TabIndex = 97;
            this.label34.Text = "Y:";
            // 
            // label36
            // 
            this.label36.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(86, 32);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(17, 13);
            this.label36.TabIndex = 96;
            this.label36.Text = "X:";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 13);
            this.label20.TabIndex = 90;
            this.label20.Text = "X:";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(3, 58);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 13);
            this.label17.TabIndex = 91;
            this.label17.Text = "Y:";
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 84);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 13);
            this.label16.TabIndex = 92;
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
            this.tableLayoutPanel19.TabIndex = 10;
            // 
            // BtnReadFiles
            // 
            this.BtnReadFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnReadFiles.AutoSize = true;
            this.BtnReadFiles.Location = new System.Drawing.Point(3, 3);
            this.BtnReadFiles.Name = "BtnReadFiles";
            this.BtnReadFiles.Size = new System.Drawing.Size(125, 25);
            this.BtnReadFiles.TabIndex = 2;
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
            this.splitContainer1.TabIndex = 9;
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
            this.LbxFilesDirectories.TabIndex = 7;
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
            this.LbxFilesFiles.TabIndex = 8;
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
            this.TlpFramebufferTab.TabIndex = 15;
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
            this.tableLayoutPanel11.TabIndex = 14;
            // 
            // BtnFramebufferSave
            // 
            this.BtnFramebufferSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BtnFramebufferSave.AutoSize = true;
            this.BtnFramebufferSave.Location = new System.Drawing.Point(604, 3);
            this.BtnFramebufferSave.Name = "BtnFramebufferSave";
            this.tableLayoutPanel11.SetRowSpan(this.BtnFramebufferSave, 2);
            this.BtnFramebufferSave.Size = new System.Drawing.Size(75, 50);
            this.BtnFramebufferSave.TabIndex = 12;
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
            this.BtnFramebufferZoomIn.TabIndex = 7;
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
            this.CmbFramebufferZoom.TabIndex = 11;
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
            this.BtnFramebufferGrab.TabIndex = 1;
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
            this.BtnFramebufferZoomOut.TabIndex = 9;
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
            this.label93.TabIndex = 87;
            this.label93.Text = "Height:";
            // 
            // label89
            // 
            this.label89.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label89.AutoSize = true;
            this.label89.Location = new System.Drawing.Point(84, 6);
            this.label89.Name = "label89";
            this.label89.Size = new System.Drawing.Size(17, 13);
            this.label89.TabIndex = 84;
            this.label89.Text = "X:";
            // 
            // label90
            // 
            this.label90.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label90.AutoSize = true;
            this.label90.Location = new System.Drawing.Point(171, 6);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(38, 13);
            this.label90.TabIndex = 85;
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
            this.NudFramebufferH.TabIndex = 5;
            this.toolTip1.SetToolTip(this.NudFramebufferH, "Height");
            this.NudFramebufferH.Value = new decimal(new int[] {
            448,
            0,
            0,
            0});
            this.NudFramebufferH.ValueChanged += new System.EventHandler(this.NudFramebuffer_ValueChanged);
            this.NudFramebufferH.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferH.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
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
            this.NudFramebufferW.TabIndex = 4;
            this.toolTip1.SetToolTip(this.NudFramebufferW, "Width");
            this.NudFramebufferW.Value = new decimal(new int[] {
            320,
            0,
            0,
            0});
            this.NudFramebufferW.ValueChanged += new System.EventHandler(this.NudFramebuffer_ValueChanged);
            this.NudFramebufferW.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferW.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
            // 
            // label91
            // 
            this.label91.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label91.AutoSize = true;
            this.label91.Location = new System.Drawing.Point(84, 34);
            this.label91.Name = "label91";
            this.label91.Size = new System.Drawing.Size(17, 13);
            this.label91.TabIndex = 86;
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
            this.NudFramebufferOfsX.TabIndex = 2;
            this.toolTip1.SetToolTip(this.NudFramebufferOfsX, "X offset");
            this.NudFramebufferOfsX.ValueChanged += new System.EventHandler(this.NudFramebuffer_ValueChanged);
            this.NudFramebufferOfsX.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsX.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsX.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
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
            this.NudFramebufferOfsY.TabIndex = 3;
            this.toolTip1.SetToolTip(this.NudFramebufferOfsY, "Y offset");
            this.NudFramebufferOfsY.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.NudFramebufferOfsY.ValueChanged += new System.EventHandler(this.NudFramebuffer_ValueChanged);
            this.NudFramebufferOfsY.Click += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsY.Enter += new System.EventHandler(this.Selectable_Enter);
            this.NudFramebufferOfsY.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NudFramebuffer_KeyDown);
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
            this.groupBox8.TabIndex = 9;
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
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // TbxUtilityAnglesGameUnits
            // 
            this.TbxUtilityAnglesGameUnits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityAnglesGameUnits.Location = new System.Drawing.Point(72, 3);
            this.TbxUtilityAnglesGameUnits.Name = "TbxUtilityAnglesGameUnits";
            this.TbxUtilityAnglesGameUnits.Size = new System.Drawing.Size(70, 20);
            this.TbxUtilityAnglesGameUnits.TabIndex = 21;
            this.toolTip1.SetToolTip(this.TbxUtilityAnglesGameUnits, "Hexadecimal, 0x0 through 0xFFF");
            this.TbxUtilityAnglesGameUnits.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityAnglesGameUnits_KeyDown);
            // 
            // label78
            // 
            this.label78.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(34, 58);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(32, 13);
            this.label78.TabIndex = 24;
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
            this.TbxUtilityAnglesDegrees.TabIndex = 23;
            this.TbxUtilityAnglesDegrees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityAnglesDegrees_KeyDown);
            // 
            // label76
            // 
            this.label76.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(16, 32);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(50, 13);
            this.label76.TabIndex = 22;
            this.label76.Text = "Degrees:";
            // 
            // label75
            // 
            this.label75.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(3, 6);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(63, 13);
            this.label75.TabIndex = 20;
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
            this.tableLayoutPanel2.TabIndex = 44;
            // 
            // label71
            // 
            this.label71.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(3, 7);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(42, 13);
            this.label71.TabIndex = 1;
            this.label71.Text = "Format:";
            // 
            // LblUtilityFixedPointError
            // 
            this.LblUtilityFixedPointError.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblUtilityFixedPointError.AutoSize = true;
            this.LblUtilityFixedPointError.Location = new System.Drawing.Point(51, 88);
            this.LblUtilityFixedPointError.Name = "LblUtilityFixedPointError";
            this.LblUtilityFixedPointError.Size = new System.Drawing.Size(33, 13);
            this.LblUtilityFixedPointError.TabIndex = 8;
            this.LblUtilityFixedPointError.Text = "None";
            // 
            // label72
            // 
            this.label72.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(12, 34);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(33, 13);
            this.label72.TabIndex = 43;
            this.label72.Text = "Float:";
            // 
            // TbxUtilityFixedPointQ
            // 
            this.TbxUtilityFixedPointQ.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityFixedPointQ.Location = new System.Drawing.Point(51, 57);
            this.TbxUtilityFixedPointQ.Name = "TbxUtilityFixedPointQ";
            this.TbxUtilityFixedPointQ.Size = new System.Drawing.Size(100, 20);
            this.TbxUtilityFixedPointQ.TabIndex = 6;
            this.TbxUtilityFixedPointQ.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityFixedPointQ_KeyDown);
            // 
            // TbxUtilityFixedPointFloat
            // 
            this.TbxUtilityFixedPointFloat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.TbxUtilityFixedPointFloat.Location = new System.Drawing.Point(51, 30);
            this.TbxUtilityFixedPointFloat.Name = "TbxUtilityFixedPointFloat";
            this.TbxUtilityFixedPointFloat.Size = new System.Drawing.Size(100, 20);
            this.TbxUtilityFixedPointFloat.TabIndex = 4;
            this.TbxUtilityFixedPointFloat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbxUtilityFixedPointFloat_KeyDown);
            // 
            // label74
            // 
            this.label74.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(13, 88);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(32, 13);
            this.label74.TabIndex = 7;
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
            this.CmbUtilityFixedPointFormat.TabIndex = 2;
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
            this.label73.TabIndex = 5;
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
            this.GbxController.TabIndex = 26;
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
            this.tableLayoutPanel23.Controls.Add(this.CbxEnableControlsSection, 4, 2);
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
            this.tableLayoutPanel23.TabIndex = 17;
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
            this.tableLayoutPanel28.TabIndex = 18;
            // 
            // LblButtonR1
            // 
            this.LblButtonR1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblButtonR1.AutoSize = true;
            this.LblButtonR1.Location = new System.Drawing.Point(344, 33);
            this.LblButtonR1.Name = "LblButtonR1";
            this.LblButtonR1.Size = new System.Drawing.Size(21, 13);
            this.LblButtonR1.TabIndex = 12;
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
            this.LblButtonR2.TabIndex = 13;
            this.LblButtonR2.Text = "R2";
            // 
            // LblButtonL2
            // 
            this.LblButtonL2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblButtonL2.AutoSize = true;
            this.LblButtonL2.Location = new System.Drawing.Point(3, 6);
            this.LblButtonL2.Name = "LblButtonL2";
            this.LblButtonL2.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL2.TabIndex = 11;
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
            this.tableLayoutPanel31.TabIndex = 21;
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
            this.LblButtonStart.TabIndex = 1;
            this.LblButtonStart.Text = "Start";
            // 
            // LblButtonL3
            // 
            this.LblButtonL3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblButtonL3.AutoSize = true;
            this.LblButtonL3.Location = new System.Drawing.Point(3, 85);
            this.LblButtonL3.Name = "LblButtonL3";
            this.LblButtonL3.Size = new System.Drawing.Size(19, 13);
            this.LblButtonL3.TabIndex = 14;
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
            this.tableLayoutPanel30.TabIndex = 20;
            // 
            // LblButtonTriangle
            // 
            this.LblButtonTriangle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonTriangle.AutoSize = true;
            this.LblButtonTriangle.Location = new System.Drawing.Point(69, 13);
            this.LblButtonTriangle.Name = "LblButtonTriangle";
            this.LblButtonTriangle.Size = new System.Drawing.Size(45, 13);
            this.LblButtonTriangle.TabIndex = 6;
            this.LblButtonTriangle.Text = "Triangle";
            // 
            // LblButtonSquare
            // 
            this.LblButtonSquare.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonSquare.AutoSize = true;
            this.LblButtonSquare.Location = new System.Drawing.Point(10, 53);
            this.LblButtonSquare.Name = "LblButtonSquare";
            this.LblButtonSquare.Size = new System.Drawing.Size(41, 13);
            this.LblButtonSquare.TabIndex = 7;
            this.LblButtonSquare.Text = "Square";
            // 
            // LblButtonCircle
            // 
            this.LblButtonCircle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonCircle.AutoSize = true;
            this.LblButtonCircle.Location = new System.Drawing.Point(137, 53);
            this.LblButtonCircle.Name = "LblButtonCircle";
            this.LblButtonCircle.Size = new System.Drawing.Size(33, 13);
            this.LblButtonCircle.TabIndex = 8;
            this.LblButtonCircle.Text = "Circle";
            // 
            // LblButtonX
            // 
            this.LblButtonX.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonX.AutoSize = true;
            this.LblButtonX.Location = new System.Drawing.Point(84, 94);
            this.LblButtonX.Name = "LblButtonX";
            this.LblButtonX.Size = new System.Drawing.Size(14, 13);
            this.LblButtonX.TabIndex = 9;
            this.LblButtonX.Text = "X";
            // 
            // CbxEnableControlsSection
            // 
            this.CbxEnableControlsSection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxEnableControlsSection.AutoSize = true;
            this.CbxEnableControlsSection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CbxEnableControlsSection.Location = new System.Drawing.Point(306, 278);
            this.CbxEnableControlsSection.Name = "CbxEnableControlsSection";
            this.CbxEnableControlsSection.Size = new System.Drawing.Size(59, 17);
            this.CbxEnableControlsSection.TabIndex = 15;
            this.CbxEnableControlsSection.Text = "Enable";
            this.CbxEnableControlsSection.UseVisualStyleBackColor = true;
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
            this.tableLayoutPanel29.TabIndex = 19;
            // 
            // LblButtonUp
            // 
            this.LblButtonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonUp.AutoSize = true;
            this.LblButtonUp.Location = new System.Drawing.Point(79, 13);
            this.LblButtonUp.Name = "LblButtonUp";
            this.LblButtonUp.Size = new System.Drawing.Size(21, 13);
            this.LblButtonUp.TabIndex = 2;
            this.LblButtonUp.Text = "Up";
            // 
            // LblButtonLeft
            // 
            this.LblButtonLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonLeft.AutoSize = true;
            this.LblButtonLeft.Location = new System.Drawing.Point(17, 53);
            this.LblButtonLeft.Name = "LblButtonLeft";
            this.LblButtonLeft.Size = new System.Drawing.Size(25, 13);
            this.LblButtonLeft.TabIndex = 3;
            this.LblButtonLeft.Text = "Left";
            // 
            // LblButtonRight
            // 
            this.LblButtonRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonRight.AutoSize = true;
            this.LblButtonRight.Location = new System.Drawing.Point(135, 53);
            this.LblButtonRight.Name = "LblButtonRight";
            this.LblButtonRight.Size = new System.Drawing.Size(32, 13);
            this.LblButtonRight.TabIndex = 4;
            this.LblButtonRight.Text = "Right";
            // 
            // LblButtonDown
            // 
            this.LblButtonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LblButtonDown.AutoSize = true;
            this.LblButtonDown.Location = new System.Drawing.Point(72, 94);
            this.LblButtonDown.Name = "LblButtonDown";
            this.LblButtonDown.Size = new System.Drawing.Size(35, 13);
            this.LblButtonDown.TabIndex = 5;
            this.LblButtonDown.Text = "Down";
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
            this.tableLayoutPanel38.ResumeLayout(false);
            this.tableLayoutPanel38.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudEyeHeight)).EndInit();
            this.tableLayoutPanel27.ResumeLayout(false);
            this.tableLayoutPanel27.PerformLayout();
            this.GbxOverlay.ResumeLayout(false);
            this.tableLayoutPanel26.ResumeLayout(false);
            this.tableLayoutPanel26.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayCameraX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayRenderableOpacity)).EndInit();
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.TlpSelectedTriggerLeft.ResumeLayout(false);
            this.TlpSelectedTriggerLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudSelectedTriggerTargetIndex)).EndInit();
            this.groupBox1.ResumeLayout(false);
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
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWorldTintB)).EndInit();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudFogB)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.TrkModelScale)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudModelZ)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestBoxZ)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetSizeZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestSheetY)).EndInit();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineAZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudOverlayTestLineBZ)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.BpbFramebuffer)).EndInit();
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
		private PictureBox PbxMapGraphic;
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
		private CheckBox CbxStats;
		private TabPage TbpFog;
		private CheckBox CbxFog;
		private Button BtnFogColor;
		private Label label9;
		private Label label6;
		private Label label5;
		private NumericUpDown NudFogB;
		private NumericUpDown NudFogG;
		private NumericUpDown NudFogR;
		private CheckBox CbxCustomFog;
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
		private Label label35;
		private Label label38;
		private Label LblSelectedPoiXZ;
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
		private Label LblSelectedTriggerSomeIndex;
		private Label label50;
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
		private Label label15;
		private Label LblSelectedTriggerPoiGeometry;
		private ComboBox CmbRenderShape;
		private Button BtnClearPoisTriggers;
		private GroupBox GbxConvertStatesOrSaveRam;
		private PictureBox PbxHazardStripes;
		private CheckBox CbxSaveRamDanger;
		private Label LblSelectedTriggerThing2;
		private Label label60;
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
		private NumericUpDown NudOverlayTestBoxSizeZ;
		private NumericUpDown NudOverlayTestBoxSizeY;
		private NumericUpDown NudOverlayTestBoxSizeX;
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
		private Label label28;
		private Label label29;
		private Label label30;
		private NumericUpDown NudOverlayTestBoxZ;
		private NumericUpDown NudOverlayTestBoxY;
		private NumericUpDown NudOverlayTestBoxX;
		private CheckBox CbxOverlayTestBox;
		private Label label68;
		private RadioButton RdoOverlayAxisColorsOff;
		private Label label44;
		private RadioButton RdoOverlayAxisColorsOverlay;
		private RadioButton RdoOverlayAxisColorsGame;
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
		private CheckBox CbxOverlayRenderToFramebuffer;
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
		private Label LblCameraPathThing4;
		private Label label92;
		private Label LblCameraPathAreaMax;
		private Label label102;
		private Label LblCameraPathAreaMin;
		private Label label104;
		private Button BtnCameraPathGoToVolumeMin;
		private Label LblCameraPathAddress;
		private Label label107;
		private Label label108;
		private Label LblCameraPathVolumeMin;
		private Button BtnCameraPathGoToVolumeMax;
		private Label label80;
		private Label LblCameraPathVolumeMax;
		private Label LblCameraPathThing6;
		private Label label83;
		private Label LblCameraPathThing5;
		private Label label81;
		private Label LblCameraPathYaw;
		private Label LblCameraPathPitch;
		private Label label82;
		private Label label77;
		private CheckBox CbxReadLevelDataOnStageLoad;
		private CheckBox CbxCullBeyondFarClip;
		private CheckBox CbxCullBackfaces;
		private CheckBox CbxSelectedCameraPathDisabled;
		private Label label79;
		private Label label85;
		private NumericUpDown NudOverlayTestSheetSizeZ;
		private NumericUpDown NudOverlayTestSheetSizeX;
		private Label label86;
		private Label label87;
		private Label label88;
		private NumericUpDown NudOverlayTestSheetZ;
		private NumericUpDown NudOverlayTestSheetY;
		private NumericUpDown NudOverlayTestSheetX;
		private CheckBox CbxOverlayTestSheet;
		private Label label84;
		private NumericUpDown NudOverlayRenderableOpacity;
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
		private TrackBar TrkModelScale;
		private TableLayoutPanel tableLayoutPanel8;
		private NumericUpDown NudModelX;
		private NumericUpDown NudModelY;
		private NumericUpDown NudModelZ;
		private Label LblModelX;
		private Label LblModelY;
		private Label LblModelZ;
		private Button BtnModelSetPosition;
		private Button BtnModelGetPosition;
		private Label LblModelScale;
		private CheckBox CbxEnableModelDisplay;
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
		private Button BtnFirstPerson;
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
		private CheckBox CbxEnableControlsSection;
		private TableLayoutPanel tableLayoutPanel29;
		private Label LblButtonUp;
		private Label LblButtonLeft;
		private Label LblButtonRight;
		private Label LblButtonDown;
		private TableLayoutPanel tableLayoutPanel27;
		private CheckBox CbxCameraFlyInvert;
		private TextBox TbxCameraFlySensitivity;
		private Label label4;
		private CheckBox CbxCameraDetach;
		private Button BtnCameraFly;
		private TextBox TbxCameraFlySpeed;
		private Label label3;
		private TableLayoutPanel tableLayoutPanel38;
		private CheckBox CbxAlwaysRun;
		private Label label48;
		private NumericUpDown NudEyeHeight;
		private CheckBox CbxHideHarry;
		private TableLayoutPanel tableLayoutPanel39;
		private CheckBox CbxShowLookAt;
	}
}
