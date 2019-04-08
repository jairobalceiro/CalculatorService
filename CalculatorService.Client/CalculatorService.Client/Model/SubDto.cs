using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Dtos
{
    /// <summary>
    /// Class SubDto
    /// </summary>
    public class SubDto
    {
        /// <summary>
        /// Represents the minuend of the arithmetic subtraction.
        /// </summary>
        public int Minuend { get; set; }
        /// <summary>
        /// Represents the subtrahend of the arithmetic subtraction.
        /// </summary>
        public int Subtrahend { get; set; }
    }
}
