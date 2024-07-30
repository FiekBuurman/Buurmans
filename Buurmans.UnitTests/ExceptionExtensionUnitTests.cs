using Buurmans.Common.Extensions;

namespace Buurmans.UnitTests
{
    public class ExceptionExtensionUnitTests
    {
		private const string ExceptionMessage = "Test message";
		private const string ExceptionSource = "Test source";

        [Test]
		public void FlattenException_WhenExceptionIsNull_ShouldReturnEmptyString()
		{
            // Arrange
			var expected = string.Empty;

			// Act
			var actual = ExceptionExtension.FlattenException(null);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void FlattenException_WithSingleException_ShouldReturnFormattedString()
		{
			// Arrange
			var exception = new Exception(ExceptionMessage) { Source = ExceptionSource };
			var expectedMessage = ExceptionMessage;
			var expectedSource = ExceptionSource;

            // Act
            var result = exception.FlattenException();

			// Assert
			Assert.That(result.Contains(expectedMessage), $"Expected to contain: \"{expectedMessage}\" in: \r{result}");
			Assert.That(result.Contains(expectedSource), $"Expected to contain: \"{expectedSource}\" in: \r{result}");
		}
    }
}