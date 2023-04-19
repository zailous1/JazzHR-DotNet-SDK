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
        public async Task GetUsersAsync_ReturnsExpectedUsers_WhenVarsAreValid()
        {
            // Arrange
            var usersVars = new UsersVars { Name = "Doe", Email = null, Type = "user" };
            var expectedUsers = new List<User>
            {
                new User
                {
                    Id = "user1",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Type = "user",
                    DateCreated = "2023-04-18"
                },
                new User
                {
                    Id = "user2",
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane.doe@example.com",
                    Type = "user",
                    DateCreated = "2023-04-19"
                }
            };
            var responseJson = JsonConvert.SerializeObject(expectedUsers);
            _httpClientMock.Setup(c => c.GetAsync($"users/name/Doe/type/user/page/1")).ReturnsAsync(responseJson);

            // Act
            var result = await _apiClient.GetUsersAsync(usersVars);

            // Assert
            result.Should().BeEquivalentTo(expectedUsers);
        }

        [TestMethod]
        public async Task GetUsersAsync_ReturnsEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var usersVars = new UsersVars { Name = "NonExisting", Email = null, Type = "user" };
            _httpClientMock.Setup(c => c.GetAsync("users/name/NonExisting/type/user")).ReturnsAsync("[]");

            // Act
            var result = await _apiClient.GetUsersAsync(usersVars);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetUsersAsync_ThrowsExceptionAndLogsError_WhenGetAsyncFails()
        {
            // Arrange
            var usersVars = new UsersVars { Name = "Doe", Email = null, Type = "user" };
            _httpClientMock.Setup(c => c.GetAsync("users/name/Doe/type/user/page/1")).ThrowsAsync(new Exception("An error occurred"));

            // Call the helper method with the appropriate action and expected log message
            await TestExceptionHandlingAndLogging(() => _apiClient.GetUsersAsync(usersVars), "An error occurred while retrieving users", _loggerMock);
        }

        [TestMethod]
        public async Task GetUsersAsync_ReturnsExpectedUsers_WhenApiCallSucceeds()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = "1", FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
                new User { Id = "2", FirstName = "Jane", LastName = "Doe", Email = "jane.doe@example.com" }
            };

            _httpClientMock.Setup(c => c.GetAsync("users/page/1")).ReturnsAsync(JsonConvert.SerializeObject(users));

            // Act
            var result = await _apiClient.GetUsersAsync();

            // Assert
            result.Should().BeEquivalentTo(users);
        }

        [TestMethod]
        public async Task GetUsersAsync_ThrowsExceptionAndLogsError_WhenApiCallFails()
        {
            // Arrange
            var exception = new Exception("An error occurred");
            _httpClientMock.Setup(c => c.GetAsync("users/page/1")).ThrowsAsync(exception);

            // Act & Assert
            await TestExceptionHandlingAndLogging(
                async () => await _apiClient.GetUsersAsync(),
                "An error occurred while retrieving users",
                _loggerMock
            );
        }

    }
}

