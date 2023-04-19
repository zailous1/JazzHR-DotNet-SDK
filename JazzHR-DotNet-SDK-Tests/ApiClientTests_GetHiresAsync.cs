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
        public async Task GetHiresAsync_ReturnsHires_WhenSuccessful()
        {
            // Arrange
            var hires = new List<Hire>
            {
                new Hire { Id = "1", ApplicantId = "1", JobId = "1", WorkflowStepId = "1", WorkflowStepName = "Step 1", HiredDate = "2023-01-01", HiredTime = "10:00" },
                new Hire { Id = "2", ApplicantId = "2", JobId = "2", WorkflowStepId = "2", WorkflowStepName = "Step 2", HiredDate = "2023-01-02", HiredTime = "11:00" }
            };
            var json = JsonConvert.SerializeObject(hires);
            _httpClientMock.Setup(c => c.GetAsync("hires/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetHiresAsync();

            // Assert
            result.Should().BeEquivalentTo(hires);
        }

        [TestMethod]
        public async Task GetHiresAsync_ReturnsEmptyList_WhenResponseIsNullOrEmpty()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("hires")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetHiresAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public async Task GetHiresAsync_ThrowsException_WhenApiCallFails()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("hires/page/1")).ThrowsAsync(new HttpRequestException());

            // Act & Assert
            await Assert.ThrowsExceptionAsync<HttpRequestException>(() => _apiClient.GetHiresAsync());
        }

    }
}

