using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task DownloadResumeAsync_ReturnsExpectedResult_WhenUrlIsValid()
        {
            // Arrange
            var url = "https://example.com/resume.pdf";
            var expected = new byte[] { 1, 2, 3, 4, 5 };
            _httpClientMock.Setup(c => c.DownloadAsync(url)).ReturnsAsync(expected);

            // Act
            var result = await _apiClient.DownloadResumeAsync(url);

            // Assert
            result.Should().NotBeNull();
            result.Should().Equal(expected);
        }

        [TestMethod]
        public async Task DownloadResumeAsync_ThrowsExceptionAndLogsError_WhenDownloadFails()
        {
            // Arrange
            var url = "https://example.com/resume.pdf";
            _httpClientMock.Setup(c => c.DownloadAsync(url)).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.DownloadResumeAsync(url),
                $"Failed to download resume from {url}",
                _loggerMock);
        }

    }
}

