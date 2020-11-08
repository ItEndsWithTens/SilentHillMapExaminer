namespace BizHawk.Client.EmuHawk
{
	public partial class CustomMainForm
	{
		private void ReportStats()
		{
			float walkedRaw = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DistanceWalked));
			float runRaw = Core.QToFloat(Mem.ReadS32(Rom.Addresses.MainRam.DistanceRun));

			LblDistanceWalked.Text = $"{walkedRaw / 1000.0f:N3} km";
			LblDistanceRun.Text = $"{runRaw / 1000.0f:N3} km";
		}
	}
}
