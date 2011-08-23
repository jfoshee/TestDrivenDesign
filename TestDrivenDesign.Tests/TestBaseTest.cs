using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class TestBaseTest : TestBase
    {
        [TestMethod]
        public void HasTestContextProperty()
        {
            // Arrange
            TestContext testContext = base.TestContext;

            // Assert
            Assert.IsInstanceOfType(testContext, typeof(TestContext));
        }

        [TestMethod]
        public void TestPathShouldContainTestClassAndTestName()
        {
            // Arrange
            var expected = TestContext.DeploymentDirectory + "\\TestBaseTest.TestPathShouldContainTestClassAndTestName";

            // Act
            string actual = base.TestPath();

            // Assert
            Assert.AreEqual(expected, actual);
            Console.WriteLine(actual);
        }

        [TestMethod]
        public void TestDirectoryCreatesADirectoryNamedForTestClassAndTestName()
        {
            // Arrange
            var expected = TestPath();

            // Act
            string actual = base.TestDirectory();

            // Assert
            Assert.AreEqual(expected, actual);
            DirectoryAssert.Exists(expected);
        }

        [TestMethod]
        public void TextFilePath()
        {
            // Arrange
            var expected = TestPath() + ".txt";

            // Act
            string actual = base.TextPath();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod, DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\DataDrivenSample.csv", "DataDrivenSample#csv", DataAccessMethod.Sequential), DeploymentItem("TestDrivenDesign.Tests\\DataDrivenSample.csv")]
        public void DataDrivenHelpers()
        {
            Assert.AreEqual(12, base.DataValueAsInt("SampleInt"));
            Assert.AreEqual(1.23f, base.DataValueAsFloat("SampleFloat"));
            Assert.AreEqual("Expected!", base.DataValueAsString("SampleString"));
            Assert.AreEqual(true, base.DataValueAsBool("SampleBool"));
        }
    }
}
