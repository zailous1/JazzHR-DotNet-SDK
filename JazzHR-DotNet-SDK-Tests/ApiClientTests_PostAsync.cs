using FluentAssertions;
using Zailous.JazzHR.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Net;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task PostAsync_ReturnsDeserializedObject_WhenResponseIsValidJson()
        {
            // Arrange
            var request = new PostRequest { Name = "Test", Value = 42, ApiKey = "test_api_key" };
            var expected = new Foo { Name = "Test", Value = 42 };
            var json = JsonConvert.SerializeObject(request);
            _httpClientMock.Setup(c => c.PostAsync("test", json)).Returns(Task.FromResult(json));

            // Act
            var result = await _apiClient.PostAsync<Foo>("test", request);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public async Task PostAsync_ThrowsException_WhenResponseIsNull()
        {
            // Arrange
            var request = new PostRequest { Name = "Test", Value = 42 };
            _httpClientMock.Setup(c => c.PostAsync("test", It.IsAny<string?>())).ReturnsAsync((string)null);

            // Act
            Func<Task> act = async () => await _apiClient.PostAsync<Foo>("test", request);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'response')");
        }

        [TestMethod]
        public async Task PostAsync_ThrowsException_WhenDeserializationFails()
        {
            // Arrange
            var request = new PostRequest { Name = "Test", Value = 42 };
            var json = "invalid json";
            var content = new StringContent(json);
            var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
            _httpClientMock.Setup(c => c.PostAsync("test", json)).Returns(Task.FromResult(json));

            // Act
            Func<Task> act = async () => await _apiClient.PostAsync<Foo>("test", request);

            // Assert
            await act.Should().ThrowAsync<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'response')");
        }

    }

    [JsonObject]
    public class PostRequest : CreateRequest
    {
        public string? Name { get; set; }

        public int? Value { get; set; }
    }
}

