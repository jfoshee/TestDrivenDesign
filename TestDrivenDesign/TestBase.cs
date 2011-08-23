using System;
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

        /// <returns>A text file path in the deployment directory named for the test class and test method</returns>
        public string TextPath()
        {
            return TestPath() + ".txt";
        }

        #region Data Driven Helpers

        public int DataValueAsInt(string name)
        {
            return Convert.ToInt32(TestContext.DataRow[name]);
        }

        public float DataValueAsFloat(string name)
        {
            return Convert.ToSingle(TestContext.DataRow[name]);
        }

        public bool DataValueAsBool(string name)
        {
            return Convert.ToBoolean(TestContext.DataRow[name]);
        }

        public string DataValueAsString(string name)
        {
            return TestContext.DataRow[name].ToString();
        }

        #endregion
    }
}
