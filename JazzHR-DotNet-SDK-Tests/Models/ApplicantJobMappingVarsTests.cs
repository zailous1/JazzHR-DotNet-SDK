using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class ApplicantJobMappingVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var applicantJobMappingVars = new ApplicantJobMappingVars
            {
                ApplicantId = "123",
                JobId = "456",
                Rating = 5,
                WorkflowStepId = "789"
            };

            // Act
            var subpath = applicantJobMappingVars.ToSubpath();

            // Assert
            subpath.Should().Be("/applicant_id/123/job_id/456/rating/5/workflow_step_id/789");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath_WithMissingValues()
        {
            // Arrange
            var applicantJobMappingVars = new ApplicantJobMappingVars
            {
                ApplicantId = "123",
                JobId = null,
                Rating = null,
                WorkflowStepId = "789"
            };

            // Act
            var subpath = applicantJobMappingVars.ToSubpath();

            // Assert
            subpath.Should().Be("/applicant_id/123/workflow_step_id/789");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnEmptyString_WhenAllValuesAreMissing()
        {
            // Arrange
            var applicantJobMappingVars = new ApplicantJobMappingVars
            {
                ApplicantId = null,
                JobId = null,
                Rating = null,
                WorkflowStepId = null
            };

            // Act
            var subpath = applicantJobMappingVars.ToSubpath();

            // Assert
            subpath.Should().BeEmpty();
        }
    }
}
