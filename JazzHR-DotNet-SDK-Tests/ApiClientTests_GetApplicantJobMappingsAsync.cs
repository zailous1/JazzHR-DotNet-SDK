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
        public async Task GetApplicantJobMappingAsync_ReturnsApplicantJobMapping_WhenSuccessful()
        {
            // Arrange
            var expected = new ApplicantJobMapping
            {
                Id = "1",
                ApplicantId = "1",
                JobId = "1",
                Rating = "4",
                WorkflowStepId = "1",
                Date = "2023-01-01"
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetApplicantJobMappingAsync("1");

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(expected.Id);
            result.ApplicantId.Should().Be(expected.ApplicantId);
            result.JobId.Should().Be(expected.JobId);
            result.Rating.Should().Be(expected.Rating);
            result.WorkflowStepId.Should().Be(expected.WorkflowStepId);
            result.Date.Should().Be(expected.Date);
        }

        [TestMethod]
        public async Task GetApplicantJobMappingAsync_ReturnsNull_WhenResponseIsNullOrEmpty()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs/1")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetApplicantJobMappingAsync("1");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task GetApplicantJobMappingAsync_ThrowsException_WhenApiCallFails()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs/1")).ThrowsAsync(new HttpRequestException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetApplicantJobMappingAsync("1"));
        }

    }
}

