using Nucs.JsonSettings;
using Nucs.JsonSettings.Autosave;
using Nucs.JsonSettings.Fluent;
using Nucs.JsonSettings.Modulation;
using Nucs.JsonSettings.Modulation.Recovery;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SHME.ExternalTool
{
	public class Settings : IDisposable
	{
		/// <summary>
		/// User-specific, machine-dependent settings.
		/// </summary>
		public LocalSettings Local { get; set; }

		/// <summary>
		/// User-specific, machine-independent settings.
		/// </summary>
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

			bool save = false;

			// Settings that are collections need to be initialized as empty
			// first, then populated later. Otherwise JsonSettings creates a
			// series of duplicate entries in your settings file on every load.
			if (Local.FpsBinds?.Count < DefaultLocalSettings.FpsBinds.Count)
			{
				foreach (InputBind d in DefaultLocalSettings.FpsBinds)
				{
					bool exists = Local.FpsBinds
						.Where((l) => l.Command == d.Command)
						.Any();

					if (!exists)
					{
						Local.FpsBinds.Add(new InputBind(d));
					}
				}

				save = true;
			}

			if (Local.FlyBinds?.Count < DefaultLocalSettings.FlyBinds.Count)
			{
				foreach (InputBind d in DefaultLocalSettings.FlyBinds)
				{
					bool exists = Local.FlyBinds
						.Where((l) => l.Command == d.Command)
						.Any();

					if (!exists)
					{
						Local.FlyBinds.Add(new InputBind(d));
					}
				}

				save = true;
			}

			// JsonSettings can't autosave changes to collections that don't
			// implement INotifyCollectionChanged, but even for such collection
			// types there are no change events raised when elements of the
			// collection have changed, only when the collection itself has
			// changed. Developing a custom collection class with that feature
			// is much more involved than just calling Save when necessary.
			if (save)
			{
				Local.Save();
			}

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
