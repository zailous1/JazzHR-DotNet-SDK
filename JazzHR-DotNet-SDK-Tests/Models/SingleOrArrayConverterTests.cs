using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Zailous.JazzHR.Models.Tests
{
    [TestClass]
    public class SingleOrArrayConverterTests
    {
        private class TestObject
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private readonly JsonSerializerSettings _settings = new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new SingleOrArrayConverter<TestObject>() },
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        [TestMethod]
        public void ReadJson_WithSingleObject_ShouldReturnListWithSingleObject()
        {
            // Arrange
            string json = "{\"Id\": 1, \"Name\": \"Test\"}";

            // Act
            var result = JsonConvert.DeserializeObject<List<TestObject>>(json, _settings);

            // Assert
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Test");
        }

        [TestMethod]
        public void ReadJson_WithArray_ShouldReturnListWithMultipleObjects()
        {
            // Arrange
            string json = "[{\"Id\": 1, \"Name\": \"Test1\"}, {\"Id\": 2, \"Name\": \"Test2\"}]";

            // Act
            var result = JsonConvert.DeserializeObject<List<TestObject>>(json, _settings);

            // Assert
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[0].Name.Should().Be("Test1");
            result[1].Id.Should().Be(2);
            result[1].Name.Should().Be("Test2");
        }

        [TestMethod]
        public void WriteJson_WithListWithSingleObject_ShouldSerializeSingleObject()
        {
            // Arrange
            var list = new List<TestObject> { new TestObject { Id = 1, Name = "Test" } };

            // Act
            string result = JsonConvert.SerializeObject(list, _settings);

            // Assert
            result.Should().Be("{\"Id\":1,\"Name\":\"Test\"}");
        }

        [TestMethod]
        public void WriteJson_WithListWithMultipleObjects_ShouldSerializeArray()
        {
            // Arrange
            var objects = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test1" },
                new TestObject { Id = 2, Name = "Test2" }
            };

            // Act
            var result = SerializeObjects(objects);

            // Assert
            result.Should().Be("[{\"Id\":1,\"Name\":\"Test1\"},{\"Id\":2,\"Name\":\"Test2\"}]");
        }


        private string SerializeObjects(List<TestObject> objects)
        {
            var converter = new SingleOrArrayConverter<TestObject>();
            var serializer = new JsonSerializer();

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);

            // Write the start of the array
            jsonWriter.WriteStartArray();

            // Serialize each object in the list
            foreach (var obj in objects)
            {
                serializer.Serialize(jsonWriter, obj);
            }

            // Write the end of the array
            jsonWriter.WriteEndArray();

            return stringWriter.ToString();
        }



    }

}
