using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class TextFileAssertTest : TestBase
    {
        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void FileDoesNotExist()
        {
            TextFileAssert.Exists(TestPath());
        }

        [TestMethod]
        public void FileExists()
        {
            // Arrange
            var path = TestPath() + ".txt";
            File.WriteAllText(path, "");

            // Act
            TextFileAssert.Exists(path);

            // Assert: No exception
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void NotEqual()
        {
            // Arrange
            var expectedPath = TestPath() + "1.txt";
            var actualPath = TestPath() + "2.txt";
            File.WriteAllText(expectedPath, "a b c");
            File.WriteAllText(actualPath, "x y z");

            // Act
            TextFileAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void Equality()
        {
            // Arrange
            var expectedPath = TestPath() + "1.txt";
            var actualPath = TestPath() + "2.txt";
            File.WriteAllText(expectedPath, "a b c");
            File.WriteAllText(actualPath, "a b c");

            // Act
            TextFileAssert.AreEqual(expectedPath, actualPath);

            // Assert: No exception
        }
    }
}
