using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class ApplicantsVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var applicantsVars = new ApplicantsVars
            {
                Name = "John Doe",
                City = "New York",
                JobId = "456",
                JobTitle = "Software Engineer",
                RecruiterId = "789",
                ApplyDate = new DateTime(2023, 4, 19),
                FromApplyDate = new DateTime(2023, 4, 1),
                ToApplyDate = new DateTime(2023, 4, 30),
                Status = "Active",
                Rating = 5
            };

            // Act
            var subpath = applicantsVars.ToSubpath();

            // Assert
            subpath.Should().Be("/name/John Doe/city/New York/job_id/456/job_title/Software Engineer/recruiter_id/789/apply_date/2023-04-19/from_apply_date/2023-04-01/to_apply_date/2023-04-30/status/Active/rating/5");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath_WithMissingValues()
        {
            // Arrange
            var applicantsVars = new ApplicantsVars
            {
                Name = "John Doe",
                City = null,
                JobId = "456",
                JobTitle = null,
                RecruiterId = "789",
                ApplyDate = null,
                FromApplyDate = null,
                ToApplyDate = null,
                Status = "Active",
                Rating = null
            };

            // Act
            var subpath = applicantsVars.ToSubpath();

            // Assert
            subpath.Should().Be("/name/John Doe/job_id/456/recruiter_id/789/status/Active");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnEmptyString_WhenAllValuesAreMissing()
        {
            // Arrange
            var applicantsVars = new ApplicantsVars
            {
                Name = null,
                City = null,
                JobId = null,
                JobTitle = null,
                RecruiterId = null,
                ApplyDate = null,
                FromApplyDate = null,
                ToApplyDate = null,
                Status = null,
                Rating = null
            };

            // Act
            var subpath = applicantsVars.ToSubpath();

            // Assert
            subpath.Should().BeEmpty();
        }
    }
}
