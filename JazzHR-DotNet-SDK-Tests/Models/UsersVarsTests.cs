using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class UsersVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var usersVars = new UsersVars
            {
                Name = "JohnDoe",
                Email = "john.doe@example.com",
                Type = "Admin"
            };

            // Act
            var subpath = usersVars.ToSubpath();

            // Assert
            subpath.Should().Be("/name/JohnDoe/email/john.doe@example.com/type/Admin");
        }

        [TestMethod]
        public void ToSubpath_ShouldIgnoreEmptyParameters()
        {
            // Arrange
            var usersVars = new UsersVars
            {
                Name = "JohnDoe",
                Email = "",
                Type = "Admin"
            };

            // Act
            var subpath = usersVars.ToSubpath();

            // Assert
            subpath.Should().Be("/name/JohnDoe/type/Admin");
        }

        [TestMethod]
        public void ToSubpath_ShouldIgnoreNullParameters()
        {
            // Arrange
            var usersVars = new UsersVars
            {
                Name = "JohnDoe",
                Email = null,
                Type = "Admin"
            };

            // Act
            var subpath = usersVars.ToSubpath();

            // Assert
            subpath.Should().Be("/name/JohnDoe/type/Admin");
        }
    }
}
