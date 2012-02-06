using System;
using System.IO;
using System.Linq;
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

        public static void Contains(string path, string expected)
        {
            var text = File.ReadAllText(path);
            if (!text.Contains(expected))
                throw new AssertFailedException("File does not contain: " + expected);
        }

        public static void ContainsLine(string path, string expected)
        {
            var lines = File.ReadAllLines(path);
            if (!lines.Contains(expected))
                throw new AssertFailedException("File does not contain line: " + expected);
        }

        public static void StartsWith(string path, string expected)
        {
            var text = File.ReadAllText(path);
            if (!text.StartsWith(expected, _comparison))
                throw new AssertFailedException("File does not start with: " + expected);
        }

        public static void EndsWith(string path, string expected)
        {
            var text = File.ReadAllText(path);
            if (!(text.EndsWith(expected, _comparison) || text.EndsWith(expected + Environment.NewLine, _comparison)))
                throw new AssertFailedException("File does not end with: " + expected);
        }

        private const StringComparison _comparison = StringComparison.Ordinal;
    }
}
