using FluentAssertions;
using Zailous.JazzHR;
using Zailous.JazzHR.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task CreateNoteAsync_ReturnsExpectedResponse_WhenRequestIsValid()
        {
            // Arrange
            var request = new CreateNoteRequest("applicantId", "userId", "contents");
            request.ApiKey = "test_api_key";
            var expectedResponse = new CreateNoteResponse { CommentId = "12345" };
            var requestJson = JsonConvert.SerializeObject(request);
            var responseJson = JsonConvert.SerializeObject(expectedResponse);
            _httpClientMock.Setup(c => c.PostAsync("notes", requestJson)).ReturnsAsync(responseJson);

            // Act
            var result = await _apiClient.CreateNoteAsync(request);

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [TestMethod]
        public async Task CreateNoteAsync_ThrowsArgumentNullException_WhenRequestIsNull()
        {
            // Arrange
            CreateNoteRequest request = null;

            // Act & Assert
            Func<Task> action = async () => await _apiClient.CreateNoteAsync(request);
            var exception = await action.Should().ThrowAsync<ArgumentNullException>();
            exception.Which.ParamName.Should().Be("request");
        }

        [TestMethod]
        public async Task CreateNoteAsync_ThrowsExceptionAndLogsError_WhenPostAsyncFails()
        {
            // Arrange
            var request = new CreateNoteRequest("applicantId", "userId", "contents");
            _httpClientMock.Setup(c => c.PostAsync("notes", It.IsAny<string>())).ThrowsAsync(new Exception("An error occurred"));

            // Call the helper method with the appropriate action and expected log message
            await TestExceptionHandlingAndLogging(() => _apiClient.CreateNoteAsync(request), "An error occurred while creating a note", _loggerMock);
        }


    }

}

