using BenchmarkDotNet.Attributes;
using SHME.ExternalTool.Graphics;
using System.Drawing;
using System.Numerics;

namespace SHME.Benchmarks.Graphics
{
	public class AabbBenchmarks
	{
		readonly Aabb aabb0 = new(
			new Vector3(0.0f, 0.0f, 0.0f),
			new Vector3(1.0f, 1.0f, 1.0f));

		readonly Aabb aabb1 = new(
			new Vector3(2.0f, 3.0f, 4.0f),
			new Vector3(27.0f, 43.0f, 5.0f));

		// Adding two Aabbs together should exercise the most important code
		// paths in the class; constructing a new instance, setting Min and
		// Max, and calling Update. Other benchmarks would just be redundant,
		// since "benchmarks aren't unit tests" after all.
		[Benchmark]
		public Aabb AddAabb()
		{
			return aabb0 + aabb1;
		}
	}

	public class CameraBenchmarks
	{
		readonly Camera camera = new() { Culling = Culling.Frustum };

		readonly BoxGenerator boxGenerator = new(1.0f, Color.White);
		readonly Renderable box;

		readonly SheetGenerator sheetGenerator = new(4096.0f, Color.White);
		readonly Renderable sheet;

		public CameraBenchmarks()
		{
			box = boxGenerator.Generate();
			box.Position = new Vector3(2048.0f);

			sheet = sheetGenerator.Generate();
		}

		// Covers checking the Camera's culling flags as well as calling
		// Frustum.TouchedBy with the renderable's Aabb.
		[Benchmark]
		public bool CannotSeeOffscreenRenderable()
		{
			return !camera.CanSee(box);
		}

		Line line = new(
			new Vertex(new Vector3(-4096.0f, 0.0f, 0.0f)),
			new Vertex(new Vector3(4096.0f, 0.0f, 0.0f)));

		// Takes care of ClipLineAgainstFrustum, ClipLineAgainstPlanes, and the
		// singular form of the latter as well, all in one benchmark.
		[Benchmark]
		public bool ClipLineAgainstFrustum()
		{
			// Since Lines are mutable, and get modified by the clipping method,
			// it's necessary to reset the X coordinates of each vertex per op.

			Vertex a = line.A;
			Vertex b = line.B;

			Vector3 posA = a.Position;
			Vector3 posB = b.Position;

			posA.X = -4096.0f;
			posB.X = 4096.0f;

			a.Position = posA;
			b.Position = posB;

			line.A = a;
			line.B = b;

			return camera.ClipLineAgainstFrustum(ref line);
		}

		[Benchmark]
		public Polygon ClipPolygonAgainstFrustum()
		{
			return camera.ClipPolygonAgainstFrustum(sheet.Polygons[0]);
		}

		// Calls Camera.UpdateViewMatrix, Camera.UpdateProjectionMatrix, and
		// Frustum.Update.
		[Benchmark]
		public Camera SetAngles()
		{
			camera.UpdateAll(
				null,
				45.0f, 45.0f, 45.0f,
				null, null,
				null, null);

			return camera;
		}
	}
}
