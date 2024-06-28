using SHME.ExternalTool.Graphics;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SHME.ExternalTool;

partial class Guts
{
	public Camera Camera { get; set; } = new()
	{
		Culling = Culling.Frustum,
		Fov = 53.13f
	};

	public IList<Renderable> TestBoxes { get; } = [];
	public IList<Renderable> Gems { get; } = [];
	public IList<Renderable> Lines { get; } = [];

	public Viewport ClickPort { get; set; } = new();
	public Viewport RenderPort { get; set; } = new();

	public Renderable GameCameraLookAt { get; set; } = new();

	// SortedDictionary is the best type available for this purpose, it
	// seems. It allows access by key, in this case the address of the
	// SilentHillType, but keeps elements sorted by said key. A simple
	// extension method, IndexFromKey, then allows getting the index in
	// situations that warrant it.
	//
	// Sadly, dictionaries don't implement INotifyCollectionChanged, so
	// data binding is a problem. ObservableCollection does, but then it
	// doesn't implement IBindingList, which is an issue for ListBoxes:
	// https://learn.microsoft.com/en-us/dotnet/desktop/winforms/controls/how-to-bind-a-windows-forms-combobox-or-listbox-control-to-data
	//
	// Managing these dictionaries and the associated ListBoxes by hand
	// is a bit more work, but avoids a whole load of nonsense otherwise.
	public SortedDictionary<long, (PointOfInterest, Renderable?)> Pois { get; } = [];
	public SortedDictionary<long, Trigger> Triggers { get; } = [];

	public Renderable TestBox { get; set; } = new BoxGenerator(1.0f, Color.White).GenerateRainbowBox().ToWorld();
	public IList<Renderable> TestLines { get; } =
	[
		new Line(
		new Vertex(0.0f, 1.0f, 0.0f, Color.Red.ToArgb()),
		new Vertex(1.0f, 1.0f, 0.0f, Color.Lime.ToArgb()))
	];
	public Renderable TestSheet { get; set; } = new SheetGenerator(1.0f, Color.White).Generate().ToWorld();

	public IList<Renderable> ModelBoxes { get; } = [];

	public Dictionary<CameraPath, IList<Renderable?>> CameraPaths { get; } = [];

	public IList<Renderable> CameraBoxes { get; } = [];
	public IList<Renderable> CameraGems { get; } = [];
	public IList<Line> CameraLines { get; } = [];

	private IList<((Vertex a, Vertex b), int argb, bool visible)> _screenSpaceLines = [];
	public ref IList<((Vertex a, Vertex b), int argb, bool visible)> ScreenSpaceLines => ref _screenSpaceLines;
	private IList<(Renderable, bool)> _visibleRenderables = [];
	public ref IList<(Renderable, bool)> VisibleRenderables => ref _visibleRenderables;

	public Stage? Stage { get; set; }

	public PointOfInterest? LastHarrySpawnPoint { get; set; }

	public ControllerConfig ControllerConfig { get; set; }

	public Ilm? HarryModel { get; set; }

	public Ilm? Model { get; set; }

	private PsxButtons _saveButton = PsxButtons.None;
	public ref PsxButtons SaveButton => ref _saveButton;

	private Dictionary<SilentHillType, IList<(ListControl control, int index)>> _clickedThings = [];
	public ref Dictionary<SilentHillType, IList<(ListControl control, int index)>> ClickedThings => ref _clickedThings;

	public Tim? AreaMapGraphic { get; set; }
}
