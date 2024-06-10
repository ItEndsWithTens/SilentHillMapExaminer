namespace SHME.ExternalTool
{
	public abstract class Rom
	{
		public abstract string Name { get; }

		public abstract string HashBizHawk { get; }
		public abstract string HashCrc32 { get; }
		public abstract string HashMd5 { get; }
		public abstract string HashSha1 { get; }

		/// <summary>
		/// Zero for full game releases, i.e. the beginning of their respective
		/// discs. Will be different for demo discs with multiple games on them.
		/// A given file's start sector is assumed to be relative to this.
		/// </summary>
		public abstract int BaseLba { get; }

		public abstract Addresses Addresses { get; }
	}
}
