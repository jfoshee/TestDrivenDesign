using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public static class DirectoryAssert
    {
        public static void Exists(string directory)
        {
            if (!Directory.Exists(directory))
                throw new AssertFailedException("Directory does not exist: " + directory);
        }
    }
}
