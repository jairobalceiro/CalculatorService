using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using CalculatorService.Data;
using CalculatorService.Model;
using CalculatorService.Service;

namespace CalculatorService.Test
{
    /// <summary>
    /// Service Calculators tests.
    /// </summary>
    [TestClass]
    public class ServiceCalculatorsTests
    {
        /// <summary>
        /// This method serves UC-­CALC-­ADD external interface
        /// </summary>
        [TestMethod]
        public void AddTest()
        {
            List<int> Addends = new List<int>();
            int addresult = 8;

            Addends.Add(3);
            Addends.Add(3);
            Addends.Add(2);

            var moqDaoCalculators = new Mock<IDaoCalculators>();

            moqDaoCalculators.Setup(r => r.Add(Addends)).Returns(new Sums() { Sum=8});

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);
            int sum = serviceCalculators.Add(Addends).Sum;
            Assert.AreEqual(sum, addresult);
        }


        /// <summary>
        /// This method serves UC-­CALC-­SUB external interface
        /// </summary>
        [TestMethod]
        public void SubTest()
        {
            int addresult = 3;
            int minuend = 5;
            int substraned = 2;
            

            var moqDaoCalculators = new Mock<IDaoCalculators>();

            moqDaoCalculators.Setup(r => r.Sub(minuend, substraned)).Returns(new Sub() { Difference = 3});

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);
            int result = serviceCalculators.Sub(minuend, substraned).Difference;
            Assert.AreEqual(result, addresult);
        }


        /// <summary>
        /// This method serves UC-­CALC-­MULT external interface
        /// </summary>
        [TestMethod]
        public void MultTest()
        {
            List<int> Factors = new List<int>();
            int addresult = 48;

            Factors.Add(8);
            Factors.Add(3);
            Factors.Add(2);

            var moqDaoCalculators = new Mock<IDaoCalculators>();

            moqDaoCalculators.Setup(r => r.Mult(Factors)).Returns(new Mult() { Product = 48});

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);

            int result = serviceCalculators.Mult(Factors).Product;

            Assert.AreEqual(result, addresult);
        }

        /// <summary>
        /// This method serves UC-­CALC-­DIV external interface
        /// </summary>
        [TestMethod]
        public void DivTest()
        {
            int dividend = 11;
            int divisor = 2;
            int quotient = 5;
            int remainder = 1;   

            var moqDaoCalculators = new Mock<IDaoCalculators>();

            moqDaoCalculators.Setup(r => r.Div(dividend,divisor)).Returns(new Div() { Quotient = quotient, Remainder = remainder });

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);

            Div restult = serviceCalculators.Div(dividend, divisor);

            Assert.AreEqual(quotient, restult.Quotient);
            Assert.AreEqual(remainder, restult.Remainder);
        }

        /// <summary>
        /// This method serves UC-­CALC-­SQRT external interface
        /// </summary>
        [TestMethod]
        public void SqrtTest()
        {
            int number = 16;
            int square = 4;

            var moqDaoCalculators = new Mock<IDaoCalculators>();

            moqDaoCalculators.Setup(r => r.Sqrt(number)).Returns(new Sqrt() { Square = square });

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);
            double result = serviceCalculators.Sqrt(number).Square;
            Assert.AreEqual(result, square);
        }
    }
}
