using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign
{
    public abstract class TestBase
    {
        public TestContext TestContext { get; set; }

        /// <returns>A path in the deployment directory named for the test class and test method</returns>
        public string TestPath()
        {
            var testClassName = TestContext.FullyQualifiedTestClassName.Split('.').Last();
            return Path.Combine(TestContext.DeploymentDirectory, testClassName + "." + TestContext.TestName);
        }

        /// <returns>A directory in the deployment directory created for the current test</returns>
        public string TestDirectory()
        {
            var directory = TestPath();
            Directory.CreateDirectory(directory);
            return directory;
        }

        public string TextPath()
        {
            return TestPath() + ".txt";
        }
    }
}
