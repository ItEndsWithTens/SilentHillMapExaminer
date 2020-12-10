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

			float walkedRaw = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DistanceWalked));
			float runRaw = QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DistanceRun));

			LblDistanceWalked.Text = $"{walkedRaw / 1000.0f:N3} km";
			LblDistanceRun.Text = $"{runRaw / 1000.0f:N3} km";
		}
	}
}
