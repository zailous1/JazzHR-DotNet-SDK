using FluentAssertions;
using Zailous.JazzHR.Models;
using Zailous.JazzHR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetJobsAsync_ReturnsExpectedResult_WhenVarsAreProvided()
        {
            // Arrange
            var vars = new JobsVars { Title = "Test Job", City = "New York" };
            var expected = new List<JobDetail>
            {
                new JobDetail { Id = "1", Title = "Test Job", City = "New York", JobApplicants = new List<JobApplicant>() },
                new JobDetail { Id = "2", Title = "Test Job 2", City = "New York", JobApplicants = new List<JobApplicant>() }
            };

            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("jobs/title/Test Job/city/New York/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetJobsAsync(vars);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetJobsAsync_ThrowsExceptionAndLogsError_WhenAnErrorOccurs()
        {
            // Arrange
            var vars = new JobsVars { Title = "Test Job" };
            _httpClientMock.Setup(c => c.GetAsync(It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.GetJobsAsync(vars),
                "An error occurred while retrieving jobs",
                _loggerMock);
        }

        [TestMethod]
        public async Task GetJobsAsync_WithoutParameters_ReturnsExpectedResult()
        {
            // Arrange
            var expected = new List<JobDetail>
            {
                new JobDetail { Id = "1", Title = "Test Job 1", City = "New York", JobApplicants = new List<JobApplicant>()  },
                new JobDetail { Id = "2", Title = "Test Job 2", City = "Los Angeles", JobApplicants = new List<JobApplicant>()  }
            };

            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("jobs/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetJobsAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetJobsAsync_WithoutParameters_ReturnsEmptyList_WhenNoJobsAreFound()
        {
            // Arrange
            var expected = new List<JobDetail>();

            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync(It.IsAny<string>())).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetJobsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetJobsAsync_WithoutParameters_ThrowsExceptionAndLogsError_WhenAnErrorOccurs()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync(It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.GetJobsAsync(),
                "An error occurred while retrieving jobs",
                _loggerMock);
        }

    }
}

