using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public abstract class TestBase
    {
        public TestContext TestContext { get; set; }

        public string TestPath()
        {
            var testClassName = TestContext.FullyQualifiedTestClassName.Split('.').Last();
            return Path.Combine(TestContext.DeploymentDirectory, testClassName + "." + TestContext.TestName);
        }

        public string TestDirectory()
        {
            var directory = TestPath();
            Directory.CreateDirectory(directory);
            return directory;
        }
    }
}
