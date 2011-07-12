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
            var path = TextPath();
            File.WriteAllText(path, "");

            // Act
            TextFileAssert.Exists(path);

            // Assert: No exception
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void NotEqual()
        {
            AssertTwoTextFilesEqual(false);
        }

        [TestMethod]
        public void Equality()
        {
            AssertTwoTextFilesEqual(true);
        }

        private void AssertTwoTextFilesEqual(bool sameFiles)
        {
            // Arrange
            var expectedPath = TestPath() + "1";
            var actualPath = TestPath() + "2";
            File.WriteAllText(actualPath, "a b c");
            File.Copy(actualPath, expectedPath);
            if (!sameFiles)
                File.AppendAllText(expectedPath, "1 2 3");

            // Act
            TextFileAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotContain()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.Contains(path, "x");
        }

        [TestMethod]
        public void DoesContain()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.Contains(path, "sip");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotContainLine()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.ContainsLine(path, "texas");
        }

        [TestMethod]
        public void DoesContainLine()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.ContainsLine(path, "mississippi");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotStartWith()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.StartsWith(path, "sip");
        }

        [TestMethod]
        public void DoesStartWith()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.StartsWith(path, "arkansas\nmiss");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotEndWith()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.EndsWith(path, "sip");
        }

        [TestMethod]
        public void DoesEndWith()
        {
            // Arrange
            var path = WriteFileWithSomeStateNames();

            // Act
            TextFileAssert.EndsWith(path, "ippi\nalabama");
        }

        private string WriteFileWithSomeStateNames()
        {
            var path = TextPath();
            File.WriteAllText(path, "arkansas\nmississippi\nalabama");
            return path;
        }
    }
}
