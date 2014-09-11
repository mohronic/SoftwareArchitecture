using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PolishCalculator;

namespace PolishCalculator.test
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void RequiredTest()
        {
            string[] input = { "5", "1", "2", "+", "4", "*", "+", "3", "-" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 14;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void NullTest()
        {
            string[] input = new string[1];
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 0;
        	Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EmptyStringTest()
        {
            string[] input = {""};
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void TooFewOperatorsTest()
        {
            string[] input = { "5", "1", "2", "4", "*", "+", "3", "-" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DivideByZeroTest()
        {
            string[] input = { "5", "1", "2", "+", "4", "*", "+", "0", "/" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void WrongOperatorTest()
        {
            string[] input = { "5", "1", "2", "j", "4", "*", "+", "4", "/" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MaxIntegerTest()
        {
            
            string[] input = { Int32.MaxValue.ToString(), "1", "+" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = Int32.MinValue;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void MinIntegerTest()
        {

            string[] input = { Int32.MinValue.ToString(), "1", "-" };
            int actual = Calculator.DoThePolishStuff(input);
            int expected = Int32.MaxValue;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void SimpleTests()
        {
            string[] input;
            int actual;
            int expected;
            // Addition
            input = new []{"5", "5", "+"};
            actual = Calculator.DoThePolishStuff(input);
            expected = 10;
            Assert.AreEqual(expected, actual);
            // Subtraction
            input = new[] { "12", "5", "-" };
            actual = Calculator.DoThePolishStuff(input);
            expected = 7;
            Assert.AreEqual(expected, actual);
            // Multiplication
            input = new[] { "5", "5", "*" };
            actual = Calculator.DoThePolishStuff(input);
            expected = 25;
            Assert.AreEqual(expected, actual);
            // Division
            input = new[] { "21", "7", "/" };
            actual = Calculator.DoThePolishStuff(input);
            expected = 3;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ComplexTest()
        {
            string[] input = { "3", "4", "*", "1", "+", "2", "/", "3", "-"};
            int actual = Calculator.DoThePolishStuff(input);
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
    }
}
