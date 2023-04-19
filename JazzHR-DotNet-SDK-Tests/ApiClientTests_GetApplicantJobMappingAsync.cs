using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Zailous.JazzHR.Models;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetApplicantJobMappingsAsync_ReturnsListOfApplicantJobMappings_WhenSuccessful()
        {
            // Arrange
            var expected = new List<ApplicantJobMapping>
            {
                new ApplicantJobMapping
                {
                    Id = "1",
                    ApplicantId = "1",
                    JobId = "1",
                    Rating = "4",
                    WorkflowStepId = "1",
                    Date = "2023-01-01"
                },
                new ApplicantJobMapping
                {
                    Id = "2",
                    ApplicantId = "2",
                    JobId = "2",
                    Rating = "5",
                    WorkflowStepId = "2",
                    Date = "2023-01-02"
                }
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs/applicant_id/1/job_id/1/rating/4/workflow_step_id/1/page/1")).ReturnsAsync(json);

            var vars = new ApplicantJobMappingVars
            {
                ApplicantId = "1",
                JobId = "1",
                Rating = 4,
                WorkflowStepId = "1"
            };

            // Act
            var result = await _apiClient.GetApplicantJobMappingsAsync(vars);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetApplicantJobMappingsAsync_ReturnsEmptyList_WhenNoMappingsExist()
        {
            // Arrange
            var json = JsonConvert.SerializeObject(new List<ApplicantJobMapping>());
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetApplicantJobMappingsAsync(null);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetApplicantJobMappingsAsync_ThrowsException_WhenApiCallFails()
        {
            // Arrange
            var exception = new Exception("API call failed");
            _httpClientMock.Setup(c => c.GetAsync("applicants2jobs/page/1")).ThrowsAsync(exception);

            // Act & Assert
            await _apiClient.Awaiting(apiClient => apiClient.GetApplicantJobMappingsAsync(null))
                .Should().ThrowAsync<Exception>()
                .WithMessage("API call failed");
        }

    }
}

