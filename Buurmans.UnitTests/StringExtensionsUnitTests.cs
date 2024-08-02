using System.Globalization;
using Buurmans.Common.Extensions;

namespace Buurmans.UnitTests;

[TestFixture]
public class StringExtensionsTests
{
	[Test]
	public void AddTimePrefix_ShouldStartWithTimePrefix()
	{
		// Arrange
		const string info = "Test info";
		const string pattern = @"^\[\d{2}:\d{2}:\d{2}\.\d{2}\] - ";

		// Act
		var result = info.AddTimePrefix();

		// Assert
		Assert.That(result, Does.Match(pattern));
	}

	[Test]
	public void AddTimePrefix_ShouldContainOriginalString()
	{
		// Arrange
		const string info = "Test info";

		// Act
		var result = info.AddTimePrefix();

		// Assert
		Assert.That(result, Does.EndWith(info));
	}

	[Test]
	public void AddTimePrefix_ShouldCorrectlyFormatTimePrefix()
	{
		// Arrange
		const string info = "Test info";
		var now = DateTime.Now;
		var expectedPrefix = now.ToString("[HH:mm:ss.ff] - ", CultureInfo.InvariantCulture);

		// Act
		var result = info.AddTimePrefix();

		// Assert
		Assert.That(result[..12], Does.StartWith(expectedPrefix[..12]));
	}
}