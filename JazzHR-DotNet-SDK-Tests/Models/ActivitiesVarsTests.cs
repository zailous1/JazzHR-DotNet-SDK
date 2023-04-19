using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class ActivitiesVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var activitiesVars = new ActivitiesVars
            {
                UserId = "123",
                TeamId = "456",
                ObjectId = "789",
                Category = "TestCategory"
            };

            // Act
            var subpath = activitiesVars.ToSubpath();

            // Assert
            subpath.Should().Be("/user_id/123/team_id/456/object_id/789/category/TestCategory");
        }
    }
}
