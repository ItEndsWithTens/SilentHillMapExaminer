using System.Globalization;
using static SHME.ExternalTool.Guts;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void ReportStats()
		{
			CultureInfo c = CultureInfo.CurrentCulture;

			int healthRaw = Mem.ReadS32(Rom.Addresses.MainRam.HarryHealth);

			LblHarryHealth.Text = QToFloat(healthRaw).ToString(c);

			uint secondsRaw = Mem.ReadU32(Rom.Addresses.MainRam.TotalTime);
			double secondsScaled = secondsRaw / 4096.0;

			int hours = (int)(secondsScaled / 3600.0);
			int minutes = (int)((secondsScaled % 3600.0) / 60.0);
			int seconds = (int)((secondsScaled % 3600.0) % 60.0);

			LblTotalTime.Text = $"{hours.ToString(c)}h {minutes.ToString(c)}m {seconds.ToString(c)}s";

			int walkedRaw = Mem.ReadS32(Rom.Addresses.MainRam.WalkingDistance);
			int runRaw = Mem.ReadS32(Rom.Addresses.MainRam.RunningDistance);

			LblWalkingDistance.Text = $"{(QToFloat(walkedRaw) / 1000.0f).ToString("N3", c)} km";
			LblRunningDistance.Text = $"{(QToFloat(runRaw) / 1000.0f).ToString("N3", c)} km";
		}
	}
}
