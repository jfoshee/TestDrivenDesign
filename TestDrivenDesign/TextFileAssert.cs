using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public static class TextFileAssert
    {
        public static void Exists(string path)
        {
            if (!File.Exists(path))
                throw new AssertFailedException("File does not exist: " + path);
        }

        public static void AreEqual(string expectedPath, string actualPath)
        {
            var expected = File.ReadAllText(expectedPath);
            var actual = File.ReadAllText(actualPath);
            if (expected != actual)
                throw new AssertFailedException("Files are not equal.");
        }
    }
}
