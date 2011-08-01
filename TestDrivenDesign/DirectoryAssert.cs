using System.IO;
using System.Linq;
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

        public static void Contains(string directory, string searchPattern)
        {
            if (Directory.EnumerateFileSystemEntries(directory, searchPattern).Count() == 0)
                throw new AssertFailedException("Directory does not contain: " + searchPattern);
        }

        public static void IsEmpty(string directory)
        {
            if (Directory.EnumerateFiles(directory).Count() > 0)
                throw new AssertFailedException("Directory is not empty: " + directory);
        }
    }
}
