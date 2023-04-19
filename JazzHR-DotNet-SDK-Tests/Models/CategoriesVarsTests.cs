using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zailous.JazzHR.Models.Tests
{

    [TestClass]
    public class CategoriesVarsTests
    {
        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath()
        {
            // Arrange
            var categoriesVars = new CategoriesVars
            {
                UserId = "123",
                Name = "TestCategory",
                Status = "Active",
                FromCreationDate = "2023-04-01",
                ToCreationDate = "2023-04-30"
            };

            // Act
            var subpath = categoriesVars.ToSubpath();

            // Assert
            subpath.Should().Be("/user_id/123/name/TestCategory/status/Active/from_creation_date/2023-04-01/to_creation_date/2023-04-30");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnCorrectSubpath_WithMissingValues()
        {
            // Arrange
            var categoriesVars = new CategoriesVars
            {
                UserId = "123",
                Name = null,
                Status = "Active",
                FromCreationDate = null,
                ToCreationDate = null
            };

            // Act
            var subpath = categoriesVars.ToSubpath();

            // Assert
            subpath.Should().Be("/user_id/123/status/Active");
        }

        [TestMethod]
        public void ToSubpath_ShouldReturnEmptyString_WhenAllValuesAreMissing()
        {
            // Arrange
            var categoriesVars = new CategoriesVars
            {
                UserId = null,
                Name = null,
                Status = null,
                FromCreationDate = null,
                ToCreationDate = null
            };

            // Act
            var subpath = categoriesVars.ToSubpath();

            // Assert
            subpath.Should().BeEmpty();
        }
    }
}
