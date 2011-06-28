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

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void AreNotEqualSameLength()
        {
            // Arrange
            var expectedPath = WriteBinaryTenToFifty();
            var actualPath = TestPath2();
            File.WriteAllBytes(actualPath, new byte[] { 10, 20, 31, 40, 50 });

            // Act
            BinaryFileAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void AreNotEqualDifferentLength()
        {
            // Arrange
            var expectedPath = WriteBinaryTenToFifty();
            var actualPath = TestPath2();
            File.WriteAllBytes(actualPath, new byte[] { 10, 20, 30 });

            // Act
            BinaryFileAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod]
        public void AreEqual()
        {
            // Arrange
            var expectedPath = WriteBinaryTenToFifty();
            var actualPath = TestPath2();
            File.Copy(expectedPath, actualPath);

            // Act
            BinaryFileAssert.AreEqual(expectedPath, actualPath);
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void StartsWithNotFollowedBy()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.StartsWith(path, new byte[] { 10, 20 })
                .FollowedBy(new byte[] { 40, 50 });
        }

        [TestMethod]
        public void StartsWithIsFollowedBy()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.StartsWith(path, new byte[] { 10, 20 })
                .FollowedBy(new byte[] { 30, 40 });
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void BytesAreNotFollowedBy()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.BytesAt(path, 1, new byte[] { 20, 30 })
                .FollowedBy(new byte[] { 123 });
        }

        [TestMethod]
        public void BytesAreFollowedBy()
        {
            // Arrange
            var path = WriteBinaryTenToFifty();

            // Act
            BinaryFileAssert.BytesAt(path, 1, new byte[] { 20, 30 })
                .FollowedBy(new byte[] { 40, 50 });
        }

        // TODO: Move AreEqual to the top
        // TODO: Can we change the byte array to a params arg?
        // TODO: Contains
        // TODO: Contains.FollowedBy
        // TODO: <T>At
        // TODO: FollowedBy<T>

        private string WriteBinaryTenToFifty()
        {
            var path = TestPath();
            File.WriteAllBytes(path, new byte[] { 10, 20, 30, 40, 50 });
            return path;
        }

        private string TestPath2()
        {
            return TestPath() + "2";
        }
    }
}
