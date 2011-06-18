using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class TestBaseTest : TestBase
    {
        [TestMethod]
        public void TestContextProperty()
        {
            Assert.IsInstanceOfType(TestContext, typeof(TestContext));
        }
    }
}
