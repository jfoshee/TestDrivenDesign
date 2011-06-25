using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

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
            using (var reader = new BinaryReader(File.OpenRead(path)))
            {
                var actual = reader.ReadBytes(expected.Length);
                if (!Enumerable.SequenceEqual(expected, actual))
                    throw new AssertFailedException("File does not start with expected bytes");
            }
        }
    }
}
