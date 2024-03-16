namespace SHME.ExternalTool
{
	// The ability BizHawk offers to restrict usage of an external tool to only
	// certain ROMs is implemented via attributes, and they require constant
	// values. Otherwise these would be stored in each derived Rom class.
	public static class Slus00707Constants
	{
		public const string Name = "Silent Hill (USA)";

		public const string HashBizHawk = "F1B5EB6C";
		public const string HashCrc32 = "1D4A3FF7";
		public const string HashMd5 = "B52500EEA7D7D04A6A81B0EFE88955E1";
		public const string HashSha1 = "34278D31D9B9B12B3B5DB5E45BCBE548991ECBC7";
	}
}
