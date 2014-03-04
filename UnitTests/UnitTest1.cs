using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capsule;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanList()
        {
            var host = new Host();
            var result = host.Evaluate(@"1 2 3 4");
            Assert.AreEqual("(1 2 3 4)", result);
        }

        [TestMethod]
        public void CanAdd()
        {
            var host = new Host();
            var result = host.Evaluate(@"+ 1 (+ 2 3) 4");
            Assert.AreEqual("10", result);
        }
    }
}
