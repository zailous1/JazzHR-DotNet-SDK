using System.Net;
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
        public async Task GetAsync_ReturnsAllItems_WhenThereAreFewerItemsThanMaxPageResults()
        {
            // Arrange
            var expected = new List<Foo>
            {
                new Foo { Name = "Test 1", Value = 1 },
                new Foo { Name = "Test 2", Value = 2 },
                new Foo { Name = "Test 3", Value = 3 }
            };

            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(JsonConvert.SerializeObject(expected));

            // Act
            var result = await _apiClient.GetAsync<Foo>("test", null);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetAsync_ReturnsAllItems_WhenThereAreMoreItemsThanMaxPageResults()
        {
            // Arrange
            var page1 = new List<Foo>
            {
                new Foo { Name = "Test 1", Value = 1 },
                new Foo { Name = "Test 2", Value = 2 }
            };

            var page2 = new List<Foo>
            {
                new Foo { Name = "Test 3", Value = 3 },
                new Foo { Name = "Test 4", Value = 4 }
            };

            _httpClientMock.SetupSequence(c => c.GetAsync("test/page/1"))
                .ReturnsAsync(JsonConvert.SerializeObject(page1));

            _httpClientMock.SetupSequence(c => c.GetAsync("test/page/2"))
                .ReturnsAsync(JsonConvert.SerializeObject(page2));

            // Act
            var result = await _apiClient.GetAsync<Foo>("test", null);

            // Assert
            result.Should().BeEquivalentTo(page1.Concat(page2));
        }

        [TestMethod]
        public async Task GetAsync_ReturnsEmptyList_WhenResponseIsEmpty()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetAsync<Foo>("test", null);

            // Assert
            result.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetAsync_ThrowsException_WhenDeserializationFails()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonSerializationException>(() => _apiClient.GetAsync<Foo>("test", null));
        }

    }

}

