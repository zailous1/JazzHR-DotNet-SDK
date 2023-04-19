using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Models.Tests
{ 
    [TestClass]
    public class CreateCategoryRequestTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties_WhenArgumentsAreValid()
        {
            // Arrange
            string name = "TestCategory";
            bool active = true;

            // Act
            var request = new CreateCategoryRequest(name, active);

            // Assert
            request.Name.Should().Be(name);
            request.Enabled.Should().Be("1");
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenNameIsNull()
        {
            // Arrange
            string name = null;
            bool active = true;

            // Act
            Action act = () => new CreateCategoryRequest(name, active);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(name)}')");
        }

        [TestMethod]
        public void JsonSerialization_ShouldSerializeProperties()
        {
            // Arrange
            string name = "TestCategory";
            bool active = true;
            var request = new CreateCategoryRequest(name, active);

            // Act
            string json = JsonConvert.SerializeObject(request);
            var deserializedRequest = JsonConvert.DeserializeObject<CreateCategoryRequest>(json);

            // Assert
            deserializedRequest.Name.Should().Be(name);
            deserializedRequest.Enabled.Should().Be("1");
        }

        [TestMethod]
        public void JsonSerialization_ShouldSerializeProperties_WhenActiveIsFalse()
        {
            // Arrange
            string name = "TestCategory";
            bool active = false;
            var request = new CreateCategoryRequest(name, active);

            // Act
            string json = JsonConvert.SerializeObject(request);
            var deserializedRequest = JsonConvert.DeserializeObject<CreateCategoryRequest>(json);

            // Assert
            deserializedRequest.Name.Should().Be(name);
            deserializedRequest.Enabled.Should().Be("0");
        }
    }
}
