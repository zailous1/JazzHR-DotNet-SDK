using FluentAssertions;
using Zailous.JazzHR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace Zailous.JazzHR.Tests
{
    [TestClass]
    public class JazzHRHttpClientTests
    {
        private JazzHRApiClientConfig _config;
        private Mock<IRestClientFactory>? _restClientFactoryMock;
        private Mock<IRestClient>? _restClientMock;
        private HttpClient? _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _restClientFactoryMock = new Mock<IRestClientFactory>();
            _restClientMock = new Mock<IRestClient>();

            _config = new JazzHRApiClientConfig("https://api.jazz.co/", "abc123", "ticket");

            _restClientFactoryMock.Setup(f => f.CreateRestClient(It.IsAny<string>())).Returns(_restClientMock.Object);

            _client = new HttpClient(
                _config,
                _restClientFactoryMock.Object);
        }

        [TestMethod]
        public async Task GetAsync_WhenCalled_ExecutesCorrectRequest()
        {
            // Arrange
            var subpath = "jobs/page/1";
            var expectedContent = "expected content";
            var restResponse = new RestResponse { Content = expectedContent, StatusCode = HttpStatusCode.OK, IsSuccessStatusCode = true };
            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == subpath && r.Method == Method.Get)))
                .ReturnsAsync(restResponse);

            // Act
            var content = await _client.GetAsync(subpath);

            // Assert
            content.Should().Be(expectedContent);
            _restClientMock.VerifyAll();
        }

        [TestMethod]
        public async Task GetAsync_WhenResponseIsNotSuccessful_ThrowsException()
        {
            // Arrange
            var subpath = "jobs/page/1";
            var expectedContent = "error content";
            var restResponse = new RestResponse { Content = expectedContent, StatusCode = HttpStatusCode.BadRequest, StatusDescription = expectedContent };
            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == subpath && r.Method == Method.Get))).ReturnsAsync(restResponse);

            // Act
            Func<Task> act = async () => await _client.GetAsync(subpath);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage($"Error {HttpStatusCode.BadRequest}: {expectedContent}");
            _restClientMock.VerifyAll();
        }

        [TestMethod]
        public async Task PostAsync_WhenCalled_ExecutesCorrectRequest()
        {
            // Arrange
            var subpath = "jobs";
            var body = "{}";
            var expectedContent = "expected content";
            var restResponse = new RestResponse { Content = expectedContent, StatusCode = HttpStatusCode.Created, IsSuccessStatusCode = true };
            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == subpath && r.Method == Method.Post && JsonConvert.SerializeObject(r.Parameters).Contains(body))))
                .ReturnsAsync(restResponse);

            // Act
            var content = await _client.PostAsync(subpath, body);

            // Assert
            content.Should().Be(expectedContent);
            _restClientMock.VerifyAll();
        }

        [TestMethod]
        public async Task PostAsync_WhenResponseIsNotSuccessful_ThrowsException()
        {
            // Arrange
            var subpath = "jobs";
            var body = "{}";
            var expectedContent = "error content";
            var restResponse = new RestResponse { Content = expectedContent, StatusCode = HttpStatusCode.BadRequest, StatusDescription = expectedContent };
            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == subpath && r.Method == Method.Post && JsonConvert.SerializeObject(r.Parameters).Contains(body))))
                .ReturnsAsync(restResponse);

            // Act
            Func<Task> act = async () => await _client.PostAsync(subpath, body);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage($"Error {HttpStatusCode.BadRequest}: {expectedContent}");
            _restClientMock.VerifyAll();
        }

        [TestMethod]
        public async Task DownloadAsync_WhenCalled_ExecutesCorrectRequest()
        {
            // Arrange
            var url = "https://example.com/file.pdf";
            var resource = "https://app.jazz.co/files/download/resume";
            var expectedContent = new byte[] { 0x01, 0x02, 0x03 };
            var restResponse = new RestResponse { Content = "", RawBytes = expectedContent, StatusCode = HttpStatusCode.OK };
            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == resource && r.Method == Method.Get)))
                .Returns((RestRequest request) =>
                {
                    request.ResponseWriter(new MemoryStream(expectedContent));
                    var restResponse = new RestResponse { Content = "", RawBytes = expectedContent, StatusCode = HttpStatusCode.OK };
                    return Task.FromResult(restResponse);
                });

            // Act
            var content = await _client.DownloadAsync(url);

            // Assert
            content.Should().BeEquivalentTo(expectedContent);
            _restClientMock.VerifyAll();
        }

        [TestMethod]
        public async Task DownloadAsync_WhenResponseIsNotSuccessful_ThrowsException()
        {
            // Arrange
            var url = "https://example.com/file.pdf";
            var resource = "https://app.jazz.co/files/download/resume";

            _restClientMock.Setup(c => c.ExecuteAsync(It.Is<RestRequest>(r => r.Resource == resource && r.Method == Method.Get)))
                .Returns((RestRequest request) =>
                {
                    var restResponse = new RestResponse { StatusCode = HttpStatusCode.BadRequest };
                    return Task.FromResult(restResponse);
                });

            // Act
            Func<Task> act = async () => await _client.DownloadAsync(url);

            // Assert
            await act.Should().ThrowAsync<Exception>().WithMessage($"{nameof(HttpClient.DownloadAsync)}: {HttpStatusCode.BadRequest}");
            _restClientMock.VerifyAll();
        }
    }
}
