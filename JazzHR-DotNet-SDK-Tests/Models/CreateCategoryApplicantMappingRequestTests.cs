using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class CreateCategoryApplicantMappingRequestTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties_WhenArgumentsAreValid()
        {
            // Arrange
            string applicantId = "123";
            string categoryId = "456";

            // Act
            var request = new CreateCategoryApplicantMappingRequest(applicantId, categoryId);

            // Assert
            request.ApplicantId.Should().Be(applicantId);
            request.CategoryId.Should().Be(categoryId);
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenApplicantIdIsNull()
        {
            // Arrange
            string applicantId = null;
            string categoryId = "456";

            // Act
            Action act = () => new CreateCategoryApplicantMappingRequest(applicantId, categoryId);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(applicantId)}')");
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenCategoryIdIsNull()
        {
            // Arrange
            string applicantId = "123";
            string categoryId = null;

            // Act
            Action act = () => new CreateCategoryApplicantMappingRequest(applicantId, categoryId);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(categoryId)}')");
        }

        [TestMethod]
        public void JsonSerialization_ShouldSerializeProperties()
        {
            // Arrange
            string applicantId = "123";
            string categoryId = "456";
            var request = new CreateCategoryApplicantMappingRequest(applicantId, categoryId);

            // Act
            string json = JsonConvert.SerializeObject(request);
            var deserializedRequest = JsonConvert.DeserializeObject<CreateCategoryApplicantMappingRequest>(json);

            // Assert
            deserializedRequest.ApplicantId.Should().Be(applicantId);
            deserializedRequest.CategoryId.Should().Be(categoryId);
        }
    }
}
