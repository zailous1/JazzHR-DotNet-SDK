using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Zailous.JazzHR;

namespace Zailous.JazzHR.Tests
{
    [TestClass]
    public class RestClientFactoryTests
    {
        private RestClientFactory? _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            _factory = new RestClientFactory();
        }

        [TestMethod]
        public void CreateRestClient_WhenCalled_ReturnsRestClientImpl()
        {
            // Arrange
            var baseUrl = "https://api.jazz.co/";

            // Act
            var restClient = _factory.CreateRestClient(baseUrl);

            // Assert
            restClient.Should().BeOfType<RestClientImpl>();
        }

        [TestMethod]
        public void CreateRestClient_WhenCalled_SetsBaseUrl()
        {
            // Arrange
            var baseUrl = "https://api.jazz.co/";

            // Act
            var restClient = _factory.CreateRestClient(baseUrl) as RestClientImpl;

            // Assert
            restClient.BaseUrl.Should().Be(new Uri(baseUrl));
        }
    }
}
