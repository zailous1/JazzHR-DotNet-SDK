using FluentAssertions;
using Zailous.JazzHR;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Zailous.JazzHR.Tests
{
    [TestClass]
    public class RestClientImplTests
    {
        private RestClientImpl? _client;

        [TestInitialize]
        public void TestInitialize()
        {
            _client = new RestClientImpl("https://api.jazz.co/");
        }

        [TestMethod]
        public void Constructor_WhenCalled_SetsBaseUrl()
        {
            // Arrange
            var baseUrl = "https://api.jazz.co/";

            // Act
            var client = new RestClientImpl(baseUrl);

            // Assert
            client.BaseUrl.Should().Be(new Uri(baseUrl));
        }

    }
}
