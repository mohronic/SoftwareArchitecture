using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PolishCalculator.test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void RequiredTest()
        {
            Calculator c = new Calculator();
            string input = "5 1 2 + 4 * + 3 -";
            double actual = c.Calc(input);
            double expected = 14;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NullTest()
        {
            Calculator c = new Calculator();
            string input = null;
            double actual = c.Calc(input);
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EmptyStringTest()
        {
            Calculator c = new Calculator();
            string input = "";
            double actual = c.Calc(input);
            double expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "too many tokens")]
        public void TooFewOperatorsTest()
        {
            Calculator c = new Calculator();
            string input = "5 1 2 4 * + 3 -";
            double actual = c.Calc(input);

        }
        [TestMethod]
        public void DivideByZeroTest()
        {
            Calculator c = new Calculator();
            string input = "5 1 2 + 4 * + 0 /";
            double actual = c.Calc(input);
            Assert.IsTrue(double.IsInfinity(actual));
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Wrong token: j, check input")]
        public void WrongOperatorTest()
        {
            Calculator c = new Calculator();
            string input = "5 1 2 j 4 * + 4 /";
            double actual = c.Calc(input);
        }

        [TestMethod]
        public void SimpleTests()
        {
            Calculator c = new Calculator();
            string input;
            double actual;
            double expected;

            // Addition
            input = "5 5 +";
            actual = c.Calc(input);
            expected = 10;
            Assert.AreEqual(expected, actual);
            // Subtraction
            input = "12 5 -";
            actual = c.Calc(input);
            expected = 7;
            Assert.AreEqual(expected, actual);
            // Multiplication
            input = "5 5 *";
            actual = c.Calc(input);
            expected = 25;
            Assert.AreEqual(expected, actual);
            // Division
            input = "21 7 /";
            actual = c.Calc(input);
            expected = 3;
            Assert.AreEqual(expected, actual);
            // Power
            input = "2 3 ^";
            actual = c.Calc(input);
            expected = 8;
            Assert.AreEqual(expected, actual);
            // Absolute
            input = "-21 abs";
            actual = c.Calc(input);
            expected = 21;
            Assert.AreEqual(expected, actual);
            // Squareroot
            input = "9 sqrt";
            actual = c.Calc(input);
            expected = 3;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComplexTest()
        {
            Calculator c = new Calculator();
            string input = "3 4 * 1 + 2 / 3 -";
            double actual = c.Calc(input);
            double expected = 3.5;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DoubleDotTest()
        {
            Calculator c = new Calculator();
            string input = "3.5 3.5 +";
            double actual = c.Calc(input);
            double expected = 7;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// comma is currently read as 5,0 = 50, so the program doesn't handle comma doubles right.
        /// </summary>
        [TestMethod]
        public void DoubleCommaTest()
        {
            Calculator c = new Calculator();
            string input = "5,0 2,5 +";
            double actual = c.Calc(input);
            double expected = 7.5;
            Assert.AreEqual(expected, actual);
        }
    }
}

