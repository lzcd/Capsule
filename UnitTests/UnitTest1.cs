﻿using System;
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

        [TestMethod]
        public void CanDefineComposedComplex()
        {
            var host = new Host();
            var result = host.Evaluate(@"
(define (square x) (* x x)) 

(define (sum-of-squares x y)
  (+ (square x) (square y)))

(sum-of-squares 3 4)");
            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void CanDefineNestedComplex()
        {
            var host = new Host();
            var result = host.Evaluate(@"
(define (sum-of-squares x y)
    (define (square a) (* a a))
    (+ (square x) (square y))
)

(sum-of-squares 3 4)");
            Assert.AreEqual("25", result);
        }

        [TestMethod]
        public void CanDefineClosure()
        {
            var host = new Host();
            var result = host.Evaluate(@"
(define y 5) 

(define (calculate x) (+ x y z))

(define y 7)
(define z 9)

(calculate 3)");
            Assert.AreEqual("17", result);
        }

        [TestMethod]
        public void CanMultiply()
        {
            var host = new Host();
            var result = host.Evaluate(@"(* 2 (* 3 4) 5)");
            Assert.AreEqual("120", result);
        }

        [TestMethod]
        public void CanSubtract()
        {
            var host = new Host();
            var result = host.Evaluate(@"(- 10 (- 5 3) 3)");
            Assert.AreEqual("5", result);
        }

        [TestMethod]
        public void CanDivide()
        {
            var host = new Host();
            var result = host.Evaluate(@"(/ 100 (/ 10 2) 5)");
            Assert.AreEqual("4", result);
        }

        [TestMethod]
        public void CanNegate()
        {
            var host = new Host();
            var result = host.Evaluate(@"(- 5)");
            Assert.AreEqual("-5", result);
        }

        [TestMethod]
        public void CanIfTrue()
        {
            var host = new Host();
            var result = host.Evaluate(@"(if true 1 2)");
            Assert.AreEqual("1", result);
        }

        [TestMethod]
        public void CanIfFalse()
        {
            var host = new Host();
            var result = host.Evaluate(@"(if false 2 3)");
            Assert.AreEqual("3", result);
        }

        [TestMethod]
        public void CanEqualPositive()
        {
            var host = new Host();
            var result = host.Evaluate(@"(= 4 4 4)");
            Assert.AreEqual("true", result);
        }

        [TestMethod]
        public void CanEqualNegative()
        {
            var host = new Host();
            var result = host.Evaluate(@"(= 4 5 4)");
            Assert.AreEqual("false", result);
        }
    }
}
