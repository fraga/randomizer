using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace Randomizer.Tests
{
    [TestClass]
    public class RandomOrgV1
    {
        [TestMethod]
        public void TestConstructor()
        {
            Assert.IsNotNull(new RandomOrgV1());
        }


    }
}
