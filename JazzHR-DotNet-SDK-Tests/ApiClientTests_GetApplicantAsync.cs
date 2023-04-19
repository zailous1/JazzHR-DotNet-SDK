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
        public async Task GetApplicantAsync_WithValidId_ReturnsApplicantDetail()
        {
            // Arrange
            var expected = new ApplicantDetail
            {
                Id = "1",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Jobs = new List<Job>(),
                Comments = new List<Comment>(),
                Feedback = new List<Feedback>(),
                Activities = new List<ApplicantActivity>(),
                Messages = new List<Message>(),
                Questionnaire = new List<QuestionnaireItem>(),
                Evaluation = new List<EvaluationItem>(),
                Categories = new List<ApplicantCategory>()
            };
            var json = JsonConvert.SerializeObject(expected);
            _httpClientMock.Setup(c => c.GetAsync("applicants/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetApplicantAsync("1");

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be("1");
            result.FirstName.Should().Be("John");
            result.LastName.Should().Be("Doe");
            result.Email.Should().Be("john.doe@example.com");
            result.Jobs.Should().BeEmpty();
            result.Comments.Should().BeEmpty();
            result.Feedback.Should().BeEmpty();
            result.Activities.Should().BeEmpty();
            result.Messages.Should().BeEmpty();
            result.Questionnaire.Should().BeEmpty();
            result.Evaluation.Should().BeEmpty();
            result.Categories.Should().BeEmpty();
        }

        [TestMethod]
        public async Task GetApplicantAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            _httpClientMock.Setup(c => c.GetAsync("applicants/99")).ReturnsAsync((string?)null);

            // Act
            var result = await _apiClient.GetApplicantAsync("99");

            // Assert
            result.Should().BeNull();
        }

        [TestMethod]
        public async Task GetApplicantAsync_WithInvalidJson_ThrowsJsonReaderException()
        {
            // Arrange
            var json = "invalid json";
            _httpClientMock.Setup(c => c.GetAsync("applicants/1")).ReturnsAsync(json);

            // Act & Assert
            await Assert.ThrowsExceptionAsync<JsonReaderException>(() => _apiClient.GetApplicantAsync("1"));
        }

    }
}

