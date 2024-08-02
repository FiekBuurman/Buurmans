using System.Drawing;
using Buurmans.Common.Extensions;

namespace Buurmans.UnitTests
{
	[TestFixture]
	public class ColorExtensionsUnitTests
	{
		[Test]
		public void ToRgbString_WhenColorIsFromArgb_ShouldReturnCorrectString()
		{
			// Arrange
			var color = Color.FromArgb(255, 128, 64);

			// Act
			var result = color.ToRgbString();
			const string expected = "Color [R=255, G=128, B=64]";

            // Assert
			Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void ToRgbString_WhenColorIsEmpty_ShouldHandleDefaultColor()
		{
			// Arrange
			var color = Color.Empty;

			// Act
			var result = color.ToRgbString();
			const string expected = "Color [R=0, G=0, B=0]";

            // Assert
            Assert.That(result, Is.EqualTo(expected));
		}

		[Test]
		public void ToRgbString_WhenColorIsNamed_ShouldReturnCorrectStringForNamedColor()
		{
			// Arrange
			var color = Color.Red;

			// Act
			var result = color.ToRgbString();
			const string expected = "Color [R=255, G=0, B=0]";

            // Assert
            Assert.That(result, Is.EqualTo(expected));
		}
	}
}