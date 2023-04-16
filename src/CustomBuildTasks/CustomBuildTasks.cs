using BizHawk.Common;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace CustomBuildTasks
{
	public class ReadBizHawkVersion : Task
	{
		[Output]
		public string BHV { get; private set; } = "X.Y";

		public override bool Execute()
		{
			BHV = VersionInfo.MainVersion;

			return true;
		}
	}
}
