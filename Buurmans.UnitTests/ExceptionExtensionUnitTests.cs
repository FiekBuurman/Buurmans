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

			// Act
            var result = exception.FlattenException();

			// Assert
            Assert.Multiple(() =>
			{
				Assert.That(result, Does.Contain(ExceptionMessage), $"Expected to contain: \"{ExceptionMessage}\" in: \r{result}");
				Assert.That(result, Does.Contain(ExceptionSource), $"Expected to contain: \"{ExceptionSource}\" in: \r{result}");
            });
        }
    }
}