using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class JobsVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var jobsVars = new JobsVars
            {
                Title = "Software Engineer",
                Recruiter = "John Doe",
                BoardCode = "ABC123",
                Department = "IT",
                HiringLead = "Jane Smith",
                TeamId = "789",
                State = "CA",
                City = "San Francisco",
                FromOpenDate = new DateTime(2022, 01, 01),
                ToOpenDate = new DateTime(2022, 12, 31),
                Status = "open",
                Confidential = true,
                Private = false
            };

            // Act
            var subpath = jobsVars.ToSubpath();

            // Assert
            subpath.Should().Be("/title/Software Engineer/recruiter/John Doe/board_code/ABC123/department/IT/hiring_lead/Jane Smith/team_id/789/state/CA/city/San Francisco/from_open_date/2022-01-01/to_open_date/2022-12-31/status/open/confidential/true/private/false");
        }
    }
}
