using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Dtos
{
    /// <summary>
    /// Class Div DTO
    /// </summary>
    public class DivDto
    {
        /// <summary>
        /// Represents the dividend of the arithmetic division.
        /// </summary>
        public int Dividend { get; set; }
        /// <summary>
        /// Represents the divisor of the arithmetic division.
        /// </summary>
        public int Divisor { get; set; }
    }
}
