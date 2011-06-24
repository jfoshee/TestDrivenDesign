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
    }
}
