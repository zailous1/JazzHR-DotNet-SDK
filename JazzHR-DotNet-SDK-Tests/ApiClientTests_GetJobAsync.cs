using FluentAssertions;
using Zailous.JazzHR.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetJobAsync_ReturnsExpectedJobDetail_WhenJobExists()
        {
            // Arrange
            var jobId = "1";
            var expected = new JobDetail { Id = jobId, Title = "Test Job", City = "New York", JobApplicants = new List<JobApplicant>() };

            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync($"jobs/{jobId}")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetJobAsync(jobId);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetJobAsync_ReturnsNull_WhenJobDoesNotExist()
        {
            // Arrange
            var jobId = "1";
            _httpClientMock.Setup(c => c.GetAsync($"jobs/{jobId}")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetJobAsync(jobId);

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetJobAsync_ThrowsExceptionAndLogsError_WhenAnErrorOccurs()
        {
            // Arrange
            var jobId = "1";
            _httpClientMock.Setup(c => c.GetAsync($"jobs/{jobId}")).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.GetJobAsync(jobId),
                $"An error occurred while retrieving job detail for ID {jobId}",
                _loggerMock);
        }
    }
}

