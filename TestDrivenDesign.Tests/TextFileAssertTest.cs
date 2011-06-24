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
    }
}
