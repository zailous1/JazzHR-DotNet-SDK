using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class CreateNoteRequestTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties_WhenArgumentsAreValid()
        {
            // Arrange
            string applicantId = "123";
            string userId = "456";
            string contents = "Sample note contents";

            // Act
            var request = new CreateNoteRequest(applicantId, userId, contents);

            // Assert
            request.ApplicantId.Should().Be(applicantId);
            request.UserId.Should().Be(userId);
            request.Contents.Should().Be(contents);
            request.Security.Should().Be("1");
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenApplicantIdIsNull()
        {
            // Arrange
            string applicantId = null;
            string userId = "456";
            string contents = "Sample note contents";

            // Act
            Action act = () => new CreateNoteRequest(applicantId, userId, contents);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(applicantId)}')");
        }

        [TestMethod]
        public void Constructor_ShouldThrowArgumentNullException_WhenUserIdIsNull()
        {
            // Arrange
            string applicantId = "123";
            string userId = null;
            string contents = "Sample note contents";

            // Act
            Action act = () => new CreateNoteRequest(applicantId, userId, contents);

            // Assert
            act.Should().Throw<ArgumentNullException>().WithMessage($"Value cannot be null. (Parameter '{nameof(userId)}')");
        }

        [TestMethod]
        public void JsonSerialization_ShouldSerializeProperties()
        {
            // Arrange
            string applicantId = "123";
            string userId = "456";
            string contents = "Sample note contents";
            var request = new CreateNoteRequest(applicantId, userId, contents);

            // Act
            string json = JsonConvert.SerializeObject(request);
            var deserializedRequest = JsonConvert.DeserializeObject<CreateNoteRequest>(json);

            // Assert
            deserializedRequest.ApplicantId.Should().Be(applicantId);
            deserializedRequest.UserId.Should().Be(userId);
            deserializedRequest.Contents.Should().Be(contents);
            deserializedRequest.Security.Should().Be("1");
        }
    }
}
