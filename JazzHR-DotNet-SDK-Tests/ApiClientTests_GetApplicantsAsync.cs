using FluentAssertions;
using Zailous.JazzHR.Models;
using Zailous.JazzHR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Tests
{
    public partial class ApiClientTests
    {
        [TestMethod]
        public async Task GetApplicantsAsync_WithVars_ReturnsFilteredApplicants()
        {
            // Arrange
            var applicants = new List<Applicant>
            {
                new Applicant { Id = "1", FirstName = "John", LastName = "Doe", JobId = "J1" },
                new Applicant { Id = "2", FirstName = "Jane", LastName = "Doe", JobId = "J2" }
            };

            var json = JsonConvert.SerializeObject(applicants);
            _httpClientMock.Setup(c => c.GetAsync("applicants/name/John/city/New York/job_id/J1/job_title/Software Engineer/recruiter_id/R1/apply_date/2023-04-18/from_apply_date/2023-04-01/to_apply_date/2023-04-30/status/Active/rating/5/page/1"))
                .ReturnsAsync(json);

            var vars = new ApplicantsVars
            {
                Name = "John",
                City = "New York",
                JobId = "J1",
                JobTitle = "Software Engineer",
                RecruiterId = "R1",
                ApplyDate = new DateTime(2023, 4, 18),
                FromApplyDate = new DateTime(2023, 4, 1),
                ToApplyDate = new DateTime(2023, 4, 30),
                Status = "Active",
                Rating = 5
            };

            // Act
            var result = await _apiClient.GetApplicantsAsync(vars);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.First().FirstName.Should().Be("John");
            result.First().LastName.Should().Be("Doe");
            result.First().JobId.Should().Be("J1");
        }


        [TestMethod]
        public async Task GetApplicantsAsync_WithNullVars_ReturnsAllApplicants()
        {
            // Arrange
            var applicants = new List<Applicant>
            {
                new Applicant { Id = "1", FirstName = "John", LastName = "Doe", JobId = "J1" },
                new Applicant { Id = "2", FirstName = "Jane", LastName = "Doe", JobId = "J2" }
            };

            var json = JsonConvert.SerializeObject(applicants);
            _httpClientMock.Setup(c => c.GetAsync("applicants/page/1")).ReturnsAsync(json);

            // Act
            var result = await _apiClient.GetApplicantsAsync(null);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.First().FirstName.Should().Be("John");
            result.First().LastName.Should().Be("Doe");
            result.First().JobId.Should().Be("J1");
        }

        [TestMethod]
        public async Task GetApplicantsAsync_WithEmptyVars_ReturnsAllApplicants()
        {
            // Arrange
            var applicants = new List<Applicant>
            {
                new Applicant { Id = "1", FirstName = "John", LastName = "Doe", JobId = "J1" },
                new Applicant { Id = "2", FirstName = "Jane", LastName = "Doe", JobId = "J2" }
            };

            var json = JsonConvert.SerializeObject(applicants);
            _httpClientMock.Setup(c => c.GetAsync("applicants/page/1")).ReturnsAsync(json);

            var vars = new ApplicantsVars();

            // Act
            var result = await _apiClient.GetApplicantsAsync(vars);

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.First().FirstName.Should().Be("John");
            result.First().LastName.Should().Be("Doe");
            result.First().JobId.Should().Be("J1");
        }

    }
}

