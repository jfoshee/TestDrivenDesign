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

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotContain()
        {
            // Arrange
            var directory = TestDirectory();
            var searchPattern = "foo*";

            // Act
            DirectoryAssert.Contains(directory, searchPattern);
        }

        [TestMethod]
        public void DoesContainFile()
        {
            // Arrange
            File.WriteAllText(TestDirectory() + "\\foobar.txt", "abc");

            // Act
            DirectoryAssert.Contains(TestDirectory(), "foo*");
            DirectoryAssert.Contains(TestDirectory(), "foobar.txt");
        }

        [TestMethod]
        public void DoesContainDirectory()
        {
            // Arrange
            Directory.CreateDirectory(TestDirectory() + "\\foobar");

            // Act
            DirectoryAssert.Contains(TestDirectory(), "foo*");
            DirectoryAssert.Contains(TestDirectory(), "foobar");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void IsEmptyFails()
        {
            // Arrange
            var directory = TestDirectory();
            File.WriteAllText(directory + "\\foo.txt", "...");

            // Act
            DirectoryAssert.IsEmpty(directory);
        }

        [TestMethod]
        public void IsEmptyPasses()
        {
            // Arrange
            var directory = TestDirectory();

            // Act
            DirectoryAssert.IsEmpty(directory);
        }
    }
}
