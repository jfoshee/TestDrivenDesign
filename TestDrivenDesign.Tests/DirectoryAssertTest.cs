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
            TestDirectoryWithFoobarTxt();

            // Act
            DirectoryAssert.Contains(TestDirectory(), "foo*");
            DirectoryAssert.Contains(TestDirectory(), "foobar.txt");
        }

        [TestMethod]
        public void DoesContainDirectory()
        {
            // Arrange
            TestDirectoryWithFoobarDirectory();

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

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotContainFailsWithFile()
        {
            // Arrange
            var directory = TestDirectoryWithFoobarTxt();
            var searchPattern = "*.txt";

            // Act
            DirectoryAssert.DoesNotContain(directory, searchPattern);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotContainFailsWithDirectory()
        {
            // Arrange
            var directory = TestDirectoryWithFoobarDirectory();

            // Act
            DirectoryAssert.DoesNotContain(directory, "foo*");
        }

        [TestMethod]
        public void DoesNotContainPasses()
        {
            // Arrange
            var directory = TestDirectoryWithFoobarTxt();

            // Act
            DirectoryAssert.DoesNotContain(directory, "*.ini");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void CountFails()
        {
            // Arrange
            var directory = TestDirectoryWithFoobarTxt();
            int expected = 2;

            // Act
            DirectoryAssert.Count(directory, expected);
        }

        [TestMethod]
        public void CountPasses()
        {
            // Arrange
            TestDirectoryWithFoobarDirectory();
            TestDirectoryWithFoobarTxt();

            // Act
            DirectoryAssert.Count(TestDirectory(), 2);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void CountWithSearchPatternFails()
        {
            // Arrange
            TestDirectoryWithFoobarDirectory();
            TestDirectoryWithFoobarTxt();
            var searchPattern = "abc*";
            int expected = 2;

            // Act
            DirectoryAssert.Count(TestDirectory(), searchPattern, expected);
        }

        [TestMethod]
        public void CountWithSearchPatternPasses()
        {
            // Arrange
            TestDirectoryWithFoobarDirectory();
            TestDirectoryWithFoobarTxt();

            // Act
            DirectoryAssert.Count(TestDirectory(), "foo*", 2);
        }

        private string TestDirectoryWithFoobarTxt()
        {
            var directory = TestDirectory();
            File.WriteAllText(directory + "\\foobar.txt", "abc");
            return directory;
        }

        private string TestDirectoryWithFoobarDirectory()
        {
            var directory = TestDirectory();
            Directory.CreateDirectory(directory + "\\foobar");
            return directory;
        }
    }
}
