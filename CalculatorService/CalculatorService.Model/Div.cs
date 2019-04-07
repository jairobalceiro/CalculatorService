using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorService.Model
{
    /// <summary>
    /// Class for Div result
    /// </summary>
    public class Div
    {
        /// <summary>
        /// the arithmetic operation result.
        /// </summary>
        public int Quotient { get; set; }
        /// <summary>
        /// The remained of the arithmetic division
        /// </summary>
        public int Remainder { get; set; }
    }
}
