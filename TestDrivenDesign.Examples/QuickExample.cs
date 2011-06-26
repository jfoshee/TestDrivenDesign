using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Examples
{
    [TestClass]
    public class QuickExampleTest : TestBase<QuickExample>
    {
        [TestMethod]
        public void ShouldSayHelloMultipleTimes()
        {
            // Arrange
            Subject.Count = 3;      // TestBase<T> provides us with a default constructed QuickExample object 
                                    // (think: "Test Subject")
            var path = TextPath();  // Gives us a unique path like: 
                                    // ...\TestResults\...\Out\QuickExampleTest.ShouldSayHelloMultipleTimes.txt

            // Act
            Subject.SayHello(path);

            // Assert
            TestContext.AddResultFile(path);    // TestBase provides the TestContext property. 
                                                // AddResultFile adds a hyperlink to our file on the test result page
            TextFileAssert.Contains(path,       // TextFileAssert contains methods for testing text files.
                "hello hello hello");           // Yes, there is a BinaryFileAssert too!
        }
    }

    public class QuickExample
    {
        public int Count { get; set; }

        public void SayHello(string path)
        {
            using (var writer = new StreamWriter(File.OpenWrite(path)))
                for (int i = 0; i < Count; i++)
                    writer.Write("hello ");
        }
    }
}
