using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Marathon.IntegrationTest.Common;
using System.Data.Entity;
using Marathon.Data.Core;

namespace Marathon.IntegrationTest
{
    [TestClass]
    public class Initialize
    {
        [AssemblyInitialize]
        public static void Setup(TestContext testContext)
        {
            Database.SetInitializer<Context>(null);
            TestRegistry.Configure();
        }
    }
}
