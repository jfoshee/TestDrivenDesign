using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Examples
{
    class HelloPlainText
    {
        internal static void Write(string path)
        {
            File.WriteAllText(path, "Hello, World!");
        }
    }

    [TestClass]
    public class HelloPlainTextTest : TestBase
    {
        [TestMethod]
        public void ShouldWriteHelloToFile()
        {
            // Arrange a unique text file path for this test
            var path = TextPath();

            // Act
            HelloPlainText.Write(path);

            // Assert the file contains the word 'Hello' 
            // and add a link to the results page for convenient human inspection
            TestContext.AddResultFile(path);
            TextFileAssert.Contains(path, "Hello");
        }
    }
}
