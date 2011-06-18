﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

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
    }
}