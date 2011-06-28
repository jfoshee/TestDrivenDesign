using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public class BinaryFileAssert
    {
        public static void Exists(string path)
        {
            TextFileAssert.Exists(path);
        }

        public static BinaryFileAssert StartsWith(string path, byte[] expected)
        {
            return BytesAt(path, 0, expected);
        }

        public static BinaryFileAssert BytesAt(string path, int byteIndex, byte[] expected)
        {
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadBytes(byteIndex);
                var actual = reader.ReadBytes(expected.Length);
                if (!Enumerable.SequenceEqual(expected, actual))
                    throw new AssertFailedException("File does not have expected bytes at index: " + byteIndex);
            }
            return new BinaryFileAssert(path, byteIndex + expected.Length);
        }

        public static void AreEqual(string expectedPath, string actualPath)
        {
            using (var expectedReader = File.OpenRead(expectedPath))
            using (var actualReader = File.OpenRead(actualPath))
            {
                if (actualReader.Length != expectedReader.Length)
                    throw new AssertFailedException("The files have a different length");
                int expectedByte;
                int actualByte;
                do
                {
                    expectedByte = expectedReader.ReadByte();
                    actualByte = actualReader.ReadByte();
                    if (expectedByte != actualByte)
                        throw new AssertFailedException("The files are not equal");
                }
                while (expectedByte != -1);
            }
        }

        public void FollowedBy(byte[] expected)
        {
            BytesAt(_path, _at, expected);
        }

        private string _path;
        private int _at;
        private BinaryFileAssert(string path, int at)
        {
            _path = path;
            _at = at;
        }
    }
}
