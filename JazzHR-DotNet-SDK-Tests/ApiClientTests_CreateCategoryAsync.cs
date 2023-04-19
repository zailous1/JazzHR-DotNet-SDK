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
        public async Task CreateCategoryAsync_ReturnsExpectedCreateCategoryResponse_WhenRequestIsValid()
        {
            // Arrange
            var createCategoryRequest = new CreateCategoryRequest("TestCategory", true);
            var expected = new CreateCategoryResponse { CategoryId = new CategoryId { Id = "123" } };

            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.PostAsync("categories", It.IsAny<string>())).ReturnsAsync(json);

            // Act
            var result = await _apiClient.CreateCategoryAsync(createCategoryRequest);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task CreateCategoryAsync_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => _apiClient.CreateCategoryAsync(null));
        }

        [TestMethod]
        public async Task CreateCategoryAsync_ThrowsExceptionAndLogsError_WhenAnErrorOccurs()
        {
            // Arrange
            var createCategoryRequest = new CreateCategoryRequest("TestCategory", true);
            _httpClientMock.Setup(c => c.PostAsync("categories", It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                () => _apiClient.CreateCategoryAsync(createCategoryRequest),
                "An error occurred while creating a category",
                _loggerMock);
        }
    }
}

