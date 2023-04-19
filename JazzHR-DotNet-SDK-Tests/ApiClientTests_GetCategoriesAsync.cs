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
        public async Task GetCategoriesAsync_ReturnsListOfCategories_WhenSuccessful()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = "1", Name = "Category 1", Status = "active", CreatedBy = "user", DateCreated = "2023-01-01" },
                new Category { Id = "2", Name = "Category 2", Status = "inactive", CreatedBy = "user", DateCreated = "2023-01-02" }
            };
            var json = JsonConvert.SerializeObject(categories);
            _httpClientMock.Setup(c => c.GetAsync("categories/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetCategoriesAsync(null);

            // Assert
            Assert.IsNotNull(result);
            result.Should().BeEquivalentTo(categories);
        }

        [TestMethod]
        public async Task GetCategoriesAsync_ThrowsException_WhenApiCallFails()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("categories/page/1")).ThrowsAsync(new HttpRequestException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetCategoriesAsync(null));
        }

    }
}

