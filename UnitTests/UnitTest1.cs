using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capsule;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var host = new Host();
            host.Evaluate(@"(+ 1 (+ 2 3) 4)");
        }
    }
}
