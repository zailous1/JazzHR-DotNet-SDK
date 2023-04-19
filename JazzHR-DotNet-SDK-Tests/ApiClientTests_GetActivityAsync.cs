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
        public async Task GetActivityAsync_WithValidId_ReturnsActivity()
        {
            // Arrange
            var expected = new Activity
            {
                Id = "1",
                Category = "Interview",
                TeamId = "123",
                UserId = "321",
                ObjectId = "111",
                Action = "Created",
                Date = "2023-04-18",
                Time = "14:00:00"
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("activities/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetActivityAsync("1");

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("1");
            result.Category.Should().Be("Interview");
            result.TeamId.Should().Be("123");
            result.UserId.Should().Be("321");
            result.ObjectId.Should().Be("111");
            result.Action.Should().Be("Created");
            result.Date.Should().Be("2023-04-18");
            result.Time.Should().Be("14:00:00");
        }

        [TestMethod]
        public async Task GetActivityAsync_WithInvalidId_ThrowsHttpRequestException()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("activities/invalid_id")).ThrowsAsync(new HttpRequestException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetActivityAsync("invalid_id"));
        }

        [TestMethod]
        public async Task GetActivityAsync_WithInvalidJson_ThrowsJsonReaderException()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("activities/1")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonReaderException>(() => _apiClient.GetActivityAsync("1"));
        }
    }
}

