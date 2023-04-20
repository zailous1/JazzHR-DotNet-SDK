using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Tests
{

    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task DeserializeApiResponse_ReturnsDeserializedObject_WhenResponseIsValidJson()
        {
            // Arrange
            var expected = new Foo { Name = "Test", Value = 42 };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("test")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.DeserializeApiResponse<Foo>("test");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expected.Name, result.Name);
            Assert.AreEqual(expected.Value, result.Value);
        }

        [TestMethod]
        public async Task DeserializeApiResponse_ReturnsNull_WhenResponseIsNullOrEmpty()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("test")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.DeserializeApiResponse<Foo>("test");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task DeserializeApiResponse_ThrowsException_WhenDeserializationFails()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("test")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonReaderException>(() => _apiClient.DeserializeApiResponse<Foo>("test"));
        }

    }
}