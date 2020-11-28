using System;
using System.Collections.Generic;
using System.Numerics;

namespace SHME.ExternalTool
{
	public enum CullMode
	{
		None,
		Back
	}

	public class Frustum
	{
		public Vector3 NearTopLeft { get; set; } = new Vector3();
		public Vector3 NearTopRight { get; set; } = new Vector3();
		public Vector3 NearBottomLeft { get; set; } = new Vector3();
		public Vector3 NearBottomRight { get; set; } = new Vector3();

		public Vector3 FarTopLeft { get; set; } = new Vector3();
		public Vector3 FarTopRight { get; set; } = new Vector3();
		public Vector3 FarBottomLeft { get; set; } = new Vector3();
		public Vector3 FarBottomRight { get; set; } = new Vector3();

		public double MaxAngleH { get; set; } = 180.0;
		public double MaxAngleV { get; set; } = 180.0;

		public Plane Left { get; private set; }
		public Plane Right { get; private set; }
		public Plane Top { get; private set; }
		public Plane Bottom { get; private set; }
		public Plane Near { get; private set; }
		public Plane Far { get; private set; }

		public List<Plane> Planes { get; } = new List<Plane>();

		public Frustum()
		{
			Update(
				new Vector3(0.0f), new Vector3(0.0f, 0.0f, -1.0f), new Vector3(1.0f, 0.0f, 0.0f), new Vector3(0.0f, 1.0f, 0.0f),
				75.0f, 1.0f, 0.01f, 1.0f);
		}
		public Frustum(
			Vector3 position, Vector3 front, Vector3 right, Vector3 up,
			float fov, float aspect, float near, float far)
		{
			Update(position, front, right, up, fov, aspect, near, far);
		}

		public bool Contains(Aabb aabb)
		{
			bool contains = true;

			foreach (Plane p in Planes)
			{
				bool allPointsInFront = true;

				foreach (Vector3 point in aabb.Points)
				{
					float dot = Vector3.Dot(p.Normal, point - p.Points[0]);
					
					if (dot <= 0.0)
					{
						allPointsInFront = false;
						break;
					}
				}

				if (allPointsInFront)
				{
					contains = false;
					break;
				}
			}

			return contains;
		}

		public void Update(Vector3 position, Vector3 front, Vector3 right, Vector3 up, float fov, float aspect, float near, float far)
		{
			Vector3 nearTarget = position + (front * near);
			Vector3 farTarget = position + (front * far);

			float nearHalfWidth = GetHalf(fov * aspect, near);
			float nearHalfHeight = GetHalf(fov, near);

			float farHalfWidth = GetHalf(fov * aspect, far);
			float farHalfHeight = GetHalf(fov, far);

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

			Left = new Plane(NearTopLeft, FarTopLeft, FarBottomLeft, Winding.Ccw);
			Right = new Plane(NearTopRight, NearBottomRight, FarBottomRight, Winding.Ccw);
			Top = new Plane(NearTopLeft, NearTopRight, FarTopRight, Winding.Ccw);
			Bottom = new Plane(NearBottomRight, NearBottomLeft, FarBottomLeft, Winding.Ccw);
			Near = new Plane(NearTopLeft, NearBottomLeft, NearBottomRight, Winding.Ccw);
			Far = new Plane(FarBottomRight, FarBottomLeft, FarTopLeft, Winding.Ccw);

			Planes.Clear();
			Planes.Add(Left);
			Planes.Add(Right);
			Planes.Add(Top);
			Planes.Add(Bottom);
			Planes.Add(Near);
			Planes.Add(Far);

			MaxAngleH = GetRemainingAngle((fov * aspect) / 2.0f);
			MaxAngleV = GetRemainingAngle(fov / 2.0f);
		}

		private static float GetHalf(float fov, float distance)
		{
			float half = fov / 2.0f;

			// The angle where the view direction hits a clip plane is 90
			// degrees, and a triangle's angles add up to 180.
			float remaining = GetRemainingAngle(half);

			float factor = distance / (float)Math.Sin(MathUtilities.DegreesToRadians(remaining));
			return (float)Math.Sin(MathUtilities.DegreesToRadians(half)) * factor;
		}

		private static float GetRemainingAngle(float angle)
		{
			return 90.0f - angle;
		}
	}

	public class Camera
	{
		private float _aspectRatio;
		public float AspectRatio
		{
			get { return _aspectRatio; }
			set
			{
				_aspectRatio = value;

				UpdateProjectionMatrix();
			}
		}

		private float _fov;
		/// <summary>
		/// The vertical field of view of this camera, in degrees.
		/// </summary>
		public float Fov
		{
			get { return _fov; }
			set
			{
				if (value > 120.0f)
				{
					_fov = 120.0f;
				}
				else
				{
					_fov = value;

					UpdateProjectionMatrix();
				}
			}
		}

		private float _maxPitch = 360.0f;
		public float MaxPitch
		{
			get { return _maxPitch; }
			set { _maxPitch = MathUtilities.ModAngleToCircleSigned(value); }
		}

		private float _minPitch = -360.0f;
		public float MinPitch
		{
			get { return _minPitch; }
			set { _minPitch = MathUtilities.ModAngleToCircleSigned(value); }
		}

		private float _nearClip;
		public float NearClip
		{
			get { return _nearClip; }
			set
			{
				_nearClip = value;
				UpdateProjectionMatrix();
			}
		}
		private float _farClip;
		public float FarClip
		{
			get { return _farClip; }
			set
			{
				_farClip = value;
				UpdateProjectionMatrix();
			}
		}

		private Vector3 _position;
		/// <summary>
		/// This camera's position in Y-up, right-handed coordinates.
		/// </summary>
		public Vector3 Position
		{
			get { return _position; }
			set
			{
				_position = value;
				Rotate();
			}
		}

		private float _pitch;
		public float Pitch
		{
			get { return _pitch; }
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

				Rotate();
			}
		}

		private float _yaw;
		public float Yaw
		{
			get { return _yaw; }
			set
			{
				_yaw = MathUtilities.ModAngleToCircleUnsigned(value);

				Rotate();
			}
		}

		private float _roll;
		public float Roll
		{
			get { return _roll; }
			set
			{
				_roll = MathUtilities.ModAngleToCircleSigned(value);

				Rotate();
			}
		}

		public CullMode CullMode { get; set; } = CullMode.Back;

		public Frustum Frustum { get; } = new Frustum();

		public Matrix4x4 ViewMatrix { get; private set; }
		public Matrix4x4 ProjectionMatrix { get; set; }

		private Vector3 WorldUp;
		public Vector3 Front;
		private Vector3 Right;
		private Vector3 Up;

		public Camera()
		{
			// TODO: Fix this! SH has a value in memory that gets read into what
			// the GTE docs call the "projection plane distance" register, but
			// it defaults to 0xE0 (224, the framebuffer height). Need to dig
			// deeper into the code with Ghidra, see how the value is used.
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

			UpdateProjectionMatrix();

			Frustum = new Frustum(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
		}

		public bool CanSee(Renderable r)
		{
			return Frustum.Contains(r.Aabb);
		}

		public void LookAt(Vector3 target)
		{
			ViewMatrix = Matrix4x4.CreateLookAt(Position, target, Up);

			UpdateProjectionMatrix();
		}

		public void Rotate()
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

			Frustum.Update(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
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

		public void UpdateProjectionMatrix()
		{
			ProjectionMatrix = Matrix4x4.CreatePerspectiveFieldOfView(MathUtilities.DegreesToRadians(Fov), AspectRatio, NearClip, FarClip);

			Frustum.Update(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
		}

		private readonly List<(Polygon, Renderable)> _visiblePolygons = new List<(Polygon, Renderable)>();
		public List<(Polygon, Renderable)> GetVisiblePolygons(Renderable renderable)
		{
			return GetVisiblePolygons(new List<Renderable>() { renderable });
		}
		public List<(Polygon, Renderable)> GetVisiblePolygons(IEnumerable<Renderable> renderables)
		{
			_visiblePolygons.Clear();

			foreach (Renderable r in renderables)
			{
				if (!CanSee(r))
				{
					continue;
				}

				foreach (Polygon p in r.Polygons)
				{
					Vector3 point = r.Vertices[p.Indices[0]];
					Vector3 transformed = Vector3.Transform(point, r.ModelMatrix);
					Vector3 toPoint = transformed - Position;

					if (Vector3.Dot(toPoint, p.Normal) < 0.0f)
					{
						_visiblePolygons.Add((p, r));
					}
					else if (CullMode == CullMode.None)
					{
						// Keeping backfaces at the start of the list makes sure
						// they're drawn first, and won't overdraw any colored
						// edges when rendering as wireframes.
						_visiblePolygons.Insert(0, (p, r));
					}
				}
			}

			return _visiblePolygons;
		}

		public void Clear()
		{
			_visiblePolygons.Clear();
		}
	}
}
