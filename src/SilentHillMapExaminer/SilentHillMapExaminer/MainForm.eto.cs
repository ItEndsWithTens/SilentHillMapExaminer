using Eto.Drawing;
using Eto.Forms;
using Eto.Veldrid;

namespace SilentHillMapExaminer
{
	partial class MainForm : Form
	{
		void InitializeComponent()
		{
			Title = "Silent Hill Map Examiner";
			ClientSize = new Size(400, 350);
			MinimumSize = new Size(250, 250);
			Padding = 10;

			var quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
			quitCommand.Executed += (sender, e) => Application.Instance.Quit();

			var aboutCommand = new Command { MenuText = "About..." };
			aboutCommand.Executed += (sender, e) => new AboutDialog().ShowDialog(this);

			Menu = new MenuBar
			{
				Items =
				{
					new ButtonMenuItem { Text = "&File", Items = { CmdOpen } },
					// new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
					// new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
				},
				ApplicationItems =
				{
					// application (OS X) or file menu (others)
				},
				QuitItem = quitCommand,
				AboutItem = aboutCommand
			};
		}
	}
}
