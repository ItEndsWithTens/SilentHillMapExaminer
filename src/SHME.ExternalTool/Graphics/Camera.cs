using System;
using System.Collections.Generic;
using System.Numerics;

namespace SHME.ExternalTool
{
	[Flags]
	public enum Culling
	{
		None = 0,
		Near = 1,
		Far = 2,
		Left = 4,
		Right = 8,
		Top = 16,
		Bottom = 32,
		Frustum = Near | Far | Left | Right | Top | Bottom,
		Backface = 64,
		All = Frustum | Backface
	}

	public class Frustum
	{
		public Vector3 NearTopLeft { get; set; }
		public Vector3 NearTopRight { get; set; }
		public Vector3 NearBottomLeft { get; set; }
		public Vector3 NearBottomRight { get; set; }

		public Vector3 FarTopLeft { get; set; }
		public Vector3 FarTopRight { get; set; }
		public Vector3 FarBottomLeft { get; set; }
		public Vector3 FarBottomRight { get; set; }

		public Plane Left { get; private set; } = new Plane();
		public Plane Right { get; private set; } = new Plane();
		public Plane Top { get; private set; } = new Plane();
		public Plane Bottom { get; private set; } = new Plane();
		public Plane Near { get; private set; } = new Plane();
		public Plane Far { get; private set; } = new Plane();

		public IList<Plane> Planes { get; } = new List<Plane>();

		public Frustum()
		{
			Update(
				new Vector3(0.0f), new Vector3(0.0f, 0.0f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f),
				75.0f, 1.0f, 0.01f, 1.0f,
				Culling.All);
		}
		public Frustum(
			Vector3 position, Vector3 front, Vector3 right, Vector3 up,
			float fov, float aspect, float near, float far,
			Culling culling)
		{
			Update(position, front, right, up, fov, aspect, near, far, culling);
		}

		public bool TouchedBy(Aabb aabb)
		{
			bool touches = true;

			foreach (Plane plane in Planes)
			{
				bool allPointsBehind = true;

				foreach (Vector3 p in aabb.Points)
				{
					if (Vector3.Dot(p - plane.A, plane.Normal) > 0.0f)
					{
						allPointsBehind = false;
						break;
					}
				}

				if (allPointsBehind)
				{
					touches = false;
					break;
				}
			}

			return touches;
		}

		public void Update(
			Vector3 position, Vector3 front, Vector3 right, Vector3 up,
			float fov, float aspect, float near, float far,
			Culling culling)
		{
			Vector3 nearTarget = position + (front * near);
			Vector3 farTarget = position + (front * far);

			float nearHalfHeight = GetHalf(fov, near);
			float nearHalfWidth = nearHalfHeight * aspect;

			float farHalfHeight = GetHalf(fov, far);
			float farHalfWidth = farHalfHeight * aspect;

			Vector3 nearEdgeHorizontal = right * nearHalfWidth;
			Vector3 nearEdgeVertical = up * nearHalfHeight;

			NearTopLeft = (nearTarget - nearEdgeHorizontal) + nearEdgeVertical;
			NearTopRight = (nearTarget + nearEdgeHorizontal) + nearEdgeVertical;
			NearBottomLeft = (nearTarget - nearEdgeHorizontal) - nearEdgeVertical;
			NearBottomRight = (nearTarget + nearEdgeHorizontal) - nearEdgeVertical;

			Vector3 farEdgeHorizontal = right * farHalfWidth;
			Vector3 farEdgeVertical = up * farHalfHeight;

			FarTopLeft = (farTarget - farEdgeHorizontal) + farEdgeVertical;
			FarTopRight = (farTarget + farEdgeHorizontal) + farEdgeVertical;
			FarBottomLeft = (farTarget - farEdgeHorizontal) - farEdgeVertical;
			FarBottomRight = (farTarget + farEdgeHorizontal) - farEdgeVertical;

			Left = new Plane(NearTopLeft, NearBottomLeft, FarBottomLeft, Winding.Ccw);
			Right = new Plane(NearTopRight, FarTopRight, FarBottomRight, Winding.Ccw);
			Top = new Plane(NearTopLeft, FarTopLeft, FarTopRight, Winding.Ccw);
			Bottom = new Plane(NearBottomRight, FarBottomRight, FarBottomLeft, Winding.Ccw);
			Near = new Plane(NearTopLeft, NearTopRight, NearBottomRight, Winding.Ccw);
			Far = new Plane(FarBottomRight, FarTopRight, FarTopLeft, Winding.Ccw);

			Planes.Clear();

			if (culling.HasFlag(Culling.Left))
			{
				Planes.Add(Left);
			}
			if (culling.HasFlag(Culling.Right))
			{
				Planes.Add(Right);
			}
			if (culling.HasFlag(Culling.Top))
			{
				Planes.Add(Top);
			}
			if (culling.HasFlag(Culling.Bottom))
			{
				Planes.Add(Bottom);
			}
			if (culling.HasFlag(Culling.Near))
			{
				Planes.Add(Near);
			}
			if (culling.HasFlag(Culling.Far))
			{
				Planes.Add(Far);
			}
		}

		private static float GetHalf(float fov, float distance)
		{
			float half = fov / 2.0f;

			float hyp = (float)(distance / Math.Cos(MathUtilities.DegreesToRadians(half)));

			return (float)Math.Sqrt(Math.Pow(hyp, 2.0) - Math.Pow(distance, 2.0));
		}
	}

	public class Camera
	{
		private float _aspectRatio;
		public float AspectRatio
		{
			get => _aspectRatio;
			set
			{
				_aspectRatio = value;

				UpdateAllInternal();
			}
		}

		private float _fov;
		/// <summary>
		/// The vertical field of view of this camera, in degrees.
		/// </summary>
		public float Fov
		{
			get => _fov;
			set
			{
				if (value > 120.0f)
				{
					_fov = 120.0f;
				}
				else
				{
					_fov = value;

					UpdateAllInternal();
				}
			}
		}

		private float _maxPitch = 360.0f;
		public float MaxPitch
		{
			get => _maxPitch;
			set => _maxPitch = MathUtilities.ModAngleToCircleSigned(value);
		}

		private float _minPitch = -360.0f;
		public float MinPitch
		{
			get => _minPitch;
			set => _minPitch = MathUtilities.ModAngleToCircleSigned(value);
		}

		private float _nearClip;
		public float NearClip
		{
			get => _nearClip;
			set
			{
				_nearClip = value;

				UpdateAllInternal();
			}
		}
		private float _farClip;
		public float FarClip
		{
			get => _farClip;
			set
			{
				_farClip = value;

				UpdateAllInternal();
			}
		}

		private Vector3 _position;
		/// <summary>
		/// This camera's position in Y-up, right-handed coordinates.
		/// </summary>
		public Vector3 Position
		{
			get => _position;
			set
			{
				_position = value;

				UpdateAllInternal();
			}
		}

		private float _pitch;
		public float Pitch
		{
			get => _pitch;
			set
			{
				_pitch = MathUtilities.ModAngleToCircleSigned(value);

				if (_pitch > MaxPitch)
				{
					_pitch = MaxPitch;
				}
				else if (_pitch < MinPitch)
				{
					_pitch = MinPitch;
				}

				UpdateAllInternal();
			}
		}

		private float _yaw;
		public float Yaw
		{
			get => _yaw;
			set
			{
				_yaw = MathUtilities.ModAngleToCircleUnsigned(value);

				UpdateAllInternal();
			}
		}

		private float _roll;
		public float Roll
		{
			get => _roll;
			set
			{
				_roll = MathUtilities.ModAngleToCircleSigned(value);

				UpdateAllInternal();
			}
		}

		private Culling _culling;
		public Culling Culling
		{
			get => _culling;
			set
			{
				_culling = value;

				UpdateAllInternal();
			}
		}

		public Frustum Frustum { get; } = new Frustum();

		public Matrix4x4 ViewMatrix { get; private set; }
		public Matrix4x4 ProjectionMatrix { get; set; }

		private Vector3 WorldUp;
		public Vector3 Front;
		private Vector3 Right;
		private Vector3 Up;

		public Camera()
		{
			_fov = 75.0f;

			// Gameplay in Silent Hill is rendered to a 320x224 framebuffer, as
			// opposed to the inventory and map screens, which are 320x448.
			_aspectRatio = 320.0f / 224.0f;

			// The default SH draw distance is 14.5 world units.
			_nearClip = 0.01f;
			_farClip = 20.0f;

			WorldUp = new Vector3(0.0f, 1.0f, 0.0f);
			Position = new Vector3(0.0f, 0.0f, 0.0f);

			Pitch = 0.0f;
			Yaw = 0.0f;
			Roll = 0.0f;

			_culling = Culling.All;

			UpdateAllInternal();
		}

		public bool CanSee(Renderable r)
		{
			return Frustum.TouchedBy(r.Aabb);
		}

		public void LookAt(Vector3 target)
		{
			ViewMatrix = Matrix4x4.CreateLookAt(Position, target, Up);

			UpdateProjectionMatrix();
			Frustum.Update(
				Position,
				Front, Right, Up,
				Fov, AspectRatio,
				NearClip, FarClip,
				Culling);
		}

		public void UpdateViewMatrix()
		{
			float yawRad = MathUtilities.DegreesToRadians(Yaw);
			float pitchRad = MathUtilities.DegreesToRadians(Pitch);
			float rollRad = MathUtilities.DegreesToRadians(Roll);

			// There are two contexts of "handedness" at play in any camera's
			// coordinate system. One is the concern of which way the positive
			// ends of the axes point, with "left-handed" coordinates having the
			// positive Z axis point in the direction the camera is looking, and
			// "right-handed" being the opposite. The other handedness concerns
			// the direction of rotations, with the "left hand rule" being that
			// rotations about a given axis go clockwise when looking toward the
			// negative direction of that axis, while the "right hand rule" has
			// the rotations go counter-clockwise.
			//
			// This camera uses right-handed coordinate space, but aims to also
			// use right hand rotation, which complicates these calculations a
			// little bit.
			//
			// When looking "down" at a given plane, that is to say looking in
			// the negative direction of the perpendicular axis, one axis runs
			// horizontally relative to the view and one runs vertically.
			//
			// Rotating a unit vector within that plane requires modifying two
			// of its components, one per axis. For the vertical axis, taking
			// the sine of the rotation value for the axis of rotation will in
			// fact give you a counter-clockwise turn, but only assuming the
			// positive ends of the horizontal and vertical axes point right and
			// up, respectively.
			//
			// This plugin's coordinate system being right-handed, pitch is not
			// an issue, and simply taking the sine of the pitch value gives the
			// new Y component of the front vector. Yaw is a different story,
			// thanks to the direction of the positive Z axis, and negating the
			// sine result becomes necessary to achieve the right hand rule and
			// produce counter-clockwise rotation.
			Front.X = Convert.ToSingle(Math.Cos(pitchRad) * Math.Cos(yawRad));
			Front.Y = Convert.ToSingle(Math.Sin(pitchRad));
			Front.Z = Convert.ToSingle(Math.Cos(pitchRad) * -Math.Sin(yawRad));

			Front = Vector3.Normalize(Front);

			Right = Vector3.Normalize(Vector3.Cross(Front, WorldUp));
			Matrix4x4 matrixRoll = Matrix4x4.CreateFromAxisAngle(Front, rollRad);
			Right = Vector3.Transform(Right, matrixRoll);

			Up = Vector3.Normalize(Vector3.Cross(Right, Front));

			ViewMatrix = Matrix4x4.CreateLookAt(Position, Position + Front, Up);
		}

		public void TranslateRelative(bool forward, bool backward, bool left, bool right, bool up, bool down, float distance)
		{
			if (forward)
			{
				// Remember that OpenGL uses right-handed coordinates.
				Position += distance * Front;
			}
			else if (backward)
			{
				Position -= distance * Front;
			}

			if (left)
			{
				Position -= distance * Right;
			}
			else if (right)
			{
				Position += distance * Right;
			}

			if (up)
			{
				Position += distance * WorldUp;
			}
			else if (down)
			{
				Position -= distance * WorldUp;
			}
		}

		public void UpdateAll(
			Vector3? position,
			float? pitch, float? yaw, float? roll,
			float? aspect, float? fov,
			float? nearClip, float? farClip)
		{
			_position = position ?? _position;
			_pitch = pitch ?? _pitch;
			_yaw = yaw ?? _yaw;
			_roll = roll ?? _roll;
			_aspectRatio = aspect ?? _aspectRatio;

			_fov = fov switch
			{
				null => _fov,
				< 120.0f => (float)fov,
				_ => 120.0f
			};

			_nearClip = nearClip ?? _nearClip;
			_farClip = farClip ?? _farClip;

			UpdateAllInternal();
		}
		private void UpdateAllInternal()
		{
			UpdateViewMatrix();
			UpdateProjectionMatrix();
			Frustum.Update(
				Position,
				Front, Right, Up,
				Fov, AspectRatio,
				NearClip, FarClip,
				Culling);
		}

		public void UpdateProjectionMatrix()
		{
			ProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(
				MathUtilities.DegreesToRadians(Fov), AspectRatio,
				NearClip, FarClip);
		}

		private readonly IList<Polygon> _visiblePolygons = new List<Polygon>();
		public IList<Polygon> GetVisiblePolygons(Renderable renderable)
		{
			return GetVisiblePolygons(new List<Renderable>() { renderable });
		}
		public IList<Polygon> GetVisiblePolygons(IEnumerable<Renderable> renderables)
		{
			_visiblePolygons.Clear();

			foreach (Renderable r in renderables)
			{
				if (!CanSee(r))
				{
					continue;
				}

				// TODO: Replace HasFlag with my own version! The Enum method is
				// apparently slower than molasses on account of some safety checks
				// that aren't necessary in my case.
				if (Culling.HasFlag(Culling.Backface))
				{
					foreach (Polygon p in r.Polygons)
					{
						Vector3 point = p.Vertices[0];
						Vector3 transformed = Vector3.Transform(point, r.ModelMatrix);
						Vector3 toPoint = transformed - Position;

						if (Vector3.Dot(toPoint, p.Normal) <= 0.0f)
						{
							_visiblePolygons.Add(p);
						}
					}
				}
				else
				{
					foreach (Polygon p in r.Polygons)
					{
						// Keeping backfaces at the start of the list makes sure
						// they're drawn first, and won't overdraw any colored
						// edges when rendering as wireframes.
						_visiblePolygons.Insert(0, p);
					}
				}
			}

			return _visiblePolygons;
		}

		private readonly IList<Line> _visibleLines = new List<Line>();
		public IList<Line> GetVisibleLines(Line line)
		{
			return GetVisibleLines(new List<Line>() { line });
		}
		public IList<Line> GetVisibleLines(IList<Line> lines)
		{
			_visibleLines.Clear();

			for (int i = 0; i < lines.Count; i++)
			{
				Line l = lines[i];

				if (CanSee(l))
				{
					_visibleLines.Add(l);
				}
			}

			return _visibleLines;
		}

		public void Clear()
		{
			_visiblePolygons.Clear();
		}

		public bool ClipLineAgainstFrustum(ref Line line)
		{
			return ClipLineAgainstPlanes(ref line, Frustum.Planes);
		}

		public Polygon ClipPolygonAgainstFrustum(Polygon polygon)
		{
			return ClipPolygonAgainstPlanes(polygon, Frustum.Planes);
		}
		public static Polygon ClipPolygonAgainstPlanes(Polygon polygon, IEnumerable<Plane> planes)
		{
			var p = new Polygon(polygon);

			foreach (Plane plane in planes)
			{
				p.ClipAgainstPlane(plane);

				if (p.Vertices.Count == 0)
				{
					break;
				}
			}

			// Just a quick and dirty hack job to mark edges that should be
			// invisible, namely those that lie exactly on a plane. Without
			// this, polygons clipped to the view frustum would have their
			// line loops closed inappropriately, giving the impression of
			// edges where there are no edges.
			for (int i = 0; i < p.Edges.Count; i++)
			{
				(int idxA, int idxB, bool _) = p.Edges[i];

				Vertex a = p.Vertices[idxA];
				Vertex b = p.Vertices[idxB];

				bool visible = true;
				foreach (Plane plane in planes)
				{
					Vector3 point = plane.A;
					Vector3 n = plane.Normal;

					float distanceA = Vector3.Dot(a.Position - point, n);
					float distanceB = Vector3.Dot(b.Position - point, n);

					float epsilon = 0.0001f;
					bool aBehind = distanceA <= 0.0f + epsilon;
					bool bBehind = distanceB <= 0.0f + epsilon;

					if (aBehind && bBehind)
					{
						visible = false;
						break;
					}
				}

				p.Edges[i] = (idxA, idxB, visible);
			}

			return p;
		}

		public static bool ClipLineAgainstPlanes(ref Line line, IEnumerable<Plane> planes)
		{
			bool visible = true;

			foreach (Plane plane in planes)
			{
				visible = ClipLineAgainstPlane(ref line, plane);
				if (!visible)
				{
					break;
				}
			}

			return visible;
		}

		// Credit to Nils Pipenbrinck aka Submissive/Cubic & $eeN for this!
		// https://www.cubic.org/docs/3dclip.htm
		public static bool ClipLineAgainstPlane(ref Line line, Plane plane)
		{
			Vector3 p = plane.A;
			Vector3 n = plane.Normal;

			float distanceA = Vector3.Dot(line.A - p, n);
			float distanceB = Vector3.Dot(line.B - p, n);

			bool aBehind = distanceA <= 0.0f;
			bool bBehind = distanceB <= 0.0f;

			if (aBehind && bBehind)
			{
				return false;
			}

			if (!aBehind && !bBehind)
			{
				return true;
			}

			float factor = distanceA / (distanceA - distanceB);

			Vector3 intersection = line.A + (line.B - line.A) * factor;

			if (aBehind)
			{
				line.A = new Vertex(line.A) { Position = intersection };
				return true;
			}
			else
			{
				line.B = new Vertex(line.B) { Position = intersection };
				return true;
			}
		}
	}
}
