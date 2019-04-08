using CalculatorService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Data
{
    public interface IDaoCalculators
    {
        /// <summary>
        /// This method serves UC-­CALC-­ADD external interface
        /// </summary>
        /// <param name="Addends">the input of the arithmetic operation.</param>
        /// <returns>the arithmetic operation result</returns>       
        Sums Add(List<int> Addends);

        /// <summary>
        /// This method serves UC-­CALC-­SUB external interface
        /// </summary>
        /// <param name="Minuend">the minuend of the arithmetic subtraction.</param>
        /// <param name="Subtrahend">the subtrahend of the arithmetic subtraction</param>
        /// <returns>Represent the arithmetic operation result</returns>
        Sub Sub(int Minuend, int Subtrahend);

        /// <summary>
        ///  This method serves UC­CALC­MUL external interface.
        /// </summary>
        /// <param name="Factors">the inputs of a arithmetic operation</param>
        /// <returns>the arithmetic operation result</returns>
        Mult Mult(List<int> Factors);

        /// <summary>
        /// This method serves UC­-CALC-­DIV external interface 
        /// </summary>
        /// <param name="Dividend">the dividend of the arithmetic division.</param>
        /// <param name="Divisor">the divisor of the arithmetic division</param>
        /// <returns>the arithmetic operation result</returns>
        Div Div(int Dividend, int Divisor);

        /// <summary>
        /// This method serves UC­-CALC­-SQRT external interface
        /// </summary>
        /// <param name="Number">the input of the square root mathematical function.</param>
        /// <returns>the arithmetic operation result</returns>
        Sqrt Sqrt(int Number);

        /// <summary>
        /// This method serves UC­-CALC-­QUERY external interface
        /// </summary>
        /// <param name="Id">The Tracking­Id for which journal should be queried against</param>
        /// <returns>List of all the operations performed with the specified Tracking­Id</returns>
        ICollection<Operations> Query(string Id);

        /// <summary>
        /// Save Journal 
        /// </summary>
        /// <param name="operation">Object of operations</param>
        void SaveJournal(Operations operation);
    }
}
