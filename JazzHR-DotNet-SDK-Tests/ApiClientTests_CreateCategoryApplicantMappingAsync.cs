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
        public async Task CreateCategoryApplicantMappingAsync_ReturnsExpectedResult_WhenRequestIsValid()
        {
            // Arrange
            var request = new CreateCategoryApplicantMappingRequest("applicantId", "categoryId");
            var response = new CreateCategoryApplicantMappingResponse { Pro2catId = 12345 };
            var json = JsonConvert.SerializeObject(response);
            _httpClientMock.Setup(c => c.PostAsync("categories2applicants", It.IsAny<string>())).ReturnsAsync(json);

            // Act
            var result = await _apiClient.CreateCategoryApplicantMappingAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Pro2catId.Should().Be(response.Pro2catId);
        }

        [TestMethod]
        public async Task CreateCategoryApplicantMappingAsync_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            // Act & Assert
            Func<Task> action = async () => await _apiClient.CreateCategoryApplicantMappingAsync(null!);
            await action.Should().ThrowAsync<Exception>().WithMessage("*request*");
        }

        [TestMethod]
        public async Task CreateCategoryApplicantMappingAsync_ThrowsExceptionAndLogsError_WhenApiCallFails()
        {
            // Arrange
            var request = new CreateCategoryApplicantMappingRequest("applicantId", "categoryId");
            _httpClientMock.Setup(c => c.PostAsync("categories2applicants", It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.CreateCategoryApplicantMappingAsync(request),
                "An error occurred while creating category applicant mapping",
                _loggerMock);
        }

    }
}

