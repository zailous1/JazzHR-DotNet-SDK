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
        public async Task GetActivitiesAsync_WithValidVars_ReturnsActivities()
        {
            // Arrange
            var expected = new List<Activity>
            {
                new Activity
                {
                    Id = "1",
                    Category = "Interview",
                    TeamId = "123",
                    UserId = "321",
                    ObjectId = "111",
                    Action = "Created",
                    Date = "2023-04-18",
                    Time = "14:00:00"
                },
                new Activity
                {
                    Id = "2",
                    Category = "Application",
                    TeamId = "123",
                    UserId = "321",
                    ObjectId = "222",
                    Action = "Updated",
                    Date = "2023-04-18",
                    Time = "14:30:00"
                }
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("activities/user_id/321/team_id/123/page/1")).ReturnsAsync(json);
            var vars = new ActivitiesVars { UserId = "321", TeamId = "123" };

            // Act
            var result = await _apiClient.GetActivitiesAsync(vars);

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(2);
            result.First().Id.Should().Be("1");
            result.First().Category.Should().Be("Interview");
            result.Last().Id.Should().Be("2");
            result.Last().Category.Should().Be("Application");
        }

        [TestMethod]
        public async Task GetActivitiesAsync_WithNullVars_ReturnsAllActivities()
        {
            // Arrange
            var expected = new List<Activity>
            {
                new Activity
                {
                    Id = "1",
                    Category = "Interview",
                    TeamId = "123",
                    UserId = "321",
                    ObjectId = "111",
                    Action = "Created",
                    Date = "2023-04-18",
                    Time = "14:00:00"
                },
                new Activity
                {
                    Id = "2",
                    Category = "Application",
                    TeamId = "123",
                    UserId = "321",
                    ObjectId = "222",
                    Action = "Updated",
                    Date = "2023-04-18",
                    Time = "14:30:00"
                }
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("activities/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetActivitiesAsync(null);

            // Assert
            result.Should().NotBeNull();
            result.Count().Should().Be(2);
            result.First().Id.Should().Be("1");
            result.First().Category.Should().Be("Interview");
            result.Last().Id.Should().Be("2");
            result.Last().Category.Should().Be("Application");
        }

        [TestMethod]
        public async Task GetActivitiesAsync_WithInvalidJson_ThrowsJsonReaderException()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("activities/page/1")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonSerializationException>(() => _apiClient.GetActivitiesAsync(null));
        }
    }
}

