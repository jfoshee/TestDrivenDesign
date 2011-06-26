using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public static class BinaryFileAssert
    {
        public static void Exists(string path)
        {
            TextFileAssert.Exists(path);
        }

        public static void StartsWith(string path, byte[] expected)
        {
            BytesAt(path, 0, expected);
        }

        public static void BytesAt(string path, int byteIndex, byte[] expected)
        {
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                reader.ReadBytes(byteIndex);
                var actual = reader.ReadBytes(expected.Length);
                if (!Enumerable.SequenceEqual(expected, actual))
                    throw new AssertFailedException("File does not have expected bytes at index: " + byteIndex);
            }
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
    }
}
