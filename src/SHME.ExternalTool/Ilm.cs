using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using static SHME.ExternalTool.Utility;

namespace SHME.ExternalTool
{
	public class SubmeshHeader
	{
		public byte PolygonCount { get; }

		public byte VertexCount { get; }

		public byte Unknown1Count { get; }

		public byte Unknown2Count { get; }

		public long PolygonDataPointer { get; }

		public long VerticesXYPointer { get; }

		public long VerticesZPointer { get; }

		public long Unknown1Pointer { get; }

		public long Unknown2Pointer { get; }

		public SubmeshHeader(byte[] bytes)
		{
			int raw = BitConverter.ToInt32(bytes, 0);

			PolygonCount = (byte)(raw & 0xFF);
			VertexCount = (byte)((raw & 0xFF00) >> 8);
			Unknown1Count = (byte)((raw & 0xFF0000) >> 16);
			Unknown2Count = (byte)((raw & 0xFF000000) >> 24);

			PolygonDataPointer = BitConverter.ToInt32(bytes, 4);
			VerticesXYPointer = BitConverter.ToInt32(bytes, 8);
			VerticesZPointer = BitConverter.ToInt32(bytes, 12);
			Unknown1Pointer = BitConverter.ToInt32(bytes, 16);
			Unknown2Pointer = BitConverter.ToInt32(bytes, 20);
		}
	}

	public class Submesh
	{
		public long BaseAddress { get; }

		public int BoneID { get; }

		public string Name { get; }

		public bool Visible { get; }

		public long SubmeshHeaderPointer { get; }

		public SubmeshHeader Header { get; }

		public List<Vector3> Vertices { get; } = new List<Vector3>();

		public List<List<int>> PolygonIndices { get; } = new List<List<int>>();

		public float Scale { get; set; } = 1.0f;

		public Submesh(byte[] bytes, long baseAddress) : this(bytes, baseAddress, 1.0f)
		{
		}
		public Submesh(byte[] bytes, long baseAddress, float scale)
		{
			BaseAddress = baseAddress;
			Scale = scale;

			var utf = new UTF8Encoding();

			BoneID = Int32.Parse(utf.GetString(bytes, 0, 2));

			string name = utf.GetString(bytes, 2, 6);
			int nullIndex = name.IndexOf('\0');
			if (nullIndex >= 0)
			{
				name = name.Remove(nullIndex);
			}

			Name = name;

			Visible = (BitConverter.ToInt32(bytes, 8) & 0xFF) == 1;

			SubmeshHeaderPointer = BitConverter.ToInt32(bytes, 12);

			Header = new SubmeshHeader(bytes.Skip((int)(SubmeshHeaderPointer - BaseAddress)).ToArray());

			int verticesOffsetXY = (int)(Header.VerticesXYPointer - BaseAddress);
			int verticesOffsetZ = (int)(Header.VerticesZPointer - BaseAddress);
			for (int i = 0; i < Header.VertexCount; i++)
			{
				int offsetXY = verticesOffsetXY + (sizeof(int) * i);
				int offsetZ = verticesOffsetZ + (sizeof(short) * i);

				byte[] elementXY = bytes.Skip(offsetXY).Take(sizeof(int)).ToArray();
				byte[] elementZ = bytes.Skip(offsetZ).Take(sizeof(short)).ToArray();

				int x = (elementXY[1] << 8) | elementXY[0];
				int y = (elementXY[3] << 8) | elementXY[2];
				int z = (elementZ[1] << 8) | elementZ[0];

				var interpreted = new Vector3(
					(float)ScaleToRange((short)x, Int16.MinValue, Int16.MaxValue, -1.0, 1.0),
					(float)ScaleToRange((short)y, Int16.MinValue, Int16.MaxValue, -1.0, 1.0),
					(float)ScaleToRange((short)z, Int16.MinValue, Int16.MaxValue, -1.0, 1.0));

				Vertices.Add(interpreted * Scale);
			}
		}
	}

	public class IlmHeader
	{
		public static int Length { get; } = 20;

		public long BaseAddress { get; }

		/// <summary>
		/// ILM format identifier
		/// </summary>
		/// <remarks>Always 0x0630</remarks>
		public short ID { get; private set; }

		/// <summary>
		/// Whether this model has had its relative offsets replaced with absolute pointers. Happens on load.
		/// </summary>
		public bool MapFlag { get; }

		public byte TextureCount { get; }

		public long TexturePointer { get; }

		public int SubmeshCount { get; }

		public long SubmeshListPointer { get; }

		public long MeshDataPointer { get; }

		public IlmHeader(IReadOnlyList<byte> headerBytes, long baseAddress) : this(headerBytes.ToArray(), baseAddress)
		{
		}
		public IlmHeader(byte[] headerBytes, long baseAddress)
		{
			BaseAddress = baseAddress;

			int raw = BitConverter.ToInt32(headerBytes, 0);

			ID = (short)(raw & 0x0000FFFF);

			if (ID != 0x0630)
			{
				throw new ArgumentException("Byte array is not an ILM header!");
			}

			MapFlag = ((raw & 0x00FF0000) >> 16) == 1;
			TextureCount = (byte)((raw & 0xFF000000) >> 24);

			TexturePointer = BitConverter.ToInt32(headerBytes, 4);

			SubmeshCount = BitConverter.ToInt32(headerBytes, 8);
			SubmeshListPointer = BitConverter.ToInt32(headerBytes, 12);
			MeshDataPointer = BitConverter.ToInt32(headerBytes, 16);
		}
	}

	public class Ilm
	{
		public IlmHeader Header { get; }

		public List<string> Textures { get; } = new List<string>();

		public List<Submesh> Submeshes { get; } = new List<Submesh>();

		public IEnumerable<Vector3> Vertices => Submeshes.SelectMany(submesh => submesh.Vertices);

		public float Scale { get; set; } = 1.0f;

		public Ilm(IlmHeader h, IReadOnlyList<byte> bytes) : this(h, bytes.ToArray())
		{
		}
		public Ilm(IlmHeader h, IReadOnlyList<byte> bytes, float scale) : this(h, bytes.ToArray(), scale)
		{
		}
		public Ilm(IlmHeader h, byte[] bytes) : this(h, bytes.ToArray(), 1.0f)
		{
		}
		public Ilm(IlmHeader h, byte[] bytes, float scale)
		{
			Header = h;
			Scale = scale;

			int textureBase = (int)(Header.TexturePointer - Header.BaseAddress);
			int textureByteCount = sizeof(int) * 6;
			for (int i = 0; i < Header.TextureCount; i++)
			{
				int offset = textureBase + (textureByteCount * i);

				var utf = new UTF8Encoding();
				string raw = utf.GetString(bytes, offset, textureByteCount);

				// Each texture listing is 6 32-bit words, and though they start
				// out padded with zeroes in their file on disk, once loaded in
				// RAM they have other, as yet undeciphered data after the name.
				int nullIndex = raw.IndexOf('\0');
				if (nullIndex >= 0)
				{
					raw = raw.Remove(nullIndex);
				}
				Textures.Add(raw);
			}

			int submeshStartOffset = textureBase + (textureByteCount * Header.TextureCount);
			int submeshListingByteCount = 16;
			for (int i = 0; i < Header.SubmeshCount; i++)
			{
				int offset = submeshStartOffset + (submeshListingByteCount * i);

				var mesh = new Submesh(bytes.Skip(offset).ToArray(), Header.BaseAddress + offset, Scale);

				Submeshes.Add(mesh);
			}
		}
	}
}
