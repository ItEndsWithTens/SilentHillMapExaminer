using Nucs.JsonSettings;
using Nucs.JsonSettings.Autosave;
using Nucs.JsonSettings.Fluent;
using Nucs.JsonSettings.Modulation;
using Nucs.JsonSettings.Modulation.Recovery;
using System;
using System.Diagnostics;
using System.IO;

namespace SHME.ExternalTool.Extras
{
	public class Settings : IDisposable
	{
		public LocalSettings Local { get; set; }
		public RoamingSettings Roaming { get; set; }

		private bool disposedValue;

		public Settings(string company, string product, string component)
		{
			string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string roamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

			string localPath = Path.Combine(localAppData, company, product, $"{component}.local.json");
			string roamingPath = Path.Combine(roamingAppData, company, product, $"{component}.roaming.json");

			FileVersionInfo info = FileVersionInfo.GetVersionInfo(typeof(Settings).Assembly.Location);
			var version = new Version(info.FileMajorPart, info.FileMinorPart, info.FileBuildPart);

			VersioningResultAction actionV = VersioningResultAction.RenameAndLoadDefault;
			RecoveryAction actionR = RecoveryAction.RenameAndLoadDefault;

			Local = JsonSettings
				.Configure<LocalSettings>(localPath)
				.WithVersioning(version, actionV)
				.WithRecovery(actionR)
				.LoadNow()
				.EnableAutosave();

			Roaming = JsonSettings
				.Configure<RoamingSettings>(roamingPath)
				.WithVersioning(version, actionV)
				.WithRecovery(actionR)
				.LoadNow()
				.EnableAutosave();
		}

		public void Save()
		{
			Local.Save();
			Roaming.Save();
		}

		private SuspendAutosave? _suspendAutosaveLocal;
		private SuspendAutosave? _suspendAutosaveRoaming;
		public void SuspendAutosave()
		{
			_suspendAutosaveLocal = Local.SuspendAutosave();
			_suspendAutosaveRoaming = Roaming.SuspendAutosave();
		}
		public void ResumeAutosave()
		{
			_suspendAutosaveLocal?.Resume();
			_suspendAutosaveRoaming?.Resume();

			_suspendAutosaveLocal = null;
			_suspendAutosaveRoaming = null;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_suspendAutosaveLocal?.Dispose();
					_suspendAutosaveRoaming?.Dispose();

					Local.Dispose();
					Roaming.Dispose();
				}

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
}
