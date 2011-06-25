using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class BinaryFileAssertTest : TestBase
    {
        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void FileDoesNotExist()
        {
            BinaryFileAssert.Exists(TestPath());
        }

        [TestMethod]
        public void FileExists()
        {
            // Arrange
            var path = TestPath();
            File.WriteAllBytes(path, new byte[] { 0 });

            // Act
            BinaryFileAssert.Exists(path);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void DoesNotStartWith()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.StartsWith(path, new byte[] { 30, 40, 50 });
        }

        [TestMethod]
        public void DoesStartWith()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.StartsWith(path, new byte[] { 10, 20, 30 });
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void BytesNotAt()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.BytesAt(path, 2, new byte[] { 10, 20, 30 });
        }

        [TestMethod]
        public void BytesAt()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.BytesAt(path, 2, new byte[] { 30, 40 });
        }

        private string WriteBinaryTenToFifty()
        {
            var path = TestPath();
            File.WriteAllBytes(path, new byte[] { 10, 20, 30, 40, 50 });
            return path;
        }
    }
}
