using Eto.Forms;
using Eto.Veldrid;
using Veldrid;

namespace SilentHillMapExaminer
{
	public partial class MainForm : Form
	{
		private bool _veldridReady = false;
		public bool VeldridReady
		{
			get { return _veldridReady; }
			private set
			{
				_veldridReady = value;

				SetUpVeldrid();
			}
		}

		private bool _formReady = false;
		public bool FormReady
		{
			get { return _formReady; }
			set
			{
				_formReady = value;

				SetUpVeldrid();
			}
		}

		RichTextArea rtaFileContents = new RichTextArea();
		VeldridSurface vlsMapDisplay;

		public UITimer Clock { get; } = new UITimer();

		public CommandList CommandList { get; private set; }

		public MainForm()
		{
			InitializeComponent();

			vlsMapDisplay = new VeldridSurface(
				VeldridSurface.PreferredBackend,
				new GraphicsDeviceOptions(
					false,
					PixelFormat.R32_Float,
					false,
					ResourceBindingModel.Improved));

			Shown += (sender, e) => FormReady = true;
			vlsMapDisplay.VeldridInitialized += (sender, e) => VeldridReady = true;
			vlsMapDisplay.Size = new Eto.Drawing.Size(200, 200);

			var tblMain = new TableLayout(2, 1);
			tblMain.Spacing = new Eto.Drawing.Size(10, 0);

			tblMain.Add(rtaFileContents, 0, 0);
			tblMain.Add(vlsMapDisplay, 1, 0);

			Content = tblMain;


			Clock.Interval = 1.0f / 60.0f;
			Clock.Elapsed += Clock_Elapsed;
		}

		private void Clock_Elapsed(object sender, System.EventArgs e)
		{
			CommandList.Begin();

			CommandList.SetFramebuffer(vlsMapDisplay.Swapchain.Framebuffer);

			CommandList.ClearColorTarget(0, RgbaFloat.Pink);
			CommandList.ClearDepthStencil(1.0f);

			CommandList.End();

			vlsMapDisplay.GraphicsDevice.SubmitCommands(CommandList);
			vlsMapDisplay.GraphicsDevice.SwapBuffers(vlsMapDisplay.Swapchain);
		}

		private void SetUpVeldrid()
		{
			if (!(FormReady && VeldridReady))
			{
				return;
			}

			ResourceFactory factory = vlsMapDisplay.GraphicsDevice.ResourceFactory;

			CommandList = factory.CreateCommandList();

			Clock.Start();
		}
	}
}
