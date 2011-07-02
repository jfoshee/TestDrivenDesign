using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class DirectoryAssertTest : TestBase
    {
        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DirectoryDoesNotExist()
        {
            // Arrange
            var directory = TestPath();

            // Act
            DirectoryAssert.Exists(directory);
        }

        [TestMethod]
        public void DirectoryDoesExist()
        {
            // Arrange
            var directory = TestPath();
            Directory.CreateDirectory(directory);

            // Act
            DirectoryAssert.Exists(directory);
        }
    }
}
