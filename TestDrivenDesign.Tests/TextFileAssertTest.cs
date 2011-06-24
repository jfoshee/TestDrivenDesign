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
            var path = WriteMississippiFile();

            // Act
            TextFileAssert.Contains(path, "x");
        }

        [TestMethod]
        public void DoesContain()
        {
            // Arrange
            var path = WriteMississippiFile();

            // Act
            TextFileAssert.Contains(path, "sip");
        }

        private string WriteMississippiFile()
        {
            var path = TextPath();
            File.WriteAllText(path, "mississippi");
            return path;
        }
    }
}
