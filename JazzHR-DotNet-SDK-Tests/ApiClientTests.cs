using FluentAssertions;
using Zailous.JazzHR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Zailous.JazzHR.Tests
{

    [TestClass]
    public partial class ApiClientTests
    {
        private readonly Mock<IHttpClient> _httpClientMock = new Mock<IHttpClient>();
        private readonly Mock<ILogger<JazzHRApiClient>> _loggerMock = new Mock<ILogger<JazzHRApiClient>>();
        private readonly JazzHRApiClientConfig _config;
        private readonly JazzHRApiClient _apiClient;

        public ApiClientTests()
        {
            _config = new JazzHRApiClientConfig("", "test_api_key", "");

            _apiClient = new JazzHRApiClient(_httpClientMock.Object, _config, _loggerMock.Object, maxPageResults: 2);
        }

        [TestMethod]
        public void ApiClient_DefaultConstructor_InitializesProperties()
        {
            // Arrange
            var httpClientMock = new Mock<IHttpClient>();
            var configuration = new JazzHRApiClientConfig("", "test_api_key", "");
            var loggerMock = new Mock<ILogger<JazzHRApiClient>>();

            // Act
            var apiClient = new JazzHRApiClient(httpClientMock.Object, configuration, loggerMock.Object);

            // Assert
            apiClient.Should().NotBeNull();
            apiClient.ApiKey.Should().Be("test_api_key");
            apiClient.MaxPageResults.Should().Be(JazzHRApiClient.DefaultMaxPageResults);
        }

        [TestMethod]
        public void ApiClient_OverloadedConstructor_InitializesProperties()
        {
            // Arrange
            var httpClientMock = new Mock<IHttpClient>();
            var configuration = new JazzHRApiClientConfig("", "test_api_key", "");
            var loggerMock = new Mock<ILogger<JazzHRApiClient>>();

            // Act
            var apiClient = new JazzHRApiClient(httpClientMock.Object, configuration, loggerMock.Object, 50);

            // Assert
            apiClient.Should().NotBeNull();
            apiClient.ApiKey.Should().Be("test_api_key");
            apiClient.MaxPageResults.Should().Be(50);
        }

        private async Task TestExceptionHandlingAndLogging(
            Func<Task> action,
            string expectedLogMessagePart,
            Mock<ILogger<JazzHRApiClient>> loggerMock
        )
        {
            var exception = new Exception("An error occurred");

            // Set up the logger to capture log messages
            loggerMock.Setup(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(expectedLogMessagePart)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>())
            );

            // Act & Assert
            await action.Should().ThrowAsync<Exception>().WithMessage("An error occurred");

            // Verify that the log method was called with the expected message
            loggerMock.Verify(
                l => l.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains(expectedLogMessagePart)),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }

        private class Foo
        {
            public string? Name { get; set; }
            public int Value { get; set; }
        }

    }
}