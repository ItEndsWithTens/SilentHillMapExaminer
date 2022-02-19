using static SHME.ExternalTool.Core;

namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void ReportStats()
		{
			if (Mem == null)
			{
				return;
			}

			LblHarryHealth.Text = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.HarryHealth)).ToString();

			double secondsScaled = Mem.ReadU32(Rom.Addresses.MainRam.TotalTime) / 4096.0;

			int hours = (int)(secondsScaled / 3600.0);
			int minutes = (int)((secondsScaled % 3600.0) / 60.0);
			int seconds = (int)((secondsScaled % 3600.0) % 60.0);

			LblTotalTime.Text = $"{hours}h {minutes}m {seconds}s";

			float walkedRaw = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.WalkingDistance));
			float runRaw = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.RunningDistance));

			LblWalkingDistance.Text = $"{walkedRaw / 1000.0f:N3} km";
			LblRunningDistance.Text = $"{runRaw / 1000.0f:N3} km";
		}
	}
}
