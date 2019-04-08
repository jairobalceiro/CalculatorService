using System;
using System.Collections.Generic;
using System.Text;
using CalculatorService.Data;
using CalculatorService.Model;

namespace CalculatorService.Service
{
    /// <summary>
    /// service calculators
    /// </summary>
    public class ServiceCalculators : IServiceCalculators
    {
        /// <summary>
        /// The DAO Calculators.
        /// </summary>
        private readonly IDaoCalculators daoCalculators;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Service.ServiceCalculators"/> class.
        /// </summary>
        public ServiceCalculators(IDaoCalculators dao)
        {
            this.daoCalculators = dao;
        }

        /// <summary>
        /// This method serves UC-­CALC-­ADD external interface
        /// </summary>
        /// <param name="Addends">the input of the arithmetic operation.</param>
        /// <returns>the arithmetic operation result</returns>
        public Sums Add(List<int> Addends)
        {
            try
            {
                return daoCalculators.Add(Addends);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Add Sums", ex);
            }
        }

        /// <summary>
        /// This method serves UC­-CALC-­DIV external interface 
        /// </summary>
        /// <param name="Dividend">the dividend of the arithmetic division.</param>
        /// <param name="Divisor">the divisor of the arithmetic division</param>
        /// <returns>the arithmetic operation result</returns>
        public Div Div(int Dividend, int Divisor)
        {
            try
            {
                return daoCalculators.Div(Dividend, Divisor);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Add Sums", ex);
            }
        }

        /// <summary>
        ///  This method serves UC­CALC­MUL external interface.
        /// </summary>
        /// <param name="Factors">the inputs of a arithmetic operation</param>
        /// <returns>the arithmetic operation result</returns>
        public Mult Mult(List<int> Factors)
        {
            try
            {
                return daoCalculators.Mult(Factors);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Add Mult", ex);
            }
        }

        /// <summary>
        /// This method serves UC­-CALC-­QUERY external interface
        /// </summary>
        /// <param name="Id">The Tracking­Id for which journal should be queried against</param>
        /// <returns>List of all the operations performed with the specified Tracking­Id</returns>
        public ICollection<Operations> Query(string Id)
        {
            try
            {
                return daoCalculators.Query(Id);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Sub", ex);
            }
        }

        /// <summary>
        /// Save Journal 
        /// </summary>
        /// <param name="operation">Object of operations</param>
        public void SaveJournal(Operations operation)
        {
            try
            {
                 daoCalculators.SaveJournal(operation);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service save journal", ex);
            }
        }

        /// <summary>
        /// This method serves UC­-CALC­-SQRT external interface
        /// </summary>
        /// <param name="Number">the input of the square root mathematical function.</param>
        /// <returns>the arithmetic operation result</returns>
        public Sqrt Sqrt(int Number)
        {
            try
            {
                return daoCalculators.Sqrt(Number);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Sub", ex);
            }
        }

        /// <summary>
        /// This method serves UC-­CALC-­SUB external interface
        /// </summary>
        /// <param name="Minuend">the minuend of the arithmetic subtraction.</param>
        /// <param name="Subtrahend">the subtrahend of the arithmetic subtraction</param>
        /// <returns>Represent the arithmetic operation result</returns>
        public Sub Sub(int Minuend, int Subtrahend)
        {
            try
            {
                return daoCalculators.Sub(Minuend, Subtrahend);
            }
            catch (DataException ex)
            {
                throw new ServiceException("Error service Sub", ex);
            }
        }
    }
}
