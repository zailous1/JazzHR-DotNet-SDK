using FluentAssertions;
using Zailous.JazzHR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Zailous.JazzHR.Models;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetPageAsync_ReturnsEmptyList_WhenResponseIsNullOrWhiteSpace()
        {
            // Arrange
            string? response = null;
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(response);

            // Act
            var result = await _apiClient.GetPageAsync<object>("test", null, 1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, ((List<object>)result).Count);
        }

        [TestMethod]
        public async Task GetPageAsync_ReturnsDeserializedObject_WhenResponseIsValidJson()
        {
            // Arrange
            var expected = new List<Foo> { new Foo { Name = "Test", Value = 42 } };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetPageAsync<Foo>("test", null, 1);

            // Assert
            Assert.IsNotNull(result);
            ((List<Foo>)result).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetPageAsync_ReturnsDeserializedObject_WhenResponseIsValidJsonWithSingleObject()
        {
            // Arrange
            var expected = new List<Foo> { new Foo { Name = "Test", Value = 42 } };
            var json = JsonConvert.SerializeObject(expected[0]);
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetPageAsync<Foo>("test", null, 1);

            // Assert
            Assert.IsNotNull(result);
            ((List<Foo>)result).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetPageAsync_ThrowsJsonSerializationException_WhenResponseIsInvalidJson()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonSerializationException>(() => _apiClient.GetPageAsync<object>("test", null, 1));
        }

        [TestMethod]
        public async Task GetPageAsync_ThrowsException_WhenHttpClientThrowsException()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("test/page/1")).ThrowsAsync(new Exception());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<Exception>(() => _apiClient.GetPageAsync<object>("test", null, 1));
        }

        [TestMethod]
        public async Task GetPageAsync_AppendsSubpathWithToSubpath_WhenPathVarsIsNotNull()
        {
            // Arrange
            var expected = new List<Foo> { new Foo { Name = "Test", Value = 42 } };
            var json = JsonConvert.SerializeObject(expected);
            var pathVars = new PathVars { Id = 1 };
            _httpClientMock.Setup(c => c.GetAsync($"test{pathVars.ToSubpath()}/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetPageAsync<Foo>("test", pathVars, 1);

            // Assert
            Assert.IsNotNull(result);
            ((List<Foo>)result).Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task GetPageAsync_AppendsSubpathWithPageNum_WhenPathVarsIsNull()
        {
            // Arrange
            var expected = new List<Foo> { new Foo { Name = "Test", Value = 42 } };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("test/page/2")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetPageAsync<Foo>("test", null, 2);

            // Assert
            Assert.IsNotNull(result);
            ((List<Foo>)result).Should().BeEquivalentTo(expected);
        }

        private class PathVars : IPathVars
        {
            public int Id { get; set; }

            public string ToSubpath()
            {
                return $"/id/{Id}";
            }
        }
    }
}

