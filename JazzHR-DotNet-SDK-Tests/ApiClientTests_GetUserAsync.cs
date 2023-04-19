using FluentAssertions;
using Zailous.JazzHR;
using Zailous.JazzHR.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetUserAsync_ReturnsExpectedUserDetail_WhenIdIsValid()
        {
            // Arrange
            var id = "userId";
            var expectedUserDetail = new UserDetail
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Type = "user",
                DateCreated = "2023-04-18",
                UserActivity = new List<UserActivity> { new UserActivity { ActivityId = "activityId", Activity = "Test Activity" } }
            };
            var responseJson = JsonConvert.SerializeObject(expectedUserDetail);
            _httpClientMock.Setup(c => c.GetAsync($"users/{id}")).ReturnsAsync(responseJson);

            // Act
            var result = await _apiClient.GetUserAsync(id);

            // Assert
            result.Should().BeEquivalentTo(expectedUserDetail);
        }

        [TestMethod]
        public async Task GetUserAsync_ReturnsNull_WhenIdIsInvalid()
        {
            // Arrange
            var id = "invalidId";
            _httpClientMock.Setup(c => c.GetAsync($"users/{id}")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetUserAsync(id);

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetUserAsync_ThrowsExceptionAndLogsError_WhenGetAsyncFails()
        {
            // Arrange
            var id = "userId";
            _httpClientMock.Setup(c => c.GetAsync($"users/{id}")).ThrowsAsync(new Exception("An error occurred"));

            // Call the helper method with the appropriate action and expected log message
            await TestExceptionHandlingAndLogging(() => _apiClient.GetUserAsync(id), $"An error occurred while retrieving user {id}", _loggerMock);
        }



    }

}

