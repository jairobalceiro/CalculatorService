using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Dtos
{
    /// <summary>
    /// Calss Add Dto
    /// </summary>
    public class AddDto
    {
        /// <summary>
        /// Represents the input of the arithmetic operation.
        /// </summary>
        public List<int> Addends { get; set; }
    }
}
