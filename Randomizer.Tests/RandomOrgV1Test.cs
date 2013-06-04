using System;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Randomizer.Utils;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Randomizer.Tests
{
    [TestClass]
    public class RandomOrgV1Test
    {
        [TestMethod]
        public void TestConstructor()
        {
            Assert.IsNotNull(new RandomOrgV1());
        }

        [TestMethod]
        public void TestBaseAddress()
        {
            Assert.AreEqual("http://random.org", new RandomOrgV1().BaseAddress());
        }

        [TestMethod]
        public void TestRequestAddressShouldNotBeNull()
        {
            var randomOrg = new RandomOrgV1();
            Assert.IsNotNull(randomOrg.RequestAddress);
        }

        [TestMethod]
        public void TestFormatBase()
        {
            var randomOrg = new RandomOrgV1();

            Assert.AreEqual("base2", randomOrg.FormatBase(BaseEnum.Binary));
            Assert.AreEqual("base8", randomOrg.FormatBase(BaseEnum.Octal));
            Assert.AreEqual("base10", randomOrg.FormatBase(BaseEnum.Decimal));
            Assert.AreEqual("base16", randomOrg.FormatBase(BaseEnum.Hexa));
        }

        [TestMethod]
        public void TestFluentIntegersAddress()
        {
            var randomOrg = new RandomOrgV1();

            Assert.AreEqual("http://random.org/integers?num=1&min=1&max=100&col=1&base=10&format=plain&rnd=new", randomOrg.IntegerRequest(1, 100).RequestAddress.AbsoluteUri);
        }

        [TestMethod]
        public void TestFormatQueryString()
        {
            var randomOrg = new RandomOrgV1();

            Assert.AreEqual("http://random.org/?num=1&min=1&max=6&col=1&base=10&format=plain&rnd=new", randomOrg.FormatQueryString(1, 6).AbsoluteUri);
            Assert.AreEqual("http://random.org/?num=1&min=1&max=60&col=1&base=10&format=plain&rnd=new", randomOrg.FormatQueryString(1, 60).AbsoluteUri);
            Assert.AreEqual("http://random.org/?num=1&min=10&max=60&col=1&base=10&format=plain&rnd=new", randomOrg.FormatQueryString(10, 60).AbsoluteUri);
            Assert.AreEqual("http://random.org/?num=1&min=-100&max=-60&col=1&base=10&format=plain&rnd=new", randomOrg.FormatQueryString(-100, -60).AbsoluteUri);
        }

        [TestMethod]
        public void TestMinGreaterThanMaxException()
        {
            var randomOrg = new RandomOrgV1();

            Assert.ThrowsException<RandoOrgMinGreaterThanMaxException>(() => randomOrg.IntegerRequest(6, 1));
            Assert.ThrowsException<RandoOrgMinGreaterThanMaxException>(() => randomOrg.IntegerRequest(-60, -100));
        }

        public async Task<string> CallRequestAsync()
        {
            var randomOrg = new RandomOrgV1();

            var result = await randomOrg.IntegerRequest(1, 100).Request();

            return result;
        }
    }
}
