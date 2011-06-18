using System;
using System.IO;
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
            Assert.IsTrue(Directory.Exists(expected));
        }
    }
}
