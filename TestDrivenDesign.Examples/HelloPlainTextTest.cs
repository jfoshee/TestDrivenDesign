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
            // Arrange a unique file path for this test
            var path = TestPath() + ".txt";

            // Act
            HelloPlainText.Write(path);

            // Assert the file contains the word 'Hello' 
            // and add a link to the results page for convenient human inspection
            TestContext.AddResultFile(path);
            var text = File.ReadAllText(path);
            StringAssert.Contains(text, "Hello");
        }
    }
}
