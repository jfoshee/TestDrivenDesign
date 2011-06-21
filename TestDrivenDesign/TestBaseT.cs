using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    [TestClass]
    public abstract class TestBase<T> : TestBase where T : new()
    {
        public T Subject { get; set; }

        [TestInitialize]
        public void TestInitialize()
        {
            Subject = new T();
        }
    }
}
