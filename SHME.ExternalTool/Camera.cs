using OpenTK;
using System;
using System.Collections.Generic;

namespace SHME.ExternalTool
{
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

		public Aabb Bounds { get; private set; }

		public Frustum(
			Vector3 position, Vector3 front, Vector3 right, Vector3 up,
			float fov, float aspect, float near, float far)
		{
			Update(position, front, right, up, fov, aspect, near, far);
		}

		public bool Contains(Aabb aabb)
		{
			// Note the component swap! Not the swap of Y and Z, that's only due
			// to the difference in up axis between objects in world space and
			// the camera's coordinate system. The swap of Max.Y and Min.Y for
			// the new min/max, however, is thanks to switching left-handed 
			// coordinates to right-handed; that flips the sign of the camera's
			// lens axis, so the old min and max become the new max and min.
			bool outsideX = aabb.Max.X < Bounds.Min.X || aabb.Min.X > Bounds.Max.X;
			bool outsideY = aabb.Max.Z < Bounds.Min.Y || aabb.Min.Z > Bounds.Max.Y;
			bool outsideZ = -aabb.Min.Y < Bounds.Min.Z || -aabb.Max.Y > Bounds.Max.Z;

			return !(outsideX || outsideY || outsideZ);
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

			Bounds = new Aabb(
				NearTopLeft,
				NearTopRight,
				NearBottomLeft,
				NearBottomRight,
				FarTopLeft,
				FarTopRight,
				FarBottomLeft,
				FarBottomRight);

			MaxAngleH = GetRemainingAngle((fov * aspect) / 2.0f);
			MaxAngleV = GetRemainingAngle(fov / 2.0f);
		}

		private static float GetHalf(float fov, float distance)
		{
			float half = fov / 2.0f;

			// The angle where the view direction hits a clip plane is 90
			// degrees, and a triangle's angles add up to 180.
			float remaining = GetRemainingAngle(half);

			float factor = distance / (float)Math.Sin(MathHelper.DegreesToRadians(remaining));
			return (float)Math.Sin(MathHelper.DegreesToRadians(half)) * factor;
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
				WorldPosition = new Vector3(value.X, value.Z, -value.Y);
				Rotate();
			}
		}

		/// <summary>
		/// This camera's position in Z-up, left-handed coordinates.
		/// </summary>
		public Vector3 WorldPosition
		{
			get { return new Vector3(Position.X, -Position.Z, Position.Y); }
			private set { }
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

		public Frustum Frustum { get; }

		public Matrix4 ViewMatrix { get; private set; }
		public Matrix4 ProjectionMatrix { get; set; }

		private Vector3 WorldUp;
		public Vector3 Front;
		private Vector3 Right;
		private Vector3 Up;

		public Camera()
		{
			// TODO: Fix this! SH doesn't seem to have FOV in any particular
			// form, so I'll be trying to calculate it from the number it
			// gives me, which I've tentatively assumed is the focal length in
			// game units. Fingers crossed.
			_fov = 75.0f;

			// Silent Hill uses a 256x448 frame buffer, but stretches that to
			// 640 width on display, apparently (according to an EmuHawk screen
			// capture, examined in IrfanView).
			_aspectRatio = 640.0f / 448.0f;

			// Hopefully this is enough for Silent Hill, since one unit is the
			// size of one sidewalk paver in fogworld.
			_nearClip = 0.01f;
			_farClip = 128.0f;

			WorldUp = new Vector3(0.0f, 1.0f, 0.0f);
			Position = new Vector3(0.0f, 0.0f, 0.0f);

			Pitch = 0.0f;
			//Yaw = -90.0f;
			Yaw = 0.0f;
			Roll = 0.0f;

			UpdateProjectionMatrix();

			Frustum = new Frustum(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
		}

		public bool CanSee(Renderable r)
		{
			return Frustum.Contains(r.Aabb);
		}

		public void Rotate()
		{
			// TODO: Hook up Roll. Not critical, but nice to have.
			float yawRad = MathHelper.DegreesToRadians(Yaw);
			float pitchRad = MathHelper.DegreesToRadians(Pitch);

			Front.X = Convert.ToSingle(Math.Cos(pitchRad) * Math.Cos(yawRad));
			Front.Y = Convert.ToSingle(Math.Sin(pitchRad));
			Front.Z = Convert.ToSingle(Math.Cos(pitchRad) * Math.Sin(yawRad));

			Front.Normalize();

			Right = Vector3.Normalize(Vector3.Cross(Front, WorldUp));
			Up = Vector3.Normalize(Vector3.Cross(Right, Front));

			ViewMatrix = Matrix4.LookAt(Position, Position + Front, Up);

			Frustum?.Update(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
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
			ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(Fov), AspectRatio, NearClip, FarClip);

			Frustum?.Update(Position, Front, Right, Up, Fov, AspectRatio, NearClip, FarClip);
		}

		private List<(Polygon, Renderable)> _visiblePolygons = new List<(Polygon, Renderable)>();
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
					// OpenGL offers its own backface culling, if it's enabled, but
					// that only does its work after a draw call. Letting cameras
					// check ahead of time allows skipping the setup of those calls.
					Vector3 point = r.Vertices[p.Indices[0]];
					var yUpRightHand = new Vector4(point.X, point.Z, -point.Y, 1.0f);
					Vector4 transformed = yUpRightHand * r.ModelMatrix;
					var zUpLeftHand = new Vector3(transformed.X, -transformed.Z, transformed.Y);
					Vector3 toPoint = WorldPosition - new Vector3(zUpLeftHand);

					if (Vector3.Dot(toPoint, p.Normal) > 0.0f)
					{
						_visiblePolygons.Add((p, r));
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
