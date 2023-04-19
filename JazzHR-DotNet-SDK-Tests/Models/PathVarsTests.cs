using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class PathVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var testPathVars = new TestPathVars();

            // Act
            var subpath = testPathVars.ToSubpath();

            // Assert
            subpath.Should().Be("/param1/value1/param2/value2");
        }
    }

    public class TestPathVars : PathVars
    {
        protected override List<(string paramName, string? paramValue)> Parameters
            => new List<(string paramName, string? paramValue)>
            {
                ("param1", "value1"),
                ("param2", "value2")
            };
    }
}
