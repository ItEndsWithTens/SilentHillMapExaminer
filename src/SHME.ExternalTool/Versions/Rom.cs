namespace SHME.ExternalTool
{
	public abstract class Rom
	{
		public abstract string Name { get; }

		public abstract string HashBizHawk { get; }
		public abstract string HashCrc32 { get; }
		public abstract string HashMd5 { get; }
		public abstract string HashSha1 { get; }

		public abstract Addresses Addresses { get; }
	}
}
