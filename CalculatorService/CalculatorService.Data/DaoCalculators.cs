using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CalculatorService.Model;

namespace CalculatorService.Data
{
    /// <summary>
    /// Dao Calculators 
    /// </summary>
    public class DaoCalculators : IDaoCalculators
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:CalculatorService.Data.DaoCalculators"/> class.
        /// </summary>
        public DaoCalculators()
        {
                
        }

        /// <summary>
        /// This method serves UC-­CALC-­ADD external interface
        /// </summary>
        /// <param name="Addends">the input of the arithmetic operation.</param>
        /// <returns>the arithmetic operation result</returns>          
        public Sums Add(List<int> Addends)
        {
            Sums sum = new Sums();
            try
            {
                sum.Sum = Addends.Sum();
            }
            catch (Exception ex)
            {
                throw new DataException("Error dao Add.", ex);
            }

            return sum;
        }

        /// <summary>
        /// This method serves UC­-CALC-­DIV external interface 
        /// </summary>
        /// <param name="Dividend">the dividend of the arithmetic division.</param>
        /// <param name="Divisor">the divisor of the arithmetic division</param>
        /// <returns>the arithmetic operation result</returns>
        public Div Div(int Dividend, int Divisor)
        {
            Div div = new Div();
            int remainder = 0;
            int quotient = 0;
            try
            {
                quotient = Math.DivRem(Dividend, Divisor, out remainder);
                div.Quotient = quotient;
                div.Remainder = remainder;

            }
            catch (Exception ex)
            {
                throw new DataException("Error dao Sub.", ex);
            }

            return div;
        }

        /// <summary>
        ///  This method serves UC­-CALC­-MUL external interface.
        /// </summary>
        /// <param name="Factors">the inputs of a arithmetic operation</param>
        /// <returns>the arithmetic operation result</returns>
        public Mult Mult(List<int> Factors)
        {
            Mult mul = new Mult();
            try
            {
                mul.Product = Factors.Aggregate((total, next) => total * next); ;
            }
            catch (Exception ex)
            {
                throw new DataException("Error dao Add.", ex);
            }

            return mul;
        }

        /// <summary>
        /// This method serves UC­-CALC-­QUERY external interface
        /// </summary>
        /// <param name="Id">The Tracking­Id for which journal should be queried against</param>
        /// <returns>List of all the operations performed with the specified Tracking­Id</returns>
        public ICollection<Operations> Query(string Id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method serves UC­-CALC­-SQRT external interface
        /// </summary>
        /// <param name="Number">the input of the square root mathematical function.</param>
        /// <returns>the arithmetic operation result</returns>
        public Sqrt Sqrt(int Number)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method serves UC-­CALC-­SUB external interface
        /// </summary>
        /// <param name="Minuend">the minuend of the arithmetic subtraction.</param>
        /// <param name="Subtrahend">the subtrahend of the arithmetic subtraction</param>
        /// <returns>Represent the arithmetic operation result</returns>
        public Sub Sub(int Minuend, int Subtrahend)
        {
            Sub sub = new Sub();

            try
            {
                sub.Difference = Minuend - Math.Abs(Subtrahend);
            }
            catch (Exception ex)
            {
                throw new DataException("Error dao Sub.", ex);
            }

            return sub;
        }
    }
}
