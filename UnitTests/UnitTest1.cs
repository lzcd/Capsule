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
            var result = host.Evaluate(@"(1 2 3 4)");
            Assert.AreEqual("(1 2 3 4)", result);
        }

        [TestMethod]
        public void CanAdd()
        {
            var host = new Host();
            var result = host.Evaluate(@"(+ 1 (+ 2 3) 4)");
            Assert.AreEqual("10", result);
        }

        [TestMethod]
        public void CanLambda()
        {
            var host = new Host();
            var result = host.Evaluate(@"((lambda (x y) (+ x y 5)) 7 9)");
            Assert.AreEqual("21", result);
        }

        [TestMethod]
        public void CanDefineSimple()
        {
            var host = new Host();
            var result = host.Evaluate(@"(define age 35) age");
            Assert.AreEqual("35", result);
        }

        [TestMethod]
        public void CanDefineComplex()
        {
            var host = new Host();
            var result = host.Evaluate(@"(define (square x) (* x x)) (square 21)");
            Assert.AreEqual("441", result);
        }
    }
}
