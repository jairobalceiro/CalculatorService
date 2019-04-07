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

            moqDaoCalculators.Setup(r => r.Add(Addends)).Returns(new Sums());

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);

            Assert.AreEqual(serviceCalculators.Add(Addends), addresult);
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

            moqDaoCalculators.Setup(r => r.Sub(minuend, substraned)).Returns(new Sub());

            ServiceCalculators serviceCalculators = new ServiceCalculators(moqDaoCalculators.Object);

            Assert.AreEqual(serviceCalculators.Sub(minuend, substraned), addresult);
        }
    }
}
