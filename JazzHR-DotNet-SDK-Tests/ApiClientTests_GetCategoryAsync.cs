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
        public async Task GetCategoryAsync_ReturnsCategory_WhenSuccessful()
        {
            // Arrange
            var category = new Category { Id = "1", Name = "Category 1", Status = "active", CreatedBy = "user", DateCreated = "2023-01-01" };
            var json = JsonConvert.SerializeObject(category);
            _httpClientMock.Setup(c => c.GetAsync("categories/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetCategoryAsync("1");

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(category);
        }

        [TestMethod]
        public async Task GetCategoryAsync_ReturnsNull_WhenResponseIsNullOrEmpty()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("categories/1")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetCategoryAsync("1");

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetCategoryAsync_ThrowsException_WhenApiCallFails()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("categories/1")).ThrowsAsync(new HttpRequestException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetCategoryAsync("1"));
        }

    }
}

