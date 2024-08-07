using NUnit.Framework;
using SHME.ExternalTool;
using System.Diagnostics.CodeAnalysis;

namespace GutsTest;

[ExcludeFromCodeCoverage]
public class SilentHillTypeTest
{
	float Tolerance { get; } = 0.001f;

	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void CameraPathTest()
	{
		byte[] expected = [
			0x58, 0x01, 0xE0, 0x01,
			0xC0, 0x08, 0xA0, 0x09,
			0x88, 0x01, 0x88, 0x01,
			0xD3, 0x08, 0xA0, 0x09,
			0x00, 0x02, 0xEF, 0xEF,
			0xE7, 0x00, 0x00, 0x00];

		CameraPath c = new(0x800C9D80, expected);

		Assert.Multiple(() =>
		{
			Assert.That(c.Address, Is.EqualTo(0x800C9D80));
			Assert.That(c.Disabled, Is.False);

			Assert.That(c.VolumeMin.X, Is.EqualTo(24.5f).Within(Tolerance));
			Assert.That(c.VolumeMin.Y, Is.EqualTo(-1.0625f).Within(Tolerance));
			Assert.That(c.VolumeMin.Z, Is.EqualTo(141.1875f).Within(Tolerance));

			Assert.That(c.VolumeMax.X, Is.EqualTo(24.5f).Within(Tolerance));
			Assert.That(c.VolumeMax.Y, Is.EqualTo(-1.0625f).Within(Tolerance));
			Assert.That(c.VolumeMax.Z, Is.EqualTo(154.0f).Within(Tolerance));

			Assert.That(c.AreaMinX, Is.EqualTo(21.5f).Within(Tolerance));
			Assert.That(c.AreaMinZ, Is.EqualTo(140.0f).Within(Tolerance));

			Assert.That(c.AreaMaxX, Is.EqualTo(30.0f).Within(Tolerance));
			Assert.That(c.AreaMaxZ, Is.EqualTo(154.0f).Within(Tolerance));

			Assert.That(c.Thing4, Is.EqualTo(0x00));
			Assert.That(c.Thing5, Is.EqualTo(0x02));
			Assert.That(c.Thing6, Is.EqualTo(0x00E7));

			Assert.That(c.Pitch, Is.EqualTo(0.0f).Within(Tolerance));
			Assert.That(c.Yaw, Is.EqualTo(0.0f).Within(Tolerance));

			Assert.That(c.ToBytes().ToArray(), Is.EqualTo(expected));
		});

		byte[] disabledExpected = [
			0x58, 0x01, 0xE0, 0x01,
			0xC0, 0x08, 0xA0, 0x09,
			0x88, 0x01, 0x88, 0x01,
			0xD3, 0x08, 0xA0, 0x09,
			0x40, 0x02, 0xEF, 0xEF,
			0xE7, 0x00, 0x00, 0x00];

		c.Disabled = true;

		Assert.Multiple(() =>
		{
			Assert.That(c.Disabled, Is.True);
			Assert.That(c.Thing4, Is.EqualTo(0x40));
			Assert.That(c.ToBytes().ToArray(), Is.EqualTo(disabledExpected));
		});

		c.Thing4 = 0x00;

		Assert.Multiple(() =>
		{
			Assert.That(c.Disabled, Is.False);
			Assert.That(c.Thing4, Is.EqualTo(0x00));
			Assert.That(c.ToBytes().ToArray(), Is.EqualTo(expected));
		});
	}

	[Test]
	public void PointOfInterestTest()
	{
		byte[] expected = [
			0xCD, 0x9C, 0xFF, 0xFF,
			0x00, 0x00, 0x04, 0x04,
			0x00, 0x08, 0x0A, 0x00];

		PointOfInterest p = new(0x800DF368, expected);

		Assert.Multiple(() =>
		{
			Assert.That(p.Address, Is.EqualTo(0x800DF368));
			Assert.That(p.X, Is.EqualTo(-6.2).Within(Tolerance));
			Assert.That(p.Geometry, Is.EqualTo(0x4040000));
			Assert.That(p.Z, Is.EqualTo(160.5).Within(Tolerance));

			Assert.That(p.ToBytes().ToArray(), Is.EqualTo(expected));
		});
	}

	[Test]
	public void StageTest()
	{
		byte[] expected = [
			0xDE, 0xAD, 0xBE, 0xEF];

		Stage s = new(0x800C9578, expected);

		Assert.Multiple(() =>
		{
			Assert.That(s.Address, Is.EqualTo(0x800C9578));
			Assert.That(s.ToBytes().ToArray(), Is.EqualTo(expected));
		});
	}

	[Test]
	public void TriggerTest()
	{
		byte[] expected = [
			0x00, 0x00, 0x02, 0x00,
			0x01, 0x08, 0x00, 0x00,
			0x8A, 0x20, 0x00, 0x00];

		Trigger t = new(0x800DF76C, expected);

		Assert.Multiple(() =>
		{
			Assert.That(t.Address, Is.EqualTo(0x800DF76C));
			Assert.That(t.Disabled, Is.False);
			Assert.That(t.Thing0, Is.EqualTo(0x00));
			Assert.That(t.Thing1, Is.EqualTo(0x00));
			Assert.That(t.Fired, Is.False);
			Assert.That(t.FiredGroup, Is.EqualTo(0x00));
			Assert.That(t.Thing2, Is.EqualTo(0x00));
			Assert.That(t.Style, Is.EqualTo(TriggerStyle.TouchAabb));
			Assert.That(t.PoiIndex, Is.EqualTo(8));
			Assert.That(t.Thing3, Is.EqualTo(0x00));
			Assert.That(t.Thing4, Is.EqualTo(0x00));
			Assert.That(t.TriggerType, Is.EqualTo(TriggerType.Function1));
			Assert.That(t.TargetIndex, Is.EqualTo(4));
			Assert.That(t.Thing5, Is.EqualTo(0x01));
			Assert.That(t.Thing6, Is.EqualTo(0x00));
			Assert.That(t.StageIndex, Is.EqualTo(0));
			Assert.That(t.SomeBool, Is.False);

			Assert.That(t.ToBytes().ToArray(), Is.EqualTo(expected));
		});
	}
}
