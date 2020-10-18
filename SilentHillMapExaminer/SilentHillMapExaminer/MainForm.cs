using Eto.Forms;
using Eto.Veldrid;
using Microsoft.DotNet.PlatformAbstractions;
using System;
using System.Text;
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

		private Command CmdOpen = new Command
		{
			MenuText = "&Open...",
			Shortcut = Application.Instance.CommonModifier | Keys.O
		};

		RichTextArea rtaFileContents = new RichTextArea()
		{
			Font = new Eto.Drawing.Font(Eto.Drawing.FontFamilies.Monospace, 14.0f),
			ReadOnly = true,
			Wrap = false
		};
		VeldridSurface vlsMapDisplay;
		Splitter splMain;

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


			rtaFileContents.SelectionChanged += RtaFileContents_SelectionChanged;

			splMain = new Splitter
			{
				Orientation = Orientation.Horizontal,
				Panel1 = rtaFileContents,
				Panel1MinimumSize = 64,
				Panel2 = vlsMapDisplay,
				Panel2MinimumSize = 64
			};

			//var tblMain = new TableLayout(2, 1);
			//tblMain.Spacing = new Eto.Drawing.Size(10, 0);
			//
			//tblMain.Add(rtaFileContents, 0, 0);
			//tblMain.Add(vlsMapDisplay, 1, 0);

			Content = splMain;

			CmdOpen.Executed += CmdOpen_Executed;

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

		private void CloseMap()
		{
			// TODO: Delete Veldrid buffers, etc.
		}

		private void CmdOpen_Executed(object sender, System.EventArgs e)
		{
			var dlgOpenFile = new OpenFileDialog()
			{
				MultiSelect = false,
				CheckFileExists = true
			};

			DialogResult result = dlgOpenFile.ShowDialog(this);

			if (result == DialogResult.Cancel)
			{
				return;
			}

			CloseMap();

			OpenMap(dlgOpenFile.FileName);
		}

		private void OpenMap(string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
			{
				return;
			}

			byte[] raw = System.IO.File.ReadAllBytes(fileName);

			var sb = new StringBuilder();

			for (int i = 0; i < raw.Length; i++)
			{
				if (i > 0 && i % 16 == 0)
				{
					sb.Append(Environment.NewLine);
				}

				if (i % 16 != 0 && i % 4 == 0)
				{
					sb.Append(" ");
				}

				sb.Append(raw[i].ToString("X2"));
			}

			rtaFileContents.Text = sb.ToString();

			// 2 characters per byte, 4 bytes per word, 4 words per line, but
			// then there are 3 spaces separating said words, plus 1 newline.
			Eto.Drawing.SizeF lineSize = rtaFileContents.Font.MeasureString(rtaFileContents.Text.Substring(0, 36));

			// Unfortunately that's just the string itself, so add some cushion
			// to account for scrollbars and what all.
			splMain.Panel1MinimumSize = (int)lineSize.Width + 32;
		}

		private void RtaFileContents_SelectionChanged(object sender, EventArgs e)
		{
			var random = new System.Random();

			var color = new Eto.Drawing.Color((float)random.NextDouble(), (float)random.NextDouble(), (float)random.NextDouble());

			rtaFileContents.SelectionBackground = color;
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
