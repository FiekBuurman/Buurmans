using Buurmans.Common.Extensions;
using System.Net;

namespace Buurmans.UnitTests;

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
	
	[Test]
	public void FlattenException_ShouldIncludeMessageAndSource_WhenExceptionIsProvided()
	{
		// Arrange
		var exception = new Exception("Test exception message");

		// Act
		var result = exception.FlattenException();

		// Assert
		Assert.That(result, Does.Contain("Message    :\tTest exception message"));
	}

	[Test]
	public void FlattenException_ShouldIncludeInnerException()
	{
		// Arrange
		var innerException = new Exception("Inner exception message");
		var exception = new Exception("Outer exception message", innerException);

		// Act
		var result = exception.FlattenException();

		// Assert
		Assert.That(result, Does.Contain("Inner exception message"));
		Assert.That(result, Does.Contain("Outer exception message"));
	}

	[Test]
	public void FlattenException_ShouldHandleExceptionWithoutSourceOrTargetSite()
	{
		// Arrange
		var exception = new Exception("Test exception message");

		// Act
		var result = exception.FlattenException();

		// Assert
		Assert.That(result, Does.Contain("No Source!"));
		Assert.That(result, Does.Contain("No Method!"));
	}

	[Test]
	public void FlattenException_ShouldHandleExceptionWithStackTrace()
	{
		// Arrange
		try
		{
			throw new Exception("Exception with stack trace");
		}
		catch (Exception ex)
		{
			// Act
			var result = ex.FlattenException();

			// Assert
			Assert.That(result, Does.Contain("Stacktrace :\t"));
		}
	}

	[Test]
	public void FlattenException_ShouldIncludeCurrentDateAndTime()
	{
		// Arrange
		var exception = new Exception("Test exception message");

		// Act
		var result = exception.FlattenException();
		var currentDate = DateTime.Now.ToLongDateString();
		var currentTime = DateTime.Now.ToLongTimeString();

		// Assert
		Assert.That(result, Does.Contain($"{currentDate}:\tTime    :\t{currentTime}"));
	}

	[Test]
	public void FlattenException_ShouldIncludeComputerName()
	{
		// Arrange
		var exception = new Exception("Test exception message");

		// Act
		var result = exception.FlattenException();
		var computerName = Dns.GetHostName();

		// Assert
		Assert.That(result, Does.Contain($"Computer    :\t{computerName}"));
	}
}