using System;
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
            if (GetCount(directory, searchPattern) == 0)
                throw new AssertFailedException("Directory does not contain: " + searchPattern);
        }

        public static void IsEmpty(string directory)
        {
            if (Directory.EnumerateFiles(directory).Count() > 0)
                throw new AssertFailedException("Directory is not empty: " + directory);
        }

        public static void DoesNotContain(string directory, string searchPattern)
        {
            if (GetCount(directory, searchPattern) != 0)
                throw new AssertFailedException("Directory does contain: " + searchPattern);
        }

        public static void Count(string directory, int expected)
        {
            Count(directory, "*", expected);
        }

        public static void Count(string directory, string searchPattern, int expected)
        {
            var count = GetCount(directory, searchPattern);
            if (count != expected)
                throw new AssertFailedException(String.Format("Directory contains {0} file entries matching '{1}'.  Expected: {2}", count, searchPattern, expected));
        }

        private static int GetCount(string directory, string searchPattern)
        {
            return Directory.EnumerateFileSystemEntries(directory, searchPattern).Count();
        }
    }
}
